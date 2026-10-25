import os

path = r'Venta Productos Cosméticos\FormLibros.cs'
with open(path, 'r', encoding='utf-8') as f:
    content = f.read()

target1 = """            foreach (DataGridViewColumn columna in dataGridView1.Columns)
            {
                columna.HeaderText = columna.Name.Replace("_657SGA", "");
            }
            if (dataGridView1.Columns["EsParaPrestamo"] != null)
            {
                dataGridView1.Columns["EsParaPrestamo"].HeaderText = ServicioSessionManager.GetInstance().Traducir("Es Para Préstamo");
            }"""

replacement1 = """            foreach (DataGridViewColumn columna in dataGridView1.Columns)
            {
                columna.HeaderText = columna.Name.Replace("_657SGA", "");
            }
            if (dataGridView1.Columns["Existencias_657SGA"] != null)
            {
                dataGridView1.Columns["Existencias_657SGA"].HeaderText = ServicioSessionManager.GetInstance().Traducir("Stock Venta");
            }
            if (dataGridView1.Columns["ExistenciasPrestamo"] != null)
            {
                dataGridView1.Columns["ExistenciasPrestamo"].HeaderText = ServicioSessionManager.GetInstance().Traducir("Stock Préstamo");
            }
            if (dataGridView1.Columns["Precio_657SGA"] != null)
            {
                dataGridView1.Columns["Precio_657SGA"].HeaderText = ServicioSessionManager.GetInstance().Traducir("Precio Venta");
            }
            if (dataGridView1.Columns["EsParaPrestamo"] != null)
            {
                dataGridView1.Columns["EsParaPrestamo"].HeaderText = ServicioSessionManager.GetInstance().Traducir("Es Para Préstamo");
            }"""

target2 = """                string precioStr = Interaction.InputBox(session.Traducir("Ingrese el Precio del libro:"), session.Traducir("Agregar Libro"), "");
                if (!decimal.TryParse(precioStr, out decimal precio) || precio <= 0)
                {
                    throw new Exception(session.Traducir("Operación cancelada. El precio es inválido."));
                }
                int cantidad = 1;
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

replacement2 = """                decimal precio = 0m;
                int cantidadVenta = 0;
                int existenciasPrestamo = 0;

                if (esParaPrestamo)
                {
                    existenciasPrestamo = 1;
                }
                else
                {
                    string precioStr = Interaction.InputBox(session.Traducir("Ingrese el Precio del libro:"), session.Traducir("Agregar Libro"), "");
                    if (!decimal.TryParse(precioStr, out decimal precioIngresado) || precioIngresado <= 0)
                    {
                        throw new Exception(session.Traducir("Operación cancelada. El precio es inválido."));
                    }
                    precio = precioIngresado;

                    string cantidadStr = Interaction.InputBox(session.Traducir("Ingrese la cantidad inicial de ejemplares del libro:"), session.Traducir("Agregar Libro"), "");
                    if (!int.TryParse(cantidadStr, out cantidadVenta) || cantidadVenta < 0)
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
                    Existencias_657SGA = cantidadVenta,
                    ExistenciasPrestamo = existenciasPrestamo,
                    EsParaPrestamo = esParaPrestamo,
                    Activo_657SGA = true
                };"""

target3 = """                    string precioStr = Interaction.InputBox(session.Traducir("Ingrese el Precio del libro:"), session.Traducir("Modificar Libro"), libroSeleccionado.Precio_657SGA.ToString());
                    if (!decimal.TryParse(precioStr, out decimal precio) || precio <= 0)
                    {
                        throw new Exception(session.Traducir("Operación cancelada. El precio es inválido."));
                    }

                    int cantidad = libroSeleccionado.Existencias_657SGA;
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

replacement3 = """                    decimal precio = libroSeleccionado.Precio_657SGA;
                    int cantidad = libroSeleccionado.Existencias_657SGA;

                    if (!libroSeleccionado.EsParaPrestamo || libroSeleccionado.Existencias_657SGA > 0 || libroSeleccionado.Precio_657SGA > 0)
                    {
                        string precioStr = Interaction.InputBox(session.Traducir("Ingrese el Precio de venta del libro:"), session.Traducir("Modificar Libro"), libroSeleccionado.Precio_657SGA.ToString());
                        if (!decimal.TryParse(precioStr, out decimal precioIngresado) || precioIngresado <= 0)
                        {
                            throw new Exception(session.Traducir("Operación cancelada. El precio es inválido."));
                        }
                        precio = precioIngresado;

                        string cantidadStr = Interaction.InputBox(session.Traducir("Ingrese la cantidad de ejemplares para venta:"), session.Traducir("Modificar Libro"), libroSeleccionado.Existencias_657SGA.ToString());
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
                        ExistenciasPrestamo = libroSeleccionado.ExistenciasPrestamo,
                        EsParaPrestamo = libroSeleccionado.EsParaPrestamo,
                        Activo_657SGA = libroSeleccionado.Activo_657SGA
                    };"""

norm_content = content.replace('\r\n', '\n')
norm_t1 = target1.replace('\r\n', '\n')
norm_t2 = target2.replace('\r\n', '\n')
norm_t3 = target3.replace('\r\n', '\n')

assert norm_t1 in norm_content, "target1 not found"
assert norm_t2 in norm_content, "target2 not found"
assert norm_t3 in norm_content, "target3 not found"

norm_content = norm_content.replace(norm_t1, replacement1.replace('\r\n', '\n'))
norm_content = norm_content.replace(norm_t2, replacement2.replace('\r\n', '\n'))
norm_content = norm_content.replace(norm_t3, replacement3.replace('\r\n', '\n'))

final_content = norm_content.replace('\n', '\r\n')
with open(path, 'w', encoding='utf-8') as f:
    f.write(final_content)
print("Updated FormLibros.cs successfully!")
