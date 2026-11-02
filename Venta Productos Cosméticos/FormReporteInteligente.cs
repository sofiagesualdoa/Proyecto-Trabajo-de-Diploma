using BE;
using BLL;
using Servicios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace Venta_Productos_Cosméticos
{
    public partial class FormReporteInteligente : Form, IObserver
    {
        private readonly BLLReporteInteligente bllReporte = new BLLReporteInteligente();
        private readonly ServicioIdioma bllIdioma = new ServicioIdioma();
        private readonly Dictionary<Control, string> textosOriginales = new Dictionary<Control, string>();
        private BEReporteInteligente? reporteActual;

        private readonly Color[] paletaColores = new Color[]
        {
            Color.FromArgb(41, 128, 185),
            Color.FromArgb(39, 174, 96),
            Color.FromArgb(243, 156, 18),
            Color.FromArgb(192, 57, 43),
            Color.FromArgb(142, 68, 173),
            Color.FromArgb(22, 160, 133)
        };

        public FormReporteInteligente()
        {
            InitializeComponent();
        }

        private void FormReporteInteligente_Load(object sender, EventArgs e)
        {
            dtpFechaDesde.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpFechaHasta.Value = DateTime.Today;

            RegistrarTextos(this.Controls);
            bllIdioma.AgregarSuscriptor(this);

            var usuario = ServicioSessionManager.GetInstance().ObtenerUsuario();
            if (usuario?.Idioma != null)
            {
                Actualizar(usuario.Idioma);
            }

            CargarReporte();
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
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarReporte();
        }

        private void btnMesActual_Click(object sender, EventArgs e)
        {
            dtpFechaDesde.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpFechaHasta.Value = DateTime.Today;
            CargarReporte();
        }

        private void btnHistorico_Click(object sender, EventArgs e)
        {
            dtpFechaDesde.Value = new DateTime(2020, 1, 1);
            dtpFechaHasta.Value = DateTime.Today;
            CargarReporte();
        }

        private void CargarReporte()
        {
            try
            {
                reporteActual = bllReporte.GenerarReporte(dtpFechaDesde.Value, dtpFechaHasta.Value);
                ActualizarKPIs();
                ActualizarRecomendaciones();

                pnlGraficoEditorial.Invalidate();
                pnlGraficoAutor.Invalidate();
                pnlGraficoComparativa.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ServicioSessionManager.GetInstance().Traducir("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarKPIs()
        {
            if (reporteActual == null) return;

            lblKpi1Valor.Text = $"$ {reporteActual.IngresosTotales:N2}";
            lblKpi2Valor.Text = $"{reporteActual.TotalEjemplaresVendidos} ej. (${reporteActual.MontoTotalVentas:N2})";
            lblKpi3Valor.Text = $"{reporteActual.TotalPrestamosRealizados} sol. (${(reporteActual.MontoTotalPrestamos + reporteActual.MontoTotalRecargosMora):N2})";
        }

        private void ActualizarRecomendaciones()
        {
            if (reporteActual == null || reporteActual.Recomendaciones == null)
            {
                txtRecomendaciones.Text = string.Empty;
                return;
            }

            txtRecomendaciones.Text = string.Join(Environment.NewLine + Environment.NewLine, reporteActual.Recomendaciones);
        }

        private void pnlGraficoEditorial_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (Font fuenteTitulo = new Font("Segoe UI", 10F, FontStyle.Bold))
            using (Brush brochaTitulo = new SolidBrush(Color.FromArgb(45, 55, 72)))
            {
                g.DrawString(ServicioSessionManager.GetInstance().Traducir("Ventas por Editorial ($)"), fuenteTitulo, brochaTitulo, 10, 10);
            }

            if (reporteActual == null || reporteActual.VentasPorEditorial.Count == 0 || reporteActual.VentasPorEditorial.All(x => x.TotalRecaudado <= 0))
            {
                DibujarSinDatos(g, pnlGraficoEditorial.ClientRectangle);
                return;
            }

            Rectangle rectTorta = new Rectangle(12, 38, 120, 120);
            float anguloInicio = 0f;

            for (int i = 0; i < reporteActual.VentasPorEditorial.Count; i++)
            {
                var item = reporteActual.VentasPorEditorial[i];
                float barrido = (float)(item.Porcentaje * 3.6m);
                if (barrido <= 0) continue;

                Color colorSector = paletaColores[i % paletaColores.Length];
                using (SolidBrush brocha = new SolidBrush(colorSector))
                {
                    g.FillPie(brocha, rectTorta, anguloInicio, barrido);
                }
                using (Pen lapiz = new Pen(Color.White, 2f))
                {
                    g.DrawPie(lapiz, rectTorta, anguloInicio, barrido);
                }
                anguloInicio += barrido;
            }

            using (SolidBrush brochaCentro = new SolidBrush(Color.FloralWhite))
            {
                Rectangle rectCentro = new Rectangle(rectTorta.X + 35, rectTorta.Y + 35, 50, 50);
                g.FillEllipse(brochaCentro, rectCentro);
            }

            int leyX = 142;
            int leyY = 38;
            using (Font fuenteTexto = new Font("Segoe UI", 8F, FontStyle.Bold))
            using (Font fuenteMonto = new Font("Segoe UI", 7.5F, FontStyle.Regular))
            using (Brush brochaTexto = new SolidBrush(Color.FromArgb(30, 41, 59)))
            using (Brush brochaGris = new SolidBrush(Color.DimGray))
            {
                for (int i = 0; i < reporteActual.VentasPorEditorial.Count && i < 5; i++)
                {
                    var item = reporteActual.VentasPorEditorial[i];
                    Color col = paletaColores[i % paletaColores.Length];

                    using (SolidBrush b = new SolidBrush(col))
                    {
                        g.FillRectangle(b, leyX, leyY + 2, 10, 10);
                    }

                    string texto = item.Etiqueta.Length > 13 ? item.Etiqueta.Substring(0, 13) + ".." : item.Etiqueta;
                    g.DrawString($"{texto} ({item.Porcentaje}%)", fuenteTexto, brochaTexto, leyX + 14, leyY);
                    g.DrawString($"${item.TotalRecaudado:N0}", fuenteMonto, brochaGris, leyX + 14, leyY + 14);

                    leyY += 34;
                }
            }
        }

        private void pnlGraficoAutor_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (Font fuenteTitulo = new Font("Segoe UI", 10F, FontStyle.Bold))
            using (Brush brochaTitulo = new SolidBrush(Color.FromArgb(45, 55, 72)))
            {
                g.DrawString(ServicioSessionManager.GetInstance().Traducir("Demanda por Autor (Ventas+Préstamos)"), fuenteTitulo, brochaTitulo, 10, 10);
            }

            if (reporteActual == null || reporteActual.DemandaPorAutor.Count == 0 || reporteActual.DemandaPorAutor.All(x => x.Cantidad <= 0))
            {
                DibujarSinDatos(g, pnlGraficoAutor.ClientRectangle);
                return;
            }

            Rectangle rectTorta = new Rectangle(12, 38, 120, 120);
            float anguloInicio = 0f;

            for (int i = 0; i < reporteActual.DemandaPorAutor.Count; i++)
            {
                var item = reporteActual.DemandaPorAutor[i];
                float barrido = (float)(item.Porcentaje * 3.6m);
                if (barrido <= 0) continue;

                Color colorSector = paletaColores[(i + 2) % paletaColores.Length];
                using (SolidBrush brocha = new SolidBrush(colorSector))
                {
                    g.FillPie(brocha, rectTorta, anguloInicio, barrido);
                }
                using (Pen lapiz = new Pen(Color.White, 2f))
                {
                    g.DrawPie(lapiz, rectTorta, anguloInicio, barrido);
                }
                anguloInicio += barrido;
            }

            using (SolidBrush brochaCentro = new SolidBrush(Color.FloralWhite))
            {
                Rectangle rectCentro = new Rectangle(rectTorta.X + 35, rectTorta.Y + 35, 50, 50);
                g.FillEllipse(brochaCentro, rectCentro);
            }

            int leyX = 142;
            int leyY = 38;
            using (Font fuenteTexto = new Font("Segoe UI", 8F, FontStyle.Bold))
            using (Font fuenteMonto = new Font("Segoe UI", 7.5F, FontStyle.Regular))
            using (Brush brochaTexto = new SolidBrush(Color.FromArgb(30, 41, 59)))
            using (Brush brochaGris = new SolidBrush(Color.DimGray))
            {
                for (int i = 0; i < reporteActual.DemandaPorAutor.Count && i < 5; i++)
                {
                    var item = reporteActual.DemandaPorAutor[i];
                    Color col = paletaColores[(i + 2) % paletaColores.Length];

                    using (SolidBrush b = new SolidBrush(col))
                    {
                        g.FillRectangle(b, leyX, leyY + 2, 10, 10);
                    }

                    string texto = item.Etiqueta.Length > 13 ? item.Etiqueta.Substring(0, 13) + ".." : item.Etiqueta;
                    g.DrawString($"{texto} ({item.Porcentaje}%)", fuenteTexto, brochaTexto, leyX + 14, leyY);
                    g.DrawString($"{item.Cantidad} ej.", fuenteMonto, brochaGris, leyX + 14, leyY + 14);

                    leyY += 34;
                }
            }
        }

        private void pnlGraficoComparativa_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (Font fuenteTitulo = new Font("Segoe UI", 10F, FontStyle.Bold))
            using (Brush brochaTitulo = new SolidBrush(Color.FromArgb(45, 55, 72)))
            {
                g.DrawString(ServicioSessionManager.GetInstance().Traducir("Rendimiento: Ventas vs. Préstamos"), fuenteTitulo, brochaTitulo, 10, 10);
            }

            if (reporteActual == null || reporteActual.ComparativaVentasVsPrestamos == null)
            {
                DibujarSinDatos(g, pnlGraficoComparativa.ClientRectangle);
                return;
            }

            int inicioY = 48;
            int anchoMaximoBarra = 240;

            using (Font fuenteItem = new Font("Segoe UI", 8.5F, FontStyle.Bold))
            using (Font fuenteValores = new Font("Segoe UI", 8F, FontStyle.Regular))
            using (Brush brochaTexto = new SolidBrush(Color.FromArgb(30, 41, 59)))
            using (Brush brochaGris = new SolidBrush(Color.DimGray))
            {
                for (int i = 0; i < reporteActual.ComparativaVentasVsPrestamos.Count; i++)
                {
                    var item = reporteActual.ComparativaVentasVsPrestamos[i];
                    Color colorBarra = (i == 0) ? Color.FromArgb(41, 128, 185) : Color.FromArgb(230, 126, 34);

                    g.DrawString(item.Etiqueta, fuenteItem, brochaTexto, 15, inicioY);

                    float porcentaje = (float)item.Porcentaje;
                    int anchoBarra = Math.Max(6, (int)((porcentaje / 100f) * anchoMaximoBarra));

                    using (SolidBrush brochaFondo = new SolidBrush(Color.FromArgb(235, 238, 242)))
                    {
                        g.FillRectangle(brochaFondo, 15, inicioY + 18, anchoMaximoBarra, 18);
                    }

                    using (SolidBrush brochaBarra = new SolidBrush(colorBarra))
                    {
                        g.FillRectangle(brochaBarra, 15, inicioY + 18, anchoBarra, 18);
                    }

                    g.DrawString($"{item.Porcentaje}%  |  ${item.TotalRecaudado:N2} ({item.Cantidad} ops)", fuenteValores, brochaGris, 15, inicioY + 40);

                    inicioY += 68;
                }
            }
        }

        private void DibujarSinDatos(Graphics g, Rectangle rect)
        {
            using (Font f = new Font("Segoe UI", 9F, FontStyle.Italic))
            using (Brush b = new SolidBrush(Color.Gray))
            {
                string mensaje = ServicioSessionManager.GetInstance().Traducir("Sin datos para graficar en el rango seleccionado.");
                SizeF tam = g.MeasureString(mensaje, f);
                float x = rect.X + (rect.Width - tam.Width) / 2f;
                float y = rect.Y + (rect.Height - tam.Height) / 2f;
                g.DrawString(mensaje, f, b, x, y);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FormSistema frmMenu = new FormSistema();
            frmMenu.Show();
            this.Close();
        }

        private void FormReporteInteligente_FormClosing(object sender, FormClosingEventArgs e)
        {
            bllIdioma.BorrarSuscriptor(this);
        }
    }
}
