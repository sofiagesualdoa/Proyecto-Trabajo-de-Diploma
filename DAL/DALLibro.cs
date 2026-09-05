using BE;
using Microsoft.Data.SqlClient;
using Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALLibro
    {
        string cadena = "Data Source=.;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;Initial Catalog=EverGlow;";
        private static List<BELibro> libros = new List<BELibro>();
        public BELibro BuscarLibroPorISBN_657SGA(string ISBN_657SGA)
        {
            BELibro libroEncontrado = null;
            string query = @"SELECT Título_657SGA, ISBN_657SGA, Precio_657SGA, Existencias_657SGA, Editorial_657SGA, Autor_657SGA, DVH 
                     FROM Libro 
                     WHERE ISBN_657SGA = @ISBN_657SGA;";
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@ISBN_657SGA", ISBN_657SGA);
                    conexion.Open();
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            libroEncontrado = new BELibro();
                            libroEncontrado.ISBN_657SGA = reader["ISBN_657SGA"].ToString();
                            libroEncontrado.Título_657SGA = reader["Título_657SGA"].ToString();
                            libroEncontrado.Editorial_657SGA = reader["Editorial_657SGA"].ToString();
                            libroEncontrado.Autor_657SGA = reader["Autor_657SGA"].ToString();
                            libroEncontrado.Existencias_657SGA = Convert.ToInt32(reader["Existencias_657SGA"]);
                            libroEncontrado.Precio_657SGA = Convert.ToDecimal(reader["Precio_657SGA"]);
                            libroEncontrado.DVH = reader["DVH"].ToString();
                        }
                    }
                }
            }
            return libroEncontrado;
        }

        public List<BELibro> ObtenerLibros()
        {
            libros.Clear();
            string query = @"SELECT Título_657SGA, ISBN_657SGA, Precio_657SGA, Existencias_657SGA, Editorial_657SGA, Autor_657SGA, DVH 
                     FROM Libro";
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    conexion.Open();
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BELibro libro = new BELibro();
                            libro.ISBN_657SGA = reader["ISBN_657SGA"].ToString();               
                            libro.Título_657SGA = reader["Título_657SGA"].ToString();
                            libro.Editorial_657SGA = reader["Editorial_657SGA"].ToString();
                            libro.Autor_657SGA = reader["Autor_657SGA"].ToString();
                            libro.Existencias_657SGA = Convert.ToInt32(reader["Existencias_657SGA"]);
                            libro.Precio_657SGA = Convert.ToDecimal(reader["Precio_657SGA"]);
                            libro.DVH = reader["DVH"].ToString();
                            libros.Add(libro);
                        }
                    }
                }
            }
            return libros;
        }

        public void GuardarLibro(BELibro libro)
        {
            string query = @"INSERT INTO Libro (ISBN_657SGA, Título_657SGA, Autor_657SGA, Existencias_657SGA, Precio_657SGA, Editorial_657SGA, DVH) 
                     VALUES (@ISBN_657SGA, @Título_657SGA, @Autor_657SGA, @Existencias_657SGA, @Precio_657SGA, @Editorial_657SGA, @DVH);";

            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add("@ISBN_657SGA", SqlDbType.VarChar, 13).Value = libro.ISBN_657SGA;
                    comando.Parameters.Add("@Título_657SGA", SqlDbType.VarChar, 100).Value = libro.Título_657SGA;
                    comando.Parameters.Add("@Autor_657SGA", SqlDbType.VarChar).Value = libro.Autor_657SGA;
                    comando.Parameters.Add("@Existencias_657SGA", SqlDbType.Int).Value = libro.Existencias_657SGA;
                    comando.Parameters.Add("@Precio_657SGA", SqlDbType.Decimal).Value = libro.Precio_657SGA;
                    comando.Parameters.Add("@Editorial_657SGA", SqlDbType.VarChar, 100).Value = libro.Editorial_657SGA;
                    comando.Parameters.Add("@DVH", SqlDbType.VarChar, 64).Value = libro.DVH;
                    try
                    {
                        conexion.Open();
                        comando.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ServicioSessionManager.GetInstance().Traducir("Error físico al intentar insertar el nuevo libro en la base de datos: ") + ex.Message);
                    }
                }
            }
            libros.Add(libro);
        }

        public void ActualizarDVHLibro(string ISBN_657SGA, string dvh)
        {
            string query = @"UPDATE Libro 
                     SET DVH = @DVH 
                     WHERE ISBN_657SGA = @ISBN_657SGA;";

            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add("@ISBN_657SGA", SqlDbType.VarChar, 13).Value = ISBN_657SGA;
                    comando.Parameters.Add("@DVH", SqlDbType.VarChar, 64).Value = dvh;
                    try
                    {
                        conexion.Open();
                        int filasAfectadas = comando.ExecuteNonQuery();
                        if (filasAfectadas == 0)
                        {
                            throw new Exception("No se encontró ningún libro con el ISBN_657SGA especificado para actualizar el DVH.");
                        }
                    }
                    catch (Exception ex)
                    {
                        string errorTraducido = ServicioSessionManager.GetInstance().Traducir(ex.Message);
                        throw new Exception(ServicioSessionManager.GetInstance().Traducir("Error físico al actualizar el DVH del libro: ") + errorTraducido);
                    }
                }
            }
        }

        public List<BELibro> BuscarLibros(string textoBusqueda)
        {
            List<BELibro> lista = new List<BELibro>();
            string query = @"SELECT ISBN_657SGA, Título_657SGA, Autor_657SGA, Editorial_657SGA, Precio_657SGA, Existencias_657SGA, DVH 
                     FROM Libro
                     WHERE Título_657SGA LIKE @Filtro 
                        OR Autor_657SGA LIKE @Filtro 
                        OR ISBN_657SGA LIKE @Filtro;";

            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@Filtro", "%" + textoBusqueda.Trim() + "%");
                    conexion.Open();
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BELibro l = new BELibro();
                            l.ISBN_657SGA = reader["ISBN_657SGA"].ToString();
                            l.Título_657SGA = reader["Título_657SGA"].ToString();
                            l.Autor_657SGA = reader["Autor_657SGA"].ToString();
                            l.Existencias_657SGA = Convert.ToInt32(reader["Existencias_657SGA"]);
                            l.Editorial_657SGA = reader["Editorial_657SGA"].ToString();
                            l.Precio_657SGA = Convert.ToDecimal(reader["Precio_657SGA"]);
                            l.DVH = reader["DVH"].ToString();
                            lista.Add(l);
                        }
                    }
                }
            }
            return lista;
        }
    }
}
