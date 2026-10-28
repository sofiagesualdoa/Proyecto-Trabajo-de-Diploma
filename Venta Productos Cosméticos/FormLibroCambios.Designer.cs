namespace Venta_Productos_Cosméticos
{
    partial class FormLibroCambios
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            labelTitulo = new Label();
            btnSalir = new Button();
            btnActivar = new Button();
            groupBoxFiltros = new GroupBox();
            btnLimpiar = new Button();
            btnFiltrar = new Button();
            dtpFechaHasta = new DateTimePicker();
            labelFechaHasta = new Label();
            dtpFechaDesde = new DateTimePicker();
            labelFechaDesde = new Label();
            chkFiltrarFecha = new CheckBox();
            txtTitulo = new TextBox();
            labelTituloFiltro = new Label();
            txtISBN = new TextBox();
            labelISBN = new Label();
            dgvCambios = new DataGridView();
            label1 = new Label();
            groupBoxFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCambios).BeginInit();
            SuspendLayout();
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.BackColor = Color.Sienna;
            labelTitulo.Font = new Font("Sitka Text", 18F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            labelTitulo.ForeColor = Color.Black;
            labelTitulo.Location = new Point(20, 15);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(260, 35);
            labelTitulo.TabIndex = 0;
            labelTitulo.Text = "Bitácora de Cambios";
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.Sienna;
            btnSalir.Font = new Font("Sitka Text", 9.749999F);
            btnSalir.ForeColor = Color.Black;
            btnSalir.Location = new Point(860, 15);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(110, 38);
            btnSalir.TabIndex = 1;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnActivar
            // 
            btnActivar.BackColor = Color.Sienna;
            btnActivar.Font = new Font("Sitka Text", 9.749999F);
            btnActivar.ForeColor = Color.Black;
            btnActivar.Location = new Point(720, 15);
            btnActivar.Name = "btnActivar";
            btnActivar.Size = new Size(125, 38);
            btnActivar.TabIndex = 2;
            btnActivar.Text = "Activar";
            btnActivar.UseVisualStyleBackColor = false;
            btnActivar.Click += btnActivar_Click;
            // 
            // groupBoxFiltros
            // 
            groupBoxFiltros.Controls.Add(btnLimpiar);
            groupBoxFiltros.Controls.Add(btnFiltrar);
            groupBoxFiltros.Controls.Add(dtpFechaHasta);
            groupBoxFiltros.Controls.Add(labelFechaHasta);
            groupBoxFiltros.Controls.Add(dtpFechaDesde);
            groupBoxFiltros.Controls.Add(labelFechaDesde);
            groupBoxFiltros.Controls.Add(chkFiltrarFecha);
            groupBoxFiltros.Controls.Add(txtTitulo);
            groupBoxFiltros.Controls.Add(labelTituloFiltro);
            groupBoxFiltros.Controls.Add(txtISBN);
            groupBoxFiltros.Controls.Add(labelISBN);
            groupBoxFiltros.Font = new Font("Sitka Text", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxFiltros.Location = new Point(20, 65);
            groupBoxFiltros.Name = "groupBoxFiltros";
            groupBoxFiltros.Size = new Size(950, 95);
            groupBoxFiltros.TabIndex = 3;
            groupBoxFiltros.TabStop = false;
            groupBoxFiltros.Text = "Filtros de Búsqueda";
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.Sienna;
            btnLimpiar.Font = new Font("Sitka Text", 9.749999F);
            btnLimpiar.ForeColor = Color.Black;
            btnLimpiar.Location = new Point(795, 54);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(140, 32);
            btnLimpiar.TabIndex = 10;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnFiltrar
            // 
            btnFiltrar.BackColor = Color.Sienna;
            btnFiltrar.Font = new Font("Sitka Text", 9.749999F);
            btnFiltrar.ForeColor = Color.Black;
            btnFiltrar.Location = new Point(795, 18);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(140, 32);
            btnFiltrar.TabIndex = 9;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = false;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // dtpFechaHasta
            // 
            dtpFechaHasta.Font = new Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpFechaHasta.Format = DateTimePickerFormat.Short;
            dtpFechaHasta.Location = new Point(658, 48);
            dtpFechaHasta.Name = "dtpFechaHasta";
            dtpFechaHasta.Size = new Size(115, 23);
            dtpFechaHasta.TabIndex = 8;
            // 
            // labelFechaHasta
            // 
            labelFechaHasta.AutoSize = true;
            labelFechaHasta.Font = new Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelFechaHasta.Location = new Point(587, 51);
            labelFechaHasta.Name = "labelFechaHasta";
            labelFechaHasta.Size = new Size(65, 18);
            labelFechaHasta.TabIndex = 7;
            labelFechaHasta.Text = "Fecha Fin:";
            // 
            // dtpFechaDesde
            // 
            dtpFechaDesde.Font = new Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpFechaDesde.Format = DateTimePickerFormat.Short;
            dtpFechaDesde.Location = new Point(445, 48);
            dtpFechaDesde.Name = "dtpFechaDesde";
            dtpFechaDesde.Size = new Size(115, 23);
            dtpFechaDesde.TabIndex = 6;
            // 
            // labelFechaDesde
            // 
            labelFechaDesde.AutoSize = true;
            labelFechaDesde.Font = new Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelFechaDesde.Location = new Point(360, 51);
            labelFechaDesde.Name = "labelFechaDesde";
            labelFechaDesde.Size = new Size(79, 18);
            labelFechaDesde.TabIndex = 5;
            labelFechaDesde.Text = "Fecha Inicio:";
            // 
            // chkFiltrarFecha
            // 
            chkFiltrarFecha.AutoSize = true;
            chkFiltrarFecha.Font = new Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkFiltrarFecha.Location = new Point(360, 22);
            chkFiltrarFecha.Name = "chkFiltrarFecha";
            chkFiltrarFecha.Size = new Size(120, 22);
            chkFiltrarFecha.TabIndex = 4;
            chkFiltrarFecha.Text = "Filtrar por Fecha";
            chkFiltrarFecha.UseVisualStyleBackColor = true;
            chkFiltrarFecha.CheckedChanged += chkFiltrarFecha_CheckedChanged;
            // 
            // txtTitulo
            // 
            txtTitulo.Font = new Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTitulo.Location = new Point(160, 48);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(180, 23);
            txtTitulo.TabIndex = 3;
            // 
            // labelTituloFiltro
            // 
            labelTituloFiltro.AutoSize = true;
            labelTituloFiltro.Font = new Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelTituloFiltro.Location = new Point(160, 25);
            labelTituloFiltro.Name = "labelTituloFiltro";
            labelTituloFiltro.Size = new Size(47, 18);
            labelTituloFiltro.TabIndex = 2;
            labelTituloFiltro.Text = "Título:";
            // 
            // txtISBN
            // 
            txtISBN.Font = new Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtISBN.Location = new Point(15, 48);
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(130, 23);
            txtISBN.TabIndex = 1;
            // 
            // labelISBN
            // 
            labelISBN.AutoSize = true;
            labelISBN.Font = new Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelISBN.Location = new Point(15, 25);
            labelISBN.Name = "labelISBN";
            labelISBN.Size = new Size(40, 18);
            labelISBN.TabIndex = 0;
            labelISBN.Text = "ISBN:";
            // 
            // dgvCambios
            // 
            dgvCambios.AllowUserToAddRows = false;
            dgvCambios.AllowUserToDeleteRows = false;
            dgvCambios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCambios.BackgroundColor = Color.FloralWhite;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Sienna;
            dataGridViewCellStyle1.Font = new Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvCambios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvCambios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.SandyBrown;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvCambios.DefaultCellStyle = dataGridViewCellStyle2;
            dgvCambios.EnableHeadersVisualStyles = false;
            dgvCambios.Location = new Point(20, 199);
            dgvCambios.MultiSelect = false;
            dgvCambios.Name = "dgvCambios";
            dgvCambios.ReadOnly = true;
            dgvCambios.RowHeadersVisible = false;
            dgvCambios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCambios.Size = new Size(950, 434);
            dgvCambios.TabIndex = 0;
            dgvCambios.RowPrePaint += dgvCambios_RowPrePaint;
            dgvCambios.SelectionChanged += dgvCambios_SelectionChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Text", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(28, 169);
            label1.Name = "label1";
            label1.Size = new Size(145, 19);
            label1.TabIndex = 11;
            label1.Text = "Historial de Cambios";
            // 
            // FormLibroCambios
            // 
            AutoScaleDimensions = new SizeF(7F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Tan;
            ClientSize = new Size(990, 645);
            Controls.Add(label1);
            Controls.Add(dgvCambios);
            Controls.Add(groupBoxFiltros);
            Controls.Add(btnActivar);
            Controls.Add(btnSalir);
            Controls.Add(labelTitulo);
            Font = new Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FormLibroCambios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bitácora de Cambios";
            Load += FormLibroCambios_Load;
            groupBoxFiltros.ResumeLayout(false);
            groupBoxFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCambios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnActivar;
        private System.Windows.Forms.GroupBox groupBoxFiltros;
        private System.Windows.Forms.Label labelISBN;
        private System.Windows.Forms.TextBox txtISBN;
        private System.Windows.Forms.Label labelTituloFiltro;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.CheckBox chkFiltrarFecha;
        private System.Windows.Forms.Label labelFechaDesde;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.Label labelFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnLimpiar;
        private DataGridView dgvCambios;
        private Label label1;
    }
}
