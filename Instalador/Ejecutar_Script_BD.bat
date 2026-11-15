@echo off
chcp 65001 > nul
echo ========================================================
echo   BOOKLY - INSTALACION DE BASE DE DATOS EVERGLOW
echo ========================================================
echo.
echo Ejecutando script de inicializacion limpia en SQL Server...
sqlcmd -S . -E -C -f 65001 -i "%~dp0Instalacion_Limpia_EverGlow.sql" -b
if %ERRORLEVEL% EQU 0 (
    echo.
    echo Base de datos 'EverGlow' instalada correctamente.
    exit /b 0
) else (
    echo.
    echo ERROR: No se pudo ejecutar en el servidor local. Intentando LocalDB...
    sqlcmd -S "(localdb)\MSSQLLocalDB" -E -C -f 65001 -i "%~dp0Instalacion_Limpia_EverGlow.sql" -b
    if %ERRORLEVEL% EQU 0 (
        echo Base de datos instalada en LocalDB exitosamente.
        exit /b 0
    ) else (
        echo Error fatal al conectar con SQL Server. Verifique el servicio.
        exit /b 1
    )
)
