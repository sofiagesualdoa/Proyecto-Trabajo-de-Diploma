using BE;
using DAL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Servicios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BLL
{
    public class BLLReporteInteligente
    {
        private readonly DALReporteInteligente dalReporte = new DALReporteInteligente();

        public BEReporteInteligente GenerarReporte(DateTime fechaDesde, DateTime fechaHasta)
        {
            var session = ServicioSessionManager.GetInstance();
            if (fechaHasta.Date < fechaDesde.Date)
            {
                throw new Exception(session.Traducir("La fecha de fin no puede ser anterior a la fecha de inicio."));
            }

            BEReporteInteligente reporte = new BEReporteInteligente
            {
                FechaDesde = fechaDesde.Date,
                FechaHasta = fechaHasta.Date
            };

            var totales = dalReporte.ObtenerTotales(fechaDesde, fechaHasta);
            reporte.TotalVentasRealizadas = totales.ventasCount;
            reporte.TotalEjemplaresVendidos = totales.ejemplaresVendidos;
            reporte.MontoTotalVentas = totales.ventasTotal;
            reporte.TotalPrestamosRealizados = totales.prestamosCount;
            reporte.TotalPrestamosFinalizados = totales.prestamosFinalizados;
            reporte.TotalPrestamosConMora = totales.prestamosMora;
            reporte.MontoTotalPrestamos = totales.prestamosTotal;
            reporte.MontoTotalRecargosMora = totales.recargosTotal;

            var editoriales = dalReporte.ObtenerVentasPorEditorial(fechaDesde, fechaHasta);
            decimal totalDineroEditoriales = editoriales.Sum(e => e.TotalRecaudado);
            if (totalDineroEditoriales > 0)
            {
                foreach (var ed in editoriales)
                {
                    ed.Porcentaje = Math.Round((ed.TotalRecaudado / totalDineroEditoriales) * 100m, 1);
                }
            }
            reporte.VentasPorEditorial = editoriales.Take(6).ToList();

            var autores = dalReporte.ObtenerDemandaPorAutor(fechaDesde, fechaHasta);
            int totalEjemplaresAutores = autores.Sum(a => a.Cantidad);
            if (totalEjemplaresAutores > 0)
            {
                foreach (var au in autores)
                {
                    au.Porcentaje = Math.Round(((decimal)au.Cantidad / totalEjemplaresAutores) * 100m, 1);
                }
            }
            reporte.DemandaPorAutor = autores.Take(6).ToList();

            decimal totalIngresosAmbos = reporte.MontoTotalVentas + reporte.MontoTotalPrestamos + reporte.MontoTotalRecargosMora;
            List<BEItemEstadistico> comparativa = new List<BEItemEstadistico>
            {
                new BEItemEstadistico
                {
                    Etiqueta = session.Traducir("Ventas Directas"),
                    Cantidad = reporte.TotalEjemplaresVendidos,
                    TotalRecaudado = reporte.MontoTotalVentas,
                    Porcentaje = totalIngresosAmbos > 0 ? Math.Round((reporte.MontoTotalVentas / totalIngresosAmbos) * 100m, 1) : 0m
                },
                new BEItemEstadistico
                {
                    Etiqueta = session.Traducir("Préstamos y Recargos"),
                    Cantidad = reporte.TotalPrestamosRealizados,
                    TotalRecaudado = reporte.MontoTotalPrestamos + reporte.MontoTotalRecargosMora,
                    Porcentaje = totalIngresosAmbos > 0 ? Math.Round(((reporte.MontoTotalPrestamos + reporte.MontoTotalRecargosMora) / totalIngresosAmbos) * 100m, 1) : 0m
                }
            };
            reporte.ComparativaVentasVsPrestamos = comparativa;

            var libros = dalReporte.ObtenerMovimientosPorLibro(fechaDesde, fechaHasta);
            List<BEItemEstadistico> predicciones = new List<BEItemEstadistico>();
            foreach (var lib in libros.Where(l => l.TotalMovimientos > 0).OrderByDescending(l => l.TotalMovimientos).Take(4))
            {
                int baseDemanda = Math.Max(1, lib.TotalMovimientos);
                int proyectados = (int)Math.Ceiling(baseDemanda * 1.25m);
                if (proyectados < 2) proyectados = 2;
                decimal recaudacionEstimada = proyectados * lib.Precio;

                predicciones.Add(new BEItemEstadistico
                {
                    Etiqueta = lib.Titulo,
                    Cantidad = proyectados,
                    TotalRecaudado = recaudacionEstimada,
                    Porcentaje = 25m
                });
            }

            if (predicciones.Count == 0)
            {
                foreach (var lib in libros.Take(3))
                {
                    decimal precio = lib.Precio > 0 ? lib.Precio : 20000m;
                    predicciones.Add(new BEItemEstadistico
                    {
                        Etiqueta = lib.Titulo,
                        Cantidad = 2,
                        TotalRecaudado = 2 * precio,
                        Porcentaje = 15m
                    });
                }
            }

            reporte.PrediccionLibrosProximoMes = predicciones;
            reporte.Recomendaciones = GenerarRecomendacionesInteligentes(reporte, libros);

            return reporte;
        }

        public List<BELibroSobrestock> ObtenerLibrosSobrestock()
        {
            return dalReporte.ObtenerLibrosSobrestock();
        }

        public List<BEClienteVIP> ObtenerClientesCandidatosVIP(string isbn, string autor, string editorial)
        {
            return dalReporte.ObtenerClientesCandidatosVIP(isbn, autor, editorial);
        }

        public string GenerarPropuestaComercialPdf(BEClienteVIP cliente, BELibroSobrestock libro, decimal porcentajeDescuento, string rutaDestino)
        {
            if (cliente == null) throw new ArgumentNullException(nameof(cliente));
            if (libro == null) throw new ArgumentNullException(nameof(libro));
            if (string.IsNullOrWhiteSpace(rutaDestino)) throw new ArgumentException("Ruta de destino inválida.", nameof(rutaDestino));

            string? dir = Path.GetDirectoryName(rutaDestino);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            decimal descuentoDecimal = porcentajeDescuento / 100m;
            decimal montoDescuento = Math.Round(libro.Precio * descuentoDecimal, 2);
            decimal precioFinal = Math.Max(0m, libro.Precio - montoDescuento);
            string codigoPropuesta = $"VIP-{cliente.DNI}-{DateTime.Now:yyyyMMdd}-{Math.Abs(libro.ISBN.GetHashCode()) % 10000:D4}";

            Document doc = new Document(PageSize.A4, 40f, 40f, 40f, 40f);
            using (FileStream fs = new FileStream(rutaDestino, FileMode.Create))
            {
                PdfWriter.GetInstance(doc, fs);
                doc.Open();

                iTextSharp.text.Font fuenteEmpresa = FontFactory.GetFont("Segoe UI", 20f, iTextSharp.text.Font.BOLD, new BaseColor(160, 82, 45));
                iTextSharp.text.Font fuenteLema = FontFactory.GetFont("Segoe UI", 10f, iTextSharp.text.Font.ITALIC, BaseColor.DARK_GRAY);
                iTextSharp.text.Font fuenteTituloDoc = FontFactory.GetFont("Segoe UI", 13f, iTextSharp.text.Font.BOLD, new BaseColor(45, 55, 72));
                iTextSharp.text.Font fuenteSub = FontFactory.GetFont("Segoe UI", 9.5f, iTextSharp.text.Font.NORMAL, BaseColor.GRAY);
                iTextSharp.text.Font fuenteSeccion = FontFactory.GetFont("Segoe UI", 11f, iTextSharp.text.Font.BOLD, new BaseColor(160, 82, 45));
                iTextSharp.text.Font fuenteTexto = FontFactory.GetFont("Segoe UI", 9.5f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                iTextSharp.text.Font fuenteNegrita = FontFactory.GetFont("Segoe UI", 9.5f, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                iTextSharp.text.Font fuenteDestacado = FontFactory.GetFont("Segoe UI", 11f, iTextSharp.text.Font.BOLD, new BaseColor(39, 174, 96));

                PdfPTable tablaEncabezado = new PdfPTable(2);
                tablaEncabezado.WidthPercentage = 100f;
                tablaEncabezado.SetWidths(new float[] { 55f, 45f });

                PdfPCell celdaMarca = new PdfPCell();
                celdaMarca.Border = iTextSharp.text.Rectangle.NO_BORDER;
                celdaMarca.AddElement(new Paragraph("BOOKLY", fuenteEmpresa));
                celdaMarca.AddElement(new Paragraph("Libros que te acompañan - Sistema de Gestión Bibliográfica", fuenteLema));
                tablaEncabezado.AddCell(celdaMarca);

                PdfPCell celdaDocInfo = new PdfPCell();
                celdaDocInfo.Border = iTextSharp.text.Rectangle.NO_BORDER;
                celdaDocInfo.HorizontalAlignment = Element.ALIGN_RIGHT;
                Paragraph pRef = new Paragraph("PROPUESTA ESTRATÉGICA VIP", fuenteTituloDoc);
                pRef.Alignment = Element.ALIGN_RIGHT;
                Paragraph pFecha = new Paragraph($"Fecha de Emisión: {DateTime.Now:dd/MM/yyyy}\nCódigo: {codigoPropuesta}", fuenteSub);
                pFecha.Alignment = Element.ALIGN_RIGHT;
                celdaDocInfo.AddElement(pRef);
                celdaDocInfo.AddElement(pFecha);
                tablaEncabezado.AddCell(celdaDocInfo);

                doc.Add(tablaEncabezado);

                Paragraph separador = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(1f, 100f, new BaseColor(210, 180, 140), Element.ALIGN_CENTER, -1)));
                separador.SpacingBefore = 8f;
                separador.SpacingAfter = 12f;
                doc.Add(separador);

                doc.Add(new Paragraph("DESTINATARIO PREFERENCIAL (PROGRAMA CLIENTES VIP)", fuenteSeccion));
                PdfPTable tablaCliente = new PdfPTable(2);
                tablaCliente.WidthPercentage = 100f;
                tablaCliente.SpacingBefore = 5f;
                tablaCliente.SpacingAfter = 12f;
                tablaCliente.SetWidths(new float[] { 50f, 50f });

                PdfPCell cCliente1 = new PdfPCell(new Phrase($"Titular: {cliente.NombreCompleto}\nDNI: {cliente.DNI}\nEmail: {cliente.Email}", fuenteTexto))
                {
                    Border = iTextSharp.text.Rectangle.BOX,
                    BorderColor = new BaseColor(210, 180, 140),
                    Padding = 7f,
                    BackgroundColor = new BaseColor(253, 248, 242)
                };
                PdfPCell cCliente2 = new PdfPCell(new Phrase($"Historial Comercial: {cliente.Afinidad}\nCalificación de Crédito: {cliente.EstadoCalificacion}\nTeléfono: {cliente.Telefono}", fuenteTexto))
                {
                    Border = iTextSharp.text.Rectangle.BOX,
                    BorderColor = new BaseColor(210, 180, 140),
                    Padding = 7f,
                    BackgroundColor = new BaseColor(253, 248, 242)
                };
                tablaCliente.AddCell(cCliente1);
                tablaCliente.AddCell(cCliente2);
                doc.Add(tablaCliente);

                Paragraph carta = new Paragraph();
                carta.Font = fuenteTexto;
                carta.SpacingAfter = 14f;
                carta.Add(new Chunk($"Estimado/a {cliente.NombreCompleto}:\n\n", fuenteNegrita));
                carta.Add("Nos comunicamos directamente desde la Dirección Comercial de Bookly. En atención a su excelente trayectoria de preferencia, y valorando especialmente su condición de cliente intachable en cumplimiento, nuestra administración ha resuelto distinguir su perfil otorgándole un beneficio de compra preferencial.\n\n" +
                          "En base a su afinidad de lectura, hemos reservado para usted una oportunidad exclusiva sobre el siguiente título selecto de nuestro catálogo con una bonificación única de liquidación anticipada:");
                doc.Add(carta);

                doc.Add(new Paragraph("DETALLE DE LA OBRA Y CONDICIONES COMERCIALES", fuenteSeccion));
                PdfPTable tablaLibro = new PdfPTable(4);
                tablaLibro.WidthPercentage = 100f;
                tablaLibro.SpacingBefore = 5f;
                tablaLibro.SpacingAfter = 15f;
                tablaLibro.SetWidths(new float[] { 45f, 20f, 15f, 20f });

                PdfPCell h1 = new PdfPCell(new Phrase("Título y Autor", fuenteNegrita)) { BackgroundColor = new BaseColor(240, 230, 220), Padding = 6f };
                PdfPCell h2 = new PdfPCell(new Phrase("Precio Regular", fuenteNegrita)) { BackgroundColor = new BaseColor(240, 230, 220), Padding = 6f, HorizontalAlignment = Element.ALIGN_RIGHT };
                PdfPCell h3 = new PdfPCell(new Phrase("Descuento VIP", fuenteNegrita)) { BackgroundColor = new BaseColor(240, 230, 220), Padding = 6f, HorizontalAlignment = Element.ALIGN_CENTER };
                PdfPCell h4 = new PdfPCell(new Phrase("Precio Final Oferta", fuenteNegrita)) { BackgroundColor = new BaseColor(240, 230, 220), Padding = 6f, HorizontalAlignment = Element.ALIGN_RIGHT };

                tablaLibro.AddCell(h1);
                tablaLibro.AddCell(h2);
                tablaLibro.AddCell(h3);
                tablaLibro.AddCell(h4);

                PdfPCell d1 = new PdfPCell(new Phrase($"'{libro.Titulo}'\nAutor: {libro.Autor} | Editorial: {libro.Editorial}\nISBN: {libro.ISBN}", fuenteTexto)) { Padding = 7f };
                PdfPCell d2 = new PdfPCell(new Phrase($"$ {libro.Precio:N2}", fuenteTexto)) { Padding = 7f, HorizontalAlignment = Element.ALIGN_RIGHT };
                PdfPCell d3 = new PdfPCell(new Phrase($"{porcentajeDescuento:N0}% OFF", fuenteDestacado)) { Padding = 7f, HorizontalAlignment = Element.ALIGN_CENTER };
                PdfPCell d4 = new PdfPCell(new Phrase($"$ {precioFinal:N2}", fuenteDestacado)) { Padding = 7f, HorizontalAlignment = Element.ALIGN_RIGHT };

                tablaLibro.AddCell(d1);
                tablaLibro.AddCell(d2);
                tablaLibro.AddCell(d3);
                tablaLibro.AddCell(d4);

                PdfPCell celdaAhorro = new PdfPCell(new Phrase($"AHORRO EXCLUSIVO PARA EL CLIENTE: $ {montoDescuento:N2}", fuenteDestacado));
                celdaAhorro.Colspan = 4;
                celdaAhorro.HorizontalAlignment = Element.ALIGN_RIGHT;
                celdaAhorro.Padding = 7f;
                celdaAhorro.BackgroundColor = new BaseColor(235, 247, 238);
                tablaLibro.AddCell(celdaAhorro);

                doc.Add(tablaLibro);

                doc.Add(new Paragraph("TÉRMINOS Y CONDICIONES DE LA PROPUESTA", fuenteSeccion));
                Paragraph terminos = new Paragraph();
                terminos.Font = fuenteSub;
                terminos.SpacingBefore = 4f;
                terminos.SpacingAfter = 25f;
                terminos.Add("1. Validez temporal: La presente bonificación tiene vigencia exclusiva por 15 días corridos a partir de su emisión.\n" +
                             "2. Modalidad de canje: Para hacer efectivo este beneficio, presente esta propuesta impresa o mencione su código de validación al momento de abonar en caja.\n" +
                             "3. Carácter intransferible: El descuento es personal y exclusivo para el titular registrado en el sistema.\n" +
                             "4. Canales habilitados: Válido para compras en mostrador central y envíos coordinados.");
                doc.Add(terminos);

                PdfPTable tablaFirma = new PdfPTable(2);
                tablaFirma.WidthPercentage = 100f;
                tablaFirma.SetWidths(new float[] { 50f, 50f });

                PdfPCell celdaSello = new PdfPCell(new Phrase($"Código Verificador de Seguridad:\n{codigoPropuesta}\nFirma Digital: EVERGLOW-SEC-OK", fuenteSub));
                celdaSello.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tablaFirma.AddCell(celdaSello);

                PdfPCell celdaFirma = new PdfPCell();
                celdaFirma.Border = iTextSharp.text.Rectangle.NO_BORDER;
                celdaFirma.HorizontalAlignment = Element.ALIGN_RIGHT;
                Paragraph pFirma = new Paragraph("_____________________________________\nDepartamento de Estrategia Comercial\nBookly - Libros que te acompañan", fuenteSub);
                pFirma.Alignment = Element.ALIGN_RIGHT;
                celdaFirma.AddElement(pFirma);
                tablaFirma.AddCell(celdaFirma);

                doc.Add(tablaFirma);

                doc.Close();
            }

            return rutaDestino;
        }

        private List<string> GenerarRecomendacionesInteligentes(BEReporteInteligente reporte, List<(string Titulo, string Autor, decimal Precio, int ExistenciasVenta, int ExistenciasPrestamo, int TotalMovimientos)> libros)
        {
            List<string> sugerencias = new List<string>();

            if (reporte.PrediccionLibrosProximoMes.Count > 0)
            {
                var topPred = reporte.PrediccionLibrosProximoMes[0];
                sugerencias.Add($"• Pronóstico Predictivo Futuro (Próximo Mes): Se proyecta que '{topPred.Etiqueta}' registrará la mayor demanda con una estimación de {topPred.Cantidad} ejemplares vendidos (facturación estimada: ${topPred.TotalRecaudado:N2}). Se sugiere gestionar la compra anticipada para asegurar disponibilidad.");
            }

            if (reporte.VentasPorEditorial.Count > 0)
            {
                var topEditorial = reporte.VentasPorEditorial[0];
                sugerencias.Add($"• Abastecimiento: La editorial '{topEditorial.Etiqueta}' lidera el volumen comercial ({topEditorial.Porcentaje}% del total con ${topEditorial.TotalRecaudado:N2} recaudados). Se aconseja consolidar pedidos mayoristas y solicitar bonificaciones por volumen.");
            }

            if (reporte.DemandaPorAutor.Count > 0)
            {
                var topAutor = reporte.DemandaPorAutor[0];
                sugerencias.Add($"• Impulso Comercial: Las obras de '{topAutor.Etiqueta}' concentran la mayor preferencia de los usuarios con {topAutor.Cantidad} ejemplares operados ({topAutor.Porcentaje}% del público). Se recomienda darles visibilidad destacada en vidrieras y catálogo inicial.");
            }

            if (reporte.TotalPrestamosRealizados > 0)
            {
                decimal tasaMora = Math.Round(((decimal)reporte.TotalPrestamosConMora / reporte.TotalPrestamosRealizados) * 100m, 1);
                if (tasaMora > 15m)
                {
                    sugerencias.Add($"• Control de Morosidad: El {tasaMora}% de los préstamos registra retrasos en su restitución pactada (${reporte.MontoTotalRecargosMora:N2} percibidos en penalizaciones). Se recomienda implementar recordatorios automáticos 48hs antes del vencimiento.");
                }
                else
                {
                    sugerencias.Add($"• Cumplimiento del Catálogo: La tasa de restitución en término es del {(100m - tasaMora):N1}%, reflejando alta fidelidad y bajo riesgo operativo en el servicio de préstamo.");
                }
            }

            var librosCriticos = libros.Where(l => l.TotalMovimientos > 0 && l.ExistenciasVenta <= 2).Take(2).ToList();
            foreach (var lib in librosCriticos)
            {
                sugerencias.Add($"• Alerta de Reposición: El título '{lib.Titulo}' ({lib.Autor}) registra alta rotación ({lib.TotalMovimientos} operaciones) y su existencia en mostrador es crítica ({lib.ExistenciasVenta} disponibles). Se sugiere emitir orden de compra inmediata para evitar pérdida de ventas.");
            }

            if (sugerencias.Count == 0)
            {
                sugerencias.Add("• Monitoreo Operativo: A medida que se registren nuevas transacciones en el rango de fechas seleccionado, el motor predictivo consolidará indicadores de rotación y tendencias de catálogo.");
            }

            return sugerencias;
        }
    }
}
