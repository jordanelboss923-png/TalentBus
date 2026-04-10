namespace Presentacion
{
    partial class FrmNuevoVolante
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
            this.lblLblEmpleado = new System.Windows.Forms.Label();
            this.cmbEmpleado = new System.Windows.Forms.ComboBox();
            this.lblInfoEmpleado = new System.Windows.Forms.Label();
            this.lblLblSueldo = new System.Windows.Forms.Label();
            this.txtSueldo = new System.Windows.Forms.TextBox();
            this.lblNotaSueldo = new System.Windows.Forms.Label();
            this.lblLblAsig = new System.Windows.Forms.Label();
            this.txtAsignacion = new System.Windows.Forms.TextBox();
            this.lblLblTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblLblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.sep = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblEstado = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlCuerpo.SuspendLayout();
            this.SuspendLayout();

            // ── pnlHeader ─────────────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(18, 24, 48);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Controls.Add(this.lblSubtitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(520, 64);
            this.pnlHeader.TabIndex = 0;

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(20, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Nuevo Volante de Pago";

            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblSubtitulo.Location = new System.Drawing.Point(22, 40);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Completa los campos para registrar el volante";

            // ── pnlCuerpo ─────────────────────────────────────────────────
            this.pnlCuerpo.BackColor = System.Drawing.Color.FromArgb(13, 17, 35);
            this.pnlCuerpo.Controls.Add(this.lblLblEmpleado);
            this.pnlCuerpo.Controls.Add(this.cmbEmpleado);
            this.pnlCuerpo.Controls.Add(this.lblInfoEmpleado);
            this.pnlCuerpo.Controls.Add(this.lblLblSueldo);
            this.pnlCuerpo.Controls.Add(this.txtSueldo);
            this.pnlCuerpo.Controls.Add(this.lblNotaSueldo);
            this.pnlCuerpo.Controls.Add(this.lblLblAsig);
            this.pnlCuerpo.Controls.Add(this.txtAsignacion);
            this.pnlCuerpo.Controls.Add(this.lblLblTotal);
            this.pnlCuerpo.Controls.Add(this.txtTotal);
            this.pnlCuerpo.Controls.Add(this.lblLblFecha);
            this.pnlCuerpo.Controls.Add(this.dtpFecha);
            this.pnlCuerpo.Controls.Add(this.sep);
            this.pnlCuerpo.Controls.Add(this.btnGuardar);
            this.pnlCuerpo.Controls.Add(this.btnCancelar);
            this.pnlCuerpo.Controls.Add(this.lblEstado);
            this.pnlCuerpo.Location = new System.Drawing.Point(0, 64);
            this.pnlCuerpo.Name = "pnlCuerpo";
            this.pnlCuerpo.Size = new System.Drawing.Size(520, 380);
            this.pnlCuerpo.TabIndex = 1;

            // Empleado
            this.lblLblEmpleado.AutoSize = true;
            this.lblLblEmpleado.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblLblEmpleado.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblLblEmpleado.Location = new System.Drawing.Point(30, 20);
            this.lblLblEmpleado.Name = "lblLblEmpleado";
            this.lblLblEmpleado.TabIndex = 0;
            this.lblLblEmpleado.Text = "Empleado *";

            this.cmbEmpleado.BackColor = System.Drawing.Color.FromArgb(25, 35, 65);
            this.cmbEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEmpleado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbEmpleado.ForeColor = System.Drawing.Color.White;
            this.cmbEmpleado.Location = new System.Drawing.Point(30, 38);
            this.cmbEmpleado.Name = "cmbEmpleado";
            this.cmbEmpleado.Size = new System.Drawing.Size(460, 23);
            this.cmbEmpleado.TabIndex = 1;

            this.lblInfoEmpleado.AutoSize = true;
            this.lblInfoEmpleado.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblInfoEmpleado.ForeColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.lblInfoEmpleado.Location = new System.Drawing.Point(30, 64);
            this.lblInfoEmpleado.Name = "lblInfoEmpleado";
            this.lblInfoEmpleado.TabIndex = 2;
            this.lblInfoEmpleado.Text = "";

            // Sueldo base
            this.lblLblSueldo.AutoSize = true;
            this.lblLblSueldo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblLblSueldo.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblLblSueldo.Location = new System.Drawing.Point(30, 90);
            this.lblLblSueldo.Name = "lblLblSueldo";
            this.lblLblSueldo.TabIndex = 3;
            this.lblLblSueldo.Text = "Sueldo Base (RD$) *";

            this.txtSueldo.BackColor = System.Drawing.Color.FromArgb(25, 35, 65);
            this.txtSueldo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSueldo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSueldo.ForeColor = System.Drawing.Color.White;
            this.txtSueldo.Location = new System.Drawing.Point(30, 108);
            this.txtSueldo.Name = "txtSueldo";
            this.txtSueldo.ReadOnly = true;
            this.txtSueldo.Size = new System.Drawing.Size(220, 26);
            this.txtSueldo.TabIndex = 4;

            this.lblNotaSueldo.AutoSize = true;
            this.lblNotaSueldo.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblNotaSueldo.ForeColor = System.Drawing.Color.FromArgb(100, 120, 160);
            this.lblNotaSueldo.Location = new System.Drawing.Point(30, 137);
            this.lblNotaSueldo.Name = "lblNotaSueldo";
            this.lblNotaSueldo.TabIndex = 5;
            this.lblNotaSueldo.Text = "Se carga automáticamente al seleccionar empleado";

            // Asignacion
            this.lblLblAsig.AutoSize = true;
            this.lblLblAsig.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblLblAsig.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblLblAsig.Location = new System.Drawing.Point(270, 90);
            this.lblLblAsig.Name = "lblLblAsig";
            this.lblLblAsig.TabIndex = 6;
            this.lblLblAsig.Text = "Asignaciones (RD$)";

            this.txtAsignacion.BackColor = System.Drawing.Color.FromArgb(25, 35, 65);
            this.txtAsignacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAsignacion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAsignacion.ForeColor = System.Drawing.Color.White;
            this.txtAsignacion.Location = new System.Drawing.Point(270, 108);
            this.txtAsignacion.Name = "txtAsignacion";
            this.txtAsignacion.Size = new System.Drawing.Size(220, 26);
            this.txtAsignacion.TabIndex = 7;
            this.txtAsignacion.Text = "0.00";

            // Total (calculado, readonly)
            this.lblLblTotal.AutoSize = true;
            this.lblLblTotal.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblLblTotal.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblLblTotal.Location = new System.Drawing.Point(30, 160);
            this.lblLblTotal.Name = "lblLblTotal";
            this.lblLblTotal.TabIndex = 8;
            this.lblLblTotal.Text = "Total (calculado automáticamente)";

            this.txtTotal.BackColor = System.Drawing.Color.FromArgb(15, 22, 45);
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.txtTotal.ForeColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.txtTotal.Location = new System.Drawing.Point(30, 178);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(460, 30);
            this.txtTotal.TabIndex = 9;
            this.txtTotal.Text = "0.00";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // Fecha efectividad
            this.lblLblFecha.AutoSize = true;
            this.lblLblFecha.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblLblFecha.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblLblFecha.Location = new System.Drawing.Point(30, 224);
            this.lblLblFecha.Name = "lblLblFecha";
            this.lblLblFecha.TabIndex = 10;
            this.lblLblFecha.Text = "Fecha de Efectividad *";

            this.dtpFecha.CalendarForeColor = System.Drawing.Color.White;
            this.dtpFecha.CalendarMonthBackground = System.Drawing.Color.FromArgb(18, 24, 48);
            this.dtpFecha.CalendarTitleBackColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.dtpFecha.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dtpFecha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(30, 242);
            this.dtpFecha.MaxDate = System.DateTime.Today;
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 23);
            this.dtpFecha.TabIndex = 11;
            this.dtpFecha.Value = System.DateTime.Today;

            // Separador
            this.sep.BackColor = System.Drawing.Color.FromArgb(30, 40, 80);
            this.sep.Location = new System.Drawing.Point(30, 282);
            this.sep.Name = "sep";
            this.sep.Size = new System.Drawing.Size(460, 1);
            this.sep.TabIndex = 12;

            // Botones
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(30, 80, 180);
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(30, 296);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(220, 36);
            this.btnGuardar.TabIndex = 13;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;

            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(25, 35, 65);
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.btnCancelar.Location = new System.Drawing.Point(270, 296);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(220, 36);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;

            // lblEstado
            this.lblEstado.AutoSize = false;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblEstado.Location = new System.Drawing.Point(30, 342);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(460, 22);
            this.lblEstado.TabIndex = 15;
            this.lblEstado.Text = "";
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // ── FrmNuevoVolante ───────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(13, 17, 35);
            this.ClientSize = new System.Drawing.Size(520, 444);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlCuerpo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmNuevoVolante";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Volante de Pago";
            this.Load += new System.EventHandler(this.FrmNuevoVolante_Load);

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
        private System.Windows.Forms.Label lblLblSueldo;
        private System.Windows.Forms.TextBox txtSueldo;
        private System.Windows.Forms.Label lblNotaSueldo;
        private System.Windows.Forms.Label lblLblAsig;
        private System.Windows.Forms.TextBox txtAsignacion;
        private System.Windows.Forms.Label lblLblTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblLblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Panel sep;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblEstado;
    }
}