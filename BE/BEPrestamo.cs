using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEPrestamo
    {
        public int IdPrestamo { get; set; }
        public int DNI { get; set; }
        public string ISBN { get; set; }
        public int? IdFactura { get; set; }
        public DateTime FechaInicio { get; set; } = DateTime.Today;
        public DateTime FechaDevolucion { get; set; }
        public DateTime? FechaRealDevolucion { get; set; }
        public string Estado { get; set; }
        public decimal MontoPrestamo { get; set; }
        public decimal MontoRecargo { get; set; }
        public string DVH { get; set; }
        public string NumeroFactura { get; set; }
    }
}
