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
                        string queryVenta = @"INSERT INTO Venta (DNICliente, Fecha, Hora, Total, DVH) 
                                              VALUES (@DNICliente, @Fecha, @Hora, @Total, @DVH);
                                              SELECT CAST(SCOPE_IDENTITY() AS INT);";

                        int idVenta;
                        using (SqlCommand cmdVenta = new SqlCommand(queryVenta, conexion, transaccion))
                        {
                            cmdVenta.Parameters.Add("@DNICliente", SqlDbType.Int).Value = venta.DNICliente;
                            cmdVenta.Parameters.Add("@Fecha", SqlDbType.Date).Value = venta.Fecha;
                            cmdVenta.Parameters.Add("@Hora", SqlDbType.Time).Value = venta.Hora;
                            cmdVenta.Parameters.Add("@Total", SqlDbType.Decimal).Value = venta.Total;
                            cmdVenta.Parameters.Add("@DVH", SqlDbType.VarChar, 64).Value = DBNull.Value;
                            idVenta = Convert.ToInt32(cmdVenta.ExecuteScalar());
                        }

                        venta.IdVenta = idVenta;

                        BEVenta ventaParaDVH = new BEVenta
                        {
                            IdVenta = idVenta,
                            DNICliente = venta.DNICliente,
                            Fecha = venta.Fecha,
                            Hora = venta.Hora,
                            Total = venta.Total
                        };
                        venta.DVH = generador.GenerarDVH(ventaParaDVH);

                        string queryUpdateDVHVenta = "UPDATE Venta SET DVH = @DVH WHERE IdVenta = @IdVenta;";
                        using (SqlCommand cmdDVHVenta = new SqlCommand(queryUpdateDVHVenta, conexion, transaccion))
                        {
                            cmdDVHVenta.Parameters.Add("@DVH", SqlDbType.VarChar, 64).Value = venta.DVH;
                            cmdDVHVenta.Parameters.Add("@IdVenta", SqlDbType.Int).Value = idVenta;
                            cmdDVHVenta.ExecuteNonQuery();
                        }

                        string queryDetalle = @"INSERT INTO DetalleVenta (IdVenta, ISBN_657SGA, Cantidad, PrecioUnitario, Subtotal, DVH) 
                                                VALUES (@IdVenta, @ISBN, @Cantidad, @PrecioUnitario, @Subtotal, @DVH);
                                                SELECT CAST(SCOPE_IDENTITY() AS INT);";

                        string queryUpdateDVHDetalle = "UPDATE DetalleVenta SET DVH = @DVH WHERE IdDetalleVenta = @IdDetalleVenta;";

                        foreach (var item in detalles)
                        {
                            int idDetalle;
                            using (SqlCommand cmdDetalle = new SqlCommand(queryDetalle, conexion, transaccion))
                            {
                                cmdDetalle.Parameters.Add("@IdVenta", SqlDbType.Int).Value = idVenta;
                                cmdDetalle.Parameters.Add("@ISBN", SqlDbType.VarChar, 13).Value = item.ISBN;
                                cmdDetalle.Parameters.Add("@Cantidad", SqlDbType.Int).Value = item.Cantidad;
                                cmdDetalle.Parameters.Add("@PrecioUnitario", SqlDbType.Decimal).Value = item.PrecioUnitario;
                                cmdDetalle.Parameters.Add("@Subtotal", SqlDbType.Decimal).Value = item.Subtotal;
                                cmdDetalle.Parameters.Add("@DVH", SqlDbType.VarChar, 64).Value = DBNull.Value;
                                idDetalle = Convert.ToInt32(cmdDetalle.ExecuteScalar());
                            }

                            item.IdDetalleVenta = idDetalle;
                            item.IdVenta = idVenta;

                            BEDetalleVenta detalleParaDVH = new BEDetalleVenta
                            {
                                IdDetalleVenta = idDetalle,
                                IdVenta = idVenta,
                                ISBN = item.ISBN,
                                Cantidad = item.Cantidad,
                                PrecioUnitario = item.PrecioUnitario,
                                Subtotal = item.Subtotal
                            };
                            item.DVH = generador.GenerarDVH(detalleParaDVH);

                            using (SqlCommand cmdDVHDetalle = new SqlCommand(queryUpdateDVHDetalle, conexion, transaccion))
                            {
                                cmdDVHDetalle.Parameters.Add("@DVH", SqlDbType.VarChar, 64).Value = item.DVH;
                                cmdDVHDetalle.Parameters.Add("@IdDetalleVenta", SqlDbType.Int).Value = idDetalle;
                                cmdDVHDetalle.ExecuteNonQuery();
                            }
                        }

                        factura.IdVenta = idVenta;
                        string queryFactura = @"INSERT INTO Factura (IdVenta, NumeroFactura, Fecha, Hora, Total, DNICliente, DVH) 
                                                VALUES (@IdVenta, @NumeroFactura, @Fecha, @Hora, @Total, @DNICliente, @DVH);
                                                SELECT CAST(SCOPE_IDENTITY() AS INT);";

                        int idFactura;
                        using (SqlCommand cmdFactura = new SqlCommand(queryFactura, conexion, transaccion))
                        {
                            cmdFactura.Parameters.Add("@IdVenta", SqlDbType.Int).Value = idVenta;
                            cmdFactura.Parameters.Add("@NumeroFactura", SqlDbType.VarChar, 50).Value = factura.NumeroFactura;
                            cmdFactura.Parameters.Add("@Fecha", SqlDbType.Date).Value = factura.Fecha;
                            cmdFactura.Parameters.Add("@Hora", SqlDbType.Time).Value = factura.Hora;
                            cmdFactura.Parameters.Add("@Total", SqlDbType.Decimal).Value = factura.Total;
                            cmdFactura.Parameters.Add("@DNICliente", SqlDbType.Int).Value = factura.DNICliente;
                            cmdFactura.Parameters.Add("@DVH", SqlDbType.VarChar, 64).Value = DBNull.Value;
                            idFactura = Convert.ToInt32(cmdFactura.ExecuteScalar());
                        }

                        factura.IdFactura = idFactura;
                        BEFactura facturaParaDVH = new BEFactura
                        {
                            IdFactura = idFactura,
                            IdVenta = idVenta,
                            NumeroFactura = factura.NumeroFactura,
                            Fecha = factura.Fecha,
                            Hora = factura.Hora,
                            Total = factura.Total,
                            DNICliente = factura.DNICliente
                        };
                        factura.DVH = generador.GenerarDVH(facturaParaDVH);

                        string queryUpdateDVHFactura = "UPDATE Factura SET DVH = @DVH WHERE IdFactura = @IdFactura;";
                        using (SqlCommand cmdDVHFactura = new SqlCommand(queryUpdateDVHFactura, conexion, transaccion))
                        {
                            cmdDVHFactura.Parameters.Add("@DVH", SqlDbType.VarChar, 64).Value = factura.DVH;
                            cmdDVHFactura.Parameters.Add("@IdFactura", SqlDbType.Int).Value = idFactura;
                            cmdDVHFactura.ExecuteNonQuery();
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
            string query = @"SELECT v.IdVenta, v.DNICliente, v.Fecha, v.Hora, v.Total, v.DVH, f.NumeroFactura 
                             FROM Venta v 
                             LEFT JOIN Factura f ON v.IdVenta = f.IdVenta 
                             ORDER BY v.IdVenta DESC;";
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
            string query = @"SELECT d.IdDetalleVenta, d.IdVenta, d.ISBN_657SGA, d.Cantidad, d.PrecioUnitario, d.Subtotal, d.DVH,
                                    l.Título_657SGA, l.Autor_657SGA, l.Editorial_657SGA
                             FROM DetalleVenta d 
                             LEFT JOIN Libro l ON d.ISBN_657SGA = l.ISBN_657SGA 
                             WHERE d.IdVenta = @IdVenta;";
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.Add("@IdVenta", SqlDbType.Int).Value = idVenta;
                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new BEDetalleVenta
                            {
                                IdDetalleVenta = Convert.ToInt32(reader["IdDetalleVenta"]),
                                IdVenta = Convert.ToInt32(reader["IdVenta"]),
                                IdCarrito = Convert.ToInt32(reader["IdVenta"]),
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
            string query = "SELECT IdFactura, IdVenta, NumeroFactura, Fecha, Hora, Total, DNICliente, DVH FROM Factura WHERE IdVenta = @IdVenta;";
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.Add("@IdVenta", SqlDbType.Int).Value = idVenta;
                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            factura = new BEFactura
                            {
                                IdFactura = Convert.ToInt32(reader["IdFactura"]),
                                IdVenta = Convert.ToInt32(reader["IdVenta"]),
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