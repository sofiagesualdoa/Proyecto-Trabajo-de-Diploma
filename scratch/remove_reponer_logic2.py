import re

form_path = r"Venta Productos Cosméticos\FormLibros.cs"
with open(form_path, "r", encoding="utf-8") as f:
    form_content = f.read()

# 1. In btnAgregar: replace condition from existente.ExistenciasPrestamo > 0 to existente.EsParaPrestamo
agregar_pattern = re.compile(
    r"if\s*\(esParaPrestamo\)\s*\{\s*"
    r"if\s*\(existente\.ExistenciasPrestamo\s*>\s*0\)\s*\{\s*"
    r"MessageBox\.Show\(\s*"
    r"string\.Format\(session\.Traducir\(\"El libro '\{0\}' ya cuenta con un ejemplar disponible para préstamo\.\"\),\s*existente\.Título_657SGA\),\s*"
    r"session\.Traducir\(\"Aviso\"\),\s*"
    r"MessageBoxButtons\.OK,\s*"
    r"MessageBoxIcon\.Information\);\s*"
    r"return;\s*\}",
    re.MULTILINE
)

m_agg = agregar_pattern.search(form_content)
assert m_agg is not None, "agregar_pattern not found in FormLibros.cs"

replacement_agregar = """if (esParaPrestamo)
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

form_content = form_content[:m_agg.start()] + replacement_agregar + form_content[m_agg.end():]
print("btnAgregar match replaced!")

# 2. In btnModificar: remove the "¿Hay ejemplar disponible para préstamo para reponer?" block
modificar_pattern = re.compile(
    r"bool\s+esParaPrestamo\s*=\s*libroSeleccionado\.EsParaPrestamo;\s*"
    r"int\s+existenciasPrestamo\s*=\s*libroSeleccionado\.ExistenciasPrestamo;\s*"
    r"if\s*\(esParaPrestamo\)\s*\{\s*"
    r"DialogResult\s+respReponer\s*=\s*MessageBox\.Show\([\s\S]*?existenciasPrestamo\s*=\s*\(respReponer\s*==\s*DialogResult\.Yes\)\s*\?\s*1\s*:\s*0;\s*\}\s*"
    r"else\s*\{\s*"
    r"DialogResult\s+respHabilitar\s*=\s*MessageBox\.Show\([\s\S]*?existenciasPrestamo\s*=\s*1;\s*\}\s*\}",
    re.MULTILINE
)

m_mod = modificar_pattern.search(form_content)
assert m_mod is not None, "modificar_pattern not found in FormLibros.cs"

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

form_content = form_content[:m_mod.start()] + replacement_modificar + form_content[m_mod.end():]
print("btnModificar match replaced!")

with open(form_path, "w", encoding="utf-8") as f:
    f.write(form_content)
print("FormLibros.cs updated successfully.")
