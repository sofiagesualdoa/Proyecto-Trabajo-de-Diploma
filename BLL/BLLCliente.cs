using BE;
using DAL;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLCliente
    {
        private readonly DALCliente dal = new DALCliente();
        private readonly ServicioEvento bitacora = new ServicioEvento();
        private readonly GeneradorDigVerificador generador = new GeneradorDigVerificador();
        private readonly ServicioEncriptador encriptador = new ServicioEncriptador();

        public string ObtenerNombreCompleto(BECliente cliente)
        {
            string nom = string.Empty;
            if (cliente != null) nom = $"{cliente.Nombre_657SGA} {cliente.Apellido_657SGA}".Trim();
            return nom;
        }

        public BECliente BuscarClientePorDNI(int dni)
        {
            if (dni <= 0)
            {
                throw new Exception(ServicioSessionManager.GetInstance().Traducir("El DNI ingresado no es válido."));
            }
            BECliente cli = dal.BuscarClientePorDNI(dni);
            ProcesarSeguridadDireccion(cli);
            return cli;
        }

        public List<BECliente> ObtenerClientes()
        {
            List<BECliente> lista = dal.ObtenerClientes();
            ProcesarSeguridadDireccion(lista);
            return lista;
        }

        public List<BECliente> ObtenerClientesActivos()
        {
            List<BECliente> lista = dal.ObtenerClientes().Where(c => c.Activo_657SGA).ToList();
            ProcesarSeguridadDireccion(lista);
            return lista;
        }

        public void CrearCliente(BECliente cliente)
        {
            var session = ServicioSessionManager.GetInstance();
            BECliente existente = dal.BuscarClientePorDNI(cliente.DNI_657SGA);
            if (existente != null)
            {
                throw new Exception(session.Traducir("Ya existe un cliente registrado con ese número de DNI."));
            }
            cliente.Activo_657SGA = true;
            cliente.Dirección_657SGA = encriptador.EncriptarAES(cliente.Dirección_657SGA);
            cliente.DVH = generador.GenerarDVH(cliente);
            dal.CrearCliente(cliente);
            bitacora.GrabarBitacora("Alta de Cliente", "Cliente", 3);
        }

        public void ModificarCliente(BECliente clienteModificado, int dniOriginal)
        {
            var session = ServicioSessionManager.GetInstance();
            BECliente original = dal.BuscarClientePorDNI(dniOriginal);
            if (original == null)
            {
                throw new Exception(session.Traducir("El cliente que intenta modificar no existe."));
            }
            if (clienteModificado.DNI_657SGA != dniOriginal)
            {
                BECliente duplicado = dal.BuscarClientePorDNI(clienteModificado.DNI_657SGA);
                if (duplicado != null)
                    throw new Exception(session.Traducir("Ya existe otro cliente con el nuevo DNI especificado."));
            }

            bool esGerente = session.EsUsuarioGerente();
            if (!esGerente || string.IsNullOrWhiteSpace(clienteModificado.Dirección_657SGA) || clienteModificado.Dirección_657SGA.StartsWith("["))
            {
                clienteModificado.Dirección_657SGA = original.Dirección_657SGA;
            }
            else
            {
                clienteModificado.Dirección_657SGA = encriptador.EncriptarAES(clienteModificado.Dirección_657SGA);
            }

            clienteModificado.Activo_657SGA = original.Activo_657SGA;
            clienteModificado.DVH = generador.GenerarDVH(clienteModificado);
            dal.ModificarCliente(clienteModificado, dniOriginal);
            bitacora.GrabarBitacora("Modificar Cliente", "Cliente", 3);
        }

        public void ActivarDesactivarCliente(int dni)
        {
            BECliente existente = dal.BuscarClientePorDNI(dni);
            if (existente == null)
            {
                throw new Exception(ServicioSessionManager.GetInstance().Traducir("El cliente no existe."));
            }
            existente.Activo_657SGA = !existente.Activo_657SGA;
            existente.DVH = generador.GenerarDVH(existente);
            dal.ModificarEstadoCliente(existente.DNI_657SGA, existente.Activo_657SGA, existente.DVH);
            string accion = existente.Activo_657SGA ? "Activar Cliente" : "Desactivar Cliente";
            bitacora.GrabarBitacora(accion, "Cliente", 3);
        }

        public List<BECliente> FiltrarClientes(string dni, string nombre, string apellido, string email, string telefono, string direccion, bool? soloActivos)
        {
            List<BECliente> lista = dal.BuscarClientes(dni, nombre, apellido, email, telefono, null, soloActivos);
            ProcesarSeguridadDireccion(lista);
            if (!string.IsNullOrWhiteSpace(direccion) && ServicioSessionManager.GetInstance().EsUsuarioGerente())
            {
                lista = lista.Where(c => !string.IsNullOrEmpty(c.Dirección_657SGA) &&
                                         c.Dirección_657SGA.IndexOf(direccion.Trim(), StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }
            return lista;
        }

        private void ProcesarSeguridadDireccion(BECliente cliente)
        {
            if (cliente == null) return;
            bool esGerente = ServicioSessionManager.GetInstance().EsUsuarioGerente();
            if (esGerente)
            {
                cliente.Dirección_657SGA = encriptador.DescifrarAES(cliente.Dirección_657SGA);
            }
            else
            {
                cliente.Dirección_657SGA = ServicioSessionManager.GetInstance().Traducir("[Dato Protegido - Solo Gerente]");
            }
        }

        private void ProcesarSeguridadDireccion(List<BECliente> clientes)
        {
            if (clientes == null) return;
            foreach (var c in clientes)
            {
                ProcesarSeguridadDireccion(c);
            }
        }
    }
}