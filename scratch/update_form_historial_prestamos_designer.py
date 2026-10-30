import glob

file_path = glob.glob('**/FormHistorialPrestamos.Designer.cs', recursive=True)[0]
with open(file_path, 'r', encoding='utf-8') as f:
    content = f.read()

target1 = 'btnDevolver = new Button();'
repl1 = '''btnDevolver = new Button();
            btnImprimirComprobante = new Button();'''

target2 = '''            // 
            // groupBoxDetalle
            // 
            groupBoxDetalle.Controls.Add(dgvDetalles);
            groupBoxDetalle.Controls.Add(lblDetalleInfo);'''

repl2 = '''            // 
            // groupBoxDetalle
            // 
            groupBoxDetalle.Controls.Add(btnImprimirComprobante);
            groupBoxDetalle.Controls.Add(dgvDetalles);
            groupBoxDetalle.Controls.Add(lblDetalleInfo);'''

target3 = '''            // 
            // lblDetalleInfo
            // 
            lblDetalleInfo.AutoSize = true;
            lblDetalleInfo.Font = new Font("Sitka Text", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDetalleInfo.Location = new Point(15, 22);
            lblDetalleInfo.Name = "lblDetalleInfo";
            lblDetalleInfo.Size = new Size(329, 19);
            lblDetalleInfo.TabIndex = 0;
            lblDetalleInfo.Text = "Seleccione un préstamo para visualizar sus detalles.";'''

repl3 = '''            // 
            // lblDetalleInfo
            // 
            lblDetalleInfo.AutoSize = true;
            lblDetalleInfo.Font = new Font("Sitka Text", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDetalleInfo.Location = new Point(15, 22);
            lblDetalleInfo.Name = "lblDetalleInfo";
            lblDetalleInfo.Size = new Size(329, 19);
            lblDetalleInfo.TabIndex = 0;
            lblDetalleInfo.Text = "Seleccione un préstamo para visualizar sus detalles.";
            // 
            // btnImprimirComprobante
            // 
            btnImprimirComprobante.BackColor = Color.Sienna;
            btnImprimirComprobante.Font = new Font("Sitka Text", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnImprimirComprobante.ForeColor = Color.Black;
            btnImprimirComprobante.Location = new Point(740, 14);
            btnImprimirComprobante.Name = "btnImprimirComprobante";
            btnImprimirComprobante.Size = new Size(195, 30);
            btnImprimirComprobante.TabIndex = 2;
            btnImprimirComprobante.Text = "Imprimir Comprobante";
            btnImprimirComprobante.UseVisualStyleBackColor = false;
            btnImprimirComprobante.Click += btnImprimirComprobante_Click;'''

target4 = 'private Button btnDevolver;'
repl4 = '''private Button btnDevolver;
        private Button btnImprimirComprobante;'''

if target1 in content and target2 in content and target3 in content and target4 in content:
    content = content.replace(target1, repl1, 1)
    content = content.replace(target2, repl2, 1)
    content = content.replace(target3, repl3, 1)
    content = content.replace(target4, repl4, 1)
    with open(file_path, 'w', encoding='utf-8') as f:
        f.write(content)
    print('SUCCESS')
else:
    print('TARGETS NOT MATCHED')
