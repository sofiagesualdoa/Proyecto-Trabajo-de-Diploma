using BE;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLVenta
    {
        private BLLLibro bllLibro = new BLLLibro();
        private ServicioEvento bitacora = new ServicioEvento();
        public BEFactura ConcretarVenta(BECarrito carrito, BECliente cliente, BEPago pago)
        {
            var s = ServicioSessionManager.GetInstance();
            if (carrito == null || carrito.Detalles.Count == 0)
                throw new Exception(s.Traducir("El carrito se encuentra vacío."));
            BEVenta venta = new BEVenta
            {
                DNICliente = cliente.DNI_657SGA,
                Total = carrito.Total,
                Carrito = carrito,
                Cliente = cliente
            };
            foreach (var item in carrito.Detalles)
            {
                var libro = bllLibro.ObtenerLibros().Find(l => l.ISBN_657SGA == item.ISBN);
                if (libro != null)
                {
                    libro.Existencias_657SGA -= item.Cantidad;
                    bllLibro.ModificarLibro(libro, libro.ISBN_657SGA);
                }
            }
            Random rnd = new Random();
            BEFactura factura = new BEFactura
            {
                DNICliente = cliente.DNI_657SGA,
                Total = venta.Total,
                NumeroFactura = $"FC-B-{DateTime.Now.Year}-{rnd.Next(1000, 9999)}",
                Fecha = DateTime.Today,
                Hora = DateTime.Now.TimeOfDay
            };
            bitacora.GrabarBitacora($"Venta realizada. Factura: {factura.NumeroFactura}", "Venta", 1);
            return factura;
        }
    }
}
