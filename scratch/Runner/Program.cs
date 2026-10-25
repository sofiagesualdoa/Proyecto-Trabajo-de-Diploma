using System;
using System.Linq;
using BE;
using BLL;
using Servicios;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== PRUEBA DE HISTORIAL DE PRESTAMOS ===");

            var dalUsuario = FabricaDAL.Crear<IDALUsuario>("DALUsuario");
            var usuario = dalUsuario.ObtenerUsuarios().FirstOrDefault(u => u.Activo && !u.Bloqueado);
            ServicioSessionManager.GetInstance().IniciarSesion(usuario);

            BLLPrestamo bllPrestamo = new BLLPrestamo();
            ServicioDVV srv = new ServicioDVV();

            var prestamos = bllPrestamo.ObtenerTodosLosPrestamos();
            Console.WriteLine($"Total de préstamos recuperados: {prestamos.Count}");

            foreach (var p in prestamos)
            {
                Console.WriteLine($"ID: {p.IdPrestamo} | DNI: {p.DNI} | ISBN: {p.ISBN} | Estado: {p.Estado} | Factura: {p.NumeroFactura} | Monto: ${p.MontoPrestamo} | Recargo: ${p.MontoRecargo}");
                var detalles = bllPrestamo.ObtenerDetallesPorPrestamo(p);
                foreach (var d in detalles)
                {
                    Console.WriteLine($"   -> Detalle: Libro='{d.Título}' por {d.Autor} (Editorial: {d.Editorial}) | Cliente={d.Cliente} (Tel: {d.Teléfono}, Email: {d.Email}) | Total=${d.Total}");
                }
            }

            if (prestamos.Count > 0)
            {
                var primerPrestamo = prestamos.First();
                var filtradosDni = bllPrestamo.FiltrarPrestamos(null, null, primerPrestamo.DNI);
                Console.WriteLine($"Filtro por DNI {primerPrestamo.DNI}: {filtradosDni.Count} encontrados.");

                var filtradosFecha = bllPrestamo.FiltrarPrestamos(primerPrestamo.FechaInicio.AddDays(-1), primerPrestamo.FechaInicio.AddDays(1), null);
                Console.WriteLine($"Filtro por fecha: {filtradosFecha.Count} encontrados.");
            }

            var errores = srv.ObtenerErroresIntegridad();
            Console.WriteLine($"Errores de integridad del sistema: {errores.Count}");
            foreach (var err in errores)
            {
                Console.WriteLine($"Error integridad: {err.Tabla} - {err.TipoError} (Esperado: {err.ValorEsperado}, Actual: {err.ValorActual})");
            }
        }
    }
}
