using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEDetalleFactura
    {
        public int IdDetalleFactura { get; set; }
        public int IdFactura { get; set; }
        public string ISBN { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public string DVH { get; set; }
    }
}
