using System;

namespace BE
{
    public class BELibroCambios
    {
        public int IdLibroC { get; set; }
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public decimal Precio { get; set; }
        public int Existencias { get; set; }
        public int ExistenciasPrestamo { get; set; }
        public string Editorial { get; set; }
        public string Autor { get; set; }
        public bool EsParaPrestamo { get; set; }
        public bool Activo { get; set; }
        public string DVH { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public bool Act { get; set; }
    }
}
