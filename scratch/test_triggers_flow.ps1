$connStr = "Data Source=.;Initial Catalog=EverGlow;Integrated Security=True;TrustServerCertificate=True;"
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

$isbn = '9781526369874'

Write-Host '--- 1. PRECIO ORIGINAL EN LIBRO ---'
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT Precio_657SGA FROM Libro WHERE ISBN_657SGA = '$isbn'"
$origPrice = $cmd.ExecuteScalar()
Write-Host "Precio original: $origPrice"

Write-Host '--- 2. ACTUALIZAMOS PRECIO EN LIBRO ---'
$cmd.CommandText = "UPDATE Libro SET Precio_657SGA = 9999.00 WHERE ISBN_657SGA = '$isbn'"
$cmd.ExecuteNonQuery() | Out-Null

Write-Host '--- 3. VERIFICAMOS FILAS EN LIBRO_C TRAS EL UPDATE ---'
$cmd.CommandText = "SELECT IdLibroC, Precio, Act, Fecha, Hora FROM Libro_C WHERE ISBN = '$isbn' ORDER BY IdLibroC"
$reader = $cmd.ExecuteReader()
$firstId = 0
$secondId = 0
while ($reader.Read()) {
    Write-Host "IdLibroC: $($reader[0]) | Precio: $($reader[1]) | Act: $($reader[2]) | $($reader[3]) $($reader[4])"
    if ($firstId -eq 0) { $firstId = $reader[0] } else { $secondId = $reader[0] }
}
$reader.Close()

Write-Host "--- 4. SIMULAMOS ACTIVAR VERSION ANTERIOR (ROLLBACK A IdLibroC = $firstId) ---"
$cmd.CommandText = "UPDATE Libro_C SET Act = 1 WHERE IdLibroC = $firstId"
$cmd.ExecuteNonQuery() | Out-Null

Write-Host '--- 5. VERIFICAMOS SI LIBRO FUE RESTAURADO ---'
$cmd.CommandText = "SELECT Precio_657SGA FROM Libro WHERE ISBN_657SGA = '$isbn'"
$restoredPrice = $cmd.ExecuteScalar()
Write-Host "Precio en Libro tras Rollback: $restoredPrice (Esperado: $origPrice)"

Write-Host '--- 6. VERIFICAMOS ESTADOS EN LIBRO_C TRAS ROLLBACK ---'
$cmd.CommandText = "SELECT IdLibroC, Precio, Act FROM Libro_C WHERE ISBN = '$isbn' ORDER BY IdLibroC"
$reader = $cmd.ExecuteReader()
while ($reader.Read()) {
    Write-Host "IdLibroC: $($reader[0]) | Precio: $($reader[1]) | Act: $($reader[2])"
}
$reader.Close()

if ($secondId -ne 0) {
    $cmd.CommandText = "DELETE FROM Libro_C WHERE IdLibroC = $secondId"
    $cmd.ExecuteNonQuery() | Out-Null
    Write-Host 'Fila de prueba eliminada, base de datos limpia.'
}

$conn.Close()
