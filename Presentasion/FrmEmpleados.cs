using Entidades;
using Negocio.Servicios;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;



namespace Presentasion
{
    public partial class FrmEmpleados : Form
    {
        EmpleadoService servicio = new EmpleadoService();

        // ✅ Una sola cadena de conexión centralizada
        private readonly string connStr =
            "Server=localhost;Database=TalentBusDB;Trusted_Connection=True;";

        public FrmEmpleados()
        {
            InitializeComponent();
            CargarCargos();
            ConfigurarColumnas();
            
        }
        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            // Ya se carga en el constructor, no hace falta aquí
        }
        
        void ConfigurarColumnas()
        {
            dgvEmpleados.Columns.Clear();
            dgvEmpleados.Columns.Add("Cedula", "Cédula");
            dgvEmpleados.Columns.Add("Nombre", "Nombre");
            dgvEmpleados.Columns.Add("Apellido", "Apellido");
            dgvEmpleados.Columns.Add("NombreCargo", "Cargo");
            dgvEmpleados.Columns.Add("SalarioBase", "Salario Base");
            dgvEmpleados.Columns.Add("FechaIngreso", "Fecha Ingreso"); 
        }
        void CargarCargos()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT Id, NombreCargo FROM Cargo", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbCargo.DataSource = dt;
                cmbCargo.DisplayMember = "NombreCargo";
                cmbCargo.ValueMember = "Id";
                cmbCargo.SelectedIndex = -1; 
            }
        }

        private void btnRegistrar_Click_1(object sender, EventArgs e)
        {
            // ✅ Validar que haya un cargo seleccionado
            if (cmbCargo.SelectedValue == null)
            {
                MessageBox.Show("Por favor selecciona un cargo.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtCedula.Text))
            { MessageBox.Show("La cédula es requerida."); return; }

            if (txtCedula.Text.Length < 11)
            { MessageBox.Show("La cédula debe tener 11 dígitos."); return; }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            { MessageBox.Show("El nombre es requerido."); return; }

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            { MessageBox.Show("El apellido es requerido."); return; }

            if (string.IsNullOrWhiteSpace(txtSalario.Text))
            { MessageBox.Show("El salario es requerido."); return; }

            if (!decimal.TryParse(txtSalario.Text, out decimal salario))
            { MessageBox.Show("El salario debe ser un número válido."); return; }

            if (salario <= 0)
            { MessageBox.Show("El salario debe ser mayor a 0."); return; }

            if (cmbCargo.SelectedValue == null)
            { MessageBox.Show("Selecciona un cargo."); return; }

            Empleado emp = new Empleado
            {
                Cedula = txtCedula.Text,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                IdCargo = Convert.ToInt32(cmbCargo.SelectedValue), // ✅ Id real
                SalarioBase = decimal.Parse(txtSalario.Text)
            };

            servicio.Registrar(emp);
            MessageBox.Show("Empleado registrado");
            CargarCargos(); // Refresca el combo luego de registrar
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
    dr["NombreCargo"],
    dr["SalarioBase"],
    dr["FechaIngreso"]); // ✅ Nuevo
            }
            dr.Close();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            servicio.Eliminar(txtCedula.Text);
            MessageBox.Show("Empleado Eliminado De Todo Historial");
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            if (cmbCargo.SelectedValue == null)
            {
                MessageBox.Show("Por favor selecciona un cargo.");
                return;
            }

            Empleado emp = new Empleado
            {
                Cedula = txtCedula.Text,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                IdCargo = Convert.ToInt32(cmbCargo.SelectedValue),
                SalarioBase = decimal.Parse(txtSalario.Text)
            };

            servicio.Actualizar(emp);
            MessageBox.Show("Empleado actualizado");
        }

        private void cmbCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // No hacer nada aquí
        }
    }
}
