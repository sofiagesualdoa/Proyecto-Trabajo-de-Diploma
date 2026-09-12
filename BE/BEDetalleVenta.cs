using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEDetalleVenta
    {
        public int IdDetalleVenta { get; set; }
        public int IdVenta { get; set; }
        public int IdCarrito { get; set; }
        public string ISBN { get; set; }
        public int Cantidad { get; set; }
        public string DVH { get; set; }
        public BELibro Libro { get; set; }
        public string Título => Libro?.Título_657SGA;
        public string Autor => Libro?.Autor_657SGA;
        private decimal _precioUnitario;
        public decimal PrecioUnitario
        {
            get => _precioUnitario > 0 ? _precioUnitario : (Libro != null ? Libro.Precio_657SGA : 0m);
            set => _precioUnitario = value;
        }

        private decimal _subtotal;
        public decimal Subtotal
        {
            get => _subtotal > 0 ? _subtotal : (Cantidad * PrecioUnitario);
            set => _subtotal = value;
        }
    }
}