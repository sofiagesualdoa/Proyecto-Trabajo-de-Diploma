using System.ComponentModel;
using System.Windows.Forms;

namespace Servicios
{
    public class ServicioUsuario
    {
        public int DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string contraseña { get; set; }
        public string nombreUsuario { get; set; }
        public int IdPerfil { get; set; }

        [NoVerificar]
        public ServicioPerfil PerfilUsuario { get; set; }

        public int IntentosInicio { get; set; }
        public bool Activo { get; set; }
        public bool Bloqueado { get; set; }
        public int IdIdioma { get; set; }
        public string DVH { get; set; }

        [NoVerificar]
        public ServicioIdioma Idioma { get; set; }

        private static IDALUsuario ObtenerDAL() => FabricaDAL.Crear<IDALUsuario>("DALUsuario");

        public void SetPassword(string hash)
        {
            contraseña = hash.ToUpper().Trim();
        }

        public string GetPassword()
        {
            return contraseña;
        }

        public bool ValidarPassword(string hashIngresado)
        {
            return this.contraseña.ToUpper().Trim() == hashIngresado.ToUpper().Trim();
        }

        public void ActualizarPasswordMemoria(string nuevoHash)
        {
            this.contraseña = nuevoHash.ToUpper().Trim();
        }

        public void ModificarClave(string claveActual, string claveNueva)
        {
            ServicioEvento bitacora = new ServicioEvento();
            GeneradorDigVerificador generador = new GeneradorDigVerificador();
            try
            {
                ServicioUsuario usuarioActivo = ServicioSessionManager.GetInstance().ObtenerUsuario();

                ServicioEncriptador encriptador = new ServicioEncriptador();
                string hashClaveActual = encriptador.Encriptar(claveActual);
                if (!usuarioActivo.ValidarPassword(hashClaveActual))
                {
                    throw new Exception(ServicioSessionManager.GetInstance().Traducir("La contraseña actual ingresada es incorrecta."));
                }
                string hashClaveNueva = encriptador.Encriptar(claveNueva);

                if (usuarioActivo.GetPassword().ToUpper().Trim() == hashClaveNueva.ToUpper().Trim())
                {
                    throw new Exception(ServicioSessionManager.GetInstance().Traducir("La nueva contraseña no puede ser igual a la contraseña actual. Por favor, elija una diferente."));
                }
                IDALUsuario dal = ObtenerDAL();
                usuarioActivo.ActualizarPasswordMemoria(hashClaveNueva);
                usuarioActivo.DVH = generador.GenerarDVH(usuarioActivo);
                dal.GuardarNuevaClave(usuarioActivo.nombreUsuario, hashClaveNueva, usuarioActivo.DVH);
                new ServicioDVV().RecalcularDVVUsuario();
                bitacora.GrabarBitacora("Cambiar Clave", "Usuario", 1);
            }
            catch (Exception ex)
            {
                string errorTraducido = ServicioSessionManager.GetInstance().Traducir(ex.Message);
                throw new Exception(ServicioSessionManager.GetInstance().Traducir("Error al intentar cambiar la contraseña: ") + errorTraducido);
            }
        }

        public bool IniciarSesion(string nombreUsuario, string passwordIngresado)
        {
            ServicioEvento bitacora = new ServicioEvento();
            GeneradorDigVerificador generador = new GeneradorDigVerificador();

            ServicioEncriptador encriptador = new ServicioEncriptador();
            string hashIngresado = encriptador.Encriptar(passwordIngresado);

            IDALUsuario dal = ObtenerDAL();
            ServicioUsuario usuario = dal.ObtenerUsuario(nombreUsuario);

            if (usuario == null)
            {
                throw new Exception(ServicioSessionManager.GetInstance().Traducir("El nombre de usuario ingresado no existe."));
            }
            if (usuario.Bloqueado)
            {
                throw new Exception(ServicioSessionManager.GetInstance().Traducir("La cuenta se encuentra bloqueada por seguridad. Contacte a un administrador."));
            }
            if (!usuario.Activo)
            {
                throw new Exception(ServicioSessionManager.GetInstance().Traducir("El usuario se encuentra dado de baja en el sistema."));
            }
            if (!usuario.ValidarPassword(hashIngresado))
            {
                usuario.IntentosInicio++;
                usuario.DVH = generador.GenerarDVH(usuario);
                dal.SumarIntentoFallido(usuario.nombreUsuario, usuario.DVH);
                new ServicioDVV().RecalcularDVVUsuario();
                if (usuario.IntentosInicio >= 3)
                {
                    usuario.Bloqueado = true;
                    usuario.DVH = generador.GenerarDVH(usuario);
                    dal.BloquearUsuario(usuario.DNI, usuario.DVH);
                    new ServicioDVV().RecalcularDVVUsuario();
                    bitacora.GrabarBitacora($"Bloquear Usuario: {nombreUsuario}", "Usuario", 1);
                    throw new Exception(ServicioSessionManager.GetInstance().Traducir("La cuenta ha sido bloqueada de forma automática por superar los 3 intentos fallidos."));
                }

                throw new Exception(ServicioSessionManager.GetInstance().Traducir("La contraseña ingresada es incorrecta."));
            }

            if (usuario.IntentosInicio > 0)
            {
                usuario.IntentosInicio = 0;
                usuario.Bloqueado = false;
                usuario.DVH = generador.GenerarDVH(usuario);
                dal.DesbloquearUsuario(usuario.DNI, usuario.DVH);
                new ServicioDVV().RecalcularDVVUsuario();
            }

            ServicioPerfil servicioPerfil = new ServicioPerfil();
            usuario.PerfilUsuario = servicioPerfil.CargarPerfilUsuario(usuario.IdPerfil);

            if (usuario.IdIdioma > 0)
            {
                ServicioIdioma servicioIdioma = new ServicioIdioma();
                usuario.Idioma = servicioIdioma.ListarIdiomas().FirstOrDefault(i => i.IdIdioma == usuario.IdIdioma);
                if (usuario.Idioma != null && usuario.Idioma.CodigoIdioma == "en")
                {
                    usuario.Idioma.DiccionarioLeyendas = servicioIdioma.ObtenerTraducciones();
                }
            }
            ServicioDVV servicioDVV = new ServicioDVV();
            if (!servicioDVV.ValidarIntegridad())
            {
                if (servicioPerfil.TienePermiso(usuario, "Administrador"))
                {
                    ServicioSessionManager.GetInstance().IniciarSesion(usuario);
                    throw new Exception("ERROR_INTEGRIDAD_ADMIN");
                }
                throw new Exception("ERROR_INTEGRIDAD_NO_ADMIN");
            }

            ServicioSessionManager.GetInstance().IniciarSesion(usuario);
            bitacora.GrabarBitacora("Login", "Usuario", 1);
            return true;
        }

        public bool CerrarSesion()
        {
            ServicioUsuario usuarioActivo = ServicioSessionManager.GetInstance().ObtenerUsuario();
            if (usuarioActivo != null)
            {
                ServicioEvento bitacora = new ServicioEvento();
                bitacora.GrabarBitacora("Logout", "Usuario", 1);
                ServicioSessionManager.GetInstance().CerrarSesion();
                return true;
            }
            return false;
        }

        public void CrearUsuario(ServicioUsuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Nombre) ||
                string.IsNullOrWhiteSpace(usuario.Apellido) ||
                string.IsNullOrWhiteSpace(usuario.Email) ||
                string.IsNullOrWhiteSpace(usuario.nombreUsuario) ||
                usuario.IdPerfil <= 0)
            {
                throw new Exception(ServicioSessionManager.GetInstance().Traducir("Debe completar todos los campos."));
            }

            IDALUsuario dal = ObtenerDAL();

            ServicioUsuario existente = dal.BuscarUsuarioPorDniOMail(
                usuario.DNI,
                usuario.Email);

            if (existente != null)
            {
                throw new Exception(ServicioSessionManager.GetInstance().Traducir("Ya existe un usuario con ese DNI o email."));
            }

            string clavePlana = usuario.DNI.ToString() + usuario.Apellido;
            ServicioEncriptador encriptador = new ServicioEncriptador();
            string hashClave = encriptador.Encriptar(clavePlana);
            usuario.SetPassword(hashClave);
            usuario.Bloqueado = false;
            usuario.IntentosInicio = 0;
            GeneradorDigVerificador generador = new GeneradorDigVerificador();
            usuario.DVH = generador.GenerarDVH(usuario);
            dal.GuardarUsuario(usuario);
            new ServicioDVV().RecalcularDVVUsuario();
            ServicioEvento bitacora = new ServicioEvento();
            bitacora.GrabarBitacora("Crear Usuario", "Usuario", 1);
        }

        public List<ServicioUsuario> ObtenerUsuarios()
        {
            IDALUsuario dal = ObtenerDAL();
            return dal.ObtenerUsuarios();
        }

        public ServicioUsuario BuscarUsuarioPorDniOMail(int dni, string email)
        {
            IDALUsuario dal = ObtenerDAL();
            return dal.BuscarUsuarioPorDniOMail(dni, email);
        }

        public void DesbloquearUsuario(int dni)
        {
            IDALUsuario dal = ObtenerDAL();
            ServicioUsuario usuario = dal.BuscarUsuarioPorDniOMail(dni, "x");

            if (usuario == null)
            {
                throw new Exception(ServicioSessionManager.GetInstance().Traducir("El usuario no existe."));
            }

            if (!usuario.Bloqueado)
            {
                throw new Exception(
                    ServicioSessionManager.GetInstance().Traducir("El usuario ya se encuentra desbloqueado."));
            }
            usuario.Bloqueado = false;
            usuario.IntentosInicio = 0;
            GeneradorDigVerificador generador = new GeneradorDigVerificador();
            usuario.DVH = generador.GenerarDVH(usuario);
            dal.DesbloquearUsuario(dni, usuario.DVH);
            new ServicioDVV().RecalcularDVVUsuario();
            ServicioEvento bitacora = new ServicioEvento();
            bitacora.GrabarBitacora($"Desbloquear Usuario: {usuario.nombreUsuario}", "Usuario", 1);
        }

        public void ModificarUsuario(ServicioUsuario usuarioModificado)
        {
            IDALUsuario dal = ObtenerDAL();

            ServicioUsuario usuarioExistente =
                dal.BuscarUsuarioPorDniOMail(usuarioModificado.DNI, "x");

            if (usuarioExistente == null)
            {
                throw new Exception(ServicioSessionManager.GetInstance().Traducir("El usuario no existe."));
            }
            GeneradorDigVerificador generador = new GeneradorDigVerificador();
            usuarioModificado.DVH = generador.GenerarDVH(usuarioModificado);
            dal.ModificarUsuario(usuarioModificado);
            new ServicioDVV().RecalcularDVVUsuario();
            ServicioEvento bitacora = new ServicioEvento();
            bitacora.GrabarBitacora($"Modificar Usuario: {usuarioModificado.nombreUsuario}", "Usuario", 1);
        }

        public bool ModificarEstado(int DNIUsuarioSeleccionado)
        {
            ServicioUsuario logueado = ServicioSessionManager.GetInstance().ObtenerUsuario();
            if (logueado != null && logueado.DNI == DNIUsuarioSeleccionado)
            {
                throw new Exception(ServicioSessionManager.GetInstance().Traducir("Operación inválida. No es posible desactivar la cuenta con la que se encuentra logueado actualmente."));
            }
            IDALUsuario dal = ObtenerDAL();
            ServicioUsuario usuarioAfectado = dal.BuscarUsuarioPorDniOMail(DNIUsuarioSeleccionado, "x");
            usuarioAfectado.Activo = !usuarioAfectado.Activo;
            GeneradorDigVerificador generador = new GeneradorDigVerificador();
            usuarioAfectado.DVH = generador.GenerarDVH(usuarioAfectado);
            bool exito = dal.ModificarEstado(DNIUsuarioSeleccionado, usuarioAfectado.DVH);
            new ServicioDVV().RecalcularDVVUsuario();
            if (exito)
            {
                ServicioEvento bitacora = new ServicioEvento();
                bitacora.GrabarBitacora($"Activar / Desactivar Usuario", "Usuario", 1);
                return true;
            }
            return false;
        }

        public void ActualizarIdiomaUsuario(int dni, int idIdioma)
        {
            IDALUsuario dal = ObtenerDAL();
            ServicioUsuario logueado = ServicioSessionManager.GetInstance().ObtenerUsuario();
            logueado.IdIdioma = idIdioma;
            GeneradorDigVerificador generador = new GeneradorDigVerificador();
            logueado.DVH = generador.GenerarDVH(logueado);
            dal.ActualizarIdiomaUsuario(dni, idIdioma, logueado.DVH);
            new ServicioDVV().RecalcularDVVUsuario();
        }
    }
}
