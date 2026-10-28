$connStr = "Data Source=.;Initial Catalog=EverGlow;Integrated Security=True;TrustServerCertificate=True;"
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

$sqlPath = Join-Path $PSScriptRoot "setup_libro_c.sql"
$content = Get-Content -Path $sqlPath -Raw -Encoding UTF8

# Split by GO on its own line
$batches = $content -split "(?m)^\s*GO\s*$"

foreach ($batch in $batches) {
    $trimmed = $batch.Trim()
    if ($trimmed.Length -gt 0) {
        $cmd = $conn.CreateCommand()
        $cmd.CommandText = $trimmed
        try {
            $cmd.ExecuteNonQuery() | Out-Null
            Write-Host "Batch executed successfully."
        } catch {
            Write-Host "Error in batch: $($_.Exception.Message)"
            Write-Host "Batch SQL: $trimmed"
            $conn.Close()
            exit 1
        }
    }
}

$conn.Close()
Write-Host "All batches completed successfully!"
