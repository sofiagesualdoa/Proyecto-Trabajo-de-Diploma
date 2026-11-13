namespace Venta_Productos_Cosméticos
{
    partial class FormAyudaContextual
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblSubtituloHeader = new Label();
            lblTituloHeader = new Label();
            pnlFiltros = new Panel();
            txtBuscar = new TextBox();
            lblBuscar = new Label();
            cmbModulos = new ComboBox();
            lblModulo = new Label();
            rtbContenido = new RichTextBox();
            pnlFooter = new Panel();
            btnCerrar = new Button();
            btnAbrirManual = new Button();
            pnlHeader.SuspendLayout();
            pnlFiltros.SuspendLayout();
            pnlFooter.SuspendLayout();
            SuspendLayout();

            pnlHeader.BackColor = Color.Sienna;
            pnlHeader.Controls.Add(lblSubtituloHeader);
            pnlHeader.Controls.Add(lblTituloHeader);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(884, 65);
            pnlHeader.TabIndex = 0;

            lblSubtituloHeader.AutoSize = true;
            lblSubtituloHeader.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtituloHeader.ForeColor = Color.FloralWhite;
            lblSubtituloHeader.Location = new Point(16, 38);
            lblSubtituloHeader.Name = "lblSubtituloHeader";
            lblSubtituloHeader.Size = new Size(543, 15);
            lblSubtituloHeader.TabIndex = 1;
            lblSubtituloHeader.Text = "Guía operativa contextual paso a paso. Presione F1 en cualquier pantalla para asistencia inmediata.";

            lblTituloHeader.AutoSize = true;
            lblTituloHeader.Font = new Font("Segoe UI", 13.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloHeader.ForeColor = Color.White;
            lblTituloHeader.Location = new Point(14, 10);
            lblTituloHeader.Name = "lblTituloHeader";
            lblTituloHeader.Size = new Size(415, 25);
            lblTituloHeader.TabIndex = 0;
            lblTituloHeader.Text = "📖 Centro de Ayuda y Asistencia al Usuario (F1)";

            pnlFiltros.BackColor = Color.FromArgb(245, 240, 235);
            pnlFiltros.Controls.Add(txtBuscar);
            pnlFiltros.Controls.Add(lblBuscar);
            pnlFiltros.Controls.Add(cmbModulos);
            pnlFiltros.Controls.Add(lblModulo);
            pnlFiltros.Dock = DockStyle.Top;
            pnlFiltros.Location = new Point(0, 65);
            pnlFiltros.Name = "pnlFiltros";
            pnlFiltros.Size = new Size(884, 46);
            pnlFiltros.TabIndex = 1;

            txtBuscar.Font = new Font("Segoe UI", 9.5F);
            txtBuscar.Location = new Point(576, 11);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar tema o palabra clave...";
            txtBuscar.Size = new Size(294, 24);
            txtBuscar.TabIndex = 3;
            txtBuscar.TextChanged += txtBuscar_TextChanged;

            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblBuscar.ForeColor = Color.FromArgb(45, 55, 72);
            lblBuscar.Location = new Point(518, 14);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(52, 17);
            lblBuscar.TabIndex = 2;
            lblBuscar.Text = "Buscar:";

            cmbModulos.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbModulos.Font = new Font("Segoe UI", 9.5F);
            cmbModulos.FormattingEnabled = true;
            cmbModulos.Location = new Point(148, 11);
            cmbModulos.Name = "cmbModulos";
            cmbModulos.Size = new Size(346, 24);
            cmbModulos.TabIndex = 1;
            cmbModulos.SelectedIndexChanged += cmbModulos_SelectedIndexChanged;

            lblModulo.AutoSize = true;
            lblModulo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblModulo.ForeColor = Color.FromArgb(45, 55, 72);
            lblModulo.Location = new Point(16, 14);
            lblModulo.Name = "lblModulo";
            lblModulo.Size = new Size(126, 17);
            lblModulo.TabIndex = 0;
            lblModulo.Text = "Módulo / Pantalla:";

            rtbContenido.BackColor = Color.White;
            rtbContenido.BorderStyle = BorderStyle.None;
            rtbContenido.Dock = DockStyle.Fill;
            rtbContenido.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rtbContenido.Location = new Point(0, 111);
            rtbContenido.Name = "rtbContenido";
            rtbContenido.ReadOnly = true;
            rtbContenido.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbContenido.Size = new Size(884, 420);
            rtbContenido.TabIndex = 2;
            rtbContenido.Text = "";

            pnlFooter.BackColor = Color.FromArgb(240, 235, 230);
            pnlFooter.Controls.Add(btnCerrar);
            pnlFooter.Controls.Add(btnAbrirManual);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 531);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(884, 49);
            pnlFooter.TabIndex = 3;

            btnCerrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCerrar.BackColor = Color.Gainsboro;
            btnCerrar.Cursor = Cursors.Hand;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnCerrar.ForeColor = Color.FromArgb(45, 55, 72);
            btnCerrar.Location = new Point(748, 8);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(122, 33);
            btnCerrar.TabIndex = 1;
            btnCerrar.Text = "Cerrar (Esc)";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;

            btnAbrirManual.BackColor = Color.Sienna;
            btnAbrirManual.Cursor = Cursors.Hand;
            btnAbrirManual.FlatStyle = FlatStyle.Flat;
            btnAbrirManual.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnAbrirManual.ForeColor = Color.White;
            btnAbrirManual.Location = new Point(16, 8);
            btnAbrirManual.Name = "btnAbrirManual";
            btnAbrirManual.Size = new Size(290, 33);
            btnAbrirManual.TabIndex = 0;
            btnAbrirManual.Text = "📖 Abrir Manual de Usuario Completo (PDF)";
            btnAbrirManual.UseVisualStyleBackColor = false;
            btnAbrirManual.Click += btnAbrirManual_Click;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 580);
            Controls.Add(rtbContenido);
            Controls.Add(pnlFooter);
            Controls.Add(pnlFiltros);
            Controls.Add(pnlHeader);
            KeyPreview = true;
            MinimumSize = new Size(750, 480);
            Name = "FormAyudaContextual";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Centro de Ayuda Contextual - Bookly";
            KeyDown += FormAyudaContextual_KeyDown;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlFiltros.ResumeLayout(false);
            pnlFiltros.PerformLayout();
            pnlFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTituloHeader;
        private Label lblSubtituloHeader;
        private Panel pnlFiltros;
        private ComboBox cmbModulos;
        private Label lblModulo;
        private TextBox txtBuscar;
        private Label lblBuscar;
        private RichTextBox rtbContenido;
        private Panel pnlFooter;
        private Button btnAbrirManual;
        private Button btnCerrar;
    }
}
