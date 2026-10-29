using BE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace BLL
{
    public class BLLDeserializarCliente
    {
        public List<BECliente> Deserializar(string rutaArchivo)
        {
            if (string.IsNullOrWhiteSpace(rutaArchivo))
            {
                throw new ArgumentException("La ruta del archivo no puede estar vacía.", nameof(rutaArchivo));
            }

            if (!File.Exists(rutaArchivo))
            {
                throw new FileNotFoundException("El archivo XML especificado no existe.", rutaArchivo);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<BECliente>));
            using (StreamReader reader = new StreamReader(rutaArchivo, System.Text.Encoding.UTF8))
            {
                var resultado = serializer.Deserialize(reader) as List<BECliente>;
                return resultado ?? new List<BECliente>();
            }
        }
    }
}
