using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Venta_Productos_Cosméticos
{
    public partial class FormAyudaContextual : Form
    {
        private readonly BLLAyuda bllAyuda = new BLLAyuda();
        private List<BEItemAyuda> temasDisponibles = new List<BEItemAyuda>();

        public FormAyudaContextual(string claveModuloInicial = "")
        {
            InitializeComponent();
            CargarTemas(claveModuloInicial);
        }

        private void CargarTemas(string claveInicial)
        {
            temasDisponibles = bllAyuda.ObtenerTodosLosTemas();
            cmbModulos.Items.Clear();

            int selectedIndex = 0;
            for (int i = 0; i < temasDisponibles.Count; i++)
            {
                var item = temasDisponibles[i];
                cmbModulos.Items.Add(item);

                if (!string.IsNullOrWhiteSpace(claveInicial) &&
                    item.ClaveModulo.Equals(claveInicial, StringComparison.OrdinalIgnoreCase))
                {
                    selectedIndex = i;
                }
            }

            if (cmbModulos.Items.Count > 0)
            {
                cmbModulos.SelectedIndex = selectedIndex;
            }
        }

        private void cmbModulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbModulos.SelectedItem is BEItemAyuda seleccionado)
            {
                MostrarContenido(seleccionado);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text.Trim();
            if (string.IsNullOrWhiteSpace(texto))
            {
                CargarTemas("");
                return;
            }

            var resultados = bllAyuda.BuscarTemas(texto);
            cmbModulos.Items.Clear();

            foreach (var r in resultados)
            {
                cmbModulos.Items.Add(r);
            }

            if (cmbModulos.Items.Count > 0)
            {
                cmbModulos.SelectedIndex = 0;
            }
            else
            {
                rtbContenido.Clear();
                rtbContenido.SelectionFont = new Font("Segoe UI", 11F, FontStyle.Italic);
                rtbContenido.SelectionColor = Color.DimGray;
                rtbContenido.AppendText($"\nNo se encontraron temas coincidentes con '{texto}'. Pruebe con términos como 'venta', 'factura', 'mora', 'stock' o 'encriptar'.");
            }
        }

        private void MostrarContenido(BEItemAyuda item)
        {
            rtbContenido.Clear();

            AgregarEncabezadoPrincipal(item.TituloModulo);
            AgregarSeparador();

            AgregarSeccion("Objetivo General de la Pantalla", item.Objetivo);
            AgregarSeccion("Procedimiento Operativo Paso a Paso", item.Pasos);
            AgregarSeccion("Controles Principales y Atajos de Teclado", item.ControlesAtajos);
            AgregarSeccion("Reglas de Negocio, Validaciones y Seguridad", item.ReglasSeguridad);

            rtbContenido.SelectionStart = 0;
            rtbContenido.ScrollToCaret();
        }

        private void AgregarEncabezadoPrincipal(string titulo)
        {
            rtbContenido.SelectionFont = new Font("Segoe UI", 14F, FontStyle.Bold);
            rtbContenido.SelectionColor = Color.FromArgb(45, 55, 72);
            rtbContenido.AppendText(titulo + "\n");
        }

        private void AgregarSeparador()
        {
            rtbContenido.SelectionFont = new Font("Segoe UI", 8F, FontStyle.Regular);
            rtbContenido.SelectionColor = Color.LightGray;
            rtbContenido.AppendText(new string('-', 78) + "\n\n");
        }

        private void AgregarSeccion(string tituloSeccion, string cuerpo)
        {
            rtbContenido.SelectionFont = new Font("Segoe UI", 11F, FontStyle.Bold);
            rtbContenido.SelectionColor = Color.FromArgb(140, 75, 35);
            rtbContenido.AppendText(tituloSeccion + "\n");

            rtbContenido.SelectionFont = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            rtbContenido.SelectionColor = Color.FromArgb(30, 41, 59);
            rtbContenido.AppendText(cuerpo + "\n\n");
        }

        private void btnAbrirManual_Click(object sender, EventArgs e)
        {
            try
            {
                string rutaManual = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ManualDeUsuario.pdf");

                if (!File.Exists(rutaManual))
                {
                    string rutaAlternativa = Path.Combine(Directory.GetCurrentDirectory(), "ManualDeUsuario.pdf");
                    if (File.Exists(rutaAlternativa))
                    {
                        rutaManual = rutaAlternativa;
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el archivo del Manual de Usuario (ManualDeUsuario.pdf).", "Bookly - Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                Process.Start(new ProcessStartInfo
                {
                    FileName = rutaManual,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir el manual de usuario.\n\n" + ex.Message, "Bookly - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAyudaContextual_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                e.Handled = true;
            }
        }
    }
}
