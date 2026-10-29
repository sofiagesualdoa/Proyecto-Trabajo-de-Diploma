with open('Venta Productos Cosméticos/FormCobro.cs', 'r', encoding='utf-8-sig') as f:
    txt = f.read()

# Add using System.IO; if missing
if 'using System.IO;' not in txt:
    txt = 'using System.IO;\r\n' + txt

old_block = """                if (carrito != null)
                {
                    BEPago pago = bllFactura.RealizarPago(tarjeta, carrito.Total);
                    BEFactura factura = bllVenta.ConcretarVenta(carrito, cliente, pago);
                    MessageBox.Show(string.Format(s.Traducir("¡Venta confirmada exitosamente!\\nN° Factura: {0}\\nImporte abonado: ${1:N2}"),
                                                  factura.NumeroFactura, factura.Total),
                                    s.Traducir("Éxito"),
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }"""

new_block = """                if (carrito != null)
                {
                    BEPago pago = bllFactura.RealizarPago(tarjeta, carrito.Total);
                    BEFactura factura = bllVenta.ConcretarVenta(carrito, cliente, pago);

                    string numLimpio = factura.NumeroFactura.Replace('/', '_').Replace('\\\\', '_');
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "Archivos PDF (*.pdf)|*.pdf";
                    sfd.FileName = $"Factura_{numLimpio}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                    sfd.Title = s.Traducir("Guardar Factura de Venta");

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
                        bllFactura.GenerarFacturaPDF(factura, cliente, carrito.Detalles, pago, rutaPdf);
                    }
                    catch
                    {
                    }

                    MessageBox.Show(string.Format(s.Traducir("¡Venta confirmada exitosamente!\\nN° Factura: {0}\\nImporte abonado: ${1:N2}\\n\\nFactura emitida en:\\n{2}"),
                                                  factura.NumeroFactura, factura.Total, rutaPdf),
                                    s.Traducir("Éxito"),
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    if (File.Exists(rutaPdf))
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = rutaPdf,
                                UseShellExecute = true
                            });
                        }
                        catch
                        {
                        }
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }"""

assert old_block in txt, "old_block not found in FormCobro.cs"
txt = txt.replace(old_block, new_block, 1)

with open('Venta Productos Cosméticos/FormCobro.cs', 'w', encoding='utf-8-sig') as f:
    f.write(txt)

print("FormCobro.cs updated successfully!")
