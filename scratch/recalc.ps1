$bin = "c:\Users\usuario\OneDrive\Facultad\3° Año\2° Cuatrimestre\Trabajo de Diploma\Carpeta\Proyecto-Trabajo-de-Diploma\Venta Productos Cosméticos\bin\Debug\net8.0-windows"
[System.Reflection.Assembly]::LoadFrom("$bin\BE.dll") | Out-Null
[System.Reflection.Assembly]::LoadFrom("$bin\DAL.dll") | Out-Null
[System.Reflection.Assembly]::LoadFrom("$bin\Servicios.dll") | Out-Null

$srv = New-Object Servicios.ServicioDVV
$srv.RecalcularDigitosVerificadores()
Write-Output "Recalculo completado exitosamente"
