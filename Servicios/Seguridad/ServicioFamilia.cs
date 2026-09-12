using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ServicioFamilia : ServicioPerfil
    {
        private List<ServicioPerfil> listaperfil;

        public ServicioFamilia() : base(0, "", "")
        {
            listaperfil = new List<ServicioPerfil>();
        }

        public ServicioFamilia(int id, string nombre, string dvh) : base(id, nombre, dvh)
        {
            listaperfil = new List<ServicioPerfil>();
        }

        public override List<ServicioPerfil> Hijos => listaperfil;

        public override void Agregar(ServicioPerfil c)
        {
            listaperfil.Add(c);
        }

        public override void Eliminar(string nombre)
        {
            ServicioPerfil encontrar = Buscar(nombre);
            if (encontrar != null) listaperfil.Remove(encontrar);
        }

        public override ServicioPerfil Buscar(string nombre)
        {
            if (Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase)) return this;

            foreach (var c in listaperfil)
            {
                ServicioPerfil enc = c.Buscar(nombre);
                if (enc != null) return enc;
            }
            return null;
        }

        private static IDALFamilia ObtenerDAL() => FabricaDAL.Crear<IDALFamilia>("DALFamilia");
        private static IDALPerfil ObtenerDALPerfil() => FabricaDAL.Crear<IDALPerfil>("DALPerfil");

        public List<ServicioFamilia> ObtenerFamilias()
        {
            IDALFamilia dalFamilia = ObtenerDAL();
            return dalFamilia.ObtenerFamilias();
        }

        public void CrearFamilia(string nombreFamilia, List<ServicioPerfil> componentesSeleccionados)
        {
            if (string.IsNullOrWhiteSpace(nombreFamilia))
                throw new Exception(ServicioSessionManager.GetInstance().Traducir("El nombre de la familia no puede estar vacío."));

            if (componentesSeleccionados == null || componentesSeleccionados.Count == 0)
                throw new Exception(ServicioSessionManager.GetInstance().Traducir("No se puede crear una familia vacía. Debe seleccionar al menos un permiso o familia hijo."));

            ValidarNombreFamiliaDisponible(nombreFamilia);

            GeneradorDigVerificador generador = new GeneradorDigVerificador();
            IDALFamilia dalFamilia = ObtenerDAL();

            ServicioFamilia nuevaFamilia = new ServicioFamilia(0, nombreFamilia.Trim(), "");
            nuevaFamilia.DVH = generador.GenerarDVH(nuevaFamilia);

            int idAsignado = dalFamilia.GuardarFamilia(nuevaFamilia);
            new ServicioDVV().RecalcularDVVFamilia();
            List<string> dvhsRelaciones = new List<string>();

            foreach (ServicioPerfil hijo in componentesSeleccionados)
            {
                if (hijo is ServicioPermiso)
                {
                    ServicioPermisoFamilia relacion = new ServicioPermisoFamilia
                    {
                        IdFamilia = idAsignado,
                        IdPermiso = hijo.IdPerfil
                    };

                    dvhsRelaciones.Add(generador.GenerarDVH(relacion));
                }
                else if (hijo is ServicioFamilia)
                {
                    ServicioFamiliaFamilia relacion = new ServicioFamiliaFamilia
                    {
                        IdFamiliaPadre = idAsignado,
                        IdFamiliaHijo = hijo.IdPerfil
                    };

                    dvhsRelaciones.Add(generador.GenerarDVH(relacion));
                }
            }

            dalFamilia.GuardarRelacionesFamilia(idAsignado, componentesSeleccionados, dvhsRelaciones);
            new ServicioDVV().RecalcularDVVPermisoFamilia();
            new ServicioDVV().RecalcularDVVFamiliaFamilia();
            ServicioEvento bitacora = new ServicioEvento();
            bitacora.GrabarBitacora("Creación de nueva Familia", "Perfiles", 1);
        }

        private void ValidarNombreFamiliaDisponible(string nombreFamilia)
        {
            bool existe = ObtenerFamilias()
                .Any(f => f.Nombre.Equals(nombreFamilia.Trim(), StringComparison.OrdinalIgnoreCase));

            if (existe)
                throw new Exception(ServicioSessionManager.GetInstance().Traducir("Ya existe una familia con el nombre ") + nombreFamilia);
        }

        public void EliminarFamilia(int idFamilia, string nombreFamilia)
        {
            IDALPerfil dalPerfil = ObtenerDALPerfil();
            IDALFamilia dalFamilia = ObtenerDAL();

            List<int> perfilesVacios = dalPerfil.ObtenerPerfilesQueQuedarianVaciosPorFamilia(idFamilia);
            if (perfilesVacios.Count > 0)
            {
                throw new Exception(ServicioSessionManager.GetInstance().Traducir("Operación denegada. La familia " + nombreFamilia + ServicioSessionManager.GetInstance().Traducir("no se puede eliminar porque es el único componente asignado a uno o más Perfiles de Usuario. Modifique primero esos perfiles para que no queden vacíos.")));
            }
            List<int> familiasVacias = dalFamilia.ObtenerFamiliasPadreQueQuedarianVacias(idFamilia);
            if (familiasVacias.Count > 0)
            {
                throw new Exception(ServicioSessionManager.GetInstance().Traducir("Operación denegada. La familia ") + nombreFamilia + ServicioSessionManager.GetInstance().Traducir("no se puede eliminar porque es el único componente de otra Familia del sistema. Modifique la familia contenedora primero."));
            }
            dalFamilia.EliminarFamilia(idFamilia);
            new ServicioDVV().RecalcularDVVFamilia();
            new ServicioDVV().RecalcularDVVPermisoFamilia();
            new ServicioDVV().RecalcularDVVFamiliaFamilia();
            new ServicioDVV().RecalcularDVVPerfilFamilia();
            ServicioEvento bitacora = new ServicioEvento();
            bitacora.GrabarBitacora("Eliminación de Familia", "Perfiles", 1);
        }

        public void AgregarPermisoAFamilia(int idFamiliaPadre, string nombreFamilia, ServicioPerfil hijo)
        {
            if (hijo == null)
                throw new Exception(ServicioSessionManager.GetInstance().Traducir("Debe seleccionar un componente válido para agregar."));

            GeneradorDigVerificador generador = new GeneradorDigVerificador();
            IDALFamilia dalFamilia = ObtenerDAL();

            if (hijo is ServicioPermiso)
            {
                ServicioPermisoFamilia relacion = new ServicioPermisoFamilia
                {
                    IdFamilia = idFamiliaPadre,
                    IdPermiso = hijo.IdPerfil
                };

                string dvhRelacion = generador.GenerarDVH(relacion);
                dalFamilia.AgregarRelacionFamiliaPermiso(idFamiliaPadre, hijo, dvhRelacion);
                new ServicioDVV().RecalcularDVVPermisoFamilia();
            }
            else if (hijo is ServicioFamilia)
            {
                ServicioFamiliaFamilia relacion = new ServicioFamiliaFamilia
                {
                    IdFamiliaPadre = idFamiliaPadre,
                    IdFamiliaHijo = hijo.IdPerfil
                };

                string dvhRelacion = generador.GenerarDVH(relacion);
                dalFamilia.AgregarRelacionFamiliaPermiso(idFamiliaPadre, hijo, dvhRelacion);
                new ServicioDVV().RecalcularDVVFamiliaFamilia();
            }

            ServicioEvento bitacora = new ServicioEvento();
            bitacora.GrabarBitacora("Modificación Familia", "Perfiles", 1);
        }

        public void QuitarPermisoDeFamilia(int idFamiliaPadre, string nombreFamilia, ServicioPerfil hijo)
        {
            if (hijo == null) throw new Exception(ServicioSessionManager.GetInstance().Traducir("Debe seleccionar un componente válido para quitar."));

            List<ServicioFamilia> todasLasFamilias = ObtenerFamilias();
            ServicioFamilia familiaCompleta = todasLasFamilias.FirstOrDefault(f => f.IdPerfil == idFamiliaPadre);

            if (familiaCompleta == null || familiaCompleta.Hijos == null || !familiaCompleta.Hijos.Any(h => h.IdPerfil == hijo.IdPerfil && h.GetType() == hijo.GetType()))
            {
                throw new Exception(ServicioSessionManager.GetInstance().Traducir("La familia ") + nombreFamilia + ServicioSessionManager.GetInstance().Traducir("no tiene asignado directamente el componente ") + hijo.Nombre + ServicioSessionManager.GetInstance().Traducir(", por lo que no puede ser removido."));
            }

            ValidarQueFamiliaNoQuedeVacia(idFamiliaPadre, nombreFamilia);
            IDALFamilia dalFamilia = ObtenerDAL();
            dalFamilia.QuitarRelacionFamiliaPermiso(idFamiliaPadre, hijo);
            new ServicioDVV().RecalcularDVVFamiliaFamilia();
            new ServicioDVV().RecalcularDVVPermisoFamilia();
            ServicioEvento bitacora = new ServicioEvento();
            bitacora.GrabarBitacora("Modificación Familia", "Perfiles", 1);
        }

        public void ValidarQueFamiliaNoQuedeVacia(int idFamilia, string nombreFamilia)
        {
            IDALFamilia dalFamilia = ObtenerDAL();
            int cantidadComponentes = dalFamilia.ObtenerCantidadHijosFamilia(idFamilia);
            if (cantidadComponentes <= 1)
            {
                throw new Exception(ServicioSessionManager.GetInstance().Traducir("Operación denegada. La familia ") + nombreFamilia + ServicioSessionManager.GetInstance().Traducir("no puede quedarse vacía. Debe conservar al menos un permiso o subfamilia asignado."));
            }
        }
    }
}
