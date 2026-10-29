using BE;
using BLL;
using Servicios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Venta_Productos_Cosméticos
{
    public partial class FormLibroCambios : Form, IObserver
    {
        private readonly BLLLibroCambios bllCambios = new BLLLibroCambios();
        private readonly ServicioIdioma bllIdioma = new ServicioIdioma();
        private readonly Dictionary<Control, string> textosOriginales = new Dictionary<Control, string>();
        private List<BELibroCambios> listaActual = new List<BELibroCambios>();

        public FormLibroCambios()
        {
            InitializeComponent();
        }

        private void FormLibroCambios_Load(object sender, EventArgs e)
        {
            dtpFechaDesde.Value = DateTime.Today.AddDays(-30);
            dtpFechaHasta.Value = DateTime.Today;
            chkFiltrarFecha.Checked = false;
            dtpFechaDesde.Enabled = false;
            dtpFechaHasta.Enabled = false;
            btnActivar.Enabled = false;

            ConfigurarColumnas();
            RegistrarTextos(this.Controls);
            bllIdioma.AgregarSuscriptor(this);

            CargarCambios();

            var usuario = ServicioSessionManager.GetInstance().ObtenerUsuario();
            if (usuario != null && usuario.Idioma != null)
            {
                Actualizar(usuario.Idioma);
            }
        }

        private void ConfigurarColumnas()
        {
            dgvCambios.Columns.Clear();
            dgvCambios.AutoGenerateColumns = false;

            dgvCambios.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                HeaderText = "ID",
                DataPropertyName = "IdLibroC",
                FillWeight = 40
            });

            dgvCambios.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colISBN",
                HeaderText = "ISBN",
                DataPropertyName = "ISBN",
                FillWeight = 85
            });

            dgvCambios.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTitulo",
                HeaderText = "Título",
                DataPropertyName = "Titulo",
                FillWeight = 130
            });

            dgvCambios.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPrecio",
                HeaderText = "Precio",
                DataPropertyName = "Precio",
                DefaultCellStyle = { Format = "C2" },
                FillWeight = 65
            });

            dgvCambios.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colExistencias",
                HeaderText = "Stock Venta",
                DataPropertyName = "Existencias",
                FillWeight = 65
            });

            dgvCambios.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colExistenciasPrestamo",
                HeaderText = "Stock Préstamo",
                DataPropertyName = "ExistenciasPrestamo",
                FillWeight = 75
            });

            dgvCambios.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colEditorial",
                HeaderText = "Editorial",
                DataPropertyName = "Editorial",
                FillWeight = 90
            });

            dgvCambios.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colAutor",
                HeaderText = "Autor",
                DataPropertyName = "Autor",
                FillWeight = 100
            });

            dgvCambios.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colFecha",
                HeaderText = "Fecha",
                DataPropertyName = "Fecha",
                DefaultCellStyle = { Format = "dd/MM/yyyy" },
                FillWeight = 70
            });

            dgvCambios.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colHora",
                HeaderText = "Hora",
                DataPropertyName = "Hora",
                FillWeight = 60
            });

            dgvCambios.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colEstado",
                HeaderText = "Estado",
                FillWeight = 65
            });

            dgvCambios.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colVigente",
                HeaderText = "Vigente",
                FillWeight = 60
            });
        }

        private void CargarCambios()
        {
            try
            {
                string isbn = string.IsNullOrWhiteSpace(txtISBN.Text) ? null : txtISBN.Text.Trim();
                string titulo = string.IsNullOrWhiteSpace(txtTitulo.Text) ? null : txtTitulo.Text.Trim();
                DateTime? fechaDesde = chkFiltrarFecha.Checked ? dtpFechaDesde.Value.Date : (DateTime?)null;
                DateTime? fechaHasta = chkFiltrarFecha.Checked ? dtpFechaHasta.Value.Date : (DateTime?)null;

                listaActual = bllCambios.BuscarRegistros(isbn, titulo, fechaDesde, fechaHasta);
                MostrarEnGrilla(listaActual);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                ServicioSessionManager.GetInstance().Traducir("Error"),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void MostrarEnGrilla(List<BELibroCambios> lista)
        {
            dgvCambios.Rows.Clear();

            string txtActivo = ServicioSessionManager.GetInstance().Traducir("Activo");
            string txtInactivo = ServicioSessionManager.GetInstance().Traducir("Inactivo");
            string txtSi = ServicioSessionManager.GetInstance().Traducir("SÍ");
            string txtNo = ServicioSessionManager.GetInstance().Traducir("NO");

            foreach (var item in lista)
            {
                int rowIndex = dgvCambios.Rows.Add(
                    item.IdLibroC,
                    item.ISBN,
                    item.Titulo,
                    item.Precio,
                    item.Existencias,
                    item.ExistenciasPrestamo,
                    item.Editorial,
                    item.Autor,
                    item.Fecha,
                    item.Hora.ToString(@"hh\:mm\:ss"),
                    item.Activo ? txtActivo : txtInactivo,
                    item.Act ? txtSi : txtNo
                );

                dgvCambios.Rows[rowIndex].Tag = item;

                if (item.Act)
                {
                    dgvCambios.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(220, 245, 220);
                    dgvCambios.Rows[rowIndex].DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
            }
            ActualizarEstadoBotonActivar();
        }

        private void dgvCambios_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarEstadoBotonActivar();
        }

        private void ActualizarEstadoBotonActivar()
        {
            if (dgvCambios.CurrentRow != null && dgvCambios.CurrentRow.Tag is BELibroCambios item)
            {
                btnActivar.Enabled = !item.Act;
            }
            else
            {
                btnActivar.Enabled = false;
            }
        }

        private void dgvCambios_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvCambios.Rows.Count)
            {
                if (dgvCambios.Rows[e.RowIndex].Tag is BELibroCambios item && item.Act)
                {
                    dgvCambios.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(220, 245, 220);
                    dgvCambios.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarCambios();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtISBN.Text = string.Empty;
            txtTitulo.Text = string.Empty;
            chkFiltrarFecha.Checked = false;
            dtpFechaDesde.Value = DateTime.Today.AddDays(-30);
            dtpFechaHasta.Value = DateTime.Today;
            dtpFechaDesde.Enabled = false;
            dtpFechaHasta.Enabled = false;
            CargarCambios();
        }

        private void chkFiltrarFecha_CheckedChanged(object sender, EventArgs e)
        {
            dtpFechaDesde.Enabled = chkFiltrarFecha.Checked;
            dtpFechaHasta.Enabled = chkFiltrarFecha.Checked;
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            if (dgvCambios.CurrentRow == null || !(dgvCambios.CurrentRow.Tag is BELibroCambios selected))
            {
                return;
            }

            if (selected.Act)
            {
                MessageBox.Show(
                    ServicioSessionManager.GetInstance().Traducir("La versión seleccionada ya es la versión activa vigente."),
                    ServicioSessionManager.GetInstance().Traducir("Información"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            string pregunta = string.Format(
                ServicioSessionManager.GetInstance().Traducir("¿Confirma restaurar el libro a la versión seleccionada del día {0} a las {1}?"),
                selected.Fecha.ToString("dd/MM/yyyy"),
                selected.Hora.ToString(@"hh\:mm\:ss")
            );

            DialogResult confirm = MessageBox.Show(
                pregunta,
                ServicioSessionManager.GetInstance().Traducir("Confirmar Rollback"),
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    bllCambios.Activar(selected);
                    MessageBox.Show(
                        ServicioSessionManager.GetInstance().Traducir("El libro fue restaurado exitosamente a la versión seleccionada."),
                        ServicioSessionManager.GetInstance().Traducir("Éxito"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    CargarCambios();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex.Message,
                        ServicioSessionManager.GetInstance().Traducir("Error"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            FormSistema frm = new FormSistema();
            frm.MdiParent = this.MdiParent;
            frm.Show();
            this.Close();
        }

        private void RegistrarTextos(Control.ControlCollection controles)
        {
            foreach (Control c in controles)
            {
                if (!string.IsNullOrEmpty(c.Text))
                {
                    textosOriginales[c] = c.Text;
                }
                if (c.Controls.Count > 0)
                {
                    RegistrarTextos(c.Controls);
                }
            }
        }

        public void Actualizar(ServicioIdioma idioma)
        {
            ActualizarIdioma(idioma);
        }

        private void ActualizarIdioma(ServicioIdioma idioma)
        {
            if (idioma == null) return;
            var leyendas = idioma.DiccionarioLeyendas;

            foreach (var entry in textosOriginales)
            {
                Control ctrl = entry.Key;
                string textoBase = entry.Value;

                if (leyendas != null && leyendas.ContainsKey(textoBase))
                {
                    ctrl.Text = leyendas[textoBase];
                }
                else
                {
                    ctrl.Text = textoBase;
                }
            }

            TraducirHeaders();

            if (listaActual != null && listaActual.Count > 0)
            {
                MostrarEnGrilla(listaActual);
            }
        }

        private void TraducirHeaders()
        {
            var session = ServicioSessionManager.GetInstance();
            if (dgvCambios.Columns["colId"] != null) dgvCambios.Columns["colId"].HeaderText = session.Traducir("ID");
            if (dgvCambios.Columns["colISBN"] != null) dgvCambios.Columns["colISBN"].HeaderText = session.Traducir("ISBN");
            if (dgvCambios.Columns["colTitulo"] != null) dgvCambios.Columns["colTitulo"].HeaderText = session.Traducir("Título");
            if (dgvCambios.Columns["colPrecio"] != null) dgvCambios.Columns["colPrecio"].HeaderText = session.Traducir("Precio");
            if (dgvCambios.Columns["colExistencias"] != null) dgvCambios.Columns["colExistencias"].HeaderText = session.Traducir("Stock Venta");
            if (dgvCambios.Columns["colExistenciasPrestamo"] != null) dgvCambios.Columns["colExistenciasPrestamo"].HeaderText = session.Traducir("Stock Préstamo");
            if (dgvCambios.Columns["colEditorial"] != null) dgvCambios.Columns["colEditorial"].HeaderText = session.Traducir("Editorial");
            if (dgvCambios.Columns["colAutor"] != null) dgvCambios.Columns["colAutor"].HeaderText = session.Traducir("Autor");
            if (dgvCambios.Columns["colFecha"] != null) dgvCambios.Columns["colFecha"].HeaderText = session.Traducir("Fecha");
            if (dgvCambios.Columns["colHora"] != null) dgvCambios.Columns["colHora"].HeaderText = session.Traducir("Hora");
            if (dgvCambios.Columns["colEstado"] != null) dgvCambios.Columns["colEstado"].HeaderText = session.Traducir("Estado");
            if (dgvCambios.Columns["colVigente"] != null) dgvCambios.Columns["colVigente"].HeaderText = session.Traducir("Vigente");
        }
    }
}
