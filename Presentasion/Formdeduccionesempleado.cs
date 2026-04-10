using Negocios.Empleados;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmDeduccionesEmpleado : Form
    {
        // ─── Colores ────────────────────────────────────────────────────────
        private readonly Color ColorFondo = Color.FromArgb(13, 17, 35);
        private readonly Color ColorPanel = Color.FromArgb(18, 24, 48);
        private readonly Color ColorCyan = Color.FromArgb(0, 210, 230);
        private readonly Color ColorTexto = Color.White;
        private readonly Color ColorSubTexto = Color.FromArgb(130, 150, 190);
        private readonly Color ColorInput = Color.FromArgb(20, 28, 58);
        private readonly Color ColorBorde = Color.FromArgb(30, 40, 80);
        private readonly Color ColorBotonAzul = Color.FromArgb(30, 80, 180);
        private readonly Color ColorBotonRojo = Color.FromArgb(160, 30, 50);
        private readonly Color ColorEliminar = Color.FromArgb(255, 80, 80);
        private readonly Color ColorVerde = Color.FromArgb(39, 201, 63);

        // ─── Negocio ────────────────────────────────────────────────────────
        private readonly DeduccionesEmpleadoCN _cn = new DeduccionesEmpleadoCN();

        // ─── Estado ─────────────────────────────────────────────────────────
        private int _idSeleccionado = -1;
        private bool _modoEdicion = false;

        public FrmDeduccionesEmpleado()
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
            pnlDeduccion.Paint += PnlInput_Paint;
            pnlMonto.Paint += PnlInput_Paint;

            // Posicionar btnNuevo dinámicamente a la derecha del header
            pnlHeader.Resize += (s, e) => btnNuevo.Left = pnlHeader.Width - btnNuevo.Width - 20;
            pnlHeader.HandleCreated += (s, e) => btnNuevo.Left = pnlHeader.Width - btnNuevo.Width - 20;

            // Botones
            btnNuevo.Click += BtnNuevo_Click;
            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar.Click += BtnCancelar_Click;
            btnEliminar.Click += BtnEliminar_Click;

            // Grid
            dgvDeducciones.CellClick += Grid_CellClick;

            // Hover
            ConfigurarHover(btnNuevo, ColorCyan, Color.FromArgb(0, 185, 205));
            ConfigurarHover(btnGuardar, ColorBotonAzul, Color.FromArgb(40, 100, 210));
            ConfigurarHover(btnCancelar, ColorPanel, Color.FromArgb(30, 42, 80));
            ConfigurarHover(btnEliminar, ColorBotonRojo, Color.FromArgb(190, 45, 65));

            // Regiones redondeadas
            foreach (Button btn in new[] { btnNuevo, btnGuardar, btnCancelar, btnEliminar })
            {
                btn.Region = CrearRegionRedondeada(btn.Size, 6);
                btn.SizeChanged += (s, e) =>
                    ((Button)s).Region = CrearRegionRedondeada(((Button)s).Size, 6);
            }

            // Solo números decimales en monto
            txtMonto.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                    e.Handled = true;
                if (e.KeyChar == '.' && txtMonto.Text.Contains("."))
                    e.Handled = true;
            };
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
        private async void CargarDatos()
        {
            try
            {
                lblMensaje.Text = "Cargando...";
                lblMensaje.ForeColor = ColorSubTexto;

                DataTable dt = await _cn.ObtenerTodosAsync();
                dgvDeducciones.DataSource = null;
                dgvDeducciones.DataSource = dt;

                if (dgvDeducciones.Columns.Contains("Id"))
                    dgvDeducciones.Columns["Id"].Visible = false;

                RenombrarColumna("Empleado", "Empleado");
                RenombrarColumna("Deduccion", "Deducción");
                RenombrarColumna("Tipo", "Tipo");
                RenombrarColumna("Monto", "Monto");
                RenombrarColumna("FechaEfectividad", "Fecha Efect.");
                RenombrarColumna("FechaRegistro", "Fecha Registro");

                if (dgvDeducciones.Columns.Contains("Monto"))
                    dgvDeducciones.Columns["Monto"].DefaultCellStyle.Format = "N2";

                // Formatear Tipo
                foreach (DataGridViewRow row in dgvDeducciones.Rows)
                {
                    if (row.Cells["Tipo"].Value != null)
                    {
                        int tipo = Convert.ToInt32(row.Cells["Tipo"].Value);
                        row.Cells["Tipo"].Value = tipo == 1 ? "Mensual" : "Quincenal";
                    }
                }

                AgregarColumnaBoton("Editar", Color.FromArgb(255, 180, 0), "btnEditar", Color.FromArgb(13, 17, 35));
                AgregarColumnaBoton("Eliminar", ColorEliminar, "btnEliminar", ColorTexto);

                lblMensaje.Text = $"{dt.Rows.Count} registro(s) encontrado(s)";
                lblMensaje.ForeColor = ColorCyan;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al cargar datos";
                lblMensaje.ForeColor = Color.FromArgb(220, 60, 60);
                MessageBox.Show($"Error al cargar asignaciones:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregarColumnaBoton(string texto, Color color, string nombre, Color colorTexto)
        {
            if (dgvDeducciones.Columns.Contains(nombre)) return;
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
            col.DefaultCellStyle.ForeColor = colorTexto;
            col.DefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            col.DefaultCellStyle.SelectionBackColor = color;
            col.DefaultCellStyle.SelectionForeColor = colorTexto;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDeducciones.Columns.Add(col);
        }

        // ══════════════════════════════════════════════════════════════════
        //  EVENTOS DE BOTONES
        // ══════════════════════════════════════════════════════════════════
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            _modoEdicion = false;
            _idSeleccionado = -1;
            LimpiarFormulario();
            lblTituloFormulario.Text = "Nueva Deducción de Empleado";
            btnGuardar.Text = "Guardar";
            btnEliminar.Enabled = false;
            pnlFormulario.Visible = true;
            lblMensaje.Text = "";
            txtMonto.Focus();
            ActualizarPosicionGrid();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            OcultarFormulario();
            lblMensaje.Text = "";
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string colName = dgvDeducciones.Columns[e.ColumnIndex].Name;
            DataRow row = ((DataTable)dgvDeducciones.DataSource).Rows[e.RowIndex];

            if (colName == "btnEditar")
            {
                _idSeleccionado = Convert.ToInt32(row["Id"]);
                _modoEdicion = true;

                txtEmpleado.Text = row["Empleado"] == DBNull.Value ? "" : row["Empleado"].ToString();
                txtDeduccion.Text = row["Deduccion"] == DBNull.Value ? "" : row["Deduccion"].ToString();

                string tipoStr = row["Tipo"].ToString();
                cmbTipo.SelectedIndex = tipoStr == "Mensual" ? 0 : 1;

                if (decimal.TryParse(row["Monto"].ToString(), out decimal monto))
                    txtMonto.Text = monto.ToString("F2");

                if (DateTime.TryParse(row["FechaEfectividad"].ToString(), out DateTime fecha))
                    dtpFechaEfectividad.Value = fecha;

                lblTituloFormulario.Text = "Editar Deducción de Empleado";
                btnGuardar.Text = "Actualizar";
                btnEliminar.Enabled = true;
                pnlFormulario.Visible = true;
                lblMensaje.Text = "";
                ActualizarPosicionGrid();
            }
            else if (colName == "btnEliminar")
            {
                int id = Convert.ToInt32(row["Id"]);
                if (MessageBox.Show(
                        $"¿Eliminar esta deducción (ID: {id})?",
                        "Confirmar eliminación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    // TODO: implementar _cn.Eliminar(id)
                    MostrarMensaje("Funcionalidad de eliminación pendiente.", false);
                }
            }
        }

        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario()) return;

            try
            {
                btnGuardar.Enabled = false;
                lblMensaje.Text = _modoEdicion ? "Actualizando..." : "Guardando...";
                lblMensaje.ForeColor = ColorSubTexto;

                int idAsignacion = 1; // TODO: reemplazar con combo enlazado a BD
                int idEmpleado = 1; // TODO: reemplazar con combo enlazado a BD
                int idSubtotal = 1; // TODO: reemplazar con subtotal calculado
                int tipo = cmbTipo.SelectedIndex + 1;
                decimal monto = decimal.Parse(txtMonto.Text);
                DateTime fecha = dtpFechaEfectividad.Value.Date;

                bool resultado;
                if (_modoEdicion)
                    resultado = await _cn.ActualizarAsync(_idSeleccionado, idAsignacion, idEmpleado,
                                                          idSubtotal, tipo, monto, fecha);
                else
                    resultado = await _cn.InsertarAsync(idAsignacion, idEmpleado,
                                                        idSubtotal, tipo, monto, fecha);

                if (resultado)
                {
                    MostrarMensaje(_modoEdicion
                        ? "Asignación actualizada correctamente."
                        : "Asignación registrada correctamente.", true);
                    OcultarFormulario();
                    RefrescarGrid();
                }
                else
                {
                    MostrarMensaje("No se pudo guardar el registro.", false);
                }
            }
            catch (ArgumentException ex)
            {
                MostrarMensaje("Datos inválidos.", false);
                MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException ex)
            {
                MostrarMensaje("Operación no permitida.", false);
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error inesperado.", false);
                MessageBox.Show($"Error:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGuardar.Enabled = true;
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (_idSeleccionado <= 0) return;
            if (MessageBox.Show(
                    $"¿Eliminar esta deducción (ID: {_idSeleccionado})?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // TODO: implementar _cn.Eliminar(_idSeleccionado)
                MostrarMensaje("Funcionalidad de eliminación pendiente.", false);
            }
        }

        // ══════════════════════════════════════════════════════════════════
        //  HELPERS
        // ══════════════════════════════════════════════════════════════════
        private void OcultarFormulario()
        {
            pnlFormulario.Visible = false;
            _modoEdicion = false;
            _idSeleccionado = -1;
            LimpiarFormulario();
            ActualizarPosicionGrid();
        }

        private void LimpiarFormulario()
        {
            txtEmpleado.Text = "";
            txtDeduccion.Text = "";
            txtMonto.Text = "";
            cmbTipo.SelectedIndex = 0;
            dtpFechaEfectividad.Value = DateTime.Today;
            btnGuardar.Text = "Guardar";
            btnEliminar.Enabled = false;
            lblTituloFormulario.Text = "Nueva Deducción de Empleado";
            dgvDeducciones.ClearSelection();
        }

        private void RefrescarGrid()
        {
            foreach (string col in new[] { "btnEditar", "btnEliminar" })
                if (dgvDeducciones.Columns.Contains(col))
                    dgvDeducciones.Columns.Remove(col);
            CargarDatos();
        }

        private void ActualizarPosicionGrid()
        {
            if (pnlFormulario.Visible)
            {
                lblMensaje.Location = new Point(lblMensaje.Left, 280);
                dgvDeducciones.Location = new Point(dgvDeducciones.Left, 310);
            }
            else
            {
                lblMensaje.Location = new Point(lblMensaje.Left, 80);
                dgvDeducciones.Location = new Point(dgvDeducciones.Left, 110);
            }
        }

        private bool ValidarFormulario()
        {
            if (string.IsNullOrWhiteSpace(txtMonto.Text))
            { MostrarMensaje("El campo Monto es obligatorio.", false); txtMonto.Focus(); return false; }

            if (!decimal.TryParse(txtMonto.Text, out decimal m) || m <= 0)
            { MostrarMensaje("El monto debe ser mayor a cero.", false); txtMonto.Focus(); return false; }

            if (cmbTipo.SelectedIndex < 0)
            { MostrarMensaje("Debe seleccionar un tipo de deducción.", false); cmbTipo.Focus(); return false; }

            if (dtpFechaEfectividad.Value.Date > DateTime.Today)
            { MostrarMensaje("La fecha de efectividad no puede ser futura.", false); dtpFechaEfectividad.Focus(); return false; }

            return true;
        }

        private void MostrarMensaje(string texto, bool exito)
        {
            lblMensaje.Text = exito ? "✓  " + texto : "✗  " + texto;
            lblMensaje.ForeColor = exito ? ColorVerde : Color.FromArgb(220, 60, 60);
        }

        private void RenombrarColumna(string nombre, string encabezado)
        {
            if (dgvDeducciones.Columns.Contains(nombre))
                dgvDeducciones.Columns[nombre].HeaderText = encabezado;
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

        private void FrmDeduccionesEmpleado_Load(object sender, EventArgs e) { }
    }
}