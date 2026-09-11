using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BETarjeta
    {
        public string Tipo { get; set; } 
        public string Banco { get; set; }
        public string Numero { get; set; }
        public string Titular { get; set; }
        public string Vencimiento { get; set; } 
        public string CVV { get; set; }
    }
}
