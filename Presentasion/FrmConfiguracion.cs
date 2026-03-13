using Negocio.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentasion
{
    public partial class FrmConfiguracion : Form
    {
        DeduccionService servicio = new DeduccionService();
        int idSeleccionado = 0;
        public FrmConfiguracion()
        {
            InitializeComponent();
            CargarDeducciones();
        }
        void CargarDeducciones()
        {
            dgvDeducciones.DataSource = servicio.Listar();
        }

        
        private void FrmConfiguracion_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Selecciona una fila primero.");
                return;
            }

            decimal porcentaje = Convert.ToDecimal(txtPorcentaje.Text);
            servicio.Actualizar(idSeleccionado, porcentaje);
            MessageBox.Show("Porcentaje actualizado correctamente.");
            CargarDeducciones();
        }

        private void dgvDeducciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDeducciones.Rows[e.RowIndex];
                idSeleccionado = Convert.ToInt32(row.Cells["Id"].Value);
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtTipo.Text = row.Cells["Tipo"].Value.ToString();
                txtPorcentaje.Text = row.Cells["Porcentaje"].Value.ToString();
            }
        }
    }
}
