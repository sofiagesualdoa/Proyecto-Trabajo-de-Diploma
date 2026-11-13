namespace BE
{
    public class BEItemAyuda
    {
        public string ClaveModulo { get; set; } = string.Empty;
        public string TituloModulo { get; set; } = string.Empty;
        public string Objetivo { get; set; } = string.Empty;
        public string Pasos { get; set; } = string.Empty;
        public string ControlesAtajos { get; set; } = string.Empty;
        public string ReglasSeguridad { get; set; } = string.Empty;

        public override string ToString()
        {
            return TituloModulo;
        }
    }
}
