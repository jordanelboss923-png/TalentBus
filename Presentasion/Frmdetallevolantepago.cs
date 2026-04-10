using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmDetalleVolantePago : Form
    {
        // ─── Colores ────────────────────────────────────────────────────────
        private readonly Color ColorBorde = Color.FromArgb(30, 40, 80);
        private readonly Color ColorVerde = Color.FromArgb(39, 201, 63);
        private readonly Color ColorEliminar = Color.FromArgb(255, 80, 80);
        private readonly Color ColorCyan = Color.FromArgb(0, 210, 230);
        private readonly Color ColorBoton = Color.FromArgb(0, 210, 230);
        private readonly Color ColorBtnTxt = Color.FromArgb(13, 17, 35);

        public FrmDetalleVolantePago(DataRow row)
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
            lblVCodigo.Text = row.Table.Columns.Contains("CodigoEmpleado")
                                    ? row["CodigoEmpleado"].ToString() : "—";
            lblVEmpleado.Text = row["Empleado"].ToString();
            lblVPosicion.Text = row.Table.Columns.Contains("Posicion")
                                    ? row["Posicion"].ToString() : "—";
            lblVFecha.Text = Convert.ToDateTime(row["FechaEfectividad"]).ToString("dd/MM/yyyy");

            decimal subtotal = Convert.ToDecimal(row["Subtotal"]);
            decimal deducciones = Convert.ToDecimal(row["Deducciones"]);
            decimal total = Convert.ToDecimal(row["Total"]);

            lblVSubtotal.Text = subtotal.ToString("C2");
            lblVDeducciones.Text = deducciones.ToString("C2");
            lblVTotal.Text = total.ToString("C2");
            lblVTotal.ForeColor = total >= 0 ? ColorVerde : ColorEliminar;
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            string contenido =
                "══════════════════════════════\n" +
                "         TALENTBUS DB3\n" +
                "      VOLANTE DE PAGO\n" +
                "══════════════════════════════\n" +
                $"Código:       {lblVCodigo.Text}\n" +
                $"Empleado:     {lblVEmpleado.Text}\n" +
                $"Posición:     {lblVPosicion.Text}\n" +
                $"Período:      {lblVFecha.Text}\n" +
                "──────────────────────────────\n" +
                $"Subtotal:     {lblVSubtotal.Text}\n" +
                $"Deducciones:  {lblVDeducciones.Text}\n" +
                "══════════════════════════════\n" +
                $"TOTAL NETO:   {lblVTotal.Text}\n" +
                "══════════════════════════════\n";

            MessageBox.Show(contenido, "Vista Previa — Volante de Pago",
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

        private void FrmDetalleVolantePago_Load(object sender, EventArgs e) { }
    }
}