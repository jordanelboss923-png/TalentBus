using Negocio.Asistencia;
using Negocios;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmAsistencias : Form
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
        private readonly Color ColorAmarillo = Color.FromArgb(255, 180, 0);
        private readonly Color ColorNaranja = Color.FromArgb(255, 120, 0);

        // ─── Negocio ────────────────────────────────────────────────────────
        private readonly AsistenciasCN _cn = new AsistenciasCN();
        private readonly EmpleadosCN _cnEmp = new EmpleadosCN();

        public FrmAsistencias()
        {
            InitializeComponent();
            ConfigurarEventos();
            CargarEmpleadosCombo();
            CargarDatos();
        }

        // ══════════════════════════════════════════════════════════════════
        //  CONFIGURACIÓN DE EVENTOS
        // ══════════════════════════════════════════════════════════════════
        private void ConfigurarEventos()
        {
            // Bordes de paneles
            pnlFormulario.Paint += PnlBorde_Paint;
            ConfigurarTarjeta(cardEntrada, ColorVerde, EstadoRegistrado.Entrada);
            ConfigurarTarjeta(cardAlmuerzo, ColorAmarillo, EstadoRegistrado.Almuerzo);
            ConfigurarTarjeta(cardRetorno, ColorNaranja, EstadoRegistrado.RetornoDeAlmuerzo);
            ConfigurarTarjeta(cardSalida, ColorEliminar, EstadoRegistrado.Salida);

            // Pintar acento superior de cada tarjeta
            cardEntrada.Paint += (s, e) => PintarTarjeta(e, (Panel)s, ColorVerde);
            cardAlmuerzo.Paint += (s, e) => PintarTarjeta(e, (Panel)s, ColorAmarillo);
            cardRetorno.Paint += (s, e) => PintarTarjeta(e, (Panel)s, ColorNaranja);
            cardSalida.Paint += (s, e) => PintarTarjeta(e, (Panel)s, ColorEliminar);

            // Botones
            btnRegistrar.Click += BtnRegistrar_Click;

            // Hover botón registrar
            btnRegistrar.MouseEnter += (s, e) => btnRegistrar.BackColor = Color.FromArgb(0, 185, 205);
            btnRegistrar.MouseLeave += (s, e) => btnRegistrar.BackColor = ColorBoton;
            btnRegistrar.Region = CrearRegionRedondeada(btnRegistrar.Size, 6);
            btnRegistrar.SizeChanged += (s, e) =>
                btnRegistrar.Region = CrearRegionRedondeada(btnRegistrar.Size, 6);

            // Grid
            dgvAsistencias.CellClick += Grid_CellClick;
            dgvAsistencias.CellFormatting += Grid_CellFormatting;

            // DrawMode del combo empleado
            cmbEmpleado.DrawMode = DrawMode.OwnerDrawFixed;
            cmbEmpleado.DrawItem += CmbEmpleado_DrawItem;
        }

        private void ConfigurarTarjeta(Panel card, Color colorAcento, EstadoRegistrado tipo)
        {
            card.Tag = tipo;
            card.Cursor = Cursors.Hand;
            card.MouseEnter += (s, e) => card.BackColor = Color.FromArgb(22, 32, 60);
            card.MouseLeave += (s, e) => card.BackColor = ColorPanel;
            card.Click += (s, e) => RegistrarMarcacionRapida((EstadoRegistrado)card.Tag);

            // Propagar click a los labels internos
            foreach (System.Windows.Forms.Control ctrl in card.Controls)
                ctrl.Click += (s, e) => RegistrarMarcacionRapida((EstadoRegistrado)card.Tag);
        }

        private void PintarTarjeta(PaintEventArgs e, Panel card, Color colorAcento)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (SolidBrush b = new SolidBrush(colorAcento))
                e.Graphics.FillRectangle(b, 0, 0, card.Width, 4);
            using (Pen p = new Pen(ColorBorde, 1))
                e.Graphics.DrawRectangle(p, 0, 0, card.Width - 1, card.Height - 1);
        }

        private void CmbEmpleado_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            e.DrawBackground();
            DataRowView row = (DataRowView)cmbEmpleado.Items[e.Index];
            string display = $"{row["CodigoEmpleado"]} — {row["Nombre"]} {row["Apellido"]}";
            using (SolidBrush b = new SolidBrush(ColorTexto))
                e.Graphics.DrawString(display, new Font("Segoe UI", 9), b, e.Bounds);
        }

        // ══════════════════════════════════════════════════════════════════
        //  CARGA DE DATOS
        // ══════════════════════════════════════════════════════════════════
        private void CargarEmpleadosCombo()
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
                MostrarMensaje("Error al cargar empleados: " + ex.Message, false);
            }
        }

        private void CargarDatos()
        {
            try
            {
                DataTable dt = _cn.ObtenerTodos();
                dgvAsistencias.DataSource = null;
                dgvAsistencias.DataSource = dt;

                if (dgvAsistencias.Columns.Contains("Id"))
                    dgvAsistencias.Columns["Id"].Visible = false;
                if (dgvAsistencias.Columns.Contains("IdEmpleado"))
                    dgvAsistencias.Columns["IdEmpleado"].Visible = false;

                RenombrarColumna("NombreEmpleado", "Empleado");
                RenombrarColumna("Descripcion", "Marcación");
                RenombrarColumna("FechaHora", "Fecha y Hora");

                if (dgvAsistencias.Columns.Contains("FechaHora"))
                    dgvAsistencias.Columns["FechaHora"].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt";

                AgregarColumnaBoton("Eliminar", ColorEliminar, "btnEliminar");
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al cargar asistencias: " + ex.Message, false);
            }
        }

        private void AgregarColumnaBoton(string texto, Color color, string nombre)
        {
            if (dgvAsistencias.Columns.Contains(nombre)) return;

            DataGridViewButtonColumn col = new DataGridViewButtonColumn
            {
                Name = nombre,
                HeaderText = "",
                Text = texto,
                UseColumnTextForButtonValue = true,
                Width = 90,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                FlatStyle = FlatStyle.Flat
            };
            col.DefaultCellStyle.BackColor = color;
            col.DefaultCellStyle.ForeColor = ColorBotonTexto;
            col.DefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            col.DefaultCellStyle.SelectionBackColor = color;
            col.DefaultCellStyle.SelectionForeColor = ColorBotonTexto;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAsistencias.Columns.Add(col);
        }

        // ══════════════════════════════════════════════════════════════════
        //  EVENTOS
        // ══════════════════════════════════════════════════════════════════
        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if (cmbEmpleado.SelectedValue == null)
            {
                MostrarMensaje("Selecciona un empleado.", false);
                return;
            }
            int idEmpleado = Convert.ToInt32(cmbEmpleado.SelectedValue);
            EstadoRegistrado tipo = ObtenerTipoSeleccionado();
            EjecutarMarcacion(idEmpleado, tipo);
        }

        private void RegistrarMarcacionRapida(EstadoRegistrado tipo)
        {
            if (cmbEmpleado.SelectedValue == null)
            {
                MostrarMensaje("Selecciona un empleado primero.", false);
                return;
            }
            int idEmpleado = Convert.ToInt32(cmbEmpleado.SelectedValue);
            cmbTipo.SelectedIndex = (int)tipo;
            EjecutarMarcacion(idEmpleado, tipo);
        }

        private void EjecutarMarcacion(int idEmpleado, EstadoRegistrado tipo)
        {
            try
            {
                var resultado = _cn.RegistrarMarcacion(idEmpleado, tipo);
                MostrarMensaje(resultado.mensaje, resultado.exito);
                if (resultado.exito) RefrescarGrid();
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error: " + ex.Message, false);
            }
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvAsistencias.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                int id = Convert.ToInt32(dgvAsistencias.Rows[e.RowIndex].Cells["Id"].Value);
                string emp = dgvAsistencias.Rows[e.RowIndex].Cells["NombreEmpleado"].Value.ToString();
                string tipo = dgvAsistencias.Rows[e.RowIndex].Cells["Descripcion"].Value.ToString();

                if (MessageBox.Show(
                        $"¿Eliminar la marcación \"{tipo}\" de {emp}?",
                        "Confirmar", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        var resultado = _cn.Eliminar(id);
                        MostrarMensaje(resultado.mensaje, resultado.exito);
                        if (resultado.exito) RefrescarGrid();
                    }
                    catch (Exception ex)
                    {
                        MostrarMensaje("Error: " + ex.Message, false);
                    }
                }
            }
        }

        private void Grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvAsistencias.Columns[e.ColumnIndex].Name != "Descripcion" || e.Value == null)
                return;

            string val = e.Value.ToString();
            if (val == "Entrada") e.CellStyle.ForeColor = ColorVerde;
            else if (val == "Salida") e.CellStyle.ForeColor = ColorEliminar;
            else if (val == "Almuerzo") e.CellStyle.ForeColor = ColorAmarillo;
            else if (val == "Retorno de Almuerzo") e.CellStyle.ForeColor = ColorNaranja;
            else e.CellStyle.ForeColor = ColorTexto;
            e.FormattingApplied = true;
        }

        // ══════════════════════════════════════════════════════════════════
        //  HELPERS
        // ══════════════════════════════════════════════════════════════════
        private EstadoRegistrado ObtenerTipoSeleccionado()
        {
            switch (cmbTipo.SelectedIndex)
            {
                case 0: return EstadoRegistrado.Entrada;
                case 1: return EstadoRegistrado.Salida;
                case 2: return EstadoRegistrado.Almuerzo;
                case 3: return EstadoRegistrado.RetornoDeAlmuerzo;
                default: return EstadoRegistrado.Entrada;
            }
        }

        private void RefrescarGrid()
        {
            if (dgvAsistencias.Columns.Contains("btnEliminar"))
                dgvAsistencias.Columns.Remove("btnEliminar");
            CargarDatos();
        }

        private void MostrarMensaje(string texto, bool exito)
        {
            lblMensaje.Text = exito ? "✓  " + texto : "✗  " + texto;
            lblMensaje.ForeColor = exito ? ColorVerde : ColorEliminar;
        }

        private void RenombrarColumna(string nombre, string encabezado)
        {
            if (dgvAsistencias.Columns.Contains(nombre))
                dgvAsistencias.Columns[nombre].HeaderText = encabezado;
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

        private void FrmAsistencias_Load(object sender, EventArgs e) { }
    }
}