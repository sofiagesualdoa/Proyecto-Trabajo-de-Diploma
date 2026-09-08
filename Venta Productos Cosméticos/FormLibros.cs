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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Venta_Productos_Cosméticos
{
    public partial class FormLibros : Form, IObserver
    {
        private ServicioIdioma bllIdioma = new ServicioIdioma();
        private BLLLibro bllLibro = new BLLLibro();
        private Dictionary<Control, string> textosOriginales = new Dictionary<Control, string>();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        public FormLibros()
        {
            InitializeComponent();
        }

        private void FormLibros_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            RegistrarTextos(this.Controls);
            bllIdioma.AgregarSuscriptor(this);
            MostrarGrilla(bllLibro.ObtenerLibros());
            var usuario = ServicioSessionManager.GetInstance().ObtenerUsuario();
            if (usuario != null && usuario.Idioma != null)
            {
                Actualizar(usuario.Idioma);
            }
            ConfigurarPlaceholder();
            this.BeginInvoke((Action)(() => this.ActiveControl = null));
            rbtnTodos_657SGA.Checked = true;
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
        }

        private void MostrarGrilla(Object lista)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lista;
            if (dataGridView1.Columns["Activo_657SGA"] != null)
            {
                dataGridView1.Columns["Activo_657SGA"].Visible = false;
            }
            if (dataGridView1.Columns["DVH"] != null)
            {
                dataGridView1.Columns["DVH"].Visible = false;
            }

            foreach (DataGridViewColumn columna in dataGridView1.Columns)
            {
                columna.HeaderText = columna.Name.Replace("_657SGA", "");
            }
            var usuarioActivo = ServicioSessionManager.GetInstance().ObtenerUsuario();
            if (usuarioActivo?.Idioma?.DiccionarioLeyendas != null)
            {
                var leyendas = usuarioActivo.Idioma.DiccionarioLeyendas;
                foreach (DataGridViewColumn columna in dataGridView1.Columns)
                {
                    if (leyendas.ContainsKey(columna.Name))
                    {
                        columna.HeaderText = leyendas[columna.Name];
                    }
                }
            }
        }

        private void btnConsultar_657SGA_Click(object sender, EventArgs e)
        {
            var listaFiltrada = bllLibro.FiltrarLibros(textBox1_657SGA.Text);
            if (rbtnActivos_657SGA.Checked)
            {
                MostrarGrilla(listaFiltrada.Where(l => l.Activo_657SGA).ToList());
            }
            else
            {
                MostrarGrilla(listaFiltrada);
            }
        }

        private void btnSalir_657SGA_Click(object sender, EventArgs e)
        {
            FormSistema frmMenu = new FormSistema();
            frmMenu.Show();
            this.Close();
        }

        private void btnLimpiar_657SGA_Click(object sender, EventArgs e)
        {
            textBox1_657SGA.Clear();
            btnConsultar_657SGA_Click(sender, e);
        }

        private void btnAgregar_657SGA_Click(object sender, EventArgs e)
        {
            try
            {
                var session = ServicioSessionManager.GetInstance();
                string titulo = Interaction.InputBox(session.Traducir("Ingrese el Título del libro:"), session.Traducir("Agregar Libro"), "");
                if (string.IsNullOrWhiteSpace(titulo))
                {
                    throw new Exception(session.Traducir("Operación cancelada. El título no puede estar vacío."));
                }
                string editorial = Interaction.InputBox(session.Traducir("Ingrese la Editorial del libro:"), session.Traducir("Agregar Libro"), "");
                if (string.IsNullOrWhiteSpace(editorial))
                {
                    throw new Exception(session.Traducir("Operación cancelada. La editorial no puede estar vacía."));
                }
                string autor = Interaction.InputBox(session.Traducir("Ingrese el/los Autor/es del libro:"), session.Traducir("Agregar Libro"), "");
                if (string.IsNullOrWhiteSpace(autor))
                {
                    throw new Exception(session.Traducir("Operación cancelada. El autor no puede estar vacío."));
                }
                string isbn = Interaction.InputBox(session.Traducir("Ingrese el ISBN del libro:"), session.Traducir("Agregar Libro"), "");
                if (string.IsNullOrWhiteSpace(isbn))
                {
                    throw new Exception(session.Traducir("Operación cancelada. El ISBN no puede estar vacío."));
                }
                string precioStr = Interaction.InputBox(session.Traducir("Ingrese el Precio del libro:"), session.Traducir("Agregar Libro"), "");
                if (!decimal.TryParse(precioStr, out decimal precio) || precio <= 0)
                {
                    throw new Exception(session.Traducir("Operación cancelada. El precio es inválido."));
                }
                string cantidadStr = Interaction.InputBox(session.Traducir("Ingrese la cantidad inicial de ejemplares del libro:"), session.Traducir("Agregar Libro"), "");
                if (!int.TryParse(cantidadStr, out int cantidad) || cantidad < 0)
                {
                    throw new Exception(session.Traducir("Operación cancelada. La cantidad de ejemplares es inválida."));
                }
                BELibro libro = new BELibro
                {
                    Título_657SGA = titulo.Trim(),
                    Editorial_657SGA = editorial.Trim(),
                    Autor_657SGA = autor.Trim(),
                    ISBN_657SGA = isbn.Trim(),
                    Precio_657SGA = precio,
                    Existencias_657SGA = cantidad,
                    Activo_657SGA = true
                };
                bllLibro.CrearLibro(libro);
                MostrarGrilla(bllLibro.ObtenerLibros());
                MessageBox.Show(session.Traducir("Libro agregado correctamente."),
                                session.Traducir("Éxito"),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                string errorTraducido = ServicioSessionManager.GetInstance().Traducir(ex.Message);
                MessageBox.Show(errorTraducido,
                                ServicioSessionManager.GetInstance().Traducir("Error"),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

        }

        private void btnBorrar_657SGA_Click(object sender, EventArgs e)
        {
            try
            {
                var session = ServicioSessionManager.GetInstance();
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show(session.Traducir("Debe seleccionar un libro de la grilla para activar o desactivar."),
                                    session.Traducir("Aviso"),
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                BELibro libroSeleccionado = (BELibro)dataGridView1.SelectedRows[0].DataBoundItem;
                bool esActivo = libroSeleccionado.Activo_657SGA;

                string mensajeConfirmacion = esActivo
                    ? session.Traducir("¿Está seguro de que desea desactivar el libro '") + libroSeleccionado.Título_657SGA + session.Traducir("' ?")
                    : session.Traducir("¿Está seguro de que desea activar el libro '") + libroSeleccionado.Título_657SGA + session.Traducir("' ?");

                string tituloConfirmacion = esActivo
                    ? session.Traducir("Confirmar Desactivación")
                    : session.Traducir("Confirmar Activación");

                DialogResult confirmacion = MessageBox.Show(
                    mensajeConfirmacion,
                    tituloConfirmacion,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    bllLibro.ActivarDesactivarLibro(libroSeleccionado.ISBN_657SGA);

                    if (rbtnActivos_657SGA.Checked)
                    {
                        MostrarGrilla(bllLibro.ObtenerLibrosActivos());
                    }
                    else
                    {
                        MostrarGrilla(bllLibro.ObtenerLibros());
                    }

                    string mensajeExito = esActivo
                        ? session.Traducir("Libro desactivado correctamente.")
                        : session.Traducir("Libro activado correctamente.");

                    MessageBox.Show(mensajeExito,
                                    session.Traducir("Éxito"),
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                string errorTraducido = ServicioSessionManager.GetInstance().Traducir(ex.Message);
                MessageBox.Show(errorTraducido,
                                ServicioSessionManager.GetInstance().Traducir("Error"),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btnModificar_657SGA_Click(object sender, EventArgs e)
        {
            try
            {
                var session = ServicioSessionManager.GetInstance();
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show(session.Traducir("Debe seleccionar un libro de la grilla para modificar."),
                                    session.Traducir("Aviso"),
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
                else
                {
                    BELibro libroSeleccionado = (BELibro)dataGridView1.SelectedRows[0].DataBoundItem;
                    string titulo = Interaction.InputBox(session.Traducir("Ingrese el Título del libro:"), session.Traducir("Modificar Libro"), libroSeleccionado.Título_657SGA);
                    if (string.IsNullOrWhiteSpace(titulo))
                    {
                        throw new Exception(session.Traducir("Operación cancelada. El título no puede estar vacío."));
                    }

                    string editorial = Interaction.InputBox(session.Traducir("Ingrese la Editorial del libro:"), session.Traducir("Modificar Libro"), libroSeleccionado.Editorial_657SGA);
                    if (string.IsNullOrWhiteSpace(editorial))
                    {
                        throw new Exception(session.Traducir("Operación cancelada. La editorial no puede estar vacía."));
                    }

                    string autor = Interaction.InputBox(session.Traducir("Ingrese el/los Autor/es del libro:"), session.Traducir("Modificar Libro"), libroSeleccionado.Autor_657SGA);
                    if (string.IsNullOrWhiteSpace(autor))
                    {
                        throw new Exception(session.Traducir("Operación cancelada. El autor no puede estar vacío."));
                    }

                    string isbn = Interaction.InputBox(session.Traducir("Ingrese el ISBN del libro:"), session.Traducir("Modificar Libro"), libroSeleccionado.ISBN_657SGA);
                    if (string.IsNullOrWhiteSpace(isbn))
                    {
                        throw new Exception(session.Traducir("Operación cancelada. El ISBN no puede estar vacío."));
                    }

                    string precioStr = Interaction.InputBox(session.Traducir("Ingrese el Precio del libro:"), session.Traducir("Modificar Libro"), libroSeleccionado.Precio_657SGA.ToString());
                    if (!decimal.TryParse(precioStr, out decimal precio) || precio <= 0)
                    {
                        throw new Exception(session.Traducir("Operación cancelada. El precio es inválido."));
                    }

                    string cantidadStr = Interaction.InputBox(session.Traducir("Ingrese la cantidad de ejemplares del libro:"), session.Traducir("Modificar Libro"), libroSeleccionado.Existencias_657SGA.ToString());
                    if (!int.TryParse(cantidadStr, out int cantidad) || cantidad < 0)
                    {
                        throw new Exception(session.Traducir("Operación cancelada. La cantidad de ejemplares es inválida."));
                    }

                    BELibro libroModificado = new BELibro
                    {
                        Título_657SGA = titulo.Trim(),
                        Editorial_657SGA = editorial.Trim(),
                        Autor_657SGA = autor.Trim(),
                        ISBN_657SGA = isbn.Trim(),
                        Precio_657SGA = precio,
                        Existencias_657SGA = cantidad,
                        Activo_657SGA = libroSeleccionado.Activo_657SGA
                    };

                    bllLibro.ModificarLibro(libroModificado, libroSeleccionado.ISBN_657SGA);

                    if (rbtnActivos_657SGA.Checked)
                    {
                        MostrarGrilla(bllLibro.ObtenerLibrosActivos());
                    }
                    else
                    {
                        MostrarGrilla(bllLibro.ObtenerLibros());
                    }

                    MessageBox.Show(session.Traducir("Libro modificado correctamente."),
                                    session.Traducir("Éxito"),
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                string errorTraducido = ServicioSessionManager.GetInstance().Traducir(ex.Message);
                MessageBox.Show(errorTraducido,
                                ServicioSessionManager.GetInstance().Traducir("Error"),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || dataGridView1.Rows[e.RowIndex].DataBoundItem == null) return;
            if (e.CellStyle == null) return;
            if (dataGridView1.Rows[e.RowIndex].DataBoundItem is BELibro libro)
            {
                if (!libro.Activo_657SGA)
                {
                    e.CellStyle.BackColor = Color.FromArgb(255, 192, 192);
                    e.CellStyle.SelectionBackColor = Color.Red;
                }
            }
        }

        private void rbtnTodos_657SGA_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnTodos_657SGA.Checked)
            {
                MostrarGrilla(bllLibro.ObtenerLibros());
            }
        }

        private void rbtnActivos_657SGA_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnActivos_657SGA.Checked)
            {
                MostrarGrilla(bllLibro.ObtenerLibrosActivos());
            }
        }
    }
}
