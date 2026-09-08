namespace Venta_Productos_Cosméticos
{
    partial class FormVenta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnLimpiar_657SGA = new Button();
            btnConsultar_657SGA = new Button();
            dataGridViewLibros = new DataGridView();
            btnSalir_657SGA = new Button();
            textBox1_657SGA = new TextBox();
            btnAgregar_657SGA = new Button();
            label1 = new Label();
            label2 = new Label();
            dataGridViewCarrito = new DataGridView();
            button1 = new Button();
            label3 = new Label();
            btnPagar_SGA657 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLibros).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCarrito).BeginInit();
            SuspendLayout();
            // 
            // btnLimpiar_657SGA
            // 
            btnLimpiar_657SGA.BackColor = Color.Sienna;
            btnLimpiar_657SGA.Font = new Font("Sitka Text", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLimpiar_657SGA.Location = new Point(104, 62);
            btnLimpiar_657SGA.Name = "btnLimpiar_657SGA";
            btnLimpiar_657SGA.Size = new Size(86, 47);
            btnLimpiar_657SGA.TabIndex = 37;
            btnLimpiar_657SGA.Text = "Limpiar";
            btnLimpiar_657SGA.UseVisualStyleBackColor = false;
            btnLimpiar_657SGA.Click += btnLimpiar_657SGA_Click;
            // 
            // btnConsultar_657SGA
            // 
            btnConsultar_657SGA.BackColor = Color.Sienna;
            btnConsultar_657SGA.Font = new Font("Sitka Text", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnConsultar_657SGA.Location = new Point(466, 63);
            btnConsultar_657SGA.Name = "btnConsultar_657SGA";
            btnConsultar_657SGA.Size = new Size(86, 45);
            btnConsultar_657SGA.TabIndex = 31;
            btnConsultar_657SGA.Text = "Consultar";
            btnConsultar_657SGA.UseVisualStyleBackColor = false;
            btnConsultar_657SGA.Click += btnConsultar_657SGA_Click;
            // 
            // dataGridViewLibros
            // 
            dataGridViewLibros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewLibros.Location = new Point(12, 115);
            dataGridViewLibros.Name = "dataGridViewLibros";
            dataGridViewLibros.ScrollBars = ScrollBars.Vertical;
            dataGridViewLibros.Size = new Size(540, 323);
            dataGridViewLibros.TabIndex = 29;
            // 
            // btnSalir_657SGA
            // 
            btnSalir_657SGA.BackColor = Color.Sienna;
            btnSalir_657SGA.Font = new Font("Sitka Text", 9.749999F);
            btnSalir_657SGA.Location = new Point(965, 7);
            btnSalir_657SGA.Name = "btnSalir_657SGA";
            btnSalir_657SGA.Size = new Size(113, 36);
            btnSalir_657SGA.TabIndex = 36;
            btnSalir_657SGA.Text = "Salir";
            btnSalir_657SGA.UseVisualStyleBackColor = false;
            btnSalir_657SGA.Click += btnSalir_657SGA_Click;
            // 
            // textBox1_657SGA
            // 
            textBox1_657SGA.Font = new Font("Sitka Text", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1_657SGA.Location = new Point(203, 73);
            textBox1_657SGA.Name = "textBox1_657SGA";
            textBox1_657SGA.Size = new Size(248, 24);
            textBox1_657SGA.TabIndex = 30;
            // 
            // btnAgregar_657SGA
            // 
            btnAgregar_657SGA.BackColor = Color.Sienna;
            btnAgregar_657SGA.Font = new Font("Sitka Text", 9.749999F);
            btnAgregar_657SGA.Location = new Point(12, 62);
            btnAgregar_657SGA.Name = "btnAgregar_657SGA";
            btnAgregar_657SGA.Size = new Size(86, 47);
            btnAgregar_657SGA.TabIndex = 33;
            btnAgregar_657SGA.Text = "Agregar al Carrito";
            btnAgregar_657SGA.UseVisualStyleBackColor = false;
            btnAgregar_657SGA.Click += btnAgregar_657SGA_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Sienna;
            label1.Font = new Font("Sitka Text", 15.7499981F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label1.Location = new Point(25, 13);
            label1.Name = "label1";
            label1.Size = new Size(142, 30);
            label1.TabIndex = 32;
            label1.Text = "Nueva Venta";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Sienna;
            label2.Font = new Font("Sitka Text", 15.7499981F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label2.Location = new Point(617, 67);
            label2.Name = "label2";
            label2.Size = new Size(87, 30);
            label2.TabIndex = 38;
            label2.Text = "Carrito";
            // 
            // dataGridViewCarrito
            // 
            dataGridViewCarrito.AllowUserToAddRows = false;
            dataGridViewCarrito.AllowUserToDeleteRows = false;
            dataGridViewCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCarrito.Location = new Point(571, 115);
            dataGridViewCarrito.Name = "dataGridViewCarrito";
            dataGridViewCarrito.ReadOnly = true;
            dataGridViewCarrito.ScrollBars = ScrollBars.Vertical;
            dataGridViewCarrito.Size = new Size(528, 282);
            dataGridViewCarrito.TabIndex = 39;
            // 
            // button1
            // 
            button1.BackColor = Color.Sienna;
            button1.Font = new Font("Sitka Text", 9.749999F);
            button1.Location = new Point(846, 62);
            button1.Name = "button1";
            button1.Size = new Size(113, 47);
            button1.TabIndex = 40;
            button1.Text = "Vaciar Carrito";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Sienna;
            label3.Font = new Font("Sitka Text", 14.2499981F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label3.Location = new Point(617, 410);
            label3.Name = "label3";
            label3.Size = new Size(85, 28);
            label3.TabIndex = 41;
            label3.Text = "Total: $";
            // 
            // btnPagar_SGA657
            // 
            btnPagar_SGA657.BackColor = Color.Sienna;
            btnPagar_SGA657.Font = new Font("Sitka Text", 9.749999F);
            btnPagar_SGA657.Location = new Point(965, 62);
            btnPagar_SGA657.Name = "btnPagar_SGA657";
            btnPagar_SGA657.Size = new Size(113, 47);
            btnPagar_SGA657.TabIndex = 42;
            btnPagar_SGA657.Text = "Pagar";
            btnPagar_SGA657.UseVisualStyleBackColor = false;
            // 
            // FormVenta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Tan;
            ClientSize = new Size(1111, 450);
            Controls.Add(btnPagar_SGA657);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(dataGridViewCarrito);
            Controls.Add(label2);
            Controls.Add(btnLimpiar_657SGA);
            Controls.Add(btnConsultar_657SGA);
            Controls.Add(dataGridViewLibros);
            Controls.Add(btnSalir_657SGA);
            Controls.Add(textBox1_657SGA);
            Controls.Add(btnAgregar_657SGA);
            Controls.Add(label1);
            Name = "FormVenta";
            Text = "FormVenta";
            Load += FormVenta_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewLibros).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCarrito).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLimpiar_657SGA;
        private Button btnConsultar_657SGA;
        private DataGridView dataGridViewLibros;
        private Button btnSalir_657SGA;
        private TextBox textBox1_657SGA;
        private Button btnAgregar_657SGA;
        private Label label1;
        private Label label2;
        private DataGridView dataGridViewCarrito;
        private Button button1;
        private Label label3;
        private Button btnPagar_SGA657;
    }
}