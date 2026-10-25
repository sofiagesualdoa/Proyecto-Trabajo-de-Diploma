path = r'Venta Productos Cosméticos\FormLibros.cs'
with open(path, 'r', encoding='utf-8') as f:
    content = f.read()

# 1. New btnAgregar_657SGA_Click
new_agregar = """        private void btnAgregar_657SGA_Click(object sender, EventArgs e)
        {
            try
            {
                var session = ServicioSessionManager.GetInstance();
                DialogResult respPrestamo = MessageBox.Show(
                    session.Traducir("¿El libro a ingresar es para préstamo?"),
                    session.Traducir("Tipo de Libro"),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                bool esParaPrestamo = (respPrestamo == DialogResult.Yes);

                string isbn = Interaction.InputBox(session.Traducir("Ingrese el ISBN del libro:"), session.Traducir("Agregar Libro"), "");
                if (string.IsNullOrWhiteSpace(isbn))
                {
                    throw new Exception(session.Traducir("Operación cancelada. El ISBN no puede estar vacío."));
                }
                isbn = isbn.Trim();

                BELibro? existente = bllLibro.ObtenerLibros().FirstOrDefault(l => string.Equals(l.ISBN_657SGA, isbn, StringComparison.OrdinalIgnoreCase));
                if (existente != null)
                {
                    if (esParaPrestamo)
                    {
                        if (existente.ExistenciasPrestamo > 0)
                        {
                            MessageBox.Show(
                                string.Format(session.Traducir("El libro '{0}' ya cuenta con un ejemplar disponible para préstamo."), existente.Título_657SGA),
                                session.Traducir("Aviso"),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            return;
                        }

                        DialogResult respHabilitar = MessageBox.Show(
                            string.Format(session.Traducir("El libro '{0}' ya se encuentra registrado en el sistema.\\n\\n¿Desea habilitar 1 ejemplar para préstamo?"), existente.Título_657SGA),
                            session.Traducir("Habilitar Préstamo"),
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (respHabilitar != DialogResult.Yes) return;

                        existente.EsParaPrestamo = true;
                        existente.ExistenciasPrestamo = 1;
                        bllLibro.ModificarLibro(existente, existente.ISBN_657SGA);
                        MostrarGrilla(bllLibro.ObtenerLibros());
                        MessageBox.Show(session.Traducir("Ejemplar de préstamo habilitado correctamente."),
                                        session.Traducir("Éxito"),
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        string precioPrompt = existente.Precio_657SGA > 0
                            ? session.Traducir("Ingrese el Precio de venta del libro:")
                            : session.Traducir("El libro no tiene precio de venta fijado. Ingrese el Precio de venta:");

                        string precioStr = Interaction.InputBox(precioPrompt, session.Traducir("Agregar Libro"), existente.Precio_657SGA > 0 ? existente.Precio_657SGA.ToString() : "");
                        if (!decimal.TryParse(precioStr, out decimal precio) || precio <= 0)
                        {
                            throw new Exception(session.Traducir("Operación cancelada. El precio es inválido."));
                        }

                        string cantPrompt = existente.Existencias_657SGA > 0
                            ? string.Format(session.Traducir("El libro tiene actualmente {0} ejemplares para venta. Ingrese la cantidad a sumar al stock:"), existente.Existencias_657SGA)
                            : session.Traducir("Ingrese la cantidad inicial de ejemplares para venta:");

                        string cantidadStr = Interaction.InputBox(cantPrompt, session.Traducir("Agregar Libro"), "1");
                        if (!int.TryParse(cantidadStr, out int cantidadAdicional) || cantidadAdicional < 0)
                        {
                            throw new Exception(session.Traducir("Operación cancelada. La cantidad de ejemplares es inválida."));
                        }

                        existente.Precio_657SGA = precio;
                        existente.Existencias_657SGA += cantidadAdicional;
                        bllLibro.ModificarLibro(existente, existente.ISBN_657SGA);
                        MostrarGrilla(bllLibro.ObtenerLibros());
                        MessageBox.Show(session.Traducir("Stock de venta actualizado correctamente."),
                                        session.Traducir("Éxito"),
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        return;
                    }
                }

                string titulo = Interaction.InputBox(session.Traducir("Ingrese el Título del libro:"), session.Traducir("Agregar Libro"), "");
                if (string.IsNullOrWhiteSpace(titulo))
                {
                    throw new Exception(session.Traducir("Operación cancelada. El título no puede estar vacío."));
                }
                string editorial = Interaction.InputBox(session.Traducir("Ingrese la Editorial del libro:"), session.Traducir("Agregar Libro"), "");
                if (string.IsNullOrWhiteSpace(editorial))
                {
                    throw new Exception(session.Traducir("Operación cancelada. La editorial no puede estar vacía."));
                }
                string autor = Interaction.InputBox(session.Traducir("Ingrese el/los Autor/es del libro:"), session.Traducir("Agregar Libro"), "");
                if (string.IsNullOrWhiteSpace(autor))
                {
                    throw new Exception(session.Traducir("Operación cancelada. El autor no puede estar vacío."));
                }

                decimal nuevoPrecio = 0m;
                int nuevaCantidadVenta = 0;
                int nuevaCantidadPrestamo = 0;

                if (esParaPrestamo)
                {
                    nuevaCantidadPrestamo = 1;
                }
                else
                {
                    string precioStr = Interaction.InputBox(session.Traducir("Ingrese el Precio del libro:"), session.Traducir("Agregar Libro"), "");
                    if (!decimal.TryParse(precioStr, out decimal precioIngresado) || precioIngresado <= 0)
                    {
                        throw new Exception(session.Traducir("Operación cancelada. El precio es inválido."));
                    }
                    nuevoPrecio = precioIngresado;

                    string cantidadStr = Interaction.InputBox(session.Traducir("Ingrese la cantidad inicial de ejemplares del libro:"), session.Traducir("Agregar Libro"), "");
                    if (!int.TryParse(cantidadStr, out nuevaCantidadVenta) || nuevaCantidadVenta < 0)
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
                    Precio_657SGA = nuevoPrecio,
                    Existencias_657SGA = nuevaCantidadVenta,
                    ExistenciasPrestamo = nuevaCantidadPrestamo,
                    EsParaPrestamo = esParaPrestamo,
                    Activo_657SGA = true
                };
                bllLibro.CrearLibro(libro);
                MostrarGrilla(bllLibro.ObtenerLibros());
                MessageBox.Show(session.Traducir("Libro agregado correctamente."),
                                session.Traducir("Éxito"),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                string errorTraducido = ServicioSessionManager.GetInstance().Traducir(ex.Message);
                MessageBox.Show(errorTraducido,
                                ServicioSessionManager.GetInstance().Traducir("Error"),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }"""

# 2. In btnModificar_657SGA_Click, add the loan replenishment/toggle check
old_modificar_block = """                    BELibro libroModificado = new BELibro
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

new_modificar_block = """                    bool esParaPrestamo = libroSeleccionado.EsParaPrestamo;
                    int existenciasPrestamo = libroSeleccionado.ExistenciasPrestamo;

                    if (esParaPrestamo)
                    {
                        DialogResult respReponer = MessageBox.Show(
                            session.Traducir("¿Hay ejemplar disponible para préstamo para reponer?"),
                            session.Traducir("Stock de Préstamo"),
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        existenciasPrestamo = (respReponer == DialogResult.Yes) ? 1 : 0;
                    }
                    else
                    {
                        DialogResult respHabilitar = MessageBox.Show(
                            session.Traducir("¿Desea habilitar este libro también para préstamo?"),
                            session.Traducir("Habilitar Préstamo"),
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (respHabilitar == DialogResult.Yes)
                        {
                            esParaPrestamo = true;
                            existenciasPrestamo = 1;
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
                        ExistenciasPrestamo = existenciasPrestamo,
                        EsParaPrestamo = esParaPrestamo,
                        Activo_657SGA = libroSeleccionado.Activo_657SGA
                    };"""

# Find existing btnAgregar_657SGA_Click
norm_content = content.replace('\r\n', '\n')
start_idx = norm_content.find("        private void btnAgregar_657SGA_Click(object sender, EventArgs e)")
assert start_idx != -1, "btnAgregar start not found"
end_marker = "        private void btnBorrar_657SGA_Click"
end_idx = norm_content.find(end_marker, start_idx)
assert end_idx != -1, "btnBorrar start not found"

norm_content = norm_content[:start_idx] + new_agregar + "\n\n" + norm_content[end_idx:]

norm_old_mod = old_modificar_block.replace('\r\n', '\n')
norm_new_mod = new_modificar_block.replace('\r\n', '\n')

assert norm_old_mod in norm_content, "old_modificar_block not found"
norm_content = norm_content.replace(norm_old_mod, norm_new_mod)

with open(path, 'w', encoding='utf-8') as f:
    f.write(norm_content.replace('\n', '\r\n'))

print("FormLibros.cs updated successfully!")
