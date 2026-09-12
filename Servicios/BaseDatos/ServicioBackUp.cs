using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Servicios
{
    public class ServicioBackUp
    {
        public string PathDestino { get; set; }
        public string NombreArchivo { get; set; }
        public DateTime Fecha { get; set; }


        private IDALBackUp dalBackUp = FabricaDAL.Crear<IDALBackUp>("DALBackUp");
        private ServicioEvento bitacora = new ServicioEvento();

        string cadena = "Data Source=.;Initial Catalog=EverGlow;Integrated Security=True;Trust Server Certificate=True";
        public void RealizarBackup(string carpetaBackup)
        {
            if (!Directory.Exists(carpetaBackup))
            {
                throw new DirectoryNotFoundException(ServicioSessionManager.GetInstance().Traducir("El directorio destino no existe o no es accesible."));
            }
            ServicioBackUp backup = new ServicioBackUp();
            backup.PathDestino = carpetaBackup;
            backup.NombreArchivo = $"Backup_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
            dalBackUp.EjecutarBackup(cadena, backup);
            bitacora.GrabarBitacora("Creación de backup", "Respaldos", 1);
        }

        public void RealizarRestore(string carpetaBackup)
        {
            if (!File.Exists(carpetaBackup) || Path.GetExtension(carpetaBackup).ToLower() != ".bak")
            {
                throw new ArgumentException(ServicioSessionManager.GetInstance().Traducir("El archivo seleccionado no es un backup válido o está corrupto."));
            }
            dalBackUp.EjecutarRestore(carpetaBackup);
            bitacora.GrabarBitacora("Realizar Restore", "Respaldos", 1);
        }
    }
    
}
