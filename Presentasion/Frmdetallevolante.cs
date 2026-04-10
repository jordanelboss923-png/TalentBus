using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Negocios.Nomina;

namespace Presentacion
{
    public partial class FrmDetalleVolante : Form
    {
        // ─── Colores ────────────────────────────────────────────────────────
        private readonly Color ColorFondo = Color.FromArgb(13, 17, 35);
        private readonly Color ColorPanel = Color.FromArgb(18, 24, 48);
        private readonly Color ColorHeader = Color.FromArgb(15, 22, 45);
        private readonly Color ColorCyan = Color.FromArgb(0, 210, 230);
        private readonly Color ColorTexto = Color.White;
        private readonly Color ColorSubTexto = Color.FromArgb(130, 150, 190);
        private readonly Color ColorBorde = Color.FromArgb(30, 40, 80);
        private readonly Color ColorVerde = Color.FromArgb(39, 201, 63);
        private readonly Color ColorEliminar = Color.FromArgb(255, 80, 80);
        private readonly Color ColorBoton = Color.FromArgb(0, 210, 230);
        private readonly Color ColorBotonTexto = Color.FromArgb(13, 17, 35);

        private readonly VolantesPagoCN _cn = new VolantesPagoCN();

        public FrmDetalleVolante(DataRow row)
        {
            InitializeComponent();
            ConfigurarEventos();
            CargarDatos(row);
        }

        private void ConfigurarEventos()
        {
            btnCerrar.Click += (s, e) => this.Close();
            btnImprimir.Click += BtnImprimir_Click;

            btnCerrar.MouseEnter += (s, e) => btnCerrar.BackColor = Color.FromArgb(200, 60, 60);
            btnCerrar.MouseLeave += (s, e) => btnCerrar.BackColor = ColorEliminar;
            btnImprimir.MouseEnter += (s, e) => btnImprimir.BackColor = Color.FromArgb(0, 185, 205);
            btnImprimir.MouseLeave += (s, e) => btnImprimir.BackColor = ColorBoton;

            pnlCuerpo.Paint += PnlBorde_Paint;
        }

        private void CargarDatos(DataRow row)
        {
            // ── Info del empleado ──────────────────────────────────────────
            lblVCodigo.Text = row.Table.Columns.Contains("CodigoEmpleado")
                                    ? row["CodigoEmpleado"].ToString() : "—";
            lblVEmpleado.Text = row["Empleado"].ToString();
            lblVPosicion.Text = row.Table.Columns.Contains("Posicion")
                                    ? row["Posicion"].ToString() : "—";
            lblVFecha.Text = Convert.ToDateTime(row["FechaEfectividad"]).ToString("dd/MM/yyyy");

            // ── Montos de SalarioST ────────────────────────────────────────
            decimal sueldo = Convert.ToDecimal(row["Sueldobase"]);
            decimal asignacion = Convert.ToDecimal(row["Asignacion"]);
            decimal total = Convert.ToDecimal(row["Total"]);

            lblVSueldo.Text = sueldo.ToString("C2");
            lblVAsignacion.Text = asignacion.ToString("C2");
            lblVSubtotal.Text = total.ToString("C2");

            // ── Deducciones ───────────────────────────────────────────────
            try
            {
                int idEmp = row.Table.Columns.Contains("IdEmpleado") && row["IdEmpleado"] != DBNull.Value
                    ? Convert.ToInt32(row["IdEmpleado"]) : 0;

                DateTime fecha = Convert.ToDateTime(row["FechaEfectividad"]);

                if (idEmp > 0)
                {
                    DataTable dtComp = _cn.ObtenerVolanteCompleto(idEmp, fecha);
                    if (dtComp != null && dtComp.Rows.Count > 0)
                    {
                        decimal ded = Convert.ToDecimal(dtComp.Rows[0]["TotalDeducciones"]);
                        decimal neto = Convert.ToDecimal(dtComp.Rows[0]["SalarioNeto"]);
                        lblVDeducciones.Text = ded.ToString("C2");
                        lblVNeto.Text = neto.ToString("C2");
                        lblVNeto.ForeColor = neto >= 0 ? ColorVerde : ColorEliminar;
                    }
                    else
                    {
                        lblVDeducciones.Text = "$0.00";
                        lblVNeto.Text = total.ToString("C2");
                        lblVNeto.ForeColor = ColorVerde;
                    }
                }
            }
            catch
            {
                lblVDeducciones.Text = "$0.00";
                lblVNeto.Text = total.ToString("C2");
                lblVNeto.ForeColor = ColorVerde;
            }
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            string contenido =
                "══════════════════════════════\n" +
                "         TALENTBUS DB3\n" +
                "        SUELDO NETO\n" +
                "══════════════════════════════\n" +
                $"Código:       {lblVCodigo.Text}\n" +
                $"Empleado:     {lblVEmpleado.Text}\n" +
                $"Posición:     {lblVPosicion.Text}\n" +
                $"Período:      {lblVFecha.Text}\n" +
                "──────────────────────────────\n" +
                "INGRESOS\n" +
                $"Sueldo Base:  {lblVSueldo.Text}\n" +
                $"Asignaciones: {lblVAsignacion.Text}\n" +
                $"Subtotal:     {lblVSubtotal.Text}\n" +
                "──────────────────────────────\n" +
                "DEDUCCIONES\n" +
                $"Total Ded.:   {lblVDeducciones.Text}\n" +
                "══════════════════════════════\n" +
                $"SALARIO NETO: {lblVNeto.Text}\n" +
                "══════════════════════════════\n";

            MessageBox.Show(contenido, "Vista Previa — Sueldo Neto",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void FrmDetalleVolante_Load(object sender, EventArgs e) { }
    }
}
