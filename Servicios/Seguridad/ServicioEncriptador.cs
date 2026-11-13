using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ServicioEncriptador
    {
        private static readonly byte[] AesKey = Encoding.UTF8.GetBytes("BooklySecretKey2026SecureAES256!");
        private static readonly byte[] AesIV = Encoding.UTF8.GetBytes("BooklyIV2026Init");

        public string Encriptar(string texto)
        {
            if (string.IsNullOrEmpty(texto)) return string.Empty;
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytesOriginales = Encoding.UTF8.GetBytes(texto);
                byte[] bytesHasheados = sha256.ComputeHash(bytesOriginales);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < bytesHasheados.Length; i++)
                {
                    sb.Append(bytesHasheados[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        public string EncriptarBase64(string texto)
        {
            if (string.IsNullOrEmpty(texto)) return string.Empty;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytesOriginales = Encoding.UTF8.GetBytes(texto);
                byte[] bytesHasheados = sha256.ComputeHash(bytesOriginales);
                return Convert.ToBase64String(bytesHasheados);
            }
        }

        public string EncriptarAES(string textoPlano)
        {
            if (string.IsNullOrWhiteSpace(textoPlano)) return textoPlano;
            if (EsTextoCifradoAES(textoPlano)) return textoPlano;

            using (Aes aes = Aes.Create())
            {
                aes.Key = AesKey;
                aes.IV = AesIV;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    using (StreamWriter sw = new StreamWriter(cs, Encoding.UTF8))
                    {
                        sw.Write(textoPlano);
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        public string DescifrarAES(string textoCifrado)
        {
            if (string.IsNullOrWhiteSpace(textoCifrado)) return textoCifrado;

            try
            {
                byte[] buffer = Convert.FromBase64String(textoCifrado);
                if (buffer.Length == 0 || buffer.Length % 16 != 0) return textoCifrado;

                using (Aes aes = Aes.Create())
                {
                    aes.Key = AesKey;
                    aes.IV = AesIV;
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;

                    using (ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                    using (MemoryStream ms = new MemoryStream(buffer))
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    using (StreamReader sr = new StreamReader(cs, Encoding.UTF8))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
            catch
            {
                return textoCifrado;
            }
        }

        public bool EsTextoCifradoAES(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return false;

            try
            {
                byte[] buffer = Convert.FromBase64String(texto);
                if (buffer.Length == 0 || buffer.Length % 16 != 0) return false;

                string descifrado = DescifrarAES(texto);
                return descifrado != texto && !string.IsNullOrEmpty(descifrado);
            }
            catch
            {
                return false;
            }
        }
    }
}