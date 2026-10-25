$c = New-Object System.Data.SqlClient.SqlConnection('Data Source=.;Initial Catalog=EverGlow;Integrated Security=True;TrustServerCertificate=True')
$c.Open()
$cmd = $c.CreateCommand()
$cmd.CommandText = 'SELECT p.Nombre, pxp.IdPermiso FROM Perfil_x_Permiso pxp INNER JOIN Perfil p ON pxp.IdPerfil = p.IdPerfil WHERE pxp.IdPermiso = 21'
$r = $cmd.ExecuteReader()
while($r.Read()){
    Write-Host ($r[0].ToString() + ' -> ' + $r[1].ToString())
}
$r.Close()
$cmd.CommandText = 'SELECT f.Nombre, pxf.IdPermiso FROM Permiso_x_Familia pxf INNER JOIN Familia f ON pxf.IdFamilia = f.IdFamilia WHERE pxf.IdPermiso = 21'
$r2 = $cmd.ExecuteReader()
while($r2.Read()){
    Write-Host ($r2[0].ToString() + ' -> ' + $r2[1].ToString())
}
$c.Close()
