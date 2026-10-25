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
    public partial class FormCobro : Form, IObserver
    {
        private readonly BECarrito? carrito;
        private readonly BEPrestamo? prestamo;
        private readonly decimal montoRecargo;
        private readonly BECliente cliente;
        private readonly BLLFactura bllFactura = new BLLFactura();
        private readonly BLLVenta bllVenta = new BLLVenta();
        private readonly BLLPrestamo bllPrestamo = new BLLPrestamo();
        private readonly ServicioIdioma bllIdioma = new ServicioIdioma();
        private readonly Dictionary<Control, string> textosOriginales = new Dictionary<Control, string>();
        public FormCobro()
        {
            InitializeComponent();
        }
        public FormCobro(BECarrito carrito, BECliente cliente) : this()
        {
            this.carrito = carrito;
            this.cliente = cliente;
        }
        public FormCobro(BEPrestamo prestamo, BECliente cliente) : this()
        {
            this.prestamo = prestamo;
            this.cliente = cliente;
        }
        public FormCobro(BEPrestamo prestamo, BECliente cliente, decimal montoRecargo) : this()
        {
            this.prestamo = prestamo;
            this.cliente = cliente;
            this.montoRecargo = montoRecargo;
        }
        private void FormCobroVenta_Load(object sender, EventArgs e)
        {
            RegistrarTextos(this.Controls);
            bllIdioma.AgregarSuscriptor(this);
            var usuario = ServicioSessionManager.GetInstance().ObtenerUsuario();
            if (usuario?.Idioma != null)
            {
                Actualizar(usuario.Idioma);
            }
            ActualizarTextosDinamicos();
            rbtnDebito.Checked = true;
        }
        private void RegistrarTextos(Control.ControlCollection controles)
        {
            foreach (Control c in controles)
            {
                if (!string.IsNullOrEmpty(c.Text))
                    textosOriginales[c] = c.Text;
                if (c.Controls.Count > 0)
                    RegistrarTextos(c.Controls);
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
            ActualizarTextosDinamicos();
        }
        private void ActualizarTextosDinamicos()
        {
            if (cliente == null) return;
            lblCliente.Text = $"{cliente.Nombre_657SGA} {cliente.Apellido_657SGA} ({cliente.DNI_657SGA})";
            if (montoRecargo > 0)
            {
                lblTotal.Text = $"${montoRecargo:N2}";
            }
            else if (carrito != null)
            {
                lblTotal.Text = $"${carrito.Total:N2}";
            }
            else if (prestamo != null)
            {
                lblTotal.Text = $"${prestamo.MontoPrestamo:N2}";
            }
        }
        private void btnConfirmarPago_Click_1(object sender, EventArgs e)
        {
            var s = ServicioSessionManager.GetInstance();
            try
            {
                BETarjeta tarjeta = new BETarjeta
                {
                    Tipo = rbtnDebito.Checked ? "Débito" : "Crédito",
                    Banco = txtBanco.Text.Trim(),
                    Numero = txtNumeroTarjeta.Text.Trim(),
                    Titular = txtTitular.Text.Trim(),
                    Vencimiento = txtVencimiento.Text.Trim(),
                    CVV = txtCVV.Text.Trim()
                };
                if (carrito != null)
                {
                    BEPago pago = bllFactura.RealizarPago(tarjeta, carrito.Total);
                    BEFactura factura = bllVenta.ConcretarVenta(carrito, cliente, pago);
                    MessageBox.Show(string.Format(s.Traducir("¡Venta confirmada exitosamente!\nN° Factura: {0}\nImporte abonado: ${1:N2}"),
                                                  factura.NumeroFactura, factura.Total),
                                    s.Traducir("Éxito"),
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else if (prestamo != null && montoRecargo > 0)
                {
                    BEFactura factura = bllPrestamo.CobrarRecargo(prestamo, cliente, tarjeta, montoRecargo);
                    MessageBox.Show(string.Format(s.Traducir("¡Recargo por mora cobrado exitosamente!\nN° Factura: {0}\nImporte abonado: ${1:N2}"),
                                                  factura.NumeroFactura, factura.Total),
                                    s.Traducir("Éxito"),
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else if (prestamo != null)
                {
                    BEFactura factura = bllPrestamo.ConcretarPrestamo(prestamo, cliente, tarjeta);
                    MessageBox.Show(string.Format(s.Traducir("¡Préstamo confirmado exitosamente!\nN° Factura: {0}\nFecha Pactada de Devolución: {1:dd/MM/yyyy}\nImporte abonado: ${2:N2}"),
                                                  factura.NumeroFactura, prestamo.FechaDevolucion, factura.Total),
                                    s.Traducir("Éxito"),
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, s.Traducir("Error de Pago"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void FormCobroVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            bllIdioma.BorrarSuscriptor(this);
        }
    }
}
