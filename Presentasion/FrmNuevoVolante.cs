using Negocios.Nomina;
using Negocios;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmNuevoVolante : Form
    {
        // ─── Colores ───────────────────────────────────────────────────────
        private readonly Color ColorFondo = Color.FromArgb(13, 17, 35);
        private readonly Color ColorPanel = Color.FromArgb(18, 24, 48);
        private readonly Color ColorCyan = Color.FromArgb(0, 210, 230);
        private readonly Color ColorTexto = Color.White;
        private readonly Color ColorSubTexto = Color.FromArgb(130, 150, 190);
        private readonly Color ColorInput = Color.FromArgb(25, 35, 65);
        private readonly Color ColorBorde = Color.FromArgb(30, 40, 80);
        private readonly Color ColorBotonAzul = Color.FromArgb(30, 80, 180);
        private readonly Color ColorEliminar = Color.FromArgb(255, 80, 80);
        private readonly Color ColorVerde = Color.FromArgb(39, 201, 63);

        // ─── Negocio ───────────────────────────────────────────────────────
        private readonly VolantesPagoCN _cn = new VolantesPagoCN();
        private readonly EmpleadosCN _cnEmp = new EmpleadosCN();

        // ─── Estado ───────────────────────────────────────────────────────
        private readonly int _idEditar = 0;
        private readonly bool _modoEditar = false;

        // Constructor para NUEVO
        public FrmNuevoVolante()
        {
            InitializeComponent();
            ConfigurarEventos();
            CargarEmpleados();
        }

        // Constructor para EDITAR (recibe el id y la fila actual del grid)
        public FrmNuevoVolante(int id, DataRow rowActual)
        {
            InitializeComponent();
            _idEditar = id;
            _modoEditar = true;
            ConfigurarEventos();
            CargarEmpleados();
            CargarDatosEdicion(rowActual);
        }

        // ══════════════════════════════════════════════════════════════════
        //  CONFIGURACIÓN
        // ══════════════════════════════════════════════════════════════════
        private void ConfigurarEventos()
        {
            lblTitulo.Text = _modoEditar ? "Editar Volante de Pago" : "Nuevo Volante de Pago";
            btnGuardar.Text = _modoEditar ? "Actualizar" : "Guardar";

            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            // Al seleccionar empleado, cargar su sueldo base automáticamente
            cmbEmpleado.SelectedIndexChanged += CmbEmpleado_SelectedIndexChanged;

            // Al cambiar asignación, recalcular total
            txtAsignacion.TextChanged += RecalcularTotal;

            // Solo números decimales en campos monetarios
            foreach (TextBox txt in new[] { txtSueldo, txtAsignacion })
            {
                txt.KeyPress += (s, e) =>
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                        e.Handled = true;
                    if (e.KeyChar == '.' && ((TextBox)s).Text.Contains("."))
                        e.Handled = true;
                };
            }

            txtSueldo.TextChanged += RecalcularTotal;

            // DrawMode del combo
            cmbEmpleado.DrawMode = DrawMode.OwnerDrawFixed;
            cmbEmpleado.DrawItem += (s, e) =>
            {
                if (e.Index < 0) return;
                e.DrawBackground();
                DataRowView row = (DataRowView)cmbEmpleado.Items[e.Index];
                string display = $"{row["CodigoEmpleado"]} — {row["Nombre"]} {row["Apellido"]}";
                using (SolidBrush b = new SolidBrush(ColorTexto))
                    e.Graphics.DrawString(display, new Font("Segoe UI", 9), b, e.Bounds);
            };

            // Hover botones
            btnGuardar.MouseEnter += (s, e) => btnGuardar.BackColor = Color.FromArgb(40, 100, 210);
            btnGuardar.MouseLeave += (s, e) => btnGuardar.BackColor = ColorBotonAzul;
            btnCancelar.MouseEnter += (s, e) => btnCancelar.BackColor = Color.FromArgb(35, 48, 85);
            btnCancelar.MouseLeave += (s, e) => btnCancelar.BackColor = ColorInput;
        }

        private void CargarEmpleados()
        {
            try
            {
                DataTable dt = _cnEmp.ObtenerTodos();
                cmbEmpleado.DataSource = dt;
                cmbEmpleado.DisplayMember = "CodigoEmpleado";
                cmbEmpleado.ValueMember = "Id";
                cmbEmpleado.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                lblEstado.Text = "Error al cargar empleados: " + ex.Message;
                lblEstado.ForeColor = ColorEliminar;
            }
        }

        private void CargarDatosEdicion(DataRow row)
        {
            // Seleccionar el empleado en el combo
            try
            {
                string codigo = row["CodigoEmpleado"].ToString();
                DataTable dtCombo = (DataTable)cmbEmpleado.DataSource;
                foreach (DataRow item in dtCombo.Rows)
                {
                    if (item["CodigoEmpleado"].ToString() == codigo)
                    {
                        cmbEmpleado.SelectedValue = item["Id"];
                        break;
                    }
                }
            }
            catch { }

            txtSueldo.Text = Convert.ToDecimal(row["Sueldobase"]).ToString("F2");
            txtAsignacion.Text = Convert.ToDecimal(row["Asignacion"]).ToString("F2");
            dtpFecha.Value = Convert.ToDateTime(row["FechaEfectividad"]);

            // En modo edición el empleado no se puede cambiar
            cmbEmpleado.Enabled = false;
            txtSueldo.ReadOnly = true; // El sueldo viene del empleado

            RecalcularTotal(null, null);
        }

        // ══════════════════════════════════════════════════════════════════
        //  LÓGICA
        // ══════════════════════════════════════════════════════════════════
        private void CmbEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEmpleado.SelectedValue == null || cmbEmpleado.SelectedIndex < 0) return;

            try
            {
                int idEmp = Convert.ToInt32(cmbEmpleado.SelectedValue);
                DataTable dt = _cnEmp.ObtenerPorId(idEmp);
                if (dt.Rows.Count > 0)
                {
                    decimal sueldo = Convert.ToDecimal(dt.Rows[0]["SalarioBase"]);
                    txtSueldo.Text = sueldo.ToString("F2");

                    // Mostrar info del empleado
                    lblInfoEmpleado.Text =
                        $"{dt.Rows[0]["Nombre"]} {dt.Rows[0]["Apellido"]}  |  " +
                        $"Posición: {dt.Rows[0]["Posicion"] ?? "—"}";
                }
            }
            catch (Exception ex)
            {
                lblEstado.Text = "Error al obtener datos del empleado: " + ex.Message;
                lblEstado.ForeColor = ColorEliminar;
            }
        }

        private void RecalcularTotal(object sender, EventArgs e)
        {
            decimal sueldo = 0, asignacion = 0;
            decimal.TryParse(txtSueldo.Text, out sueldo);
            decimal.TryParse(txtAsignacion.Text, out asignacion);
            decimal total = sueldo + asignacion;
            txtTotal.Text = total.ToString("F2");
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            try
            {
                btnGuardar.Enabled = false;
                lblEstado.Text = _modoEditar ? "Actualizando..." : "Guardando...";
                lblEstado.ForeColor = ColorSubTexto;

                int idEmpleado = Convert.ToInt32(cmbEmpleado.SelectedValue);
                decimal sueldo = decimal.Parse(txtSueldo.Text);
                decimal asignacion = decimal.Parse(txtAsignacion.Text);
                decimal total = sueldo + asignacion;
                DateTime fecha = dtpFecha.Value.Date;

                bool resultado;
                if (_modoEditar)
                    resultado = _cn.Actualizar(_idEditar, sueldo, asignacion, total, fecha);
                else
                    resultado = _cn.Insertar(idEmpleado, sueldo, asignacion, total, fecha);

                if (resultado)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    lblEstado.Text = "No se pudo guardar el registro.";
                    lblEstado.ForeColor = ColorEliminar;
                    btnGuardar.Enabled = true;
                }
            }
            catch (ArgumentException ex)
            {
                lblEstado.Text = ex.Message;
                lblEstado.ForeColor = ColorEliminar;
                btnGuardar.Enabled = true;
            }
            catch (InvalidOperationException ex)
            {
                lblEstado.Text = ex.Message;
                lblEstado.ForeColor = ColorEliminar;
                btnGuardar.Enabled = true;
            }
            catch (Exception ex)
            {
                lblEstado.Text = "Error: " + ex.Message;
                lblEstado.ForeColor = ColorEliminar;
                btnGuardar.Enabled = true;
            }
        }

        private bool Validar()
        {
            if (!_modoEditar && (cmbEmpleado.SelectedValue == null || cmbEmpleado.SelectedIndex < 0))
            {
                lblEstado.Text = "Debe seleccionar un empleado.";
                lblEstado.ForeColor = ColorEliminar;
                cmbEmpleado.Focus();
                return false;
            }

            if (!decimal.TryParse(txtSueldo.Text, out decimal sueldo) || sueldo <= 0)
            {
                lblEstado.Text = "El sueldo base debe ser mayor a cero.";
                lblEstado.ForeColor = ColorEliminar;
                txtSueldo.Focus();
                return false;
            }

            if (!decimal.TryParse(txtAsignacion.Text, out decimal asig) || asig < 0)
            {
                lblEstado.Text = "La asignación no puede ser negativa.";
                lblEstado.ForeColor = ColorEliminar;
                txtAsignacion.Focus();
                return false;
            }

            if (dtpFecha.Value.Date > DateTime.Today)
            {
                lblEstado.Text = "La fecha de efectividad no puede ser futura.";
                lblEstado.ForeColor = ColorEliminar;
                dtpFecha.Focus();
                return false;
            }

            return true;
        }

        private void FrmNuevoVolante_Load(object sender, EventArgs e) { }
    }
}
