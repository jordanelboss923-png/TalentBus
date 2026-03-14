using Entidades;
using Negocio.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentasion
{
    public partial class FrmCargos : Form
    {
        CargoService servicio = new CargoService();
        public FrmCargos()
        {
            InitializeComponent();
            ConfigurarColumnas();
        }
        void ConfigurarColumnas()
        {
            dgvCargos.Columns.Clear();
            dgvCargos.Columns.Add("Id", "ID");
            dgvCargos.Columns.Add("NombreCargo", "Cargo");
            dgvCargos.Columns.Add("Departamento", "Departamento");
        }
        private void FrmCargos_Load(object sender, EventArgs e)
        {

        }
  

        private void btnRegistrar_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            { MessageBox.Show("El nombre del cargo es requerido."); return; }

            if (string.IsNullOrWhiteSpace(txtDepartamento.Text))
            { MessageBox.Show("El departamento es requerido."); return; }

            Cargo cargo = new Cargo
            {
                NombreCargo = txtNombre.Text,
                Departamento = txtDepartamento.Text
            };

            servicio.Registrar(cargo);
            MessageBox.Show("Cargo registrado correctamente.");
            btnListar_Click_1(null, null);
        }

        private void btnListar_Click_1(object sender, EventArgs e)
        {
            dgvCargos.Rows.Clear();
            DataTable dt = servicio.Listar();

            foreach (DataRow row in dt.Rows)
            {
                dgvCargos.Rows.Add(
                    row["Id"],
                    row["NombreCargo"],
                    row["Departamento"]);
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Selecciona un cargo del listado primero.");
                return;
            }

            try
            {
                servicio.Eliminar(Convert.ToInt32(txtId.Text));
                MessageBox.Show("Cargo eliminado correctamente.");
                btnListar_Click_1(null, null);
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                MessageBox.Show("No se puede eliminar este cargo porque tiene empleados asignados.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Selecciona un cargo del listado primero.");
                return;
            }

            Cargo cargo = new Cargo
            {
                Id = Convert.ToInt32(txtId.Text),
                NombreCargo = txtNombre.Text,
                Departamento = txtDepartamento.Text
            };

            servicio.Actualizar(cargo);
            MessageBox.Show("Cargo actualizado.");
        btnListar_Click_1 (null, null);
        }

        private void dgvCargos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCargos.Rows[e.RowIndex];
                txtId.Text = row.Cells["Id"].Value.ToString();
                txtNombre.Text = row.Cells["NombreCargo"].Value.ToString();
                txtDepartamento.Text = row.Cells["Departamento"].Value.ToString();
            }
        }
    }
}
    

