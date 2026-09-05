using BE;
using DAL;
using DALs;
using Microsoft.VisualBasic;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLLibro
    {
        BLLEvento bitacora = new BLLEvento();
        DALLibro dal = new DALLibro();
        private readonly GeneradorDigVerificador generador = new GeneradorDigVerificador();

        public void CrearLibro(BELibro libro)
        {
            if (string.IsNullOrWhiteSpace(libro.Título_657SGA) ||
                string.IsNullOrWhiteSpace(libro.Editorial_657SGA) ||
                string.IsNullOrWhiteSpace(libro.Autor_657SGA) ||
                string.IsNullOrWhiteSpace(libro.ISBN_657SGA) ||
                string.IsNullOrWhiteSpace(libro.Precio_657SGA.ToString()) ||
                string.IsNullOrWhiteSpace(libro.Existencias_657SGA.ToString()))
            {
                throw new Exception(ServicioSessionManager.GetInstance().Traducir("Debe completar todos los campos."));
            }

            BELibro existente = dal.BuscarLibroPorISBN_657SGA(libro.ISBN_657SGA);
            if (existente != null)
            {
                throw new Exception(ServicioSessionManager.GetInstance().Traducir("Ya existe un libro con ese ISBN_657SGA."));
            }
            libro.DVH = generador.GenerarDVH(libro);
            dal.GuardarLibro(libro);
            new BLLDVV().RecalcularDVVLibro();
            bitacora.GrabarBitacora("Crear Libro", "Libro", 2);
        }

        public List<BELibro> ObtenerLibros()
        {
            return dal.ObtenerLibros();
        }

        public List<BELibro> FiltrarLibros(string criterio)
        {
            return dal.BuscarLibros(criterio);
        }
    }
}
