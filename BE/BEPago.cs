using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEPago
    {
        public int IdPago { get; set; }
        public int IdVenta { get; set; }
        public string MedioPago { get; set; } 
        public decimal Importe { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string DVH { get; set; }
    }
}
