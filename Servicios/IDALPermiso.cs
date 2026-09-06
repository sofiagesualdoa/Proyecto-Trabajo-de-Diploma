using System;
using System.Collections.Generic;

namespace Servicios
{
    public interface IDALPermiso
    {
        List<ServicioPermiso> ObtenerTodos();
        void ActualizarDVHPermiso(int idPermiso, string dvh);
    }
}
