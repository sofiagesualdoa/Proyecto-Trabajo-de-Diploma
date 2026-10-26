path = r"Venta Productos Cosméticos\FormPrestamo.cs"
with open(path, "r", encoding="utf-8") as f:
    content = f.read()

target = """            if (dataGridViewLibros.Columns["Precio"] != null)
                dataGridViewLibros.Columns["Precio"].Visible = false;
            var usuarioActivo = ServicioSessionManager.GetInstance().ObtenerUsuario();"""

replacement = """            if (dataGridViewLibros.Columns["Precio"] != null)
                dataGridViewLibros.Columns["Precio"].Visible = false;
            if (dataGridViewLibros.Columns["Precio_657SGA"] != null)
                dataGridViewLibros.Columns["Precio_657SGA"].Visible = false;
            var usuarioActivo = ServicioSessionManager.GetInstance().ObtenerUsuario();"""

assert target in content, "Target not found"
new_content = content.replace(target, replacement)

target2 = """            foreach (DataGridViewColumn columna in dataGridViewLibros.Columns)
            {
                columna.HeaderText = columna.Name.Replace("_657SGA", "");
                if (leyendas != null && leyendas.ContainsKey(columna.Name))
                {
                    columna.HeaderText = leyendas[columna.Name];
                }
            }"""

replacement2 = """            foreach (DataGridViewColumn columna in dataGridViewLibros.Columns)
            {
                if (columna.Name == "ExistenciasPrestamo")
                {
                    columna.HeaderText = (leyendas != null && leyendas.ContainsKey("Stock Préstamo"))
                        ? leyendas["Stock Préstamo"]
                        : "Stock Préstamo";
                }
                else
                {
                    columna.HeaderText = columna.Name.Replace("_657SGA", "");
                    if (leyendas != null && leyendas.ContainsKey(columna.Name))
                    {
                        columna.HeaderText = leyendas[columna.Name];
                    }
                }
            }"""

assert target2 in new_content, "Target2 not found"
new_content = new_content.replace(target2, replacement2)

with open(path, "w", encoding="utf-8") as f:
    f.write(new_content)
print("Successfully patched FormPrestamo.cs")
