with open('Venta Productos Cosméticos/FormClientes.cs', 'r', encoding='utf-8-sig') as f:
    content = f.read()

# 1. Add fields
old_fields = """        private readonly BLLCliente bllCliente = new BLLCliente();
        private readonly ServicioIdioma bllIdioma = new ServicioIdioma();
        private readonly Dictionary<Control, string> textosOriginales = new Dictionary<Control, string>();"""

new_fields = """        private readonly BLLCliente bllCliente = new BLLCliente();
        private readonly BLLSerializarCliente bllSerializar = new BLLSerializarCliente();
        private readonly BLLDeserializarCliente bllDeserializar = new BLLDeserializarCliente();
        private readonly ServicioIdioma bllIdioma = new ServicioIdioma();
        private readonly Dictionary<Control, string> textosOriginales = new Dictionary<Control, string>();
        private readonly ToolTip toolTipBotones = new ToolTip();"""

assert old_fields in content, "old_fields not found"
content = content.replace(old_fields, new_fields, 1)

# 2. Add tooltips and disable buttons in modoAsociarVenta
old_load = """            rbtnActivos_SGA657.Checked = true;
            CargarGrilla();
            if (dniPrecargado.HasValue && dniPrecargado.Value > 0)
            {
                txtDNI_SGA657.Text = dniPrecargado.Value.ToString();
                txtDNI_SGA657.ReadOnly = true;
                txtNombre_SGA657.Focus();
            }
            if (modoAsociarVenta)
            {
                btnModificar_SGA657.Enabled = false;
                btnActDesact_SGA657.Enabled = false;
                btnConsultar_SGA657.Enabled = false;
                rbtnTodos_SGA657.Enabled = false;
                rbtnActivos_SGA657.Enabled = false;
                btnAgregar_SGA657.Enabled = true;
                btnSalir_SGA657.Enabled = false;
            }"""

new_load = """            rbtnActivos_SGA657.Checked = true;
            CargarGrilla();
            toolTipBotones.SetToolTip(btnActualizar, ServicioSessionManager.GetInstance().Traducir("Recarga la matriz de datos con los clientes registrados actualmente en la base de datos"));
            toolTipBotones.SetToolTip(btnSerializar, ServicioSessionManager.GetInstance().Traducir("Exporta los clientes visualizados en la grilla a un archivo XML"));
            toolTipBotones.SetToolTip(btnDesSerializar, ServicioSessionManager.GetInstance().Traducir("Importa clientes desde un archivo XML a la matriz de datos"));
            if (dniPrecargado.HasValue && dniPrecargado.Value > 0)
            {
                txtDNI_SGA657.Text = dniPrecargado.Value.ToString();
                txtDNI_SGA657.ReadOnly = true;
                txtNombre_SGA657.Focus();
            }
            if (modoAsociarVenta)
            {
                btnModificar_SGA657.Enabled = false;
                btnActDesact_SGA657.Enabled = false;
                btnConsultar_SGA657.Enabled = false;
                rbtnTodos_SGA657.Enabled = false;
                rbtnActivos_SGA657.Enabled = false;
                btnAgregar_SGA657.Enabled = true;
                btnSalir_SGA657.Enabled = false;
                btnSerializar.Enabled = false;
                btnDesSerializar.Enabled = false;
                btnActualizar.Enabled = false;
            }"""

assert old_load in content, "old_load not found"
content = content.replace(old_load, new_load, 1)

# 3. Add event handlers and helper method before the last closing brace
new_methods = """
        private List<BECliente> ObtenerClientesDeGrilla()
        {
            if (dataGridView1.DataSource is List<BECliente> listaDirecta)
            {
                return new List<BECliente>(listaDirecta);
            }

            List<BECliente> lista = new List<BECliente>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.DataBoundItem is BECliente cliente)
                {
                    lista.Add(cliente);
                }
            }
            return lista;
        }

        private void btnSerializar_Click(object sender, EventArgs e)
        {
            List<BECliente> lista = ObtenerClientesDeGrilla();
            if (lista.Count == 0)
            {
                MessageBox.Show(
                    ServicioSessionManager.GetInstance().Traducir("No hay clientes en la grilla para serializar."),
                    ServicioSessionManager.GetInstance().Traducir("Información"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            saveFileDialog1.Filter = "Archivos XML (*.xml)|*.xml";
            saveFileDialog1.Title = ServicioSessionManager.GetInstance().Traducir("Seleccionar destino para serializar clientes");
            saveFileDialog1.FileName = "Clientes.xml";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string pregunta = string.Format(
                    ServicioSessionManager.GetInstance().Traducir("¿Confirma serializar los {0} clientes visualizados al archivo seleccionado?\\n\\n{1}"),
                    lista.Count,
                    saveFileDialog1.FileName
                );

                DialogResult confirm = MessageBox.Show(
                    pregunta,
                    ServicioSessionManager.GetInstance().Traducir("Confirmar Serialización"),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        bllSerializar.Serializar(lista, saveFileDialog1.FileName);
                        MessageBox.Show(
                            string.Format(ServicioSessionManager.GetInstance().Traducir("Serialización realizada con éxito. Se exportaron {0} clientes."), lista.Count),
                            ServicioSessionManager.GetInstance().Traducir("Éxito"),
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            ex.Message,
                            ServicioSessionManager.GetInstance().Traducir("Error"),
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
        }

        private void btnDesSerializar_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Archivos XML (*.xml)|*.xml";
            openFileDialog1.Title = ServicioSessionManager.GetInstance().Traducir("Seleccionar archivo XML de clientes para des-serializar");
            openFileDialog1.FileName = string.Empty;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string pregunta = string.Format(
                    ServicioSessionManager.GetInstance().Traducir("¿Confirma des-serializar y cargar los clientes desde el archivo seleccionado?\\n\\n{0}"),
                    openFileDialog1.FileName
                );

                DialogResult confirm = MessageBox.Show(
                    pregunta,
                    ServicioSessionManager.GetInstance().Traducir("Confirmar Des-serialización"),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        var lista = bllDeserializar.Deserializar(openFileDialog1.FileName);
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = lista;
                        if (dataGridView1.Columns["DVH"] != null)
                        {
                            dataGridView1.Columns["DVH"].Visible = false;
                        }
                        TraducirHeaders();

                        MessageBox.Show(
                            string.Format(ServicioSessionManager.GetInstance().Traducir("Des-serialización realizada con éxito. Se cargaron {0} clientes en la grilla."), lista.Count),
                            ServicioSessionManager.GetInstance().Traducir("Éxito"),
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            ex.Message,
                            ServicioSessionManager.GetInstance().Traducir("Error"),
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarGrilla();
            MessageBox.Show(
                ServicioSessionManager.GetInstance().Traducir("Matriz de datos actualizada con los registros actuales de la base de datos."),
                ServicioSessionManager.GetInstance().Traducir("Información"),
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}
"""

last_closing = content.rfind("    }\n}")
if last_closing == -1:
    last_closing = content.rfind("    }\r\n}")

assert last_closing != -1, "Last closing brace not found"
content = content[:last_closing] + new_methods

with open('Venta Productos Cosméticos/FormClientes.cs', 'w', encoding='utf-8-sig') as f:
    f.write(content)

print("FormClientes.cs successfully updated!")
