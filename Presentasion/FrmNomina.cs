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
    public partial class FrmNomina : Form
    {
        NominaService servicio = new NominaService();
        DataTable dtEmpleados;
        public FrmNomina()
        {
            InitializeComponent();
            ConfigurarColumnas();
            CargarEmpleados();

            
        }

        private void FrmNomina_Load(object sender, EventArgs e)
        {

        }
        void ConfigurarColumnas()
        {
            dgvNomina.Columns.Clear();
            dgvNomina.Columns.Add("Nombre", "Nombre");
            dgvNomina.Columns.Add("Apellido", "Apellido");
            dgvNomina.Columns.Add("Cargo", "Cargo");
            dgvNomina.Columns.Add("SalarioBase", "Salario Base");
            dgvNomina.Columns.Add("HorasExtra", "Horas Extra");
            dgvNomina.Columns.Add("AFP", "AFP");
            dgvNomina.Columns.Add("ARS", "ARS");
            dgvNomina.Columns.Add("ISR", "ISR");
            dgvNomina.Columns.Add("SalarioNeto", "Salario Neto");
        }

        void CargarEmpleados()
        {
            dtEmpleados = servicio.ListarEmpleados();
            cmbEmpleado.DataSource = dtEmpleados;
            cmbEmpleado.DisplayMember = "Nombre";
            cmbEmpleado.ValueMember = "Id";
            cmbEmpleado.SelectedIndex = -1;
        }

        // Calcular UN empleado
        

        // Calcular TODOS los empleados
        

        void AgregarFilaNomina(DataRow emp)
        {
            decimal salario = Convert.ToDecimal(emp["SalarioBase"]);
            int horas = string.IsNullOrWhiteSpace(txtHorasExtra.Text)
                                 ? 0 : Convert.ToInt32(txtHorasExtra.Text);
            decimal pctAFP = servicio.ObtenerPctAFP();
            decimal pctARS = servicio.ObtenerPctARS();
            decimal afp = salario * (pctAFP / 100);
            decimal ars = salario * (pctARS / 100);
            decimal isr = servicio.CalcularISR(salario);
            decimal extras = (salario / 240) * 1.35m * horas;
            decimal neto = salario + extras - afp - ars - isr;

            dgvNomina.Rows.Add(
                emp["Nombre"],
                emp["Apellido"],
                emp["NombreCargo"],
                salario.ToString("N2"),
                horas,
                afp.ToString("N2"),
                ars.ToString("N2"),
                isr.ToString("N2"),
                neto.ToString("N2"));
        }

        // Generar y guardar nómina en BD
        

        private void cmbEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCalcularUno_Click_1(object sender, EventArgs e)
        {
            if (cmbEmpleado.SelectedValue == null)
            { MessageBox.Show("Selecciona un empleado."); return; }

            if (!string.IsNullOrWhiteSpace(txtHorasExtra.Text))
            {
                if (!int.TryParse(txtHorasExtra.Text, out int horas))
                { MessageBox.Show("Las horas extra deben ser un número válido."); return; }

                if (horas < 0 || horas > 80)
                { MessageBox.Show("Las horas extra deben estar entre 0 y 80."); return; }
            }

            dgvNomina.Rows.Clear();
            int id = Convert.ToInt32(cmbEmpleado.SelectedValue);
            DataRow emp = dtEmpleados.Select($"Id = {id}")[0];
            AgregarFilaNomina(emp);
        }

        private void btnCalcularTodos_Click_1(object sender, EventArgs e)
        {
            dgvNomina.Rows.Clear();
            foreach (DataRow emp in dtEmpleados.Rows)
                AgregarFilaNomina(emp);
        }

        private void btnGenerarNomina_Click_1(object sender, EventArgs e)
        {
            if (dgvNomina.Rows.Count == 0)
            {
                MessageBox.Show("Primero calcula la nómina.");
                return;
            }

            // Agregar columna HorasExtra al DataTable para enviar al repositorio
            if (!dtEmpleados.Columns.Contains("HorasExtra"))
                dtEmpleados.Columns.Add("HorasExtra", typeof(int));

            foreach (DataRow row in dtEmpleados.Rows)
                row["HorasExtra"] = string.IsNullOrWhiteSpace(txtHorasExtra.Text)
                                    ? 0 : Convert.ToInt32(txtHorasExtra.Text);

            servicio.GenerarNomina(dtEmpleados);
            MessageBox.Show("Nómina generada y guardada correctamente. ✅");

            // Mostrar nómina completa guardada
            DataTable dt = servicio.ListarNominaCompleta();

            Form frmResumen = new Form();
            frmResumen.Text = "Nómina Generada";
            frmResumen.Size = new System.Drawing.Size(800, 400);
            frmResumen.StartPosition = FormStartPosition.CenterScreen;

            DataGridView dgv = new DataGridView();
            dgv.Dock = DockStyle.Fill;
            dgv.DataSource = dt;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            frmResumen.Controls.Add(dgv);
            frmResumen.ShowDialog();
        }

        private void btnVolante_Click_1(object sender, EventArgs e)
        {
            if (cmbEmpleado.SelectedValue == null)
            {
                MessageBox.Show("Selecciona un empleado para ver el volante.");
                return;
            }

            int id = Convert.ToInt32(cmbEmpleado.SelectedValue);
            DataRow emp = dtEmpleados.Select($"Id = {id}")[0];
            decimal sal = Convert.ToDecimal(emp["SalarioBase"]);
            decimal pctAFP = servicio.ObtenerPctAFP();
            decimal pctARS = servicio.ObtenerPctARS();
            decimal afp = sal * (pctAFP / 100);
            decimal ars = sal * (pctARS / 100);
            decimal isr = servicio.CalcularISR(sal);
            int horas = string.IsNullOrWhiteSpace(txtHorasExtra.Text)
                             ? 0 : Convert.ToInt32(txtHorasExtra.Text);
            decimal extras = (sal / 240) * 1.35m * horas;
            decimal neto = sal + extras - afp - ars - isr;

            string volante = $@"
╔══════════════════════════════════════╗
║           VOLANTE DE PAGO            ║
╠══════════════════════════════════════╣
║ Empleado : {emp["Nombre"]} {emp["Apellido"]}
║ Cargo    : {emp["NombreCargo"]}
╠══════════════════════════════════════╣
║ Salario Base  : RD$ {sal:N2}
║ Horas Extra   : RD$ {extras:N2}
║ Salario Bruto : RD$ {(sal + extras):N2}
╠══════════════════════════════════════╣
║ AFP ({pctAFP}%)  : RD$ {afp:N2}
║ ARS ({pctARS}%)  : RD$ {ars:N2}
║ ISR           : RD$ {isr:N2}
╠══════════════════════════════════════╣
║ SALARIO NETO  : RD$ {neto:N2}
╚══════════════════════════════════════╝";

            MessageBox.Show(volante, "Volante de Pago");
        }

        private void btnResumen_Click(object sender, EventArgs e)
        {
            DataTable dt = servicio.ResumenPorDepartamento();

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No hay nóminas generadas aún.");
                return;
            }

            Form frmResumen = new Form();
            frmResumen.Text = "Resumen por Departamento";
            frmResumen.Size = new System.Drawing.Size(700, 400);
            frmResumen.StartPosition = FormStartPosition.CenterScreen;

            DataGridView dgv = new DataGridView();
            dgv.Dock = DockStyle.Fill;
            dgv.DataSource = dt;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.EnableHeadersVisualStyles = false;

            frmResumen.Controls.Add(dgv);
            frmResumen.ShowDialog();
        }
    }
}