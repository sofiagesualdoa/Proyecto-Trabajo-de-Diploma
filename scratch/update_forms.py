import re

# 1. Update FormLibros.cs
path_libros = r"c:\Users\usuario\OneDrive\Facultad\3° Año\2° Cuatrimestre\Trabajo de Diploma\Carpeta\Proyecto-Trabajo-de-Diploma\Venta Productos Cosméticos\FormLibros.cs"

with open(path_libros, "r", encoding="utf-8") as f:
    content = f.read()

# Add translation for EsParaPrestamo in MostrarGrilla
old_grilla = """            foreach (DataGridViewColumn columna in dataGridView1.Columns)
            {
                columna.HeaderText = columna.Name.Replace("_657SGA", "");
            }"""

new_grilla = """            foreach (DataGridViewColumn columna in dataGridView1.Columns)
            {
                columna.HeaderText = columna.Name.Replace("_657SGA", "");
            }
            if (dataGridView1.Columns["EsParaPrestamo"] != null)
            {
                dataGridView1.Columns["EsParaPrestamo"].HeaderText = ServicioSessionManager.GetInstance().Traducir("Es Para Préstamo");
            }"""

if old_grilla in content:
    content = content.replace(old_grilla, new_grilla, 1)
    print("FormLibros.cs: MostrarGrilla updated")
else:
    print("FormLibros.cs: MostrarGrilla target not found")

# Update btnAgregar_657SGA_Click
old_agregar = """                string cantidadStr = Interaction.InputBox(session.Traducir("Ingrese la cantidad inicial de ejemplares del libro:"), session.Traducir("Agregar Libro"), "");
                if (!int.TryParse(cantidadStr, out int cantidad) || cantidad < 0)
                {
                    throw new Exception(session.Traducir("Operación cancelada. La cantidad de ejemplares es inválida."));
                }
                BELibro libro = new BELibro
                {
                    Título_657SGA = titulo.Trim(),
                    Editorial_657SGA = editorial.Trim(),
                    Autor_657SGA = autor.Trim(),
                    ISBN_657SGA = isbn.Trim(),
                    Precio_657SGA = precio,
                    Existencias_657SGA = cantidad,
                    Activo_657SGA = true
                };"""

new_agregar = """                int cantidad = 1;
                if (!esParaPrestamo)
                {
                    string cantidadStr = Interaction.InputBox(session.Traducir("Ingrese la cantidad inicial de ejemplares del libro:"), session.Traducir("Agregar Libro"), "");
                    if (!int.TryParse(cantidadStr, out cantidad) || cantidad < 0)
                    {
                        throw new Exception(session.Traducir("Operación cancelada. La cantidad de ejemplares es inválida."));
                    }
                }
                BELibro libro = new BELibro
                {
                    Título_657SGA = titulo.Trim(),
                    Editorial_657SGA = editorial.Trim(),
                    Autor_657SGA = autor.Trim(),
                    ISBN_657SGA = isbn.Trim(),
                    Precio_657SGA = precio,
                    Existencias_657SGA = cantidad,
                    EsParaPrestamo = esParaPrestamo,
                    Activo_657SGA = true
                };"""

# Also need to add DialogResult respPrestamo at the top of btnAgregar_657SGA_Click
old_agregar_top = """        private void btnAgregar_657SGA_Click(object sender, EventArgs e)
        {
            try
            {
                var session = ServicioSessionManager.GetInstance();"""

new_agregar_top = """        private void btnAgregar_657SGA_Click(object sender, EventArgs e)
        {
            try
            {
                var session = ServicioSessionManager.GetInstance();
                DialogResult respPrestamo = MessageBox.Show(
                    session.Traducir("¿El libro a ingresar es para préstamo?"),
                    session.Traducir("Tipo de Libro"),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                bool esParaPrestamo = (respPrestamo == DialogResult.Yes);"""

if old_agregar_top in content:
    content = content.replace(old_agregar_top, new_agregar_top, 1)
    print("FormLibros.cs: btnAgregar top updated")
else:
    print("FormLibros.cs: btnAgregar top not found")

if old_agregar in content:
    content = content.replace(old_agregar, new_agregar, 1)
    print("FormLibros.cs: btnAgregar body updated")
else:
    print("FormLibros.cs: btnAgregar body not found")

# Update btnModificar_657SGA_Click
old_modificar = """                    string cantidadStr = Interaction.InputBox(session.Traducir("Ingrese la cantidad de ejemplares del libro:"), session.Traducir("Modificar Libro"), libroSeleccionado.Existencias_657SGA.ToString());
                    if (!int.TryParse(cantidadStr, out int cantidad) || cantidad < 0)
                    {
                        throw new Exception(session.Traducir("Operación cancelada. La cantidad de ejemplares es inválida."));
                    }

                    BELibro libroModificado = new BELibro
                    {
                        Título_657SGA = titulo.Trim(),
                        Editorial_657SGA = editorial.Trim(),
                        Autor_657SGA = autor.Trim(),
                        ISBN_657SGA = isbn.Trim(),
                        Precio_657SGA = precio,
                        Existencias_657SGA = cantidad,
                        Activo_657SGA = libroSeleccionado.Activo_657SGA
                    };"""

new_modificar = """                    int cantidad = libroSeleccionado.Existencias_657SGA;
                    if (!libroSeleccionado.EsParaPrestamo)
                    {
                        string cantidadStr = Interaction.InputBox(session.Traducir("Ingrese la cantidad de ejemplares del libro:"), session.Traducir("Modificar Libro"), libroSeleccionado.Existencias_657SGA.ToString());
                        if (!int.TryParse(cantidadStr, out cantidad) || cantidad < 0)
                        {
                            throw new Exception(session.Traducir("Operación cancelada. La cantidad de ejemplares es inválida."));
                        }
                    }

                    BELibro libroModificado = new BELibro
                    {
                        Título_657SGA = titulo.Trim(),
                        Editorial_657SGA = editorial.Trim(),
                        Autor_657SGA = autor.Trim(),
                        ISBN_657SGA = isbn.Trim(),
                        Precio_657SGA = precio,
                        Existencias_657SGA = cantidad,
                        EsParaPrestamo = libroSeleccionado.EsParaPrestamo,
                        Activo_657SGA = libroSeleccionado.Activo_657SGA
                    };"""

if old_modificar in content:
    content = content.replace(old_modificar, new_modificar, 1)
    print("FormLibros.cs: btnModificar updated")
else:
    print("FormLibros.cs: btnModificar not found")

with open(path_libros, "w", encoding="utf-8") as f:
    f.write(content)

# 2. Update FormVenta.cs
path_venta = r"c:\Users\usuario\OneDrive\Facultad\3° Año\2° Cuatrimestre\Trabajo de Diploma\Carpeta\Proyecto-Trabajo-de-Diploma\Venta Productos Cosméticos\FormVenta.cs"

with open(path_venta, "r", encoding="utf-8") as f:
    c_venta = f.read()

# FormVenta_Load
old_load = "MostrarGrilla(bllLibro.ObtenerLibros());"
new_load = "MostrarGrilla(bllLibro.ObtenerLibrosActivos().Where(l => !l.EsParaPrestamo).ToList());"
if old_load in c_venta:
    c_venta = c_venta.replace(old_load, new_load, 1)
    print("FormVenta.cs: FormVenta_Load updated")
else:
    print("FormVenta.cs: FormVenta_Load not found")

# MostrarGrilla in FormVenta: hide EsParaPrestamo
old_grilla_v = """            if (dataGridViewLibros.Columns["Existencias_657SGA"] != null)
                dataGridViewLibros.Columns["Existencias_657SGA"].Visible = false;"""

new_grilla_v = """            if (dataGridViewLibros.Columns["Existencias_657SGA"] != null)
                dataGridViewLibros.Columns["Existencias_657SGA"].Visible = false;
            if (dataGridViewLibros.Columns["EsParaPrestamo"] != null)
                dataGridViewLibros.Columns["EsParaPrestamo"].Visible = false;"""

if old_grilla_v in c_venta:
    c_venta = c_venta.replace(old_grilla_v, new_grilla_v, 1)
    print("FormVenta.cs: MostrarGrilla updated")
else:
    print("FormVenta.cs: MostrarGrilla not found")

# btnConsultar_657SGA_Click
old_consultar_v = "MostrarGrilla(listaFiltrada.Where(l => l.Activo_657SGA).ToList());"
new_consultar_v = "MostrarGrilla(listaFiltrada.Where(l => l.Activo_657SGA && !l.EsParaPrestamo).ToList());"
if old_consultar_v in c_venta:
    c_venta = c_venta.replace(old_consultar_v, new_consultar_v, 1)
    print("FormVenta.cs: btnConsultar updated")
else:
    print("FormVenta.cs: btnConsultar not found")

# btnAgregar_657SGA_Click defensive check
old_agregar_v = """                var libroSeleccionado = (BELibro)dataGridViewLibros.SelectedRows[0].DataBoundItem;
                string prompt = s.Traducir("Ingrese la cantidad a agregar al carrito:");"""

new_agregar_v = """                var libroSeleccionado = (BELibro)dataGridViewLibros.SelectedRows[0].DataBoundItem;
                if (libroSeleccionado.EsParaPrestamo)
                    throw new Exception(s.Traducir("No se pueden agregar libros de préstamo al carrito de ventas."));
                string prompt = s.Traducir("Ingrese la cantidad a agregar al carrito:");"""

if old_agregar_v in c_venta:
    c_venta = c_venta.replace(old_agregar_v, new_agregar_v, 1)
    print("FormVenta.cs: btnAgregar defensive check updated")
else:
    print("FormVenta.cs: btnAgregar defensive check not found")

# btnCobrar_657SGA_Click reload grid
old_cobrar_v = "MostrarGrilla(bllLibro.ObtenerLibros());"
new_cobrar_v = "MostrarGrilla(bllLibro.ObtenerLibrosActivos().Where(l => !l.EsParaPrestamo).ToList());"
if old_cobrar_v in c_venta:
    c_venta = c_venta.replace(old_cobrar_v, new_cobrar_v, 1)
    print("FormVenta.cs: btnCobrar updated")
else:
    print("FormVenta.cs: btnCobrar not found")

with open(path_venta, "w", encoding="utf-8") as f:
    f.write(c_venta)

print("ALL UPDATES FINISHED")
