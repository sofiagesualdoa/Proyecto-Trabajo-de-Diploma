using BE;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Servicios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BLL
{
    public class BLLFactura
    {
        private BLLEntidadBancaria entidadBancaria = new BLLEntidadBancaria();

        public BEPago RealizarPago(BETarjeta tarjeta, decimal importe)
        {
            var s = ServicioSessionManager.GetInstance();
            bool aprobado = entidadBancaria.ProcesarPago(tarjeta, importe);
            if (!aprobado)
            {
                throw new Exception(s.Traducir("Operación rechazada por la entidad bancaria. Fondos insuficientes o tarjeta inválida."));
            }
            return new BEPago
            {
                MedioPago = $"Tarjeta {tarjeta.Tipo}",
                Importe = importe,
                Fecha = DateTime.Now
            };
        }

        public void GenerarFacturaPDF(BEFactura factura, BECliente cliente, List<BEDetalleVenta> detalles, BEPago pago, string rutaArchivo)
        {
            if (factura == null)
            {
                throw new ArgumentNullException(nameof(factura));
            }

            if (string.IsNullOrWhiteSpace(rutaArchivo))
            {
                throw new ArgumentException("La ruta de destino no puede estar vacía.", nameof(rutaArchivo));
            }

            Document documento = new Document(PageSize.A4, 36f, 36f, 40f, 40f);
            using (FileStream fs = new FileStream(rutaArchivo, FileMode.Create))
            {
                PdfWriter.GetInstance(documento, fs);
                documento.Open();

                iTextSharp.text.Font fuenteTitulo = FontFactory.GetFont("Segoe UI", 18f, iTextSharp.text.Font.BOLD, new BaseColor(45, 55, 72));
                iTextSharp.text.Font fuenteSubtitulo = FontFactory.GetFont("Segoe UI", 10f, iTextSharp.text.Font.ITALIC, BaseColor.DARK_GRAY);
                iTextSharp.text.Font fuenteSeccion = FontFactory.GetFont("Segoe UI", 11f, iTextSharp.text.Font.BOLD, new BaseColor(45, 55, 72));
                iTextSharp.text.Font fuenteNegrita = FontFactory.GetFont("Segoe UI", 9f, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                iTextSharp.text.Font fuenteTexto = FontFactory.GetFont("Segoe UI", 9f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                Paragraph titulo = new Paragraph("BOOKLY LIBROS", fuenteTitulo);
                titulo.Alignment = Element.ALIGN_CENTER;
                documento.Add(titulo);

                Paragraph subtitulo = new Paragraph("FACTURA ELECTRÓNICA OFICIAL DE VENTA\n\n", fuenteSubtitulo);
                subtitulo.Alignment = Element.ALIGN_CENTER;
                documento.Add(subtitulo);

                PdfPTable tablaEncabezado = new PdfPTable(2);
                tablaEncabezado.WidthPercentage = 100f;
                tablaEncabezado.SetWidths(new float[] { 50f, 50f });

                string numFac = !string.IsNullOrWhiteSpace(factura.NumeroFactura) ? factura.NumeroFactura : $"FC-V-{factura.IdFactura:D6}";
                string fechaEmision = $"{factura.Fecha:dd/MM/yyyy} {factura.Hora:hh\\:mm\\:ss}";
                PdfPCell celdaIzq = new PdfPCell(new Phrase($"Factura Nº: {numFac}\nFecha Emisión: {fechaEmision}\nCondición IVA: Consumidor Final", fuenteTexto));
                celdaIzq.Border = iTextSharp.text.Rectangle.NO_BORDER;
                celdaIzq.PaddingBottom = 10f;
                tablaEncabezado.AddCell(celdaIzq);

                string medioPago = pago != null && !string.IsNullOrWhiteSpace(pago.MedioPago) ? pago.MedioPago : "Tarjeta de Crédito / Débito";
                PdfPCell celdaDer = new PdfPCell(new Phrase($"C.U.I.T.: 30-71234567-8\nIngresos Brutos: 901-234567-8\nMedio de Pago: {medioPago}", fuenteTexto));
                celdaDer.Border = iTextSharp.text.Rectangle.NO_BORDER;
                celdaDer.HorizontalAlignment = Element.ALIGN_RIGHT;
                celdaDer.PaddingBottom = 10f;
                tablaEncabezado.AddCell(celdaDer);

                documento.Add(tablaEncabezado);

                documento.Add(new Paragraph("DATOS DEL CLIENTE", fuenteSeccion));
                PdfPTable tablaCliente = new PdfPTable(2);
                tablaCliente.WidthPercentage = 100f;
                tablaCliente.SetWidths(new float[] { 50f, 50f });
                tablaCliente.SpacingBefore = 4f;
                tablaCliente.SpacingAfter = 12f;

                string dniCliente = cliente != null ? cliente.DNI_657SGA.ToString() : factura.DNICliente.ToString();
                string nombreCliente = cliente != null ? $"{cliente.Nombre_657SGA} {cliente.Apellido_657SGA}" : "Cliente Registrado";
                string telefonoCliente = cliente != null ? cliente.Teléfono_657SGA.ToString() : "N/A";
                string emailCliente = cliente != null ? cliente.Email_657SGA : "N/A";
                string direccionCliente = cliente != null && !string.IsNullOrWhiteSpace(cliente.Dirección_657SGA) ? cliente.Dirección_657SGA : "CABA";

                tablaCliente.AddCell(new PdfPCell(new Phrase($"DNI: {dniCliente}\nNombre: {nombreCliente}", fuenteTexto)) { Border = iTextSharp.text.Rectangle.BOX, Padding = 6f });
                tablaCliente.AddCell(new PdfPCell(new Phrase($"Teléfono: {telefonoCliente}\nEmail: {emailCliente}\nDirección: {direccionCliente}", fuenteTexto)) { Border = iTextSharp.text.Rectangle.BOX, Padding = 6f });
                documento.Add(tablaCliente);

                documento.Add(new Paragraph("DETALLE DE ARTÍCULOS", fuenteSeccion));
                PdfPTable tablaDetalles = new PdfPTable(5);
                tablaDetalles.WidthPercentage = 100f;
                tablaDetalles.SetWidths(new float[] { 18f, 44f, 10f, 14f, 14f });
                tablaDetalles.SpacingBefore = 4f;
                tablaDetalles.SpacingAfter = 15f;

                tablaDetalles.AddCell(new PdfPCell(new Phrase("ISBN", fuenteNegrita)) { BackgroundColor = new BaseColor(240, 240, 240), Padding = 6f });
                tablaDetalles.AddCell(new PdfPCell(new Phrase("Descripción", fuenteNegrita)) { BackgroundColor = new BaseColor(240, 240, 240), Padding = 6f });
                tablaDetalles.AddCell(new PdfPCell(new Phrase("Cant.", fuenteNegrita)) { BackgroundColor = new BaseColor(240, 240, 240), HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6f });
                tablaDetalles.AddCell(new PdfPCell(new Phrase("Precio Unit.", fuenteNegrita)) { BackgroundColor = new BaseColor(240, 240, 240), HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6f });
                tablaDetalles.AddCell(new PdfPCell(new Phrase("Subtotal", fuenteNegrita)) { BackgroundColor = new BaseColor(240, 240, 240), HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6f });

                if (detalles != null)
                {
                    foreach (var item in detalles)
                    {
                        string desc = !string.IsNullOrWhiteSpace(item.Título) ? item.Título : (item.Libro != null ? item.Libro.Título_657SGA : "Libro");
                        tablaDetalles.AddCell(new PdfPCell(new Phrase(item.ISBN, fuenteTexto)) { Padding = 5f });
                        tablaDetalles.AddCell(new PdfPCell(new Phrase(desc, fuenteTexto)) { Padding = 5f });
                        tablaDetalles.AddCell(new PdfPCell(new Phrase(item.Cantidad.ToString(), fuenteTexto)) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 5f });
                        tablaDetalles.AddCell(new PdfPCell(new Phrase($"$ {item.PrecioUnitario:N2}", fuenteTexto)) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 5f });
                        tablaDetalles.AddCell(new PdfPCell(new Phrase($"$ {item.Subtotal:N2}", fuenteTexto)) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 5f });
                    }
                }

                documento.Add(tablaDetalles);

                PdfPTable tablaTotales = new PdfPTable(2);
                tablaTotales.WidthPercentage = 100f;
                tablaTotales.SetWidths(new float[] { 70f, 30f });
                tablaTotales.SpacingAfter = 20f;

                decimal total = factura.Total;
                decimal subtotalNeto = Math.Round(total / 1.21m, 2);
                decimal iva = total - subtotalNeto;

                tablaTotales.AddCell(new PdfPCell(new Phrase("Subtotal Neto Gravado (21%):", fuenteTexto)) { Border = iTextSharp.text.Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4f });
                tablaTotales.AddCell(new PdfPCell(new Phrase($"$ {subtotalNeto:N2}", fuenteTexto)) { Border = iTextSharp.text.Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4f });

                tablaTotales.AddCell(new PdfPCell(new Phrase("IVA Liquidado (21%):", fuenteTexto)) { Border = iTextSharp.text.Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4f });
                tablaTotales.AddCell(new PdfPCell(new Phrase($"$ {iva:N2}", fuenteTexto)) { Border = iTextSharp.text.Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4f });

                tablaTotales.AddCell(new PdfPCell(new Phrase("TOTAL FACTURA:", fuenteNegrita)) { BackgroundColor = new BaseColor(245, 245, 245), HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6f });
                tablaTotales.AddCell(new PdfPCell(new Phrase($"$ {total:N2}", fuenteNegrita)) { BackgroundColor = new BaseColor(245, 245, 245), HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6f });

                documento.Add(tablaTotales);

                Paragraph pie = new Paragraph("¡Muchas gracias por su compra en Bookly Libros!\nDocumento emitido electrónicamente como comprobante fiscal válido de venta.", fuenteSubtitulo);
                pie.Alignment = Element.ALIGN_CENTER;
                documento.Add(pie);

                documento.Close();
            }
        }
    }
}
