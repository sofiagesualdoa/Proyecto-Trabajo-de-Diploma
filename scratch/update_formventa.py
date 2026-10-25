path = r'Venta Productos Cosméticos\FormVenta.cs'
with open(path, 'r', encoding='utf-8') as f:
    content = f.read()

target1 = """MostrarGrilla(bllLibro.ObtenerLibrosActivos().Where(l => !l.EsParaPrestamo).ToList());"""
replacement1 = """MostrarGrilla(bllLibro.ObtenerLibrosActivos().Where(l => l.Existencias_657SGA > 0 && l.Precio_657SGA > 0).ToList());"""

target2 = """            if (dataGridViewLibros.Columns["Existencias_657SGA"] != null)
                dataGridViewLibros.Columns["Existencias_657SGA"].Visible = false;
            if (dataGridViewLibros.Columns["EsParaPrestamo"] != null)
                dataGridViewLibros.Columns["EsParaPrestamo"].Visible = false;"""

replacement2 = """            if (dataGridViewLibros.Columns["Existencias_657SGA"] != null)
                dataGridViewLibros.Columns["Existencias_657SGA"].Visible = false;
            if (dataGridViewLibros.Columns["ExistenciasPrestamo"] != null)
                dataGridViewLibros.Columns["ExistenciasPrestamo"].Visible = false;
            if (dataGridViewLibros.Columns["EsParaPrestamo"] != null)
                dataGridViewLibros.Columns["EsParaPrestamo"].Visible = false;"""

target3 = """            var listaFiltrada = bllLibro.BuscarLibros(textBox1_657SGA.Text);
            MostrarGrilla(listaFiltrada.Where(l => l.Activo_657SGA && !l.EsParaPrestamo).ToList());"""

replacement3 = """            var listaFiltrada = bllLibro.BuscarLibros(textBox1_657SGA.Text);
            MostrarGrilla(listaFiltrada.Where(l => l.Activo_657SGA && l.Existencias_657SGA > 0 && l.Precio_657SGA > 0).ToList());"""

target4 = """                var libroSeleccionado = (BELibro)dataGridViewLibros.SelectedRows[0].DataBoundItem;
                if (libroSeleccionado.EsParaPrestamo)
                    throw new Exception(s.Traducir("No se pueden agregar libros de préstamo al carrito de ventas."));"""

replacement4 = """                var libroSeleccionado = (BELibro)dataGridViewLibros.SelectedRows[0].DataBoundItem;
                if (libroSeleccionado.Existencias_657SGA <= 0 || libroSeleccionado.Precio_657SGA <= 0)
                    throw new Exception(s.Traducir("El ejemplar seleccionado no cuenta con copias disponibles para venta."));"""

norm_content = content.replace('\r\n', '\n')
norm_t1 = target1.replace('\r\n', '\n')
norm_t2 = target2.replace('\r\n', '\n')
norm_t3 = target3.replace('\r\n', '\n')
norm_t4 = target4.replace('\r\n', '\n')

assert norm_t1 in norm_content, "target1 not found"
assert norm_t2 in norm_content, "target2 not found"
assert norm_t3 in norm_content, "target3 not found"
assert norm_t4 in norm_content, "target4 not found"

norm_content = norm_content.replace(norm_t1, replacement1.replace('\r\n', '\n'))
norm_content = norm_content.replace(norm_t2, replacement2.replace('\r\n', '\n'))
norm_content = norm_content.replace(norm_t3, replacement3.replace('\r\n', '\n'))
norm_content = norm_content.replace(norm_t4, replacement4.replace('\r\n', '\n'))

final_content = norm_content.replace('\n', '\r\n')
with open(path, 'w', encoding='utf-8') as f:
    f.write(final_content)
print("Updated FormVenta.cs successfully!")
