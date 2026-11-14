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
            if (form is FormSistema || form is FormAyudaContextual || form is FormPantallaInicio) return;
            if (form.Controls.Find("btnAyudaContextual_Auto", true).Length > 0) return;

            Button btnAyuda = new Button
            {
                Name = "btnAyudaContextual_Auto",
                Text = "Ayuda (F1)",
                Cursor = Cursors.Hand,
                UseVisualStyleBackColor = false
            };

            switch (form.Name)
            {
                case "FormInicioSesion":
                    btnAyuda.Location = new Point(650, 15);
                    btnAyuda.Size = new Size(125, 36);
                    btnAyuda.BackColor = Color.Bisque;
                    btnAyuda.ForeColor = Color.Black;
                    btnAyuda.Font = new Font("Sitka Text", 10F, FontStyle.Bold);
                    break;

                case "FormCambioClave":
                    btnAyuda.Location = new Point(325, 323);
                    btnAyuda.Size = new Size(175, 45);
                    btnAyuda.BackColor = Color.Sienna;
                    btnAyuda.ForeColor = Color.Black;
                    btnAyuda.Font = new Font("Sitka Text", 14F, FontStyle.Bold);
                    break;

                case "FormHistorialPrestamos":
                    btnAyuda.Location = new Point(440, 12);
                    btnAyuda.Size = new Size(135, 38);
                    btnAyuda.BackColor = Color.Sienna;
                    btnAyuda.ForeColor = Color.Black;
                    btnAyuda.Font = new Font("Sitka Text", 9.75F, FontStyle.Bold);
                    break;

                case "FormHistorialVentas":
                    btnAyuda.Location = new Point(710, 12);
                    btnAyuda.Size = new Size(125, 38);
                    btnAyuda.BackColor = Color.Sienna;
                    btnAyuda.ForeColor = Color.Black;
                    btnAyuda.Font = new Font("Sitka Text", 9.75F, FontStyle.Bold);
                    break;

                case "FormLibros":
                    btnAyuda.Location = new Point(686, 318);
                    btnAyuda.Size = new Size(113, 40);
                    btnAyuda.BackColor = Color.Sienna;
                    btnAyuda.ForeColor = Color.Black;
                    btnAyuda.Font = new Font("Sitka Text", 9.75F, FontStyle.Regular);
                    break;

                case "FormClientes":
                    btnAyuda.Location = new Point(818, 321);
                    btnAyuda.Size = new Size(113, 50);
                    btnAyuda.BackColor = Color.Sienna;
                    btnAyuda.ForeColor = Color.Black;
                    btnAyuda.Font = new Font("Sitka Text", 9.75F, FontStyle.Regular);
                    break;

                case "FormLibroCambios":
                    btnAyuda.Location = new Point(580, 15);
                    btnAyuda.Size = new Size(125, 38);
                    btnAyuda.BackColor = Color.Sienna;
                    btnAyuda.ForeColor = Color.Black;
                    btnAyuda.Font = new Font("Sitka Text", 9.75F, FontStyle.Regular);
                    break;

                case "FormVenta":
                    btnAyuda.Location = new Point(845, 7);
                    btnAyuda.Size = new Size(110, 36);
                    btnAyuda.BackColor = Color.Sienna;
                    btnAyuda.ForeColor = Color.Black;
                    btnAyuda.Font = new Font("Sitka Text", 9.75F, FontStyle.Regular);
                    break;

                case "FormPrestamo":
                    btnAyuda.Location = new Point(845, 7);
                    btnAyuda.Size = new Size(110, 36);
                    btnAyuda.BackColor = Color.Sienna;
                    btnAyuda.ForeColor = Color.Black;
                    btnAyuda.Font = new Font("Sitka Text", 9.75F, FontStyle.Regular);
                    break;

                case "FormReporteInteligente":
                    btnAyuda.Location = new Point(750, 12);
                    btnAyuda.Size = new Size(125, 38);
                    btnAyuda.BackColor = Color.Sienna;
                    btnAyuda.ForeColor = Color.Black;
                    btnAyuda.Font = new Font("Sitka Text", 9.75F, FontStyle.Bold);
                    break;

                case "FormBitacora":
                    btnAyuda.Location = new Point(548, 445);
                    btnAyuda.Size = new Size(113, 57);
                    btnAyuda.BackColor = Color.Sienna;
                    btnAyuda.ForeColor = Color.Black;
                    btnAyuda.Font = new Font("Sitka Text", 12F, FontStyle.Regular);
                    break;

                case "FormPerfil":
                    btnAyuda.Location = new Point(565, 13);
                    btnAyuda.Size = new Size(115, 39);
                    btnAyuda.BackColor = Color.Sienna;
                    btnAyuda.ForeColor = Color.Black;
                    btnAyuda.Font = new Font("Sitka Text", 14F, FontStyle.Bold);
                    break;

                case "FormUsuario":
                    btnAyuda.Location = new Point(845, 387);
                    btnAyuda.Size = new Size(113, 57);
                    btnAyuda.BackColor = Color.Sienna;
                    btnAyuda.ForeColor = Color.Black;
                    btnAyuda.Font = new Font("Sitka Text", 9.75F, FontStyle.Regular);
                    break;

                case "FormCobro":
                    btnAyuda.Location = new Point(135, 337);
                    btnAyuda.Size = new Size(113, 57);
                    btnAyuda.BackColor = Color.Sienna;
                    btnAyuda.ForeColor = Color.Black;
                    btnAyuda.Font = new Font("Sitka Text", 9.75F, FontStyle.Regular);
                    break;

                case "FormErrorIntegridad":
                    btnAyuda.Location = new Point(680, 25);
                    btnAyuda.Size = new Size(135, 45);
                    btnAyuda.BackColor = Color.Sienna;
                    btnAyuda.ForeColor = Color.Black;
                    btnAyuda.Font = new Font("Sitka Text", 14F, FontStyle.Bold);
                    break;

                default:
                    btnAyuda.Location = new Point(Math.Max(10, form.ClientSize.Width - 140), 10);
                    btnAyuda.Size = new Size(125, 36);
                    btnAyuda.BackColor = Color.Sienna;
                    btnAyuda.ForeColor = Color.Black;
                    btnAyuda.Font = new Font("Sitka Text", 9.75F, FontStyle.Regular);
                    btnAyuda.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                    break;
            }

            form.Controls.Add(btnAyuda);
            btnAyuda.BringToFront();
            btnAyuda.Click += (s, ev) => MostrarAyuda(form, clave);
        }

        public static void MostrarAyuda(Form formParent, string claveModulo = "")
        {
            string clave = string.IsNullOrWhiteSpace(claveModulo) ? (formParent != null ? formParent.Name : "") : claveModulo;
            bool parentWasTopMost = formParent != null && formParent.TopMost;
            if (parentWasTopMost)
            {
                formParent.TopMost = false;
            }

            try
            {
                using (FormAyudaContextual frm = new FormAyudaContextual(clave))
                {
                    frm.TopMost = true;
                    frm.StartPosition = FormStartPosition.CenterScreen;
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
            finally
            {
                if (parentWasTopMost && formParent != null && !formParent.IsDisposed)
                {
                    formParent.TopMost = true;
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
