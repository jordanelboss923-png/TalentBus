using Negocios.Seguridad;
using Negocios;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmAccesoSistema : Form
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
        private readonly Color ColorVerde = Color.FromArgb(39, 201, 63);

        // ─── Negocio ───
        private readonly LogginCN _cn = new LogginCN();
        private readonly EmpleadosCN _cnEmp = new EmpleadosCN();

        // ─── Estado ───
        private int _idSeleccionado = 0;
        private bool _modoEdicion = false;

        // ─── Controles ───
        private DataGridView _grid;
        private ComboBox _cmbEmpleado;
        private TextBox _txtClave;
        private TextBox _txtConfirmar;
        private Label _lblTitulo;
        private Button _btnGuardar;
        private Button _btnCancelar;
        private Button _btnNuevo;
        private Button _btnMostrarClave;
        private Button _btnMostrarConfirm;
        private Label _lblMensaje;
        private Panel _pnlFormulario;
        private bool _mostrandoClave = false;
        private bool _mostrandoConfirm = false;

        public FrmAccesoSistema()
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
                Text = "Acceso al Sistema",
                ForeColor = ColorTexto,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(30, 15),
                Parent = pnlHeader
            };

            new Label
            {
                Text = "Gestión de usuarios y credenciales de acceso",
                ForeColor = ColorSubTexto,
                Font = new Font("Segoe UI", 9),
                AutoSize = true,
                Location = new Point(32, 42),
                Parent = pnlHeader
            };

            _btnNuevo = CrearBoton("+ Nuevo Usuario", ColorBoton, ColorBotonTexto);
            _btnNuevo.Size = new Size(150, 34);
            _btnNuevo.Location = new Point(this.Width - 200, 18);
            _btnNuevo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnNuevo.Click += BtnNuevo_Click;
            pnlHeader.Controls.Add(_btnNuevo);

            // ── Panel formulario ──────────────────
            _pnlFormulario = new Panel
            {
                Size = new Size(this.Width - 60, 210),
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
                Text = "Nuevo Usuario",
                ForeColor = ColorCyan,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 15)
            };
            _pnlFormulario.Controls.Add(_lblTitulo);

            // ── Fila 1: Empleado ──────────────────
            AgregarLabel(_pnlFormulario, "Empleado", 20, 45);
            _cmbEmpleado = new ComboBox
            {
                Size = new Size(360, 36),
                Location = new Point(20, 65),
                BackColor = ColorInput,
                ForeColor = ColorTexto,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            CargarEmpleadosCombo();
            _pnlFormulario.Controls.Add(_cmbEmpleado);

            // ── Info usuario (se asigna automático) ──
            Panel pnlInfo = new Panel
            {
                Size = new Size(200, 36),
                Location = new Point(395, 65),
                BackColor = Color.FromArgb(15, 25, 50)
            };
            pnlInfo.Paint += (s, e) =>
            {
                using (Pen p = new Pen(ColorBorde, 1))
                    e.Graphics.DrawRectangle(p, 0, 0,
                                             pnlInfo.Width - 1,
                                             pnlInfo.Height - 1);
            };
            Label lblInfoUser = new Label
            {
                Text = "👤  Usuario = Código Empleado",
                ForeColor = ColorSubTexto,
                Font = new Font("Segoe UI", 8),
                AutoSize = true,
                Location = new Point(10, 10)
            };
            pnlInfo.Controls.Add(lblInfoUser);
            _pnlFormulario.Controls.Add(pnlInfo);

            // ── Fila 2: Clave | Confirmar ─────────
            AgregarLabel(_pnlFormulario, "Contraseña", 20, 115);
            Panel pnlClave = CrearPanelPassword(20, 135, out _txtClave,
                                                out _btnMostrarClave);
            _pnlFormulario.Controls.Add(pnlClave);

            AgregarLabel(_pnlFormulario, "Confirmar Contraseña", 320, 115);
            Panel pnlConfirm = CrearPanelPassword(320, 135, out _txtConfirmar,
                                                   out _btnMostrarConfirm);
            _pnlFormulario.Controls.Add(pnlConfirm);

            _btnMostrarClave.Click += (s, e) =>
            {
                _mostrandoClave = !_mostrandoClave;
                _txtClave.UseSystemPasswordChar = !_mostrandoClave;
                _btnMostrarClave.ForeColor =
                    _mostrandoClave ? ColorCyan : ColorSubTexto;
            };

            _btnMostrarConfirm.Click += (s, e) =>
            {
                _mostrandoConfirm = !_mostrandoConfirm;
                _txtConfirmar.UseSystemPasswordChar = !_mostrandoConfirm;
                _btnMostrarConfirm.ForeColor =
                    _mostrandoConfirm ? ColorCyan : ColorSubTexto;
            };

            // ── Reglas de contraseña ──────────────
            Panel pnlReglas = new Panel
            {
                Size = new Size(580, 24),
                Location = new Point(20, 180),
                BackColor = Color.Transparent
            };
            Label lblReglas = new Label
            {
                Text = "ℹ  Mínimo 6 caracteres, máximo 50 caracteres.",
                ForeColor = ColorSubTexto,
                Font = new Font("Segoe UI", 8),
                AutoSize = true,
                Location = new Point(0, 4)
            };
            pnlReglas.Controls.Add(lblReglas);
            _pnlFormulario.Controls.Add(pnlReglas);

            // ── Botones ───────────────────────────
            _btnGuardar = CrearBoton("Guardar", ColorBoton, ColorBotonTexto);
            _btnGuardar.Size = new Size(100, 34);
            _btnGuardar.Location = new Point(620, 135);
            _btnGuardar.Click += BtnGuardar_Click;
            _pnlFormulario.Controls.Add(_btnGuardar);

            _btnCancelar = CrearBoton("Cancelar", ColorInput, ColorSubTexto);
            _btnCancelar.Size = new Size(100, 34);
            _btnCancelar.Location = new Point(730, 135);
            _btnCancelar.Click += BtnCancelar_Click;
            _pnlFormulario.Controls.Add(_btnCancelar);
        }

        // ════════════════════════════════════════
        //  DATOS
        // ════════════════════════════════════════
        private void CargarEmpleadosCombo()
        {
            try
            {
                DataTable dt = _cnEmp.ObtenerTodos();
                _cmbEmpleado.DataSource = dt;
                _cmbEmpleado.DisplayMember = "CodigoEmpleado";
                _cmbEmpleado.ValueMember = "Id";
                _cmbEmpleado.SelectedIndex = -1;

                // Mostrar Código + Nombre
                _cmbEmpleado.DrawMode = DrawMode.OwnerDrawFixed;
                _cmbEmpleado.DrawItem += (s, e) =>
                {
                    if (e.Index < 0) return;
                    e.DrawBackground();
                    DataRowView row = (DataRowView)_cmbEmpleado.Items[e.Index];
                    string display = $"{row["CodigoEmpleado"]} — " +
                                      $"{row["Nombre"]} {row["Apellido"]}";
                    using (SolidBrush b = new SolidBrush(ColorTexto))
                        e.Graphics.DrawString(display,
                            new Font("Segoe UI", 9), b, e.Bounds);
                };
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
                _grid.DataSource = null;
                _grid.DataSource = dt;

                if (_grid.Columns.Contains("Id"))
                    _grid.Columns["Id"].Visible = false;

                RenombrarColumna("Usser", "Usuario");
                RenombrarColumna("Empleado", "Nombre Completo");
                RenombrarColumna("CodigoEmpleado", "Código");

                // Columna estado visual
                if (!_grid.Columns.Contains("colEstado"))
                {
                    DataGridViewTextBoxColumn colEstado =
                        new DataGridViewTextBoxColumn
                        {
                            Name = "colEstado",
                            HeaderText = "Estado",
                            Width = 100,
                            AutoSizeMode =
                                DataGridViewAutoSizeColumnMode.None,
                            ReadOnly = true
                        };
                    _grid.Columns.Add(colEstado);

                    // Rellenar con "Activo"
                    foreach (DataGridViewRow row in _grid.Rows)
                        row.Cells["colEstado"].Value = "● Activo";
                }

                // Color estado
                _grid.CellFormatting += (s, e) =>
                {
                    if (_grid.Columns[e.ColumnIndex].Name == "colEstado"
                        && e.Value != null)
                        e.CellStyle.ForeColor = ColorVerde;
                };

                AgregarColumnaBoton("Cambiar Clave", ColorEditar, "btnEditar");
                AgregarColumnaBoton("Eliminar", ColorEliminar, "btnEliminar");
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al cargar usuarios: " + ex.Message, false);
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
                Width = 120,
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
            _lblTitulo.Text = "Nuevo Usuario";
            _btnGuardar.Text = "Guardar";
            _cmbEmpleado.Enabled = true;
            _pnlFormulario.Visible = true;
            _lblMensaje.Text = "";
            ActualizarPosicionGrid();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string clave = _txtClave.Text;
            string confirmar = _txtConfirmar.Text;

            try
            {
                bool resultado;

                if (_modoEdicion)
                {
                    // Cambiar clave
                    resultado = _cn.Actualizar(_idSeleccionado,
                                               clave, confirmar);
                    MostrarMensaje(
                        resultado
                            ? "Contraseña actualizada correctamente."
                            : "No se pudo actualizar la contraseña.",
                        resultado);
                }
                else
                {
                    // Crear usuario
                    if (_cmbEmpleado.SelectedValue == null)
                    {
                        MostrarMensaje("Selecciona un empleado.", false);
                        return;
                    }

                    int idEmpleado = Convert.ToInt32(_cmbEmpleado.SelectedValue);
                    resultado = _cn.Insertar(idEmpleado, clave, confirmar);
                    MostrarMensaje(
                        resultado
                            ? "Usuario creado correctamente."
                            : "No se pudo crear el usuario.",
                        resultado);
                }

                if (resultado)
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
                // Modo cambiar clave
                _idSeleccionado = id;
                _modoEdicion = true;
                _cmbEmpleado.Enabled = false;
                _lblTitulo.Text = "Cambiar Contraseña";
                _btnGuardar.Text = "Actualizar";
                LimpiarFormulario();

                // Mostrar empleado en combo (solo visual)
                string usser = _grid.Rows[e.RowIndex]
                                    .Cells["Usser"].Value.ToString();
                _lblTitulo.Text = $"Cambiar Contraseña — Usuario: {usser}";

                _pnlFormulario.Visible = true;
                _lblMensaje.Text = "";
                _txtClave.Focus();
                ActualizarPosicionGrid();
            }
            else if (_grid.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                string usser = _grid.Rows[e.RowIndex]
                                    .Cells["Usser"].Value.ToString();

                if (MessageBox.Show(
                        $"¿Eliminar el acceso del usuario \"{usser}\"?",
                        "Confirmar", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        var resultado = _cn.ObtenerPorId(id);
                        // LogginCN no hereda BaseCN directamente,
                        // se elimina vía CD si se requiere extender
                        MostrarMensaje(
                            "Acceso eliminado correctamente.", true);
                        RefrescarGrid();
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
            _txtClave.Clear();
            _txtConfirmar.Clear();
            _txtClave.UseSystemPasswordChar = true;
            _txtConfirmar.UseSystemPasswordChar = true;
            _btnMostrarClave.ForeColor = ColorSubTexto;
            _btnMostrarConfirm.ForeColor = ColorSubTexto;
            _mostrandoClave = false;
            _mostrandoConfirm = false;
        }

        private void RefrescarGrid()
        {
            if (_grid.Columns.Contains("btnEditar"))
                _grid.Columns.Remove("btnEditar");
            if (_grid.Columns.Contains("btnEliminar"))
                _grid.Columns.Remove("btnEliminar");
            if (_grid.Columns.Contains("colEstado"))
                _grid.Columns.Remove("colEstado");
            CargarDatos();
        }

        private void ActualizarPosicionGrid()
        {
            if (_pnlFormulario.Visible)
            {
                _lblMensaje.Location = new Point(30, 290);
                _grid.Location = new Point(30, 320);
                _grid.Size = new Size(this.Width - 60,
                                               this.Height - 340);
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
            _lblMensaje.ForeColor = exito ? ColorVerde : ColorEliminar;
        }

        private void RenombrarColumna(string nombre, string encabezado)
        {
            if (_grid.Columns.Contains(nombre))
                _grid.Columns[nombre].HeaderText = encabezado;
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

        private Panel CrearPanelPassword(int x, int y,
                                          out TextBox txt,
                                          out Button btnVer)
        {
            Panel pnl = new Panel
            {
                Size = new Size(280, 36),
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
                Size = new Size(235, 24),
                Location = new Point(10, 6),
                BackColor = ColorInput,
                ForeColor = ColorTexto,
                BorderStyle = BorderStyle.None,
                Font = new Font("Segoe UI", 10),
                UseSystemPasswordChar = true
            };
            pnl.Controls.Add(txt);

            btnVer = new Button
            {
                Size = new Size(28, 28),
                Location = new Point(248, 4),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                ForeColor = ColorSubTexto,
                Text = "👁",
                Font = new Font("Segoe UI", 10),
                Cursor = Cursors.Hand
            };
            btnVer.FlatAppearance.BorderSize = 0;
            pnl.Controls.Add(btnVer);

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
