using BE;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLPago
    {
        private BLLEntidadBancaria entidadBancaria = new BLLEntidadBancaria();
        public BEPago RealizarPago(BETarjeta tarjeta, decimal importe)
        {
            var s = ServicioSessionManager.GetInstance();
            bool aprobado = entidadBancaria.ProcesarPago(tarjeta, importe);
            if (!aprobado)
            {
                throw new Exception(s.Traducir("Operación rechazada por la entidad bancaria. Fondos insuficientes o tarjeta inválida."));
            }
            return new BEPago
            {
                MedioPago = $"Tarjeta {tarjeta.Tipo}",
                Importe = importe,
                Fecha = DateTime.Now
            };
        }
    }
}
