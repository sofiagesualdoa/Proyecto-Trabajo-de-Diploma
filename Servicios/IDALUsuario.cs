using System;
using System.Collections.Generic;

namespace Servicios
{
    public interface IDALUsuario
    {
        ServicioUsuario ObtenerUsuario(string nombreUsuario);
        List<ServicioUsuario> ObtenerUsuarios();
        void GuardarUsuario(ServicioUsuario usuario);
        ServicioUsuario BuscarUsuarioPorDniOMail(int dni, string email);
        void DesbloquearUsuario(int dni, string dvh);
        void BloquearUsuario(int dni, string dvh);
        void ModificarUsuario(ServicioUsuario usuarioModificado);
        bool ModificarEstado(int DNIUsuario, string dvh);
        void GuardarNuevaClave(string nombreUsuario, string hashClaveNueva, string dvh);
        void SumarIntentoFallido(string nombreUsuario, string dvh);
        void ActualizarIdiomaUsuario(int dni, int idIdioma, string dvh);
        void ActualizarDVHUsuario(int dni, string dvh);
    }
}
