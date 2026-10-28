-- =========================================================================
-- SCRIPT DE BASE DE DATOS: BITÁCORA DE CAMBIOS (Libro_C)
-- Base de Datos: EverGlow
-- Proyecto: Bookly
-- =========================================================================

USE EverGlow;
GO

-- 1. Crear tabla Libro_C si no existe
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Libro_C')
BEGIN
    CREATE TABLE Libro_C (
        IdLibroC INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        ISBN VARCHAR(13) NOT NULL,
        Titulo NVARCHAR(100) NULL,
        Precio DECIMAL(18,2) NULL,
        Existencias INT NULL,
        ExistenciasPrestamo INT NULL,
        Editorial NVARCHAR(100) NULL,
        Autor VARCHAR(MAX) NULL,
        EsParaPrestamo BIT NULL,
        Activo BIT NULL,
        DVH VARCHAR(64) NULL,
        Fecha DATE NOT NULL DEFAULT CAST(GETDATE() AS DATE),
        Hora TIME(7) NOT NULL DEFAULT CAST(GETDATE() AS TIME),
        Act BIT NOT NULL DEFAULT 1,
        CONSTRAINT FK_Libro_C_Libro FOREIGN KEY (ISBN) REFERENCES Libro(ISBN_657SGA)
    );
    PRINT 'Tabla Libro_C creada exitosamente.';
END
ELSE
BEGIN
    PRINT 'La tabla Libro_C ya existe.';
END
GO

-- 2. Población inicial: si Libro_C está vacía, cargar foto actual de Libro
IF NOT EXISTS (SELECT 1 FROM Libro_C)
BEGIN
    INSERT INTO Libro_C (
        ISBN,
        Titulo,
        Precio,
        Existencias,
        ExistenciasPrestamo,
        Editorial,
        Autor,
        EsParaPrestamo,
        Activo,
        DVH,
        Fecha,
        Hora,
        Act
    )
    SELECT 
        [ISBN_657SGA],
        [Título_657SGA],
        [Precio_657SGA],
        [Existencias_657SGA],
        [ExistenciasPrestamo],
        [Editorial_657SGA],
        [Autor_657SGA],
        [EsParaPrestamo],
        [Activo_657SGA],
        [DVH],
        CAST(GETDATE() AS DATE),
        CAST(GETDATE() AS TIME),
        1
    FROM Libro;
    PRINT 'Población inicial de Libro_C completada.';
END
GO

-- 3. Trigger TR_Libro_Actualizado (AFTER INSERT, UPDATE en Libro)
CREATE OR ALTER TRIGGER TR_Libro_Actualizado
ON Libro
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Si la actualización provino de la sincronización de rollback en Libro_C, no duplicar versión
    IF TRIGGER_NESTLEVEL(OBJECT_ID('TR_Libro_C_Actualizado')) > 0
        RETURN;

    -- 1. Desactivar versiones previas de los libros modificados/insertados
    UPDATE lc
    SET lc.Act = 0
    FROM Libro_C lc
    INNER JOIN inserted i ON lc.ISBN = i.ISBN_657SGA
    WHERE lc.Act = 1;

    -- 2. Insertar la nueva versión activa
    INSERT INTO Libro_C (
        ISBN,
        Titulo,
        Precio,
        Existencias,
        ExistenciasPrestamo,
        Editorial,
        Autor,
        EsParaPrestamo,
        Activo,
        DVH,
        Fecha,
        Hora,
        Act
    )
    SELECT 
        i.ISBN_657SGA,
        i.[Título_657SGA],
        i.Precio_657SGA,
        i.Existencias_657SGA,
        i.ExistenciasPrestamo,
        i.Editorial_657SGA,
        i.Autor_657SGA,
        i.EsParaPrestamo,
        i.Activo_657SGA,
        i.DVH,
        CAST(GETDATE() AS DATE),
        CAST(GETDATE() AS TIME),
        1
    FROM inserted i;
END;
GO

-- 4. Trigger TR_Libro_Eliminado (AFTER DELETE en Libro)
CREATE OR ALTER TRIGGER TR_Libro_Eliminado
ON Libro
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- Desactivar cualquier versión activa previa en Libro_C
    UPDATE lc
    SET lc.Act = 0
    FROM Libro_C lc
    INNER JOIN deleted d ON lc.ISBN = d.ISBN_657SGA
    WHERE lc.Act = 1;
END;
GO

-- 5. Trigger TR_Libro_C_Actualizado (AFTER UPDATE en Libro_C)
CREATE OR ALTER TRIGGER TR_Libro_C_Actualizado
ON Libro_C
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Verificar si se activó una versión que estaba inactiva (Rollback)
    IF EXISTS (
        SELECT 1 
        FROM inserted i
        INNER JOIN deleted d ON i.IdLibroC = d.IdLibroC
        WHERE i.Act = 1 AND d.Act = 0
    )
    BEGIN
        -- Desactivar todas las demás versiones del mismo libro
        UPDATE lc
        SET lc.Act = 0
        FROM Libro_C lc
        INNER JOIN inserted i ON lc.ISBN = i.ISBN
        INNER JOIN deleted d ON i.IdLibroC = d.IdLibroC
        WHERE lc.IdLibroC <> i.IdLibroC 
          AND lc.Act = 1 
          AND i.Act = 1 
          AND d.Act = 0;

        -- Sincronizar la tabla operacional Libro con los valores de la versión restaurada
        UPDATE l
        SET 
            l.[Título_657SGA] = i.Titulo,
            l.Precio_657SGA = i.Precio,
            l.Existencias_657SGA = i.Existencias,
            l.ExistenciasPrestamo = i.ExistenciasPrestamo,
            l.Editorial_657SGA = i.Editorial,
            l.Autor_657SGA = i.Autor,
            l.EsParaPrestamo = i.EsParaPrestamo,
            l.Activo_657SGA = i.Activo
        FROM Libro l
        INNER JOIN inserted i ON l.ISBN_657SGA = i.ISBN
        INNER JOIN deleted d ON i.IdLibroC = d.IdLibroC
        WHERE i.Act = 1 AND d.Act = 0;
    END
END;
GO
