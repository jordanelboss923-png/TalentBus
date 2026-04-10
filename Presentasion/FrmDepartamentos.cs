using Negocio.Configuracion;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmDepartamentos : Form
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
        private readonly Color ColorEditar = Color.FromArgb(255, 180, 0);

        // ─── Negocio ────────────────────────────────────────────────────────
        private readonly DepartamentosCN _cn = new DepartamentosCN();

        // ─── Estado ─────────────────────────────────────────────────────────
        private int _idSeleccionado = 0;
        private bool _modoEdicion = false;

        public FrmDepartamentos()
        {
            InitializeComponent();
            ConfigurarEventos();
            CargarDatos();
        }

        // ══════════════════════════════════════════════════════════════════
        //  CONFIGURACIÓN DE EVENTOS
        // ══════════════════════════════════════════════════════════════════
        private void ConfigurarEventos()
        {
            // Bordes de paneles
            pnlFormulario.Paint += PnlBorde_Paint;
            pnlNombre.Paint += PnlInput_Paint;

            // Botones
            btnNuevo.Click += BtnNuevo_Click;
            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar.Click += BtnCancelar_Click;

            // Posicionar btnNuevo siempre a la derecha del header
            pnlHeader.Resize += (s, e) =>
                btnNuevo.Left = pnlHeader.Width - btnNuevo.Width - 20;
            pnlHeader.HandleCreated += (s, e) =>
                btnNuevo.Left = pnlHeader.Width - btnNuevo.Width - 20;

            // Grid
            dgvDepartamentos.CellClick += Grid_CellClick;

            // Hover
            ConfigurarHover(btnNuevo, ColorBoton, Color.FromArgb(0, 185, 205));
            ConfigurarHover(btnGuardar, ColorBoton, Color.FromArgb(0, 185, 205));
            ConfigurarHover(btnCancelar, ColorInput, Color.FromArgb(35, 48, 85));

            // Regiones redondeadas
            foreach (Button btn in new[] { btnNuevo, btnGuardar, btnCancelar })
            {
                btn.Region = CrearRegionRedondeada(btn.Size, 6);
                btn.SizeChanged += (s, e) =>
                    ((Button)s).Region = CrearRegionRedondeada(((Button)s).Size, 6);
            }
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
        private void CargarDatos()
        {
            try
            {
                DataTable dt = _cn.ObtenerTodos();
                dgvDepartamentos.DataSource = null;
                dgvDepartamentos.DataSource = dt;

                if (dgvDepartamentos.Columns.Contains("Id"))
                    dgvDepartamentos.Columns["Id"].Visible = false;

                if (dgvDepartamentos.Columns.Contains("Nombre"))
                    dgvDepartamentos.Columns["Nombre"].HeaderText = "Nombre del Departamento";

                AgregarColumnaBoton("Editar", ColorEditar, "btnEditar");
                AgregarColumnaBoton("Eliminar", ColorEliminar, "btnEliminar");
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al cargar datos: " + ex.Message, false);
            }
        }

        private void AgregarColumnaBoton(string texto, Color color, string nombre)
        {
            if (dgvDepartamentos.Columns.Contains(nombre)) return;

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
            dgvDepartamentos.Columns.Add(col);
        }

        // ══════════════════════════════════════════════════════════════════
        //  EVENTOS DE BOTONES
        // ══════════════════════════════════════════════════════════════════
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            _modoEdicion = false;
            _idSeleccionado = 0;
            txtNombre.Clear();
            lblTituloFormulario.Text = "Nuevo Departamento";
            btnGuardar.Text = "Guardar";
            pnlFormulario.Visible = true;
            lblMensaje.Text = "";
            txtNombre.Focus();
            ActualizarPosicionGrid();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();

            try
            {
                (bool exito, string mensaje) resultado;

                if (_modoEdicion)
                    resultado = _cn.Actualizar(_idSeleccionado, nombre);
                else
                    resultado = _cn.Insertar(nombre);

                MostrarMensaje(resultado.mensaje, resultado.exito);

                if (resultado.exito)
                {
                    OcultarFormulario();
                    RefrescarGrid();
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error: " + ex.Message, false);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            OcultarFormulario();
            lblMensaje.Text = "";
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dgvDepartamentos.Rows[e.RowIndex].Cells["Id"].Value);

            if (dgvDepartamentos.Columns[e.ColumnIndex].Name == "btnEditar")
            {
                string nombre = dgvDepartamentos.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                _idSeleccionado = id;
                _modoEdicion = true;
                txtNombre.Text = nombre;
                lblTituloFormulario.Text = "Editar Departamento";
                btnGuardar.Text = "Actualizar";
                pnlFormulario.Visible = true;
                lblMensaje.Text = "";
                txtNombre.Focus();
                ActualizarPosicionGrid();
            }
            else if (dgvDepartamentos.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                string nombre = dgvDepartamentos.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();

                if (MessageBox.Show(
                        $"¿Eliminar el departamento \"{nombre}\"?",
                        "Confirmar eliminación",
                        MessageBoxButtons.YesNo,
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

        // ══════════════════════════════════════════════════════════════════
        //  HELPERS
        // ══════════════════════════════════════════════════════════════════
        private void OcultarFormulario()
        {
            pnlFormulario.Visible = false;
            _modoEdicion = false;
            _idSeleccionado = 0;
            txtNombre.Clear();
            ActualizarPosicionGrid();
        }

        private void RefrescarGrid()
        {
            foreach (string col in new[] { "btnEditar", "btnEliminar" })
                if (dgvDepartamentos.Columns.Contains(col))
                    dgvDepartamentos.Columns.Remove(col);
            CargarDatos();
        }

        private void ActualizarPosicionGrid()
        {
            if (pnlFormulario.Visible)
            {
                lblMensaje.Location = new Point(lblMensaje.Left, 210);
                dgvDepartamentos.Location = new Point(dgvDepartamentos.Left, 240);
            }
            else
            {
                lblMensaje.Location = new Point(lblMensaje.Left, 80);
                dgvDepartamentos.Location = new Point(dgvDepartamentos.Left, 110);
            }
        }

        private void MostrarMensaje(string texto, bool exito)
        {
            lblMensaje.Text = exito ? "✓  " + texto : "✗  " + texto;
            lblMensaje.ForeColor = exito
                ? Color.FromArgb(39, 201, 63)
                : Color.FromArgb(255, 80, 80);
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

        private void PnlInput_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = (Panel)sender;
            using (Pen p = new Pen(ColorBorde, 1))
                e.Graphics.DrawRectangle(p, 0, 0, pnl.Width - 1, pnl.Height - 1);
        }

        private void FrmDepartamentos_Load(object sender, EventArgs e) { }
    }
}