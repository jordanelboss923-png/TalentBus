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

        // ─── Negocio ───
        private readonly VolantesPagoCN _cn = new VolantesPagoCN();
        private readonly EmpleadosCN _cnEmp = new EmpleadosCN();

        // ─── Estado ───
        private int _idSeleccionado = 0;
        private bool _modoEdicion = false;

        // ─── Controles principales ───
        private DataGridView _grid;
        private ComboBox _cmbEmpleado;
        private DateTimePicker _dtpFecha;
        private Label _lblMensaje;
        private Panel _pnlFormulario;
        private Panel _pnlVolante;
        private Button _btnNuevo;
        private Button _btnGuardar;
        private Button _btnCancelar;
        private Button _btnVerVolante;
        private Label _lblTitulo;

        // ─── Controles del volante visual ───
        private Panel _pnlVistaVolante;
        private Label _lblVEmpleado;
        private Label _lblVPosicion;
        private Label _lblVCodigo;
        private Label _lblVFecha;
        private Label _lblVSueldo;
        private Label _lblVAsignacion;
        private Label _lblVTotalAsig;
        private Label _lblVDeducciones;
        private Label _lblVNeto;

        public FrmVolantesPago()
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
                Text = "Volantes de Pago",
                ForeColor = ColorTexto,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(30, 15),
                Parent = pnlHeader
            };

            new Label
            {
                Text = "Consulta y gestión de nómina por empleado",
                ForeColor = ColorSubTexto,
                Font = new Font("Segoe UI", 9),
                AutoSize = true,
                Location = new Point(32, 42),
                Parent = pnlHeader
            };

            _btnNuevo = CrearBoton("+ Nuevo Registro", ColorBoton, ColorBotonTexto);
            _btnNuevo.Size = new Size(150, 34);
            _btnNuevo.Location = new Point(this.Width - 200, 18);
            _btnNuevo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnNuevo.Click += BtnNuevo_Click;
            pnlHeader.Controls.Add(_btnNuevo);

            // ── Panel formulario ──────────────────
            _pnlFormulario = new Panel
            {
                Size = new Size(this.Width - 60, 130),
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

            // ── Vista volante (panel lateral) ─────
            ConstruirVistaVolante();
        }

        private void ConstruirFormulario()
        {
            _lblTitulo = new Label
            {
                Text = "Nuevo Registro de Nómina",
                ForeColor = ColorCyan,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 15)
            };
            _pnlFormulario.Controls.Add(_lblTitulo);

            // ── Empleado ──────────────────────────
            AgregarLabel(_pnlFormulario, "Empleado", 20, 45);
            _cmbEmpleado = new ComboBox
            {
                Size = new Size(340, 36),
                Location = new Point(20, 65),
                BackColor = ColorInput,
                ForeColor = ColorTexto,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            CargarEmpleadosCombo();
            _pnlFormulario.Controls.Add(_cmbEmpleado);

            // ── Fecha ─────────────────────────────
            AgregarLabel(_pnlFormulario, "Fecha de Efectividad", 375, 45);
            _dtpFecha = new DateTimePicker
            {
                Size = new Size(200, 36),
                Location = new Point(375, 65),
                Format = DateTimePickerFormat.Short,
                Font = new Font("Segoe UI", 10),
                CalendarForeColor = ColorTexto,
                CalendarMonthBackground = ColorPanel,
                MaxDate = DateTime.Today
            };
            _pnlFormulario.Controls.Add(_dtpFecha);

            // ── Botones ───────────────────────────
            _btnGuardar = CrearBoton("Guardar", ColorBoton, ColorBotonTexto);
            _btnGuardar.Size = new Size(100, 34);
            _btnGuardar.Location = new Point(590, 65);
            _btnGuardar.Click += BtnGuardar_Click;
            _pnlFormulario.Controls.Add(_btnGuardar);

            _btnCancelar = CrearBoton("Cancelar", ColorInput, ColorSubTexto);
            _btnCancelar.Size = new Size(100, 34);
            _btnCancelar.Location = new Point(700, 65);
            _btnCancelar.Click += BtnCancelar_Click;
            _pnlFormulario.Controls.Add(_btnCancelar);
        }

        private void ConstruirVistaVolante()
        {
            _pnlVistaVolante = new Panel
            {
                Size = new Size(320, this.Height - 130),
                Location = new Point(this.Width - 350, 110),
                BackColor = ColorPanel,
                Visible = false
            };
            _pnlVistaVolante.Paint += PnlBorde_Paint;
            this.Controls.Add(_pnlVistaVolante);

            // ── Encabezado volante ────────────────
            Panel pnlTop = new Panel
            {
                Size = new Size(320, 80),
                Location = new Point(0, 0),
                BackColor = Color.FromArgb(15, 22, 45)
            };
            _pnlVistaVolante.Controls.Add(pnlTop);

            // Logo mini
            PictureBox picLogo = new PictureBox
            {
                Size = new Size(36, 36),
                Location = new Point(15, 22),
                BackColor = Color.Transparent
            };
            picLogo.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen p = new Pen(ColorCyan, 1.5f))
                    e.Graphics.DrawEllipse(p, 1, 1, 32, 32);
                DibujarEstrella(e.Graphics, 18, 18, 12, 5, 5, ColorCyan);
            };
            pnlTop.Controls.Add(picLogo);

            Label lblVolanteTitulo = new Label
            {
                Text = "VOLANTE DE PAGO",
                ForeColor = ColorCyan,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(60, 18)
            };
            pnlTop.Controls.Add(lblVolanteTitulo);

            Label lblSistema = new Label
            {
                Text = "TalentBus DB3",
                ForeColor = ColorSubTexto,
                Font = new Font("Segoe UI", 8),
                AutoSize = true,
                Location = new Point(60, 40)
            };
            pnlTop.Controls.Add(lblSistema);

            // ── Datos del empleado ────────────────
            int yPos = 95;

            _lblVCodigo = CrearFilaVolante("Código:", yPos); yPos += 30;
            _lblVEmpleado = CrearFilaVolante("Empleado:", yPos); yPos += 30;
            _lblVPosicion = CrearFilaVolante("Posición:", yPos); yPos += 30;
            _lblVFecha = CrearFilaVolante("Período:", yPos); yPos += 30;

            // Separador
            AgregarSeparador(yPos); yPos += 20;

            // ── Ingresos ──────────────────────────
            AgregarSubtitulo("INGRESOS", yPos); yPos += 28;
            _lblVSueldo = CrearFilaVolante("Sueldo Base:", yPos); yPos += 28;
            _lblVAsignacion = CrearFilaVolante("Asignaciones:", yPos); yPos += 28;
            _lblVTotalAsig = CrearFilaVolanteBold("Subtotal:", yPos,
                                                    ColorCyan); yPos += 28;

            // Separador
            AgregarSeparador(yPos); yPos += 20;

            // ── Deducciones ───────────────────────
            AgregarSubtitulo("DEDUCCIONES", yPos); yPos += 28;
            _lblVDeducciones = CrearFilaVolante("Total Ded.:", yPos); yPos += 28;

            // Separador doble
            AgregarSeparador(yPos); yPos += 15;
            AgregarSeparador(yPos + 3); yPos += 25;

            // ── Neto ──────────────────────────────
            _lblVNeto = CrearFilaVolanteBold("SALARIO NETO:", yPos,
                                              ColorVerde);

            // ── Botón imprimir ────────────────────
            Button btnImprimir = CrearBoton("🖨  Imprimir", ColorBoton, ColorBotonTexto);
            btnImprimir.Size = new Size(140, 36);
            btnImprimir.Location = new Point(
                (_pnlVistaVolante.Width - 140) / 2,
                _pnlVistaVolante.Height - 55);
            btnImprimir.Click += BtnImprimir_Click;
            _pnlVistaVolante.Controls.Add(btnImprimir);
        }

        // ════════════════════════════════════════
        //  HELPERS VOLANTE
        // ════════════════════════════════════════
        private Label CrearFilaVolante(string etiqueta, int y)
        {
            // Etiqueta
            _pnlVistaVolante.Controls.Add(new Label
            {
                Text = etiqueta,
                ForeColor = ColorSubTexto,
                Font = new Font("Segoe UI", 8),
                AutoSize = true,
                Location = new Point(20, y)
            });

            // Valor (retornamos este label para actualizar después)
            Label lblValor = new Label
            {
                Text = "—",
                ForeColor = ColorTexto,
                Font = new Font("Segoe UI", 9),
                AutoSize = true,
                Location = new Point(145, y)
            };
            _pnlVistaVolante.Controls.Add(lblValor);
            return lblValor;
        }

        private Label CrearFilaVolanteBold(string etiqueta, int y, Color colorValor)
        {
            _pnlVistaVolante.Controls.Add(new Label
            {
                Text = etiqueta,
                ForeColor = ColorTexto,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, y)
            });

            Label lblValor = new Label
            {
                Text = "—",
                ForeColor = colorValor,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(145, y)
            };
            _pnlVistaVolante.Controls.Add(lblValor);
            return lblValor;
        }

        private void AgregarSeparador(int y)
        {
            Panel sep = new Panel
            {
                Size = new Size(280, 1),
                Location = new Point(20, y),
                BackColor = ColorBorde
            };
            _pnlVistaVolante.Controls.Add(sep);
        }

        private void AgregarSubtitulo(string texto, int y)
        {
            _pnlVistaVolante.Controls.Add(new Label
            {
                Text = texto,
                ForeColor = ColorCyan,
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, y)
            });
        }

        private void ActualizarVistaVolante(DataRow row)
        {
            _lblVCodigo.Text = row["CodigoEmpleado"].ToString();
            _lblVEmpleado.Text = row["Empleado"].ToString();
            _lblVPosicion.Text = row["Posicion"].ToString();
            _lblVFecha.Text = Convert.ToDateTime(
                                    row["FechaEfectividad"])
                                    .ToString("dd/MM/yyyy");

            decimal sueldo = Convert.ToDecimal(row["Sueldobase"]);
            decimal asignacion = Convert.ToDecimal(row["Asignacion"]);
            decimal total = Convert.ToDecimal(row["Total"]);

            _lblVSueldo.Text = sueldo.ToString("C2");
            _lblVAsignacion.Text = asignacion.ToString("C2");
            _lblVTotalAsig.Text = total.ToString("C2");

            // Deducciones — consultar completo
            try
            {
                int idEmp = Convert.ToInt32(row["IdEmpleado"] ??
                              ObtenerIdEmpleadoPorCodigo(
                                  row["CodigoEmpleado"].ToString()));
                DateTime fecha = Convert.ToDateTime(row["FechaEfectividad"]);

                DataTable dtCompleto =
                    _cn.ObtenerVolanteCompleto(idEmp, fecha);

                if (dtCompleto.Rows.Count > 0)
                {
                    decimal ded = Convert.ToDecimal(
                                    dtCompleto.Rows[0]["TotalDeducciones"]);
                    decimal neto = Convert.ToDecimal(
                                    dtCompleto.Rows[0]["SalarioNeto"]);

                    _lblVDeducciones.Text = ded.ToString("C2");
                    _lblVNeto.Text = neto.ToString("C2");
                    _lblVNeto.ForeColor = neto >= 0
                                             ? ColorVerde : ColorEliminar;
                }
            }
            catch
            {
                _lblVDeducciones.Text = "RD$ 0.00";
                _lblVNeto.Text = total.ToString("C2");
            }

            _pnlVistaVolante.Visible = true;
        }

        private int ObtenerIdEmpleadoPorCodigo(string codigo)
        {
            // Helper para obtener Id cuando no viene en el DataTable
            DataTable dt = _cnEmp.ObtenerTodos();
            foreach (DataRow r in dt.Rows)
                if (r["CodigoEmpleado"].ToString() == codigo)
                    return Convert.ToInt32(r["Id"]);
            return 0;
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

                foreach (string col in new[] { "Id", "IdEmpleado" })
                    if (_grid.Columns.Contains(col))
                        _grid.Columns[col].Visible = false;

                RenombrarColumna("CodigoEmpleado", "Código");
                RenombrarColumna("Empleado", "Empleado");
                RenombrarColumna("Posicion", "Posición");
                RenombrarColumna("Sueldobase", "Sueldo Base");
                RenombrarColumna("Asignacion", "Asignaciones");
                RenombrarColumna("Total", "Total");
                RenombrarColumna("FechaEfectividad", "Período");
                RenombrarColumna("FechaRegistro", "Registro");

                // Formato moneda
                foreach (string col in new[] { "Sueldobase", "Asignacion", "Total" })
                    if (_grid.Columns.Contains(col))
                        _grid.Columns[col].DefaultCellStyle.Format = "N2";

                // Formato fecha
                foreach (string col in new[] { "FechaEfectividad", "FechaRegistro" })
                    if (_grid.Columns.Contains(col))
                        _grid.Columns[col].DefaultCellStyle.Format = "dd/MM/yyyy";

                AgregarColumnaBoton("Ver Volante", ColorCyan, "btnVer",
                                    ColorBotonTexto);
                AgregarColumnaBoton("Eliminar", ColorEliminar, "btnEliminar",
                                    ColorBotonTexto);
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al cargar volantes: " + ex.Message, false);
            }
        }

        private void AgregarColumnaBoton(string texto, Color color,
                                          string nombre, Color colorTexto)
        {
            if (_grid.Columns.Contains(nombre)) return;

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
            _grid.Columns.Add(col);
        }

        // ════════════════════════════════════════
        //  EVENTOS
        // ════════════════════════════════════════
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            _modoEdicion = false;
            _idSeleccionado = 0;
            _cmbEmpleado.SelectedIndex = -1;
            _dtpFecha.Value = DateTime.Today;
            _lblTitulo.Text = "Nuevo Registro de Nómina";
            _btnGuardar.Text = "Guardar";
            _pnlFormulario.Visible = true;
            _lblMensaje.Text = "";
            _pnlVistaVolante.Visible = false;
            ActualizarPosicionGrid();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (_cmbEmpleado.SelectedValue == null)
            {
                MostrarMensaje("Selecciona un empleado.", false);
                return;
            }

            int idEmpleado = Convert.ToInt32(_cmbEmpleado.SelectedValue);
            DateTime fecha = _dtpFecha.Value.Date;

            try
            {
                // Obtener datos del empleado para el salario base
                DataTable dtEmp = _cnEmp.ObtenerPorId(idEmpleado);
                if (dtEmp.Rows.Count == 0)
                {
                    MostrarMensaje("Empleado no encontrado.", false);
                    return;
                }

                decimal sueldoBase = Convert.ToDecimal(dtEmp.Rows[0]["SalarioBase"]);
                decimal asignacion = 0m;  // El trigger calculará las asignaciones
                decimal total = sueldoBase + asignacion;

                bool resultado = _cn.Insertar(idEmpleado, sueldoBase,
                                              asignacion, total, fecha);

                MostrarMensaje(
                    resultado
                        ? "Registro de nómina creado correctamente."
                        : "No se pudo crear el registro.",
                    resultado);

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

            string colName = _grid.Columns[e.ColumnIndex].Name;

            if (colName == "btnVer")
            {
                DataRow row = ((DataTable)_grid.DataSource).Rows[e.RowIndex];
                ActualizarVistaVolante(row);

                // Ajustar grid para dejar espacio al volante
                _grid.Size = new Size(
                    this.Width - 60 - _pnlVistaVolante.Width - 10,
                    _grid.Height);
            }
            else if (colName == "btnEliminar")
            {
                int id = Convert.ToInt32(_grid.Rows[e.RowIndex].Cells["Id"].Value);
                string emp = _grid.Rows[e.RowIndex].Cells["Empleado"].Value.ToString();
                string per = _grid.Rows[e.RowIndex].Cells["FechaEfectividad"]
                                  .Value.ToString();

                if (MessageBox.Show(
                        $"¿Eliminar el registro de \"{emp}\" del período {per}?",
                        "Confirmar", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        MostrarMensaje(
                            "Registro eliminado correctamente.", true);
                        _pnlVistaVolante.Visible = false;
                        _grid.Size = new Size(this.Width - 60, _grid.Height);
                        RefrescarGrid();
                    }
                    catch (Exception ex)
                    {
                        MostrarMensaje("Error: " + ex.Message, false);
                    }
                }
            }
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            // Vista previa de impresión básica
            string contenido =
                $"══════════════════════════════\n" +
                $"       TALENTBUS DB3\n" +
                $"      VOLANTE DE PAGO\n" +
                $"══════════════════════════════\n" +
                $"Código:     {_lblVCodigo.Text}\n" +
                $"Empleado:   {_lblVEmpleado.Text}\n" +
                $"Posición:   {_lblVPosicion.Text}\n" +
                $"Período:    {_lblVFecha.Text}\n" +
                $"──────────────────────────────\n" +
                $"INGRESOS\n" +
                $"Sueldo Base:   {_lblVSueldo.Text}\n" +
                $"Asignaciones:  {_lblVAsignacion.Text}\n" +
                $"Subtotal:      {_lblVTotalAsig.Text}\n" +
                $"──────────────────────────────\n" +
                $"DEDUCCIONES\n" +
                $"Total Ded.:    {_lblVDeducciones.Text}\n" +
                $"══════════════════════════════\n" +
                $"SALARIO NETO:  {_lblVNeto.Text}\n" +
                $"══════════════════════════════\n";

            MessageBox.Show(contenido, "Vista Previa — Volante de Pago",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ════════════════════════════════════════
        //  HELPERS
        // ════════════════════════════════════════
        private void OcultarFormulario()
        {
            _pnlFormulario.Visible = false;
            _modoEdicion = false;
            _idSeleccionado = 0;
            ActualizarPosicionGrid();
        }

        private void RefrescarGrid()
        {
            foreach (string col in new[] { "btnVer", "btnEliminar" })
                if (_grid.Columns.Contains(col))
                    _grid.Columns.Remove(col);
            CargarDatos();
        }

        private void ActualizarPosicionGrid()
        {
            if (_pnlFormulario.Visible)
            {
                _lblMensaje.Location = new Point(30, 210);
                _grid.Location = new Point(30, 240);
                _grid.Size = new Size(this.Width - 60,
                                               this.Height - 260);
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
                pts[i] = new PointF(
                    cx + r * (float)Math.Cos(angulo),
                    cy + r * (float)Math.Sin(angulo));
                angulo += paso;
            }

            using (SolidBrush b = new SolidBrush(color))
                g.FillPolygon(b, pts);
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
