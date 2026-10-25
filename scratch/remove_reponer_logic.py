import re

# 1. Update BLL/BLLLibro.cs
bll_path = r"BLL\BLLLibro.cs"
with open(bll_path, "r", encoding="utf-8") as f:
    bll_content = f.read()

old_bll = """                if (libro.EsParaPrestamo)
                {
                    if (existente.ExistenciasPrestamo == 0)
                    {
                        existente.EsParaPrestamo = true;
                        existente.ExistenciasPrestamo = 1;
                        existente.DVH = generador.GenerarDVH(existente);
                        dal.ModificarLibro(existente, existente.ISBN_657SGA);
                        new ServicioDVV().RecalcularDVVLibro();
                        bitacora.GrabarBitacora("Habilitar Préstamo de Libro", "Libro", 2);
                        return;
                    }
                    throw new Exception(ServicioSessionManager.GetInstance().Traducir("El libro ya se encuentra habilitado para préstamo (máximo 1 ejemplar)."));
                }"""

new_bll = """                if (libro.EsParaPrestamo)
                {
                    if (!existente.EsParaPrestamo)
                    {
                        existente.EsParaPrestamo = true;
                        existente.ExistenciasPrestamo = 1;
                        existente.DVH = generador.GenerarDVH(existente);
                        dal.ModificarLibro(existente, existente.ISBN_657SGA);
                        new ServicioDVV().RecalcularDVVLibro();
                        bitacora.GrabarBitacora("Habilitar Préstamo de Libro", "Libro", 2);
                        return;
                    }
                    throw new Exception(ServicioSessionManager.GetInstance().Traducir("El libro ya se encuentra habilitado para préstamo (máximo 1 ejemplar)."));
                }"""

assert old_bll in bll_content, "old_bll not found in BLLLibro.cs"
bll_content = bll_content.replace(old_bll, new_bll, 1)

with open(bll_path, "w", encoding="utf-8") as f:
    f.write(bll_content)
print("BLLLibro.cs updated.")

# 2. Update Venta Productos Cosméticos/FormLibros.cs
form_path = r"Venta Productos Cosméticos\FormLibros.cs"
with open(form_path, "r", encoding="utf-8") as f:
    form_content = f.read()

# Replace in btnAgregar
old_form_agregar = """                    if (esParaPrestamo)
                    {
                        if (existente.ExistenciasPrestamo > 0)
                        {
                            MessageBox.Show(
                                string.Format(session.Traducir("El libro '{0}' ya cuenta con un ejemplar disponible para préstamo."), existente.Título_657SGA),
                                session.Traducir("Aviso"),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            return;
                        }"""

new_form_agregar = """                    if (esParaPrestamo)
                    {
                        if (existente.EsParaPrestamo)
                        {
                            MessageBox.Show(
                                string.Format(session.Traducir("El libro '{0}' ya se encuentra habilitado para el catálogo de préstamos (máximo 1 ejemplar permitido)."), existente.Título_657SGA),
                                session.Traducir("Aviso"),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            return;
                        }"""

assert old_form_agregar in form_content, "old_form_agregar not found in FormLibros.cs"
form_content = form_content.replace(old_form_agregar, new_form_agregar, 1)

# In btnModificar: remove the "¿Hay ejemplar disponible para préstamo para reponer?" block
modificar_pattern = re.compile(
    r"bool esParaPrestamo = libroSeleccionado\.EsParaPrestamo;\s*"
    r"int existenciasPrestamo = libroSeleccionado\.ExistenciasPrestamo;\s*"
    r"if \(esParaPrestamo\)\s*\{\s*"
    r"DialogResult respReponer = MessageBox\.Show\([\s\S]*?existenciasPrestamo = \(respReponer == DialogResult\.Yes\) \? 1 : 0;\s*\}\s*"
    r"else\s*\{\s*"
    r"DialogResult respHabilitar = MessageBox\.Show\([\s\S]*?existenciasPrestamo = 1;\s*\}\s*\}",
    re.MULTILINE
)

m = modificar_pattern.search(form_content)
assert m is not None, "modificar_pattern not found in FormLibros.cs"

replacement_modificar = """bool esParaPrestamo = libroSeleccionado.EsParaPrestamo;
                    int existenciasPrestamo = libroSeleccionado.ExistenciasPrestamo;
                    if (!esParaPrestamo)
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
                    }"""

form_content = form_content[:m.start()] + replacement_modificar + form_content[m.end():]

with open(form_path, "w", encoding="utf-8") as f:
    f.write(form_content)
print("FormLibros.cs updated.")
