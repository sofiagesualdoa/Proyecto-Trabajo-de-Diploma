path = r"DAL\DALVenta.cs"
with open(path, "r", encoding="utf-8") as f:
    content = f.read()

target = """            string query = @"SELECT f.IdFactura AS IdVenta, f.DNICliente, f.Fecha, f.Hora, f.Total, f.DVH, f.NumeroFactura 
                             FROM Factura f 
                             WHERE f.IdFactura LIKE 'FC-B%'
                             ORDER BY f.IdFactura DESC;";"""

replacement = """            string query = @"SELECT f.IdFactura AS IdVenta, f.DNICliente, f.Fecha, f.Hora, f.Total, f.DVH, f.NumeroFactura 
                             FROM Factura f 
                             WHERE f.NumeroFactura LIKE 'FC-V%' 
                               AND NOT EXISTS (SELECT 1 FROM Prestamo p WHERE p.IdFactura = f.IdFactura) 
                             ORDER BY f.IdFactura DESC;";"""

assert target in content, "target not found in DALVenta.cs"
content = content.replace(target, replacement, 1)

with open(path, "w", encoding="utf-8") as f:
    f.write(content)

print("DALVenta.cs patched successfully.")
