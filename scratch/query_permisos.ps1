$c = New-Object System.Data.SqlClient.SqlConnection('Data Source=.;Initial Catalog=EverGlow;Integrated Security=True;TrustServerCertificate=True')
$c.Open()
$cmd = $c.CreateCommand()
$cmd.CommandText = 'SELECT IdPermiso, Nombre FROM Permiso'
$r = $cmd.ExecuteReader()
while($r.Read()){
    Write-Host ($r[0].ToString() + ': ' + $r[1].ToString())
}
$c.Close()
