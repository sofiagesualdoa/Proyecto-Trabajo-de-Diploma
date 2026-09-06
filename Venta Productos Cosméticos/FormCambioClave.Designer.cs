namespace Venta_Productos_Cosméticos
{
    partial class FormCambioClave
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCambioClave));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            btnConfirmar = new Button();
            txtClaveNueva = new TextBox();
            txtClaveActual = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txtConfirmacion = new TextBox();
            label4 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Gainsboro;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(78, 33);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(298, 256);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Bisque;
            label1.Font = new Font("Sitka Text", 18.75F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label1.Location = new Point(496, 53);
            label1.Name = "label1";
            label1.Size = new Size(217, 36);
            label1.TabIndex = 4;
            label1.Text = "Cambio de Clave";
            // 
            // btnConfirmar
            // 
            btnConfirmar.BackColor = Color.Sienna;
            btnConfirmar.Font = new Font("Sitka Text", 15.7499981F, FontStyle.Bold);
            btnConfirmar.Location = new Point(510, 323);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(184, 45);
            btnConfirmar.TabIndex = 13;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = false;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // txtClaveNueva
            // 
            txtClaveNueva.Location = new Point(496, 196);
            txtClaveNueva.Name = "txtClaveNueva";
            txtClaveNueva.Size = new Size(218, 23);
            txtClaveNueva.TabIndex = 12;
            // 
            // txtClaveActual
            // 
            txtClaveActual.Location = new Point(496, 142);
            txtClaveActual.Name = "txtClaveActual";
            txtClaveActual.Size = new Size(218, 23);
            txtClaveActual.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            label2.Location = new Point(495, 168);
            label2.Name = "label2";
            label2.Size = new Size(145, 28);
            label2.TabIndex = 10;
            label2.Text = "Nueva Clave:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            label3.Location = new Point(496, 114);
            label3.Name = "label3";
            label3.Size = new Size(146, 28);
            label3.TabIndex = 9;
            label3.Text = "Clave Actual:";
            // 
            // txtConfirmacion
            // 
            txtConfirmacion.Location = new Point(496, 250);
            txtConfirmacion.Name = "txtConfirmacion";
            txtConfirmacion.Size = new Size(218, 23);
            txtConfirmacion.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold);
            label4.Location = new Point(495, 222);
            label4.Name = "label4";
            label4.Size = new Size(157, 28);
            label4.TabIndex = 14;
            label4.Text = "Confirmación:";
            // 
            // button1
            // 
            button1.BackColor = Color.Sienna;
            button1.Font = new Font("Sitka Text", 15.7499981F, FontStyle.Bold);
            button1.Location = new Point(133, 323);
            button1.Name = "button1";
            button1.Size = new Size(184, 45);
            button1.TabIndex = 16;
            button1.Text = "Salir";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // FormCambioClave
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Tan;
            ClientSize = new Size(800, 417);
            Controls.Add(button1);
            Controls.Add(txtConfirmacion);
            Controls.Add(label4);
            Controls.Add(btnConfirmar);
            Controls.Add(txtClaveNueva);
            Controls.Add(txtClaveActual);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "FormCambioClave";
            Text = "FormCambioClave";
            FormClosing += FormCambioClave_FormClosing;
            FormClosed += FormCambioClave_FormClosed;
            Load += FormCambioClave_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Button btnConfirmar;
        private TextBox txtClaveNueva;
        private TextBox txtClaveActual;
        private Label label2;
        private Label label3;
        private TextBox txtConfirmacion;
        private Label label4;
        private Button button1;
    }
}