import glob

file_path = glob.glob('**/FormCobro.cs', recursive=True)[0]
with open(file_path, 'r', encoding='utf-8') as f:
    content = f.read()

field_target = 'private readonly BLLPrestamo bllPrestamo = new BLLPrestamo();'
field_repl = '''private readonly BLLPrestamo bllPrestamo = new BLLPrestamo();
        private readonly BLLLibro bllLibro = new BLLLibro();'''

if field_target in content and 'private readonly BLLLibro bllLibro' not in content:
    content = content.replace(field_target, field_repl, 1)

old_block = '''                else if (prestamo != null && montoRecargo > 0)
                {
                    BEFactura factura = bllPrestamo.CobrarRecargo(prestamo, cliente, tarjeta, montoRecargo);
                    MessageBox.Show(string.Format(s.Traducir("¡Recargo por mora cobrado exitosamente!\\nN° Factura: {0}\\nImporte abonado: ${1:N2}"),
                                                  factura.NumeroFactura, factura.Total),
                                    s.Traducir("Éxito"),
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else if (prestamo != null)
                {
                    BEFactura factura = bllPrestamo.ConcretarPrestamo(prestamo, cliente, tarjeta);
                    MessageBox.Show(string.Format(s.Traducir("¡Préstamo confirmado exitosamente!\\nN° Factura: {0}\\nFecha Pactada de Devolución: {1:dd/MM/yyyy}\\nImporte abonado: ${2:N2}"),
                                                  factura.NumeroFactura, prestamo.FechaDevolucion, factura.Total),
                                    s.Traducir("Éxito"),
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }'''

new_block = '''                else if (prestamo != null && montoRecargo > 0)
                {
                    BEFactura factura = bllPrestamo.CobrarRecargo(prestamo, cliente, tarjeta, montoRecargo);

                    BELibro? libroPrestamo = bllLibro.ObtenerLibros().FirstOrDefault(l => l.ISBN_657SGA == prestamo.ISBN);
                    string tituloLibro = libroPrestamo != null ? libroPrestamo.Título_657SGA : "Ejemplar Bookly";
                    string descRecargo = $"Recargo por Devolución Tardía - {tituloLibro}";

                    List<BEDetalleVenta> detallesRecargo = new List<BEDetalleVenta>
                    {
                        new BEDetalleVenta
                        {
                            ISBN = prestamo.ISBN,
                            Cantidad = 1,
                            PrecioUnitario = montoRecargo,
                            Subtotal = montoRecargo,
                            Libro = new BELibro
                            {
                                ISBN_657SGA = prestamo.ISBN,
                                Título_657SGA = descRecargo,
                                Autor_657SGA = libroPrestamo?.Autor_657SGA ?? string.Empty
                            }
                        }
                    };

                    BEPago pago = new BEPago
                    {
                        IdVenta = factura.IdFactura,
                        MedioPago = tarjeta.Tipo == "Débito" ? "Tarjeta de Débito" : "Tarjeta de Crédito",
                        Importe = montoRecargo,
                        Fecha = DateTime.Now
                    };

                    string numLimpio = factura.NumeroFactura.Replace('/', '_').Replace('\\\\', '_');
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "Archivos PDF (*.pdf)|*.pdf";
                    sfd.FileName = $"Factura_Recargo_{numLimpio}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                    sfd.Title = s.Traducir("Guardar Factura de Recargo por Mora");

                    string rutaPdf = string.Empty;
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        rutaPdf = sfd.FileName;
                    }
                    else
                    {
                        string carpetaMisDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        rutaPdf = Path.Combine(carpetaMisDocs, $"Factura_Recargo_{numLimpio}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");
                    }

                    try
                    {
                        bllFactura.GenerarFacturaPDF(factura, cliente, detallesRecargo, pago, rutaPdf);
                    }
                    catch
                    {
                    }

                    MessageBox.Show(string.Format(s.Traducir("¡Recargo por mora cobrado exitosamente!\\nN° Factura: {0}\\nImporte abonado: ${1:N2}\\n\\nFactura emitida en:\\n{2}"),
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
                }
                else if (prestamo != null)
                {
                    BEFactura factura = bllPrestamo.ConcretarPrestamo(prestamo, cliente, tarjeta);

                    BELibro? libroPrestamo = bllLibro.ObtenerLibros().FirstOrDefault(l => l.ISBN_657SGA == prestamo.ISBN);
                    string tituloLibro = libroPrestamo != null ? libroPrestamo.Título_657SGA : "Ejemplar Bookly";
                    string descPrestamo = $"Alquiler de Préstamo - {tituloLibro}";

                    List<BEDetalleVenta> detallesPrestamo = new List<BEDetalleVenta>
                    {
                        new BEDetalleVenta
                        {
                            ISBN = prestamo.ISBN,
                            Cantidad = 1,
                            PrecioUnitario = factura.Total,
                            Subtotal = factura.Total,
                            Libro = new BELibro
                            {
                                ISBN_657SGA = prestamo.ISBN,
                                Título_657SGA = descPrestamo,
                                Autor_657SGA = libroPrestamo?.Autor_657SGA ?? string.Empty
                            }
                        }
                    };

                    BEPago pago = new BEPago
                    {
                        IdVenta = factura.IdFactura,
                        MedioPago = tarjeta.Tipo == "Débito" ? "Tarjeta de Débito" : "Tarjeta de Crédito",
                        Importe = factura.Total,
                        Fecha = DateTime.Now
                    };

                    string numLimpio = factura.NumeroFactura.Replace('/', '_').Replace('\\\\', '_');
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "Archivos PDF (*.pdf)|*.pdf";
                    sfd.FileName = $"Factura_Prestamo_{numLimpio}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                    sfd.Title = s.Traducir("Guardar Factura de Préstamo");

                    string rutaPdf = string.Empty;
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        rutaPdf = sfd.FileName;
                    }
                    else
                    {
                        string carpetaMisDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        rutaPdf = Path.Combine(carpetaMisDocs, $"Factura_Prestamo_{numLimpio}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");
                    }

                    try
                    {
                        bllFactura.GenerarFacturaPDF(factura, cliente, detallesPrestamo, pago, rutaPdf);
                    }
                    catch
                    {
                    }

                    MessageBox.Show(string.Format(s.Traducir("¡Préstamo confirmado exitosamente!\\nN° Factura: {0}\\nFecha Pactada de Devolución: {1:dd/MM/yyyy}\\nImporte abonado: ${2:N2}\\n\\nFactura emitida en:\\n{3}"),
                                                  factura.NumeroFactura, prestamo.FechaDevolucion, factura.Total, rutaPdf),
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
                }'''

if old_block in content:
    content = content.replace(old_block, new_block, 1)
    with open(file_path, 'w', encoding='utf-8') as f:
        f.write(content)
    print('SUCCESS')
else:
    print('OLD BLOCK NOT FOUND')
