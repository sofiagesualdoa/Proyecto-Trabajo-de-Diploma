using BE;
using System;
using System.Collections.Generic;

namespace Servicios
{
    public interface IDALDVV
    {
        List<ServicioDVV> ObtenerDVV();
        void GuardarDVV(ServicioDVV dvv);
        List<BELibro> ObtenerLibros();
        void ActualizarDVHLibro(string isbn, string dvh);
    }
}
