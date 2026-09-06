using System;
using System.IO;
using System.Reflection;

namespace Servicios
{
    public static class FabricaDAL
    {
        public static T Crear<T>(string nombreTipo) where T : class
        {
            Type tipo = Type.GetType($"DAL.{nombreTipo}, DAL") ?? Type.GetType($"DALs.{nombreTipo}, DAL");

            if (tipo == null)
            {
                try
                {
                    Assembly asm = Assembly.Load("DAL");
                    tipo = asm.GetType($"DAL.{nombreTipo}") ?? asm.GetType($"DALs.{nombreTipo}");
                }
                catch
                {
                }
            }

            if (tipo == null)
            {
                foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
                {
                    tipo = asm.GetType($"DAL.{nombreTipo}") ?? asm.GetType($"DALs.{nombreTipo}");
                    if (tipo != null) break;
                }
            }

            if (tipo == null)
            {
                try
                {
                    string rutaDll = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DAL.dll");
                    if (File.Exists(rutaDll))
                    {
                        Assembly asm = Assembly.LoadFrom(rutaDll);
                        tipo = asm.GetType($"DAL.{nombreTipo}") ?? asm.GetType($"DALs.{nombreTipo}");
                    }
                }
                catch
                {
                }
            }

            if (tipo != null)
            {
                return (T)Activator.CreateInstance(tipo)!;
            }

            throw new InvalidOperationException($"No se pudo instanciar la clase de acceso a datos '{nombreTipo}'. Verifique que DAL.dll esté disponible.");
        }
    }
}
