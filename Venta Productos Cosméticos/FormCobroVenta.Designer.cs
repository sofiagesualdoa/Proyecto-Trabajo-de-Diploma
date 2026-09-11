namespace Venta_Productos_Cosméticos
{
    partial class FormCobroVenta
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
            label1 = new Label();
            lblCliente = new Label();
            lblTotal = new Label();
            label2 = new Label();
            label3 = new Label();
            rbtnDebito = new RadioButton();
            rbtnCredito = new RadioButton();
            label4 = new Label();
            txtCVV = new TextBox();
            txtVencimiento = new TextBox();
            txtTitular = new TextBox();
            txtNumeroTarjeta = new TextBox();
            txtBanco = new TextBox();
            label7 = new Label();
            label5 = new Label();
            label6 = new Label();
            label8 = new Label();
            label9 = new Label();
            btnCancelar = new Button();
            btnConfirmarPago = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Sienna;
            label1.Font = new Font("Sitka Text", 15.7499981F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label1.Location = new Point(28, 21);
            label1.Name = "label1";
            label1.Size = new Size(62, 30);
            label1.TabIndex = 33;
            label1.Text = "Pago";
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Font = new Font("Sitka Text", 12F);
            lblCliente.Location = new Point(47, 148);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(55, 23);
            lblCliente.TabIndex = 34;
            lblCliente.Text = "label2";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Sitka Text", 12F);
            lblTotal.Location = new Point(47, 248);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(55, 23);
            lblTotal.TabIndex = 35;
            lblTotal.Text = "label3";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sitka Text", 12F, FontStyle.Bold | FontStyle.Underline);
            label2.Location = new Point(47, 103);
            label2.Name = "label2";
            label2.Size = new Size(73, 23);
            label2.TabIndex = 36;
            label2.Text = "Cliente:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sitka Text", 12F, FontStyle.Bold | FontStyle.Underline);
            label3.Location = new Point(48, 200);
            label3.Name = "label3";
            label3.Size = new Size(57, 23);
            label3.TabIndex = 37;
            label3.Text = "Total:";
            // 
            // rbtnDebito
            // 
            rbtnDebito.AutoSize = true;
            rbtnDebito.Location = new Point(326, 107);
            rbtnDebito.Name = "rbtnDebito";
            rbtnDebito.Size = new Size(113, 19);
            rbtnDebito.TabIndex = 38;
            rbtnDebito.TabStop = true;
            rbtnDebito.Text = "Tarjeta de Débito";
            rbtnDebito.UseVisualStyleBackColor = true;
            // 
            // rbtnCredito
            // 
            rbtnCredito.AutoSize = true;
            rbtnCredito.Location = new Point(470, 107);
            rbtnCredito.Name = "rbtnCredito";
            rbtnCredito.Size = new Size(117, 19);
            rbtnCredito.TabIndex = 39;
            rbtnCredito.TabStop = true;
            rbtnCredito.Text = "Tarjeta de Crédito";
            rbtnCredito.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Sitka Text", 12F, FontStyle.Bold | FontStyle.Underline);
            label4.Location = new Point(326, 62);
            label4.Name = "label4";
            label4.Size = new Size(131, 23);
            label4.TabIndex = 40;
            label4.Text = "Medio de Pago:";
            // 
            // txtCVV
            // 
            txtCVV.Location = new Point(442, 278);
            txtCVV.Name = "txtCVV";
            txtCVV.Size = new Size(173, 23);
            txtCVV.TabIndex = 45;
            // 
            // txtVencimiento
            // 
            txtVencimiento.Location = new Point(553, 225);
            txtVencimiento.Name = "txtVencimiento";
            txtVencimiento.Size = new Size(173, 23);
            txtVencimiento.TabIndex = 44;
            // 
            // txtTitular
            // 
            txtTitular.Location = new Point(326, 225);
            txtTitular.Name = "txtTitular";
            txtTitular.Size = new Size(173, 23);
            txtTitular.TabIndex = 43;
            // 
            // txtNumeroTarjeta
            // 
            txtNumeroTarjeta.Location = new Point(553, 162);
            txtNumeroTarjeta.Name = "txtNumeroTarjeta";
            txtNumeroTarjeta.Size = new Size(173, 23);
            txtNumeroTarjeta.TabIndex = 42;
            // 
            // txtBanco
            // 
            txtBanco.Location = new Point(326, 162);
            txtBanco.Name = "txtBanco";
            txtBanco.Size = new Size(173, 23);
            txtBanco.TabIndex = 41;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Sitka Text", 9.749999F);
            label7.Location = new Point(394, 140);
            label7.Name = "label7";
            label7.Size = new Size(45, 19);
            label7.TabIndex = 46;
            label7.Text = "Banco";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Sitka Text", 9.749999F);
            label5.Location = new Point(600, 140);
            label5.Name = "label5";
            label5.Size = new Size(89, 19);
            label5.TabIndex = 47;
            label5.Text = "N° de tarjeta";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Sitka Text", 9.749999F);
            label6.Location = new Point(392, 203);
            label6.Name = "label6";
            label6.Size = new Size(51, 19);
            label6.TabIndex = 48;
            label6.Text = "Titular";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Sitka Text", 9.749999F);
            label8.Location = new Point(600, 203);
            label8.Name = "label8";
            label8.Size = new Size(84, 19);
            label8.TabIndex = 49;
            label8.Text = "Vencimiento";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Sitka Text", 9.749999F);
            label9.Location = new Point(511, 256);
            label9.Name = "label9";
            label9.Size = new Size(33, 19);
            label9.TabIndex = 50;
            label9.Text = "CVV";
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Sienna;
            btnCancelar.Font = new Font("Sitka Text", 9.749999F);
            btnCancelar.Location = new Point(585, 337);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(113, 57);
            btnCancelar.TabIndex = 52;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnConfirmarPago
            // 
            btnConfirmarPago.BackColor = Color.Sienna;
            btnConfirmarPago.Font = new Font("Sitka Text", 9.749999F);
            btnConfirmarPago.Location = new Point(360, 337);
            btnConfirmarPago.Name = "btnConfirmarPago";
            btnConfirmarPago.Size = new Size(113, 57);
            btnConfirmarPago.TabIndex = 51;
            btnConfirmarPago.Text = "Confirmar Pago";
            btnConfirmarPago.UseVisualStyleBackColor = false;
            btnConfirmarPago.Click += btnConfirmarPago_Click_1;
            // 
            // FormCobroVenta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Tan;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancelar);
            Controls.Add(btnConfirmarPago);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label7);
            Controls.Add(txtCVV);
            Controls.Add(txtVencimiento);
            Controls.Add(txtTitular);
            Controls.Add(txtNumeroTarjeta);
            Controls.Add(txtBanco);
            Controls.Add(label4);
            Controls.Add(rbtnCredito);
            Controls.Add(rbtnDebito);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lblTotal);
            Controls.Add(lblCliente);
            Controls.Add(label1);
            Name = "FormCobroVenta";
            Text = "FormCobroVenta";
            FormClosing += FormCobroVenta_FormClosing;
            Load += FormCobroVenta_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblCliente;
        private Label lblTotal;
        private Label label2;
        private Label label3;
        private RadioButton rbtnDebito;
        private RadioButton rbtnCredito;
        private Label label4;
        private TextBox txtCVV;
        private TextBox txtVencimiento;
        private TextBox txtTitular;
        private TextBox txtNumeroTarjeta;
        private TextBox txtBanco;
        private Label label7;
        private Label label5;
        private Label label6;
        private Label label8;
        private Label label9;
        private Button btnCancelar;
        private Button btnConfirmarPago;
    }
}