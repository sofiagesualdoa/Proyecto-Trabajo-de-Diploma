with open('BLL/BLLPrestamo.cs', 'rb') as f:
    data = f.read()

target = b'string numFactura = prestamo.IdFactura.HasValue ? $"FC-ID {prestamo.IdFactura.Value}" : "N/A";'
replacement = b'string numFactura = !string.IsNullOrWhiteSpace(prestamo.NumeroFactura) ? prestamo.NumeroFactura : (prestamo.IdFactura.HasValue ? $"FC-ID {prestamo.IdFactura.Value}" : "N/A");'

assert target in data, "target not found in BLLPrestamo.cs"
data = data.replace(target, replacement, 1)

with open('BLL/BLLPrestamo.cs', 'wb') as f:
    f.write(data)
print('Updated BLLPrestamo.cs successfully')
