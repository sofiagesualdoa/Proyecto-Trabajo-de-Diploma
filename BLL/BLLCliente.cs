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
            return dal.BuscarClientePorDNI(dni);
        }
        public List<BECliente> ObtenerClientes()
        {
            return dal.ObtenerClientes();
        }
        public List<BECliente> ObtenerClientesActivos()
        {
            return dal.ObtenerClientes().Where(c => c.Activo_657SGA).ToList();
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
            cliente.DVH = generador.GenerarDVH(cliente);
            dal.GuardarCliente(cliente);
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
            return dal.BuscarClientes(dni, nombre, apellido, email, telefono, direccion, soloActivos);
        }
    }
}
