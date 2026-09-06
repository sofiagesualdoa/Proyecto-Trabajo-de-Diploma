using System;
using System.Collections.Generic;

namespace Servicios
{
    public interface IDALIdioma
    {
        List<ServicioIdioma> ListarIdiomas();
        Dictionary<string, string> ObtenerTraducciones();
        void ActualizarDVHIdioma(int idIdioma, string dvh);
    }
}
