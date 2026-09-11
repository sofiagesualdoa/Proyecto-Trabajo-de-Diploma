using BE;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLCarrito
    {
        private BECarrito carritoActual;
        private BLLLibro bllLibro;
        
        public BLLCarrito()
        {
            carritoActual = new BECarrito();
            bllLibro = new BLLLibro();
        }
        public bool TieneClienteAsociado => carritoActual.DNICliente > 0;
        public int ObtenerDNICliente() => carritoActual.DNICliente;
        public void AsociarDNI(int dni)
        {
            var session = ServicioSessionManager.GetInstance();
            if (carritoActual.DNICliente > 0 && carritoActual.DNICliente != dni)
            {
                throw new InvalidOperationException(session.Traducir("El carrito ya posee un cliente asociado y no se puede modificar."));
            }
            carritoActual.DNICliente = dni;
        }
        public BECarrito ObtenerCarrito()
        {
            return carritoActual;
        }
        public List<BEDetalleCarrito> ObtenerDetalles()
        {
            return carritoActual.Detalles;
        }
        public decimal CalcularTotal()
        {
            return carritoActual.Total;
        }
        public void AgregarLibro(BELibro libro, int cantidad)
        {
            var session = ServicioSessionManager.GetInstance();
            if (libro == null)
                throw new Exception(session.Traducir("Debe seleccionar un libro del catálogo para agregarlo al carrito."));
            if (cantidad <= 0)
                throw new Exception(session.Traducir("La cantidad debe ser numérica y mayor a cero."));
            int stockDisponible = bllLibro.VerificarUnidades(libro);
            int cantidadEnCarrito = carritoActual.Detalles
                .Where(d => d.ISBN == libro.ISBN_657SGA)
                .Sum(d => d.Cantidad);
            if ((cantidadEnCarrito + cantidad) > stockDisponible)
            {
                string plantilla = session.Traducir("Stock insuficiente. Solo quedan {0} unidades disponibles.");
                throw new Exception(string.Format(plantilla, stockDisponible));
            }
            var detalleExistente = carritoActual.Detalles.FirstOrDefault(d => d.ISBN == libro.ISBN_657SGA);
            if (detalleExistente != null)
            {
                IncrementarCantidad(libro, cantidad);
            }
            else
            {
                RegistrarLibro(libro, cantidad);
            }
        }

        public void IncrementarCantidad(BELibro libro, int cantidad)
        {
            var detalle = carritoActual.Detalles.FirstOrDefault(d => d.ISBN == libro.ISBN_657SGA);
            if (detalle != null)
            {
                detalle.Cantidad += cantidad;
            }
        }

        public void RegistrarLibro(BELibro libro, int cantidad)
        {
            carritoActual.Detalles.Add(new BEDetalleCarrito
            {
                IdCarrito = carritoActual.IdCarrito,
                ISBN = libro.ISBN_657SGA,
                Cantidad = cantidad,
                Libro = libro
            });
        }
        public void VaciarCarrito()
        {
            var session = ServicioSessionManager.GetInstance();
            if (carritoActual.Detalles.Count == 0)
            {
                throw new Exception(session.Traducir("El carrito ya está vacío."));
            }
            carritoActual.Detalles.Clear();
        }
    }
}
