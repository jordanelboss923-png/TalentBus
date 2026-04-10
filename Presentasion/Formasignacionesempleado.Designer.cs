namespace Presentacion
{
    partial class FrmAsignacionesEmpleado
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.lblIcono = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.pnlFormulario = new System.Windows.Forms.Panel();
            this.lblTituloFormulario = new System.Windows.Forms.Label();
            this.lblEmpleado = new System.Windows.Forms.Label();
            this.txtEmpleado = new System.Windows.Forms.TextBox();
            this.lblAsignacion = new System.Windows.Forms.Label();
            this.txtAsignacion = new System.Windows.Forms.TextBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.lblMonto = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFechaEfectividad = new System.Windows.Forms.DateTimePicker();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.pnlTabla = new System.Windows.Forms.Panel();
            this.lblTituloTabla = new System.Windows.Forms.Label();
            this.dgvAsignaciones = new System.Windows.Forms.DataGridView();
            this.lblEstado = new System.Windows.Forms.Label();
            this.pnlTitulo.SuspendLayout();
            this.pnlFormulario.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            this.pnlTabla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsignaciones)).BeginInit();
            this.SuspendLayout();

            // ── pnlTitulo ────────────────────────────────────────────────────
            this.pnlTitulo.BackColor = System.Drawing.Color.FromArgb(18, 24, 48);
            this.pnlTitulo.Controls.Add(this.lblIcono);
            this.pnlTitulo.Controls.Add(this.lblTitulo);
            this.pnlTitulo.Controls.Add(this.lblSubtitulo);
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(900, 64);
            this.pnlTitulo.TabIndex = 0;

            // lblIcono
            this.lblIcono.AutoSize = true;
            this.lblIcono.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.lblIcono.ForeColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.lblIcono.Location = new System.Drawing.Point(20, 12);
            this.lblIcono.Name = "lblIcono";
            this.lblIcono.Size = new System.Drawing.Size(36, 36);
            this.lblIcono.TabIndex = 0;
            this.lblIcono.Text = "☰";

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(62, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(220, 25);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Asignaciones de Empleados";

            // lblSubtitulo
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblSubtitulo.Location = new System.Drawing.Point(64, 38);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(180, 15);
            this.lblSubtitulo.TabIndex = 2;
            this.lblSubtitulo.Text = "Gestión de asignaciones salariales";

            // ── pnlFormulario ─────────────────────────────────────────────────
            this.pnlFormulario.BackColor = System.Drawing.Color.FromArgb(18, 24, 48);
            this.pnlFormulario.Controls.Add(this.lblTituloFormulario);
            this.pnlFormulario.Controls.Add(this.lblEmpleado);
            this.pnlFormulario.Controls.Add(this.txtEmpleado);
            this.pnlFormulario.Controls.Add(this.lblAsignacion);
            this.pnlFormulario.Controls.Add(this.txtAsignacion);
            this.pnlFormulario.Controls.Add(this.lblTipo);
            this.pnlFormulario.Controls.Add(this.cmbTipo);
            this.pnlFormulario.Controls.Add(this.lblMonto);
            this.pnlFormulario.Controls.Add(this.txtMonto);
            this.pnlFormulario.Controls.Add(this.lblFecha);
            this.pnlFormulario.Controls.Add(this.dtpFechaEfectividad);
            this.pnlFormulario.Controls.Add(this.pnlBotones);
            this.pnlFormulario.Location = new System.Drawing.Point(16, 80);
            this.pnlFormulario.Name = "pnlFormulario";
            this.pnlFormulario.Size = new System.Drawing.Size(280, 460);
            this.pnlFormulario.TabIndex = 1;

            // lblTituloFormulario
            this.lblTituloFormulario.AutoSize = true;
            this.lblTituloFormulario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTituloFormulario.ForeColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.lblTituloFormulario.Location = new System.Drawing.Point(14, 14);
            this.lblTituloFormulario.Name = "lblTituloFormulario";
            this.lblTituloFormulario.TabIndex = 0;
            this.lblTituloFormulario.Text = "Nueva Asignación";

            // lblEmpleado
            this.lblEmpleado.AutoSize = true;
            this.lblEmpleado.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblEmpleado.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblEmpleado.Location = new System.Drawing.Point(14, 48);
            this.lblEmpleado.Name = "lblEmpleado";
            this.lblEmpleado.TabIndex = 1;
            this.lblEmpleado.Text = "Empleado";

            // txtEmpleado
            this.txtEmpleado.BackColor = System.Drawing.Color.FromArgb(20, 28, 58);
            this.txtEmpleado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmpleado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEmpleado.ForeColor = System.Drawing.Color.White;
            this.txtEmpleado.Location = new System.Drawing.Point(14, 66);
            this.txtEmpleado.Name = "txtEmpleado";
            this.txtEmpleado.ReadOnly = true;
            this.txtEmpleado.Size = new System.Drawing.Size(252, 23);
            this.txtEmpleado.TabIndex = 2;

            // lblAsignacion
            this.lblAsignacion.AutoSize = true;
            this.lblAsignacion.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblAsignacion.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblAsignacion.Location = new System.Drawing.Point(14, 100);
            this.lblAsignacion.Name = "lblAsignacion";
            this.lblAsignacion.TabIndex = 3;
            this.lblAsignacion.Text = "Asignación";

            // txtAsignacion
            this.txtAsignacion.BackColor = System.Drawing.Color.FromArgb(20, 28, 58);
            this.txtAsignacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAsignacion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAsignacion.ForeColor = System.Drawing.Color.White;
            this.txtAsignacion.Location = new System.Drawing.Point(14, 118);
            this.txtAsignacion.Name = "txtAsignacion";
            this.txtAsignacion.ReadOnly = true;
            this.txtAsignacion.Size = new System.Drawing.Size(252, 23);
            this.txtAsignacion.TabIndex = 4;

            // lblTipo
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblTipo.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblTipo.Location = new System.Drawing.Point(14, 152);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.TabIndex = 5;
            this.lblTipo.Text = "Tipo de Asignación";

            // cmbTipo
            this.cmbTipo.BackColor = System.Drawing.Color.FromArgb(20, 28, 58);
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTipo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbTipo.ForeColor = System.Drawing.Color.White;
            this.cmbTipo.Items.AddRange(new object[] { "Mensual", "Quincenal" });
            this.cmbTipo.Location = new System.Drawing.Point(14, 170);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(252, 23);
            this.cmbTipo.TabIndex = 6;
            this.cmbTipo.SelectedIndex = 0;

            // lblMonto
            this.lblMonto.AutoSize = true;
            this.lblMonto.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblMonto.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblMonto.Location = new System.Drawing.Point(14, 204);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.TabIndex = 7;
            this.lblMonto.Text = "Monto (RD$)";

            // txtMonto
            this.txtMonto.BackColor = System.Drawing.Color.FromArgb(20, 28, 58);
            this.txtMonto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMonto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMonto.ForeColor = System.Drawing.Color.White;
            this.txtMonto.Location = new System.Drawing.Point(14, 222);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(252, 23);
            this.txtMonto.TabIndex = 8;

            // lblFecha
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblFecha.Location = new System.Drawing.Point(14, 256);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.TabIndex = 9;
            this.lblFecha.Text = "Fecha de Efectividad";

            // dtpFechaEfectividad
            this.dtpFechaEfectividad.CalendarForeColor = System.Drawing.Color.White;
            this.dtpFechaEfectividad.CalendarMonthBackground = System.Drawing.Color.FromArgb(18, 24, 48);
            this.dtpFechaEfectividad.CalendarTitleBackColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.dtpFechaEfectividad.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dtpFechaEfectividad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFechaEfectividad.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaEfectividad.Location = new System.Drawing.Point(14, 274);
            this.dtpFechaEfectividad.MaxDate = System.DateTime.Today;
            this.dtpFechaEfectividad.Name = "dtpFechaEfectividad";
            this.dtpFechaEfectividad.Size = new System.Drawing.Size(252, 23);
            this.dtpFechaEfectividad.TabIndex = 10;
            this.dtpFechaEfectividad.Value = System.DateTime.Today;

            // ── pnlBotones ────────────────────────────────────────────────────
            this.pnlBotones.BackColor = System.Drawing.Color.Transparent;
            this.pnlBotones.Controls.Add(this.btnGuardar);
            this.pnlBotones.Controls.Add(this.btnLimpiar);
            this.pnlBotones.Controls.Add(this.btnEliminar);
            this.pnlBotones.Location = new System.Drawing.Point(14, 316);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(252, 120);
            this.pnlBotones.TabIndex = 11;

            // btnGuardar
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(30, 80, 180);
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(0, 0);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(252, 34);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;

            // btnLimpiar
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(18, 24, 48);
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(30, 40, 80);
            this.btnLimpiar.FlatAppearance.BorderSize = 1;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLimpiar.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.btnLimpiar.Location = new System.Drawing.Point(0, 44);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(252, 34);
            this.btnLimpiar.TabIndex = 1;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;

            // btnEliminar
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(160, 30, 50);
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.Enabled = false;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(0, 84);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(252, 34);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;

            // ── pnlTabla ─────────────────────────────────────────────────────
            this.pnlTabla.BackColor = System.Drawing.Color.FromArgb(18, 24, 48);
            this.pnlTabla.Controls.Add(this.lblTituloTabla);
            this.pnlTabla.Controls.Add(this.dgvAsignaciones);
            this.pnlTabla.Controls.Add(this.lblEstado);
            this.pnlTabla.Location = new System.Drawing.Point(312, 80);
            this.pnlTabla.Name = "pnlTabla";
            this.pnlTabla.Size = new System.Drawing.Size(572, 460);
            this.pnlTabla.TabIndex = 2;

            // lblTituloTabla
            this.lblTituloTabla.AutoSize = true;
            this.lblTituloTabla.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTituloTabla.ForeColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.lblTituloTabla.Location = new System.Drawing.Point(14, 14);
            this.lblTituloTabla.Name = "lblTituloTabla";
            this.lblTituloTabla.TabIndex = 0;
            this.lblTituloTabla.Text = "Listado de Asignaciones";

            // dgvAsignaciones
            this.dgvAsignaciones.AllowUserToAddRows = false;
            this.dgvAsignaciones.AllowUserToDeleteRows = false;
            this.dgvAsignaciones.BackgroundColor = System.Drawing.Color.FromArgb(13, 17, 35);
            this.dgvAsignaciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAsignaciones.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAsignaciones.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;

            this.dgvAsignaciones.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(18, 24, 48);
            this.dgvAsignaciones.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.dgvAsignaciones.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.dgvAsignaciones.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(18, 24, 48);
            this.dgvAsignaciones.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.dgvAsignaciones.ColumnHeadersHeight = 32;
            this.dgvAsignaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            this.dgvAsignaciones.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(13, 17, 35);
            this.dgvAsignaciones.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvAsignaciones.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.dgvAsignaciones.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(25, 35, 70);
            this.dgvAsignaciones.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.dgvAsignaciones.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;

            this.dgvAsignaciones.EnableHeadersVisualStyles = false;
            this.dgvAsignaciones.GridColor = System.Drawing.Color.FromArgb(30, 40, 80);
            this.dgvAsignaciones.Location = new System.Drawing.Point(14, 42);
            this.dgvAsignaciones.MultiSelect = false;
            this.dgvAsignaciones.Name = "dgvAsignaciones";
            this.dgvAsignaciones.ReadOnly = true;
            this.dgvAsignaciones.RowHeadersVisible = false;
            this.dgvAsignaciones.RowTemplate.Height = 28;
            this.dgvAsignaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAsignaciones.Size = new System.Drawing.Size(544, 390);
            this.dgvAsignaciones.TabIndex = 1;

            // lblEstado
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblEstado.Location = new System.Drawing.Point(14, 440);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.TabIndex = 2;
            this.lblEstado.Text = "Listo";

            // ── FrmAsignacionesEmpleado ───────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(13, 17, 35);
            this.ClientSize = new System.Drawing.Size(900, 557);
            this.Controls.Add(this.pnlTitulo);
            this.Controls.Add(this.pnlFormulario);
            this.Controls.Add(this.pnlTabla);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAsignacionesEmpleado";
            this.Text = "Asignaciones de Empleados";
            this.Load += new System.EventHandler(this.FrmAsignacionesEmpleado_Load);

            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.pnlFormulario.ResumeLayout(false);
            this.pnlFormulario.PerformLayout();
            this.pnlBotones.ResumeLayout(false);
            this.pnlTabla.ResumeLayout(false);
            this.pnlTabla.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsignaciones)).EndInit();
            this.ResumeLayout(false);
        }

        // ── Declaraciones ────────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label lblIcono;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;

        private System.Windows.Forms.Panel pnlFormulario;
        private System.Windows.Forms.Label lblTituloFormulario;
        private System.Windows.Forms.Label lblEmpleado;
        private System.Windows.Forms.TextBox txtEmpleado;
        private System.Windows.Forms.Label lblAsignacion;
        private System.Windows.Forms.TextBox txtAsignacion;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFechaEfectividad;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnEliminar;

        private System.Windows.Forms.Panel pnlTabla;
        private System.Windows.Forms.Label lblTituloTabla;
        private System.Windows.Forms.DataGridView dgvAsignaciones;
        private System.Windows.Forms.Label lblEstado;
    }
}