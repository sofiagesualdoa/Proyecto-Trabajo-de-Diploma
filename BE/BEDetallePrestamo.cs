using System;

namespace BE
{
    public class BEDetallePrestamo
    {
        public int IdPrestamo { get; set; }
        public string ISBN { get; set; }
        public string Título { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }
        public string Cliente { get; set; }
        public int DNICliente { get; set; }
        public string Teléfono { get; set; }
        public string Email { get; set; }
        public decimal MontoPrestamo { get; set; }
        public decimal MontoRecargo { get; set; }
        public decimal Total => MontoPrestamo + MontoRecargo;
    }
}
