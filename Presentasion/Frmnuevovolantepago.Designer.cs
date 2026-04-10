namespace Presentacion
{
    partial class FrmNuevoVolantePago
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();

            this.pnlCuerpo = new System.Windows.Forms.Panel();

            // Empleado
            this.lblLblEmpleado = new System.Windows.Forms.Label();
            this.cmbEmpleado = new System.Windows.Forms.ComboBox();
            this.lblInfoEmpleado = new System.Windows.Forms.Label();

            // Período (SalarioST)
            this.lblLblPeriodo = new System.Windows.Forms.Label();
            this.cmbPeriodo = new System.Windows.Forms.ComboBox();

            // Deducción
            this.lblLblDeduccion = new System.Windows.Forms.Label();
            this.cmbDeduccion = new System.Windows.Forms.ComboBox();

            // Fecha
            this.lblLblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();

            // Separador y preview
            this.sep1 = new System.Windows.Forms.Panel();
            this.lblPreviewSubtotal = new System.Windows.Forms.Label();
            this.lblPreviewDeduccion = new System.Windows.Forms.Label();
            this.sep2 = new System.Windows.Forms.Panel();
            this.lblPreviewTotal = new System.Windows.Forms.Label();

            // Estado y botones
            this.lblEstado = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlCuerpo.SuspendLayout();
            this.SuspendLayout();

            // ── pnlHeader ────────────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(15, 22, 45);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Controls.Add(this.lblSubtitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(480, 64);
            this.pnlHeader.TabIndex = 0;

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.lblTitulo.Location = new System.Drawing.Point(20, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Nuevo Volante de Pago";

            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblSubtitulo.Location = new System.Drawing.Point(22, 38);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Asocie empleado, período y deducción";

            // ── pnlCuerpo ─────────────────────────────────────────────────
            this.pnlCuerpo.BackColor = System.Drawing.Color.FromArgb(18, 24, 48);
            this.pnlCuerpo.Controls.Add(this.lblLblEmpleado);
            this.pnlCuerpo.Controls.Add(this.cmbEmpleado);
            this.pnlCuerpo.Controls.Add(this.lblInfoEmpleado);
            this.pnlCuerpo.Controls.Add(this.lblLblPeriodo);
            this.pnlCuerpo.Controls.Add(this.cmbPeriodo);
            this.pnlCuerpo.Controls.Add(this.lblLblDeduccion);
            this.pnlCuerpo.Controls.Add(this.cmbDeduccion);
            this.pnlCuerpo.Controls.Add(this.lblLblFecha);
            this.pnlCuerpo.Controls.Add(this.dtpFecha);
            this.pnlCuerpo.Controls.Add(this.sep1);
            this.pnlCuerpo.Controls.Add(this.lblPreviewSubtotal);
            this.pnlCuerpo.Controls.Add(this.lblPreviewDeduccion);
            this.pnlCuerpo.Controls.Add(this.sep2);
            this.pnlCuerpo.Controls.Add(this.lblPreviewTotal);
            this.pnlCuerpo.Controls.Add(this.lblEstado);
            this.pnlCuerpo.Controls.Add(this.btnGuardar);
            this.pnlCuerpo.Controls.Add(this.btnCancelar);
            this.pnlCuerpo.Location = new System.Drawing.Point(16, 72);
            this.pnlCuerpo.Name = "pnlCuerpo";
            this.pnlCuerpo.Size = new System.Drawing.Size(448, 420);
            this.pnlCuerpo.TabIndex = 1;

            // ── Empleado ──────────────────────────────────────────────────
            this.lblLblEmpleado.AutoSize = true;
            this.lblLblEmpleado.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblLblEmpleado.ForeColor = System.Drawing.Color.White;
            this.lblLblEmpleado.Location = new System.Drawing.Point(16, 14);
            this.lblLblEmpleado.Name = "lblLblEmpleado";
            this.lblLblEmpleado.TabIndex = 0;
            this.lblLblEmpleado.Text = "Empleado *";

            this.cmbEmpleado.BackColor = System.Drawing.Color.FromArgb(25, 35, 65);
            this.cmbEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEmpleado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbEmpleado.ForeColor = System.Drawing.Color.White;
            this.cmbEmpleado.Location = new System.Drawing.Point(16, 32);
            this.cmbEmpleado.Name = "cmbEmpleado";
            this.cmbEmpleado.Size = new System.Drawing.Size(416, 23);
            this.cmbEmpleado.TabIndex = 1;

            this.lblInfoEmpleado.AutoSize = true;
            this.lblInfoEmpleado.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblInfoEmpleado.ForeColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.lblInfoEmpleado.Location = new System.Drawing.Point(18, 58);
            this.lblInfoEmpleado.Name = "lblInfoEmpleado";
            this.lblInfoEmpleado.TabIndex = 2;
            this.lblInfoEmpleado.Text = "";

            // ── Período ───────────────────────────────────────────────────
            this.lblLblPeriodo.AutoSize = true;
            this.lblLblPeriodo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblLblPeriodo.ForeColor = System.Drawing.Color.White;
            this.lblLblPeriodo.Location = new System.Drawing.Point(16, 78);
            this.lblLblPeriodo.Name = "lblLblPeriodo";
            this.lblLblPeriodo.TabIndex = 3;
            this.lblLblPeriodo.Text = "Período de Sueldo (SalarioST) *";

            this.cmbPeriodo.BackColor = System.Drawing.Color.FromArgb(25, 35, 65);
            this.cmbPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeriodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPeriodo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbPeriodo.ForeColor = System.Drawing.Color.White;
            this.cmbPeriodo.Location = new System.Drawing.Point(16, 96);
            this.cmbPeriodo.Name = "cmbPeriodo";
            this.cmbPeriodo.Size = new System.Drawing.Size(416, 23);
            this.cmbPeriodo.TabIndex = 4;

            // ── Deducción ─────────────────────────────────────────────────
            this.lblLblDeduccion.AutoSize = true;
            this.lblLblDeduccion.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblLblDeduccion.ForeColor = System.Drawing.Color.White;
            this.lblLblDeduccion.Location = new System.Drawing.Point(16, 132);
            this.lblLblDeduccion.Name = "lblLblDeduccion";
            this.lblLblDeduccion.TabIndex = 5;
            this.lblLblDeduccion.Text = "Deducción del Empleado *";

            this.cmbDeduccion.BackColor = System.Drawing.Color.FromArgb(25, 35, 65);
            this.cmbDeduccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeduccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDeduccion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbDeduccion.ForeColor = System.Drawing.Color.White;
            this.cmbDeduccion.Location = new System.Drawing.Point(16, 150);
            this.cmbDeduccion.Name = "cmbDeduccion";
            this.cmbDeduccion.Size = new System.Drawing.Size(416, 23);
            this.cmbDeduccion.TabIndex = 6;

            // ── Fecha ─────────────────────────────────────────────────────
            this.lblLblFecha.AutoSize = true;
            this.lblLblFecha.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblLblFecha.ForeColor = System.Drawing.Color.White;
            this.lblLblFecha.Location = new System.Drawing.Point(16, 186);
            this.lblLblFecha.Name = "lblLblFecha";
            this.lblLblFecha.TabIndex = 7;
            this.lblLblFecha.Text = "Fecha de Efectividad *";

            this.dtpFecha.CalendarForeColor = System.Drawing.Color.White;
            this.dtpFecha.CalendarMonthBackground = System.Drawing.Color.FromArgb(18, 24, 48);
            this.dtpFecha.CalendarTitleBackColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.dtpFecha.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dtpFecha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(16, 204);
            this.dtpFecha.MinDate = System.DateTime.Today;
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 23);
            this.dtpFecha.TabIndex = 8;
            this.dtpFecha.Value = System.DateTime.Today;

            // ── Preview de montos ─────────────────────────────────────────
            this.sep1.BackColor = System.Drawing.Color.FromArgb(30, 40, 80);
            this.sep1.Location = new System.Drawing.Point(16, 238);
            this.sep1.Name = "sep1";
            this.sep1.Size = new System.Drawing.Size(416, 1);
            this.sep1.TabIndex = 9;

            this.lblPreviewSubtotal.AutoSize = true;
            this.lblPreviewSubtotal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPreviewSubtotal.ForeColor = System.Drawing.Color.White;
            this.lblPreviewSubtotal.Location = new System.Drawing.Point(16, 248);
            this.lblPreviewSubtotal.Name = "lblPreviewSubtotal";
            this.lblPreviewSubtotal.TabIndex = 10;
            this.lblPreviewSubtotal.Text = "Subtotal: —";

            this.lblPreviewDeduccion.AutoSize = true;
            this.lblPreviewDeduccion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPreviewDeduccion.ForeColor = System.Drawing.Color.FromArgb(255, 80, 80);
            this.lblPreviewDeduccion.Location = new System.Drawing.Point(16, 270);
            this.lblPreviewDeduccion.Name = "lblPreviewDeduccion";
            this.lblPreviewDeduccion.TabIndex = 11;
            this.lblPreviewDeduccion.Text = "Deducción: —";

            this.sep2.BackColor = System.Drawing.Color.FromArgb(30, 40, 80);
            this.sep2.Location = new System.Drawing.Point(16, 296);
            this.sep2.Name = "sep2";
            this.sep2.Size = new System.Drawing.Size(416, 1);
            this.sep2.TabIndex = 12;

            this.lblPreviewTotal.AutoSize = true;
            this.lblPreviewTotal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblPreviewTotal.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblPreviewTotal.Location = new System.Drawing.Point(16, 306);
            this.lblPreviewTotal.Name = "lblPreviewTotal";
            this.lblPreviewTotal.TabIndex = 13;
            this.lblPreviewTotal.Text = "Total Neto: —";

            // ── Estado y botones ──────────────────────────────────────────
            this.lblEstado.AutoSize = false;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.lblEstado.Location = new System.Drawing.Point(16, 344);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(416, 20);
            this.lblEstado.TabIndex = 14;
            this.lblEstado.Text = "";

            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(30, 80, 180);
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(16, 372);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(200, 36);
            this.btnGuardar.TabIndex = 15;
            this.btnGuardar.Text = "Guardar Volante";
            this.btnGuardar.UseVisualStyleBackColor = false;

            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(25, 35, 65);
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.btnCancelar.Location = new System.Drawing.Point(232, 372);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(200, 36);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;

            // ── FrmNuevoVolantePago ───────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(13, 17, 35);
            this.ClientSize = new System.Drawing.Size(480, 508);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlCuerpo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmNuevoVolantePago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuevo Volante de Pago";
            this.Load += new System.EventHandler(this.FrmNuevoVolantePago_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlCuerpo.ResumeLayout(false);
            this.pnlCuerpo.PerformLayout();
            this.ResumeLayout(false);
        }

        // ── Declaraciones ──────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel pnlCuerpo;
        private System.Windows.Forms.Label lblLblEmpleado;
        private System.Windows.Forms.ComboBox cmbEmpleado;
        private System.Windows.Forms.Label lblInfoEmpleado;
        private System.Windows.Forms.Label lblLblPeriodo;
        private System.Windows.Forms.ComboBox cmbPeriodo;
        private System.Windows.Forms.Label lblLblDeduccion;
        private System.Windows.Forms.ComboBox cmbDeduccion;
        private System.Windows.Forms.Label lblLblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Panel sep1;
        private System.Windows.Forms.Label lblPreviewSubtotal;
        private System.Windows.Forms.Label lblPreviewDeduccion;
        private System.Windows.Forms.Panel sep2;
        private System.Windows.Forms.Label lblPreviewTotal;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
