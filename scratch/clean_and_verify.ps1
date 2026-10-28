$connStr = "Data Source=.;Initial Catalog=EverGlow;Integrated Security=True;TrustServerCertificate=True;"
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

# Aseguramos precio de Nosotros en la Luna
$cmd = $conn.CreateCommand()
$cmd.CommandText = "UPDATE Libro SET Precio_657SGA = 35000.00 WHERE ISBN_657SGA = '9879867543298'"
$cmd.ExecuteNonQuery() | Out-Null

# Limpiamos filas de prueba temporales de Libro_C mayores a 6
$cmd.CommandText = "DELETE FROM Libro_C WHERE IdLibroC > 6"
$cmd.ExecuteNonQuery() | Out-Null

# Aseguramos Act = 1 en todas las 6 filas iniciales
$cmd.CommandText = "UPDATE Libro_C SET Act = 1 WHERE IdLibroC <= 6"
$cmd.ExecuteNonQuery() | Out-Null

Write-Host "Filas actuales en Libro_C:"
$cmd.CommandText = "SELECT IdLibroC, ISBN, Titulo, Precio, Act FROM Libro_C ORDER BY IdLibroC"
$reader = $cmd.ExecuteReader()
while ($reader.Read()) {
    Write-Host "Id: $($reader[0]) | $($reader[1]) | $($reader[2]) | $($reader[3]) | Act: $($reader[4])"
}
$reader.Close()
$conn.Close()
