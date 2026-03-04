using System;
using System.Windows.Forms;
using Entidades;
using Negocio.Servicios;
using System.Data.SqlClient;



namespace Presentasion
{
    public partial class FrmEmpleados : Form
    {
        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            // Aquí luego puedes cargar datos si quieres
        }

        EmpleadoService servicio = new EmpleadoService();
        public FrmEmpleados()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click_1(object sender, EventArgs e)
        {
            Empleado emp = new Empleado
            {
                Cedula = txtCedula.Text,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                SalarioBase = decimal.Parse(txtSalario.Text)
            };

            servicio.Registrar(emp);
            MessageBox.Show("Empleado registrado");
        }

        private void btnListar_Click_1(object sender, EventArgs e)
        {
            dgvEmpleados.Rows.Clear();
            SqlDataReader dr = servicio.Listar();

            while (dr.Read())
            {
                dgvEmpleados.Rows.Add(
                    dr["Cedula"],
                    dr["Nombre"],
                    dr["Apellido"],
                    dr["SalarioBase"]);
            }
            dr.Close();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            servicio.Eliminar(txtCedula.Text);
            MessageBox.Show("Empleado eliminado");
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            Empleado emp = new Empleado
            {
                Cedula = txtCedula.Text,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                SalarioBase = decimal.Parse(txtSalario.Text)
            };

            servicio.Actualizar(emp);
            MessageBox.Show("Empleado actualizado");
        }
    }
}
