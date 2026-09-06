using System;
using System.Collections.Generic;

namespace Servicios
{
    public interface IDALPerfil
    {
        List<ServicioPerfil> ObtenerPerfiles();
        ServicioPerfil ObtenerPerfilUsuario(int idPerfilUsuario);
        int GuardarPerfil(ServicioPerfil perfil);
        void GuardarRelacionesPerfil(int idPerfilPadre, List<ServicioPerfil> hijos, List<string> dvhsRelaciones);
        bool PerfilEstaAsignadoAUsuario(int idPerfil);
        void EliminarPerfil(int idPerfil);
        List<int> ObtenerPerfilesQueQuedarianVaciosPorFamilia(int idFamiliaAEliminar);
        void AgregarRelacionPerfilPermiso(int idPerfilPadre, ServicioPerfil hijo, string dvhRelacion);
        void QuitarRelacionPerfilPermiso(int idPerfilPadre, ServicioPerfil hijo);
        int ObtenerCantidadHijosPerfil(int idPerfil);
        void AgregarRelacionPerfilFamilia(int idPerfilPadre, ServicioFamilia hijo, string dvhRelacion);
        void QuitarRelacionPerfilFamilia(int idPerfilPadre, ServicioFamilia hijo);
        List<ServicioPerfilPermiso> ObtenerRelacionesPerfilPermiso();
        List<ServicioPerfilFamilia> ObtenerRelacionesPerfilFamilia();
        void ActualizarDVHPerfil(int idPerfil, string dvh);
        void ActualizarDVHPerfilPermiso(int idPerfil, int idPermiso, string dvh);
        void ActualizarDVHPerfilFamilia(int idPerfil, int idFamilia, string dvh);
    }
}
