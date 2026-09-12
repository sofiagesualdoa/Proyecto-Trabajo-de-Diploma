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
    public partial class FormHistorialVentas : Form, IObserver
    {
        private ServicioIdioma bllIdioma = new ServicioIdioma();
        private BLLVenta bllVenta = new BLLVenta();
        private Dictionary<Control, string> textosOriginales = new Dictionary<Control, string>();

        public FormHistorialVentas()
        {
            InitializeComponent();
        }

        private void FormHistorialVentas_Load(object sender, EventArgs e)
        {
            dtpFechaDesde.Value = DateTime.Today.AddDays(-30);
            dtpFechaHasta.Value = DateTime.Today;
            chkFiltrarFecha.Checked = false;

            RegistrarTextos(this.Controls);
            bllIdioma.AgregarSuscriptor(this);

            CargarVentas();

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

            TraducirHeadersVentas();
            TraducirHeadersDetalles();
            ActualizarResumen();
        }

        private void CargarVentas()
        {
            List<BEVenta> ventas = bllVenta.ObtenerVentas();
            MostrarVentas(ventas);
        }

        private void MostrarVentas(List<BEVenta> ventas)
        {
            dgvVentas.DataSource = null;
            dgvVentas.DataSource = ventas;

            if (dgvVentas.Columns["Carrito"] != null)
                dgvVentas.Columns["Carrito"].Visible = false;
            if (dgvVentas.Columns["Cliente"] != null)
                dgvVentas.Columns["Cliente"].Visible = false;
            if (dgvVentas.Columns["DVH"] != null)
                dgvVentas.Columns["DVH"].Visible = false;

            if (dgvVentas.Columns["Fecha"] != null)
                dgvVentas.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";
            if (dgvVentas.Columns["Total"] != null)
                dgvVentas.Columns["Total"].DefaultCellStyle.Format = "$ #,##0.00";

            TraducirHeadersVentas();
            ActualizarResumen();

            if (dgvVentas.Rows.Count > 0)
            {
                dgvVentas.Rows[0].Selected = true;
                if (dgvVentas.Rows[0].DataBoundItem is BEVenta venta)
                {
                    CargarDetallesVenta(venta);
                }
            }
            else
            {
                dgvDetalles.DataSource = null;
                lblDetalleInfo.Text = ServicioSessionManager.GetInstance().Traducir("Seleccione una venta para visualizar sus detalles.");
            }
        }

        private void ActualizarResumen()
        {
            if (dgvVentas.DataSource is List<BEVenta> ventas)
            {
                decimal totalAcumulado = ventas.Sum(v => v.Total);
                string textoTotal = ServicioSessionManager.GetInstance().Traducir("Total Ventas:");
                string textoMonto = ServicioSessionManager.GetInstance().Traducir("Monto Total:");
                lblResumenVentas.Text = $"{textoTotal} {ventas.Count} | {textoMonto} ${totalAcumulado:N2}";
            }
        }

        private void CargarDetallesVenta(BEVenta venta)
        {
            List<BEDetalleVenta> detalles = bllVenta.ObtenerDetallesPorVenta(venta.IdVenta);
            dgvDetalles.DataSource = null;
            dgvDetalles.DataSource = detalles;

            if (dgvDetalles.Columns["IdDetalleVenta"] != null)
                dgvDetalles.Columns["IdDetalleVenta"].Visible = false;
            if (dgvDetalles.Columns["IdVenta"] != null)
                dgvDetalles.Columns["IdVenta"].Visible = false;
            if (dgvDetalles.Columns["IdCarrito"] != null)
                dgvDetalles.Columns["IdCarrito"].Visible = false;
            if (dgvDetalles.Columns["DVH"] != null)
                dgvDetalles.Columns["DVH"].Visible = false;
            if (dgvDetalles.Columns["Libro"] != null)
                dgvDetalles.Columns["Libro"].Visible = false;

            if (dgvDetalles.Columns["PrecioUnitario"] != null)
                dgvDetalles.Columns["PrecioUnitario"].DefaultCellStyle.Format = "$ #,##0.00";
            if (dgvDetalles.Columns["Subtotal"] != null)
                dgvDetalles.Columns["Subtotal"].DefaultCellStyle.Format = "$ #,##0.00";

            TraducirHeadersDetalles();

            string txtVenta = ServicioSessionManager.GetInstance().Traducir("Venta");
            string txtFactura = ServicioSessionManager.GetInstance().Traducir("Factura");
            string txtTotal = ServicioSessionManager.GetInstance().Traducir("Total");
            lblDetalleInfo.Text = $"{txtVenta} #{venta.IdVenta} - {txtFactura}: {venta.NumeroFactura} | {txtTotal}: ${venta.Total:N2}";
        }

        private void TraducirHeadersVentas()
        {
            var usuarioActivo = ServicioSessionManager.GetInstance().ObtenerUsuario();
            if (usuarioActivo?.Idioma?.DiccionarioLeyendas != null)
            {
                var leyendas = usuarioActivo.Idioma.DiccionarioLeyendas;
                foreach (DataGridViewColumn columna in dgvVentas.Columns)
                {
                    if (leyendas.ContainsKey(columna.Name))
                    {
                        columna.HeaderText = leyendas[columna.Name];
                    }
                    else if (columna.Name == "IdVenta" && leyendas.ContainsKey("ID Venta"))
                    {
                        columna.HeaderText = leyendas["ID Venta"];
                    }
                    else if (columna.Name == "NumeroFactura" && leyendas.ContainsKey("Factura"))
                    {
                        columna.HeaderText = leyendas["Factura"];
                    }
                    else if (columna.Name == "DNICliente" && leyendas.ContainsKey("DNI Cliente"))
                    {
                        columna.HeaderText = leyendas["DNI Cliente"];
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
                    else if (columna.Name == "PrecioUnitario" && leyendas.ContainsKey("Precio Unitario"))
                    {
                        columna.HeaderText = leyendas["Precio Unitario"];
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

            List<BEVenta> filtradas = bllVenta.FiltrarVentas(fechaDesde, fechaHasta, dni);
            MostrarVentas(filtradas);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            chkFiltrarFecha.Checked = false;
            txtDniCliente.Clear();
            dtpFechaDesde.Value = DateTime.Today.AddDays(-30);
            dtpFechaHasta.Value = DateTime.Today;
            CargarVentas();
        }

        private void dgvVentas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVentas.CurrentRow != null && dgvVentas.CurrentRow.DataBoundItem is BEVenta venta)
            {
                CargarDetallesVenta(venta);
            }
        }

        private void dgvVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvVentas.Rows[e.RowIndex].DataBoundItem is BEVenta venta)
            {
                CargarDetallesVenta(venta);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FormSistema frmMenu = new FormSistema();
            frmMenu.Show();
            this.Close();
        }

        private void FormHistorialVentas_FormClosing(object sender, FormClosingEventArgs e)
        {
            bllIdioma.BorrarSuscriptor(this);
        }
    }
}
