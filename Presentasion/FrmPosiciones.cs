using Negocio.Configuracion;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmPosiciones : Form
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
        private readonly PosicionesCN _cnPos = new PosicionesCN();
        private readonly DepartamentosCN _cnDep = new DepartamentosCN();

        // ─── Estado ───
        private int _idSeleccionado = 0;
        private bool _modoEdicion = false;

        // ─── Controles ───
        private DataGridView _grid;
        private TextBox _txtNombre;
        private TextBox _txtSalario;
        private ComboBox _cmbDepartamento;
        private Label _lblTitulo;
        private Button _btnGuardar;
        private Button _btnCancelar;
        private Button _btnNuevo;
        private Label _lblMensaje;
        private Panel _pnlFormulario;

        public FrmPosiciones()
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
                Text = "Posiciones",
                ForeColor = ColorTexto,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(30, 15),
                Parent = pnlHeader
            };

            new Label
            {
                Text = "Gestión de posiciones y salarios",
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
                Size = new Size(this.Width - 60, 160),
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
                Text = "Nueva Posición",
                ForeColor = ColorCyan,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 15)
            };
            _pnlFormulario.Controls.Add(_lblTitulo);

            // ── Fila 1: Nombre ────────────────────
            AgregarLabel(_pnlFormulario, "Nombre", 20, 45);
            Panel pnlNombre = CrearPanelInput(20, 65, 260, out _txtNombre);
            _pnlFormulario.Controls.Add(pnlNombre);

            // ── Fila 1: Salario ───────────────────
            AgregarLabel(_pnlFormulario, "Salario (RD$)", 300, 45);
            Panel pnlSalario = CrearPanelInput(300, 65, 180, out _txtSalario);
            _pnlFormulario.Controls.Add(pnlSalario);

            // ── Fila 1: Departamento ──────────────
            AgregarLabel(_pnlFormulario, "Departamento", 500, 45);
            _cmbDepartamento = CrearComboBox(500, 65, 220);
            CargarDepartamentosCombo();
            _pnlFormulario.Controls.Add(_cmbDepartamento);

            // ── Botones ───────────────────────────
            _btnGuardar = CrearBoton("Guardar", ColorBoton, ColorBotonTexto);
            _btnGuardar.Size = new Size(100, 34);
            _btnGuardar.Location = new Point(20, 110);
            _btnGuardar.Click += BtnGuardar_Click;
            _pnlFormulario.Controls.Add(_btnGuardar);

            _btnCancelar = CrearBoton("Cancelar", ColorInput, ColorSubTexto);
            _btnCancelar.Size = new Size(100, 34);
            _btnCancelar.Location = new Point(130, 110);
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
                DataTable dt = _cnPos.ObtenerTodos();
                _grid.DataSource = null;
                _grid.DataSource = dt;

                if (_grid.Columns.Contains("Id"))
                    _grid.Columns["Id"].Visible = false;

                if (_grid.Columns.Contains("IdDepartamento"))
                    _grid.Columns["IdDepartamento"].Visible = false;

                if (_grid.Columns.Contains("Nombre"))
                    _grid.Columns["Nombre"].HeaderText = "Posición";

                if (_grid.Columns.Contains("Salario"))
                {
                    _grid.Columns["Salario"].HeaderText = "Salario (RD$)";
                    _grid.Columns["Salario"].DefaultCellStyle.Format = "N2";
                }

                if (_grid.Columns.Contains("NombreDepartamento"))
                    _grid.Columns["NombreDepartamento"].HeaderText = "Departamento";

                AgregarColumnaBoton("Editar", ColorEditar, "btnEditar");
                AgregarColumnaBoton("Eliminar", ColorEliminar, "btnEliminar");
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al cargar datos: " + ex.Message, false);
            }
        }

        private void CargarDepartamentosCombo()
        {
            try
            {
                DataTable dt = _cnDep.ObtenerTodos();
                _cmbDepartamento.DataSource = dt;
                _cmbDepartamento.DisplayMember = "Nombre";
                _cmbDepartamento.ValueMember = "Id";
                _cmbDepartamento.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al cargar departamentos: " + ex.Message, false);
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
            _lblTitulo.Text = "Nueva Posición";
            _btnGuardar.Text = "Guardar";
            _pnlFormulario.Visible = true;
            _lblMensaje.Text = "";
            _txtNombre.Focus();
            ActualizarPosicionGrid();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = _txtNombre.Text.Trim();
            string salarioStr = _txtSalario.Text.Trim();

            if (_cmbDepartamento.SelectedValue == null)
            {
                MostrarMensaje("Selecciona un departamento.", false);
                return;
            }

            if (!decimal.TryParse(salarioStr, out decimal salario))
            {
                MostrarMensaje("El salario debe ser un número válido.", false);
                return;
            }

            int idDep = Convert.ToInt32(_cmbDepartamento.SelectedValue);

            try
            {
                (bool exito, string mensaje) resultado;

                if (_modoEdicion)
                    resultado = _cnPos.Actualizar(_idSeleccionado, nombre,
                                                  salario, idDep);
                else
                    resultado = _cnPos.Insertar(nombre, salario, idDep);

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
                DataTable dt = _cnPos.ObtenerPorId(id);
                if (dt.Rows.Count == 0) return;

                DataRow row = dt.Rows[0];
                _idSeleccionado = id;
                _modoEdicion = true;
                _txtNombre.Text = row["Nombre"].ToString();
                _txtSalario.Text = row["Salario"].ToString();
                _cmbDepartamento.SelectedValue = Convert.ToInt32(row["IdDepartamento"]);
                _lblTitulo.Text = "Editar Posición";
                _btnGuardar.Text = "Actualizar";
                _pnlFormulario.Visible = true;
                _lblMensaje.Text = "";
                _txtNombre.Focus();
                ActualizarPosicionGrid();
            }
            else if (_grid.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                string nombre = _grid.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();

                if (MessageBox.Show($"¿Eliminar la posición \"{nombre}\"?",
                    "Confirmar", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        var resultado = _cnPos.Eliminar(id);
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
            _txtSalario.Clear();
            _cmbDepartamento.SelectedIndex = -1;
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
                _lblMensaje.Location = new Point(30, 240);
                _grid.Location = new Point(30, 270);
                _grid.Size = new Size(this.Width - 60, this.Height - 290);
            }
            else
            {
                _lblMensaje.Location = new Point(30, 80);
                _grid.Location = new Point(30, 110);
                _grid.Size = new Size(this.Width - 60, this.Height - 130);
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
            pnl.Paint += (s, e) =>
            {
                using (Pen p = new Pen(ColorBorde, 1))
                    e.Graphics.DrawRectangle(p, 0, 0,
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

        private ComboBox CrearComboBox(int x, int y, int ancho)
        {
            ComboBox cmb = new ComboBox
            {
                Size = new Size(ancho, 36),
                Location = new Point(x, y),
                BackColor = ColorInput,
                ForeColor = ColorTexto,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            return cmb;
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
            path.AddArc(0, size.Height - radio * 2, radio * 2, radio * 2, 90, 90);
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
