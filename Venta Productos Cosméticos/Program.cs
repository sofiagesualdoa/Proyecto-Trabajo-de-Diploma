namespace Venta_Productos_Cosméticos
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new ContextoNavegacion());
        }
    }

    internal class ContextoNavegacion : ApplicationContext
    {
        public ContextoNavegacion()
        {
            FormPantallaInicio inicio = new FormPantallaInicio();
            inicio.Show();
            Application.Idle += OnIdle;
        }

        private void OnIdle(object? sender, EventArgs e)
        {
            bool hayVisible = false;
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                Form f = Application.OpenForms[i];
                if (f != null && f.Visible)
                {
                    hayVisible = true;
                    break;
                }
            }

            if (!hayVisible)
            {
                Application.Idle -= OnIdle;
                ExitThread();
            }
        }
    }
}