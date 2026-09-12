using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ServicioDVV
    {
        public string NombreTabla { get; set; }

        public string Digito { get; set; }

        private readonly GeneradorDigVerificador generador = new GeneradorDigVerificador();
        private readonly IDALDVV dalDVV = FabricaDAL.Crear<IDALDVV>("DALDVV");

        private static IDALUsuario ObtenerDALUsuario() => FabricaDAL.Crear<IDALUsuario>("DALUsuario");
        private static IDALPerfil ObtenerDALPerfil() => FabricaDAL.Crear<IDALPerfil>("DALPerfil");
        private static IDALFamilia ObtenerDALFamilia() => FabricaDAL.Crear<IDALFamilia>("DALFamilia");
        private static IDALEvento ObtenerDALEvento() => FabricaDAL.Crear<IDALEvento>("DALEvento");
        private static IDALPermiso ObtenerDALPermiso() => FabricaDAL.Crear<IDALPermiso>("DALPermiso");
        private static IDALIdioma ObtenerDALIdioma() => FabricaDAL.Crear<IDALIdioma>("DALIdioma");

        public void RecalcularDigitosVerificadores()
        {
            RecalcularDVHUsuario();
            RecalcularDVHPerfil();
            RecalcularDVHFamilia();
            RecalcularDVHEvento();
            RecalcularDVHPerfilPermiso();
            RecalcularDVHPerfilFamilia();
            RecalcularDVHPermisoFamilia();
            RecalcularDVHFamiliaFamilia();
            RecalcularDVHIdioma();
            RecalcularDVHPermiso();
            RecalcularDVHLibro();
            RecalcularTodosLosDVV();
        }

        public void RecalcularTodosLosDVV()
        {
            RecalcularDVVUsuario();
            RecalcularDVVPerfil();
            RecalcularDVVFamilia();
            RecalcularDVVEvento();
            RecalcularDVVPerfilPermiso();
            RecalcularDVVPerfilFamilia();
            RecalcularDVVPermisoFamilia();
            RecalcularDVVFamiliaFamilia();
            RecalcularDVVIdioma();
            RecalcularDVVPermiso();
            RecalcularDVVLibro();
        }

        public void RecalcularDVHUsuario()
        {
            IDALUsuario dal = ObtenerDALUsuario();
            List<ServicioUsuario> usuarios = dal.ObtenerUsuarios();

            foreach (ServicioUsuario usuario in usuarios)
            {
                usuario.DVH = generador.GenerarDVH(usuario);
                dal.ActualizarDVHUsuario(usuario.DNI, usuario.DVH);
            }
        }

        public void RecalcularDVHPerfil()
        {
            IDALPerfil dal = ObtenerDALPerfil();
            List<ServicioPerfil> perfiles = dal.ObtenerPerfiles();

            foreach (ServicioPerfil x in perfiles)
            {
                x.DVH = generador.GenerarDVH(x);
                dal.ActualizarDVHPerfil(x.IdPerfil, x.DVH);
            }
        }

        public void RecalcularDVHFamilia()
        {
            IDALFamilia dal = ObtenerDALFamilia();
            List<ServicioFamilia> fams = dal.ObtenerFamilias();

            foreach (ServicioFamilia x in fams)
            {
                x.DVH = generador.GenerarDVH(x);
                dal.ActualizarDVHFamilia(x.IdPerfil, x.DVH);
            }
        }

        public void RecalcularDVHEvento()
        {
            IDALEvento dal = ObtenerDALEvento();
            List<ServicioEvento> eventos = dal.ObtenerTodosLosEventos();

            foreach (ServicioEvento x in eventos)
            {
                x.DVH = generador.GenerarDVH(x);
                dal.ActualizarDVHEvento(x.IdEvento, x.DVH);
            }
        }

        public void RecalcularDVHPerfilPermiso()
        {
            IDALPerfil dal = ObtenerDALPerfil();
            List<ServicioPerfilPermiso> lista = dal.ObtenerRelacionesPerfilPermiso();

            foreach (ServicioPerfilPermiso x in lista)
            {
                x.DVH = generador.GenerarDVH(x);
                dal.ActualizarDVHPerfilPermiso(x.IdPerfil, x.IdPermiso, x.DVH);
            }
        }

        public void RecalcularDVHPerfilFamilia()
        {
            IDALPerfil dal = ObtenerDALPerfil();
            List<ServicioPerfilFamilia> lista = dal.ObtenerRelacionesPerfilFamilia();

            foreach (ServicioPerfilFamilia x in lista)
            {
                x.DVH = generador.GenerarDVH(x);
                dal.ActualizarDVHPerfilFamilia(x.IdPerfil, x.IdFamilia, x.DVH);
            }
        }

        public void RecalcularDVHPermisoFamilia()
        {
            IDALFamilia dal = ObtenerDALFamilia();
            List<ServicioPermisoFamilia> lista = dal.ObtenerRelacionesPermisoFamilia();

            foreach (ServicioPermisoFamilia x in lista)
            {
                x.DVH = generador.GenerarDVH(x);
                dal.ActualizarDVHPermisoFamilia(x.IdFamilia, x.IdPermiso, x.DVH);
            }
        }

        public void RecalcularDVHFamiliaFamilia()
        {
            IDALFamilia dal = ObtenerDALFamilia();
            List<ServicioFamiliaFamilia> lista = dal.ObtenerRelacionesFamiliaFamilia();

            foreach (ServicioFamiliaFamilia x in lista)
            {
                x.DVH = generador.GenerarDVH(x);
                dal.ActualizarDVHFamiliaFamilia(x.IdFamiliaPadre, x.IdFamiliaHijo, x.DVH);
            }
        }

        public void RecalcularDVHPermiso()
        {
            IDALPermiso dal = ObtenerDALPermiso();
            List<ServicioPermiso> permisos = dal.ObtenerTodos();

            foreach (ServicioPermiso permiso in permisos)
            {
                permiso.DVH = generador.GenerarDVH(permiso);
                dal.ActualizarDVHPermiso(permiso.IdPerfil, permiso.DVH);
            }
        }

        public void RecalcularDVHIdioma()
        {
            IDALIdioma dal = ObtenerDALIdioma();
            List<ServicioIdioma> idiomas = dal.ListarIdiomas();

            foreach (ServicioIdioma idioma in idiomas)
            {
                idioma.DVH = generador.GenerarDVH(idioma);
                dal.ActualizarDVHIdioma(idioma.IdIdioma, idioma.DVH);
            }
        }

        public void RecalcularDVHLibro()
        {
            List<BELibro> libros = dalDVV.ObtenerLibros();
            foreach (BELibro x in libros)
            {
                x.DVH = generador.GenerarDVH(x);
                dalDVV.ActualizarDVHLibro(x.ISBN_657SGA, x.DVH);
            }
        }

        public void RecalcularDVVUsuario()
        {
            IDALUsuario dal = ObtenerDALUsuario();
            GuardarDVV("Usuario", dal.ObtenerUsuarios().Cast<object>().ToList());
        }

        public void RecalcularDVVPerfil()
        {
            IDALPerfil dal = ObtenerDALPerfil();
            GuardarDVV("Perfil", dal.ObtenerPerfiles().Cast<object>().ToList());
        }

        public void RecalcularDVVFamilia()
        {
            IDALFamilia dal = ObtenerDALFamilia();
            GuardarDVV("Familia", dal.ObtenerFamilias().Cast<object>().ToList());
        }

        public void RecalcularDVVEvento()
        {
            IDALEvento dal = ObtenerDALEvento();
            GuardarDVV("Evento", dal.ObtenerTodosLosEventos().Cast<object>().ToList());
        }

        public void RecalcularDVVPerfilPermiso()
        {
            IDALPerfil dal = ObtenerDALPerfil();
            GuardarDVV("Perfil_x_Permiso", dal.ObtenerRelacionesPerfilPermiso().Cast<object>().ToList());
        }

        public void RecalcularDVVPerfilFamilia()
        {
            IDALPerfil dal = ObtenerDALPerfil();
            GuardarDVV("Perfil_x_Familia", dal.ObtenerRelacionesPerfilFamilia().Cast<object>().ToList());
        }

        public void RecalcularDVVPermisoFamilia()
        {
            IDALFamilia dal = ObtenerDALFamilia();
            GuardarDVV("Permiso_x_Familia", dal.ObtenerRelacionesPermisoFamilia().Cast<object>().ToList());
        }

        public void RecalcularDVVFamiliaFamilia()
        {
            IDALFamilia dal = ObtenerDALFamilia();
            GuardarDVV("Familia_x_Familia", dal.ObtenerRelacionesFamiliaFamilia().Cast<object>().ToList());
        }

        public void RecalcularDVVPermiso()
        {
            IDALPermiso dal = ObtenerDALPermiso();
            GuardarDVV("Permiso", dal.ObtenerTodos().Cast<object>().ToList());
        }

        public void RecalcularDVVIdioma()
        {
            IDALIdioma dal = ObtenerDALIdioma();
            GuardarDVV("Idioma", dal.ListarIdiomas().Cast<object>().ToList());
        }

        public void RecalcularDVVLibro()
        {
            GuardarDVV("Libro", dalDVV.ObtenerLibros().Cast<object>().ToList());
        }

        private void GuardarDVV(string nombreTabla, List<object> registros)
        {
            string digito = CalcularDVV(nombreTabla, registros);

            dalDVV.GuardarDVV(new ServicioDVV
            {
                NombreTabla = nombreTabla,
                Digito = digito
            });
        }

        private string CalcularDVV(string nombreTabla, List<object> registros)
        {
            return new GeneradorDigVerificador().GenerarDVV(nombreTabla, registros);
        }

        public bool ValidarIntegridad()
        {
            return ObtenerErroresIntegridad().Count == 0;
        }

        public List<ServicioErrorIntegridad> ObtenerErroresIntegridad()
        {
            List<ServicioErrorIntegridad> errores = new List<ServicioErrorIntegridad>();

            errores.AddRange(ValidarDVHTabla("Usuario", ObtenerDALUsuario().ObtenerUsuarios().Cast<object>().ToList()));
            errores.AddRange(ValidarDVHTabla("Perfil", ObtenerDALPerfil().ObtenerPerfiles().Cast<object>().ToList()));
            errores.AddRange(ValidarDVHTabla("Familia", ObtenerDALFamilia().ObtenerFamilias().Cast<object>().ToList()));
            errores.AddRange(ValidarDVHTabla("Evento", ObtenerDALEvento().ObtenerTodosLosEventos().Cast<object>().ToList()));
            errores.AddRange(ValidarDVHTabla("Perfil_x_Permiso", ObtenerDALPerfil().ObtenerRelacionesPerfilPermiso().Cast<object>().ToList()));
            errores.AddRange(ValidarDVHTabla("Perfil_x_Familia", ObtenerDALPerfil().ObtenerRelacionesPerfilFamilia().Cast<object>().ToList()));
            errores.AddRange(ValidarDVHTabla("Permiso_x_Familia", ObtenerDALFamilia().ObtenerRelacionesPermisoFamilia().Cast<object>().ToList()));
            errores.AddRange(ValidarDVHTabla("Familia_x_Familia", ObtenerDALFamilia().ObtenerRelacionesFamiliaFamilia().Cast<object>().ToList()));
            errores.AddRange(ValidarDVHTabla("Permiso", ObtenerDALPermiso().ObtenerTodos().Cast<object>().ToList()));
            errores.AddRange(ValidarDVHTabla("Idioma", ObtenerDALIdioma().ListarIdiomas().Cast<object>().ToList()));
            errores.AddRange(ValidarDVHTabla("Libro", dalDVV.ObtenerLibros().Cast<object>().ToList()));
            errores.AddRange(ValidarDVVDetallado());

            return errores;
        }

        private List<ServicioErrorIntegridad> ValidarDVHTabla(string nombreTabla, List<object> registros)
        {
            List<ServicioErrorIntegridad> errores = new List<ServicioErrorIntegridad>();

            foreach (object registro in registros)
            {
                var propiedadDVH = registro.GetType().GetProperty("DVH");
                string dvhGuardado = propiedadDVH?.GetValue(registro)?.ToString();
                string dvhCalculado = generador.GenerarDVH(registro);

                if (dvhGuardado != dvhCalculado)
                {
                    errores.Add(new ServicioErrorIntegridad
                    {
                        Tabla = nombreTabla,
                        Registro = ObtenerIdentificadorRegistro(registro),
                        TipoError = "DVH incorrecto",
                        ValorEsperado = dvhCalculado,
                        ValorActual = dvhGuardado
                    });
                }
            }

            return errores;
        }

        private List<ServicioErrorIntegridad> ValidarDVVDetallado()
        {
            List<ServicioErrorIntegridad> errores = new List<ServicioErrorIntegridad>();
            List<ServicioDVV> dvvsGuardados = dalDVV.ObtenerDVV();

            ValidarDVVTablaDetallado("Usuario", ObtenerDALUsuario().ObtenerUsuarios().Cast<object>().ToList(), dvvsGuardados, errores);
            ValidarDVVTablaDetallado("Perfil", ObtenerDALPerfil().ObtenerPerfiles().Cast<object>().ToList(), dvvsGuardados, errores);
            ValidarDVVTablaDetallado("Familia", ObtenerDALFamilia().ObtenerFamilias().Cast<object>().ToList(), dvvsGuardados, errores);
            ValidarDVVTablaDetallado("Evento", ObtenerDALEvento().ObtenerTodosLosEventos().Cast<object>().ToList(), dvvsGuardados, errores);
            ValidarDVVTablaDetallado("Perfil_x_Permiso", ObtenerDALPerfil().ObtenerRelacionesPerfilPermiso().Cast<object>().ToList(), dvvsGuardados, errores);
            ValidarDVVTablaDetallado("Perfil_x_Familia", ObtenerDALPerfil().ObtenerRelacionesPerfilFamilia().Cast<object>().ToList(), dvvsGuardados, errores);
            ValidarDVVTablaDetallado("Permiso_x_Familia", ObtenerDALFamilia().ObtenerRelacionesPermisoFamilia().Cast<object>().ToList(), dvvsGuardados, errores);
            ValidarDVVTablaDetallado("Familia_x_Familia", ObtenerDALFamilia().ObtenerRelacionesFamiliaFamilia().Cast<object>().ToList(), dvvsGuardados, errores);
            ValidarDVVTablaDetallado("Permiso", ObtenerDALPermiso().ObtenerTodos().Cast<object>().ToList(), dvvsGuardados, errores);
            ValidarDVVTablaDetallado("Idioma", ObtenerDALIdioma().ListarIdiomas().Cast<object>().ToList(), dvvsGuardados, errores);
            ValidarDVVTablaDetallado("Libro", dalDVV.ObtenerLibros().Cast<object>().ToList(), dvvsGuardados, errores);
            return errores;
        }

        private void ValidarDVVTablaDetallado(
            string nombreTabla,
            List<object> registros,
            List<ServicioDVV> dvvsGuardados,
            List<ServicioErrorIntegridad> errores)
        {
            string dvvCalculado = CalcularDVV(nombreTabla, registros);
            string dvvGuardado = dvvsGuardados.FirstOrDefault(d => d.NombreTabla == nombreTabla)?.Digito;

            if (dvvGuardado != dvvCalculado)
            {
                errores.Add(new ServicioErrorIntegridad
                {
                    Tabla = nombreTabla,
                    Registro = "Tabla completa",
                    TipoError = "DVV incorrecto",
                    ValorEsperado = dvvCalculado,
                    ValorActual = dvvGuardado
                });
            }
        }

        private string ObtenerIdentificadorRegistro(object registro)
        {
            string[] posiblesIds =
            {
                "DNI",
                "IdPerfil",
                "IdFamilia",
                "IdPermiso",
                "IdEvento",
                "IdFamiliaPadre",
                "IdFamiliaHijo",
                "IdIdioma",
                "ISBN_657SGA"
            };

            List<string> partes = new List<string>();

            foreach (string nombrePropiedad in posiblesIds)
            {
                var propiedad = registro.GetType().GetProperty(nombrePropiedad);

                if (propiedad != null)
                {
                    object valor = propiedad.GetValue(registro);

                    if (valor != null)
                    {
                        partes.Add(nombrePropiedad + ": " + valor);
                    }
                }
            }

            if (partes.Count == 0)
            {
                return registro.ToString();
            }

            return string.Join(" | ", partes);
        }
    }
}
