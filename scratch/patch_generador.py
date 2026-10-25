with open('Servicios/Integridad/GeneradorDigVerificador.cs', 'rb') as f:
    data = f.read()
target = b'.Where(p => !(nombreClase == "BEFactura" && p.Name == "IdVenta"))\r\n'
replacement = b'.Where(p => !(nombreClase == "BEFactura" && p.Name == "IdVenta"))\r\n            .Where(p => !(nombreClase == "BEPrestamo" && p.Name == "NumeroFactura"))\r\n'
assert target in data
new_data = data.replace(target, replacement, 1)
with open('Servicios/Integridad/GeneradorDigVerificador.cs', 'wb') as f:
    f.write(new_data)
print('Updated GeneradorDigVerificador.cs successfully')
