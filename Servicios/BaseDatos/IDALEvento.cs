using System;
using System.Collections.Generic;

namespace Servicios
{
    public interface IDALEvento
    {
        void RegistrarEvento(ServicioEvento registro);
        List<ServicioEvento> ObtenerEventos(DateTime fechaDesde);
        List<ServicioEvento> ObtenerTodosLosEventos();
        void ActualizarDVHEvento(int idEvento, string dvh);
    }
}
