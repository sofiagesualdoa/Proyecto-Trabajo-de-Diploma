$connStr = "Data Source=.;Initial Catalog=EverGlow;Integrated Security=True;TrustServerCertificate=True;"
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

Write-Host "=== ROWS IN Libro_C ==="
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT IdLibroC, ISBN, Titulo, Existencias, ExistenciasPrestamo, Fecha, Hora, Act FROM Libro_C"
$reader = $cmd.ExecuteReader()
while ($reader.Read()) {
    Write-Host "$($reader[0]) | $($reader[1]) | $($reader[2]) | Venta:$($reader[3]) | Prestamo:$($reader[4]) | $($reader[5]) | $($reader[6]) | Act:$($reader[7])"
}
$reader.Close()

Write-Host "`n=== TRIGGERS ON Libro ==="
$cmd.CommandText = "SELECT name, is_disabled FROM sys.triggers WHERE parent_id = OBJECT_ID('Libro')"
$reader = $cmd.ExecuteReader()
while ($reader.Read()) {
    Write-Host "$($reader[0]) (Disabled: $($reader[1]))"
}
$reader.Close()

Write-Host "`n=== TRIGGERS ON Libro_C ==="
$cmd.CommandText = "SELECT name, is_disabled FROM sys.triggers WHERE parent_id = OBJECT_ID('Libro_C')"
$reader = $cmd.ExecuteReader()
while ($reader.Read()) {
    Write-Host "$($reader[0]) (Disabled: $($reader[1]))"
}
$reader.Close()

$conn.Close()
