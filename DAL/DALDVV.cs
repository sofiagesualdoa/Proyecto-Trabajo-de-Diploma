using BE;
using Microsoft.Data.SqlClient;
using Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALDVV : IDALDVV
    {
        string cadena = "Data Source=.;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;Initial Catalog=EverGlow;";

        public List<ServicioDVV> ObtenerDVV()
        {
            List<ServicioDVV> lista = new List<ServicioDVV>();
            string query = "SELECT NombreTabla, Digito FROM DVV;";

            using (SqlConnection conexion = new SqlConnection(cadena))
            using (SqlCommand comando = new SqlCommand(query, conexion))
            {
                conexion.Open();

                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new ServicioDVV
                        {
                            NombreTabla = reader["NombreTabla"].ToString(),
                            Digito = reader["Digito"].ToString()
                        });
                    }
                }
            }

            return lista;
        }

        public void GuardarDVV(ServicioDVV dvv)
        {
            string query = @"
                            IF EXISTS (SELECT 1 FROM DVV WHERE NombreTabla = @NombreTabla)
                            UPDATE DVV SET Digito = @Digito WHERE NombreTabla = @NombreTabla;
                            ELSE
                            INSERT INTO DVV (NombreTabla, Digito) VALUES (@NombreTabla, @Digito);";

            using (SqlConnection conexion = new SqlConnection(cadena))
            using (SqlCommand comando = new SqlCommand(query, conexion))
            {
                comando.Parameters.Add("@NombreTabla", SqlDbType.VarChar, 50).Value = dvv.NombreTabla;
                comando.Parameters.Add("@Digito", SqlDbType.VarChar, 64).Value = dvv.Digito;

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        public List<BELibro> ObtenerLibros()
        {
            List<BELibro> libros = new List<BELibro>();
            string query = @"SELECT Título_657SGA, ISBN_657SGA, Precio_657SGA, Existencias_657SGA, Editorial_657SGA, Autor_657SGA, Activo_657SGA, DVH FROM Libro";
            using (SqlConnection conexion = new SqlConnection(cadena))
            using (SqlCommand comando = new SqlCommand(query, conexion))
            {
                conexion.Open();
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        libros.Add(new BELibro
                        {
                            ISBN_657SGA = reader["ISBN_657SGA"].ToString(),
                            Título_657SGA = reader["Título_657SGA"].ToString(),
                            Editorial_657SGA = reader["Editorial_657SGA"].ToString(),
                            Autor_657SGA = reader["Autor_657SGA"].ToString(),
                            Existencias_657SGA = Convert.ToInt32(reader["Existencias_657SGA"]),
                            Precio_657SGA = Convert.ToDecimal(reader["Precio_657SGA"]),
                            Activo_657SGA = reader["Activo_657SGA"] != DBNull.Value && Convert.ToBoolean(reader["Activo_657SGA"]),
                            DVH = reader["DVH"].ToString()
                        });
                    }
                }
            }
            return libros;
        }

        public void ActualizarDVHLibro(string isbn, string dvh)
        {
            string query = @"UPDATE Libro SET DVH = @DVH WHERE ISBN_657SGA = @ISBN_657SGA;";
            using (SqlConnection conexion = new SqlConnection(cadena))
            using (SqlCommand comando = new SqlCommand(query, conexion))
            {
                comando.Parameters.Add("@ISBN_657SGA", SqlDbType.VarChar, 13).Value = isbn;
                comando.Parameters.Add("@DVH", SqlDbType.VarChar, 64).Value = dvh;
                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }
    }
}
