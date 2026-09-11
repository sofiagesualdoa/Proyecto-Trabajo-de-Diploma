using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEFactura
    {
        public int IdFactura { get; set; }
        public int IdVenta { get; set; }
        public int DNICliente { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Today;
        public TimeSpan Hora { get; set; } = DateTime.Now.TimeOfDay;
        public decimal Total { get; set; }
        public string NumeroFactura { get; set; }
        public string DVH { get; set; }
    }
}
