using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Venta_Productos_Cosméticos
{
    public static class AyudaContextualHelper
    {
        public static void ActivarAyuda(Form form, string claveModulo = "")
        {
            if (form == null) return;

            form.KeyPreview = true;
            string clave = string.IsNullOrWhiteSpace(claveModulo) ? form.Name : claveModulo;

            form.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.F1)
                {
                    MostrarAyuda(form, clave);
                    e.Handled = true;
                }
            };

            form.Load += (sender, e) =>
            {
                AgregarBotonAyudaSiCorresponde(form, clave);
            };
        }

        private static void AgregarBotonAyudaSiCorresponde(Form form, string clave)
        {
            if (form is FormSistema || form is FormAyudaContextual) return;
            if (form.Controls.Find("btnAyudaContextual_Auto", true).Length > 0) return;

            Control? botonReferencia = null;
            foreach (Control c in form.Controls)
            {
                if (c is Button btn && (btn.Name.IndexOf("Salir", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                        btn.Text.IndexOf("Salir", StringComparison.OrdinalIgnoreCase) >= 0))
                {
                    botonReferencia = btn;
                    break;
                }
            }

            Button btnAyuda = new Button
            {
                Name = "btnAyudaContextual_Auto",
                Text = "? Ayuda (F1)",
                BackColor = Color.FromArgb(140, 75, 35),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat
            };
            btnAyuda.FlatAppearance.BorderSize = 0;

            if (botonReferencia != null)
            {
                int posX = botonReferencia.Location.X - botonReferencia.Width - 10;
                if (posX < 10) posX = 10;
                btnAyuda.Location = new Point(posX, botonReferencia.Location.Y);
                btnAyuda.Size = botonReferencia.Size;
                btnAyuda.Anchor = botonReferencia.Anchor;
                botonReferencia.Parent?.Controls.Add(btnAyuda);
            }
            else
            {
                btnAyuda.Size = new Size(110, 32);
                btnAyuda.Location = new Point(Math.Max(10, form.ClientSize.Width - 125), 10);
                btnAyuda.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                form.Controls.Add(btnAyuda);
            }

            btnAyuda.BringToFront();
            btnAyuda.Click += (s, ev) => MostrarAyuda(form, clave);
        }

        public static void MostrarAyuda(Form formParent, string claveModulo = "")
        {
            string clave = string.IsNullOrWhiteSpace(claveModulo) ? (formParent != null ? formParent.Name : "") : claveModulo;
            using (FormAyudaContextual frm = new FormAyudaContextual(clave))
            {
                if (formParent != null && formParent.Visible)
                {
                    frm.ShowDialog(formParent);
                }
                else
                {
                    frm.ShowDialog();
                }
            }
        }

        public static void AbrirManualPdf()
        {
            try
            {
                string rutaManual = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ManualDeUsuario.pdf");
                if (!File.Exists(rutaManual))
                {
                    string rutaAlt = Path.Combine(Directory.GetCurrentDirectory(), "ManualDeUsuario.pdf");
                    if (File.Exists(rutaAlt))
                    {
                        rutaManual = rutaAlt;
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
    }
}
