import glob

file_path = glob.glob('**/FormHistorialPrestamos.cs', recursive=True)[0]
with open(file_path, 'r', encoding='utf-8') as f:
    content = f.read()

target = '        private void FormHistorialPrestamos_FormClosing(object sender, FormClosingEventArgs e)'

new_method = '''        private void btnImprimirComprobante_Click(object sender, EventArgs e)
        {
            var session = ServicioSessionManager.GetInstance();
            if (dgvPrestamos.CurrentRow == null || !(dgvPrestamos.CurrentRow.DataBoundItem is BEPrestamo prestamo))
            {
                MessageBox.Show(
                    session.Traducir("Seleccione un préstamo de la grilla para imprimir su comprobante."),
                    session.Traducir("Atención"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (prestamo.Estado == "Activo")
            {
                MessageBox.Show(
                    session.Traducir("El comprobante oficial de devolución sólo puede emitirse una vez finalizado el préstamo."),
                    session.Traducir("Atención"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            BECliente cliente = bllCliente.BuscarClientePorDNI(prestamo.DNI);
            BELibro? libro = bllLibro.ObtenerLibros().FirstOrDefault(l => l.ISBN_657SGA == prestamo.ISBN);

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Documento PDF (*.pdf)|*.pdf";
            sfd.FileName = $"Comprobante_Devolucion_Prestamo_{prestamo.IdPrestamo}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
            sfd.Title = session.Traducir("Guardar Comprobante de Devolución");

            string rutaPdf = string.Empty;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                rutaPdf = sfd.FileName;
            }
            else
            {
                string carpetaMisDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                rutaPdf = Path.Combine(carpetaMisDocs, $"Comprobante_Devolucion_Prestamo_{prestamo.IdPrestamo}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");
            }

            try
            {
                bllPrestamo.GenerarComprobantePDF(prestamo, cliente, libro, rutaPdf);

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
            }
            catch (Exception ex)
            {
                MessageBox.Show(session.Traducir(ex.Message), session.Traducir("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormHistorialPrestamos_FormClosing(object sender, FormClosingEventArgs e)'''

if target in content and 'btnImprimirComprobante_Click' not in content:
    content = content.replace(target, new_method, 1)
    with open(file_path, 'w', encoding='utf-8') as f:
        f.write(content)
    print('SUCCESS')
else:
    print('TARGET NOT FOUND OR ALREADY PRESENT')
