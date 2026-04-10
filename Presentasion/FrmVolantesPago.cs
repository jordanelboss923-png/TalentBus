using Negocios.Nomina;
using Negocios;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmVolantesPago : Form
    {
        // ─── Colores ───────────────────────────────────────────────────────
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

        // ─── Negocio ───────────────────────────────────────────────────────
        private readonly VolantesPagoCN _cn = new VolantesPagoCN();
        private readonly EmpleadosCN _cnEmp = new EmpleadosCN();

        public FrmVolantesPago()
        {
            InitializeComponent();
            ConfigurarEventos();
            CargarEmpleadosFiltro();
            CargarDatos();
        }

        // ══════════════════════════════════════════════════════════════════
        //  EVENTOS
        // ══════════════════════════════════════════════════════════════════
        private void ConfigurarEventos()
        {
            pnlFiltro.Paint += PnlBorde_Paint;
            pnlVistaVolante.Paint += PnlBorde_Paint;

            picLogo.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen p = new Pen(ColorCyan, 1.5f))
                    e.Graphics.DrawEllipse(p, 1, 1, 32, 32);
                DibujarEstrella(e.Graphics, 18, 18, 12, 5, 5, ColorCyan);
            };

            btnNuevo.Click += BtnNuevo_Click;
            btnFiltrar.Click += BtnFiltrar_Click;
            btnLimpiar.Click += BtnLimpiarFiltro_Click;
            btnImprimir.Click += BtnImprimir_Click;

            dgvVolantes.CellClick += Grid_CellClick;

            ConfigurarHover(btnNuevo, ColorBoton, Color.FromArgb(0, 185, 205));
            ConfigurarHover(btnFiltrar, ColorEditar, Color.FromArgb(40, 100, 210));
            ConfigurarHover(btnLimpiar, ColorInput, Color.FromArgb(35, 48, 85));
            ConfigurarHover(btnImprimir, ColorBoton, Color.FromArgb(0, 185, 205));

            foreach (Button btn in new[] { btnNuevo, btnFiltrar, btnLimpiar, btnImprimir })
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
            {
                display = "— Todos los empleados —";
            }
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

                if (dgvVolantes.Columns.Contains("IdEmpleado"))
                    dgvVolantes.Columns["IdEmpleado"].Visible = false;
                if (dgvVolantes.Columns.Contains("Id"))
                    dgvVolantes.Columns["Id"].Visible = false;

                RenombrarColumna("CodigoEmpleado", "Código");
                RenombrarColumna("Empleado", "Empleado");
                RenombrarColumna("Posicion", "Posición");
                RenombrarColumna("Sueldobase", "Sueldo Base");
                RenombrarColumna("Asignacion", "Asignaciones");
                RenombrarColumna("Total", "Total");
                RenombrarColumna("FechaEfectividad", "Período");
                RenombrarColumna("FechaRegistro", "Registro");

                foreach (string col in new[] { "Sueldobase", "Asignacion", "Total" })
                    if (dgvVolantes.Columns.Contains(col))
                        dgvVolantes.Columns[col].DefaultCellStyle.Format = "N2";

                foreach (string col in new[] { "FechaEfectividad", "FechaRegistro" })
                    if (dgvVolantes.Columns.Contains(col))
                        dgvVolantes.Columns[col].DefaultCellStyle.Format = "dd/MM/yyyy";

                AgregarColumnaBoton("Ver Volante", ColorCyan, "btnVer", ColorBotonTexto);
                AgregarColumnaBoton("Editar", ColorEditar, "btnEditar", ColorTexto);
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
                Width = 100,
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
            using (FrmNuevoVolante frm = new FrmNuevoVolante())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    MostrarMensaje("Volante registrado correctamente.", true);
                    RefrescarGrid();
                }
            }
        }

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            pnlVistaVolante.Visible = false;
            dgvVolantes.Width = pnlTabla.Width;
            int idEmpleado = Convert.ToInt32(cmbFiltroEmpleado.SelectedValue ?? 0);
            RefrescarGrid(idEmpleado);
        }

        private void BtnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            cmbFiltroEmpleado.SelectedIndex = 0;
            pnlVistaVolante.Visible = false;
            dgvVolantes.Width = pnlTabla.Width;
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
                    ActualizarVistaVolante(row);
                    dgvVolantes.Width = pnlTabla.Width - pnlVistaVolante.Width - 10;
                    break;

                case "btnEditar":
                    int idEditar = Convert.ToInt32(row["Id"]);
                    using (FrmNuevoVolante frm = new FrmNuevoVolante(idEditar, row))
                    {
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            MostrarMensaje("Volante actualizado correctamente.", true);
                            pnlVistaVolante.Visible = false;
                            dgvVolantes.Width = pnlTabla.Width;
                            RefrescarGrid();
                        }
                    }
                    break;

                case "btnEliminar":
                    string emp = row["Empleado"].ToString();
                    string per = Convert.ToDateTime(row["FechaEfectividad"]).ToString("dd/MM/yyyy");
                    if (MessageBox.Show(
                            $"¿Eliminar el volante de \"{emp}\" del período {per}?",
                            "Confirmar eliminación",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        // TODO: implementar _cn.Eliminar(id) cuando esté disponible en la capa de negocio
                        MostrarMensaje("Funcionalidad de eliminación pendiente.", false);
                    }
                    break;
            }
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            if (!pnlVistaVolante.Visible)
            {
                MostrarMensaje("Selecciona primero un volante usando 'Ver Volante'.", false);
                return;
            }
            string contenido =
                "══════════════════════════════\n" +
                "       TALENTBUS DB3\n" +
                "      VOLANTE DE PAGO\n" +
                "══════════════════════════════\n" +
                $"Código:     {lblVCodigo.Text}\n" +
                $"Empleado:   {lblVEmpleado.Text}\n" +
                $"Posición:   {lblVPosicion.Text}\n" +
                $"Período:    {lblVFecha.Text}\n" +
                "──────────────────────────────\n" +
                "INGRESOS\n" +
                $"Sueldo Base:   {lblVSueldo.Text}\n" +
                $"Asignaciones:  {lblVAsignacion.Text}\n" +
                $"Subtotal:      {lblVTotalAsig.Text}\n" +
                "──────────────────────────────\n" +
                "DEDUCCIONES\n" +
                $"Total Ded.:    {lblVDeducciones.Text}\n" +
                "══════════════════════════════\n" +
                $"SALARIO NETO:  {lblVNeto.Text}\n" +
                "══════════════════════════════\n";

            MessageBox.Show(contenido, "Vista Previa — Volante de Pago",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ══════════════════════════════════════════════════════════════════
        //  VOLANTE VISUAL
        // ══════════════════════════════════════════════════════════════════
        private void ActualizarVistaVolante(DataRow row)
        {
            lblVCodigo.Text = row["CodigoEmpleado"].ToString();
            lblVEmpleado.Text = row["Empleado"].ToString();
            lblVPosicion.Text = row["Posicion"].ToString();
            lblVFecha.Text = Convert.ToDateTime(row["FechaEfectividad"]).ToString("dd/MM/yyyy");

            decimal sueldo = Convert.ToDecimal(row["Sueldobase"]);
            decimal asignacion = Convert.ToDecimal(row["Asignacion"]);
            decimal total = Convert.ToDecimal(row["Total"]);

            lblVSueldo.Text = sueldo.ToString("C2");
            lblVAsignacion.Text = asignacion.ToString("C2");
            lblVTotalAsig.Text = total.ToString("C2");

            try
            {
                int idEmp = row.Table.Columns.Contains("IdEmpleado") && row["IdEmpleado"] != DBNull.Value
                    ? Convert.ToInt32(row["IdEmpleado"])
                    : ObtenerIdEmpleadoPorCodigo(row["CodigoEmpleado"].ToString());

                DateTime fecha = Convert.ToDateTime(row["FechaEfectividad"]);
                DataTable dtComp = _cn.ObtenerVolanteCompleto(idEmp, fecha);

                if (dtComp.Rows.Count > 0)
                {
                    decimal ded = Convert.ToDecimal(dtComp.Rows[0]["TotalDeducciones"]);
                    decimal neto = Convert.ToDecimal(dtComp.Rows[0]["SalarioNeto"]);
                    lblVDeducciones.Text = ded.ToString("C2");
                    lblVNeto.Text = neto.ToString("C2");
                    lblVNeto.ForeColor = neto >= 0 ? ColorVerde : ColorEliminar;
                }
            }
            catch
            {
                lblVDeducciones.Text = "$0.00";
                lblVNeto.Text = total.ToString("C2");
                lblVNeto.ForeColor = ColorVerde;
            }

            pnlVistaVolante.Visible = true;
        }

        private int ObtenerIdEmpleadoPorCodigo(string codigo)
        {
            DataTable dt = _cnEmp.ObtenerTodos();
            foreach (DataRow r in dt.Rows)
                if (r["CodigoEmpleado"].ToString() == codigo)
                    return Convert.ToInt32(r["Id"]);
            return 0;
        }

        // ══════════════════════════════════════════════════════════════════
        //  HELPERS
        // ══════════════════════════════════════════════════════════════════
        private void RefrescarGrid(int idEmpleado = 0)
        {
            foreach (string col in new[] { "btnVer", "btnEditar", "btnEliminar" })
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

        private void DibujarEstrella(Graphics g, float cx, float cy,
                                     float radioExt, float radioInt,
                                     int puntas, Color color)
        {
            PointF[] pts = new PointF[puntas * 2];
            double angulo = -Math.PI / 2;
            double paso = Math.PI / puntas;
            for (int i = 0; i < puntas * 2; i++)
            {
                float r = (i % 2 == 0) ? radioExt : radioInt;
                pts[i] = new PointF(cx + r * (float)Math.Cos(angulo),
                                     cy + r * (float)Math.Sin(angulo));
                angulo += paso;
            }
            using (SolidBrush b = new SolidBrush(color))
                g.FillPolygon(b, pts);
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

        private void FrmVolantesPago_Load(object sender, EventArgs e) { }
    }
}
