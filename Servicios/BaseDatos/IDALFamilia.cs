using System;
using System.Collections.Generic;

namespace Servicios
{
    public interface IDALFamilia
    {
        List<ServicioFamilia> ObtenerFamilias();
        int GuardarFamilia(ServicioFamilia familia);
        void GuardarRelacionesFamilia(int idFamiliaPadre, List<ServicioPerfil> hijos, List<string> dvhsRelaciones);
        void EliminarFamilia(int idFamilia);
        List<int> ObtenerFamiliasPadreQueQuedarianVacias(int idFamiliaHijoAEliminar);
        void AgregarRelacionFamiliaPermiso(int idFamiliaPadre, ServicioPerfil hijo, string dvhRelacion);
        void QuitarRelacionFamiliaPermiso(int idFamiliaPadre, ServicioPerfil hijo);
        int ObtenerCantidadHijosFamilia(int idFamilia);
        List<ServicioPermisoFamilia> ObtenerRelacionesPermisoFamilia();
        List<ServicioFamiliaFamilia> ObtenerRelacionesFamiliaFamilia();
        void ActualizarDVHFamilia(int idFamilia, string dvh);
        void ActualizarDVHPermisoFamilia(int idFamilia, int idPermiso, string dvh);
        void ActualizarDVHFamiliaFamilia(int idFamiliaPadre, int idFamiliaHijo, string dvh);
    }
}
