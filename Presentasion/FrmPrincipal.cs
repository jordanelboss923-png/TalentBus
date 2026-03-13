using System;
using System.Drawing;
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
            FrmNomina frm = new FrmNomina();
            frm.ShowDialog();
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCargos_Click_1(object sender, EventArgs e)
        {
            FrmCargos frm = new FrmCargos();
            frm.ShowDialog();
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            FrmConfiguracion frm = new FrmConfiguracion();
            frm.ShowDialog();
        }
    }
}
