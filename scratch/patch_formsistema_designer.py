with open('Venta Productos Cosméticos/FormSistema.Designer.cs', 'rb') as f:
    data = f.read()

target = b'''            historialPr\xc3\xa9stamosToolStripMenuItem.Name = "historialPr\xc3\xa9stamosToolStripMenuItem";\r\n            historialPr\xc3\xa9stamosToolStripMenuItem.Size = new Size(250, 28);\r\n            historialPr\xc3\xa9stamosToolStripMenuItem.Tag = "Ver Historial Pr\xc3\xa9stamos";\r\n            historialPr\xc3\xa9stamosToolStripMenuItem.Text = "Historial Pr\xc3\xa9stamos";\r\n'''

replacement = b'''            historialPr\xc3\xa9stamosToolStripMenuItem.Name = "historialPr\xc3\xa9stamosToolStripMenuItem";\r\n            historialPr\xc3\xa9stamosToolStripMenuItem.Size = new Size(250, 28);\r\n            historialPr\xc3\xa9stamosToolStripMenuItem.Tag = "Ver Historial Pr\xc3\xa9stamos";\r\n            historialPr\xc3\xa9stamosToolStripMenuItem.Text = "Historial Pr\xc3\xa9stamos";\r\n            historialPr\xc3\xa9stamosToolStripMenuItem.Click += historialPr\xc3\xa9stamosToolStripMenuItem_Click;\r\n'''

assert target in data, "target not found in FormSistema.Designer.cs"
data = data.replace(target, replacement, 1)

with open('Venta Productos Cosméticos/FormSistema.Designer.cs', 'wb') as f:
    f.write(data)
print('Updated FormSistema.Designer.cs successfully')
