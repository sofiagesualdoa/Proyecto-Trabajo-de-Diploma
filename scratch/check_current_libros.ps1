$connStr = "Data Source=.;Initial Catalog=EverGlow;Integrated Security=True;TrustServerCertificate=True;"
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT COUNT(*) FROM Libro"
$count = $cmd.ExecuteScalar()
Write-Host "Total libros in EverGlow: $count"

$cmd.CommandText = "SELECT TOP 5 ISBN_657SGA, Título_657SGA, Existencias_657SGA, ExistenciasPrestamo, Activo_657SGA FROM Libro"
$reader = $cmd.ExecuteReader()
while ($reader.Read()) {
    Write-Host "$($reader[0]) | $($reader[1]) | Venta: $($reader[2]) | Prestamo: $($reader[3]) | Activo: $($reader[4])"
}
$reader.Close()
$conn.Close()
