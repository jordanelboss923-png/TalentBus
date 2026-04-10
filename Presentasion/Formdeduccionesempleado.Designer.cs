namespace Presentacion
{
    partial class FrmDeduccionesEmpleado
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTituloPagina = new System.Windows.Forms.Label();
            this.lblSubtituloPagina = new System.Windows.Forms.Label();
            this.btnNuevo = new System.Windows.Forms.Button();

            this.pnlFormulario = new System.Windows.Forms.Panel();
            this.lblTituloFormulario = new System.Windows.Forms.Label();

            // Fila 1: Empleado | Asignación
            this.lblLblEmpleado = new System.Windows.Forms.Label();
            this.pnlNombre = new System.Windows.Forms.Panel();
            this.txtEmpleado = new System.Windows.Forms.TextBox();
            this.lblLblDeduccion = new System.Windows.Forms.Label();
            this.pnlDeduccion = new System.Windows.Forms.Panel();
            this.txtDeduccion = new System.Windows.Forms.TextBox();

            // Fila 2: Tipo | Monto | Fecha
            this.lblLblTipo = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.lblLblMonto = new System.Windows.Forms.Label();
            this.pnlMonto = new System.Windows.Forms.Panel();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.lblLblFecha = new System.Windows.Forms.Label();
            this.dtpFechaEfectividad = new System.Windows.Forms.DateTimePicker();

            // Botones
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();

            this.lblMensaje = new System.Windows.Forms.Label();
            this.dgvDeducciones = new System.Windows.Forms.DataGridView();

            this.pnlHeader.SuspendLayout();
            this.pnlFormulario.SuspendLayout();
            this.pnlNombre.SuspendLayout();
            this.pnlDeduccion.SuspendLayout();
            this.pnlMonto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeducciones)).BeginInit();
            this.SuspendLayout();

            // ── pnlHeader ────────────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(18, 24, 48);
            this.pnlHeader.Controls.Add(this.lblTituloPagina);
            this.pnlHeader.Controls.Add(this.lblSubtituloPagina);
            this.pnlHeader.Controls.Add(this.btnNuevo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(900, 64);
            this.pnlHeader.TabIndex = 0;

            this.lblTituloPagina.AutoSize = true;
            this.lblTituloPagina.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTituloPagina.ForeColor = System.Drawing.Color.White;
            this.lblTituloPagina.Location = new System.Drawing.Point(28, 12);
            this.lblTituloPagina.Name = "lblTituloPagina";
            this.lblTituloPagina.TabIndex = 0;
            this.lblTituloPagina.Text = "Deducciones de Empleados";

            this.lblSubtituloPagina.AutoSize = true;
            this.lblSubtituloPagina.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSubtituloPagina.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblSubtituloPagina.Location = new System.Drawing.Point(30, 40);
            this.lblSubtituloPagina.Name = "lblSubtituloPagina";
            this.lblSubtituloPagina.TabIndex = 1;
            this.lblSubtituloPagina.Text = "Gestión de deducciones salariales";

            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNuevo.ForeColor = System.Drawing.Color.FromArgb(13, 17, 35);
            this.btnNuevo.Location = new System.Drawing.Point(762, 16);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(110, 34);
            this.btnNuevo.TabIndex = 2;
            this.btnNuevo.Text = "+ Nueva";
            this.btnNuevo.UseVisualStyleBackColor = false;

            // ── pnlFormulario ─────────────────────────────────────────────
            this.pnlFormulario.BackColor = System.Drawing.Color.FromArgb(18, 24, 48);
            this.pnlFormulario.Controls.Add(this.lblTituloFormulario);
            this.pnlFormulario.Controls.Add(this.lblLblEmpleado);
            this.pnlFormulario.Controls.Add(this.pnlNombre);
            this.pnlFormulario.Controls.Add(this.lblLblDeduccion);
            this.pnlFormulario.Controls.Add(this.pnlDeduccion);
            this.pnlFormulario.Controls.Add(this.lblLblTipo);
            this.pnlFormulario.Controls.Add(this.cmbTipo);
            this.pnlFormulario.Controls.Add(this.lblLblMonto);
            this.pnlFormulario.Controls.Add(this.pnlMonto);
            this.pnlFormulario.Controls.Add(this.lblLblFecha);
            this.pnlFormulario.Controls.Add(this.dtpFechaEfectividad);
            this.pnlFormulario.Controls.Add(this.btnGuardar);
            this.pnlFormulario.Controls.Add(this.btnCancelar);
            this.pnlFormulario.Controls.Add(this.btnEliminar);
            this.pnlFormulario.Location = new System.Drawing.Point(16, 72);
            this.pnlFormulario.Name = "pnlFormulario";
            this.pnlFormulario.Size = new System.Drawing.Size(868, 200);
            this.pnlFormulario.TabIndex = 1;
            this.pnlFormulario.Visible = false;

            // lblTituloFormulario
            this.lblTituloFormulario.AutoSize = true;
            this.lblTituloFormulario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTituloFormulario.ForeColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.lblTituloFormulario.Location = new System.Drawing.Point(18, 12);
            this.lblTituloFormulario.Name = "lblTituloFormulario";
            this.lblTituloFormulario.TabIndex = 0;
            this.lblTituloFormulario.Text = "Nueva Deducción de Empleado";

            // ── Fila 1: Empleado | Asignación ────────────────────────────
            this.lblLblEmpleado.AutoSize = true;
            this.lblLblEmpleado.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblLblEmpleado.ForeColor = System.Drawing.Color.White;
            this.lblLblEmpleado.Location = new System.Drawing.Point(18, 40);
            this.lblLblEmpleado.Name = "lblLblEmpleado";
            this.lblLblEmpleado.TabIndex = 1;
            this.lblLblEmpleado.Text = "Empleado";

            this.pnlNombre.BackColor = System.Drawing.Color.FromArgb(20, 28, 58);
            this.pnlNombre.Controls.Add(this.txtEmpleado);
            this.pnlNombre.Location = new System.Drawing.Point(18, 58);
            this.pnlNombre.Name = "pnlNombre";
            this.pnlNombre.Size = new System.Drawing.Size(280, 36);
            this.pnlNombre.TabIndex = 2;

            this.txtEmpleado.BackColor = System.Drawing.Color.FromArgb(20, 28, 58);
            this.txtEmpleado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmpleado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEmpleado.ForeColor = System.Drawing.Color.White;
            this.txtEmpleado.Location = new System.Drawing.Point(10, 7);
            this.txtEmpleado.Name = "txtEmpleado";
            this.txtEmpleado.ReadOnly = true;
            this.txtEmpleado.Size = new System.Drawing.Size(260, 21);
            this.txtEmpleado.TabIndex = 0;

            this.lblLblDeduccion.AutoSize = true;
            this.lblLblDeduccion.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblLblDeduccion.ForeColor = System.Drawing.Color.White;
            this.lblLblDeduccion.Location = new System.Drawing.Point(316, 40);
            this.lblLblDeduccion.Name = "lblLblDeduccion";
            this.lblLblDeduccion.TabIndex = 3;
            this.lblLblDeduccion.Text = "Deducción";

            this.pnlDeduccion.BackColor = System.Drawing.Color.FromArgb(20, 28, 58);
            this.pnlDeduccion.Controls.Add(this.txtDeduccion);
            this.pnlDeduccion.Location = new System.Drawing.Point(316, 58);
            this.pnlDeduccion.Name = "pnlDeduccion";
            this.pnlDeduccion.Size = new System.Drawing.Size(280, 36);
            this.pnlDeduccion.TabIndex = 4;

            this.txtDeduccion.BackColor = System.Drawing.Color.FromArgb(20, 28, 58);
            this.txtDeduccion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDeduccion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDeduccion.ForeColor = System.Drawing.Color.White;
            this.txtDeduccion.Location = new System.Drawing.Point(10, 7);
            this.txtDeduccion.Name = "txtDeduccion";
            this.txtDeduccion.ReadOnly = true;
            this.txtDeduccion.Size = new System.Drawing.Size(260, 21);
            this.txtDeduccion.TabIndex = 0;

            // ── Fila 2: Tipo | Monto | Fecha ─────────────────────────────
            this.lblLblTipo.AutoSize = true;
            this.lblLblTipo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblLblTipo.ForeColor = System.Drawing.Color.White;
            this.lblLblTipo.Location = new System.Drawing.Point(18, 106);
            this.lblLblTipo.Name = "lblLblTipo";
            this.lblLblTipo.TabIndex = 5;
            this.lblLblTipo.Text = "Tipo";

            this.cmbTipo.BackColor = System.Drawing.Color.FromArgb(20, 28, 58);
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTipo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbTipo.ForeColor = System.Drawing.Color.White;
            this.cmbTipo.Items.AddRange(new object[] { "Mensual", "Quincenal" });
            this.cmbTipo.Location = new System.Drawing.Point(18, 124);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(160, 23);
            this.cmbTipo.TabIndex = 6;
            this.cmbTipo.SelectedIndex = 0;

            this.lblLblMonto.AutoSize = true;
            this.lblLblMonto.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblLblMonto.ForeColor = System.Drawing.Color.White;
            this.lblLblMonto.Location = new System.Drawing.Point(196, 106);
            this.lblLblMonto.Name = "lblLblMonto";
            this.lblLblMonto.TabIndex = 7;
            this.lblLblMonto.Text = "Monto (RD$)";

            this.pnlMonto.BackColor = System.Drawing.Color.FromArgb(20, 28, 58);
            this.pnlMonto.Controls.Add(this.txtMonto);
            this.pnlMonto.Location = new System.Drawing.Point(196, 124);
            this.pnlMonto.Name = "pnlMonto";
            this.pnlMonto.Size = new System.Drawing.Size(180, 36);
            this.pnlMonto.TabIndex = 8;

            this.txtMonto.BackColor = System.Drawing.Color.FromArgb(20, 28, 58);
            this.txtMonto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMonto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMonto.ForeColor = System.Drawing.Color.White;
            this.txtMonto.Location = new System.Drawing.Point(10, 7);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(160, 21);
            this.txtMonto.TabIndex = 0;

            this.lblLblFecha.AutoSize = true;
            this.lblLblFecha.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblLblFecha.ForeColor = System.Drawing.Color.White;
            this.lblLblFecha.Location = new System.Drawing.Point(394, 106);
            this.lblLblFecha.Name = "lblLblFecha";
            this.lblLblFecha.TabIndex = 9;
            this.lblLblFecha.Text = "Fecha de Efectividad";

            this.dtpFechaEfectividad.CalendarForeColor = System.Drawing.Color.White;
            this.dtpFechaEfectividad.CalendarMonthBackground = System.Drawing.Color.FromArgb(18, 24, 48);
            this.dtpFechaEfectividad.CalendarTitleBackColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.dtpFechaEfectividad.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dtpFechaEfectividad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFechaEfectividad.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaEfectividad.Location = new System.Drawing.Point(394, 124);
            this.dtpFechaEfectividad.MaxDate = System.DateTime.Today;
            this.dtpFechaEfectividad.Name = "dtpFechaEfectividad";
            this.dtpFechaEfectividad.Size = new System.Drawing.Size(200, 23);
            this.dtpFechaEfectividad.TabIndex = 10;
            this.dtpFechaEfectividad.Value = System.DateTime.Today;

            // ── Botones ───────────────────────────────────────────────────
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(30, 80, 180);
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(612, 124);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 34);
            this.btnGuardar.TabIndex = 11;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;

            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(18, 24, 48);
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(30, 40, 80);
            this.btnCancelar.FlatAppearance.BorderSize = 1;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.btnCancelar.Location = new System.Drawing.Point(722, 124);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 34);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;

            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(160, 30, 50);
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.Enabled = false;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(612, 162);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(210, 28);
            this.btnEliminar.TabIndex = 13;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;

            // ── lblMensaje ────────────────────────────────────────────────
            this.lblMensaje.AutoSize = false;
            this.lblMensaje.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMensaje.ForeColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.lblMensaje.Location = new System.Drawing.Point(16, 80);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(700, 22);
            this.lblMensaje.TabIndex = 2;
            this.lblMensaje.Text = "";
            this.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // ── dgvDeducciones ───────────────────────────────────────────
            this.dgvDeducciones.AllowUserToAddRows = false;
            this.dgvDeducciones.AllowUserToDeleteRows = false;
            this.dgvDeducciones.BackgroundColor = System.Drawing.Color.FromArgb(18, 24, 48);
            this.dgvDeducciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDeducciones.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDeducciones.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDeducciones.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(20, 28, 58);
            this.dgvDeducciones.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.dgvDeducciones.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.dgvDeducciones.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(20, 28, 58);
            this.dgvDeducciones.ColumnHeadersHeight = 32;
            this.dgvDeducciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDeducciones.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(18, 24, 48);
            this.dgvDeducciones.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDeducciones.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.dgvDeducciones.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(25, 35, 70);
            this.dgvDeducciones.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.dgvDeducciones.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDeducciones.EnableHeadersVisualStyles = false;
            this.dgvDeducciones.GridColor = System.Drawing.Color.FromArgb(30, 40, 80);
            this.dgvDeducciones.Location = new System.Drawing.Point(16, 110);
            this.dgvDeducciones.MultiSelect = false;
            this.dgvDeducciones.Name = "dgvDeducciones";
            this.dgvDeducciones.ReadOnly = true;
            this.dgvDeducciones.RowHeadersVisible = false;
            this.dgvDeducciones.RowTemplate.Height = 32;
            this.dgvDeducciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDeducciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDeducciones.Size = new System.Drawing.Size(868, 400);
            this.dgvDeducciones.TabIndex = 3;
            this.dgvDeducciones.Anchor = System.Windows.Forms.AnchorStyles.Top |
                                          System.Windows.Forms.AnchorStyles.Left |
                                          System.Windows.Forms.AnchorStyles.Right |
                                          System.Windows.Forms.AnchorStyles.Bottom;

            // ── FrmDeduccionesEmpleado ───────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(13, 17, 35);
            this.ClientSize = new System.Drawing.Size(900, 537);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlFormulario);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.dgvDeducciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDeduccionesEmpleado";
            this.Text = "Deducciones de Empleados";
            this.Load += new System.EventHandler(this.FrmDeduccionesEmpleado_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFormulario.ResumeLayout(false);
            this.pnlFormulario.PerformLayout();
            this.pnlNombre.ResumeLayout(false);
            this.pnlNombre.PerformLayout();
            this.pnlDeduccion.ResumeLayout(false);
            this.pnlDeduccion.PerformLayout();
            this.pnlMonto.ResumeLayout(false);
            this.pnlMonto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeducciones)).EndInit();
            this.ResumeLayout(false);
        }

        // ── Declaraciones ──────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTituloPagina;
        private System.Windows.Forms.Label lblSubtituloPagina;
        private System.Windows.Forms.Button btnNuevo;

        private System.Windows.Forms.Panel pnlFormulario;
        private System.Windows.Forms.Label lblTituloFormulario;
        private System.Windows.Forms.Label lblLblEmpleado;
        private System.Windows.Forms.Panel pnlNombre;
        private System.Windows.Forms.TextBox txtEmpleado;
        private System.Windows.Forms.Label lblLblDeduccion;
        private System.Windows.Forms.Panel pnlDeduccion;
        private System.Windows.Forms.TextBox txtDeduccion;
        private System.Windows.Forms.Label lblLblTipo;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label lblLblMonto;
        private System.Windows.Forms.Panel pnlMonto;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label lblLblFecha;
        private System.Windows.Forms.DateTimePicker dtpFechaEfectividad;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEliminar;

        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.DataGridView dgvDeducciones;
    }
}
