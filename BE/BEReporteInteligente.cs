using System;
using System.Collections.Generic;

namespace BE
{
    public class BEItemEstadistico
    {
        public string Etiqueta { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public decimal TotalRecaudado { get; set; }
        public decimal Porcentaje { get; set; }
    }

    public class BEReporteInteligente
    {
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public int TotalVentasRealizadas { get; set; }
        public int TotalEjemplaresVendidos { get; set; }
        public decimal MontoTotalVentas { get; set; }
        public int TotalPrestamosRealizados { get; set; }
        public int TotalPrestamosFinalizados { get; set; }
        public int TotalPrestamosConMora { get; set; }
        public decimal MontoTotalPrestamos { get; set; }
        public decimal MontoTotalRecargosMora { get; set; }
        public decimal IngresosTotales => MontoTotalVentas + MontoTotalPrestamos + MontoTotalRecargosMora;

        public List<BEItemEstadistico> VentasPorEditorial { get; set; } = new List<BEItemEstadistico>();
        public List<BEItemEstadistico> DemandaPorAutor { get; set; } = new List<BEItemEstadistico>();
        public List<BEItemEstadistico> ComparativaVentasVsPrestamos { get; set; } = new List<BEItemEstadistico>();
        public List<string> Recomendaciones { get; set; } = new List<string>();
    }
}
