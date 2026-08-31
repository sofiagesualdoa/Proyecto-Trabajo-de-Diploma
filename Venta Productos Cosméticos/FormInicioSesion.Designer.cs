namespace Venta_Productos_Cosméticos
{
    partial class FormInicioSesion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInicioSesion));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            txtUsuario = new TextBox();
            txtContraseña = new TextBox();
            btnIniciar = new Button();
            btnCambioIdioma = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.LightGray;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(75, 125);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(312, 276);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Bisque;
            label1.Font = new Font("Sitka Text", 14.2499981F, FontStyle.Bold);
            label1.Location = new Point(421, 202);
            label1.Name = "label1";
            label1.Size = new Size(93, 28);
            label1.TabIndex = 4;
            label1.Text = "Usuario:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Bisque;
            label2.Font = new Font("Sitka Text", 14.2499981F, FontStyle.Bold);
            label2.Location = new Point(406, 247);
            label2.Name = "label2";
            label2.Size = new Size(125, 28);
            label2.TabIndex = 5;
            label2.Text = "Contraseña:";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(537, 204);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(218, 23);
            txtUsuario.TabIndex = 6;
            // 
            // txtContraseña
            // 
            txtContraseña.Location = new Point(537, 250);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(218, 23);
            txtContraseña.TabIndex = 7;
            // 
            // btnIniciar
            // 
            btnIniciar.BackColor = Color.Bisque;
            btnIniciar.Font = new Font("Sitka Text", 15.7499981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIniciar.Location = new Point(508, 317);
            btnIniciar.Name = "btnIniciar";
            btnIniciar.Size = new Size(184, 45);
            btnIniciar.TabIndex = 8;
            btnIniciar.Text = "Confirmar";
            btnIniciar.UseVisualStyleBackColor = false;
            btnIniciar.Click += btnIniciar_Click;
            // 
            // btnCambioIdioma
            // 
            btnCambioIdioma.BackColor = Color.Bisque;
            btnCambioIdioma.Font = new Font("Sitka Text", 15.7499981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCambioIdioma.Location = new Point(266, 63);
            btnCambioIdioma.Name = "btnCambioIdioma";
            btnCambioIdioma.Size = new Size(290, 45);
            btnCambioIdioma.TabIndex = 9;
            btnCambioIdioma.Text = "Cambiar Idioma";
            btnCambioIdioma.UseVisualStyleBackColor = false;
            btnCambioIdioma.Click += btnCambioIdioma_Click;
            // 
            // FormInicioSesion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Tan;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCambioIdioma);
            Controls.Add(btnIniciar);
            Controls.Add(txtContraseña);
            Controls.Add(txtUsuario);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "FormInicioSesion";
            Text = "Inicio de Sesión";
            TopMost = true;
            FormClosing += FormInicioSesion_FormClosing;
            FormClosed += FormInicioSesion_FormClosed;
            Load += FormInicioSesion_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private TextBox txtUsuario;
        private TextBox txtContraseña;
        private Button btnIniciar;
        private Button btnCambioIdioma;
    }
}