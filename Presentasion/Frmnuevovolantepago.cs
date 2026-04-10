using Negocios.Nomina;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmNuevoVolantePago : Form
    {
        // ─── Colores ────────────────────────────────────────────────────────
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

        // ─── Negocio ────────────────────────────────────────────────────────
        private readonly VolantesPagoCN _cn = new VolantesPagoCN();

        public FrmNuevoVolantePago()
        {
            InitializeComponent();
            ConfigurarEventos();
            CargarEmpleados();
        }

        // ══════════════════════════════════════════════════════════════════
        //  CONFIGURACIÓN DE EVENTOS
        // ══════════════════════════════════════════════════════════════════
        private void ConfigurarEventos()
        {
            pnlCuerpo.Paint += PnlBorde_Paint;

            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            cmbEmpleado.SelectedIndexChanged += CmbEmpleado_Changed;
            cmbPeriodo.SelectedIndexChanged += CmbPeriodo_Changed;
            cmbDeduccion.SelectedIndexChanged += CmbDeduccion_Changed;

            btnGuardar.MouseEnter += (s, e) => btnGuardar.BackColor = Color.FromArgb(40, 100, 210);
            btnGuardar.MouseLeave += (s, e) => btnGuardar.BackColor = ColorBotonAzul;
            btnCancelar.MouseEnter += (s, e) => btnCancelar.BackColor = Color.FromArgb(35, 48, 85);
            btnCancelar.MouseLeave += (s, e) => btnCancelar.BackColor = ColorInput;

            cmbEmpleado.DrawMode = DrawMode.OwnerDrawFixed;
            cmbEmpleado.DrawItem += (s, e) =>
            {
                if (e.Index < 0) return;
                e.DrawBackground();
                DataRowView row = (DataRowView)cmbEmpleado.Items[e.Index];
                string display = $"{row["CodigoEmpleado"]} — {row["NombreCompleto"]}";
                using (SolidBrush b = new SolidBrush(ColorTexto))
                    e.Graphics.DrawString(display, new Font("Segoe UI", 9), b, e.Bounds);
            };
        }

        // ══════════════════════════════════════════════════════════════════
        //  CARGA DE COMBOS
        // ══════════════════════════════════════════════════════════════════
        private void CargarEmpleados()
        {
            try
            {
                DataTable dt = _cn.MostrarEmpleados();
                cmbEmpleado.DataSource = dt;
                cmbEmpleado.DisplayMember = "CodigoEmpleado";
                cmbEmpleado.ValueMember = "Id";
                cmbEmpleado.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MostrarEstado("Error al cargar empleados: " + ex.Message, false);
            }
        }

        private void CmbEmpleado_Changed(object sender, EventArgs e)
        {
            if (cmbEmpleado.SelectedValue == null || cmbEmpleado.SelectedIndex < 0) return;

            int idEmp = Convert.ToInt32(cmbEmpleado.SelectedValue);
            DataRowView row = (DataRowView)cmbEmpleado.SelectedItem;
            lblInfoEmpleado.Text = row["NombreCompleto"].ToString();

            CargarPeriodos(idEmp);
            CargarDeducciones(idEmp);
            LimpiarPreview();
        }

        private void CargarPeriodos(int idEmpleado)
        {
            try
            {
                DataTable dt = _cn.MostrarSalariosPorEmpleado(idEmpleado);
                cmbPeriodo.DataSource = dt;
                cmbPeriodo.DisplayMember = "Descripcion";
                cmbPeriodo.ValueMember = "Id";
                cmbPeriodo.SelectedIndex = dt.Rows.Count > 0 ? 0 : -1;

                if (dt.Rows.Count == 0)
                    MostrarEstado("Sin períodos de sueldo. Registre asignaciones primero.", false);
            }
            catch (Exception ex)
            {
                MostrarEstado("Error al cargar períodos: " + ex.Message, false);
            }
        }

        private void CargarDeducciones(int idEmpleado)
        {
            try
            {
                DataTable dt = _cn.MostrarDeduccionesEmpleado(idEmpleado);
                cmbDeduccion.DataSource = dt;
                cmbDeduccion.DisplayMember = "Descripcion";
                cmbDeduccion.ValueMember = "Id";
                cmbDeduccion.SelectedIndex = dt.Rows.Count > 0 ? 0 : -1;

                if (dt.Rows.Count == 0)
                    MostrarEstado("Sin deducciones registradas para este empleado.", false);
            }
            catch (Exception ex)
            {
                MostrarEstado("Error al cargar deducciones: " + ex.Message, false);
            }
        }

        private void CmbPeriodo_Changed(object sender, EventArgs e)
        {
            if (cmbPeriodo.SelectedItem == null) return;
            DataRowView row = (DataRowView)cmbPeriodo.SelectedItem;
            lblPreviewSubtotal.Text = $"Subtotal: {Convert.ToDecimal(row["Total"]):C2}";
            ActualizarTotal();
        }

        private void CmbDeduccion_Changed(object sender, EventArgs e)
        {
            if (cmbDeduccion.SelectedItem == null) return;
            DataRowView row = (DataRowView)cmbDeduccion.SelectedItem;
            lblPreviewDeduccion.Text = $"Deducción: {Convert.ToDecimal(row["Monto"]):C2}";
            ActualizarTotal();
        }

        private void ActualizarTotal()
        {
            try
            {
                decimal subtotal = cmbPeriodo.SelectedItem != null
                    ? Convert.ToDecimal(((DataRowView)cmbPeriodo.SelectedItem)["Total"]) : 0;
                decimal deduccion = cmbDeduccion.SelectedItem != null
                    ? Convert.ToDecimal(((DataRowView)cmbDeduccion.SelectedItem)["Monto"]) : 0;
                decimal neto = subtotal - deduccion;

                lblPreviewTotal.Text = $"Total Neto: {neto:C2}";
                lblPreviewTotal.ForeColor = neto >= 0 ? ColorVerde : ColorEliminar;
            }
            catch { }
        }

        private void LimpiarPreview()
        {
            lblPreviewSubtotal.Text = "Subtotal: —";
            lblPreviewDeduccion.Text = "Deducción: —";
            lblPreviewTotal.Text = "Total Neto: —";
            lblPreviewTotal.ForeColor = ColorSubTexto;
        }

        // ══════════════════════════════════════════════════════════════════
        //  GUARDAR
        // ══════════════════════════════════════════════════════════════════
        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            try
            {
                btnGuardar.Enabled = false;
                lblEstado.Text = "Guardando...";
                lblEstado.ForeColor = ColorSubTexto;

                int idEmpleado = Convert.ToInt32(cmbEmpleado.SelectedValue);
                int idAsignaciones = Convert.ToInt32(cmbPeriodo.SelectedValue);
                int idDeducciones = Convert.ToInt32(cmbDeduccion.SelectedValue);
                DateTime fecha = dtpFecha.Value.Date;

                var resultado = await _cn.InsertarAsync(idEmpleado, idAsignaciones, idDeducciones, fecha);

                if (resultado.exito)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MostrarEstado(resultado.mensaje, false);
                    btnGuardar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MostrarEstado("Error: " + ex.Message, false);
                btnGuardar.Enabled = true;
            }
        }

        // ══════════════════════════════════════════════════════════════════
        //  VALIDACIÓN
        // ══════════════════════════════════════════════════════════════════
        private bool Validar()
        {
            if (cmbEmpleado.SelectedValue == null || cmbEmpleado.SelectedIndex < 0)
            { MostrarEstado("Debe seleccionar un empleado.", false); cmbEmpleado.Focus(); return false; }

            if (cmbPeriodo.SelectedValue == null || cmbPeriodo.SelectedIndex < 0)
            { MostrarEstado("Debe seleccionar un período de sueldo.", false); cmbPeriodo.Focus(); return false; }

            if (cmbDeduccion.SelectedValue == null || cmbDeduccion.SelectedIndex < 0)
            { MostrarEstado("Debe seleccionar una deducción.", false); cmbDeduccion.Focus(); return false; }

            if (dtpFecha.Value.Date < DateTime.Today)
            { MostrarEstado("La fecha no puede ser anterior a hoy.", false); dtpFecha.Focus(); return false; }

            return true;
        }

        private void MostrarEstado(string texto, bool exito)
        {
            lblEstado.Text = exito ? "✓  " + texto : "✗  " + texto;
            lblEstado.ForeColor = exito ? ColorVerde : ColorEliminar;
        }

        private void PnlBorde_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = (Panel)sender;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen p = new Pen(ColorBorde, 1))
            {
                GraphicsPath path = new GraphicsPath();
                int r = 8;
                path.AddArc(0, 0, r * 2, r * 2, 180, 90);
                path.AddArc(pnl.Width - r * 2, 0, r * 2, r * 2, 270, 90);
                path.AddArc(pnl.Width - r * 2, pnl.Height - r * 2, r * 2, r * 2, 0, 90);
                path.AddArc(0, pnl.Height - r * 2, r * 2, r * 2, 90, 90);
                path.CloseAllFigures();
                e.Graphics.DrawPath(p, path);
            }
        }

        private void FrmNuevoVolantePago_Load(object sender, EventArgs e) { }
    }
}
