using BE;
using DAL;
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
        private DALVenta dalVenta = new DALVenta();
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
                Cliente = cliente,
                Fecha = DateTime.Today,
                Hora = DateTime.Now.TimeOfDay
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
            dalVenta.GuardarVenta(venta, factura, carrito.Detalles);
            bitacora.GrabarBitacora($"Venta realizada. Factura: {factura.NumeroFactura}", "Venta", 1);
            return factura;
        }

        public List<BEVenta> ObtenerVentas()
        {
            return dalVenta.ObtenerVentas();
        }

        public List<BEDetalleVenta> ObtenerDetallesPorVenta(int idVenta)
        {
            return dalVenta.ObtenerDetallesPorVenta(idVenta);
        }

        public BEFactura BuscarFacturaPorVenta(int idVenta)
        {
            return dalVenta.BuscarFacturaPorVenta(idVenta);
        }

        public List<BEVenta> FiltrarVentas(DateTime? fechaDesde, DateTime? fechaHasta, int? dniCliente)
        {
            var ventas = ObtenerVentas();
            if (fechaDesde.HasValue)
            {
                ventas = ventas.Where(v => v.Fecha.Date >= fechaDesde.Value.Date).ToList();
            }
            if (fechaHasta.HasValue)
            {
                ventas = ventas.Where(v => v.Fecha.Date <= fechaHasta.Value.Date).ToList();
            }
            if (dniCliente.HasValue && dniCliente.Value > 0)
            {
                ventas = ventas.Where(v => v.DNICliente.ToString().Contains(dniCliente.Value.ToString())).ToList();
            }
            return ventas;
        }
    }
}
