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

    public class BELibroSobrestock
    {
        public string ISBN { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public string Editorial { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int StockAlmacen { get; set; }
        public int UnidadesVendidas { get; set; }
        public decimal CapitalInmovilizado => StockAlmacen * Precio;
        public string NivelPrioridad { get; set; } = string.Empty;
    }

    public class BEClienteVIP
    {
        public int DNI { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public int ComprasPrevias { get; set; }
        public decimal TotalGastado { get; set; }
        public string Afinidad { get; set; } = string.Empty;
        public bool TieneMora { get; set; }
        public string EstadoCalificacion { get; set; } = string.Empty;
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
        public List<BEItemEstadistico> PrediccionLibrosProximoMes { get; set; } = new List<BEItemEstadistico>();
        public List<string> Recomendaciones { get; set; } = new List<string>();
    }
}
