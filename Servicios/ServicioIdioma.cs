using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ServicioIdioma : IObservable
    {
        [NoVerificar]
        public int IdIdioma { get; set; }
        public string Nombre { get; set; } 
        public string CodigoIdioma { get; set; }
        public string DVH { get; set; }

        [NoVerificar]
        public Dictionary<string, string> DiccionarioLeyendas { get; set; }

        private static readonly List<IObserver> Suscriptores = new List<IObserver>();
        private readonly IDALIdioma dalIdioma = FabricaDAL.Crear<IDALIdioma>("DALIdioma");

        public ServicioIdioma()
        {
            DiccionarioLeyendas = new Dictionary<string, string>();
        }

        public void AgregarSuscriptor(IObserver suscriptor)
        {
            if (!Suscriptores.Contains(suscriptor))
            {
                Suscriptores.Add(suscriptor);
            }
        }

        public void BorrarSuscriptor(IObserver suscriptor)
        {
            if (Suscriptores.Contains(suscriptor))
            {
                Suscriptores.Remove(suscriptor);
            }
        }

        public void NotificarSuscriptores(ServicioIdioma idioma)
        {
            foreach (var suscriptor in Suscriptores)
            {
                suscriptor.Actualizar(idioma);
            }
        }

        public List<ServicioIdioma> ListarIdiomas()
        {
            return dalIdioma.ListarIdiomas();
        }

        public void CambiarIdioma(ServicioIdioma idioma)
        {
            VerificarIdioma(idioma);
        }

        private void VerificarIdioma(ServicioIdioma idioma)
        {
            try
            {
                var usuarioLogueado = ServicioSessionManager.GetInstance().ObtenerUsuario();

                if (usuarioLogueado != null &&
                    (usuarioLogueado.IdIdioma == idioma.IdIdioma ||
                     string.Equals(usuarioLogueado.Idioma?.CodigoIdioma, idioma.CodigoIdioma, StringComparison.OrdinalIgnoreCase)))
                {
                    throw new InvalidOperationException("El idioma seleccionado ya se encuentra activo.");
                }

                if (idioma.CodigoIdioma == "en")
                {
                    idioma.DiccionarioLeyendas = dalIdioma.ObtenerTraducciones();
                }
                else
                {
                    idioma.DiccionarioLeyendas = new Dictionary<string, string>();
                }

                if (usuarioLogueado != null)
                {
                    ServicioSessionManager.GetInstance().CambiarIdiomaSesion(idioma.CodigoIdioma);
                    usuarioLogueado.IdIdioma = idioma.IdIdioma;
                    usuarioLogueado.Idioma = idioma;
                }

                NotificarSuscriptores(idioma);

                ServicioEvento bllEvento = new ServicioEvento();
                bllEvento.GrabarBitacora("Cambio de Idioma", "Idioma cambiado con éxito", 1);
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw new InvalidOperationException("MensajeErrorDeCarga");
            }
        }

        public Dictionary<string, string> ObtenerTraducciones()
        {
            return dalIdioma.ObtenerTraducciones();
        }

        public string TraducirTexto(string textoBase)
        {
            try
            {
                var usuarioLogueado = ServicioSessionManager.GetInstance().ObtenerUsuario();
                if (usuarioLogueado?.Idioma?.DiccionarioLeyendas != null &&
                    usuarioLogueado.Idioma.DiccionarioLeyendas.ContainsKey(textoBase))
                {
                    return usuarioLogueado.Idioma.DiccionarioLeyendas[textoBase];
                }
            }
            catch { }

            return textoBase;
        }
    }
}
