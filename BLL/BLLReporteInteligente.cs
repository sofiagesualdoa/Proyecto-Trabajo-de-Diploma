using BE;
using DAL;
using Servicios;
using System;
using System.Collections.Generic;
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

            reporte.Recomendaciones = GenerarRecomendacionesInteligentes(reporte, dalReporte.ObtenerMovimientosPorLibro(fechaDesde, fechaHasta));

            return reporte;
        }

        private List<string> GenerarRecomendacionesInteligentes(BEReporteInteligente reporte, List<(string Titulo, string Autor, int ExistenciasVenta, int ExistenciasPrestamo, int TotalMovimientos)> libros)
        {
            List<string> sugerencias = new List<string>();

            if (reporte.VentasPorEditorial.Count > 0)
            {
                var topEditorial = reporte.VentasPorEditorial[0];
                sugerencias.Add($"• Negociación de Abastecimiento: El sello '{topEditorial.Etiqueta}' lidera el volumen comercial ({topEditorial.Porcentaje}% del total con ${topEditorial.TotalRecaudado:N2} recaudados). Se aconseja consolidar pedidos mayoristas y solicitar bonificaciones por volumen.");
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
