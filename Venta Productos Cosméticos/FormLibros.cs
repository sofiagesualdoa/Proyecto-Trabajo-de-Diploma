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
        private BLLIdioma bllIdioma = new BLLIdioma();
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
            textBox1_657SGA.PlaceholderText = ServicioSessionManager.GetInstance().Traducir("Buscar por Título, Autor, ISBN...");
        }

        private void MostrarGrilla(Object lista)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lista;
            dataGridView1.Columns["DVH"].Visible = false;
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
            MostrarGrilla(bllLibro.FiltrarLibros(textBox1_657SGA.Text));
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
                    Existencias_657SGA = cantidad
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
    }
}
