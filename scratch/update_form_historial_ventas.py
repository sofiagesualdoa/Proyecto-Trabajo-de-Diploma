# Update FormHistorialVentas.Designer.cs

with open('Venta Productos Cosméticos/FormHistorialVentas.Designer.cs', 'r', encoding='utf-8-sig') as f:
    txt = f.read()

init_btn = '            btnImprimirFactura = new Button();\r\n            groupBoxFiltros.SuspendLayout();'
txt = txt.replace('            groupBoxFiltros.SuspendLayout();', init_btn, 1)

grp_add = '            groupBoxDetalle.Controls.Add(btnImprimirFactura);\r\n            groupBoxDetalle.Controls.Add(dgvDetalles);'
txt = txt.replace('            groupBoxDetalle.Controls.Add(dgvDetalles);', grp_add, 1)

btn_props = """            // 
            // btnImprimirFactura
            // 
            btnImprimirFactura.BackColor = Color.Sienna;
            btnImprimirFactura.Font = new Font("Sitka Text", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnImprimirFactura.ForeColor = Color.Black;
            btnImprimirFactura.Location = new Point(780, 14);
            btnImprimirFactura.Name = "btnImprimirFactura";
            btnImprimirFactura.Size = new Size(155, 30);
            btnImprimirFactura.TabIndex = 2;
            btnImprimirFactura.Text = "Imprimir Factura";
            btnImprimirFactura.UseVisualStyleBackColor = false;
            btnImprimirFactura.Click += btnImprimirFactura_Click;
            // 
            // lblDetalleInfo"""
txt = txt.replace('            // \r\n            // lblDetalleInfo', btn_props, 1)

decl = '        private DataGridView dgvDetalles;\r\n        private Button btnImprimirFactura;'
txt = txt.replace('        private DataGridView dgvDetalles;', decl, 1)

with open('Venta Productos Cosméticos/FormHistorialVentas.Designer.cs', 'w', encoding='utf-8-sig') as f:
    f.write(txt)

# Update FormHistorialVentas.cs
with open('Venta Productos Cosméticos/FormHistorialVentas.cs', 'r', encoding='utf-8-sig') as f:
    txt_cs = f.read()

if 'using System.IO;' not in txt_cs:
    txt_cs = 'using System.IO;\r\n' + txt_cs

new_method = """
        private void btnImprimirFactura_Click(object sender, EventArgs e)
        {
            if (dgvVentas.CurrentRow == null || !(dgvVentas.CurrentRow.DataBoundItem is BEVenta venta))
            {
                MessageBox.Show(
                    ServicioSessionManager.GetInstance().Traducir("Seleccione una venta de la grilla para imprimir su factura."),
                    ServicioSessionManager.GetInstance().Traducir("Atención"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            var factura = bllVenta.BuscarFacturaPorVenta(venta.IdVenta);
            if (factura == null)
            {
                factura = new BEFactura
                {
                    IdFactura = venta.IdVenta,
                    NumeroFactura = venta.NumeroFactura,
                    DNICliente = venta.DNICliente,
                    Fecha = venta.Fecha,
                    Total = venta.Total
                };
            }

            var cliente = new BLLCliente().ObtenerClientes().FirstOrDefault(c => c.DNI_657SGA == venta.DNICliente);
            var detalles = bllVenta.ObtenerDetallesPorVenta(venta.IdVenta);
            var pago = new BEPago { MedioPago = "Tarjeta", Importe = venta.Total, Fecha = venta.Fecha };

            string numLimpio = !string.IsNullOrWhiteSpace(factura.NumeroFactura) 
                ? factura.NumeroFactura.Replace('/', '_').Replace('\\\\', '_') 
                : $"Venta_{venta.IdVenta}";

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivos PDF (*.pdf)|*.pdf";
            sfd.FileName = $"Factura_{numLimpio}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
            sfd.Title = ServicioSessionManager.GetInstance().Traducir("Guardar Factura de Venta");

            string rutaPdf = string.Empty;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                rutaPdf = sfd.FileName;
            }
            else
            {
                string carpetaMisDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                rutaPdf = Path.Combine(carpetaMisDocs, $"Factura_{numLimpio}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");
            }

            try
            {
                new BLLFactura().GenerarFacturaPDF(factura, cliente, detalles, pago, rutaPdf);
                MessageBox.Show(
                    string.Format(
                        ServicioSessionManager.GetInstance().Traducir("Factura emitida exitosamente en:\\n{0}"),
                        rutaPdf
                    ),
                    ServicioSessionManager.GetInstance().Traducir("Éxito"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                if (File.Exists(rutaPdf))
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = rutaPdf,
                        UseShellExecute = true
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ServicioSessionManager.GetInstance().Traducir("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}"""

last_closing = txt_cs.rfind("    }\r\n}")
if last_closing == -1:
    last_closing = txt_cs.rfind("    }\n}")

assert last_closing != -1, "last_closing not found"
txt_cs = txt_cs[:last_closing] + new_method

with open('Venta Productos Cosméticos/FormHistorialVentas.cs', 'w', encoding='utf-8-sig') as f:
    f.write(txt_cs)

print("FormHistorialVentas updated successfully!")
