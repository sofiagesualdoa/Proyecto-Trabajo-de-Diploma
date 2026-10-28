$connStr = "Data Source=.;Initial Catalog=EverGlow;Integrated Security=True;TrustServerCertificate=True;"
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='Permiso'"
$reader = $cmd.ExecuteReader()
while ($reader.Read()) {
    Write-Host $reader[0]
}
$reader.Close()
$conn.Close()
