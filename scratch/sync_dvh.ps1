$connStr = "Data Source=.;Initial Catalog=EverGlow;Integrated Security=True;TrustServerCertificate=True;"
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = "UPDATE lc SET lc.DVH = l.DVH FROM Libro_C lc INNER JOIN Libro l ON lc.ISBN = l.ISBN_657SGA WHERE lc.Act = 1"
$cmd.ExecuteNonQuery() | Out-Null
$conn.Close()
Write-Host "Libro_C DVH synchronized."
