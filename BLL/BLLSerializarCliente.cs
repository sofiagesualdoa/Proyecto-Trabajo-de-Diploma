using BE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace BLL
{
    public class BLLSerializarCliente
    {
        public void Serializar(List<BECliente> clientes, string rutaArchivo)
        {
            if (clientes == null)
            {
                throw new ArgumentNullException(nameof(clientes));
            }

            if (string.IsNullOrWhiteSpace(rutaArchivo))
            {
                throw new ArgumentException("La ruta del archivo no puede estar vacía.", nameof(rutaArchivo));
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<BECliente>));
            using (StreamWriter writer = new StreamWriter(rutaArchivo, false, System.Text.Encoding.UTF8))
            {
                serializer.Serialize(writer, clientes);
            }
        }
    }
}
