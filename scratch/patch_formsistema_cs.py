with open('Venta Productos Cosméticos/FormSistema.cs', 'rb') as f:
    data = f.read()

target = '''        private void nuevoPréstamoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPrestamo frm = new FormPrestamo();
            frm.MdiParent = this.MdiParent;
            frm.Show();
            this.Close();
        }
    }
}'''

replacement = '''        private void nuevoPréstamoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPrestamo frm = new FormPrestamo();
            frm.MdiParent = this.MdiParent;
            frm.Show();
            this.Close();
        }

        private void historialPréstamosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHistorialPrestamos frmHistorial = new FormHistorialPrestamos();
            frmHistorial.MdiParent = this.MdiParent;
            frmHistorial.Show();
            this.Close();
        }
    }
}'''

target_bytes = target.replace('\n', '\r\n').encode('utf-8')
replacement_bytes = replacement.replace('\n', '\r\n').encode('utf-8')

assert target_bytes in data, "target not found in FormSistema.cs"
data = data.replace(target_bytes, replacement_bytes, 1)

with open('Venta Productos Cosméticos/FormSistema.cs', 'wb') as f:
    f.write(data)
print('Updated FormSistema.cs successfully')
