namespace Venta_Productos_Cosméticos
{
    partial class FormHistorialVentas
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
            btnLimpiar = new Button();
            btnFiltrar = new Button();
            txtDniCliente = new TextBox();
            labelDniCliente = new Label();
            chkFiltrarFecha = new CheckBox();
            dtpFechaHasta = new DateTimePicker();
            labelFechaHasta = new Label();
            dtpFechaDesde = new DateTimePicker();
            labelFechaDesde = new Label();
            groupBoxVentas = new GroupBox();
            lblResumenVentas = new Label();
            dgvVentas = new DataGridView();
            groupBoxDetalle = new GroupBox();
            dgvDetalles = new DataGridView();
            lblDetalleInfo = new Label();
            groupBoxFiltros.SuspendLayout();
            groupBoxVentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            groupBoxDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
            SuspendLayout();
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.BackColor = Color.Bisque;
            labelTitulo.Font = new Font("Sitka Text", 18F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            labelTitulo.Location = new Point(15, 12);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(243, 35);
            labelTitulo.TabIndex = 0;
            labelTitulo.Text = "Historial de Ventas";
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.Sienna;
            btnVolver.Font = new Font("Sitka Text", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVolver.ForeColor = Color.Black;
            btnVolver.Location = new Point(845, 12);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(120, 38);
            btnVolver.TabIndex = 1;
            btnVolver.Text = "Salir";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // groupBoxFiltros
            // 
            groupBoxFiltros.Controls.Add(btnLimpiar);
            groupBoxFiltros.Controls.Add(btnFiltrar);
            groupBoxFiltros.Controls.Add(txtDniCliente);
            groupBoxFiltros.Controls.Add(labelDniCliente);
            groupBoxFiltros.Controls.Add(chkFiltrarFecha);
            groupBoxFiltros.Controls.Add(dtpFechaHasta);
            groupBoxFiltros.Controls.Add(labelFechaHasta);
            groupBoxFiltros.Controls.Add(dtpFechaDesde);
            groupBoxFiltros.Controls.Add(labelFechaDesde);
            groupBoxFiltros.Font = new Font("Sitka Text", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxFiltros.Location = new Point(15, 55);
            groupBoxFiltros.Name = "groupBoxFiltros";
            groupBoxFiltros.Size = new Size(950, 85);
            groupBoxFiltros.TabIndex = 2;
            groupBoxFiltros.TabStop = false;
            groupBoxFiltros.Text = "Filtros de Búsqueda";
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.Sienna;
            btnLimpiar.Font = new Font("Sitka Text", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLimpiar.ForeColor = Color.Black;
            btnLimpiar.Location = new Point(780, 30);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(145, 42);
            btnLimpiar.TabIndex = 8;
            btnLimpiar.Text = "Limpiar Filtros";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnFiltrar
            // 
            btnFiltrar.BackColor = Color.Sienna;
            btnFiltrar.Font = new Font("Sitka Text", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFiltrar.ForeColor = Color.Black;
            btnFiltrar.Location = new Point(625, 30);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(135, 42);
            btnFiltrar.TabIndex = 7;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = false;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // txtDniCliente
            // 
            txtDniCliente.Font = new Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDniCliente.Location = new Point(440, 45);
            txtDniCliente.Name = "txtDniCliente";
            txtDniCliente.Size = new Size(140, 23);
            txtDniCliente.TabIndex = 6;
            // 
            // labelDniCliente
            // 
            labelDniCliente.AutoSize = true;
            labelDniCliente.Font = new Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelDniCliente.Location = new Point(440, 23);
            labelDniCliente.Name = "labelDniCliente";
            labelDniCliente.Size = new Size(76, 18);
            labelDniCliente.TabIndex = 5;
            labelDniCliente.Text = "DNI Cliente:";
            // 
            // chkFiltrarFecha
            // 
            chkFiltrarFecha.AutoSize = true;
            chkFiltrarFecha.Font = new Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkFiltrarFecha.Location = new Point(295, 46);
            chkFiltrarFecha.Name = "chkFiltrarFecha";
            chkFiltrarFecha.Size = new Size(120, 22);
            chkFiltrarFecha.TabIndex = 4;
            chkFiltrarFecha.Text = "Filtrar por Fecha";
            chkFiltrarFecha.UseVisualStyleBackColor = true;
            // 
            // dtpFechaHasta
            // 
            dtpFechaHasta.CustomFormat = "dd/MM/yyyy";
            dtpFechaHasta.Font = new Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpFechaHasta.Format = DateTimePickerFormat.Custom;
            dtpFechaHasta.Location = new Point(155, 45);
            dtpFechaHasta.Name = "dtpFechaHasta";
            dtpFechaHasta.Size = new Size(125, 23);
            dtpFechaHasta.TabIndex = 3;
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
            // dtpFechaDesde
            // 
            dtpFechaDesde.CustomFormat = "dd/MM/yyyy";
            dtpFechaDesde.Font = new Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpFechaDesde.Format = DateTimePickerFormat.Custom;
            dtpFechaDesde.Location = new Point(15, 45);
            dtpFechaDesde.Name = "dtpFechaDesde";
            dtpFechaDesde.Size = new Size(125, 23);
            dtpFechaDesde.TabIndex = 1;
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
            // groupBoxVentas
            // 
            groupBoxVentas.Controls.Add(lblResumenVentas);
            groupBoxVentas.Controls.Add(dgvVentas);
            groupBoxVentas.Font = new Font("Sitka Text", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxVentas.Location = new Point(15, 145);
            groupBoxVentas.Name = "groupBoxVentas";
            groupBoxVentas.Size = new Size(950, 235);
            groupBoxVentas.TabIndex = 3;
            groupBoxVentas.TabStop = false;
            groupBoxVentas.Text = "Ventas Realizadas";
            // 
            // lblResumenVentas
            // 
            lblResumenVentas.AutoSize = true;
            lblResumenVentas.Font = new Font("Sitka Text", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblResumenVentas.Location = new Point(15, 204);
            lblResumenVentas.Name = "lblResumenVentas";
            lblResumenVentas.Size = new Size(242, 19);
            lblResumenVentas.TabIndex = 1;
            lblResumenVentas.Text = "Total Ventas: 0 | Monto Total: $0.00";
            // 
            // dgvVentas
            // 
            dgvVentas.AllowUserToAddRows = false;
            dgvVentas.AllowUserToDeleteRows = false;
            dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVentas.Location = new Point(15, 25);
            dgvVentas.MultiSelect = false;
            dgvVentas.Name = "dgvVentas";
            dgvVentas.ReadOnly = true;
            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVentas.Size = new Size(920, 170);
            dgvVentas.TabIndex = 0;
            dgvVentas.CellClick += dgvVentas_CellClick;
            dgvVentas.SelectionChanged += dgvVentas_SelectionChanged;
            // 
            // groupBoxDetalle
            // 
            groupBoxDetalle.Controls.Add(dgvDetalles);
            groupBoxDetalle.Controls.Add(lblDetalleInfo);
            groupBoxDetalle.Font = new Font("Sitka Text", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxDetalle.Location = new Point(15, 385);
            groupBoxDetalle.Name = "groupBoxDetalle";
            groupBoxDetalle.Size = new Size(950, 240);
            groupBoxDetalle.TabIndex = 4;
            groupBoxDetalle.TabStop = false;
            groupBoxDetalle.Text = "Detalle de Venta Seleccionada";
            // 
            // dgvDetalles
            // 
            dgvDetalles.AllowUserToAddRows = false;
            dgvDetalles.AllowUserToDeleteRows = false;
            dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalles.Location = new Point(15, 48);
            dgvDetalles.MultiSelect = false;
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.ReadOnly = true;
            dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalles.Size = new Size(920, 175);
            dgvDetalles.TabIndex = 1;
            // 
            // lblDetalleInfo
            // 
            lblDetalleInfo.AutoSize = true;
            lblDetalleInfo.Font = new Font("Sitka Text", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDetalleInfo.Location = new Point(15, 22);
            lblDetalleInfo.Name = "lblDetalleInfo";
            lblDetalleInfo.Size = new Size(312, 19);
            lblDetalleInfo.TabIndex = 0;
            lblDetalleInfo.Text = "Seleccione una venta para visualizar sus detalles.";
            // 
            // FormHistorialVentas
            // 
            AutoScaleDimensions = new SizeF(7F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Tan;
            ClientSize = new Size(980, 640);
            Controls.Add(groupBoxDetalle);
            Controls.Add(groupBoxVentas);
            Controls.Add(groupBoxFiltros);
            Controls.Add(btnVolver);
            Controls.Add(labelTitulo);
            Font = new Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormHistorialVentas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Historial de Ventas";
            FormClosing += FormHistorialVentas_FormClosing;
            Load += FormHistorialVentas_Load;
            groupBoxFiltros.ResumeLayout(false);
            groupBoxFiltros.PerformLayout();
            groupBoxVentas.ResumeLayout(false);
            groupBoxVentas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            groupBoxDetalle.ResumeLayout(false);
            groupBoxDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label labelTitulo;
        private Button btnVolver;
        private GroupBox groupBoxFiltros;
        private Label labelFechaDesde;
        private DateTimePicker dtpFechaDesde;
        private Label labelFechaHasta;
        private DateTimePicker dtpFechaHasta;
        private CheckBox chkFiltrarFecha;
        private Label labelDniCliente;
        private TextBox txtDniCliente;
        private Button btnFiltrar;
        private Button btnLimpiar;
        private GroupBox groupBoxVentas;
        private DataGridView dgvVentas;
        private Label lblResumenVentas;
        private GroupBox groupBoxDetalle;
        private Label lblDetalleInfo;
        private DataGridView dgvDetalles;
    }
}
