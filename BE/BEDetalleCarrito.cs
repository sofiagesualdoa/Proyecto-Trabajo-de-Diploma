using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEDetalleCarrito
    {
        public int IdCarrito { get; set; }
        public string ISBN { get; set; }
        public int Cantidad { get; set; }
        public string DVH { get; set; }
        public BELibro Libro { get; set; }
        public string Título => Libro?.Título_657SGA;
        public string Autor => Libro?.Autor_657SGA;
        public decimal PrecioUnitario => Libro != null ? Libro.Precio_657SGA : 0m;
        public decimal Subtotal => Cantidad * PrecioUnitario;
    }
}
