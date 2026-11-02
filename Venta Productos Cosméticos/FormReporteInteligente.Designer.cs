namespace Venta_Productos_Cosméticos
{
    partial class FormReporteInteligente
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            labelTitulo = new Label();
            btnVolver = new Button();
            groupBoxFiltros = new GroupBox();
            labelFechaDesde = new Label();
            dtpFechaDesde = new DateTimePicker();
            labelFechaHasta = new Label();
            dtpFechaHasta = new DateTimePicker();
            btnFiltrar = new Button();
            btnMesActual = new Button();
            btnHistorico = new Button();
            panelKPI1 = new Panel();
            lblKpi1Titulo = new Label();
            lblKpi1Valor = new Label();
            panelKPI2 = new Panel();
            lblKpi2Titulo = new Label();
            lblKpi2Valor = new Label();
            panelKPI3 = new Panel();
            lblKpi3Titulo = new Label();
            lblKpi3Valor = new Label();
            pnlGraficoEditorial = new Panel();
            pnlGraficoAutor = new Panel();
            pnlGraficoComparativa = new Panel();
            groupBoxRecomendaciones = new GroupBox();
            txtRecomendaciones = new TextBox();
            groupBoxFiltros.SuspendLayout();
            panelKPI1.SuspendLayout();
            panelKPI2.SuspendLayout();
            panelKPI3.SuspendLayout();
            groupBoxRecomendaciones.SuspendLayout();
            SuspendLayout();
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.BackColor = Color.Sienna;
            labelTitulo.Font = new Font("Sitka Text", 18F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            labelTitulo.ForeColor = Color.Black;
            labelTitulo.Location = new Point(15, 12);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(266, 35);
            labelTitulo.TabIndex = 0;
            labelTitulo.Text = "Reportes del Negocio";
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.Sienna;
            btnVolver.Font = new Font("Sitka Text", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVolver.ForeColor = Color.Black;
            btnVolver.Location = new Point(885, 12);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(120, 38);
            btnVolver.TabIndex = 1;
            btnVolver.Text = "Salir";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // groupBoxFiltros
            // 
            groupBoxFiltros.Controls.Add(labelFechaDesde);
            groupBoxFiltros.Controls.Add(dtpFechaDesde);
            groupBoxFiltros.Controls.Add(labelFechaHasta);
            groupBoxFiltros.Controls.Add(dtpFechaHasta);
            groupBoxFiltros.Controls.Add(btnFiltrar);
            groupBoxFiltros.Controls.Add(btnMesActual);
            groupBoxFiltros.Controls.Add(btnHistorico);
            groupBoxFiltros.Font = new Font("Sitka Text", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxFiltros.Location = new Point(15, 58);
            groupBoxFiltros.Name = "groupBoxFiltros";
            groupBoxFiltros.Size = new Size(990, 75);
            groupBoxFiltros.TabIndex = 2;
            groupBoxFiltros.TabStop = false;
            groupBoxFiltros.Text = "Rango de Análisis";
            // 
            // labelFechaDesde
            // 
            labelFechaDesde.AutoSize = true;
            labelFechaDesde.Font = new Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelFechaDesde.Location = new Point(15, 23);
            labelFechaDesde.Name = "labelFechaDesde";
            labelFechaDesde.Size = new Size(80, 18);
            labelFechaDesde.TabIndex = 0;
            labelFechaDesde.Text = "Fecha Desde:";
            // 
            // dtpFechaDesde
            // 
            dtpFechaDesde.CustomFormat = "dd/MM/yyyy";
            dtpFechaDesde.Font = new Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpFechaDesde.Format = DateTimePickerFormat.Custom;
            dtpFechaDesde.Location = new Point(15, 43);
            dtpFechaDesde.Name = "dtpFechaDesde";
            dtpFechaDesde.Size = new Size(120, 23);
            dtpFechaDesde.TabIndex = 1;
            // 
            // labelFechaHasta
            // 
            labelFechaHasta.AutoSize = true;
            labelFechaHasta.Font = new Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelFechaHasta.Location = new Point(155, 23);
            labelFechaHasta.Name = "labelFechaHasta";
            labelFechaHasta.Size = new Size(79, 18);
            labelFechaHasta.TabIndex = 2;
            labelFechaHasta.Text = "Fecha Hasta:";
            // 
            // dtpFechaHasta
            // 
            dtpFechaHasta.CustomFormat = "dd/MM/yyyy";
            dtpFechaHasta.Font = new Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpFechaHasta.Format = DateTimePickerFormat.Custom;
            dtpFechaHasta.Location = new Point(155, 43);
            dtpFechaHasta.Name = "dtpFechaHasta";
            dtpFechaHasta.Size = new Size(120, 23);
            dtpFechaHasta.TabIndex = 3;
            // 
            // btnFiltrar
            // 
            btnFiltrar.BackColor = Color.Sienna;
            btnFiltrar.Font = new Font("Sitka Text", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFiltrar.Location = new Point(300, 28);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(130, 38);
            btnFiltrar.TabIndex = 4;
            btnFiltrar.Text = "Actualizar";
            btnFiltrar.UseVisualStyleBackColor = false;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // btnMesActual
            // 
            btnMesActual.BackColor = Color.Sienna;
            btnMesActual.Font = new Font("Sitka Text", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMesActual.Location = new Point(445, 28);
            btnMesActual.Name = "btnMesActual";
            btnMesActual.Size = new Size(130, 38);
            btnMesActual.TabIndex = 5;
            btnMesActual.Text = "Mes Actual";
            btnMesActual.UseVisualStyleBackColor = false;
            btnMesActual.Click += btnMesActual_Click;
            // 
            // btnHistorico
            // 
            btnHistorico.BackColor = Color.Sienna;
            btnHistorico.Font = new Font("Sitka Text", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHistorico.Location = new Point(590, 28);
            btnHistorico.Name = "btnHistorico";
            btnHistorico.Size = new Size(140, 38);
            btnHistorico.TabIndex = 6;
            btnHistorico.Text = "Todo el Historial";
            btnHistorico.UseVisualStyleBackColor = false;
            btnHistorico.Click += btnHistorico_Click;
            // 
            // panelKPI1
            // 
            panelKPI1.BackColor = Color.FloralWhite;
            panelKPI1.BorderStyle = BorderStyle.FixedSingle;
            panelKPI1.Controls.Add(lblKpi1Titulo);
            panelKPI1.Controls.Add(lblKpi1Valor);
            panelKPI1.Location = new Point(15, 140);
            panelKPI1.Name = "panelKPI1";
            panelKPI1.Size = new Size(315, 62);
            panelKPI1.TabIndex = 3;
            // 
            // lblKpi1Titulo
            // 
            lblKpi1Titulo.AutoSize = true;
            lblKpi1Titulo.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            lblKpi1Titulo.ForeColor = Color.DimGray;
            lblKpi1Titulo.Location = new Point(10, 8);
            lblKpi1Titulo.Name = "lblKpi1Titulo";
            lblKpi1Titulo.Size = new Size(122, 13);
            lblKpi1Titulo.TabIndex = 0;
            lblKpi1Titulo.Text = "RECAUDACIÓN TOTAL";
            // 
            // lblKpi1Valor
            // 
            lblKpi1Valor.AutoSize = true;
            lblKpi1Valor.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            lblKpi1Valor.ForeColor = Color.DarkGreen;
            lblKpi1Valor.Location = new Point(10, 26);
            lblKpi1Valor.Name = "lblKpi1Valor";
            lblKpi1Valor.Size = new Size(66, 25);
            lblKpi1Valor.TabIndex = 1;
            lblKpi1Valor.Text = "$ 0.00";
            // 
            // panelKPI2
            // 
            panelKPI2.BackColor = Color.FloralWhite;
            panelKPI2.BorderStyle = BorderStyle.FixedSingle;
            panelKPI2.Controls.Add(lblKpi2Titulo);
            panelKPI2.Controls.Add(lblKpi2Valor);
            panelKPI2.Location = new Point(350, 140);
            panelKPI2.Name = "panelKPI2";
            panelKPI2.Size = new Size(315, 62);
            panelKPI2.TabIndex = 4;
            // 
            // lblKpi2Titulo
            // 
            lblKpi2Titulo.AutoSize = true;
            lblKpi2Titulo.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            lblKpi2Titulo.ForeColor = Color.DimGray;
            lblKpi2Titulo.Location = new Point(10, 8);
            lblKpi2Titulo.Name = "lblKpi2Titulo";
            lblKpi2Titulo.Size = new Size(101, 13);
            lblKpi2Titulo.TabIndex = 0;
            lblKpi2Titulo.Text = "VENTAS DIRECTAS";
            // 
            // lblKpi2Valor
            // 
            lblKpi2Valor.AutoSize = true;
            lblKpi2Valor.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            lblKpi2Valor.ForeColor = Color.MidnightBlue;
            lblKpi2Valor.Location = new Point(10, 26);
            lblKpi2Valor.Name = "lblKpi2Valor";
            lblKpi2Valor.Size = new Size(123, 25);
            lblKpi2Valor.TabIndex = 1;
            lblKpi2Valor.Text = "0 ejemplares";
            // 
            // panelKPI3
            // 
            panelKPI3.BackColor = Color.FloralWhite;
            panelKPI3.BorderStyle = BorderStyle.FixedSingle;
            panelKPI3.Controls.Add(lblKpi3Titulo);
            panelKPI3.Controls.Add(lblKpi3Valor);
            panelKPI3.Location = new Point(685, 140);
            panelKPI3.Name = "panelKPI3";
            panelKPI3.Size = new Size(320, 62);
            panelKPI3.TabIndex = 5;
            // 
            // lblKpi3Titulo
            // 
            lblKpi3Titulo.AutoSize = true;
            lblKpi3Titulo.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            lblKpi3Titulo.ForeColor = Color.DimGray;
            lblKpi3Titulo.Location = new Point(10, 8);
            lblKpi3Titulo.Name = "lblKpi3Titulo";
            lblKpi3Titulo.Size = new Size(164, 13);
            lblKpi3Titulo.TabIndex = 0;
            lblKpi3Titulo.Text = "CIRCULACIÓN DE PRÉSTAMOS";
            // 
            // lblKpi3Valor
            // 
            lblKpi3Valor.AutoSize = true;
            lblKpi3Valor.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            lblKpi3Valor.ForeColor = Color.Firebrick;
            lblKpi3Valor.Location = new Point(10, 26);
            lblKpi3Valor.Name = "lblKpi3Valor";
            lblKpi3Valor.Size = new Size(121, 25);
            lblKpi3Valor.TabIndex = 1;
            lblKpi3Valor.Text = "0 solicitudes";
            // 
            // pnlGraficoEditorial
            // 
            pnlGraficoEditorial.BackColor = Color.FloralWhite;
            pnlGraficoEditorial.BorderStyle = BorderStyle.FixedSingle;
            pnlGraficoEditorial.Location = new Point(15, 210);
            pnlGraficoEditorial.Name = "pnlGraficoEditorial";
            pnlGraficoEditorial.Size = new Size(315, 250);
            pnlGraficoEditorial.TabIndex = 6;
            pnlGraficoEditorial.Paint += pnlGraficoEditorial_Paint;
            // 
            // pnlGraficoAutor
            // 
            pnlGraficoAutor.BackColor = Color.FloralWhite;
            pnlGraficoAutor.BorderStyle = BorderStyle.FixedSingle;
            pnlGraficoAutor.Location = new Point(350, 210);
            pnlGraficoAutor.Name = "pnlGraficoAutor";
            pnlGraficoAutor.Size = new Size(315, 250);
            pnlGraficoAutor.TabIndex = 7;
            pnlGraficoAutor.Paint += pnlGraficoAutor_Paint;
            // 
            // pnlGraficoComparativa
            // 
            pnlGraficoComparativa.BackColor = Color.FloralWhite;
            pnlGraficoComparativa.BorderStyle = BorderStyle.FixedSingle;
            pnlGraficoComparativa.Location = new Point(685, 210);
            pnlGraficoComparativa.Name = "pnlGraficoComparativa";
            pnlGraficoComparativa.Size = new Size(320, 250);
            pnlGraficoComparativa.TabIndex = 8;
            pnlGraficoComparativa.Paint += pnlGraficoComparativa_Paint;
            // 
            // groupBoxRecomendaciones
            // 
            groupBoxRecomendaciones.Controls.Add(txtRecomendaciones);
            groupBoxRecomendaciones.Font = new Font("Sitka Text", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxRecomendaciones.Location = new Point(15, 470);
            groupBoxRecomendaciones.Name = "groupBoxRecomendaciones";
            groupBoxRecomendaciones.Size = new Size(990, 155);
            groupBoxRecomendaciones.TabIndex = 9;
            groupBoxRecomendaciones.TabStop = false;
            groupBoxRecomendaciones.Text = "Predicciones y Recomendaciones Inteligentes";
            // 
            // txtRecomendaciones
            // 
            txtRecomendaciones.BackColor = Color.FloralWhite;
            txtRecomendaciones.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRecomendaciones.Location = new Point(15, 25);
            txtRecomendaciones.Multiline = true;
            txtRecomendaciones.Name = "txtRecomendaciones";
            txtRecomendaciones.ReadOnly = true;
            txtRecomendaciones.ScrollBars = ScrollBars.Vertical;
            txtRecomendaciones.Size = new Size(960, 115);
            txtRecomendaciones.TabIndex = 0;
            // 
            // FormReporteInteligente
            // 
            AutoScaleDimensions = new SizeF(7F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Tan;
            ClientSize = new Size(1020, 640);
            Controls.Add(groupBoxRecomendaciones);
            Controls.Add(pnlGraficoComparativa);
            Controls.Add(pnlGraficoAutor);
            Controls.Add(pnlGraficoEditorial);
            Controls.Add(panelKPI3);
            Controls.Add(panelKPI2);
            Controls.Add(panelKPI1);
            Controls.Add(groupBoxFiltros);
            Controls.Add(btnVolver);
            Controls.Add(labelTitulo);
            Font = new Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormReporteInteligente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reporte Inteligente de Negocio";
            FormClosing += FormReporteInteligente_FormClosing;
            Load += FormReporteInteligente_Load;
            groupBoxFiltros.ResumeLayout(false);
            groupBoxFiltros.PerformLayout();
            panelKPI1.ResumeLayout(false);
            panelKPI1.PerformLayout();
            panelKPI2.ResumeLayout(false);
            panelKPI2.PerformLayout();
            panelKPI3.ResumeLayout(false);
            panelKPI3.PerformLayout();
            groupBoxRecomendaciones.ResumeLayout(false);
            groupBoxRecomendaciones.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.GroupBox groupBoxFiltros;
        private System.Windows.Forms.Label labelFechaDesde;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.Label labelFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnMesActual;
        private System.Windows.Forms.Button btnHistorico;
        private System.Windows.Forms.Panel panelKPI1;
        private System.Windows.Forms.Label lblKpi1Titulo;
        private System.Windows.Forms.Label lblKpi1Valor;
        private System.Windows.Forms.Panel panelKPI2;
        private System.Windows.Forms.Label lblKpi2Titulo;
        private System.Windows.Forms.Label lblKpi2Valor;
        private System.Windows.Forms.Panel panelKPI3;
        private System.Windows.Forms.Label lblKpi3Titulo;
        private System.Windows.Forms.Label lblKpi3Valor;
        private System.Windows.Forms.Panel pnlGraficoEditorial;
        private System.Windows.Forms.Panel pnlGraficoAutor;
        private System.Windows.Forms.Panel pnlGraficoComparativa;
        private System.Windows.Forms.GroupBox groupBoxRecomendaciones;
        private System.Windows.Forms.TextBox txtRecomendaciones;
    }
}