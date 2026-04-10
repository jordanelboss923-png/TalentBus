using Negocios.Empleados;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmAsignacionesEmpleado : Form
    {
        // ── Colores del sistema ──────────────────────────────────────────────
        private readonly Color ColorFondo = Color.FromArgb(13, 17, 35);
        private readonly Color ColorPanel = Color.FromArgb(18, 24, 48);
        private readonly Color ColorCyan = Color.FromArgb(0, 210, 230);
        private readonly Color ColorTexto = Color.White;
        private readonly Color ColorSubTexto = Color.FromArgb(130, 150, 190);
        private readonly Color ColorBorde = Color.FromArgb(30, 40, 80);
        private readonly Color ColorInput = Color.FromArgb(20, 28, 58);
        private readonly Color ColorBotonAzul = Color.FromArgb(30, 80, 180);
        private readonly Color ColorBotonRojo = Color.FromArgb(160, 30, 50);

        // ── Negocio ──────────────────────────────────────────────────────────
        private readonly AsignacionesEmpleadoCN _cn = new AsignacionesEmpleadoCN();

        // ── Estado ───────────────────────────────────────────────────────────
        private int _idSeleccionado = -1;
        private bool _modoEdicion = false;

        public FrmAsignacionesEmpleado()
        {
            InitializeComponent();
            ConfigurarEventos();
            CargarDatos();
        }

        // ────────────────────────────────────────────────────────────────────
        // Eventos
        // ────────────────────────────────────────────────────────────────────
        private void ConfigurarEventos()
        {
            // Bordes de paneles
            pnlFormulario.Paint += (s, e) =>
            {
                using (Pen p = new Pen(ColorBorde, 1))
                    e.Graphics.DrawRectangle(p, 0, 0,
                        pnlFormulario.Width - 1, pnlFormulario.Height - 1);
            };

            pnlTabla.Paint += (s, e) =>
            {
                using (Pen p = new Pen(ColorBorde, 1))
                    e.Graphics.DrawRectangle(p, 0, 0,
                        pnlTabla.Width - 1, pnlTabla.Height - 1);
            };

            // Selección en el DataGridView
            dgvAsignaciones.SelectionChanged += DgvAsignaciones_SelectionChanged;

            // Botones
            btnGuardar.Click += BtnGuardar_Click;
            btnLimpiar.Click += BtnLimpiar_Click;
            btnEliminar.Click += BtnEliminar_Click;

            // Hover en botones
            ConfigurarHoverBoton(btnGuardar, ColorBotonAzul, Color.FromArgb(40, 100, 210));
            ConfigurarHoverBoton(btnLimpiar, ColorPanel, Color.FromArgb(30, 42, 80));
            ConfigurarHoverBoton(btnEliminar, ColorBotonRojo, Color.FromArgb(190, 45, 65));

            // Validación de monto: solo números decimales
            txtMonto.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                    e.Handled = true;
                if (e.KeyChar == '.' && txtMonto.Text.Contains("."))
                    e.Handled = true;
            };
        }

        private void ConfigurarHoverBoton(Button btn, Color normal, Color hover)
        {
            btn.BackColor = normal;
            btn.MouseEnter += (s, e) => btn.BackColor = hover;
            btn.MouseLeave += (s, e) => btn.BackColor = normal;
        }

        // ────────────────────────────────────────────────────────────────────
        // Carga de datos
        // ────────────────────────────────────────────────────────────────────
        private async void CargarDatos()
        {
            try
            {
                lblEstado.Text = "Cargando...";
                lblEstado.ForeColor = ColorSubTexto;

                DataTable dt = await _cn.ObtenerTodosAsync();
                dgvAsignaciones.DataSource = dt;

                EstilizarGrid();
                lblEstado.Text = $"{dt.Rows.Count} registro(s) encontrado(s)";
                lblEstado.ForeColor = ColorCyan;
            }
            catch (Exception ex)
            {
                lblEstado.Text = "Error al cargar datos";
                lblEstado.ForeColor = Color.FromArgb(220, 60, 60);
                MessageBox.Show($"Error al cargar asignaciones:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EstilizarGrid()
        {
            if (dgvAsignaciones.Columns.Count == 0) return;

            // Renombrar columnas
            var nombres = new (string col, string header, int ancho)[]
            {
                ("Id",               "ID",               50),
                ("Empleado",         "Empleado",         160),
                ("Asignacion",       "Asignación",       130),
                ("Tipo",             "Tipo",              80),
                ("Monto",            "Monto",             90),
                ("FechaEfectividad", "Fecha Efect.",     110),
                ("FechaRegistro",    "Fecha Registro",   120),
            };

            foreach (var (col, header, ancho) in nombres)
            {
                if (dgvAsignaciones.Columns.Contains(col))
                {
                    dgvAsignaciones.Columns[col].HeaderText = header;
                    dgvAsignaciones.Columns[col].Width = ancho;
                }
            }

            // Formatear columna Tipo: 1 → Mensual, 2 → Quincenal
            foreach (DataGridViewRow row in dgvAsignaciones.Rows)
            {
                if (row.Cells["Tipo"].Value != null)
                {
                    int tipo = Convert.ToInt32(row.Cells["Tipo"].Value);
                    row.Cells["Tipo"].Value = tipo == 1 ? "Mensual" : "Quincenal";
                }
            }
        }

        // ────────────────────────────────────────────────────────────────────
        // Selección en el grid → llenar formulario
        // ────────────────────────────────────────────────────────────────────
        private void DgvAsignaciones_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAsignaciones.CurrentRow == null) return;

            DataGridViewRow row = dgvAsignaciones.CurrentRow;

            _idSeleccionado = Convert.ToInt32(row.Cells["Id"].Value);
            _modoEdicion = true;

            // Llenar campos
            txtEmpleado.Text = row.Cells["Empleado"].Value?.ToString() ?? "";
            txtAsignacion.Text = row.Cells["Asignacion"].Value?.ToString() ?? "";

            string tipoStr = row.Cells["Tipo"].Value?.ToString() ?? "";
            cmbTipo.SelectedIndex = tipoStr == "Mensual" ? 0 : 1;

            if (decimal.TryParse(row.Cells["Monto"].Value?.ToString(), out decimal monto))
                txtMonto.Text = monto.ToString("F2");

            if (DateTime.TryParse(row.Cells["FechaEfectividad"].Value?.ToString(), out DateTime fecha))
                dtpFechaEfectividad.Value = fecha;

            // Actualizar UI modo edición
            btnGuardar.Text = "Actualizar";
            btnEliminar.Enabled = true;
            lblTituloFormulario.Text = "Editar Asignación";
        }

        // ────────────────────────────────────────────────────────────────────
        // Guardar (Insertar o Actualizar)
        // ────────────────────────────────────────────────────────────────────
        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario()) return;

            try
            {
                btnGuardar.Enabled = false;
                lblEstado.Text = _modoEdicion ? "Actualizando..." : "Guardando...";
                lblEstado.ForeColor = ColorSubTexto;

                // Obtener valores del formulario
                // Nota: IdAsignacion e IdEmpleado deben venir de ComboBoxes enlazados a BD.
                // Por ahora se usan los índices seleccionados + 1 como placeholder.
                // Reemplaza con cmbEmpleado.SelectedValue e cmbAsignacion.SelectedValue
                // cuando los ComboBoxes estén enlazados a la tabla correspondiente.
                int idAsignacion = 1; // TODO: reemplazar con cmbAsignacion.SelectedValue
                int idEmpleado = 1; // TODO: reemplazar con cmbEmpleado.SelectedValue
                int idSubtotal = 1; // TODO: reemplazar con el subtotal calculado
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
                    lblEstado.Text = _modoEdicion ? "Asignación actualizada correctamente." : "Asignación registrada correctamente.";
                    lblEstado.ForeColor = ColorCyan;
                    LimpiarFormulario();
                    CargarDatos();
                }
                else
                {
                    lblEstado.Text = "No se pudo guardar el registro.";
                    lblEstado.ForeColor = Color.FromArgb(220, 60, 60);
                }
            }
            catch (ArgumentException ex)
            {
                lblEstado.Text = "Datos inválidos.";
                lblEstado.ForeColor = Color.FromArgb(220, 60, 60);
                MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException ex)
            {
                lblEstado.Text = "Operación no permitida.";
                lblEstado.ForeColor = Color.FromArgb(220, 60, 60);
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                lblEstado.Text = "Error inesperado.";
                lblEstado.ForeColor = Color.FromArgb(220, 60, 60);
                MessageBox.Show($"Error:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGuardar.Enabled = true;
            }
        }

        // ────────────────────────────────────────────────────────────────────
        // Eliminar
        // ────────────────────────────────────────────────────────────────────
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (_idSeleccionado <= 0) return;

            var confirmacion = MessageBox.Show(
                $"¿Estás seguro de que deseas eliminar esta asignación (ID: {_idSeleccionado})?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacion != DialogResult.Yes) return;

            try
            {
                // Nota: eliminar requiere método en la capa de datos.
                // Implementar _cn.Eliminar(_idSeleccionado) cuando esté disponible.
                MessageBox.Show("Funcionalidad de eliminación pendiente de implementar en la capa de negocio.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ────────────────────────────────────────────────────────────────────
        // Limpiar formulario
        // ────────────────────────────────────────────────────────────────────
        private void BtnLimpiar_Click(object sender, EventArgs e) => LimpiarFormulario();

        private void LimpiarFormulario()
        {
            _idSeleccionado = -1;
            _modoEdicion = false;

            txtEmpleado.Text = "";
            txtAsignacion.Text = "";
            txtMonto.Text = "";
            cmbTipo.SelectedIndex = 0;
            dtpFechaEfectividad.Value = DateTime.Today;

            btnGuardar.Text = "Guardar";
            btnEliminar.Enabled = false;
            lblTituloFormulario.Text = "Nueva Asignación";

            dgvAsignaciones.ClearSelection();
        }

        // ────────────────────────────────────────────────────────────────────
        // Validación del formulario
        // ────────────────────────────────────────────────────────────────────
        private bool ValidarFormulario()
        {
            if (string.IsNullOrWhiteSpace(txtMonto.Text))
            {
                MostrarError("El campo Monto es obligatorio.");
                txtMonto.Focus();
                return false;
            }

            if (!decimal.TryParse(txtMonto.Text, out decimal monto) || monto <= 0)
            {
                MostrarError("El monto debe ser un número mayor a cero.");
                txtMonto.Focus();
                return false;
            }

            if (cmbTipo.SelectedIndex < 0)
            {
                MostrarError("Debe seleccionar un tipo de asignación.");
                cmbTipo.Focus();
                return false;
            }

            if (dtpFechaEfectividad.Value.Date > DateTime.Today)
            {
                MostrarError("La fecha de efectividad no puede ser futura.");
                dtpFechaEfectividad.Focus();
                return false;
            }

            return true;
        }

        private void MostrarError(string mensaje)
        {
            lblEstado.Text = mensaje;
            lblEstado.ForeColor = Color.FromArgb(220, 60, 60);
        }

        private void FrmAsignacionesEmpleado_Load(object sender, EventArgs e) { }
    }
}