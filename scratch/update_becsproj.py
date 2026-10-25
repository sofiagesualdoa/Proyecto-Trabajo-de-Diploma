with open('BE/BE.csproj', 'rb') as f:
    data = f.read()
target = b'<Compile Include="BEDetalleFactura.cs" />\r\n'
replacement = b'<Compile Include="BEDetalleFactura.cs" />\r\n    <Compile Include="BEDetallePrestamo.cs" />\r\n'
assert target in data
new_data = data.replace(target, replacement, 1)
with open('BE/BE.csproj', 'wb') as f:
    f.write(new_data)
print('Updated BE.csproj successfully')
