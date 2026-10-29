# Script to update DataGridView fonts from Sitka Text to Segoe UI in the 3 forms

# 1. FormLibroCambios.Designer.cs
with open('Venta Productos Cosméticos/FormLibroCambios.Designer.cs', 'r', encoding='utf-8-sig') as f:
    txt = f.read()

txt = txt.replace('dataGridViewCellStyle1.Font = new Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);',
                  'dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);')
txt = txt.replace('dataGridViewCellStyle2.Font = new Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);',
                  'dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);')

if 'dgvCambios.Font =' not in txt:
    txt = txt.replace('dgvCambios.DefaultCellStyle = dataGridViewCellStyle2;',
                      'dgvCambios.DefaultCellStyle = dataGridViewCellStyle2;\r\n            dgvCambios.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);')

with open('Venta Productos Cosméticos/FormLibroCambios.Designer.cs', 'w', encoding='utf-8-sig') as f:
    f.write(txt)

# 2. FormLibroCambios.cs
with open('Venta Productos Cosméticos/FormLibroCambios.cs', 'r', encoding='utf-8-sig') as f:
    txt = f.read()

txt = txt.replace('new Font("Sitka Text", 9F, FontStyle.Bold)', 'new Font("Segoe UI", 9F, FontStyle.Bold)')

with open('Venta Productos Cosméticos/FormLibroCambios.cs', 'w', encoding='utf-8-sig') as f:
    f.write(txt)

# 3. FormHistorialVentas.Designer.cs
with open('Venta Productos Cosméticos/FormHistorialVentas.Designer.cs', 'r', encoding='utf-8-sig') as f:
    txt = f.read()

if 'dgvVentas.Font =' not in txt:
    txt = txt.replace('dgvVentas.CellClick += dgvVentas_CellClick;',
                      'dgvVentas.CellClick += dgvVentas_CellClick;\r\n            dgvVentas.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);')

if 'dgvDetalles.Font =' not in txt:
    txt = txt.replace('dgvDetalles.Name = "dgvDetalles";',
                      'dgvDetalles.Name = "dgvDetalles";\r\n            dgvDetalles.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);')

with open('Venta Productos Cosméticos/FormHistorialVentas.Designer.cs', 'w', encoding='utf-8-sig') as f:
    f.write(txt)

# 4. FormHistorialPrestamos.Designer.cs
with open('Venta Productos Cosméticos/FormHistorialPrestamos.Designer.cs', 'r', encoding='utf-8-sig') as f:
    txt = f.read()

if 'dgvPrestamos.Font =' not in txt:
    txt = txt.replace('dgvPrestamos.CellClick += dgvPrestamos_CellClick;',
                      'dgvPrestamos.CellClick += dgvPrestamos_CellClick;\r\n            dgvPrestamos.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);')

if 'dgvDetalles.Font =' not in txt:
    txt = txt.replace('dgvDetalles.Name = "dgvDetalles";',
                      'dgvDetalles.Name = "dgvDetalles";\r\n            dgvDetalles.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);')

with open('Venta Productos Cosméticos/FormHistorialPrestamos.Designer.cs', 'w', encoding='utf-8-sig') as f:
    f.write(txt)

print("Updated grid fonts to Segoe UI successfully!")
