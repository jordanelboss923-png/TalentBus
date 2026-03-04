using System;
using System.Windows.Forms;

namespace Presentasion
{
    public partial class FrmPrincipal : Form
    {
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            // Aquí luego puedes cargar datos si quieres
        }
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        

        private void btnEmpleados_Click_1(object sender, EventArgs e)
        {
            FrmEmpleados frm = new FrmEmpleados();
            frm.ShowDialog(); // abre y bloquea el principal
        }

        private void btnNomina_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Módulo de nómina en construcción 🚧");
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
