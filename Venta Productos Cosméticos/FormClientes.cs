using BE;
using BLL;
using Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Venta_Productos_Cosméticos
{
    public partial class FormClientes : Form, IObserver
    {
        private readonly BLLCliente bllCliente = new BLLCliente();
        private readonly ServicioIdioma bllIdioma = new ServicioIdioma();
        private readonly Dictionary<Control, string> textosOriginales = new Dictionary<Control, string>();
        public BECliente ClienteSeleccionado { get; private set; }
        public bool AsociadoAlCarrito { get; private set; } = false;
        private readonly int? dniPrecargado;
        private readonly bool modoAsociarVenta;
        public FormClientes()
        {
            InitializeComponent();
        }

        public FormClientes(int? dniInicial, bool modoVenta = false) : this()
        {
            dniPrecargado = dniInicial;
            modoAsociarVenta = modoVenta;
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            RegistrarTextos(this.Controls);
            bllIdioma.AgregarSuscriptor(this);
            var usuario = ServicioSessionManager.GetInstance().ObtenerUsuario();
            if (usuario?.Idioma != null)
            {
                Actualizar(usuario.Idioma);
            }
            rbtnActivos_SGA657.Checked = true;
            CargarGrilla();
            if (dniPrecargado.HasValue && dniPrecargado.Value > 0)
            {
                txtDNI_SGA657.Text = dniPrecargado.Value.ToString();
                txtDNI_SGA657.ReadOnly = true;
                txtNombre_SGA657.Focus();
            }
            if (modoAsociarVenta)
            {
                btnModificar_SGA657.Enabled = false;
                btnActDesact_SGA657.Enabled = false;
                btnConsultar_SGA657.Enabled = false;
                rbtnTodos_SGA657.Enabled = false;
                rbtnActivos_SGA657.Enabled = false;
                btnAgregar_SGA657.Enabled = true;
                btnSalir_SGA657.Enabled = false;
            }
        }

        private void CargarGrilla()
        {
            try
            {
                List<BECliente> lista = rbtnActivos_SGA657.Checked
                    ? bllCliente.ObtenerClientesActivos()
                    : bllCliente.ObtenerClientes();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = lista;
                if (dataGridView1.Columns["DVH"] != null)
                    dataGridView1.Columns["DVH"].Visible = false;
                TraducirHeaders();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TraducirHeaders()
        {
            if (dataGridView1.DataSource == null || dataGridView1.Columns.Count == 0) return;
            var s = ServicioSessionManager.GetInstance();
            if (dataGridView1.Columns["DNI_657SGA"] != null)
                dataGridView1.Columns["DNI_657SGA"].HeaderText = s.Traducir("DNI");
            if (dataGridView1.Columns["Nombre_657SGA"] != null)
                dataGridView1.Columns["Nombre_657SGA"].HeaderText = s.Traducir("Nombre");
            if (dataGridView1.Columns["Apellido_657SGA"] != null)
                dataGridView1.Columns["Apellido_657SGA"].HeaderText = s.Traducir("Apellido");
            if (dataGridView1.Columns["Email_657SGA"] != null)
                dataGridView1.Columns["Email_657SGA"].HeaderText = s.Traducir("Email");
            if (dataGridView1.Columns["Teléfono_657SGA"] != null)
                dataGridView1.Columns["Teléfono_657SGA"].HeaderText = s.Traducir("Teléfono");
            if (dataGridView1.Columns["Dirección_657SGA"] != null)
                dataGridView1.Columns["Dirección_657SGA"].HeaderText = s.Traducir("Dirección");
            if (dataGridView1.Columns["Activo_657SGA"] != null)
                dataGridView1.Columns["Activo_657SGA"].HeaderText = s.Traducir("Activo");
        }

        private void btnAgregar_SGA657_Click(object sender, EventArgs e)
        {
            var s = ServicioSessionManager.GetInstance();
            try
            {
                if (string.IsNullOrWhiteSpace(txtDNI_SGA657.Text) ||
                    string.IsNullOrWhiteSpace(txtNombre_SGA657.Text) ||
                    string.IsNullOrWhiteSpace(txtApellido_SGA657.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail_SGA657.Text) ||
                    string.IsNullOrWhiteSpace(txtTelefono_SGA657.Text) ||
                    string.IsNullOrWhiteSpace(txtDireccion_SGA657.Text))
                {
                    throw new Exception(s.Traducir("Debe completar todos los campos."));
                }
                if (!int.TryParse(txtDNI_SGA657.Text.Trim(), out int dni) || dni <= 0)
                    throw new Exception(s.Traducir("El DNI debe ser numérico y mayor a cero."));
                if (!int.TryParse(txtTelefono_SGA657.Text.Trim(), out int telefono) || telefono <= 0)
                    throw new Exception(s.Traducir("El teléfono debe ser numérico y válido."));
                BECliente nuevo = new BECliente
                {
                    DNI_657SGA = dni,
                    Nombre_657SGA = txtNombre_SGA657.Text.Trim(),
                    Apellido_657SGA = txtApellido_SGA657.Text.Trim(),
                    Email_657SGA = txtEmail_SGA657.Text.Trim(),
                    Teléfono_657SGA = telefono,
                    Dirección_657SGA = txtDireccion_SGA657.Text.Trim()
                };
                bllCliente.CrearCliente(nuevo);
                CargarGrilla();
                SeleccionarClienteEnGrilla(nuevo.DNI_657SGA);
                if (modoAsociarVenta)
                {
                    MessageBox.Show(
                        s.Traducir("Cliente registrado exitosamente. Ahora selecciónelo en la grilla para confirmar la asociación con el carrito de compras."),
                        s.Traducir("Cliente Registrado"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                        s.Traducir("Cliente registrado exitosamente."),
                        s.Traducir("Éxito"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, s.Traducir("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SeleccionarClienteEnGrilla(int dni)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.DataBoundItem is BECliente cli && cli.DNI_657SGA == dni)
                {
                    row.Selected = true;
                    dataGridView1.CurrentCell = row.Cells[0];
                    break;
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var s = ServicioSessionManager.GetInstance();
            if (dataGridView1.SelectedRows.Count > 0)
            {
                BECliente cli = (BECliente)dataGridView1.SelectedRows[0].DataBoundItem;
                txtDNI_SGA657.Text = cli.DNI_657SGA.ToString();
                txtNombre_SGA657.Text = cli.Nombre_657SGA;
                txtApellido_SGA657.Text = cli.Apellido_657SGA;
                txtEmail_SGA657.Text = cli.Email_657SGA;
                txtTelefono_SGA657.Text = cli.Teléfono_657SGA.ToString();
                txtDireccion_SGA657.Text = cli.Dirección_657SGA;
                if (modoAsociarVenta)
                {
                    string nombreCompleto = bllCliente.ObtenerNombreCompleto(cli);
                    string mensaje = string.Format(
                        s.Traducir("¿Desea asociar al cliente {0} (DNI: {1}) con el carrito de compras?"),
                        nombreCompleto, cli.DNI_657SGA);
                    DialogResult respuesta = MessageBox.Show(mensaje,
                                                             s.Traducir("Asociar Cliente al Carrito"),
                                                             MessageBoxButtons.YesNo,
                                                             MessageBoxIcon.Question);
                    if (respuesta == DialogResult.Yes)
                    {
                        ClienteSeleccionado = cli;
                        AsociadoAlCarrito = true;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
        }

        private void btnModificar_SGA657_Click(object sender, EventArgs e)
        {
            var s = ServicioSessionManager.GetInstance();
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                    throw new Exception(s.Traducir("Seleccione un cliente de la grilla para modificar."));
                var clienteOriginal = (BECliente)dataGridView1.SelectedRows[0].DataBoundItem;
                if (string.IsNullOrWhiteSpace(txtDNI_SGA657.Text) ||
                    string.IsNullOrWhiteSpace(txtNombre_SGA657.Text) ||
                    string.IsNullOrWhiteSpace(txtApellido_SGA657.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail_SGA657.Text) ||
                    string.IsNullOrWhiteSpace(txtTelefono_SGA657.Text) ||
                    string.IsNullOrWhiteSpace(txtDireccion_SGA657.Text))
                {
                    throw new Exception(s.Traducir("Debe completar todos los campos."));
                }
                if (!int.TryParse(txtDNI_SGA657.Text.Trim(), out int nuevoDni) || nuevoDni <= 0)
                    throw new Exception(s.Traducir("El DNI debe ser numérico y mayor a cero."));
                if (!int.TryParse(txtTelefono_SGA657.Text.Trim(), out int nuevoTel) || nuevoTel <= 0)
                    throw new Exception(s.Traducir("El teléfono debe ser numérico y válido."));
                BECliente modificado = new BECliente
                {
                    DNI_657SGA = nuevoDni,
                    Nombre_657SGA = txtNombre_SGA657.Text.Trim(),
                    Apellido_657SGA = txtApellido_SGA657.Text.Trim(),
                    Email_657SGA = txtEmail_SGA657.Text.Trim(),
                    Teléfono_657SGA = nuevoTel,
                    Dirección_657SGA = txtDireccion_SGA657.Text.Trim()
                };
                bllCliente.ModificarCliente(modificado, clienteOriginal.DNI_657SGA);
                MessageBox.Show(s.Traducir("Cliente modificado correctamente."),
                                s.Traducir("Éxito"),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                CargarGrilla();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, s.Traducir("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActDesact_SGA657_Click(object sender, EventArgs e)
        {
            var s = ServicioSessionManager.GetInstance();
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                    throw new Exception(s.Traducir("Seleccione un cliente de la grilla para activar o desactivar."));
                var cliente = (BECliente)dataGridView1.SelectedRows[0].DataBoundItem;
                bllCliente.ActivarDesactivarCliente(cliente.DNI_657SGA);
                MessageBox.Show(s.Traducir("Estado del Cliente modificado correctamente."),
                               s.Traducir("Éxito"),
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                CargarGrilla();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, s.Traducir("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConsultar_SGA657_Click(object sender, EventArgs e)
        {
            var s = ServicioSessionManager.GetInstance();
            try
            {
                bool? soloActivos = null;
                if (rbtnActivos_SGA657.Checked)
                {
                    soloActivos = true;
                }
                string dni = txtDNI_SGA657.Text.Trim();
                string nombre = txtNombre_SGA657.Text.Trim();
                string apellido = txtApellido_SGA657.Text.Trim();
                string email = txtEmail_SGA657.Text.Trim();
                string telefono = txtTelefono_SGA657.Text.Trim();
                string direccion = txtDireccion_SGA657.Text.Trim();
                List<BECliente> resultados = bllCliente.FiltrarClientes(
                    dni, nombre, apellido, email, telefono, direccion, soloActivos);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = resultados;
                if (dataGridView1.Columns["DVH"] != null)
                    dataGridView1.Columns["DVH"].Visible = false;
                TraducirHeaders();
                if (resultados.Count == 0)
                {
                    MessageBox.Show(
                        s.Traducir("No se encontraron clientes que coincidan con los criterios de búsqueda."),
                        s.Traducir("Consulta"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, s.Traducir("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_SGA657_Click(object sender, EventArgs e)
        {
            FormSistema frmMenu = new FormSistema();
            frmMenu.Show();
            this.Close();
        }

        private void LimpiarCampos()
        {
            txtDNI_SGA657.Clear();
            txtNombre_SGA657.Clear();
            txtApellido_SGA657.Clear();
            txtEmail_SGA657.Clear();
            txtTelefono_SGA657.Clear();
            txtDireccion_SGA657.Clear();
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
            TraducirHeaders();
        }

        private void rbtnTodos_SGA657_CheckedChanged(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtDNI_SGA657.Clear();
            txtNombre_SGA657.Clear();
            txtApellido_SGA657.Clear();
            txtDireccion_SGA657.Clear();
            txtTelefono_SGA657.Clear();
            txtEmail_SGA657.Clear();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || dataGridView1.Rows[e.RowIndex].DataBoundItem == null) return;
            if (e.CellStyle == null) return;
            if (dataGridView1.Rows[e.RowIndex].DataBoundItem is BECliente cliente)
            {
                if (!cliente.Activo_657SGA)
                {
                    e.CellStyle.BackColor = Color.FromArgb(255, 192, 192);
                    e.CellStyle.SelectionBackColor = Color.Red;
                }
            }
        }
    }
}
