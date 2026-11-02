using BE;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class DALReporteInteligente
    {
        private readonly string cadena = "Data Source=.;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;Initial Catalog=EverGlow;";

        public List<BEItemEstadistico> ObtenerVentasPorEditorial(DateTime fechaDesde, DateTime fechaHasta)
        {
            List<BEItemEstadistico> lista = new List<BEItemEstadistico>();
            string query = @"SELECT ISNULL(NULLIF(LTRIM(RTRIM(l.Editorial_657SGA)), ''), 'Otras') AS Editorial,
                                    SUM(df.Cantidad) AS Cantidad,
                                    SUM(df.Cantidad * df.Precio) AS TotalRecaudado
                             FROM DetalleFactura df
                             INNER JOIN Factura f ON df.IdFactura = f.IdFactura
                             INNER JOIN Libro l ON df.ISBN_657SGA = l.ISBN_657SGA
                             WHERE f.Fecha >= @FechaDesde AND f.Fecha <= @FechaHasta
                               AND f.NumeroFactura LIKE 'FC-V%'
                             GROUP BY l.Editorial_657SGA
                             ORDER BY TotalRecaudado DESC;";

            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.Add("@FechaDesde", SqlDbType.Date).Value = fechaDesde.Date;
                    cmd.Parameters.Add("@FechaHasta", SqlDbType.Date).Value = fechaHasta.Date;
                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new BEItemEstadistico
                            {
                                Etiqueta = reader["Editorial"].ToString() ?? "Otras",
                                Cantidad = Convert.ToInt32(reader["Cantidad"]),
                                TotalRecaudado = Convert.ToDecimal(reader["TotalRecaudado"])
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public List<BEItemEstadistico> ObtenerDemandaPorAutor(DateTime fechaDesde, DateTime fechaHasta)
        {
            List<BEItemEstadistico> lista = new List<BEItemEstadistico>();
            string query = @"SELECT Autor, SUM(Cantidad) AS Cantidad, SUM(TotalRecaudado) AS TotalRecaudado
                             FROM (
                                 SELECT ISNULL(NULLIF(LTRIM(RTRIM(l.Autor_657SGA)), ''), 'Autor No Especificado') AS Autor,
                                        SUM(df.Cantidad) AS Cantidad,
                                        SUM(df.Cantidad * df.Precio) AS TotalRecaudado
                                 FROM DetalleFactura df
                                 INNER JOIN Factura f ON df.IdFactura = f.IdFactura
                                 INNER JOIN Libro l ON df.ISBN_657SGA = l.ISBN_657SGA
                                 WHERE f.Fecha >= @FechaDesde AND f.Fecha <= @FechaHasta
                                 GROUP BY l.Autor_657SGA

                                 UNION ALL

                                 SELECT ISNULL(NULLIF(LTRIM(RTRIM(l.Autor_657SGA)), ''), 'Autor No Especificado') AS Autor,
                                        COUNT(p.IdPrestamo) AS Cantidad,
                                        SUM(p.MontoPrestamo + p.MontoRecargo) AS TotalRecaudado
                                 FROM Prestamo p
                                 INNER JOIN Libro l ON p.ISBN = l.ISBN_657SGA
                                 WHERE p.FechaInicio >= @FechaDesde AND p.FechaInicio <= @FechaHasta
                                 GROUP BY l.Autor_657SGA
                             ) AS Sub
                             GROUP BY Autor
                             ORDER BY Cantidad DESC;";

            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.Add("@FechaDesde", SqlDbType.Date).Value = fechaDesde.Date;
                    cmd.Parameters.Add("@FechaHasta", SqlDbType.Date).Value = fechaHasta.Date;
                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new BEItemEstadistico
                            {
                                Etiqueta = reader["Autor"].ToString() ?? "Autor No Especificado",
                                Cantidad = Convert.ToInt32(reader["Cantidad"]),
                                TotalRecaudado = Convert.ToDecimal(reader["TotalRecaudado"])
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public (int ventasCount, int ejemplaresVendidos, decimal ventasTotal, int prestamosCount, int prestamosFinalizados, int prestamosMora, decimal prestamosTotal, decimal recargosTotal) ObtenerTotales(DateTime fechaDesde, DateTime fechaHasta)
        {
            int vCount = 0;
            int ejVendidos = 0;
            decimal vTotal = 0m;

            int pCount = 0;
            int pFinalizados = 0;
            int pMora = 0;
            decimal pTotal = 0m;
            decimal recargos = 0m;

            string queryVentas = @"SELECT COUNT(DISTINCT f.IdFactura) AS VentasCount,
                                          ISNULL(SUM(df.Cantidad), 0) AS EjemplaresVendidos,
                                          ISNULL(SUM(df.Cantidad * df.Precio), 0) AS TotalVentas
                                   FROM Factura f
                                   LEFT JOIN DetalleFactura df ON f.IdFactura = df.IdFactura
                                   WHERE f.Fecha >= @FechaDesde AND f.Fecha <= @FechaHasta
                                     AND f.NumeroFactura LIKE 'FC-V%';";

            string queryPrestamos = @"SELECT COUNT(p.IdPrestamo) AS PrestamosCount,
                                             ISNULL(SUM(CASE WHEN p.Estado LIKE 'Finalizado%' THEN 1 ELSE 0 END), 0) AS Finalizados,
                                             ISNULL(SUM(CASE WHEN p.MontoRecargo > 0 OR p.Estado = 'Finalizado con Mora' THEN 1 ELSE 0 END), 0) AS ConMora,
                                             ISNULL(SUM(p.MontoPrestamo), 0) AS TotalPrestamos,
                                             ISNULL(SUM(p.MontoRecargo), 0) AS TotalRecargos
                                      FROM Prestamo p
                                      WHERE p.FechaInicio >= @FechaDesde AND p.FechaInicio <= @FechaHasta;";

            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                conexion.Open();
                using (SqlCommand cmdV = new SqlCommand(queryVentas, conexion))
                {
                    cmdV.Parameters.Add("@FechaDesde", SqlDbType.Date).Value = fechaDesde.Date;
                    cmdV.Parameters.Add("@FechaHasta", SqlDbType.Date).Value = fechaHasta.Date;
                    using (SqlDataReader r = cmdV.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            vCount = Convert.ToInt32(r["VentasCount"]);
                            ejVendidos = Convert.ToInt32(r["EjemplaresVendidos"]);
                            vTotal = Convert.ToDecimal(r["TotalVentas"]);
                        }
                    }
                }

                using (SqlCommand cmdP = new SqlCommand(queryPrestamos, conexion))
                {
                    cmdP.Parameters.Add("@FechaDesde", SqlDbType.Date).Value = fechaDesde.Date;
                    cmdP.Parameters.Add("@FechaHasta", SqlDbType.Date).Value = fechaHasta.Date;
                    using (SqlDataReader r = cmdP.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            pCount = Convert.ToInt32(r["PrestamosCount"]);
                            pFinalizados = Convert.ToInt32(r["Finalizados"]);
                            pMora = Convert.ToInt32(r["ConMora"]);
                            pTotal = Convert.ToDecimal(r["TotalPrestamos"]);
                            recargos = Convert.ToDecimal(r["TotalRecargos"]);
                        }
                    }
                }
            }

            return (vCount, ejVendidos, vTotal, pCount, pFinalizados, pMora, pTotal, recargos);
        }

        public List<(string Titulo, string Autor, int ExistenciasVenta, int ExistenciasPrestamo, int TotalMovimientos)> ObtenerMovimientosPorLibro(DateTime fechaDesde, DateTime fechaHasta)
        {
            List<(string Titulo, string Autor, int ExistenciasVenta, int ExistenciasPrestamo, int TotalMovimientos)> lista = new List<(string Titulo, string Autor, int ExistenciasVenta, int ExistenciasPrestamo, int TotalMovimientos)>();
            string query = @"SELECT l.Título_657SGA AS Titulo,
                                    ISNULL(l.Autor_657SGA, 'N/A') AS Autor,
                                    l.Existencias_657SGA AS ExistenciasVenta,
                                    l.ExistenciasPrestamo,
                                    ISNULL(v.Vendidos, 0) + ISNULL(p.Prestados, 0) AS TotalMovimientos
                             FROM Libro l
                             LEFT JOIN (
                                 SELECT df.ISBN_657SGA, SUM(df.Cantidad) AS Vendidos
                                 FROM DetalleFactura df
                                 INNER JOIN Factura f ON df.IdFactura = f.IdFactura
                                 WHERE f.Fecha >= @FechaDesde AND f.Fecha <= @FechaHasta
                                 GROUP BY df.ISBN_657SGA
                             ) v ON l.ISBN_657SGA = v.ISBN_657SGA
                             LEFT JOIN (
                                 SELECT p.ISBN, COUNT(p.IdPrestamo) AS Prestados
                                 FROM Prestamo p
                                 WHERE p.FechaInicio >= @FechaDesde AND p.FechaInicio <= @FechaHasta
                                 GROUP BY p.ISBN
                             ) p ON l.ISBN_657SGA = p.ISBN
                             ORDER BY TotalMovimientos DESC;";

            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.Add("@FechaDesde", SqlDbType.Date).Value = fechaDesde.Date;
                    cmd.Parameters.Add("@FechaHasta", SqlDbType.Date).Value = fechaHasta.Date;
                    conexion.Open();
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            lista.Add((
                                r["Titulo"].ToString() ?? "Libro",
                                r["Autor"].ToString() ?? "N/A",
                                Convert.ToInt32(r["ExistenciasVenta"]),
                                Convert.ToInt32(r["ExistenciasPrestamo"]),
                                Convert.ToInt32(r["TotalMovimientos"])
                            ));
                        }
                    }
                }
            }
            return lista;
        }
    }
}
