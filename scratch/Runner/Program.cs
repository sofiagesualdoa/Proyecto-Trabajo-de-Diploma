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
            Console.WriteLine("=== ESTADO DEL SISTEMA Y PRESTAMOS ===");

            var dalUsuario = FabricaDAL.Crear<IDALUsuario>("DALUsuario");
            var usuario = dalUsuario.ObtenerUsuarios().FirstOrDefault(u => u.Activo && !u.Bloqueado);
            ServicioSessionManager.GetInstance().IniciarSesion(usuario);

            BLLPrestamo bllPrestamo = new BLLPrestamo();
            ServicioDVV srv = new ServicioDVV();

            var prestamos = bllPrestamo.ObtenerTodosLosPrestamos();
            Console.WriteLine($"Total de préstamos: {prestamos.Count}");

            foreach (var p in prestamos)
            {
                Console.WriteLine($"ID: {p.IdPrestamo} | DNI: {p.DNI} | ISBN: {p.ISBN} | Estado: {p.Estado} | Factura: {p.NumeroFactura} | Monto: ${p.MontoPrestamo} | Recargo: ${p.MontoRecargo}");
            }

            var errores = srv.ObtenerErroresIntegridad();
            Console.WriteLine($"Errores de integridad: {errores.Count}");
            foreach (var err in errores)
            {
                Console.WriteLine($"Error integridad: {err.Tabla} - {err.TipoError} (Esperado: {err.ValorEsperado}, Actual: {err.ValorActual})");
            }
        }
    }
}