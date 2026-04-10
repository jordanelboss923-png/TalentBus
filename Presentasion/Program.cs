using System;
using System.Windows.Forms;

namespace Presentacion
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Mostrar login sin Application.Run
            FrmLogin login = new FrmLogin();
            // El login setea DialogResult.OK si el acceso es válido
            if (login.ShowDialog() == DialogResult.OK)
            {
                // Si el login fue exitoso, correr el formulario principal
                Application.Run(new FrmPrincipal(login.UsuarioAutenticado));
            }
        }
    }
}