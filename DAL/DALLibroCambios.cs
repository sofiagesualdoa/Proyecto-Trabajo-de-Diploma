using BE;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class DALLibroCambios
    {
        private readonly string cadena = "Data Source=.;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;Initial Catalog=EverGlow;";

        public List<BELibroCambios> BuscarRegistros(string isbn = null, string titulo = null, DateTime? fechaDesde = null, DateTime? fechaHasta = null)
        {
            List<BELibroCambios> lista = new List<BELibroCambios>();
            string query = @"SELECT IdLibroC, ISBN, Titulo, Precio, Existencias, ExistenciasPrestamo, Editorial, Autor, EsParaPrestamo, Activo, DVH, Fecha, Hora, Act 
                             FROM Libro_C 
                             WHERE 1=1 ";

            if (!string.IsNullOrWhiteSpace(isbn))
            {
                query += " AND ISBN LIKE @isbn ";
            }

            if (!string.IsNullOrWhiteSpace(titulo))
            {
                query += " AND Titulo LIKE @titulo ";
            }

            if (fechaDesde.HasValue)
            {
                query += " AND Fecha >= @fechaDesde ";
            }

            if (fechaHasta.HasValue)
            {
                query += " AND Fecha <= @fechaHasta ";
            }

            query += " ORDER BY Fecha DESC, Hora DESC, IdLibroC DESC;";

            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    if (!string.IsNullOrWhiteSpace(isbn))
                    {
                        comando.Parameters.Add("@isbn", SqlDbType.VarChar, 50).Value = "%" + isbn.Trim() + "%";
                    }

                    if (!string.IsNullOrWhiteSpace(titulo))
                    {
                        comando.Parameters.Add("@titulo", SqlDbType.NVarChar, 100).Value = "%" + titulo.Trim() + "%";
                    }

                    if (fechaDesde.HasValue)
                    {
                        comando.Parameters.Add("@fechaDesde", SqlDbType.Date).Value = fechaDesde.Value.Date;
                    }

                    if (fechaHasta.HasValue)
                    {
                        comando.Parameters.Add("@fechaHasta", SqlDbType.Date).Value = fechaHasta.Value.Date;
                    }

                    conexion.Open();
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BELibroCambios item = new BELibroCambios();
                            item.IdLibroC = Convert.ToInt32(reader["IdLibroC"]);
                            item.ISBN = reader["ISBN"].ToString();
                            item.Titulo = reader["Titulo"] != DBNull.Value ? reader["Titulo"].ToString() : string.Empty;
                            item.Precio = reader["Precio"] != DBNull.Value ? Convert.ToDecimal(reader["Precio"]) : 0m;
                            item.Existencias = reader["Existencias"] != DBNull.Value ? Convert.ToInt32(reader["Existencias"]) : 0;
                            item.ExistenciasPrestamo = reader["ExistenciasPrestamo"] != DBNull.Value ? Convert.ToInt32(reader["ExistenciasPrestamo"]) : 0;
                            item.Editorial = reader["Editorial"] != DBNull.Value ? reader["Editorial"].ToString() : string.Empty;
                            item.Autor = reader["Autor"] != DBNull.Value ? reader["Autor"].ToString() : string.Empty;
                            item.EsParaPrestamo = reader["EsParaPrestamo"] != DBNull.Value && Convert.ToBoolean(reader["EsParaPrestamo"]);
                            item.Activo = reader["Activo"] != DBNull.Value && Convert.ToBoolean(reader["Activo"]);
                            item.DVH = reader["DVH"] != DBNull.Value ? reader["DVH"].ToString() : string.Empty;
                            item.Fecha = Convert.ToDateTime(reader["Fecha"]);

                            if (reader["Hora"] is TimeSpan ts)
                            {
                                item.Hora = ts;
                            }
                            else
                            {
                                TimeSpan parsed;
                                if (TimeSpan.TryParse(reader["Hora"].ToString(), out parsed))
                                {
                                    item.Hora = parsed;
                                }
                            }

                            item.Act = reader["Act"] != DBNull.Value && Convert.ToBoolean(reader["Act"]);
                            lista.Add(item);
                        }
                    }
                }
            }
            return lista;
        }

        public void ActivarCambio(int idLibroC, string isbn)
        {
            string query = "UPDATE Libro_C SET Act = 1 WHERE IdLibroC = @IdLibroC;";
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add("@IdLibroC", SqlDbType.Int).Value = idLibroC;
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }

        public BELibroCambios ObtenerPorId(int idLibroC)
        {
            string query = @"SELECT IdLibroC, ISBN, Titulo, Precio, Existencias, ExistenciasPrestamo, Editorial, Autor, EsParaPrestamo, Activo, DVH, Fecha, Hora, Act 
                             FROM Libro_C 
                             WHERE IdLibroC = @IdLibroC;";
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add("@IdLibroC", SqlDbType.Int).Value = idLibroC;
                    conexion.Open();
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            BELibroCambios item = new BELibroCambios();
                            item.IdLibroC = Convert.ToInt32(reader["IdLibroC"]);
                            item.ISBN = reader["ISBN"].ToString();
                            item.Titulo = reader["Titulo"] != DBNull.Value ? reader["Titulo"].ToString() : string.Empty;
                            item.Precio = reader["Precio"] != DBNull.Value ? Convert.ToDecimal(reader["Precio"]) : 0m;
                            item.Existencias = reader["Existencias"] != DBNull.Value ? Convert.ToInt32(reader["Existencias"]) : 0;
                            item.ExistenciasPrestamo = reader["ExistenciasPrestamo"] != DBNull.Value ? Convert.ToInt32(reader["ExistenciasPrestamo"]) : 0;
                            item.Editorial = reader["Editorial"] != DBNull.Value ? reader["Editorial"].ToString() : string.Empty;
                            item.Autor = reader["Autor"] != DBNull.Value ? reader["Autor"].ToString() : string.Empty;
                            item.EsParaPrestamo = reader["EsParaPrestamo"] != DBNull.Value && Convert.ToBoolean(reader["EsParaPrestamo"]);
                            item.Activo = reader["Activo"] != DBNull.Value && Convert.ToBoolean(reader["Activo"]);
                            item.DVH = reader["DVH"] != DBNull.Value ? reader["DVH"].ToString() : string.Empty;
                            item.Fecha = Convert.ToDateTime(reader["Fecha"]);

                            if (reader["Hora"] is TimeSpan ts)
                            {
                                item.Hora = ts;
                            }
                            else
                            {
                                TimeSpan parsed;
                                if (TimeSpan.TryParse(reader["Hora"].ToString(), out parsed))
                                {
                                    item.Hora = parsed;
                                }
                            }

                            item.Act = reader["Act"] != DBNull.Value && Convert.ToBoolean(reader["Act"]);
                            return item;
                        }
                    }
                }
            }
            return null;
        }
    }
}
