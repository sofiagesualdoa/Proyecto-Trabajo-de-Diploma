import glob

file_path = glob.glob('**/FormHistorialVentas.Designer.cs', recursive=True)[0]
with open(file_path, 'r', encoding='utf-8') as f:
    content = f.read()

target = '''            // 
            // lblDetalleInfo
            // 
            lblDetalleInfo.AutoSize = true;
            lblDetalleInfo.Font = new Font("Sitka Text", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDetalleInfo.Location = new Point(15, 22);
            lblDetalleInfo.Name = "lblDetalleInfo";
            lblDetalleInfo.Size = new Size(312, 19);
            lblDetalleInfo.TabIndex = 0;
            lblDetalleInfo.Text = "Seleccione una venta para visualizar sus detalles.";'''

replacement = '''            // 
            // lblDetalleInfo
            // 
            lblDetalleInfo.AutoSize = true;
            lblDetalleInfo.Font = new Font("Sitka Text", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDetalleInfo.Location = new Point(15, 22);
            lblDetalleInfo.Name = "lblDetalleInfo";
            lblDetalleInfo.Size = new Size(312, 19);
            lblDetalleInfo.TabIndex = 0;
            lblDetalleInfo.Text = "Seleccione una venta para visualizar sus detalles.";
            // 
            // btnImprimirFactura
            // 
            btnImprimirFactura.BackColor = Color.Sienna;
            btnImprimirFactura.Font = new Font("Sitka Text", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnImprimirFactura.ForeColor = Color.Black;
            btnImprimirFactura.Location = new Point(765, 14);
            btnImprimirFactura.Name = "btnImprimirFactura";
            btnImprimirFactura.Size = new Size(170, 30);
            btnImprimirFactura.TabIndex = 2;
            btnImprimirFactura.Text = "Imprimir Factura";
            btnImprimirFactura.UseVisualStyleBackColor = false;
            btnImprimirFactura.Click += btnImprimirFactura_Click;'''

if target in content and 'btnImprimirFactura.Click +=' not in content:
    content = content.replace(target, replacement, 1)
    with open(file_path, 'w', encoding='utf-8') as f:
        f.write(content)
    print('SUCCESS')
else:
    print('TARGET NOT FOUND OR ALREADY CONFIGURED')
