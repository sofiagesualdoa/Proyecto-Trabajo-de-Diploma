using BE;
using BLL;
using Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Venta_Productos_Cosméticos
{
    public partial class FormHistorialPrestamos : Form, IObserver
    {
        private ServicioIdioma bllIdioma = new ServicioIdioma();
        private BLLPrestamo bllPrestamo = new BLLPrestamo();
        private Dictionary<Control, string> textosOriginales = new Dictionary<Control, string>();

        public FormHistorialPrestamos()
        {
            InitializeComponent();
        }

        private void FormHistorialPrestamos_Load(object sender, EventArgs e)
        {
            dtpFechaDesde.Value = DateTime.Today.AddDays(-30);
            dtpFechaHasta.Value = DateTime.Today;
            chkFiltrarFecha.Checked = false;
            RegistrarTextos(this.Controls);
            bllIdioma.AgregarSuscriptor(this);
            CargarPrestamos();
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

            TraducirHeadersPrestamos();
            TraducirHeadersDetalles();
            ActualizarResumen();
        }

        private void CargarPrestamos()
        {
            List<BEPrestamo> prestamos = bllPrestamo.ObtenerTodosLosPrestamos();
            MostrarPrestamos(prestamos);
        }

        private void MostrarPrestamos(List<BEPrestamo> prestamos)
        {
            dgvPrestamos.DataSource = null;
            dgvPrestamos.DataSource = prestamos;

            if (dgvPrestamos.Columns["IdFactura"] != null)
                dgvPrestamos.Columns["IdFactura"].Visible = false;
            if (dgvPrestamos.Columns["DVH"] != null)
                dgvPrestamos.Columns["DVH"].Visible = false;

            if (dgvPrestamos.Columns["FechaInicio"] != null)
                dgvPrestamos.Columns["FechaInicio"].DefaultCellStyle.Format = "dd/MM/yyyy";
            if (dgvPrestamos.Columns["FechaDevolucion"] != null)
                dgvPrestamos.Columns["FechaDevolucion"].DefaultCellStyle.Format = "dd/MM/yyyy";
            if (dgvPrestamos.Columns["FechaRealDevolucion"] != null)
                dgvPrestamos.Columns["FechaRealDevolucion"].DefaultCellStyle.Format = "dd/MM/yyyy";
            if (dgvPrestamos.Columns["MontoPrestamo"] != null)
                dgvPrestamos.Columns["MontoPrestamo"].DefaultCellStyle.Format = "$ #,##0.00";
            if (dgvPrestamos.Columns["MontoRecargo"] != null)
                dgvPrestamos.Columns["MontoRecargo"].DefaultCellStyle.Format = "$ #,##0.00";

            TraducirHeadersPrestamos();
            ActualizarResumen();

            if (dgvPrestamos.Rows.Count > 0)
            {
                dgvPrestamos.Rows[0].Selected = true;
                if (dgvPrestamos.Rows[0].DataBoundItem is BEPrestamo prestamo)
                {
                    CargarDetallesPrestamo(prestamo);
                }
            }
            else
            {
                dgvDetalles.DataSource = null;
                lblDetalleInfo.Text = ServicioSessionManager.GetInstance().Traducir("Seleccione un préstamo para visualizar sus detalles.");
            }
        }

        private void ActualizarResumen()
        {
            if (dgvPrestamos.DataSource is List<BEPrestamo> prestamos)
            {
                decimal totalAcumulado = prestamos.Sum(p => p.MontoPrestamo + p.MontoRecargo);
                string textoTotal = ServicioSessionManager.GetInstance().Traducir("Total Préstamos:");
                string textoMonto = ServicioSessionManager.GetInstance().Traducir("Monto Total:");
                lblResumenPrestamos.Text = $"{textoTotal} {prestamos.Count} | {textoMonto} ${totalAcumulado:N2}";
            }
        }

        private void CargarDetallesPrestamo(BEPrestamo prestamo)
        {
            List<BEDetallePrestamo> detalles = bllPrestamo.ObtenerDetallesPorPrestamo(prestamo);
            dgvDetalles.DataSource = null;
            dgvDetalles.DataSource = detalles;

            if (dgvDetalles.Columns["IdPrestamo"] != null)
                dgvDetalles.Columns["IdPrestamo"].Visible = false;

            if (dgvDetalles.Columns["MontoPrestamo"] != null)
                dgvDetalles.Columns["MontoPrestamo"].DefaultCellStyle.Format = "$ #,##0.00";
            if (dgvDetalles.Columns["MontoRecargo"] != null)
                dgvDetalles.Columns["MontoRecargo"].DefaultCellStyle.Format = "$ #,##0.00";
            if (dgvDetalles.Columns["Total"] != null)
                dgvDetalles.Columns["Total"].DefaultCellStyle.Format = "$ #,##0.00";

            TraducirHeadersDetalles();

            string txtPrestamo = ServicioSessionManager.GetInstance().Traducir("Préstamo");
            string txtFactura = ServicioSessionManager.GetInstance().Traducir("Factura");
            string txtEstado = ServicioSessionManager.GetInstance().Traducir("Estado");
            string txtTotal = ServicioSessionManager.GetInstance().Traducir("Total");
            string nroFactura = string.IsNullOrWhiteSpace(prestamo.NumeroFactura) ? "N/A" : prestamo.NumeroFactura;
            lblDetalleInfo.Text = $"{txtPrestamo} #{prestamo.IdPrestamo} - {txtFactura}: {nroFactura} | {txtEstado}: {prestamo.Estado} | {txtTotal}: ${(prestamo.MontoPrestamo + prestamo.MontoRecargo):N2}";
        }

        private void TraducirHeadersPrestamos()
        {
            var usuarioActivo = ServicioSessionManager.GetInstance().ObtenerUsuario();
            if (usuarioActivo?.Idioma?.DiccionarioLeyendas != null)
            {
                var leyendas = usuarioActivo.Idioma.DiccionarioLeyendas;
                foreach (DataGridViewColumn columna in dgvPrestamos.Columns)
                {
                    if (leyendas.ContainsKey(columna.Name))
                    {
                        columna.HeaderText = leyendas[columna.Name];
                    }
                    else if (columna.Name == "IdPrestamo" && leyendas.ContainsKey("ID Préstamo"))
                    {
                        columna.HeaderText = leyendas["ID Préstamo"];
                    }
                    else if (columna.Name == "NumeroFactura" && leyendas.ContainsKey("Factura"))
                    {
                        columna.HeaderText = leyendas["Factura"];
                    }
                    else if (columna.Name == "DNI" && leyendas.ContainsKey("DNI Cliente"))
                    {
                        columna.HeaderText = leyendas["DNI Cliente"];
                    }
                    else if (columna.Name == "FechaInicio" && leyendas.ContainsKey("Fecha Inicio"))
                    {
                        columna.HeaderText = leyendas["Fecha Inicio"];
                    }
                    else if (columna.Name == "FechaDevolucion" && leyendas.ContainsKey("Fecha Devolución"))
                    {
                        columna.HeaderText = leyendas["Fecha Devolución"];
                    }
                    else if (columna.Name == "FechaRealDevolucion" && leyendas.ContainsKey("Fecha Real Devolución"))
                    {
                        columna.HeaderText = leyendas["Fecha Real Devolución"];
                    }
                    else if (columna.Name == "MontoPrestamo" && leyendas.ContainsKey("Monto Préstamo"))
                    {
                        columna.HeaderText = leyendas["Monto Préstamo"];
                    }
                    else if (columna.Name == "MontoRecargo" && leyendas.ContainsKey("Monto Recargo"))
                    {
                        columna.HeaderText = leyendas["Monto Recargo"];
                    }
                }
            }
        }

        private void TraducirHeadersDetalles()
        {
            var usuarioActivo = ServicioSessionManager.GetInstance().ObtenerUsuario();
            if (usuarioActivo?.Idioma?.DiccionarioLeyendas != null)
            {
                var leyendas = usuarioActivo.Idioma.DiccionarioLeyendas;
                foreach (DataGridViewColumn columna in dgvDetalles.Columns)
                {
                    if (leyendas.ContainsKey(columna.Name))
                    {
                        columna.HeaderText = leyendas[columna.Name];
                    }
                    else if (columna.Name == "DNICliente" && leyendas.ContainsKey("DNI Cliente"))
                    {
                        columna.HeaderText = leyendas["DNI Cliente"];
                    }
                    else if (columna.Name == "MontoPrestamo" && leyendas.ContainsKey("Monto Préstamo"))
                    {
                        columna.HeaderText = leyendas["Monto Préstamo"];
                    }
                    else if (columna.Name == "MontoRecargo" && leyendas.ContainsKey("Monto Recargo"))
                    {
                        columna.HeaderText = leyendas["Monto Recargo"];
                    }
                }
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            DateTime? fechaDesde = chkFiltrarFecha.Checked ? dtpFechaDesde.Value.Date : null;
            DateTime? fechaHasta = chkFiltrarFecha.Checked ? dtpFechaHasta.Value.Date : null;

            int? dni = null;
            if (!string.IsNullOrWhiteSpace(txtDniCliente.Text))
            {
                if (int.TryParse(txtDniCliente.Text.Trim(), out int parsedDni))
                {
                    dni = parsedDni;
                }
                else
                {
                    MessageBox.Show(
                        ServicioSessionManager.GetInstance().Traducir("El DNI ingresado debe contener únicamente números."),
                        ServicioSessionManager.GetInstance().Traducir("Atención"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }
            }

            List<BEPrestamo> filtradas = bllPrestamo.FiltrarPrestamos(fechaDesde, fechaHasta, dni);
            MostrarPrestamos(filtradas);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            chkFiltrarFecha.Checked = false;
            txtDniCliente.Clear();
            dtpFechaDesde.Value = DateTime.Today.AddDays(-30);
            dtpFechaHasta.Value = DateTime.Today;
            CargarPrestamos();
        }

        private void dgvPrestamos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPrestamos.CurrentRow != null && dgvPrestamos.CurrentRow.DataBoundItem is BEPrestamo prestamo)
            {
                CargarDetallesPrestamo(prestamo);
            }
        }

        private void dgvPrestamos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvPrestamos.Rows[e.RowIndex].DataBoundItem is BEPrestamo prestamo)
            {
                CargarDetallesPrestamo(prestamo);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FormSistema frmMenu = new FormSistema();
            frmMenu.Show();
            this.Close();
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {

        }

        private void FormHistorialPrestamos_FormClosing(object sender, FormClosingEventArgs e)
        {
            bllIdioma.BorrarSuscriptor(this);
        }
        
    }
}
