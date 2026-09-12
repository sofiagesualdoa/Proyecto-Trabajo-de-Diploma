using System;
using System.Collections.Generic;

namespace Servicios
{
    public interface IDALBackUp
    {
        void EjecutarBackup(string connectionString, ServicioBackUp backup);
        void EjecutarRestore(string rutaCompletaArchivo);
    }
}
