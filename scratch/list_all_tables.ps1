$c = New-Object System.Data.SqlClient.SqlConnection('Data Source=.;Initial Catalog=EverGlow;Integrated Security=True;TrustServerCertificate=True')
$c.Open()
$cmd = $c.CreateCommand()
$cmd.CommandText = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' ORDER BY TABLE_NAME"
$r = $cmd.ExecuteReader()
while($r.Read()){
    Write-Host $r[0].ToString()
}
$c.Close()
