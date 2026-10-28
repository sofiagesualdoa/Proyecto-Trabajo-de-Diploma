$connStr = "Data Source=.;Initial Catalog=EverGlow;Integrated Security=True;TrustServerCertificate=True;"
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = @"
SELECT 
    t.name AS TriggerName,
    OBJECT_NAME(t.parent_id) AS TableName,
    m.definition AS TriggerDefinition
FROM sys.triggers t
INNER JOIN sys.sql_modules m ON t.object_id = m.object_id
WHERE t.parent_id = OBJECT_ID('Libro')
"@
$reader = $cmd.ExecuteReader()
while ($reader.Read()) {
    Write-Host "TRIGGER: $($reader[0]) ON $($reader[1])"
    Write-Host $reader[2]
    Write-Host "----------------------------------------"
}
$reader.Close()
$conn.Close()
