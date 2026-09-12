using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ServicioPerfil
    {
        [NoVerificar]
        public int IdPerfil { get; set; }
        public string Nombre { get; set; }
        public string DVH { get; set; }

        public ServicioPerfil()
        {
        }

        public ServicioPerfil(int id, string nombre, string dvh)
        {
            IdPerfil = id;
            Nombre = nombre;
            DVH = dvh;
        }
        public virtual void Agregar(ServicioPerfil c) { }
        public virtual void Eliminar(string nombre) { }
        public virtual ServicioPerfil Buscar(string nombre) => null;
        [NoVerificar]
        public virtual List<ServicioPerfil> Hijos => new List<ServicioPerfil>();
        public override string ToString() => Nombre ?? string.Empty;

        private static IDALPerfil ObtenerDAL() => FabricaDAL.Crear<IDALPerfil>("DALPerfil");

        public ServicioPerfil CargarPerfilUsuario(int idPerfilUsuario)
        {
            if (idPerfilUsuario <= 0) return null;

            IDALPerfil dalPerfil = ObtenerDAL();
            return dalPerfil.ObtenerPerfilUsuario(idPerfilUsuario);
        }

        public List<ServicioPerfil> ObtenerPerfiles()
        {
            IDALPerfil dalPerfil = ObtenerDAL();
            return dalPerfil.ObtenerPerfiles();
        }

        public bool TienePermiso(ServicioUsuario usuario, string nombrePermisoABuscar)
        {
            if (usuario == null || usuario.PerfilUsuario == null) return false;
            if (string.IsNullOrEmpty(nombrePermisoABuscar)) return false;

            ServicioPerfil encontrado = usuario.PerfilUsuario.Buscar(nombrePermisoABuscar);

            return encontrado != null;
        }

        public void CrearPerfil(string nombrePerfil, List<ServicioPerfil> componentesSeleccionados)
        {
            if (string.IsNullOrWhiteSpace(nombrePerfil))
                throw new Exception(ServicioSessionManager.GetInstance().Traducir("El nombre del perfil no puede estar vacío."));

            if (componentesSeleccionados == null || componentesSeleccionados.Count == 0)
                throw new Exception(ServicioSessionManager.GetInstance().Traducir("No se puede crear un perfil vacío. Debe seleccionar al menos un permiso o familia."));

            ValidarNombrePerfilDisponible(nombrePerfil);

            GeneradorDigVerificador generador = new GeneradorDigVerificador();
            IDALPerfil dalPerfil = ObtenerDAL();

            ServicioFamilia nuevoPerfil = new ServicioFamilia(0, nombrePerfil.Trim(), "");
            nuevoPerfil.DVH = generador.GenerarDVH(nuevoPerfil);

            int idAsignado = dalPerfil.GuardarPerfil(nuevoPerfil);
            new ServicioDVV().RecalcularDVVPerfil();

            List<string> dvhsRelaciones = new List<string>();

            foreach (ServicioPerfil hijo in componentesSeleccionados)
            {
                if (hijo is ServicioPermiso)
                {
                    ServicioPerfilPermiso relacion = new ServicioPerfilPermiso
                    {
                        IdPerfil = idAsignado,
                        IdPermiso = hijo.IdPerfil
                    };

                    dvhsRelaciones.Add(generador.GenerarDVH(relacion));
                }
                else if (hijo is ServicioFamilia)
                {
                    ServicioPerfilFamilia relacion = new ServicioPerfilFamilia
                    {
                        IdPerfil = idAsignado,
                        IdFamilia = hijo.IdPerfil
                    };

                    dvhsRelaciones.Add(generador.GenerarDVH(relacion));
                }
            }

            dalPerfil.GuardarRelacionesPerfil(idAsignado, componentesSeleccionados, dvhsRelaciones);
            new ServicioDVV().RecalcularDVVPerfilPermiso();
            new ServicioDVV().RecalcularDVVPerfilFamilia();
            ServicioEvento bitacora = new ServicioEvento();
            bitacora.GrabarBitacora("Creación de nuevo Perfil", "Perfiles", 1);
        }

        private void ValidarNombrePerfilDisponible(string nombrePerfil)
        {
            bool existe = ObtenerPerfiles()
                .Any(p => p.Nombre.Equals(nombrePerfil.Trim(), StringComparison.OrdinalIgnoreCase));

            if (existe)
                throw new Exception(ServicioSessionManager.GetInstance().Traducir("Ya existe un perfil con el nombre ") + nombrePerfil);
        }

        public void EliminarPerfil(int idPerfil, string nombrePerfil)
        {
            IDALPerfil dalPerfil = ObtenerDAL();
            if (dalPerfil.PerfilEstaAsignadoAUsuario(idPerfil))
            {
                throw new Exception(ServicioSessionManager.GetInstance().Traducir("El perfil ") + nombrePerfil + ServicioSessionManager.GetInstance().Traducir("no se puede eliminar porque está asignado actualmente a uno o más usuarios."));
            }
            dalPerfil.EliminarPerfil(idPerfil);
            new ServicioDVV().RecalcularDVVPerfil();
            new ServicioDVV().RecalcularDVVPerfilPermiso();
            new ServicioDVV().RecalcularDVVPerfilFamilia();
            ServicioEvento bitacora = new ServicioEvento();
            bitacora.GrabarBitacora("Eliminación de Perfil", "Perfiles", 1);
        }

        public void AgregarPermisoAPerfil(int idPerfilPadre, string nombrePerfil, ServicioPerfil hijo)
        {
            if (hijo == null)
                throw new Exception(ServicioSessionManager.GetInstance().Traducir("Debe seleccionar un componente válido para agregar."));

            IDALPerfil dalPerfil = ObtenerDAL();
            ServicioPerfil perfilCompleto = dalPerfil.ObtenerPerfilUsuario(idPerfilPadre);

            if (perfilCompleto != null)
            {
                ServicioPerfil encontrado = perfilCompleto.Buscar(hijo.Nombre);

                if (encontrado != null && encontrado is ServicioPermiso)
                {
                    throw new Exception(ServicioSessionManager.GetInstance().Traducir("El perfil ") + nombrePerfil + ServicioSessionManager.GetInstance().Traducir("ya posee el componente ") + hijo.Nombre + ServicioSessionManager.GetInstance().Traducir("de forma directa o heredada a través de una familia."));
                }
            }

            ServicioPerfilPermiso relacion = new ServicioPerfilPermiso
            {
                IdPerfil = idPerfilPadre,
                IdPermiso = hijo.IdPerfil
            };

            GeneradorDigVerificador generador = new GeneradorDigVerificador();
            string dvhRelacion = generador.GenerarDVH(relacion);

            dalPerfil.AgregarRelacionPerfilPermiso(idPerfilPadre, hijo, dvhRelacion);
            new ServicioDVV().RecalcularDVVPerfilPermiso();
            ServicioEvento bitacora = new ServicioEvento();
            bitacora.GrabarBitacora("Modificación Perfil", "Perfiles", 1);
        }

        public void QuitarPermisoDePerfil(int idPerfilPadre, string nombrePerfil, ServicioPerfil hijo)
        {
            if (hijo == null) throw new Exception(ServicioSessionManager.GetInstance().Traducir("Debe seleccionar un componente válido para quitar."));

            IDALPerfil dalPerfil = ObtenerDAL();
            ServicioPerfil perfilCompleto = dalPerfil.ObtenerPerfilUsuario(idPerfilPadre);
            if (perfilCompleto == null || perfilCompleto.Hijos == null || !perfilCompleto.Hijos.Any(h => h.IdPerfil == hijo.IdPerfil && h.GetType() == hijo.GetType()))
            {
                throw new Exception(ServicioSessionManager.GetInstance().Traducir("El perfil ") + nombrePerfil + ServicioSessionManager.GetInstance().Traducir("no tiene asignado directamente el componente ") + hijo.Nombre + ServicioSessionManager.GetInstance().Traducir(", por lo que no puede ser removido."));
            }

            ValidarQueNoQuedeVacio(idPerfilPadre, nombrePerfil);
            dalPerfil.QuitarRelacionPerfilPermiso(idPerfilPadre, hijo);
            new ServicioDVV().RecalcularDVVPerfilPermiso();
            ServicioEvento bitacora = new ServicioEvento();
            bitacora.GrabarBitacora($"Modificación Perfil", "Perfiles", 1);
        }

        public void ValidarQueNoQuedeVacio(int idPerfil, string nombrePerfil)
        {
            IDALPerfil dalPerfil = ObtenerDAL();
            int cantidadComponentes = dalPerfil.ObtenerCantidadHijosPerfil(idPerfil);
            if (cantidadComponentes <= 1)
            {
                throw new Exception(ServicioSessionManager.GetInstance().Traducir("Operación denegada. El perfil ") + nombrePerfil + ServicioSessionManager.GetInstance().Traducir("no puede quedarse vacío. Debe conservar al menos un permiso o familia asignado en su raíz."));
            }
        }

        public void AgregarFamiliaAPerfil(int idPerfilPadre, string nombrePerfil, ServicioFamilia familiaHijo)
        {
            if (familiaHijo == null)
                throw new Exception(ServicioSessionManager.GetInstance().Traducir("Debe seleccionar una familia válida para agregar."));

            ServicioPerfilFamilia relacion = new ServicioPerfilFamilia
            {
                IdPerfil = idPerfilPadre,
                IdFamilia = familiaHijo.IdPerfil
            };

            GeneradorDigVerificador generador = new GeneradorDigVerificador();
            string dvhRelacion = generador.GenerarDVH(relacion);

            IDALPerfil dalPerfil = ObtenerDAL();
            dalPerfil.AgregarRelacionPerfilFamilia(idPerfilPadre, familiaHijo, dvhRelacion);
            new ServicioDVV().RecalcularDVVPerfilFamilia();
            ServicioEvento bitacora = new ServicioEvento();
            bitacora.GrabarBitacora("Modificación Perfil", "Perfiles", 1);
        }

        public void QuitarFamiliaDePerfil(int idPerfilPadre, string nombrePerfil, ServicioFamilia familiaHijo)
        {
            if (familiaHijo == null) throw new Exception(ServicioSessionManager.GetInstance().Traducir("Debe seleccionar una familia válida para quitar."));

            IDALPerfil dalPerfil = ObtenerDAL();
            ServicioPerfil perfilCompleto = dalPerfil.ObtenerPerfilUsuario(idPerfilPadre);
            if (perfilCompleto == null || perfilCompleto.Hijos == null || !perfilCompleto.Hijos.Any(h => h.IdPerfil == familiaHijo.IdPerfil && h is ServicioFamilia))
            {
                throw new Exception(ServicioSessionManager.GetInstance().Traducir("El perfil " + nombrePerfil + ServicioSessionManager.GetInstance().Traducir("no tiene asignada directamente la familia ") + familiaHijo.Nombre + ServicioSessionManager.GetInstance().Traducir(", por lo que no puede ser removida.")));
            }

            ValidarQueNoQuedeVacio(idPerfilPadre, nombrePerfil);
            dalPerfil.QuitarRelacionPerfilFamilia(idPerfilPadre, familiaHijo);
            new ServicioDVV().RecalcularDVVPerfilFamilia();
            ServicioEvento bitacora = new ServicioEvento();
            bitacora.GrabarBitacora("Modificación Perfil", "Perfiles", 1);
        }
    }
}
