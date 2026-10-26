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
    public class BLLPrestamo
    {
        private readonly DALPrestamo dalPrestamo = new DALPrestamo();
        private readonly BLLLibro bllLibro = new BLLLibro();
        private readonly BLLCliente bllCliente = new BLLCliente();
        private readonly BLLFactura bllFactura = new BLLFactura();
        private readonly ServicioEvento bitacora = new ServicioEvento();
        private readonly GeneradorDigVerificador generador = new GeneradorDigVerificador();
        private readonly ServicioDVV servicioDVV = new ServicioDVV();

        public List<BELibro> BuscarLibrosParaPrestamo(string criterio)
        {
            return bllLibro.BuscarLibros(criterio).Where(l => l.Activo_657SGA && l.EsParaPrestamo && l.ExistenciasPrestamo > 0).ToList();
        }

        public void VerificarClienteHabilitado(int dni)
        {
            var session = ServicioSessionManager.GetInstance();
            BECliente cliente = bllCliente.BuscarClientePorDNI(dni);
            if (cliente == null || !cliente.Activo_657SGA)
            {
                throw new Exception(session.Traducir("El cliente especificado no existe o no se encuentra activo."));
            }
            BEPrestamo? activo = dalPrestamo.ObtenerPrestamoActivoPorDNI(dni);
            if (activo != null)
            {
                throw new Exception(session.Traducir("El cliente ya posee un préstamo activo vigente. No puede solicitar otro hasta devolver el ejemplar adeudado."));
            }
        }

        public decimal CalcularImporte(BELibro libro, int dias)
        {
            if (dias <= 0) dias = 1;

            int meses = dias / 30;
            int restoDiasMes = dias % 30;

            int semanas = restoDiasMes / 7;
            int diasSueltos = restoDiasMes % 7;

            decimal costoDiasSueltos = Math.Min(diasSueltos * 400m, 2000m);
            decimal costoSemanas = (semanas * 2000m) + costoDiasSueltos;
            decimal total = (meses * 7000m) + Math.Min(costoSemanas, 7000m);

            return total;
        }

        public BEPrestamo RegistrarSolicitudPrestamo(int dni, string isbn, DateTime fechaDevolucion, decimal monto)
        {
            var session = ServicioSessionManager.GetInstance();
            VerificarClienteHabilitado(dni);

            BELibro? libro = bllLibro.ObtenerLibros().FirstOrDefault(l => l.ISBN_657SGA == isbn && l.EsParaPrestamo);
            if (libro == null)
            {
                throw new Exception(session.Traducir("El libro especificado no se encuentra en el catálogo de préstamos."));
            }
            if (libro.ExistenciasPrestamo <= 0)
            {
                throw new Exception(session.Traducir("El ejemplar seleccionado no cuenta con disponibilidad para préstamo."));
            }
            if (fechaDevolucion.Date <= DateTime.Today)
            {
                throw new Exception(session.Traducir("La fecha de devolución pactada debe ser posterior al día de hoy."));
            }

            BEPrestamo prestamo = new BEPrestamo
            {
                DNI = dni,
                ISBN = isbn,
                IdFactura = null,
                FechaInicio = DateTime.Today,
                FechaDevolucion = fechaDevolucion.Date,
                FechaRealDevolucion = null,
                Estado = "Pendiente",
                MontoPrestamo = (decimal)(long)monto,
                MontoRecargo = 0m
            };
            int id = dalPrestamo.GuardarPrestamo(prestamo);
            prestamo.IdPrestamo = id;
            servicioDVV.RecalcularDVVPrestamo();
            return prestamo;
        }

        public BEFactura ConcretarPrestamo(BEPrestamo prestamo, BECliente cliente, BETarjeta tarjeta)
        {
            var session = ServicioSessionManager.GetInstance();
            if (prestamo == null)
                throw new Exception(session.Traducir("No hay ninguna solicitud de préstamo para cobrar."));

            bllFactura.RealizarPago(tarjeta, prestamo.MontoPrestamo);

            Random rnd = new Random();
            BEFactura factura = new BEFactura
            {
                DNICliente = cliente.DNI_657SGA,
                Total = prestamo.MontoPrestamo,
                NumeroFactura = $"FC-P-{DateTime.Now.Year}-{rnd.Next(1000, 9999)}",
                Fecha = DateTime.Today,
                Hora = DateTime.Now.TimeOfDay
            };

            int idFactura = dalPrestamo.GuardarFacturaPrestamo(factura, prestamo.ISBN, prestamo.MontoPrestamo);
            factura.IdFactura = idFactura;
            prestamo.IdFactura = idFactura;
            prestamo.Estado = "Activo";

            BEPrestamo prestamoParaDVH = new BEPrestamo
            {
                IdPrestamo = prestamo.IdPrestamo,
                DNI = prestamo.DNI,
                ISBN = prestamo.ISBN,
                IdFactura = idFactura,
                FechaInicio = prestamo.FechaInicio,
                FechaDevolucion = prestamo.FechaDevolucion,
                FechaRealDevolucion = prestamo.FechaRealDevolucion,
                Estado = "Activo",
                MontoPrestamo = (decimal)(long)prestamo.MontoPrestamo,
                MontoRecargo = (decimal)(long)prestamo.MontoRecargo
            };
            prestamo.DVH = generador.GenerarDVH(prestamoParaDVH);
            prestamo.IdFactura = idFactura;
            prestamo.Estado = "Activo";
            dalPrestamo.ActualizarPrestamoCobrado(prestamo.IdPrestamo, idFactura, prestamo.DVH);
            servicioDVV.RecalcularDVVPrestamo();

            BELibro? libro = bllLibro.ObtenerLibros().FirstOrDefault(l => l.ISBN_657SGA == prestamo.ISBN);
            if (libro != null)
            {
                libro.ExistenciasPrestamo = 0;
                bllLibro.ModificarLibro(libro, libro.ISBN_657SGA);
            }

            bitacora.GrabarBitacora($"Cobro Préstamo ID:{prestamo.IdPrestamo} FC:{factura.NumeroFactura}", "Préstamo", 1);
            return factura;
        }

        public BEPrestamo BuscarPrestamoActivo(int dni)
        {
            var session = ServicioSessionManager.GetInstance();
            BECliente cliente = bllCliente.BuscarClientePorDNI(dni);
            if (cliente == null)
            {
                throw new Exception(session.Traducir("El DNI ingresado no corresponde a ningún cliente registrado en el sistema."));
            }
            BEPrestamo? activo = dalPrestamo.ObtenerPrestamoActivoPorDNI(dni);
            if (activo == null)
            {
                throw new Exception(session.Traducir("El cliente no posee ningún préstamo activo pendiente de devolución."));
            }
            return activo;
        }

        public (int diasMora, decimal montoMora) CalcularMora(BEPrestamo prestamo)
        {
            if (prestamo == null) return (0, 0m);
            DateTime fechaHoy = DateTime.Today;
            DateTime fechaLimite = prestamo.FechaDevolucion.Date;
            if (fechaHoy > fechaLimite)
            {
                int dias = (fechaHoy - fechaLimite).Days;
                decimal monto = dias * 1000m;
                return (dias, monto);
            }
            return (0, 0m);
        }

        public BEFactura CobrarRecargo(BEPrestamo prestamo, BECliente cliente, BETarjeta tarjeta, decimal montoMora)
        {
            var session = ServicioSessionManager.GetInstance();
            if (prestamo == null || montoMora <= 0)
                throw new Exception(session.Traducir("No existe recargo por mora para cobrar en esta devolución."));

            bllFactura.RealizarPago(tarjeta, montoMora);

            Random rnd = new Random();
            BEFactura factura = new BEFactura
            {
                DNICliente = cliente.DNI_657SGA,
                Total = montoMora,
                NumeroFactura = $"FC-R-{DateTime.Now.Year}-{rnd.Next(1000, 9999)}",
                Fecha = DateTime.Today,
                Hora = DateTime.Now.TimeOfDay
            };

            int idFactura = dalPrestamo.GuardarFacturaPrestamo(factura, prestamo.ISBN, montoMora);
            factura.IdFactura = idFactura;
            prestamo.MontoRecargo = montoMora;

            bitacora.GrabarBitacora($"Cobro Mora ID:{prestamo.IdPrestamo} FC:{factura.NumeroFactura}", "Préstamo", 1);
            return factura;
        }

        public void RegistrarDevolucion(BEPrestamo prestamo, string rutaPdfDevolucion)
        {
            var session = ServicioSessionManager.GetInstance();
            if (prestamo == null)
                throw new Exception(session.Traducir("Debe seleccionar un préstamo válido para registrar la devolución."));

            prestamo.FechaRealDevolucion = DateTime.Today;
            if (prestamo.MontoRecargo > 0 || DateTime.Today > prestamo.FechaDevolucion.Date)
            {
                prestamo.Estado = "Finalizado con Mora";
            }
            else
            {
                prestamo.Estado = "Finalizado";
            }

            BEPrestamo prestamoParaDVH = new BEPrestamo
            {
                IdPrestamo = prestamo.IdPrestamo,
                DNI = prestamo.DNI,
                ISBN = prestamo.ISBN,
                IdFactura = prestamo.IdFactura,
                FechaInicio = prestamo.FechaInicio,
                FechaDevolucion = prestamo.FechaDevolucion,
                FechaRealDevolucion = prestamo.FechaRealDevolucion,
                Estado = prestamo.Estado,
                MontoPrestamo = (decimal)(long)prestamo.MontoPrestamo,
                MontoRecargo = (decimal)(long)prestamo.MontoRecargo
            };
            prestamo.DVH = generador.GenerarDVH(prestamoParaDVH);
            dalPrestamo.FinalizarPrestamo(prestamo);
            servicioDVV.RecalcularDVVPrestamo();

            BELibro? libro = bllLibro.ObtenerLibros().FirstOrDefault(l => l.ISBN_657SGA == prestamo.ISBN);
            if (libro != null)
            {
                libro.ExistenciasPrestamo = 1;
                bllLibro.ModificarLibro(libro, libro.ISBN_657SGA);
            }

            BECliente cliente = bllCliente.BuscarClientePorDNI(prestamo.DNI);

            if (!string.IsNullOrWhiteSpace(rutaPdfDevolucion))
            {
                GenerarComprobantePDF(prestamo, cliente, libro, rutaPdfDevolucion);
            }

            bitacora.GrabarBitacora($"Devolución Préstamo ID:{prestamo.IdPrestamo}", "Préstamo", 1);
        }

        public void GenerarComprobantePDF(BEPrestamo prestamo, BECliente cliente, BELibro? libro, string rutaArchivo)
        {
            Document documento = new Document(PageSize.A4, 36f, 36f, 40f, 40f);
            using (FileStream fs = new FileStream(rutaArchivo, FileMode.Create))
            {
                PdfWriter.GetInstance(documento, fs);
                documento.Open();

                iTextSharp.text.Font fuenteTitulo = FontFactory.GetFont("Segoe UI", 18f, iTextSharp.text.Font.BOLD, new BaseColor(45, 55, 72));
                iTextSharp.text.Font fuenteSubtitulo = FontFactory.GetFont("Segoe UI", 10f, iTextSharp.text.Font.ITALIC, BaseColor.DARK_GRAY);
                iTextSharp.text.Font fuenteSeccion = FontFactory.GetFont("Segoe UI", 12f, iTextSharp.text.Font.BOLD, new BaseColor(45, 55, 72));
                iTextSharp.text.Font fuenteNegrita = FontFactory.GetFont("Segoe UI", 9f, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                iTextSharp.text.Font fuenteTexto = FontFactory.GetFont("Segoe UI", 9f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                Paragraph titulo = new Paragraph("BOOKLY LIBROS", fuenteTitulo);
                titulo.Alignment = Element.ALIGN_CENTER;
                documento.Add(titulo);

                Paragraph subtitulo = new Paragraph("COMPROBANTE OFICIAL DE DEVOLUCIÓN DE PRÉSTAMO\n\n", fuenteSubtitulo);
                subtitulo.Alignment = Element.ALIGN_CENTER;
                documento.Add(subtitulo);

                PdfPTable tablaEncabezado = new PdfPTable(2);
                tablaEncabezado.WidthPercentage = 100f;
                tablaEncabezado.SetWidths(new float[] { 50f, 50f });

                PdfPCell celdaComp = new PdfPCell(new Phrase($"Comprobante N°: DEV-{prestamo.IdPrestamo:D6}\nFecha Emisión: {DateTime.Now:dd/MM/yyyy HH:mm:ss}\nEstado: {prestamo.Estado}", fuenteTexto));
                celdaComp.Border = iTextSharp.text.Rectangle.NO_BORDER;
                celdaComp.PaddingBottom = 10f;
                tablaEncabezado.AddCell(celdaComp);

                string numFactura = !string.IsNullOrWhiteSpace(prestamo.NumeroFactura) ? prestamo.NumeroFactura : (prestamo.IdFactura.HasValue ? $"FC-ID {prestamo.IdFactura.Value}" : "N/A");
                PdfPCell celdaFactura = new PdfPCell(new Phrase($"Préstamo ID: {prestamo.IdPrestamo}\nFactura Asociada: {numFactura}\nFecha Inicio: {prestamo.FechaInicio:dd/MM/yyyy}", fuenteTexto));
                celdaFactura.Border = iTextSharp.text.Rectangle.NO_BORDER;
                celdaFactura.HorizontalAlignment = Element.ALIGN_RIGHT;
                celdaFactura.PaddingBottom = 10f;
                tablaEncabezado.AddCell(celdaFactura);

                documento.Add(tablaEncabezado);

                documento.Add(new Paragraph("DATOS DEL CLIENTE", fuenteSeccion));
                PdfPTable tablaCliente = new PdfPTable(2);
                tablaCliente.WidthPercentage = 100f;
                tablaCliente.SetWidths(new float[] { 50f, 50f });
                tablaCliente.SpacingBefore = 4f;
                tablaCliente.SpacingAfter = 12f;

                string nombreCliente = cliente != null ? $"{cliente.Nombre_657SGA} {cliente.Apellido_657SGA}" : "Cliente General";
                string telefonoCliente = cliente != null ? cliente.Teléfono_657SGA.ToString() : "N/A";
                string emailCliente = cliente != null ? cliente.Email_657SGA : "N/A";

                tablaCliente.AddCell(new PdfPCell(new Phrase($"DNI: {prestamo.DNI}\nNombre: {nombreCliente}", fuenteTexto)) { Border = iTextSharp.text.Rectangle.BOX, Padding = 6f });
                tablaCliente.AddCell(new PdfPCell(new Phrase($"Teléfono: {telefonoCliente}\nEmail: {emailCliente}", fuenteTexto)) { Border = iTextSharp.text.Rectangle.BOX, Padding = 6f });
                documento.Add(tablaCliente);

                documento.Add(new Paragraph("DATOS DEL EJEMPLAR DEVUELTO", fuenteSeccion));
                PdfPTable tablaLibro = new PdfPTable(2);
                tablaLibro.WidthPercentage = 100f;
                tablaLibro.SetWidths(new float[] { 50f, 50f });
                tablaLibro.SpacingBefore = 4f;
                tablaLibro.SpacingAfter = 12f;

                string tituloLibro = libro != null ? libro.Título_657SGA : "Ejemplar Bookly";
                string autorLibro = libro != null ? libro.Autor_657SGA : "N/A";
                string editorialLibro = libro != null ? libro.Editorial_657SGA : "N/A";

                tablaLibro.AddCell(new PdfPCell(new Phrase($"ISBN: {prestamo.ISBN}\nTítulo: {tituloLibro}", fuenteTexto)) { Border = iTextSharp.text.Rectangle.BOX, Padding = 6f });
                tablaLibro.AddCell(new PdfPCell(new Phrase($"Autor: {autorLibro}\nEditorial: {editorialLibro}", fuenteTexto)) { Border = iTextSharp.text.Rectangle.BOX, Padding = 6f });
                documento.Add(tablaLibro);

                documento.Add(new Paragraph("DETALLE DEL PRÉSTAMO Y LIQUIDACIÓN", fuenteSeccion));
                PdfPTable tablaLiquidacion = new PdfPTable(2);
                tablaLiquidacion.WidthPercentage = 100f;
                tablaLiquidacion.SetWidths(new float[] { 70f, 30f });
                tablaLiquidacion.SpacingBefore = 4f;
                tablaLiquidacion.SpacingAfter = 15f;

                tablaLiquidacion.AddCell(new PdfPCell(new Phrase("Concepto", fuenteNegrita)) { BackgroundColor = new BaseColor(240, 240, 240), Padding = 6f });
                tablaLiquidacion.AddCell(new PdfPCell(new Phrase("Importe", fuenteNegrita)) { BackgroundColor = new BaseColor(240, 240, 240), HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6f });

                tablaLiquidacion.AddCell(new PdfPCell(new Phrase($"Alquiler pactado (Devolución prevista: {prestamo.FechaDevolucion:dd/MM/yyyy})", fuenteTexto)) { Padding = 5f });
                tablaLiquidacion.AddCell(new PdfPCell(new Phrase($"$ {prestamo.MontoPrestamo:N2}", fuenteTexto)) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 5f });

                string descMora = prestamo.MontoRecargo > 0
                    ? $"Recargo por mora (Devuelto el {prestamo.FechaRealDevolucion:dd/MM/yyyy})"
                    : "Recargo por mora (Devuelto en término)";
                tablaLiquidacion.AddCell(new PdfPCell(new Phrase(descMora, fuenteTexto)) { Padding = 5f });
                tablaLiquidacion.AddCell(new PdfPCell(new Phrase($"$ {prestamo.MontoRecargo:N2}", fuenteTexto)) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 5f });

                decimal granTotal = prestamo.MontoPrestamo + prestamo.MontoRecargo;
                tablaLiquidacion.AddCell(new PdfPCell(new Phrase("TOTAL CONTRATO Y PENALIDADES", fuenteNegrita)) { BackgroundColor = new BaseColor(245, 245, 245), Padding = 6f });
                tablaLiquidacion.AddCell(new PdfPCell(new Phrase($"$ {granTotal:N2}", fuenteNegrita)) { BackgroundColor = new BaseColor(245, 245, 245), HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 6f });

                documento.Add(tablaLiquidacion);

                Paragraph pie = new Paragraph("¡Muchas gracias por confiar en Bookly Libros!\nEl ejemplar ha sido devuelto satisfactoriamente al inventario de la tienda.", fuenteSubtitulo);
                pie.Alignment = Element.ALIGN_CENTER;
                documento.Add(pie);

                documento.Close();
            }
        }

        public List<BEPrestamo> ObtenerTodosLosPrestamos()
        {
            return dalPrestamo.ObtenerTodosLosPrestamos();
        }

        public List<BEPrestamo> FiltrarPrestamos(DateTime? fechaDesde, DateTime? fechaHasta, int? dniCliente)
        {
            var prestamos = ObtenerTodosLosPrestamos();
            if (fechaDesde.HasValue)
            {
                prestamos = prestamos.Where(p => p.FechaInicio.Date >= fechaDesde.Value.Date).ToList();
            }
            if (fechaHasta.HasValue)
            {
                prestamos = prestamos.Where(p => p.FechaInicio.Date <= fechaHasta.Value.Date).ToList();
            }
            if (dniCliente.HasValue && dniCliente.Value > 0)
            {
                prestamos = prestamos.Where(p => p.DNI.ToString().Contains(dniCliente.Value.ToString())).ToList();
            }
            return prestamos;
        }

        public List<BEDetallePrestamo> ObtenerDetallesPorPrestamo(BEPrestamo prestamo)
        {
            if (prestamo == null) return new List<BEDetallePrestamo>();

            BELibro? libro = bllLibro.ObtenerLibros().FirstOrDefault(l => l.ISBN_657SGA == prestamo.ISBN);
            BECliente? cliente = bllCliente.BuscarClientePorDNI(prestamo.DNI);

            BEDetallePrestamo detalle = new BEDetallePrestamo
            {
                IdPrestamo = prestamo.IdPrestamo,
                ISBN = prestamo.ISBN,
                Título = libro?.Título_657SGA ?? "N/A",
                Autor = libro?.Autor_657SGA ?? "N/A",
                Editorial = libro?.Editorial_657SGA ?? "N/A",
                Cliente = cliente != null ? $"{cliente.Nombre_657SGA} {cliente.Apellido_657SGA}" : "N/A",
                DNICliente = prestamo.DNI,
                Teléfono = cliente != null ? cliente.Teléfono_657SGA.ToString() : "N/A",
                Email = cliente?.Email_657SGA ?? "N/A",
                MontoPrestamo = prestamo.MontoPrestamo,
                MontoRecargo = prestamo.MontoRecargo
            };

            return new List<BEDetallePrestamo> { detalle };
        }

        public List<BEDetallePrestamo> ObtenerDetallesPorPrestamo(int idPrestamo)
        {
            BEPrestamo? p = dalPrestamo.ObtenerPrestamoPorId(idPrestamo);
            if (p == null) return new List<BEDetallePrestamo>();
            return ObtenerDetallesPorPrestamo(p);
        }
    }
}
