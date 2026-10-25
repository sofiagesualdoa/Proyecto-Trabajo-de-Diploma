using BE;
using System.Collections.Generic;

namespace Servicios
{
    public interface IDALLibro
    {
        List<BELibro> ObtenerLibros();
        void ActualizarDVHLibro(string isbn, string dvh);
    }
}
