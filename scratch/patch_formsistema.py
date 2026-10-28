import os

designer_path = r'c:\Users\usuario\OneDrive\Facultad\3° Año\2° Cuatrimestre\Trabajo de Diploma\Carpeta\Proyecto-Trabajo-de-Diploma\Venta Productos Cosméticos\FormSistema.Designer.cs'
with open(designer_path, 'r', encoding='utf-8') as f:
    text = f.read()

target = 'librosCToolStripMenuItem.Text = "Libros C";'
replacement = 'librosCToolStripMenuItem.Text = "Libros C";\r\n            librosCToolStripMenuItem.Click += librosCToolStripMenuItem_Click;'

if target in text:
    text = text.replace(target, replacement, 1)
    with open(designer_path, 'w', encoding='utf-8') as f:
        f.write(text)
    print("Designer patched successfully")
else:
    print("Target not found in Designer")

cs_path = r'c:\Users\usuario\OneDrive\Facultad\3° Año\2° Cuatrimestre\Trabajo de Diploma\Carpeta\Proyecto-Trabajo-de-Diploma\Venta Productos Cosméticos\FormSistema.cs'
with open(cs_path, 'r', encoding='utf-8') as f:
    cs_text = f.read()

cs_target = 'private void clientesToolStripMenuItem_Click(object sender, EventArgs e)'
cs_replacement = '''private void librosCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLibroCambios frm = new FormLibroCambios();
            frm.MdiParent = this.MdiParent;
            frm.Show();
            this.Close();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)'''

if cs_target in cs_text:
    cs_text = cs_text.replace(cs_target, cs_replacement, 1)
    with open(cs_path, 'w', encoding='utf-8') as f:
        f.write(cs_text)
    print("FormSistema.cs patched successfully")
else:
    print("Target not found in FormSistema.cs")
