using BE;
using Microsoft.Data.SqlClient;
using Servicios;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class DALPrestamo : IDALPrestamo
    {
        private readonly string cadena = "Data Source=.;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;Initial Catalog=EverGlow;";

        public int GuardarPrestamo(BEPrestamo prestamo)
        {
            string query = @"INSERT INTO Prestamo (DNI, ISBN, IdFactura, FechaInicio, FechaDevolucion, FechaRealDevolucion, Estado, MontoPrestamo, MontoRecargo, DVH) 
                             VALUES (@DNI, @ISBN, @IdFactura, @FechaInicio, @FechaDevolucion, @FechaRealDevolucion, @Estado, @MontoPrestamo, @MontoRecargo, @DVH);
                             SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add("@DNI", SqlDbType.Int).Value = prestamo.DNI;
                    comando.Parameters.Add("@ISBN", SqlDbType.VarChar, 13).Value = prestamo.ISBN;
                    comando.Parameters.Add("@IdFactura", SqlDbType.Int).Value = (object?)prestamo.IdFactura ?? DBNull.Value;
                    comando.Parameters.Add("@FechaInicio", SqlDbType.Date).Value = prestamo.FechaInicio.Date;
                    comando.Parameters.Add("@FechaDevolucion", SqlDbType.Date).Value = prestamo.FechaDevolucion.Date;
                    comando.Parameters.Add("@FechaRealDevolucion", SqlDbType.Date).Value = prestamo.FechaRealDevolucion.HasValue ? prestamo.FechaRealDevolucion.Value.Date : DBNull.Value;
                    comando.Parameters.Add("@Estado", SqlDbType.VarChar, 30).Value = prestamo.Estado ?? "Pendiente";
                    comando.Parameters.Add("@MontoPrestamo", SqlDbType.Decimal).Value = (decimal)(long)prestamo.MontoPrestamo;
                    comando.Parameters.Add("@MontoRecargo", SqlDbType.Decimal).Value = (decimal)(long)prestamo.MontoRecargo;
                    comando.Parameters.Add("@DVH", SqlDbType.VarChar, 64).Value = DBNull.Value;

                    conexion.Open();
                    int idGenerado = Convert.ToInt32(comando.ExecuteScalar());
                    prestamo.IdPrestamo = idGenerado;

                    GeneradorDigVerificador generador = new GeneradorDigVerificador();
                    prestamo.DVH = generador.GenerarDVH(prestamo);

                    using (SqlCommand cmdDVH = new SqlCommand("UPDATE Prestamo SET DVH = @DVH WHERE IdPrestamo = @IdPrestamo;", conexion))
                    {
                        cmdDVH.Parameters.Add("@DVH", SqlDbType.VarChar, 64).Value = prestamo.DVH;
                        cmdDVH.Parameters.Add("@IdPrestamo", SqlDbType.Int).Value = idGenerado;
                        cmdDVH.ExecuteNonQuery();
                    }

                    return idGenerado;
                }
            }
        }

        public BEPrestamo? ObtenerPrestamoPorId(int idPrestamo)
        {
            BEPrestamo? prestamo = null;
            string query = @"SELECT IdPrestamo, DNI, ISBN, IdFactura, FechaInicio, FechaDevolucion, FechaRealDevolucion, Estado, MontoPrestamo, MontoRecargo, DVH 
                             FROM Prestamo 
                             WHERE IdPrestamo = @IdPrestamo;";

            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add("@IdPrestamo", SqlDbType.Int).Value = idPrestamo;
                    conexion.Open();
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            prestamo = MapearPrestamo(reader);
                        }
                    }
                }
            }
            return prestamo;
        }

        public BEPrestamo? ObtenerPrestamoActivoPorDNI(int dni)
        {
            BEPrestamo? prestamo = null;
            string query = @"SELECT TOP 1 IdPrestamo, DNI, ISBN, IdFactura, FechaInicio, FechaDevolucion, FechaRealDevolucion, Estado, MontoPrestamo, MontoRecargo, DVH 
                             FROM Prestamo 
                             WHERE DNI = @DNI AND Estado = 'Activo' 
                             ORDER BY FechaInicio DESC, IdPrestamo DESC;";

            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add("@DNI", SqlDbType.Int).Value = dni;
                    conexion.Open();
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            prestamo = MapearPrestamo(reader);
                        }
                    }
                }
            }
            return prestamo;
        }

        public List<BEPrestamo> ObtenerPrestamosPorDNI(int dni)
        {
            List<BEPrestamo> lista = new List<BEPrestamo>();
            string query = @"SELECT IdPrestamo, DNI, ISBN, IdFactura, FechaInicio, FechaDevolucion, FechaRealDevolucion, Estado, MontoPrestamo, MontoRecargo, DVH 
                             FROM Prestamo 
                             WHERE DNI = @DNI 
                             ORDER BY FechaInicio DESC, IdPrestamo DESC;";

            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add("@DNI", SqlDbType.Int).Value = dni;
                    conexion.Open();
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(MapearPrestamo(reader));
                        }
                    }
                }
            }
            return lista;
        }

        public List<BEPrestamo> ObtenerTodosLosPrestamos()
        {
            List<BEPrestamo> lista = new List<BEPrestamo>();
            string query = @"SELECT p.IdPrestamo, p.DNI, p.ISBN, p.IdFactura, p.FechaInicio, p.FechaDevolucion, p.FechaRealDevolucion, p.Estado, p.MontoPrestamo, p.MontoRecargo, p.DVH, f.NumeroFactura 
                             FROM Prestamo p 
                             LEFT JOIN Factura f ON p.IdFactura = f.IdFactura 
                             ORDER BY p.IdPrestamo DESC;";

            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    conexion.Open();
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(MapearPrestamo(reader));
                        }
                    }
                }
            }
            return lista;
        }

        public void ActualizarPrestamoCobrado(int idPrestamo, int idFactura, string dvh)
        {
            string query = @"UPDATE Prestamo 
                             SET IdFactura = @IdFactura, Estado = 'Activo', DVH = @DVH 
                             WHERE IdPrestamo = @IdPrestamo;";

            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add("@IdFactura", SqlDbType.Int).Value = idFactura;
                    comando.Parameters.Add("@DVH", SqlDbType.VarChar, 64).Value = (object?)dvh ?? DBNull.Value;
                    comando.Parameters.Add("@IdPrestamo", SqlDbType.Int).Value = idPrestamo;

                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void FinalizarPrestamo(BEPrestamo prestamo)
        {
            string query = @"UPDATE Prestamo 
                             SET FechaRealDevolucion = @FechaRealDevolucion, 
                                 Estado = @Estado, 
                                 MontoRecargo = @MontoRecargo, 
                                 DVH = @DVH 
                             WHERE IdPrestamo = @IdPrestamo;";

            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add("@FechaRealDevolucion", SqlDbType.Date).Value = prestamo.FechaRealDevolucion.HasValue ? prestamo.FechaRealDevolucion.Value.Date : DateTime.Today;
                    comando.Parameters.Add("@Estado", SqlDbType.VarChar, 30).Value = prestamo.Estado;
                    comando.Parameters.Add("@MontoRecargo", SqlDbType.Decimal).Value = (decimal)(long)prestamo.MontoRecargo;
                    comando.Parameters.Add("@DVH", SqlDbType.VarChar, 64).Value = (object?)prestamo.DVH ?? DBNull.Value;
                    comando.Parameters.Add("@IdPrestamo", SqlDbType.Int).Value = prestamo.IdPrestamo;

                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarDVHPrestamo(int idPrestamo, string dvh)
        {
            string query = "UPDATE Prestamo SET DVH = @DVH WHERE IdPrestamo = @IdPrestamo;";

            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add("@IdPrestamo", SqlDbType.Int).Value = idPrestamo;
                    comando.Parameters.Add("@DVH", SqlDbType.VarChar, 64).Value = dvh;

                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }

        public int GuardarFacturaPrestamo(BEFactura factura, string isbn, decimal importe)
        {
            GeneradorDigVerificador generador = new GeneradorDigVerificador();
            string queryFactura = @"INSERT INTO Factura (NumeroFactura, Fecha, Hora, Total, DNICliente, DVH) 
                                    VALUES (@NumeroFactura, @Fecha, @Hora, @Total, @DNICliente, @DVH);
                                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

            string queryDetalle = @"INSERT INTO DetalleFactura (IdFactura, ISBN_657SGA, Cantidad, Precio, DVH) 
                                    VALUES (@IdFactura, @ISBN, 1, @Precio, @DVH);
                                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                conexion.Open();
                using (SqlTransaction transaccion = conexion.BeginTransaction())
                {
                    try
                    {
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

                        string queryUpdateDVHFactura = "UPDATE Factura SET DVH = @DVH WHERE IdFactura = @IdFactura;";
                        using (SqlCommand cmdDVHFactura = new SqlCommand(queryUpdateDVHFactura, conexion, transaccion))
                        {
                            cmdDVHFactura.Parameters.Add("@DVH", SqlDbType.VarChar, 64).Value = factura.DVH;
                            cmdDVHFactura.Parameters.Add("@IdFactura", SqlDbType.Int).Value = idFactura;
                            cmdDVHFactura.ExecuteNonQuery();
                        }

                        int idDetalleFactura;
                        using (SqlCommand cmdDetalle = new SqlCommand(queryDetalle, conexion, transaccion))
                        {
                            cmdDetalle.Parameters.Add("@IdFactura", SqlDbType.Int).Value = idFactura;
                            cmdDetalle.Parameters.Add("@ISBN", SqlDbType.VarChar, 13).Value = isbn;
                            cmdDetalle.Parameters.Add("@Precio", SqlDbType.Decimal).Value = importe;
                            cmdDetalle.Parameters.Add("@DVH", SqlDbType.VarChar, 64).Value = DBNull.Value;
                            idDetalleFactura = Convert.ToInt32(cmdDetalle.ExecuteScalar());
                        }

                        BEDetalleFactura detalleParaDVH = new BEDetalleFactura
                        {
                            IdDetalleFactura = idDetalleFactura,
                            IdFactura = idFactura,
                            ISBN = isbn,
                            Cantidad = 1,
                            Precio = importe
                        };
                        string dvhDetalle = generador.GenerarDVH(detalleParaDVH);

                        string queryUpdateDVHDetalle = "UPDATE DetalleFactura SET DVH = @DVH WHERE IdDetalleFactura = @IdDetalleFactura;";
                        using (SqlCommand cmdDVHDetalle = new SqlCommand(queryUpdateDVHDetalle, conexion, transaccion))
                        {
                            cmdDVHDetalle.Parameters.Add("@DVH", SqlDbType.VarChar, 64).Value = dvhDetalle;
                            cmdDVHDetalle.Parameters.Add("@IdDetalleFactura", SqlDbType.Int).Value = idDetalleFactura;
                            cmdDVHDetalle.ExecuteNonQuery();
                        }

                        transaccion.Commit();
                        return idFactura;
                    }
                    catch
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
            }
        }

        private static BEPrestamo MapearPrestamo(SqlDataReader reader)
        {
            var p = new BEPrestamo
            {
                IdPrestamo = Convert.ToInt32(reader["IdPrestamo"]),
                DNI = Convert.ToInt32(reader["DNI"]),
                ISBN = reader["ISBN"].ToString() ?? string.Empty,
                IdFactura = reader["IdFactura"] == DBNull.Value ? null : Convert.ToInt32(reader["IdFactura"]),
                FechaInicio = Convert.ToDateTime(reader["FechaInicio"]),
                FechaDevolucion = Convert.ToDateTime(reader["FechaDevolucion"]),
                FechaRealDevolucion = reader["FechaRealDevolucion"] == DBNull.Value ? null : Convert.ToDateTime(reader["FechaRealDevolucion"]),
                Estado = reader["Estado"].ToString() ?? string.Empty,
                MontoPrestamo = (decimal)(long)Convert.ToDecimal(reader["MontoPrestamo"]),
                MontoRecargo = (decimal)(long)Convert.ToDecimal(reader["MontoRecargo"]),
                DVH = reader["DVH"]?.ToString() ?? string.Empty
            };
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).Equals("NumeroFactura", StringComparison.OrdinalIgnoreCase))
                {
                    p.NumeroFactura = reader[i] != DBNull.Value ? reader[i].ToString() : string.Empty;
                    break;
                }
            }
            return p;
        }
    }
}
