using BE;
using BLL;
using DAL;
using Microsoft.VisualBasic;
using Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Venta_Productos_Cosméticos
{
    public partial class FormVenta : Form, IObserver
    {
        private ServicioIdioma bllIdioma = new ServicioIdioma();
        private BLLLibro bllLibro = new BLLLibro();
        private BLLCarrito bllCarrito = new BLLCarrito();
        private BLLCliente bllCliente = new BLLCliente();
        private Dictionary<Control, string> textosOriginales = new Dictionary<Control, string>();
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        private const int EM_SETCUEBANNER = 0x1501;
        public FormVenta()
        {
            InitializeComponent();
        }
        private void FormVenta_Load(object sender, EventArgs e)
        {
            dataGridViewLibros.ReadOnly = true;
            dataGridViewLibros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewLibros.MultiSelect = false;
            dataGridViewCarrito.ReadOnly = true;
            dataGridViewCarrito.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCarrito.MultiSelect = false;
            RegistrarTextos(this.Controls);
            bllIdioma.AgregarSuscriptor(this);
            MostrarGrilla(bllLibro.ObtenerLibros());
            ActualizarCarrito();
            var usuario = ServicioSessionManager.GetInstance().ObtenerUsuario();
            if (usuario != null && usuario.Idioma != null)
            {
                Actualizar(usuario.Idioma);
            }
            ConfigurarPlaceholder();
            this.BeginInvoke((Action)(() => this.ActiveControl = null));
        }
        private void ConfigurarPlaceholder()
        {
            string textoBuscar = ServicioSessionManager.GetInstance().Traducir("Buscar por Título, Autor, ISBN...");
            textBox1_657SGA.PlaceholderText = textoBuscar;
            if (textBox1_657SGA.IsHandleCreated)
            {
                SendMessage(textBox1_657SGA.Handle, EM_SETCUEBANNER, 1, textoBuscar);
            }
        }
        private void RegistrarTextos(Control.ControlCollection controles)
        {
            foreach (Control c in controles)
            {
                if (!string.IsNullOrEmpty(c.Text))
                    textosOriginales[c] = c.Text;
                if (c.Controls.Count > 0) RegistrarTextos(c.Controls);
            }
        }
        public void Actualizar(ServicioIdioma idioma)
        {
            ActualizarIdioma(idioma);
        }
        private void ActualizarIdioma(ServicioIdioma idioma)
        {
            var leyendas = idioma.DiccionarioLeyendas;
            foreach (var entry in textosOriginales)
            {
                Control ctrl = entry.Key;
                string textoBase = entry.Value;
                if (leyendas != null && leyendas.ContainsKey(textoBase))
                    ctrl.Text = leyendas[textoBase];
                else
                    ctrl.Text = textoBase;
            }
            TraducirHeadersLibros(leyendas);
            TraducirHeadersCarrito();
            ConfigurarPlaceholder();
            ActualizarTotal();
        }
        private void MostrarGrilla(Object lista)
        {
            dataGridViewLibros.DataSource = null;
            dataGridViewLibros.DataSource = lista;
            if (dataGridViewLibros.Columns["Activo_657SGA"] != null)
                dataGridViewLibros.Columns["Activo_657SGA"].Visible = false;
            if (dataGridViewLibros.Columns["DVH"] != null)
                dataGridViewLibros.Columns["DVH"].Visible = false;
            if (dataGridViewLibros.Columns["Existencias_657SGA"] != null)
                dataGridViewLibros.Columns["Existencias_657SGA"].Visible = false;
            var usuarioActivo = ServicioSessionManager.GetInstance().ObtenerUsuario();
            TraducirHeadersLibros(usuarioActivo?.Idioma?.DiccionarioLeyendas);
        }
        private void TraducirHeadersLibros(Dictionary<string, string> leyendas)
        {
            if (dataGridViewLibros.DataSource == null || dataGridViewLibros.Columns.Count == 0) return;
            foreach (DataGridViewColumn columna in dataGridViewLibros.Columns)
            {
                columna.HeaderText = columna.Name.Replace("_657SGA", "");
                if (leyendas != null && leyendas.ContainsKey(columna.Name))
                {
                    columna.HeaderText = leyendas[columna.Name];
                }
            }
        }
        private void TraducirHeadersCarrito()
        {
            if (dataGridViewCarrito.DataSource == null || dataGridViewCarrito.Columns.Count == 0) return;
            var session = ServicioSessionManager.GetInstance();
            if (dataGridViewCarrito.Columns["Título"] != null)
                dataGridViewCarrito.Columns["Título"].HeaderText = session.Traducir("Título");
            if (dataGridViewCarrito.Columns["Autor"] != null)
                dataGridViewCarrito.Columns["Autor"].HeaderText = session.Traducir("Autor");
            if (dataGridViewCarrito.Columns["PrecioUnitario"] != null)
                dataGridViewCarrito.Columns["PrecioUnitario"].HeaderText = session.Traducir("Precio Unitario");
            if (dataGridViewCarrito.Columns["Cantidad"] != null)
                dataGridViewCarrito.Columns["Cantidad"].HeaderText = session.Traducir("Cantidad");
            if (dataGridViewCarrito.Columns["Subtotal"] != null)
                dataGridViewCarrito.Columns["Subtotal"].HeaderText = session.Traducir("Subtotal");
        }
        private void btnConsultar_657SGA_Click(object sender, EventArgs e)
        {
            var listaFiltrada = bllLibro.FiltrarLibros(textBox1_657SGA.Text);
            MostrarGrilla(listaFiltrada.Where(l => l.Activo_657SGA).ToList());
        }
        private void btnLimpiar_657SGA_Click(object sender, EventArgs e)
        {
            textBox1_657SGA.Clear();
            btnConsultar_657SGA_Click(sender, e);
        }
        private void btnSalir_657SGA_Click(object sender, EventArgs e)
        {
            FormSistema frmMenu = new FormSistema();
            frmMenu.Show();
            this.Close();
        }
        private void btnAgregar_657SGA_Click(object sender, EventArgs e)
        {
            var s = ServicioSessionManager.GetInstance();
            try
            {
                if (dataGridViewLibros.SelectedRows.Count == 0)
                    throw new Exception(s.Traducir("Debe seleccionar un libro del catálogo para agregarlo al carrito."));
                var libroSeleccionado = (BELibro)dataGridViewLibros.SelectedRows[0].DataBoundItem;
                string prompt = s.Traducir("Ingrese la cantidad a agregar al carrito:");
                string titulo = s.Traducir("Cantidad");
                string cantidadStr = Interaction.InputBox(prompt, titulo, "");
                if (string.IsNullOrWhiteSpace(cantidadStr)) return;
                if (!int.TryParse(cantidadStr, out int cantidadDeseada) || cantidadDeseada <= 0)
                    throw new Exception(s.Traducir("La cantidad debe ser numérica y mayor a cero."));
                bllCarrito.AgregarLibro(libroSeleccionado, cantidadDeseada);
                ActualizarCarrito();
            }
            catch (Exception ex)
            {
                MessageBox.Show(s.Traducir("Error al agregar el libro al carrito: ") + ex.Message,
                                s.Traducir("Error"),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
        private void ActualizarCarrito()
        {
            dataGridViewCarrito.DataSource = null;
            dataGridViewCarrito.DataSource = bllCarrito.ObtenerDetalles().ToList();
            if (dataGridViewCarrito.Columns["IdCarrito"] != null)
                dataGridViewCarrito.Columns["IdCarrito"].Visible = false;
            if (dataGridViewCarrito.Columns["ISBN"] != null)
                dataGridViewCarrito.Columns["ISBN"].Visible = false;
            if (dataGridViewCarrito.Columns["DVH"] != null)
                dataGridViewCarrito.Columns["DVH"].Visible = false;
            if (dataGridViewCarrito.Columns["Libro"] != null)
                dataGridViewCarrito.Columns["Libro"].Visible = false;
            if (dataGridViewCarrito.Columns["PrecioUnitario"] != null)
                dataGridViewCarrito.Columns["PrecioUnitario"].DefaultCellStyle.Format = "C2";
            if (dataGridViewCarrito.Columns["Subtotal"] != null)
                dataGridViewCarrito.Columns["Subtotal"].DefaultCellStyle.Format = "C2";
            TraducirHeadersCarrito();
            ActualizarTotal();
        }
        private void ActualizarTotal()
        {
            var s = ServicioSessionManager.GetInstance();
            decimal totalGeneral = bllCarrito.CalcularTotal();
            if (bllCarrito.ObtenerDetalles().Count > 0)
            {
                label3.Text = $"{s.Traducir("Total")}: ${totalGeneral:N2}";
            }
            else
            {
                label3.Text = $"{s.Traducir("Total")}: $";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var s = ServicioSessionManager.GetInstance();
            try
            {
                bllCarrito.VaciarCarrito();
                ActualizarCarrito();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                s.Traducir("Información"),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        private void btnPagar_SGA657_Click(object sender, EventArgs e)
        {
            var s = ServicioSessionManager.GetInstance();
            try
            {
                if (dataGridViewCarrito.Rows.Count == 0 || bllCarrito.ObtenerDetalles().Count == 0)
                {
                    throw new Exception("No hay libros en el carrito para iniciar la venta");
                }
                string prompt = s.Traducir("Ingrese el DNI del cliente:");
                string titulo = s.Traducir("Identificación del Cliente");
                string dniStr = Interaction.InputBox(prompt, titulo, "");
                if (string.IsNullOrWhiteSpace(dniStr) || dniStr.Length > 8 || dniStr.Length < 7)
                {
                    throw new Exception("El DNI no es válido");
                }
                if (!int.TryParse(dniStr.Trim(), out int dni))
                {
                    throw new Exception(s.Traducir("El DNI ingresado no es válido. Debe contener solo números."));
                }
                BECliente cliente = bllCliente.BuscarClientePorDNI(dni);
                if (cliente != null)
                {
                    string nombreCompleto = bllCliente.ObtenerNombreCompleto(cliente);
                    string mensajeRegistrado = $"{s.Traducir("Cliente:")} {nombreCompleto}";
                    MessageBox.Show(mensajeRegistrado,
                                    s.Traducir("Cliente Registrado"),
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    bllCarrito.AsociarDNI(cliente.DNI_657SGA);
                    ContinuarConPago(cliente);
                }
                else
                {
                    MessageBox.Show(s.Traducir("El cliente no se encuentra registrado en el sistema. Presione Aceptar para registrarlo."),
                                    s.Traducir("Cliente No Registrado"),
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    using (FormClientes frmClientes = new FormClientes(dni, modoVenta: true))
                    {
                        if (frmClientes.ShowDialog() == DialogResult.OK && frmClientes.AsociadoAlCarrito)
                        {
                            BECliente clienteAsociado = frmClientes.ClienteSeleccionado;
                            if (clienteAsociado != null)
                            {
                                bllCarrito.AsociarDNI(clienteAsociado.DNI_657SGA);
                                ContinuarConPago(clienteAsociado);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                s.Traducir("Información"),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        private void ContinuarConPago(BECliente cliente)
        {
            var s = ServicioSessionManager.GetInstance();
            decimal total = bllCarrito.CalcularTotal();
            string nombreCompleto = bllCliente.ObtenerNombreCompleto(cliente);
            MessageBox.Show(string.Format(s.Traducir("Cliente {0} asociado correctamente al carrito. Total a cobrar: ${1:N2}"), nombreCompleto, total),
                            s.Traducir("Venta Lista para Cobro"),
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }
    }
}