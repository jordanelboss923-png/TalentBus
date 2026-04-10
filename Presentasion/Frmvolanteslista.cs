using Negocios;
using Negocios.Nomina;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmVolantesLista : Form
    {
        // ─── Colores ────────────────────────────────────────────────────────
        private readonly Color ColorFondo = Color.FromArgb(13, 17, 35);
        private readonly Color ColorPanel = Color.FromArgb(18, 24, 48);
        private readonly Color ColorCyan = Color.FromArgb(0, 210, 230);
        private readonly Color ColorTexto = Color.White;
        private readonly Color ColorSubTexto = Color.FromArgb(130, 150, 190);
        private readonly Color ColorInput = Color.FromArgb(25, 35, 65);
        private readonly Color ColorBorde = Color.FromArgb(30, 40, 80);
        private readonly Color ColorBoton = Color.FromArgb(0, 210, 230);
        private readonly Color ColorBotonTexto = Color.FromArgb(13, 17, 35);
        private readonly Color ColorEliminar = Color.FromArgb(255, 80, 80);
        private readonly Color ColorVerde = Color.FromArgb(39, 201, 63);
        private readonly Color ColorEditar = Color.FromArgb(30, 80, 180);

        // ─── Negocio ────────────────────────────────────────────────────────
        private readonly VolantesPagoCN _cn = new VolantesPagoCN();
        private readonly EmpleadosCN _cnEmp = new EmpleadosCN();

        public FrmVolantesLista()
        {
            InitializeComponent();
            ConfigurarEventos();
            CargarEmpleadosFiltro();
            CargarDatos();
        }

        // ══════════════════════════════════════════════════════════════════
        //  CONFIGURACIÓN DE EVENTOS
        // ══════════════════════════════════════════════════════════════════
        private void ConfigurarEventos()
        {
            pnlFiltro.Paint += PnlBorde_Paint;

            // Posicionar btnNuevo dinámicamente
            pnlHeader.Resize += (s, e) => btnNuevo.Left = pnlHeader.Width - btnNuevo.Width - 20;
            pnlHeader.HandleCreated += (s, e) => btnNuevo.Left = pnlHeader.Width - btnNuevo.Width - 20;

            btnNuevo.Click += BtnNuevo_Click;
            btnFiltrar.Click += BtnFiltrar_Click;
            btnLimpiar.Click += BtnLimpiar_Click;

            dgvVolantes.CellClick += Grid_CellClick;

            ConfigurarHover(btnNuevo, ColorBoton, Color.FromArgb(0, 185, 205));
            ConfigurarHover(btnFiltrar, ColorEditar, Color.FromArgb(40, 100, 210));
            ConfigurarHover(btnLimpiar, ColorInput, Color.FromArgb(35, 48, 85));

            foreach (Button btn in new[] { btnNuevo, btnFiltrar, btnLimpiar })
            {
                btn.Region = CrearRegionRedondeada(btn.Size, 6);
                btn.SizeChanged += (s, e) =>
                    ((Button)s).Region = CrearRegionRedondeada(((Button)s).Size, 6);
            }

            cmbFiltroEmpleado.DrawMode = DrawMode.OwnerDrawFixed;
            cmbFiltroEmpleado.DrawItem += CmbFiltro_DrawItem;
        }

        private void CmbFiltro_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            e.DrawBackground();
            string display;
            if (e.Index == 0)
                display = "— Todos los empleados —";
            else
            {
                DataRowView row = (DataRowView)cmbFiltroEmpleado.Items[e.Index];
                display = $"{row["CodigoEmpleado"]} — {row["Nombre"]} {row["Apellido"]}";
            }
            using (SolidBrush b = new SolidBrush(ColorTexto))
                e.Graphics.DrawString(display, new Font("Segoe UI", 9), b, e.Bounds);
        }

        private void ConfigurarHover(Button btn, Color normal, Color hover)
        {
            btn.BackColor = normal;
            btn.MouseEnter += (s, e) => btn.BackColor = hover;
            btn.MouseLeave += (s, e) => btn.BackColor = normal;
        }

        // ══════════════════════════════════════════════════════════════════
        //  CARGA DE DATOS
        // ══════════════════════════════════════════════════════════════════
        private void CargarEmpleadosFiltro()
        {
            try
            {
                DataTable dt = _cnEmp.ObtenerTodos();

                DataRow todos = dt.NewRow();
                todos["Id"] = 0;
                todos["CodigoEmpleado"] = "";
                todos["Nombre"] = "— Todos";
                todos["Apellido"] = "—";
                dt.Rows.InsertAt(todos, 0);

                cmbFiltroEmpleado.DataSource = dt;
                cmbFiltroEmpleado.DisplayMember = "CodigoEmpleado";
                cmbFiltroEmpleado.ValueMember = "Id";
                cmbFiltroEmpleado.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al cargar empleados: " + ex.Message, false);
            }
        }

        private void CargarDatos(int idEmpleadoFiltro = 0)
        {
            try
            {
                DataTable dt = idEmpleadoFiltro > 0
                    ? _cn.ObtenerPorEmpleado(idEmpleadoFiltro)
                    : _cn.ObtenerTodos();

                dgvVolantes.DataSource = null;
                dgvVolantes.DataSource = dt;

                if (dgvVolantes.Columns.Contains("Id"))
                    dgvVolantes.Columns["Id"].Visible = false;
                if (dgvVolantes.Columns.Contains("IdEmpleado"))
                    dgvVolantes.Columns["IdEmpleado"].Visible = false;
                if (dgvVolantes.Columns.Contains("IdAsignaciones"))
                    dgvVolantes.Columns["IdAsignaciones"].Visible = false;
                if (dgvVolantes.Columns.Contains("IdDeducciones"))
                    dgvVolantes.Columns["IdDeducciones"].Visible = false;

                RenombrarColumna("CodigoEmpleado", "Código");
                RenombrarColumna("Empleado", "Empleado");
                RenombrarColumna("Posicion", "Posición");
                RenombrarColumna("Subtotal", "Subtotal");
                RenombrarColumna("Deducciones", "Deducciones");
                RenombrarColumna("Total", "Total Neto");
                RenombrarColumna("FechaEfectividad", "Período");
                RenombrarColumna("FechaRegistro", "Registro");

                foreach (string col in new[] { "Subtotal", "Deducciones", "Total" })
                    if (dgvVolantes.Columns.Contains(col))
                        dgvVolantes.Columns[col].DefaultCellStyle.Format = "N2";

                foreach (string col in new[] { "FechaEfectividad", "FechaRegistro" })
                    if (dgvVolantes.Columns.Contains(col))
                        dgvVolantes.Columns[col].DefaultCellStyle.Format = "dd/MM/yyyy";

                AgregarColumnaBoton("Ver Volante", ColorCyan, "btnVer", ColorBotonTexto);
                AgregarColumnaBoton("Eliminar", ColorEliminar, "btnEliminar", ColorTexto);

                lblConteo.Text = $"{dt.Rows.Count} registro(s)";
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al cargar volantes: " + ex.Message, false);
            }
        }

        private void AgregarColumnaBoton(string texto, Color color, string nombre, Color colorTexto)
        {
            if (dgvVolantes.Columns.Contains(nombre)) return;
            DataGridViewButtonColumn col = new DataGridViewButtonColumn
            {
                Name = nombre,
                HeaderText = "",
                Text = texto,
                UseColumnTextForButtonValue = true,
                Width = 110,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                FlatStyle = FlatStyle.Flat
            };
            col.DefaultCellStyle.BackColor = color;
            col.DefaultCellStyle.ForeColor = colorTexto;
            col.DefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            col.DefaultCellStyle.SelectionBackColor = color;
            col.DefaultCellStyle.SelectionForeColor = colorTexto;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvVolantes.Columns.Add(col);
        }

        // ══════════════════════════════════════════════════════════════════
        //  EVENTOS BOTONES
        // ══════════════════════════════════════════════════════════════════
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            FrmNuevoVolantePago frm = new FrmNuevoVolantePago();
            frm.TopLevel = true;
            frm.FormBorderStyle = FormBorderStyle.FixedDialog;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.FormClosed += (s, ev) =>
            {
                if (frm.DialogResult == DialogResult.OK)
                {
                    MostrarMensaje("Volante de pago registrado correctamente.", true);
                    RefrescarGrid();
                }
            };
            frm.Show();
        }

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            int idEmpleado = Convert.ToInt32(cmbFiltroEmpleado.SelectedValue ?? 0);
            RefrescarGrid(idEmpleado);
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            cmbFiltroEmpleado.SelectedIndex = 0;
            RefrescarGrid(0);
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string colName = dgvVolantes.Columns[e.ColumnIndex].Name;
            DataRow row = ((DataTable)dgvVolantes.DataSource).Rows[e.RowIndex];

            switch (colName)
            {
                case "btnVer":
                    FrmDetalleVolantePago frmDetalle = new FrmDetalleVolantePago(row);
                    frmDetalle.ShowDialog(this);
                    break;

                case "btnEliminar":
                    int id = Convert.ToInt32(row["Id"]);
                    string emp = row["Empleado"].ToString();
                    string per = Convert.ToDateTime(row["FechaEfectividad"]).ToString("dd/MM/yyyy");

                    if (MessageBox.Show(
                            $"¿Eliminar el volante de pago de \"{emp}\" del período {per}?",
                            "Confirmar eliminación",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        var resultado = _cn.Eliminar(id);
                        MostrarMensaje(resultado.mensaje, resultado.exito);
                        if (resultado.exito) RefrescarGrid();
                    }
                    break;
            }
        }

        // ══════════════════════════════════════════════════════════════════
        //  HELPERS
        // ══════════════════════════════════════════════════════════════════
        private void RefrescarGrid(int idEmpleado = 0)
        {
            foreach (string col in new[] { "btnVer", "btnEliminar" })
                if (dgvVolantes.Columns.Contains(col))
                    dgvVolantes.Columns.Remove(col);
            CargarDatos(idEmpleado);
        }

        private void MostrarMensaje(string texto, bool exito)
        {
            lblMensaje.Text = exito ? "✓  " + texto : "✗  " + texto;
            lblMensaje.ForeColor = exito ? ColorVerde : ColorEliminar;
        }

        private void RenombrarColumna(string nombre, string encabezado)
        {
            if (dgvVolantes.Columns.Contains(nombre))
                dgvVolantes.Columns[nombre].HeaderText = encabezado;
        }

        private Region CrearRegionRedondeada(Size size, int radio)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radio * 2, radio * 2, 180, 90);
            path.AddArc(size.Width - radio * 2, 0, radio * 2, radio * 2, 270, 90);
            path.AddArc(size.Width - radio * 2, size.Height - radio * 2, radio * 2, radio * 2, 0, 90);
            path.AddArc(0, size.Height - radio * 2, radio * 2, radio * 2, 90, 90);
            path.CloseAllFigures();
            return new Region(path);
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

        private void FrmVolantesLista_Load(object sender, EventArgs e) { }
    }
}
