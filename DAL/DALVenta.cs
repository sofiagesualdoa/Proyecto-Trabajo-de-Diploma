using BE;
using Microsoft.Data.SqlClient;
using Servicios;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class DALVenta
    {
        private readonly string cadena = "Data Source=.;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;Initial Catalog=EverGlow;";
        private readonly GeneradorDigVerificador generador = new GeneradorDigVerificador();

        public void GuardarVenta(BEVenta venta, BEFactura factura, List<BEDetalleVenta> detalles)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                conexion.Open();
                using (SqlTransaction transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        // 1. INSERT EN FACTURA
                        string queryFactura = @"INSERT INTO Factura (NumeroFactura, Fecha, Hora, Total, DNICliente, DVH) 
                                                VALUES (@NumeroFactura, @Fecha, @Hora, @Total, @DNICliente, @DVH);
                                                SELECT CAST(SCOPE_IDENTITY() AS INT);";

                        int idFactura;
                        using (SqlCommand cmdFactura = new SqlCommand(queryFactura, conexion, transaccion))
                        {
                            cmdFactura.Parameters.Add("@NumeroFactura", SqlDbType.VarChar, 50).Value = factura.NumeroFactura;
                            cmdFactura.Parameters.Add("@Fecha", SqlDbType.Date).Value = factura.Fecha;
                            cmdFactura.Parameters.Add("@Hora", SqlDbType.Time).Value = factura.Hora;
                            cmdFactura.Parameters.Add("@Total", SqlDbType.Decimal).Value = factura.Total;
                            cmdFactura.Parameters.Add("@DNICliente", SqlDbType.Int).Value = factura.DNICliente;
                            cmdFactura.Parameters.Add("@DVH", SqlDbType.VarChar, 64).Value = DBNull.Value;
                            idFactura = Convert.ToInt32(cmdFactura.ExecuteScalar());
                        }

                        factura.IdFactura = idFactura;
                        venta.IdVenta = idFactura;

                        BEFactura facturaParaDVH = new BEFactura
                        {
                            IdFactura = idFactura,
                            NumeroFactura = factura.NumeroFactura,
                            Fecha = factura.Fecha,
                            Hora = factura.Hora,
                            Total = factura.Total,
                            DNICliente = factura.DNICliente
                        };
                        factura.DVH = generador.GenerarDVH(facturaParaDVH);
                        venta.DVH = factura.DVH;

                        string queryUpdateDVHFactura = "UPDATE Factura SET DVH = @DVH WHERE IdFactura = @IdFactura;";
                        using (SqlCommand cmdDVHFactura = new SqlCommand(queryUpdateDVHFactura, conexion, transaccion))
                        {
                            cmdDVHFactura.Parameters.Add("@DVH", SqlDbType.VarChar, 64).Value = factura.DVH;
                            cmdDVHFactura.Parameters.Add("@IdFactura", SqlDbType.Int).Value = idFactura;
                            cmdDVHFactura.ExecuteNonQuery();
                        }

                        // 2. INSERT EN DETALLE FACTURA
                        string queryDetalleFactura = @"INSERT INTO DetalleFactura (IdFactura, ISBN_657SGA, Cantidad, Precio, DVH) 
                                                       VALUES (@IdFactura, @ISBN, @Cantidad, @Precio, @DVH);
                                                       SELECT CAST(SCOPE_IDENTITY() AS INT);";

                        string queryUpdateDVHDetalleFactura = "UPDATE DetalleFactura SET DVH = @DVH WHERE IdDetalleFactura = @IdDetalleFactura;";

                        foreach (var item in detalles)
                        {
                            int idDetalleFactura;
                            using (SqlCommand cmdDetalleFactura = new SqlCommand(queryDetalleFactura, conexion, transaccion))
                            {
                                cmdDetalleFactura.Parameters.Add("@IdFactura", SqlDbType.Int).Value = idFactura;
                                cmdDetalleFactura.Parameters.Add("@ISBN", SqlDbType.VarChar, 13).Value = item.ISBN;
                                cmdDetalleFactura.Parameters.Add("@Cantidad", SqlDbType.Int).Value = item.Cantidad;
                                cmdDetalleFactura.Parameters.Add("@Precio", SqlDbType.Decimal).Value = item.PrecioUnitario;
                                cmdDetalleFactura.Parameters.Add("@DVH", SqlDbType.VarChar, 64).Value = DBNull.Value;
                                idDetalleFactura = Convert.ToInt32(cmdDetalleFactura.ExecuteScalar());
                            }

                            item.IdDetalleVenta = idDetalleFactura;
                            item.IdVenta = idFactura;

                            BEDetalleFactura detalleFacturaParaDVH = new BEDetalleFactura
                            {
                                IdDetalleFactura = idDetalleFactura,
                                IdFactura = idFactura,
                                ISBN = item.ISBN,
                                Cantidad = item.Cantidad,
                                Precio = item.PrecioUnitario
                            };
                            string dvhDetalleFactura = generador.GenerarDVH(detalleFacturaParaDVH);
                            item.DVH = dvhDetalleFactura;

                            using (SqlCommand cmdDVHDetalleFactura = new SqlCommand(queryUpdateDVHDetalleFactura, conexion, transaccion))
                            {
                                cmdDVHDetalleFactura.Parameters.Add("@DVH", SqlDbType.VarChar, 64).Value = dvhDetalleFactura;
                                cmdDVHDetalleFactura.Parameters.Add("@IdDetalleFactura", SqlDbType.Int).Value = idDetalleFactura;
                                cmdDVHDetalleFactura.ExecuteNonQuery();
                            }
                        }

                        transaccion.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaccion.Rollback();
                        throw new Exception(ServicioSessionManager.GetInstance().Traducir("Error al registrar la venta en la base de datos: ") + ex.Message);
                    }
                }
            }
        }

        public List<BEVenta> ObtenerVentas()
        {
            List<BEVenta> lista = new List<BEVenta>();
            string query = @"SELECT f.IdFactura AS IdVenta, f.DNICliente, f.Fecha, f.Hora, f.Total, f.DVH, f.NumeroFactura 
                             FROM Factura f 
                             ORDER BY f.IdFactura DESC;";
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new BEVenta
                            {
                                IdVenta = Convert.ToInt32(reader["IdVenta"]),
                                DNICliente = Convert.ToInt32(reader["DNICliente"]),
                                Fecha = Convert.ToDateTime(reader["Fecha"]),
                                Hora = (TimeSpan)reader["Hora"],
                                Total = Convert.ToDecimal(reader["Total"]),
                                DVH = reader["DVH"]?.ToString(),
                                NumeroFactura = reader["NumeroFactura"] != DBNull.Value ? reader["NumeroFactura"].ToString() : string.Empty
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public List<BEDetalleVenta> ObtenerDetallesPorVenta(int idVenta)
        {
            List<BEDetalleVenta> lista = new List<BEDetalleVenta>();
            string query = @"SELECT df.IdDetalleFactura, df.IdFactura, df.ISBN_657SGA, df.Cantidad, df.DVH,
                                    df.Precio AS PrecioUnitario,
                                    (df.Cantidad * df.Precio) AS Subtotal,
                                    l.Título_657SGA, l.Autor_657SGA, l.Editorial_657SGA
                             FROM DetalleFactura df 
                             LEFT JOIN Libro l ON df.ISBN_657SGA = l.ISBN_657SGA 
                             WHERE df.IdFactura = @IdFactura;";
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.Add("@IdFactura", SqlDbType.Int).Value = idVenta;
                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new BEDetalleVenta
                            {
                                IdDetalleVenta = Convert.ToInt32(reader["IdDetalleFactura"]),
                                IdVenta = Convert.ToInt32(reader["IdFactura"]),
                                IdCarrito = Convert.ToInt32(reader["IdFactura"]),
                                ISBN = reader["ISBN_657SGA"].ToString(),
                                Cantidad = Convert.ToInt32(reader["Cantidad"]),
                                PrecioUnitario = Convert.ToDecimal(reader["PrecioUnitario"]),
                                Subtotal = Convert.ToDecimal(reader["Subtotal"]),
                                DVH = reader["DVH"]?.ToString(),
                                Libro = new BELibro
                                {
                                    ISBN_657SGA = reader["ISBN_657SGA"].ToString(),
                                    Título_657SGA = reader["Título_657SGA"] != DBNull.Value ? reader["Título_657SGA"].ToString() : string.Empty,
                                    Autor_657SGA = reader["Autor_657SGA"] != DBNull.Value ? reader["Autor_657SGA"].ToString() : string.Empty,
                                    Editorial_657SGA = reader["Editorial_657SGA"] != DBNull.Value ? reader["Editorial_657SGA"].ToString() : string.Empty
                                }
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public BEFactura BuscarFacturaPorVenta(int idVenta)
        {
            BEFactura factura = null;
            string query = "SELECT IdFactura, NumeroFactura, Fecha, Hora, Total, DNICliente, DVH FROM Factura WHERE IdFactura = @IdFactura;";
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.Add("@IdFactura", SqlDbType.Int).Value = idVenta;
                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            factura = new BEFactura
                            {
                                IdFactura = Convert.ToInt32(reader["IdFactura"]),
                                NumeroFactura = reader["NumeroFactura"].ToString(),
                                Fecha = Convert.ToDateTime(reader["Fecha"]),
                                Hora = (TimeSpan)reader["Hora"],
                                Total = Convert.ToDecimal(reader["Total"]),
                                DNICliente = Convert.ToInt32(reader["DNICliente"]),
                                DVH = reader["DVH"]?.ToString()
                            };
                        }
                    }
                }
            }
            return factura;
        }
    }
}