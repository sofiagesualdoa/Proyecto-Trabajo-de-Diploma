using BE;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLEntidadBancaria
    {
        public bool ProcesarPago(BETarjeta tarjeta, decimal importe)
        {
            bool res = false;
            var s = ServicioSessionManager.GetInstance();
            if (tarjeta == null)
                throw new Exception(s.Traducir("Debe ingresar los datos de la tarjeta."));
            if (string.IsNullOrWhiteSpace(tarjeta.Numero) || tarjeta.Numero.Replace(" ", "").Length < 16)
                throw new Exception(s.Traducir("El número de tarjeta debe tener 16 dígitos."));
            if (string.IsNullOrWhiteSpace(tarjeta.CVV) || tarjeta.CVV.Length < 3)
                throw new Exception(s.Traducir("El código de seguridad (CVV) es inválido."));
            if (string.IsNullOrWhiteSpace(tarjeta.Titular))
                throw new Exception(s.Traducir("Debe ingresar el nombre del titular de la tarjeta."));
            if (!tarjeta.Numero.EndsWith("0000"))
            {
                res = true;
            }
            return res;
        }
    }
}
