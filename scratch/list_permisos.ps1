$connStr = "Data Source=.;Initial Catalog=EverGlow;Integrated Security=True;TrustServerCertificate=True;"
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT IdPermiso, Nombre FROM Permiso"
$reader = $cmd.ExecuteReader()
while ($reader.Read()) {
    Write-Host "$($reader[0]) - $($reader[1])"
}
$reader.Close()
$conn.Close()
