using Negocio.Servicios;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmDeducciones : Form
    {
        // ─── Colores del tema ───
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

        // ─── Negocio ───
        private readonly DeduccionesCN _cn = new DeduccionesCN();

        // ─── Estado ───
        private int _idSeleccionado = 0;
        private bool _modoEdicion = false;

        // ─── Controles ───
        private DataGridView _grid;
        private TextBox _txtNombre;
        private TextBox _txtPorcentaje;
        private TextBox _txtDescripcion;
        private Label _lblTitulo;
        private Button _btnGuardar;
        private Button _btnCancelar;
        private Button _btnNuevo;
        private Label _lblMensaje;
        private Panel _pnlFormulario;

        public FrmDeducciones()
        {
            InitializeComponent();
            ConfigurarFormulario();
            ConstruirUI();
            CargarDatos();
        }

        // ════════════════════════════════════════
        //  CONFIGURACIÓN
        // ════════════════════════════════════════
        private void ConfigurarFormulario()
        {
            this.BackColor = ColorFondo;
            this.DoubleBuffered = true;
        }

        // ════════════════════════════════════════
        //  CONSTRUCCIÓN UI
        // ════════════════════════════════════════
        private void ConstruirUI()
        {
            // ── Encabezado ────────────────────────
            Panel pnlHeader = new Panel
            {
                Size = new Size(this.Width, 60),
                Location = new Point(0, 0),
                BackColor = Color.Transparent
            };
            this.Controls.Add(pnlHeader);

            new Label
            {
                Text = "Deducciones",
                ForeColor = ColorTexto,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(30, 15),
                Parent = pnlHeader
            };

            new Label
            {
                Text = "Gestión de deducciones aplicadas a la nómina",
                ForeColor = ColorSubTexto,
                Font = new Font("Segoe UI", 9),
                AutoSize = true,
                Location = new Point(32, 42),
                Parent = pnlHeader
            };

            _btnNuevo = CrearBoton("+ Nueva", ColorBoton, ColorBotonTexto);
            _btnNuevo.Size = new Size(110, 34);
            _btnNuevo.Location = new Point(this.Width - 160, 18);
            _btnNuevo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnNuevo.Click += BtnNuevo_Click;
            pnlHeader.Controls.Add(_btnNuevo);

            // ── Panel formulario ──────────────────
            _pnlFormulario = new Panel
            {
                Size = new Size(this.Width - 60, 190),
                Location = new Point(30, 70),
                BackColor = ColorPanel,
                Visible = false
            };
            _pnlFormulario.Paint += PnlBorde_Paint;
            this.Controls.Add(_pnlFormulario);
            ConstruirFormulario();

            // ── Mensaje ───────────────────────────
            _lblMensaje = new Label
            {
                Text = "",
                ForeColor = ColorCyan,
                Font = new Font("Segoe UI", 9),
                AutoSize = false,
                Size = new Size(this.Width - 60, 24),
                Location = new Point(30, 80),
                TextAlign = ContentAlignment.MiddleLeft
            };
            this.Controls.Add(_lblMensaje);

            // ── Grid ──────────────────────────────
            _grid = new DataGridView
            {
                Size = new Size(this.Width - 60, this.Height - 130),
                Location = new Point(30, 110),
                BackgroundColor = ColorPanel,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                Font = new Font("Segoe UI", 9),
                Anchor = AnchorStyles.Top | AnchorStyles.Left |
                                        AnchorStyles.Right | AnchorStyles.Bottom
            };
            EstilarGrid(_grid);
            _grid.CellClick += Grid_CellClick;
            this.Controls.Add(_grid);
        }

        private void ConstruirFormulario()
        {
            _lblTitulo = new Label
            {
                Text = "Nueva Deducción",
                ForeColor = ColorCyan,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 15)
            };
            _pnlFormulario.Controls.Add(_lblTitulo);

            // ── Fila 1 ────────────────────────────
            AgregarLabel(_pnlFormulario, "Nombre", 20, 45);
            Panel pnlNombre = CrearPanelInput(20, 65, 280, out _txtNombre);
            _pnlFormulario.Controls.Add(pnlNombre);

            AgregarLabel(_pnlFormulario, "Porcentaje (%)", 320, 45);
            Panel pnlPorc = CrearPanelInput(320, 65, 160, out _txtPorcentaje);
            _pnlFormulario.Controls.Add(pnlPorc);

            // ── Fila 2: Descripción ───────────────
            AgregarLabel(_pnlFormulario, "Descripción (opcional)", 20, 112);
            Panel pnlDesc = CrearPanelInput(20, 132, 460, out _txtDescripcion);
            _pnlFormulario.Controls.Add(pnlDesc);

            // ── Botones ───────────────────────────
            _btnGuardar = CrearBoton("Guardar", ColorBoton, ColorBotonTexto);
            _btnGuardar.Size = new Size(100, 34);
            _btnGuardar.Location = new Point(500, 132);
            _btnGuardar.Click += BtnGuardar_Click;
            _pnlFormulario.Controls.Add(_btnGuardar);

            _btnCancelar = CrearBoton("Cancelar", ColorInput, ColorSubTexto);
            _btnCancelar.Size = new Size(100, 34);
            _btnCancelar.Location = new Point(610, 132);
            _btnCancelar.Click += BtnCancelar_Click;
            _pnlFormulario.Controls.Add(_btnCancelar);
        }

        // ════════════════════════════════════════
        //  DATOS
        // ════════════════════════════════════════
        private void CargarDatos()
        {
            try
            {
                DataTable dt = _cn.ObtenerTodos();
                _grid.DataSource = null;
                _grid.DataSource = dt;

                if (_grid.Columns.Contains("Id"))
                    _grid.Columns["Id"].Visible = false;

                if (_grid.Columns.Contains("Nombre"))
                    _grid.Columns["Nombre"].HeaderText = "Nombre";

                if (_grid.Columns.Contains("Porcentaje"))
                {
                    _grid.Columns["Porcentaje"].HeaderText = "Porcentaje (%)";
                    _grid.Columns["Porcentaje"].DefaultCellStyle.Format = "N2";
                }

                if (_grid.Columns.Contains("Descripcion"))
                    _grid.Columns["Descripcion"].HeaderText = "Descripción";

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
            if (_grid.Columns.Contains(nombre)) return;

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
            _grid.Columns.Add(col);
        }

        // ════════════════════════════════════════
        //  EVENTOS
        // ════════════════════════════════════════
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            _modoEdicion = false;
            _idSeleccionado = 0;
            LimpiarFormulario();
            _lblTitulo.Text = "Nueva Deducción";
            _btnGuardar.Text = "Guardar";
            _pnlFormulario.Visible = true;
            _lblMensaje.Text = "";
            _txtNombre.Focus();
            ActualizarPosicionGrid();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = _txtNombre.Text.Trim();
            string porcStr = _txtPorcentaje.Text.Trim();
            string descripcion = _txtDescripcion.Text.Trim();

            if (!decimal.TryParse(porcStr, out decimal porcentaje))
            {
                MostrarMensaje("El porcentaje debe ser un número válido (ej: 5.50).", false);
                return;
            }

            try
            {
                (bool exito, string mensaje) resultado;

                if (_modoEdicion)
                    resultado = _cn.Actualizar(_idSeleccionado, nombre,
                                               porcentaje,
                                               string.IsNullOrEmpty(descripcion)
                                                   ? null : descripcion);
                else
                    resultado = _cn.Insertar(nombre, porcentaje,
                                             string.IsNullOrEmpty(descripcion)
                                                 ? null : descripcion);

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
            _lblMensaje.Text = "";
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(_grid.Rows[e.RowIndex].Cells["Id"].Value);

            if (_grid.Columns[e.ColumnIndex].Name == "btnEditar")
            {
                DataTable dt = _cn.ObtenerPorId(id);
                if (dt.Rows.Count == 0) return;

                DataRow row = dt.Rows[0];
                _idSeleccionado = id;
                _modoEdicion = true;
                _txtNombre.Text = row["Nombre"].ToString();
                _txtPorcentaje.Text = row["Porcentaje"].ToString();
                _txtDescripcion.Text = row["Descripcion"] == DBNull.Value
                                            ? "" : row["Descripcion"].ToString();
                _lblTitulo.Text = "Editar Deducción";
                _btnGuardar.Text = "Actualizar";
                _pnlFormulario.Visible = true;
                _lblMensaje.Text = "";
                _txtNombre.Focus();
                ActualizarPosicionGrid();
            }
            else if (_grid.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                string nombre = _grid.Rows[e.RowIndex]
                                     .Cells["Nombre"].Value.ToString();

                if (MessageBox.Show($"¿Eliminar la deducción \"{nombre}\"?",
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

        // ════════════════════════════════════════
        //  HELPERS
        // ════════════════════════════════════════
        private void OcultarFormulario()
        {
            _pnlFormulario.Visible = false;
            _modoEdicion = false;
            _idSeleccionado = 0;
            LimpiarFormulario();
            ActualizarPosicionGrid();
        }

        private void LimpiarFormulario()
        {
            _txtNombre.Clear();
            _txtPorcentaje.Clear();
            _txtDescripcion.Clear();
        }

        private void RefrescarGrid()
        {
            if (_grid.Columns.Contains("btnEditar"))
                _grid.Columns.Remove("btnEditar");
            if (_grid.Columns.Contains("btnEliminar"))
                _grid.Columns.Remove("btnEliminar");
            CargarDatos();
        }

        private void ActualizarPosicionGrid()
        {
            if (_pnlFormulario.Visible)
            {
                _lblMensaje.Location = new Point(30, 270);
                _grid.Location = new Point(30, 300);
                _grid.Size = new Size(this.Width - 60,
                                               this.Height - 320);
            }
            else
            {
                _lblMensaje.Location = new Point(30, 80);
                _grid.Location = new Point(30, 110);
                _grid.Size = new Size(this.Width - 60,
                                               this.Height - 130);
            }
        }

        private void MostrarMensaje(string texto, bool exito)
        {
            _lblMensaje.Text = exito ? "✓  " + texto : "✗  " + texto;
            _lblMensaje.ForeColor = exito
                ? Color.FromArgb(39, 201, 63)
                : Color.FromArgb(255, 80, 80);
        }

        private void AgregarLabel(Panel parent, string texto, int x, int y)
        {
            parent.Controls.Add(new Label
            {
                Text = texto,
                ForeColor = ColorTexto,
                Font = new Font("Segoe UI", 9),
                AutoSize = true,
                Location = new Point(x, y)
            });
        }

        private Panel CrearPanelInput(int x, int y, int ancho, out TextBox txt)
        {
            Panel pnl = new Panel
            {
                Size = new Size(ancho, 36),
                Location = new Point(x, y),
                BackColor = ColorInput
            };
            pnl.Paint += (s, ev) =>
            {
                using (Pen p = new Pen(ColorBorde, 1))
                    ev.Graphics.DrawRectangle(p, 0, 0,
                                              pnl.Width - 1, pnl.Height - 1);
            };

            txt = new TextBox
            {
                Size = new Size(ancho - 20, 24),
                Location = new Point(10, 6),
                BackColor = ColorInput,
                ForeColor = ColorTexto,
                BorderStyle = BorderStyle.None,
                Font = new Font("Segoe UI", 10)
            };
            pnl.Controls.Add(txt);
            return pnl;
        }

        private Button CrearBoton(string texto, Color fondo, Color fuente)
        {
            Button btn = new Button
            {
                Text = texto,
                FlatStyle = FlatStyle.Flat,
                BackColor = fondo,
                ForeColor = fuente,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.Region = CrearRegionRedondeada(btn.Size, 6);
            btn.SizeChanged += (s, e) =>
                btn.Region = CrearRegionRedondeada(btn.Size, 6);
            return btn;
        }

        private Region CrearRegionRedondeada(Size size, int radio)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radio * 2, radio * 2, 180, 90);
            path.AddArc(size.Width - radio * 2, 0, radio * 2, radio * 2, 270, 90);
            path.AddArc(size.Width - radio * 2,
                        size.Height - radio * 2, radio * 2, radio * 2, 0, 90);
            path.AddArc(0, size.Height - radio * 2,
                        radio * 2, radio * 2, 90, 90);
            path.CloseAllFigures();
            return new Region(path);
        }

        private void EstilarGrid(DataGridView grid)
        {
            grid.DefaultCellStyle.BackColor = ColorPanel;
            grid.DefaultCellStyle.ForeColor = ColorTexto;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(25, 35, 70);
            grid.DefaultCellStyle.SelectionForeColor = ColorCyan;
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            grid.DefaultCellStyle.Padding = new Padding(4, 0, 4, 0);

            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 28, 58);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = ColorSubTexto;
            grid.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 8, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                Color.FromArgb(20, 28, 58);

            grid.ColumnHeadersHeight = 36;
            grid.RowTemplate.Height = 40;
            grid.GridColor = ColorBorde;
            grid.EnableHeadersVisualStyles = false;

            grid.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(20, 28, 55);
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
                path.AddArc(pnl.Width - r * 2, pnl.Height - r * 2,
                            r * 2, r * 2, 0, 90);
                path.AddArc(0, pnl.Height - r * 2, r * 2, r * 2, 90, 90);
                path.CloseAllFigures();
                e.Graphics.DrawPath(p, path);
            }
        }
    }
}
