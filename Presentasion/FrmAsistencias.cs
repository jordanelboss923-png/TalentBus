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
        private readonly Color ColorVerde = Color.FromArgb(39, 201, 63);
        private readonly Color ColorAmarillo = Color.FromArgb(255, 180, 0);
        private readonly Color ColorNaranja = Color.FromArgb(255, 120, 0);

        // ─── Negocio ───
        private readonly AsistenciasCN _cn = new AsistenciasCN();
        private readonly EmpleadosCN _cnEmp = new EmpleadosCN();

        // ─── Controles ───
        private DataGridView _grid;
        private ComboBox _cmbEmpleado;
        private ComboBox _cmbTipo;
        private Label _lblMensaje;
        private Panel _pnlFormulario;
        private Panel _pnlTarjetas;

        // ─── Tarjetas de marcación rápida ───
        private Panel _cardEntrada;
        private Panel _cardSalida;
        private Panel _cardAlmuerzo;
        private Panel _cardRetorno;

        public FrmAsistencias()
        {
            InitializeComponent();
            ConfigurarFormulario();
            ConstruirUI();
            CargarEmpleadosCombo();
            CargarDatos();
        }

       
        private void ConfigurarFormulario()
        {
            this.BackColor = ColorFondo;
            this.DoubleBuffered = true;
        }

        
        private void ConstruirUI()
        {
            Panel pnlHeader = new Panel
            {
                Size = new Size(this.Width, 60),
                Location = new Point(0, 0),
                BackColor = Color.Transparent
            };
            this.Controls.Add(pnlHeader);

            new Label
            {
                Text = "Asistencias",
                ForeColor = ColorTexto,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(30, 15),
                Parent = pnlHeader
            };

            new Label
            {
                Text = "Registro de marcaciones del personal",
                ForeColor = ColorSubTexto,
                Font = new Font("Segoe UI", 9),
                AutoSize = true,
                Location = new Point(32, 42),
                Parent = pnlHeader
            };

            _pnlFormulario = new Panel
            {
                Size = new Size(this.Width - 60, 90),
                Location = new Point(30, 70),
                BackColor = ColorPanel
            };
            _pnlFormulario.Paint += PnlBorde_Paint;
            this.Controls.Add(_pnlFormulario);
            ConstruirSelector();

            _pnlTarjetas = new Panel
            {
                Size = new Size(this.Width - 60, 110),
                Location = new Point(30, 175),
                BackColor = Color.Transparent
            };
            this.Controls.Add(_pnlTarjetas);
            ConstruirTarjetas();

            _lblMensaje = new Label
            {
                Text = "",
                ForeColor = ColorCyan,
                Font = new Font("Segoe UI", 9),
                AutoSize = false,
                Size = new Size(this.Width - 60, 24),
                Location = new Point(30, 295),
                TextAlign = ContentAlignment.MiddleLeft
            };
            this.Controls.Add(_lblMensaje);

            _grid = new DataGridView
            {
                Size = new Size(this.Width - 60, this.Height - 350),
                Location = new Point(30, 325),
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
            _grid.CellFormatting += Grid_CellFormatting;
            _grid.CellClick += Grid_CellClick;
            this.Controls.Add(_grid);
        }

        private void ConstruirSelector()
        {
            AgregarLabel(_pnlFormulario, "Empleado", 20, 15);

            _cmbEmpleado = new ComboBox
            {
                Size = new Size(320, 36),
                Location = new Point(20, 38),
                BackColor = ColorInput,
                ForeColor = ColorTexto,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            _pnlFormulario.Controls.Add(_cmbEmpleado);

            AgregarLabel(_pnlFormulario, "Tipo de marcación", 360, 15);

            _cmbTipo = new ComboBox
            {
                Size = new Size(220, 36),
                Location = new Point(360, 38),
                BackColor = ColorInput,
                ForeColor = ColorTexto,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            _cmbTipo.Items.AddRange(new object[]
            {
                "Entrada",
                "Salida",
                "Almuerzo",
                "Retorno de Almuerzo"
            });
            _cmbTipo.SelectedIndex = 0;
            _pnlFormulario.Controls.Add(_cmbTipo);

            Button btnRegistrar = CrearBoton("Registrar", ColorBoton, ColorBotonTexto);
            btnRegistrar.Size = new Size(120, 36);
            btnRegistrar.Location = new Point(600, 38);
            btnRegistrar.Click += BtnRegistrar_Click;
            _pnlFormulario.Controls.Add(btnRegistrar);
        }

        private void ConstruirTarjetas()
        {
            int ancho = (_pnlTarjetas.Width - 45) / 4;

            _cardEntrada = CrearTarjeta(0, ancho * 0 + 0, "🟢", "Entrada",
                                          ColorVerde, EstadoRegistrado.Entrada);
            _cardAlmuerzo = CrearTarjeta(1, ancho * 1 + 15, "🟡", "Almuerzo",
                                          ColorAmarillo, EstadoRegistrado.Almuerzo);
            _cardRetorno = CrearTarjeta(2, ancho * 2 + 30, "🟠", "Retorno Almuerzo",
                                          ColorNaranja, EstadoRegistrado.RetornoDeAlmuerzo);
            _cardSalida = CrearTarjeta(3, ancho * 3 + 45, "🔴", "Salida",
                                          ColorEliminar, EstadoRegistrado.Salida);

            _pnlTarjetas.Controls.Add(_cardEntrada);
            _pnlTarjetas.Controls.Add(_cardAlmuerzo);
            _pnlTarjetas.Controls.Add(_cardRetorno);
            _pnlTarjetas.Controls.Add(_cardSalida);
        }

        private Panel CrearTarjeta(int idx, int x, string icono,
                                   string texto, Color colorAcento,
                                   EstadoRegistrado tipo)
        {
            int ancho = (_pnlTarjetas.Width - 45) / 4;

            Panel card = new Panel
            {
                Size = new Size(ancho, 100),
                Location = new Point(x, 0),
                BackColor = ColorPanel,
                Cursor = Cursors.Hand,
                Tag = tipo
            };
            card.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (SolidBrush b = new SolidBrush(colorAcento))
                    e.Graphics.FillRectangle(b, 0, 0, card.Width, 4);
                using (Pen p = new Pen(ColorBorde, 1))
                    e.Graphics.DrawRectangle(p, 0, 0,
                                             card.Width - 1, card.Height - 1);
            };

            Label lblIcono = new Label
            {
                Text = icono,
                Font = new Font("Segoe UI", 20),
                AutoSize = true,
                Location = new Point(15, 15),
                BackColor = Color.Transparent,
                ForeColor = colorAcento
            };
            card.Controls.Add(lblIcono);

            Label lblTexto = new Label
            {
                Text = texto,
                ForeColor = ColorTexto,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(15, 60),
                BackColor = Color.Transparent
            };
            card.Controls.Add(lblTexto);

            Action<object, EventArgs> onClick = (s, e) =>
                RegistrarMarcacionRapida((EstadoRegistrado)card.Tag);

            card.Click += (s, e) => onClick(s, e);
            lblIcono.Click += (s, e) => onClick(s, e);
            lblTexto.Click += (s, e) => onClick(s, e);

            card.MouseEnter += (s, e) => card.BackColor = Color.FromArgb(22, 32, 60);
            card.MouseLeave += (s, e) => card.BackColor = ColorPanel;

            return card;
        }

        
        private void CargarEmpleadosCombo()
        {
            try
            {
                DataTable dt = _cnEmp.ObtenerTodos();
                _cmbEmpleado.DataSource = dt;
                _cmbEmpleado.DisplayMember = "CodigoEmpleado";
                _cmbEmpleado.ValueMember = "Id";
                _cmbEmpleado.SelectedIndex = -1;

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

                if (_grid.Columns.Contains("IdEmpleado"))
                    _grid.Columns["IdEmpleado"].Visible = false;

                RenombrarColumna("NombreEmpleado", "Empleado");
                RenombrarColumna("Descripcion", "Marcación");
                RenombrarColumna("FechaHora", "Fecha y Hora");

                if (_grid.Columns.Contains("FechaHora"))
                    _grid.Columns["FechaHora"].DefaultCellStyle.Format =
                        "dd/MM/yyyy hh:mm tt";

                AgregarColumnaBoton("Eliminar", ColorEliminar, "btnEliminar");
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al cargar asistencias: " + ex.Message, false);
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

        
        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if (_cmbEmpleado.SelectedValue == null)
            {
                MostrarMensaje("Selecciona un empleado.", false);
                return;
            }

            int idEmpleado = Convert.ToInt32(_cmbEmpleado.SelectedValue);
            EstadoRegistrado tipo = ObtenerTipoSeleccionado();
            EjecutarMarcacion(idEmpleado, tipo);
        }

        private void RegistrarMarcacionRapida(EstadoRegistrado tipo)
        {
            if (_cmbEmpleado.SelectedValue == null)
            {
                MostrarMensaje("Selecciona un empleado primero.", false);
                return;
            }

            int idEmpleado = Convert.ToInt32(_cmbEmpleado.SelectedValue);
            _cmbTipo.SelectedIndex = (int)tipo;
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

            if (_grid.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                int id = Convert.ToInt32(_grid.Rows[e.RowIndex].Cells["Id"].Value);
                string emp = _grid.Rows[e.RowIndex].Cells["NombreEmpleado"].Value.ToString();
                string tipo = _grid.Rows[e.RowIndex].Cells["Descripcion"].Value.ToString();

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
            if (_grid.Columns[e.ColumnIndex].Name != "Descripcion"
                || e.Value == null) return;

            string val = e.Value.ToString();

            if (val == "Entrada") e.CellStyle.ForeColor = ColorVerde;
            else if (val == "Salida") e.CellStyle.ForeColor = ColorEliminar;
            else if (val == "Almuerzo") e.CellStyle.ForeColor = ColorAmarillo;
            else if (val == "Retorno de Almuerzo") e.CellStyle.ForeColor = ColorNaranja;
            else e.CellStyle.ForeColor = ColorTexto;

            e.FormattingApplied = true;
        }

        private EstadoRegistrado ObtenerTipoSeleccionado()
        {
            switch (_cmbTipo.SelectedIndex)
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
            if (_grid.Columns.Contains("btnEliminar"))
                _grid.Columns.Remove("btnEliminar");
            CargarDatos();
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