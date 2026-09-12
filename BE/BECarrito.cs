using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BECarrito
    {
        public int IdCarrito { get; set; }
        public int DNICliente { get; set; }
        public List<BEDetalleVenta> Detalles { get; set; }
        public string DVH { get; set; }
        public decimal Total => Detalles != null ? Detalles.Sum(d => d.Subtotal) : 0m;
        public BECarrito()
        {
            Detalles = new List<BEDetalleVenta>();
        }
    }
}
