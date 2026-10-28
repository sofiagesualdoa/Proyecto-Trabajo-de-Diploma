using BE;
using DAL;
using Servicios;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class BLLLibroCambios
    {
        private readonly DALLibroCambios dalCambios = new DALLibroCambios();
        private readonly ServicioEvento bitacora = new ServicioEvento();
        private readonly ServicioDVV servicioDvv = new ServicioDVV();

        public List<BELibroCambios> BuscarRegistros(string isbn = null, string titulo = null, DateTime? fechaDesde = null, DateTime? fechaHasta = null)
        {
            if (fechaDesde.HasValue && fechaHasta.HasValue && fechaDesde.Value.Date > fechaHasta.Value.Date)
            {
                throw new Exception(ServicioSessionManager.GetInstance().Traducir("La fecha inicial no puede ser mayor a la fecha final."));
            }

            return dalCambios.BuscarRegistros(isbn, titulo, fechaDesde, fechaHasta);
        }

        public void Activar(BELibroCambios version)
        {
            if (version == null)
            {
                throw new ArgumentNullException(nameof(version));
            }

            if (version.Act)
            {
                throw new Exception(ServicioSessionManager.GetInstance().Traducir("La versión seleccionada ya es la versión activa vigente."));
            }

            dalCambios.ActivarCambio(version.IdLibroC, version.ISBN);
            servicioDvv.RecalcularDVHLibro();
            servicioDvv.RecalcularDVVLibro();
            bitacora.GrabarBitacora($"Rollback de versión de libro - ISBN: {version.ISBN}", "Libro", 2);
        }

        public BELibroCambios ObtenerPorId(int idLibroC)
        {
            return dalCambios.ObtenerPorId(idLibroC);
        }
    }
}
