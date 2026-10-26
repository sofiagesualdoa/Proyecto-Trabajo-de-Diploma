$c = New-Object System.Data.SqlClient.SqlConnection('Data Source=.;Initial Catalog=EverGlow;Integrated Security=True;TrustServerCertificate=True')
$c.Open()
$cmd = $c.CreateCommand()
$cmd.CommandText = 'SELECT IdPermiso, Nombre FROM Permiso ORDER BY IdPermiso'
$r = $cmd.ExecuteReader()
while($r.Read()){
    Write-Host ($r[0].ToString() + ' -> ' + $r[1].ToString())
}
$r.Close()
$cmd.CommandText = 'SELECT p.Nombre as Perfil, perm.Nombre as Permiso FROM Perfil_x_Permiso pxp INNER JOIN Perfil p ON pxp.IdPerfil = p.IdPerfil INNER JOIN Permiso perm ON pxp.IdPermiso = perm.IdPermiso WHERE perm.Nombre LIKE ''%Pr%stamo%'''
$r2 = $cmd.ExecuteReader()
while($r2.Read()){
    Write-Host ($r2[0].ToString() + ' tiene ' + $r2[1].ToString())
}
$c.Close()
