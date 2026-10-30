using System;
using System.Collections.Generic;
using BE;
using BLL;
using Servicios;

namespace scratch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServicioDVV servicioDVV = new ServicioDVV();
            var errores = servicioDVV.ObtenerErroresIntegridad();
            Console.WriteLine($"Errores de Integridad DVV: {errores.Count}");
            foreach (var err in errores)
            {
                Console.WriteLine($"Error: {err.Tabla} - {err.TipoError} - {err.Registro}");
            }

            BEFactura facRecargo = new BEFactura
            {
                IdFactura = 9999,
                NumeroFactura = "FC-R-2026-1234",
                Fecha = DateTime.Today,
                Hora = DateTime.Now.TimeOfDay,
                Total = 3000m,
                DNICliente = 46956657
            };

            BECliente cliente = new BECliente
            {
                DNI_657SGA = 46956657,
                Nombre_657SGA = "Sofía",
                Apellido_657SGA = "Gesualdo",
                Email_657SGA = "sofia@bookly.com",
                Teléfono_657SGA = 1123456789,
                Dirección_657SGA = "Av. Corrientes 1234"
            };

            List<BEDetalleVenta> detalles = new List<BEDetalleVenta>
            {
                new BEDetalleVenta
                {
                    ISBN = "9789877382761",
                    Cantidad = 1,
                    PrecioUnitario = 3000m,
                    Subtotal = 3000m,
                    Libro = new BELibro
                    {
                        ISBN_657SGA = "9789877382761",
                        Título_657SGA = "Recargo por Devolución Tardía - Rayuela",
                        Autor_657SGA = "Julio Cortázar"
                    }
                }
            };

            BEPago pago = new BEPago
            {
                MedioPago = "Tarjeta de Crédito",
                Importe = 3000m
            };

            string rutaPrueba = "test_factura_recargo.pdf";
            BLLFactura bllFactura = new BLLFactura();
            bllFactura.GenerarFacturaPDF(facRecargo, cliente, detalles, pago, rutaPrueba);

            if (System.IO.File.Exists(rutaPrueba))
            {
                Console.WriteLine($"PDF generado con éxito. Tamaño: {new System.IO.FileInfo(rutaPrueba).Length} bytes");
                System.IO.File.Delete(rutaPrueba);
            }
        }
    }
}
