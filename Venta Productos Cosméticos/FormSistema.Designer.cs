namespace Venta_Productos_Cosméticos
{
    partial class FormSistema
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSistema));
            menuStrip1 = new MenuStrip();
            usuarioToolStripMenuItem = new ToolStripMenuItem();
            cambiarClaveToolStripMenuItem = new ToolStripMenuItem();
            cambiarIdiomaToolStripMenuItem = new ToolStripMenuItem();
            españolToolStripMenuItem = new ToolStripMenuItem();
            inglésToolStripMenuItem = new ToolStripMenuItem();
            reLoginToolStripMenuItem = new ToolStripMenuItem();
            administraciónToolStripMenuItem = new ToolStripMenuItem();
            usuariosToolStripMenuItem = new ToolStripMenuItem();
            perfilesToolStripMenuItem = new ToolStripMenuItem();
            bitácoraEventosToolStripMenuItem = new ToolStripMenuItem();
            bitácoraCambiosToolStripMenuItem = new ToolStripMenuItem();
            backUpToolStripMenuItem = new ToolStripMenuItem();
            restoreToolStripMenuItem = new ToolStripMenuItem();
            ventasToolStripMenuItem = new ToolStripMenuItem();
            nuevaVentaToolStripMenuItem = new ToolStripMenuItem();
            nuevoPréstamoToolStripMenuItem = new ToolStripMenuItem();
            historialVentasToolStripMenuItem = new ToolStripMenuItem();
            historialPréstamosToolStripMenuItem = new ToolStripMenuItem();
            inventarioToolStripMenuItem = new ToolStripMenuItem();
            librosToolStripMenuItem = new ToolStripMenuItem();
            clientesToolStripMenuItem = new ToolStripMenuItem();
            librosCToolStripMenuItem = new ToolStripMenuItem();
            reportesToolStripMenuItem = new ToolStripMenuItem();
            productosMásVendidosToolStripMenuItem = new ToolStripMenuItem();
            productosMenosVendidosToolStripMenuItem = new ToolStripMenuItem();
            productosConBajoStockToolStripMenuItem = new ToolStripMenuItem();
            centroDeAyudaToolStripMenuItem = new ToolStripMenuItem();
            manualDeUsuarioToolStripMenuItem = new ToolStripMenuItem();
            guíaDeInstalaciónArchivoLeémeToolStripMenuItem = new ToolStripMenuItem();
            cerrarSesiónToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            label2 = new Label();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.Sienna;
            menuStrip1.Font = new Font("Sitka Text", 12.7499981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuStrip1.Items.AddRange(new ToolStripItem[] { usuarioToolStripMenuItem, administraciónToolStripMenuItem, ventasToolStripMenuItem, inventarioToolStripMenuItem, reportesToolStripMenuItem, centroDeAyudaToolStripMenuItem, cerrarSesiónToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 32);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // usuarioToolStripMenuItem
            // 
            usuarioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cambiarClaveToolStripMenuItem, cambiarIdiomaToolStripMenuItem, reLoginToolStripMenuItem });
            usuarioToolStripMenuItem.Font = new Font("Sitka Text", 12.7499981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            usuarioToolStripMenuItem.Name = "usuarioToolStripMenuItem";
            usuarioToolStripMenuItem.Size = new Size(89, 28);
            usuarioToolStripMenuItem.Tag = "";
            usuarioToolStripMenuItem.Text = "Usuario";
            // 
            // cambiarClaveToolStripMenuItem
            // 
            cambiarClaveToolStripMenuItem.Name = "cambiarClaveToolStripMenuItem";
            cambiarClaveToolStripMenuItem.Size = new Size(216, 28);
            cambiarClaveToolStripMenuItem.Tag = "Cambiar Clave";
            cambiarClaveToolStripMenuItem.Text = "Cambiar Clave";
            cambiarClaveToolStripMenuItem.Click += cambiarClaveToolStripMenuItem_Click;
            // 
            // cambiarIdiomaToolStripMenuItem
            // 
            cambiarIdiomaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { españolToolStripMenuItem, inglésToolStripMenuItem });
            cambiarIdiomaToolStripMenuItem.Name = "cambiarIdiomaToolStripMenuItem";
            cambiarIdiomaToolStripMenuItem.Size = new Size(216, 28);
            cambiarIdiomaToolStripMenuItem.Tag = "Cambiar Idioma";
            cambiarIdiomaToolStripMenuItem.Text = "Cambiar Idioma";
            cambiarIdiomaToolStripMenuItem.Click += cambiarIdiomaToolStripMenuItem_Click;
            // 
            // españolToolStripMenuItem
            // 
            españolToolStripMenuItem.Name = "españolToolStripMenuItem";
            españolToolStripMenuItem.Size = new Size(148, 28);
            españolToolStripMenuItem.Text = "Español";
            españolToolStripMenuItem.Click += españolToolStripMenuItem_Click;
            // 
            // inglésToolStripMenuItem
            // 
            inglésToolStripMenuItem.Name = "inglésToolStripMenuItem";
            inglésToolStripMenuItem.Size = new Size(148, 28);
            inglésToolStripMenuItem.Text = "Inglés";
            inglésToolStripMenuItem.Click += inglésToolStripMenuItem_Click;
            // 
            // reLoginToolStripMenuItem
            // 
            reLoginToolStripMenuItem.Name = "reLoginToolStripMenuItem";
            reLoginToolStripMenuItem.Size = new Size(216, 28);
            reLoginToolStripMenuItem.Tag = "ReLogin";
            reLoginToolStripMenuItem.Text = "ReLogin";
            reLoginToolStripMenuItem.Click += reLoginToolStripMenuItem_Click;
            // 
            // administraciónToolStripMenuItem
            // 
            administraciónToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { usuariosToolStripMenuItem, perfilesToolStripMenuItem, bitácoraEventosToolStripMenuItem, bitácoraCambiosToolStripMenuItem, backUpToolStripMenuItem, restoreToolStripMenuItem });
            administraciónToolStripMenuItem.Name = "administraciónToolStripMenuItem";
            administraciónToolStripMenuItem.Size = new Size(153, 28);
            administraciónToolStripMenuItem.Text = "Administración";
            // 
            // usuariosToolStripMenuItem
            // 
            usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            usuariosToolStripMenuItem.Size = new Size(227, 28);
            usuariosToolStripMenuItem.Tag = "Gestionar Usuarios";
            usuariosToolStripMenuItem.Text = "Usuarios";
            usuariosToolStripMenuItem.Click += usuariosToolStripMenuItem_Click;
            // 
            // perfilesToolStripMenuItem
            // 
            perfilesToolStripMenuItem.Name = "perfilesToolStripMenuItem";
            perfilesToolStripMenuItem.Size = new Size(227, 28);
            perfilesToolStripMenuItem.Tag = "Gestionar Perfiles";
            perfilesToolStripMenuItem.Text = "Perfiles";
            perfilesToolStripMenuItem.Click += perfilesToolStripMenuItem_Click;
            // 
            // bitácoraEventosToolStripMenuItem
            // 
            bitácoraEventosToolStripMenuItem.Name = "bitácoraEventosToolStripMenuItem";
            bitácoraEventosToolStripMenuItem.Size = new Size(227, 28);
            bitácoraEventosToolStripMenuItem.Tag = "Auditar Bitacora";
            bitácoraEventosToolStripMenuItem.Text = "Bitácora Eventos";
            bitácoraEventosToolStripMenuItem.Click += bitácoraEventosToolStripMenuItem_Click;
            // 
            // bitácoraCambiosToolStripMenuItem
            // 
            bitácoraCambiosToolStripMenuItem.Name = "bitácoraCambiosToolStripMenuItem";
            bitácoraCambiosToolStripMenuItem.Size = new Size(227, 28);
            bitácoraCambiosToolStripMenuItem.Tag = "Ver Bitácora Cambios";
            bitácoraCambiosToolStripMenuItem.Text = "Bitácora Cambios";
            // 
            // backUpToolStripMenuItem
            // 
            backUpToolStripMenuItem.Name = "backUpToolStripMenuItem";
            backUpToolStripMenuItem.Size = new Size(227, 28);
            backUpToolStripMenuItem.Tag = "Gestionar Backup";
            backUpToolStripMenuItem.Text = "BackUp";
            backUpToolStripMenuItem.Click += backUpToolStripMenuItem_Click;
            // 
            // restoreToolStripMenuItem
            // 
            restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
            restoreToolStripMenuItem.Size = new Size(227, 28);
            restoreToolStripMenuItem.Tag = "Gestionar Restore";
            restoreToolStripMenuItem.Text = "Restore";
            restoreToolStripMenuItem.Click += restoreToolStripMenuItem_Click;
            // 
            // ventasToolStripMenuItem
            // 
            ventasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { nuevaVentaToolStripMenuItem, nuevoPréstamoToolStripMenuItem, historialVentasToolStripMenuItem, historialPréstamosToolStripMenuItem });
            ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            ventasToolStripMenuItem.Size = new Size(125, 28);
            ventasToolStripMenuItem.Text = "Operaciones";
            // 
            // nuevaVentaToolStripMenuItem
            // 
            nuevaVentaToolStripMenuItem.Name = "nuevaVentaToolStripMenuItem";
            nuevaVentaToolStripMenuItem.Size = new Size(250, 28);
            nuevaVentaToolStripMenuItem.Tag = "Registrar Venta";
            nuevaVentaToolStripMenuItem.Text = "Nueva Venta";
            nuevaVentaToolStripMenuItem.Click += nuevaVentaToolStripMenuItem_Click;
            // 
            // nuevoPréstamoToolStripMenuItem
            // 
            nuevoPréstamoToolStripMenuItem.Name = "nuevoPréstamoToolStripMenuItem";
            nuevoPréstamoToolStripMenuItem.Size = new Size(250, 28);
            nuevoPréstamoToolStripMenuItem.Tag = "Registrar Préstamo";
            nuevoPréstamoToolStripMenuItem.Text = "Nuevo Préstamo";
            // 
            // historialVentasToolStripMenuItem
            // 
            historialVentasToolStripMenuItem.Name = "historialVentasToolStripMenuItem";
            historialVentasToolStripMenuItem.Size = new Size(250, 28);
            historialVentasToolStripMenuItem.Tag = "Ver Historial Ventas";
            historialVentasToolStripMenuItem.Text = "Historial Ventas";
            // 
            // historialPréstamosToolStripMenuItem
            // 
            historialPréstamosToolStripMenuItem.Name = "historialPréstamosToolStripMenuItem";
            historialPréstamosToolStripMenuItem.Size = new Size(250, 28);
            historialPréstamosToolStripMenuItem.Tag = "Ver Historial Préstamos";
            historialPréstamosToolStripMenuItem.Text = "Historial Préstamos";
            // 
            // inventarioToolStripMenuItem
            // 
            inventarioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { librosToolStripMenuItem, clientesToolStripMenuItem, librosCToolStripMenuItem });
            inventarioToolStripMenuItem.Name = "inventarioToolStripMenuItem";
            inventarioToolStripMenuItem.Size = new Size(91, 28);
            inventarioToolStripMenuItem.Text = "Maestro";
            // 
            // librosToolStripMenuItem
            // 
            librosToolStripMenuItem.Name = "librosToolStripMenuItem";
            librosToolStripMenuItem.Size = new Size(180, 28);
            librosToolStripMenuItem.Tag = "Gestionar Libros";
            librosToolStripMenuItem.Text = "Libros";
            librosToolStripMenuItem.Click += librosToolStripMenuItem_Click;
            // 
            // clientesToolStripMenuItem
            // 
            clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            clientesToolStripMenuItem.Size = new Size(180, 28);
            clientesToolStripMenuItem.Tag = "Gestionar Clientes";
            clientesToolStripMenuItem.Text = "Clientes";
            // 
            // librosCToolStripMenuItem
            // 
            librosCToolStripMenuItem.Name = "librosCToolStripMenuItem";
            librosCToolStripMenuItem.Size = new Size(180, 28);
            librosCToolStripMenuItem.Tag = "Gestionar Libros C";
            librosCToolStripMenuItem.Text = "Libros C";
            // 
            // reportesToolStripMenuItem
            // 
            reportesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { productosMásVendidosToolStripMenuItem, productosMenosVendidosToolStripMenuItem, productosConBajoStockToolStripMenuItem });
            reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            reportesToolStripMenuItem.Size = new Size(97, 28);
            reportesToolStripMenuItem.Text = "Reportes";
            reportesToolStripMenuItem.Click += reportesToolStripMenuItem_Click;
            // 
            // productosMásVendidosToolStripMenuItem
            // 
            productosMásVendidosToolStripMenuItem.Name = "productosMásVendidosToolStripMenuItem";
            productosMásVendidosToolStripMenuItem.Size = new Size(308, 28);
            productosMásVendidosToolStripMenuItem.Tag = "Reporte Mas Vendidos";
            productosMásVendidosToolStripMenuItem.Text = "Productos Más Vendidos";
            // 
            // productosMenosVendidosToolStripMenuItem
            // 
            productosMenosVendidosToolStripMenuItem.Name = "productosMenosVendidosToolStripMenuItem";
            productosMenosVendidosToolStripMenuItem.Size = new Size(308, 28);
            productosMenosVendidosToolStripMenuItem.Tag = "Reporte Menos Vendidos";
            productosMenosVendidosToolStripMenuItem.Text = "Productos Menos Vendidos";
            // 
            // productosConBajoStockToolStripMenuItem
            // 
            productosConBajoStockToolStripMenuItem.Name = "productosConBajoStockToolStripMenuItem";
            productosConBajoStockToolStripMenuItem.Size = new Size(308, 28);
            productosConBajoStockToolStripMenuItem.Tag = "Reporte Bajo Stock";
            productosConBajoStockToolStripMenuItem.Text = "Productos con Bajo Stock";
            // 
            // centroDeAyudaToolStripMenuItem
            // 
            centroDeAyudaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { manualDeUsuarioToolStripMenuItem, guíaDeInstalaciónArchivoLeémeToolStripMenuItem });
            centroDeAyudaToolStripMenuItem.Name = "centroDeAyudaToolStripMenuItem";
            centroDeAyudaToolStripMenuItem.Size = new Size(76, 28);
            centroDeAyudaToolStripMenuItem.Text = "Ayuda";
            // 
            // manualDeUsuarioToolStripMenuItem
            // 
            manualDeUsuarioToolStripMenuItem.Name = "manualDeUsuarioToolStripMenuItem";
            manualDeUsuarioToolStripMenuItem.Size = new Size(388, 28);
            manualDeUsuarioToolStripMenuItem.Tag = "Ver Manual Usuario";
            manualDeUsuarioToolStripMenuItem.Text = "Manual de Usuario";
            // 
            // guíaDeInstalaciónArchivoLeémeToolStripMenuItem
            // 
            guíaDeInstalaciónArchivoLeémeToolStripMenuItem.Name = "guíaDeInstalaciónArchivoLeémeToolStripMenuItem";
            guíaDeInstalaciónArchivoLeémeToolStripMenuItem.Size = new Size(388, 28);
            guíaDeInstalaciónArchivoLeémeToolStripMenuItem.Tag = "Ver Guia Instalacion";
            guíaDeInstalaciónArchivoLeémeToolStripMenuItem.Text = "Guía de Instalación (Archivo Leéme)";
            guíaDeInstalaciónArchivoLeémeToolStripMenuItem.Click += guíaDeInstalaciónArchivoLeémeToolStripMenuItem_Click;
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            cerrarSesiónToolStripMenuItem.Size = new Size(136, 28);
            cerrarSesiónToolStripMenuItem.Tag = "Cerrar Sesion";
            cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            cerrarSesiónToolStripMenuItem.Click += cerrarSesiónToolStripMenuItem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Text", 18F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label1.Location = new Point(225, 53);
            label1.Name = "label1";
            label1.Size = new Size(166, 35);
            label1.TabIndex = 3;
            label1.Text = "¡Bienvenida!";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.LightGray;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(249, 143);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(319, 276);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sitka Text", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(23, 379);
            label2.Name = "label2";
            label2.Size = new Size(45, 19);
            label2.TabIndex = 5;
            label2.Text = "label2";
            // 
            // FormSistema
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Tan;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FormSistema";
            Text = "Sistema Bookly - Venta y Préstamo de Libros";
            FormClosing += FormSistema_FormClosing;
            Load += FormSistema_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem ventasToolStripMenuItem;
        private ToolStripMenuItem inventarioToolStripMenuItem;
        private ToolStripMenuItem reportesToolStripMenuItem;
        private ToolStripMenuItem usuarioToolStripMenuItem;
        private ToolStripMenuItem administraciónToolStripMenuItem;
        private ToolStripMenuItem centroDeAyudaToolStripMenuItem;
        private ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private ToolStripMenuItem nuevaVentaToolStripMenuItem;
        private ToolStripMenuItem historialVentasToolStripMenuItem;
        private ToolStripMenuItem productosMásVendidosToolStripMenuItem;
        private ToolStripMenuItem productosConBajoStockToolStripMenuItem;
        private ToolStripMenuItem usuariosToolStripMenuItem;
        private ToolStripMenuItem perfilesToolStripMenuItem;
        private ToolStripMenuItem bitácoraEventosToolStripMenuItem;
        private ToolStripMenuItem backUpToolStripMenuItem;
        private ToolStripMenuItem restoreToolStripMenuItem;
        private ToolStripMenuItem librosToolStripMenuItem;
        private ToolStripMenuItem clientesToolStripMenuItem;
        private ToolStripMenuItem productosMenosVendidosToolStripMenuItem;
        private ToolStripMenuItem cambiarClaveToolStripMenuItem;
        private ToolStripMenuItem cambiarIdiomaToolStripMenuItem;
        private ToolStripMenuItem manualDeUsuarioToolStripMenuItem;
        private ToolStripMenuItem guíaDeInstalaciónArchivoLeémeToolStripMenuItem;
        private Label label1;
        private PictureBox pictureBox1;
        private ToolStripMenuItem reLoginToolStripMenuItem;
        private ToolStripMenuItem españolToolStripMenuItem;
        private ToolStripMenuItem inglésToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private Label label2;
        private ToolStripMenuItem nuevoPréstamoToolStripMenuItem;
        private ToolStripMenuItem historialPréstamosToolStripMenuItem;
        private ToolStripMenuItem librosCToolStripMenuItem;
        private ToolStripMenuItem bitácoraCambiosToolStripMenuItem;
    }
}
