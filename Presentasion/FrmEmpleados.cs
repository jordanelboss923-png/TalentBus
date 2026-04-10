using Negocio.Configuracion;
using Negocios;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmEmpleados : Form
    {
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

        private readonly EmpleadosCN _cnEmp = new EmpleadosCN();
        private readonly PosicionesCN _cnPos = new PosicionesCN();

        private int _idSeleccionado = 0;
        private bool _modoEdicion = false;

        private DataGridView _grid;
        private TextBox _txtCodigo, _txtNombre, _txtApellido, _txtCedula;
        private ComboBox _cmbPosicion, _cmbTipo;
        private Label _lblTitulo;
        private Button _btnGuardar, _btnCancelar, _btnNuevo;
        private Label _lblMensaje;
        private Panel _pnlFormulario;

        public FrmEmpleados()
        {
            InitializeComponent();
            this.BackColor = ColorFondo;
            this.DoubleBuffered = true;
            ConstruirUI();
            CargarDatos();
        }

        // ════════════════════════════════════════
        //  CONSTRUCCIÓN UI
        // ════════════════════════════════════════
        private void ConstruirUI()
        {
            Panel pnlHeader = new Panel { Size = new Size(this.Width, 60), Location = new Point(0, 0), BackColor = Color.Transparent };
            this.Controls.Add(pnlHeader);

            new Label { Text = "Empleados", ForeColor = ColorTexto, Font = new Font("Segoe UI", 16, FontStyle.Bold), AutoSize = true, Location = new Point(30, 15), Parent = pnlHeader };
            new Label { Text = "Gestión del personal de la empresa", ForeColor = ColorSubTexto, Font = new Font("Segoe UI", 9), AutoSize = true, Location = new Point(32, 42), Parent = pnlHeader };

            _btnNuevo = CrearBoton("+ Nuevo", ColorBoton, ColorBotonTexto);
            _btnNuevo.Size = new Size(110, 34);
            _btnNuevo.Location = new Point(this.Width - 160, 18);
            _btnNuevo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnNuevo.Click += BtnNuevo_Click;
            pnlHeader.Controls.Add(_btnNuevo);

            _pnlFormulario = new Panel { Size = new Size(this.Width - 60, 230), Location = new Point(30, 70), BackColor = ColorPanel, Visible = false };
            _pnlFormulario.Paint += PnlBorde_Paint;
            this.Controls.Add(_pnlFormulario);
            ConstruirFormulario();

            _lblMensaje = new Label { Text = "", ForeColor = ColorCyan, Font = new Font("Segoe UI", 9), AutoSize = false, Size = new Size(this.Width - 60, 24), Location = new Point(30, 80), TextAlign = ContentAlignment.MiddleLeft };
            this.Controls.Add(_lblMensaje);

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
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom
            };
            EstilarGrid(_grid);
            _grid.CellClick += Grid_CellClick;
            this.Controls.Add(_grid);
        }

        private void ConstruirFormulario()
        {
            _lblTitulo = new Label { Text = "Nuevo Empleado", ForeColor = ColorCyan, Font = new Font("Segoe UI", 10, FontStyle.Bold), AutoSize = true, Location = new Point(20, 15) };
            _pnlFormulario.Controls.Add(_lblTitulo);

            AgregarLabel(_pnlFormulario, "Código Empleado", 20, 45);
            _pnlFormulario.Controls.Add(CrearPanelInput(20, 65, 150, out _txtCodigo));

            AgregarLabel(_pnlFormulario, "Nombre", 185, 45);
            _pnlFormulario.Controls.Add(CrearPanelInput(185, 65, 200, out _txtNombre));

            AgregarLabel(_pnlFormulario, "Apellido", 400, 45);
            _pnlFormulario.Controls.Add(CrearPanelInput(400, 65, 200, out _txtApellido));

            AgregarLabel(_pnlFormulario, "Cédula", 20, 115);
            _pnlFormulario.Controls.Add(CrearPanelInput(20, 135, 190, out _txtCedula));

            AgregarLabel(_pnlFormulario, "Posición", 225, 115);
            _cmbPosicion = CrearComboBox(225, 135, 240);
            CargarPosicionesCombo();
            _pnlFormulario.Controls.Add(_cmbPosicion);

            AgregarLabel(_pnlFormulario, "Tipo", 480, 115);
            _cmbTipo = CrearComboBox(480, 135, 140);
            _cmbTipo.Items.Add("Fijo");
            _cmbTipo.Items.Add("Por hora");
            _cmbTipo.SelectedIndex = 0;
            _pnlFormulario.Controls.Add(_cmbTipo);

            _btnGuardar = CrearBoton("Guardar", ColorBoton, ColorBotonTexto);
            _btnGuardar.Size = new Size(100, 34);
            _btnGuardar.Location = new Point(20, 185);
            _btnGuardar.Click += BtnGuardar_Click;
            _pnlFormulario.Controls.Add(_btnGuardar);

            _btnCancelar = CrearBoton("Cancelar", ColorInput, ColorSubTexto);
            _btnCancelar.Size = new Size(100, 34);
            _btnCancelar.Location = new Point(130, 185);
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
                DataTable dt = _cnEmp.ObtenerTodos();
                _grid.DataSource = null;
                _grid.DataSource = dt;

                foreach (string col in new[] { "Id", "IdPosicion" })
                    if (_grid.Columns.Contains(col))
                        _grid.Columns[col].Visible = false;

                RenombrarColumna("CodigoEmpleado", "Código");
                RenombrarColumna("Nombre", "Nombre");
                RenombrarColumna("Apellido", "Apellido");
                RenombrarColumna("Cedula", "Cédula");
                RenombrarColumna("Posicion", "Posición");
                RenombrarColumna("FechaIngreso", "Fecha Ingreso");
                RenombrarColumna("SalarioBase", "Salario Base");

                if (_grid.Columns.Contains("SalarioBase"))
                    _grid.Columns["SalarioBase"].DefaultCellStyle.Format = "N2";
                if (_grid.Columns.Contains("FechaIngreso"))
                    _grid.Columns["FechaIngreso"].DefaultCellStyle.Format = "dd/MM/yyyy";

                if (_grid.Columns.Contains("Tipo"))
                {
                    _grid.Columns["Tipo"].HeaderText = "Tipo";
                    _grid.CellFormatting += (s, e) =>
                    {
                        if (e.ColumnIndex == _grid.Columns["Tipo"].Index && e.Value != null)
                        { e.Value = e.Value.ToString() == "1" ? "Fijo" : "Por hora"; e.FormattingApplied = true; }
                    };
                }

                // Solo botón Editar — Eliminar removido
                AgregarColumnaBoton("Editar", ColorEditar, "btnEditar");
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al cargar datos: " + ex.Message, false);
            }
        }

        private void CargarPosicionesCombo()
        {
            try
            {
                DataTable dt = _cnPos.ObtenerTodos();
                _cmbPosicion.DataSource = dt;
                _cmbPosicion.DisplayMember = "Nombre";
                _cmbPosicion.ValueMember = "Id";
                _cmbPosicion.SelectedIndex = -1;
            }
            catch (Exception ex) { MostrarMensaje("Error al cargar posiciones: " + ex.Message, false); }
        }

        private void RenombrarColumna(string nombre, string encabezado)
        {
            if (_grid.Columns.Contains(nombre))
                _grid.Columns[nombre].HeaderText = encabezado;
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
            _modoEdicion = false; _idSeleccionado = 0;
            LimpiarFormulario();
            _lblTitulo.Text = "Nuevo Empleado";
            _btnGuardar.Text = "Guardar";
            _txtCodigo.Enabled = true;
            _pnlFormulario.Visible = true;
            _lblMensaje.Text = "";
            _txtCodigo.Focus();
            ActualizarPosicionGrid();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (_cmbPosicion.SelectedValue == null) { MostrarMensaje("Selecciona una posición.", false); return; }

            string codigo = _txtCodigo.Text.Trim();
            string nombre = _txtNombre.Text.Trim();
            string apellido = _txtApellido.Text.Trim();
            string cedula = _txtCedula.Text.Trim();
            int tipo = _cmbTipo.SelectedIndex + 1;
            int idPos = Convert.ToInt32(_cmbPosicion.SelectedValue);

            try
            {
                bool ok = _modoEdicion
                    ? _cnEmp.Actualizar(_idSeleccionado, nombre, apellido, cedula, tipo, idPos)
                    : _cnEmp.Insertar(codigo, nombre, apellido, cedula, tipo, idPos);

                MostrarMensaje(ok
                    ? (_modoEdicion ? "Empleado actualizado correctamente." : "Empleado registrado correctamente.")
                    : "No se pudo guardar el empleado.", ok);

                if (ok) { OcultarFormulario(); RefrescarGrid(); }
            }
            catch (Exception ex) { MostrarMensaje("Error: " + ex.Message, false); }
        }

        private void BtnCancelar_Click(object sender, EventArgs e) { OcultarFormulario(); _lblMensaje.Text = ""; }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(_grid.Rows[e.RowIndex].Cells["Id"].Value);

            if (_grid.Columns[e.ColumnIndex].Name == "btnEditar")
            {
                DataTable dt = _cnEmp.ObtenerPorId(id);
                if (dt.Rows.Count == 0) return;

                DataRow row = dt.Rows[0];
                _idSeleccionado = id;
                _modoEdicion = true;

                _txtCodigo.Text = row["CodigoEmpleado"].ToString();
                _txtCodigo.Enabled = false;
                _txtNombre.Text = row["Nombre"].ToString();
                _txtApellido.Text = row["Apellido"].ToString();
                _txtCedula.Text = row["Cedula"].ToString();

                if (row.Table.Columns.Contains("IdPosicion"))
                    _cmbPosicion.SelectedValue = Convert.ToInt32(row["IdPosicion"]);

                _cmbTipo.SelectedIndex = Convert.ToInt32(row["Tipo"]) == 1 ? 0 : 1;

                _lblTitulo.Text = "Editar Empleado";
                _btnGuardar.Text = "Actualizar";
                _pnlFormulario.Visible = true;
                _lblMensaje.Text = "";
                _txtNombre.Focus();
                ActualizarPosicionGrid();
            }
        }

        // ════════════════════════════════════════
        //  HELPERS
        // ════════════════════════════════════════
        private void OcultarFormulario()
        {
            _pnlFormulario.Visible = false; _modoEdicion = false; _idSeleccionado = 0;
            LimpiarFormulario(); ActualizarPosicionGrid();
        }

        private void LimpiarFormulario()
        {
            _txtCodigo.Clear(); _txtNombre.Clear(); _txtApellido.Clear(); _txtCedula.Clear();
            _cmbPosicion.SelectedIndex = -1; _cmbTipo.SelectedIndex = 0; _txtCodigo.Enabled = true;
        }

        private void RefrescarGrid()
        {
            if (_grid.Columns.Contains("btnEditar")) _grid.Columns.Remove("btnEditar");
            CargarDatos();
        }

        private void ActualizarPosicionGrid()
        {
            if (_pnlFormulario.Visible)
            { _lblMensaje.Location = new Point(30, 310); _grid.Location = new Point(30, 340); _grid.Size = new Size(this.Width - 60, this.Height - 360); }
            else
            { _lblMensaje.Location = new Point(30, 80); _grid.Location = new Point(30, 110); _grid.Size = new Size(this.Width - 60, this.Height - 130); }
        }

        private void MostrarMensaje(string texto, bool exito)
        {
            _lblMensaje.Text = exito ? "✓  " + texto : "✗  " + texto;
            _lblMensaje.ForeColor = exito ? Color.FromArgb(39, 201, 63) : Color.FromArgb(255, 80, 80);
        }

        private void AgregarLabel(Panel parent, string texto, int x, int y)
        {
            parent.Controls.Add(new Label { Text = texto, ForeColor = ColorTexto, Font = new Font("Segoe UI", 9), AutoSize = true, Location = new Point(x, y) });
        }

        private Panel CrearPanelInput(int x, int y, int ancho, out TextBox txt)
        {
            Panel pnl = new Panel { Size = new Size(ancho, 36), Location = new Point(x, y), BackColor = ColorInput };
            pnl.Paint += (s, ev) => { using (Pen p = new Pen(ColorBorde, 1)) ev.Graphics.DrawRectangle(p, 0, 0, pnl.Width - 1, pnl.Height - 1); };
            txt = new TextBox { Size = new Size(ancho - 20, 24), Location = new Point(10, 6), BackColor = ColorInput, ForeColor = ColorTexto, BorderStyle = BorderStyle.None, Font = new Font("Segoe UI", 10) };
            pnl.Controls.Add(txt);
            return pnl;
        }

        private ComboBox CrearComboBox(int x, int y, int ancho)
        {
            return new ComboBox { Size = new Size(ancho, 36), Location = new Point(x, y), BackColor = ColorInput, ForeColor = ColorTexto, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10), DropDownStyle = ComboBoxStyle.DropDownList };
        }

        private Button CrearBoton(string texto, Color fondo, Color fuente)
        {
            Button btn = new Button { Text = texto, FlatStyle = FlatStyle.Flat, BackColor = fondo, ForeColor = fuente, Font = new Font("Segoe UI", 9, FontStyle.Bold), Cursor = Cursors.Hand };
            btn.FlatAppearance.BorderSize = 0;
            btn.Region = CrearRegionRedondeada(btn.Size, 6);
            btn.SizeChanged += (s, e) => btn.Region = CrearRegionRedondeada(btn.Size, 6);
            return btn;
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
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(20, 28, 58);
            grid.ColumnHeadersHeight = 36;
            grid.RowTemplate.Height = 40;
            grid.GridColor = ColorBorde;
            grid.EnableHeadersVisualStyles = false;
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(20, 28, 55);
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
    }
}