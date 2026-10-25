using BE;
using System.Collections.Generic;

namespace Servicios
{
    public interface IDALPrestamo
    {
        List<BEPrestamo> ObtenerTodosLosPrestamos();
        void ActualizarDVHPrestamo(int idPrestamo, string dvh);
    }
}
