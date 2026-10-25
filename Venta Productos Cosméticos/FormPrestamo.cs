using BE;
using BLL;
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
    public partial class FormPrestamo : Form, IObserver
    {
        private ServicioIdioma bllIdioma = new ServicioIdioma();
        private BLLLibro bllLibro = new BLLLibro();
        private BLLPrestamo bllPrestamo = new BLLPrestamo();
        private BLLCliente bllCliente = new BLLCliente();
        private Dictionary<Control, string> textosOriginales = new Dictionary<Control, string>();
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        public FormPrestamo()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormSistema frmMenu = new FormSistema();
            frmMenu.Show();
            this.Close();
        }

        private void FormPrestamo_Load(object sender, EventArgs e)
        {
            dataGridViewLibros.ReadOnly = true;
            dataGridViewLibros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewLibros.MultiSelect = false;
            RegistrarTextos(this.Controls);
            bllIdioma.AgregarSuscriptor(this);
            MostrarGrilla(bllLibro.ObtenerLibrosActivos().Where(l => l.EsParaPrestamo && l.ExistenciasPrestamo != 0).ToList());
            var usuario = ServicioSessionManager.GetInstance().ObtenerUsuario();
            if (usuario != null && usuario.Idioma != null)
            {
                Actualizar(usuario.Idioma);
            }
            ConfigurarPlaceholder();
            this.BeginInvoke((Action)(() => this.ActiveControl = null));
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
            ConfigurarPlaceholder();
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
            if (dataGridViewLibros.Columns["EsParaPrestamo"] != null)
                dataGridViewLibros.Columns["EsParaPrestamo"].Visible = false;
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

        private void btnLimpiar_657SGA_Click(object sender, EventArgs e)
        {
            textBox1_657SGA.Clear();
            btnConsultar_657SGA_Click(sender, e);
        }

        private void btnConsultar_657SGA_Click(object sender, EventArgs e)
        {
            var listaFiltrada = bllLibro.BuscarLibros(textBox1_657SGA.Text);
            MostrarGrilla(listaFiltrada.Where(l => l.Activo_657SGA && l.EsParaPrestamo && l.ExistenciasPrestamo != 0).ToList());
        }

        private void btnAgregar_657SGA_Click(object sender, EventArgs e)
        {
            var session = ServicioSessionManager.GetInstance();
            try
            {
                if (dataGridViewLibros.SelectedRows.Count == 0)
                {
                    MessageBox.Show(session.Traducir("Debe seleccionar un libro de la lista para solicitar el préstamo."),
                                    session.Traducir("Aviso"),
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }
                BELibro libroSeleccionado = (BELibro)dataGridViewLibros.SelectedRows[0].DataBoundItem;
                if (libroSeleccionado.ExistenciasPrestamo <= 0)
                {
                    throw new Exception(session.Traducir("El ejemplar seleccionado no cuenta con disponibilidad para préstamo."));
                }
                DialogResult respuestaLibro = MessageBox.Show(
                    string.Format(session.Traducir("¿Desea solicitar el préstamo del libro '{0}'?"), libroSeleccionado.Título_657SGA),
                    session.Traducir("Confirmar Libro"),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (respuestaLibro != DialogResult.Yes) return;
                string diasStr = Interaction.InputBox(
                    session.Traducir("Ingrese la cantidad de días del préstamo:"),
                    session.Traducir("Duración del Préstamo"),
                    "7");
                if (string.IsNullOrWhiteSpace(diasStr)) return;
                if (!int.TryParse(diasStr, out int dias) || dias <= 0)
                {
                    throw new Exception(session.Traducir("La cantidad de días debe ser un número entero mayor a cero."));
                }
                string dniStr = Interaction.InputBox(
                    session.Traducir("Ingrese el DNI del cliente solicitante:"),
                    session.Traducir("Asociar Cliente"),
                    "");
                if (string.IsNullOrWhiteSpace(dniStr)) return;
                if (!int.TryParse(dniStr, out int dni) || dni <= 0)
                {
                    throw new Exception(session.Traducir("El DNI debe ser numérico y mayor a cero."));
                }
                BECliente cliente = bllCliente.BuscarClientePorDNI(dni);
                if (cliente == null)
                {
                    DialogResult respReg = MessageBox.Show(
                        string.Format(session.Traducir("El cliente con DNI {0} no se encuentra registrado en el sistema.\n\n¿Desea registrarlo ahora?"), dni),
                        session.Traducir("Cliente No Encontrado"),
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (respReg == DialogResult.Yes)
                    {
                        using (FormClientes frmClientes = new FormClientes(dni, modoVenta: true))
                        {
                            if (frmClientes.ShowDialog() == DialogResult.OK && frmClientes.AsociadoAlCarrito)
                            {
                                cliente = frmClientes.ClienteSeleccionado ?? bllCliente.BuscarClientePorDNI(dni);
                            }
                        }
                    }
                    if (cliente == null) return;
                }
                if (!cliente.Activo_657SGA)
                {
                    throw new Exception(session.Traducir("El cliente se encuentra dado de baja en el sistema."));
                }
                bllPrestamo.VerificarClienteHabilitado(cliente.DNI_657SGA);
                decimal total = bllPrestamo.CalcularImporte(libroSeleccionado, dias);
                DateTime fechaDevolucion = DateTime.Today.AddDays(dias);
                string mensajeResumen = string.Format(
                    session.Traducir("Resumen de la Solicitud de Préstamo:\n\n" +
                                     "Libro: {0}\n" +
                                     "Cliente: {1} {2} (DNI: {3})\n" +
                                     "Duración: {4} días\n" +
                                     "Fecha pactada de devolución: {5:dd/MM/yyyy}\n" +
                                     "Total a abonar: ${6:N2}\n\n" +
                                     "¿Desea continuar al cobro?"),
                    libroSeleccionado.Título_657SGA,
                    cliente.Nombre_657SGA,
                    cliente.Apellido_657SGA,
                    cliente.DNI_657SGA,
                    dias,
                    fechaDevolucion,
                    total);
                DialogResult confirmacion = MessageBox.Show(
                    mensajeResumen,
                    session.Traducir("Confirmar Préstamo"),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (confirmacion != DialogResult.Yes) return;
                BEPrestamo solicitud = bllPrestamo.RegistrarSolicitudPrestamo(
                    cliente.DNI_657SGA,
                    libroSeleccionado.ISBN_657SGA,
                    fechaDevolucion,
                    total);
                using (FormCobro frmCobro = new FormCobro(solicitud, cliente))
                {
                    if (frmCobro.ShowDialog() == DialogResult.OK)
                    {
                        MostrarGrilla(bllLibro.ObtenerLibrosActivos().Where(l => l.EsParaPrestamo && l.ExistenciasPrestamo !=0).ToList());
                    }
                }
            }
            catch (Exception ex)
            {
                string errorTraducido = session.Traducir(ex.Message);
                MessageBox.Show(errorTraducido,
                                session.Traducir("Aviso"),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }

        private void FormPrestamo_FormClosing(object sender, FormClosingEventArgs e)
        {
            bllIdioma.BorrarSuscriptor(this);
        }
    }
}
