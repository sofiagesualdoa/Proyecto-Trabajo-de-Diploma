$c = New-Object System.Data.SqlClient.SqlConnection('Data Source=.;Initial Catalog=EverGlow;Integrated Security=True;TrustServerCertificate=True')
$c.Open()
$cmd = $c.CreateCommand()
$cmd.CommandText = "SELECT p.Nombre, t.TextoTraducido FROM Traduccion t INNER JOIN Palabra p ON t.IdPalabra = p.IdPalabra WHERE p.Nombre LIKE '%Prestamo%' OR p.Nombre LIKE '%Préstamo%'"
$r = $cmd.ExecuteReader()
while($r.Read()){
    Write-Host ($r[0].ToString() + ' -> ' + $r[1].ToString())
}
$c.Close()
