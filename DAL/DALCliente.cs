using BE;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALCliente
    {
        private readonly string cadena = "Data Source=.;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;Initial Catalog=EverGlow;";
        public BECliente BuscarClientePorDNI(int dni)
        {
            BECliente cliente = null;
            string query = @"SELECT DNI_657SGA, Nombre_657SGA, Apellido_657SGA, Email_657SGA, Teléfono_657SGA, Dirección_657SGA, Activo_657SGA, DVH 
                             FROM Cliente 
                             WHERE DNI_657SGA = @DNI;";
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
                            cliente = new BECliente
                            {
                                DNI_657SGA = Convert.ToInt32(reader["DNI_657SGA"]),
                                Nombre_657SGA = reader["Nombre_657SGA"].ToString(),
                                Apellido_657SGA = reader["Apellido_657SGA"].ToString(),
                                Email_657SGA = reader["Email_657SGA"].ToString(),
                                Teléfono_657SGA = Convert.ToInt32(reader["Teléfono_657SGA"]),
                                Dirección_657SGA = reader["Dirección_657SGA"].ToString(),
                                Activo_657SGA = Convert.ToBoolean(reader["Activo_657SGA"]),
                                DVH = reader["DVH"]?.ToString()
                            };
                        }
                    }
                }
            }
            return cliente;
        }
        public List<BECliente> ObtenerClientes()
        {
            List<BECliente> lista = new List<BECliente>();
            string query = @"SELECT DNI_657SGA, Nombre_657SGA, Apellido_657SGA, Email_657SGA, Teléfono_657SGA, Dirección_657SGA, Activo_657SGA, DVH 
                             FROM Cliente;";
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    conexion.Open();
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new BECliente
                            {
                                DNI_657SGA = Convert.ToInt32(reader["DNI_657SGA"]),
                                Nombre_657SGA = reader["Nombre_657SGA"].ToString(),
                                Apellido_657SGA = reader["Apellido_657SGA"].ToString(),
                                Email_657SGA = reader["Email_657SGA"].ToString(),
                                Teléfono_657SGA = Convert.ToInt32(reader["Teléfono_657SGA"]),
                                Dirección_657SGA = reader["Dirección_657SGA"].ToString(),
                                Activo_657SGA = Convert.ToBoolean(reader["Activo_657SGA"]),
                                DVH = reader["DVH"]?.ToString()
                            });
                        }
                    }
                }
            }
            return lista;
        }
        public void GuardarCliente(BECliente cliente)
        {
            string query = @"INSERT INTO Cliente (DNI_657SGA, Nombre_657SGA, Apellido_657SGA, Email_657SGA, Teléfono_657SGA, Dirección_657SGA, Activo_657SGA, DVH) 
                             VALUES (@DNI, @Nombre, @Apellido, @Email, @Telefono, @Direccion, @Activo, @DVH);";
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add("@DNI", SqlDbType.Int).Value = cliente.DNI_657SGA;
                    comando.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = cliente.Nombre_657SGA;
                    comando.Parameters.Add("@Apellido", SqlDbType.VarChar, 100).Value = cliente.Apellido_657SGA;
                    comando.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = cliente.Email_657SGA;
                    comando.Parameters.Add("@Telefono", SqlDbType.Int).Value = cliente.Teléfono_657SGA;
                    comando.Parameters.Add("@Direccion", SqlDbType.NVarChar, 200).Value = cliente.Dirección_657SGA;
                    comando.Parameters.Add("@Activo", SqlDbType.Bit).Value = cliente.Activo_657SGA;
                    comando.Parameters.Add("@DVH", SqlDbType.VarChar, 64).Value = cliente.DVH ?? (object)DBNull.Value;
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }
        public void ModificarCliente(BECliente cliente, int dniOriginal)
        {
            string query = @"UPDATE Cliente 
                             SET DNI_657SGA = @NuevoDNI,
                                 Nombre_657SGA = @Nombre,
                                 Apellido_657SGA = @Apellido,
                                 Email_657SGA = @Email,
                                 Teléfono_657SGA = @Telefono,
                                 Dirección_657SGA = @Direccion,
                                 Activo_657SGA = @Activo,
                                 DVH = @DVH
                             WHERE DNI_657SGA = @DNIOriginal;";
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add("@NuevoDNI", SqlDbType.Int).Value = cliente.DNI_657SGA;
                    comando.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = cliente.Nombre_657SGA;
                    comando.Parameters.Add("@Apellido", SqlDbType.VarChar, 100).Value = cliente.Apellido_657SGA;
                    comando.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = cliente.Email_657SGA;
                    comando.Parameters.Add("@Telefono", SqlDbType.Int).Value = cliente.Teléfono_657SGA;
                    comando.Parameters.Add("@Direccion", SqlDbType.NVarChar, 200).Value = cliente.Dirección_657SGA;
                    comando.Parameters.Add("@Activo", SqlDbType.Bit).Value = cliente.Activo_657SGA;
                    comando.Parameters.Add("@DVH", SqlDbType.VarChar, 64).Value = cliente.DVH ?? (object)DBNull.Value;
                    comando.Parameters.Add("@DNIOriginal", SqlDbType.Int).Value = dniOriginal;
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }
        public void ModificarEstadoCliente(int dni, bool nuevoEstado, string dvh)
        {
            string query = @"UPDATE Cliente 
                             SET Activo_657SGA = @Activo, DVH = @DVH 
                             WHERE DNI_657SGA = @DNI;";
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add("@DNI", SqlDbType.Int).Value = dni;
                    comando.Parameters.Add("@Activo", SqlDbType.Bit).Value = nuevoEstado;
                    comando.Parameters.Add("@DVH", SqlDbType.VarChar, 64).Value = dvh;
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<BECliente> BuscarClientes(string dni, string nombre, string apellido, string email, string telefono, string direccion, bool? soloActivos)
        {
            List<BECliente> lista = new List<BECliente>();
            System.Text.StringBuilder query = new System.Text.StringBuilder(
                @"SELECT DNI_657SGA, Nombre_657SGA, Apellido_657SGA, Email_657SGA, Teléfono_657SGA, Dirección_657SGA, Activo_657SGA, DVH 
          FROM Cliente 
          WHERE 1=1 ");
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand())
                {
                    if (!string.IsNullOrWhiteSpace(dni))
                    {
                        query.Append(" AND CAST(DNI_657SGA AS VARCHAR) LIKE @DNI ");
                        comando.Parameters.AddWithValue("@DNI", "%" + dni.Trim() + "%");
                    }
                    if (!string.IsNullOrWhiteSpace(nombre))
                    {
                        query.Append(" AND Nombre_657SGA LIKE @Nombre ");
                        comando.Parameters.AddWithValue("@Nombre", "%" + nombre.Trim() + "%");
                    }
                    if (!string.IsNullOrWhiteSpace(apellido))
                    {
                        query.Append(" AND Apellido_657SGA LIKE @Apellido ");
                        comando.Parameters.AddWithValue("@Apellido", "%" + apellido.Trim() + "%");
                    }
                    if (!string.IsNullOrWhiteSpace(email))
                    {
                        query.Append(" AND Email_657SGA LIKE @Email ");
                        comando.Parameters.AddWithValue("@Email", "%" + email.Trim() + "%");
                    }
                    if (!string.IsNullOrWhiteSpace(telefono))
                    {
                        query.Append(" AND CAST(Teléfono_657SGA AS VARCHAR) LIKE @Telefono ");
                        comando.Parameters.AddWithValue("@Telefono", "%" + telefono.Trim() + "%");
                    }
                    if (!string.IsNullOrWhiteSpace(direccion))
                    {
                        query.Append(" AND Dirección_657SGA LIKE @Direccion ");
                        comando.Parameters.AddWithValue("@Direccion", "%" + direccion.Trim() + "%");
                    }
                    if (soloActivos.HasValue)
                    {
                        query.Append(" AND Activo_657SGA = @Activo ");
                        comando.Parameters.AddWithValue("@Activo", soloActivos.Value);
                    }
                    comando.CommandText = query.ToString();
                    comando.Connection = conexion;
                    conexion.Open();
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new BECliente
                            {
                                DNI_657SGA = Convert.ToInt32(reader["DNI_657SGA"]),
                                Nombre_657SGA = reader["Nombre_657SGA"].ToString(),
                                Apellido_657SGA = reader["Apellido_657SGA"].ToString(),
                                Email_657SGA = reader["Email_657SGA"].ToString(),
                                Teléfono_657SGA = Convert.ToInt32(reader["Teléfono_657SGA"]),
                                Dirección_657SGA = reader["Dirección_657SGA"].ToString(),
                                Activo_657SGA = Convert.ToBoolean(reader["Activo_657SGA"]),
                                DVH = reader["DVH"]?.ToString()
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}
