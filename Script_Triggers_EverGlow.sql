USE EverGlow;
GO

-- ====================================================================
-- 1. INMUTABILIDAD DE VENTAS
-- Bloquea modificaciones a datos comerciales y previene eliminaciÃ³n
-- ====================================================================
CREATE OR ALTER TRIGGER TR_Venta_Inmutable
ON Venta
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    IF UPDATE(Total) OR UPDATE(Fecha) OR UPDATE(Hora) OR UPDATE(DNICliente)
    BEGIN
        RAISERROR ('Las ventas concretadas son registros inmutables y no pueden modificarse.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;
GO

CREATE OR ALTER TRIGGER TR_Venta_NoDelete
ON Venta
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;
    RAISERROR ('Las ventas concretadas son registros inmutables y no pueden eliminarse.', 16, 1);
    ROLLBACK TRANSACTION;
END;
GO

-- ====================================================================
-- 2. INMUTABILIDAD DE FACTURAS
-- Bloquea modificaciones a comprobantes y previene eliminaciÃ³n
-- ====================================================================
CREATE OR ALTER TRIGGER TR_Factura_Inmutable
ON Factura
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    IF UPDATE(Total) OR UPDATE(Fecha) OR UPDATE(Hora) OR UPDATE(DNICliente) OR UPDATE(NumeroFactura)
    BEGIN
        RAISERROR ('Las facturas emitidas son comprobantes legales inmutables y no pueden modificarse.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;
GO

CREATE OR ALTER TRIGGER TR_Factura_NoDelete
ON Factura
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;
    RAISERROR ('Las facturas emitidas son comprobantes legales inmutables y no pueden eliminarse.', 16, 1);
    ROLLBACK TRANSACTION;
END;
GO

-- ====================================================================
-- 3. SALVAGUARDA DE INTEGRIDAD DE STOCK
-- Impide que el stock de libros caiga por debajo de 0
-- ====================================================================
CREATE OR ALTER TRIGGER TR_Libro_ControlStock
ON Libro
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM inserted WHERE Existencias_657SGA < 0)
    BEGIN
        RAISERROR ('OperaciÃ³n abortada: el stock no puede ser inferior a 0 unidades.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;
GO

-- ====================================================================
-- 4. CONVERSIÃ“N AUTOMÃTICA A BAJA LÃ“GICA
-- Intercepta DELETE fÃ­sico y actualiza Activo_657SGA = 0
-- ====================================================================
CREATE OR ALTER TRIGGER TR_Libro_BajaLogica
ON Libro
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Libro 
    SET Activo_657SGA = 0 
    WHERE ISBN_657SGA IN (SELECT ISBN_657SGA FROM deleted);
END;
GO

CREATE OR ALTER TRIGGER TR_Cliente_BajaLogica
ON Cliente
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Cliente
    SET Activo_657SGA = 0 
    WHERE DNI_657SGA IN (SELECT DNI_657SGA FROM deleted);
END;
GO