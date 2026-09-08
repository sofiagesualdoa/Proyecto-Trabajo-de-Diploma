using BE;
using DAL;
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
        ServicioEvento bitacora = new ServicioEvento();
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
            libro.Activo_657SGA = true;
            libro.DVH = generador.GenerarDVH(libro);
            dal.GuardarLibro(libro);
            new ServicioDVV().RecalcularDVVLibro();
            bitacora.GrabarBitacora("Crear Libro", "Libro", 2);
        }

        public List<BELibro> ObtenerLibros()
        {
            return dal.ObtenerLibros();
        }

        public List<BELibro> ObtenerLibrosActivos()
        {
            return dal.ObtenerLibros().Where(l => l.Activo_657SGA).ToList();
        }

        public List<BELibro> FiltrarLibros(string criterio)
        {
            return dal.BuscarLibros(criterio);
        }

        public void ActivarDesactivarLibro(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn))
            {
                throw new Exception(ServicioSessionManager.GetInstance().Traducir("El ISBN no es válido."));
            }
            BELibro existente = dal.BuscarLibroPorISBN_657SGA(isbn);
            if (existente == null)
            {
                throw new Exception(ServicioSessionManager.GetInstance().Traducir("El libro especificado no existe."));
            }

            existente.Activo_657SGA = !existente.Activo_657SGA;
            existente.DVH = generador.GenerarDVH(existente);
            dal.ModificarEstadoLibro(existente.ISBN_657SGA, existente.Activo_657SGA, existente.DVH);
            new ServicioDVV().RecalcularDVVLibro();

            string accion = existente.Activo_657SGA ? "Activar Libro" : "Desactivar Libro";
            bitacora.GrabarBitacora(accion, "Libro", 2);
        }

        public void BajaLibro(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn))
            {
                throw new Exception(ServicioSessionManager.GetInstance().Traducir("El ISBN no es válido."));
            }
            BELibro existente = dal.BuscarLibroPorISBN_657SGA(isbn);
            if (existente == null)
            {
                throw new Exception(ServicioSessionManager.GetInstance().Traducir("El libro que intenta dar de baja no existe."));
            }
            if (!existente.Activo_657SGA)
            {
                throw new Exception(ServicioSessionManager.GetInstance().Traducir("El libro ya se encuentra dado de baja."));
            }
            existente.Activo_657SGA = false;
            existente.DVH = generador.GenerarDVH(existente);
            dal.BajaLogicaLibro(existente.ISBN_657SGA, existente.DVH);
            new ServicioDVV().RecalcularDVVLibro();
            bitacora.GrabarBitacora("Baja de Libro", "Libro", 2);
        }

        public void ModificarLibro(BELibro libroModificado, string isbnOriginal)
        {
            if (string.IsNullOrWhiteSpace(libroModificado.Título_657SGA) ||
                string.IsNullOrWhiteSpace(libroModificado.Editorial_657SGA) ||
                string.IsNullOrWhiteSpace(libroModificado.Autor_657SGA) ||
                string.IsNullOrWhiteSpace(libroModificado.ISBN_657SGA))
            {
                throw new Exception(ServicioSessionManager.GetInstance().Traducir("Debe completar todos los campos."));
            }

            if (libroModificado.Precio_657SGA <= 0)
            {
                throw new Exception(ServicioSessionManager.GetInstance().Traducir("El precio debe ser mayor a cero."));
            }

            if (libroModificado.Existencias_657SGA < 0)
            {
                throw new Exception(ServicioSessionManager.GetInstance().Traducir("La cantidad de existencias no puede ser negativa."));
            }

            BELibro existente = dal.BuscarLibroPorISBN_657SGA(isbnOriginal);
            if (existente == null)
            {
                throw new Exception(ServicioSessionManager.GetInstance().Traducir("El libro que intenta modificar no existe."));
            }

            if (!string.Equals(libroModificado.ISBN_657SGA, isbnOriginal, StringComparison.OrdinalIgnoreCase))
            {
                BELibro libroConNuevoIsbn = dal.BuscarLibroPorISBN_657SGA(libroModificado.ISBN_657SGA);
                if (libroConNuevoIsbn != null)
                {
                    throw new Exception(ServicioSessionManager.GetInstance().Traducir("Ya existe un libro con ese ISBN_657SGA."));
                }
            }

            libroModificado.Activo_657SGA = existente.Activo_657SGA;
            libroModificado.DVH = generador.GenerarDVH(libroModificado);
            dal.ModificarLibro(libroModificado, isbnOriginal);
            new ServicioDVV().RecalcularDVVLibro();
            bitacora.GrabarBitacora("Modificar Libro", "Libro", 2);
        }

        public int VerificarUnidades(BELibro libro)
        {
            int existencias = 0;
            if (libro != null) existencias = libro.Existencias_657SGA;
            return existencias;
        }
    }
}
