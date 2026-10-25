path_dallibro = r"c:\Users\usuario\OneDrive\Facultad\3° Año\2° Cuatrimestre\Trabajo de Diploma\Carpeta\Proyecto-Trabajo-de-Diploma\DAL\DALLibro.cs"
path_daldvv = r"c:\Users\usuario\OneDrive\Facultad\3° Año\2° Cuatrimestre\Trabajo de Diploma\Carpeta\Proyecto-Trabajo-de-Diploma\DAL\DALDVV.cs"

# 1. Update DALLibro.cs
with open(path_dallibro, "r", encoding="utf-8") as f:
    c_libro = f.read()

# Query 1: BuscarLibroPorISBN_657SGA
c_libro = c_libro.replace(
    "SELECT Título_657SGA, ISBN_657SGA, Precio_657SGA, Existencias_657SGA, Editorial_657SGA, Autor_657SGA, Activo_657SGA, EsParaPrestamo, DVH",
    "SELECT Título_657SGA, ISBN_657SGA, Precio_657SGA, Existencias_657SGA, ExistenciasPrestamo, Editorial_657SGA, Autor_657SGA, Activo_657SGA, EsParaPrestamo, DVH"
)

# Mapping in BuscarLibroPorISBN_657SGA and ObtenerLibros
old_map_1 = """                            libroEncontrado.Existencias_657SGA = Convert.ToInt32(reader["Existencias_657SGA"]);
                            libroEncontrado.Precio_657SGA = Convert.ToDecimal(reader["Precio_657SGA"]);"""
new_map_1 = """                            libroEncontrado.Existencias_657SGA = Convert.ToInt32(reader["Existencias_657SGA"]);
                            libroEncontrado.ExistenciasPrestamo = reader["ExistenciasPrestamo"] != DBNull.Value ? Convert.ToInt32(reader["ExistenciasPrestamo"]) : 0;
                            libroEncontrado.Precio_657SGA = Convert.ToDecimal(reader["Precio_657SGA"]);"""
c_libro = c_libro.replace(old_map_1, new_map_1)

old_map_2 = """                            libro.Existencias_657SGA = Convert.ToInt32(reader["Existencias_657SGA"]);
                            libro.Precio_657SGA = Convert.ToDecimal(reader["Precio_657SGA"]);"""
new_map_2 = """                            libro.Existencias_657SGA = Convert.ToInt32(reader["Existencias_657SGA"]);
                            libro.ExistenciasPrestamo = reader["ExistenciasPrestamo"] != DBNull.Value ? Convert.ToInt32(reader["ExistenciasPrestamo"]) : 0;
                            libro.Precio_657SGA = Convert.ToDecimal(reader["Precio_657SGA"]);"""
c_libro = c_libro.replace(old_map_2, new_map_2)

# Insert in GuardarLibro
old_insert = """            string query = @"INSERT INTO Libro (ISBN_657SGA, Título_657SGA, Autor_657SGA, Existencias_657SGA, Precio_657SGA, Editorial_657SGA, Activo_657SGA, EsParaPrestamo, DVH) 
                     VALUES (@ISBN_657SGA, @Título_657SGA, @Autor_657SGA, @Existencias_657SGA, @Precio_657SGA, @Editorial_657SGA, @Activo_657SGA, @EsParaPrestamo, @DVH);";"""
new_insert = """            string query = @"INSERT INTO Libro (ISBN_657SGA, Título_657SGA, Autor_657SGA, Existencias_657SGA, ExistenciasPrestamo, Precio_657SGA, Editorial_657SGA, Activo_657SGA, EsParaPrestamo, DVH) 
                     VALUES (@ISBN_657SGA, @Título_657SGA, @Autor_657SGA, @Existencias_657SGA, @ExistenciasPrestamo, @Precio_657SGA, @Editorial_657SGA, @Activo_657SGA, @EsParaPrestamo, @DVH);";"""
c_libro = c_libro.replace(old_insert, new_insert)

old_insert_param = """                    comando.Parameters.Add("@Existencias_657SGA", SqlDbType.Int).Value = libro.Existencias_657SGA;
                    comando.Parameters.Add("@Precio_657SGA", SqlDbType.Decimal).Value = libro.Precio_657SGA;"""
new_insert_param = """                    comando.Parameters.Add("@Existencias_657SGA", SqlDbType.Int).Value = libro.Existencias_657SGA;
                    comando.Parameters.Add("@ExistenciasPrestamo", SqlDbType.Int).Value = libro.ExistenciasPrestamo;
                    comando.Parameters.Add("@Precio_657SGA", SqlDbType.Decimal).Value = libro.Precio_657SGA;"""
c_libro = c_libro.replace(old_insert_param, new_insert_param)

# BuscarLibros mapping
c_libro = c_libro.replace(
    "SELECT ISBN_657SGA, Título_657SGA, Autor_657SGA, Editorial_657SGA, Precio_657SGA, Existencias_657SGA, Activo_657SGA, EsParaPrestamo, DVH",
    "SELECT ISBN_657SGA, Título_657SGA, Autor_657SGA, Editorial_657SGA, Precio_657SGA, Existencias_657SGA, ExistenciasPrestamo, Activo_657SGA, EsParaPrestamo, DVH"
)

old_map_3 = """                            l.Existencias_657SGA = Convert.ToInt32(reader["Existencias_657SGA"]);
                            l.Editorial_657SGA = reader["Editorial_657SGA"].ToString();"""
new_map_3 = """                            l.Existencias_657SGA = Convert.ToInt32(reader["Existencias_657SGA"]);
                            l.ExistenciasPrestamo = reader["ExistenciasPrestamo"] != DBNull.Value ? Convert.ToInt32(reader["ExistenciasPrestamo"]) : 0;
                            l.Editorial_657SGA = reader["Editorial_657SGA"].ToString();"""
c_libro = c_libro.replace(old_map_3, new_map_3)

# Update in ModificarLibro
old_update = """            string query = @"UPDATE Libro 
                             SET ISBN_657SGA = @NuevoISBN,
                                 Título_657SGA = @Título, 
                                 Autor_657SGA = @Autor, 
                                 Existencias_657SGA = @Existencias, 
                                 Precio_657SGA = @Precio, 
                                 Editorial_657SGA = @Editorial, 
                                 Activo_657SGA = @Activo, 
                                 DVH = @DVH 
                             WHERE ISBN_657SGA = @ISBN_Original;";"""
new_update = """            string query = @"UPDATE Libro 
                             SET ISBN_657SGA = @NuevoISBN,
                                 Título_657SGA = @Título, 
                                 Autor_657SGA = @Autor, 
                                 Existencias_657SGA = @Existencias, 
                                 ExistenciasPrestamo = @ExistenciasPrestamo, 
                                 Precio_657SGA = @Precio, 
                                 Editorial_657SGA = @Editorial, 
                                 Activo_657SGA = @Activo, 
                                 EsParaPrestamo = @EsParaPrestamo, 
                                 DVH = @DVH 
                             WHERE ISBN_657SGA = @ISBN_Original;";"""
c_libro = c_libro.replace(old_update, new_update)

old_update_param = """                    comando.Parameters.Add("@Existencias", SqlDbType.Int).Value = libro.Existencias_657SGA;
                    comando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = libro.Precio_657SGA;"""
new_update_param = """                    comando.Parameters.Add("@Existencias", SqlDbType.Int).Value = libro.Existencias_657SGA;
                    comando.Parameters.Add("@ExistenciasPrestamo", SqlDbType.Int).Value = libro.ExistenciasPrestamo;
                    comando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = libro.Precio_657SGA;"""
c_libro = c_libro.replace(old_update_param, new_update_param)

with open(path_dallibro, "w", encoding="utf-8") as f:
    f.write(c_libro)
print("DALLibro.cs updated")

# 2. Update DALDVV.cs
with open(path_daldvv, "r", encoding="utf-8") as f:
    c_dvv = f.read()

c_dvv = c_dvv.replace(
    "SELECT Título_657SGA, ISBN_657SGA, Precio_657SGA, Existencias_657SGA, Editorial_657SGA, Autor_657SGA, Activo_657SGA, EsParaPrestamo, DVH FROM Libro",
    "SELECT Título_657SGA, ISBN_657SGA, Precio_657SGA, Existencias_657SGA, ExistenciasPrestamo, Editorial_657SGA, Autor_657SGA, Activo_657SGA, EsParaPrestamo, DVH FROM Libro"
)

old_map_dvv = """                            Existencias_657SGA = Convert.ToInt32(reader["Existencias_657SGA"]),
                            Precio_657SGA = Convert.ToDecimal(reader["Precio_657SGA"]),"""
new_map_dvv = """                            Existencias_657SGA = Convert.ToInt32(reader["Existencias_657SGA"]),
                            ExistenciasPrestamo = reader["ExistenciasPrestamo"] != DBNull.Value ? Convert.ToInt32(reader["ExistenciasPrestamo"]) : 0,
                            Precio_657SGA = Convert.ToDecimal(reader["Precio_657SGA"]),"""
c_dvv = c_dvv.replace(old_map_dvv, new_map_dvv)

with open(path_daldvv, "w", encoding="utf-8") as f:
    f.write(c_dvv)
print("DALDVV.cs updated")
