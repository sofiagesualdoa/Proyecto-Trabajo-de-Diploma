$connStr = "Data Source=.;Initial Catalog=EverGlow;Integrated Security=True;TrustServerCertificate=True;"
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT Id_Permiso, Nombre_Permiso FROM Permiso WHERE Nombre_Permiso LIKE '%Libro%'"
$reader = $cmd.ExecuteReader()
while ($reader.Read()) {
    Write-Host "$($reader[0]) - $($reader[1])"
}
$reader.Close()
$conn.Close()
