using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ServicioEvento
    {
        [NoVerificar]
        public int IdEvento { get; set; }
        public string Login { get; set; }
        public int Criticidad { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public string NombreEvento { get; set; }
        public string Modulo { get; set; }
        public int DNI { get; set; }
        public string DVH { get; set; }

        private readonly IDALEvento dalEvento = FabricaDAL.Crear<IDALEvento>("DALEvento");
        private readonly GeneradorDigVerificador generador = new GeneradorDigVerificador();

        public void GrabarBitacora(string accion, string modulo, int nivelCriticidad)
        {
            ServicioEvento registro = new ServicioEvento();
            registro.NombreEvento = accion;
            registro.Modulo = modulo;
            registro.Criticidad = nivelCriticidad;
            registro.Fecha = DateTime.Today;
            registro.Hora = DateTime.Now.TimeOfDay;

            ServicioUsuario usuarioActivo = ServicioSessionManager.GetInstance().ObtenerUsuario();
            if (usuarioActivo != null)
            {
                registro.Login = usuarioActivo.nombreUsuario;
                registro.DNI = usuarioActivo.DNI;
            }
            else
            {
                registro.Login = "Desconocido";
                registro.DNI = 0;
            }
            registro.DVH = generador.GenerarDVH(registro);
            dalEvento.RegistrarEvento(registro);
            new ServicioDVV().RecalcularDVVEvento();
        }

        public List<ServicioEvento> ConsultarEventosPorDefecto()
        {
            DateTime fechaFiltro = DateTime.Today.AddDays(-3);
            return dalEvento.ObtenerEventos(fechaFiltro);
        }

        public List<ServicioEvento> ObtenerEventos(DateTime fechaDesde)
        {
            return dalEvento.ObtenerEventos(fechaDesde);
        }
    }
}
