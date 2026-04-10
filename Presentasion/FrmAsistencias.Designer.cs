namespace Presentacion
{
    partial class FrmAsistencias
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

            this.pnlFormulario = new System.Windows.Forms.Panel();
            this.lblLblEmpleado = new System.Windows.Forms.Label();
            this.cmbEmpleado = new System.Windows.Forms.ComboBox();
            this.lblLblTipo = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.btnRegistrar = new System.Windows.Forms.Button();

            this.pnlTarjetas = new System.Windows.Forms.Panel();

            // Tarjeta Entrada
            this.cardEntrada = new System.Windows.Forms.Panel();
            this.lblIconoEntrada = new System.Windows.Forms.Label();
            this.lblTextoEntrada = new System.Windows.Forms.Label();

            // Tarjeta Almuerzo
            this.cardAlmuerzo = new System.Windows.Forms.Panel();
            this.lblIconoAlmuerzo = new System.Windows.Forms.Label();
            this.lblTextoAlmuerzo = new System.Windows.Forms.Label();

            // Tarjeta Retorno
            this.cardRetorno = new System.Windows.Forms.Panel();
            this.lblIconoRetorno = new System.Windows.Forms.Label();
            this.lblTextoRetorno = new System.Windows.Forms.Label();

            // Tarjeta Salida
            this.cardSalida = new System.Windows.Forms.Panel();
            this.lblIconoSalida = new System.Windows.Forms.Label();
            this.lblTextoSalida = new System.Windows.Forms.Label();

            this.lblMensaje = new System.Windows.Forms.Label();
            this.dgvAsistencias = new System.Windows.Forms.DataGridView();

            this.pnlHeader.SuspendLayout();
            this.pnlFormulario.SuspendLayout();
            this.pnlTarjetas.SuspendLayout();
            this.cardEntrada.SuspendLayout();
            this.cardAlmuerzo.SuspendLayout();
            this.cardRetorno.SuspendLayout();
            this.cardSalida.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistencias)).BeginInit();
            this.SuspendLayout();

            // ── pnlHeader ────────────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(18, 24, 48);
            this.pnlHeader.Controls.Add(this.lblTituloPagina);
            this.pnlHeader.Controls.Add(this.lblSubtituloPagina);
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
            this.lblTituloPagina.Text = "Asistencias";

            this.lblSubtituloPagina.AutoSize = true;
            this.lblSubtituloPagina.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSubtituloPagina.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblSubtituloPagina.Location = new System.Drawing.Point(30, 40);
            this.lblSubtituloPagina.Name = "lblSubtituloPagina";
            this.lblSubtituloPagina.TabIndex = 1;
            this.lblSubtituloPagina.Text = "Registro de marcaciones del personal";

            // ── pnlFormulario ─────────────────────────────────────────────
            this.pnlFormulario.BackColor = System.Drawing.Color.FromArgb(18, 24, 48);
            this.pnlFormulario.Controls.Add(this.lblLblEmpleado);
            this.pnlFormulario.Controls.Add(this.cmbEmpleado);
            this.pnlFormulario.Controls.Add(this.lblLblTipo);
            this.pnlFormulario.Controls.Add(this.cmbTipo);
            this.pnlFormulario.Controls.Add(this.btnRegistrar);
            this.pnlFormulario.Location = new System.Drawing.Point(16, 72);
            this.pnlFormulario.Name = "pnlFormulario";
            this.pnlFormulario.Size = new System.Drawing.Size(868, 90);
            this.pnlFormulario.TabIndex = 1;

            this.lblLblEmpleado.AutoSize = true;
            this.lblLblEmpleado.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblLblEmpleado.ForeColor = System.Drawing.Color.White;
            this.lblLblEmpleado.Location = new System.Drawing.Point(18, 14);
            this.lblLblEmpleado.Name = "lblLblEmpleado";
            this.lblLblEmpleado.TabIndex = 0;
            this.lblLblEmpleado.Text = "Empleado";

            this.cmbEmpleado.BackColor = System.Drawing.Color.FromArgb(25, 35, 65);
            this.cmbEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEmpleado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbEmpleado.ForeColor = System.Drawing.Color.White;
            this.cmbEmpleado.Location = new System.Drawing.Point(18, 36);
            this.cmbEmpleado.Name = "cmbEmpleado";
            this.cmbEmpleado.Size = new System.Drawing.Size(320, 23);
            this.cmbEmpleado.TabIndex = 1;

            this.lblLblTipo.AutoSize = true;
            this.lblLblTipo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblLblTipo.ForeColor = System.Drawing.Color.White;
            this.lblLblTipo.Location = new System.Drawing.Point(356, 14);
            this.lblLblTipo.Name = "lblLblTipo";
            this.lblLblTipo.TabIndex = 2;
            this.lblLblTipo.Text = "Tipo de marcación";

            this.cmbTipo.BackColor = System.Drawing.Color.FromArgb(25, 35, 65);
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTipo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbTipo.ForeColor = System.Drawing.Color.White;
            this.cmbTipo.Items.AddRange(new object[] {
                "Entrada", "Salida", "Almuerzo", "Retorno de Almuerzo" });
            this.cmbTipo.Location = new System.Drawing.Point(356, 36);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(220, 23);
            this.cmbTipo.TabIndex = 3;
            this.cmbTipo.SelectedIndex = 0;

            this.btnRegistrar.BackColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.btnRegistrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrar.FlatAppearance.BorderSize = 0;
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRegistrar.ForeColor = System.Drawing.Color.FromArgb(13, 17, 35);
            this.btnRegistrar.Location = new System.Drawing.Point(594, 34);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(120, 28);
            this.btnRegistrar.TabIndex = 4;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = false;

            // ── pnlTarjetas ───────────────────────────────────────────────
            this.pnlTarjetas.BackColor = System.Drawing.Color.Transparent;
            this.pnlTarjetas.Controls.Add(this.cardEntrada);
            this.pnlTarjetas.Controls.Add(this.cardAlmuerzo);
            this.pnlTarjetas.Controls.Add(this.cardRetorno);
            this.pnlTarjetas.Controls.Add(this.cardSalida);
            this.pnlTarjetas.Location = new System.Drawing.Point(16, 172);
            this.pnlTarjetas.Name = "pnlTarjetas";
            this.pnlTarjetas.Size = new System.Drawing.Size(868, 110);
            this.pnlTarjetas.TabIndex = 2;

            // ── cardEntrada ───────────────────────────────────────────────
            this.cardEntrada.BackColor = System.Drawing.Color.FromArgb(18, 24, 48);
            this.cardEntrada.Controls.Add(this.lblIconoEntrada);
            this.cardEntrada.Controls.Add(this.lblTextoEntrada);
            this.cardEntrada.Location = new System.Drawing.Point(0, 0);
            this.cardEntrada.Name = "cardEntrada";
            this.cardEntrada.Size = new System.Drawing.Size(205, 100);
            this.cardEntrada.TabIndex = 0;

            this.lblIconoEntrada.AutoSize = true;
            this.lblIconoEntrada.BackColor = System.Drawing.Color.Transparent;
            this.lblIconoEntrada.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.lblIconoEntrada.ForeColor = System.Drawing.Color.FromArgb(39, 201, 63);
            this.lblIconoEntrada.Location = new System.Drawing.Point(15, 14);
            this.lblIconoEntrada.Name = "lblIconoEntrada";
            this.lblIconoEntrada.TabIndex = 0;
            this.lblIconoEntrada.Text = "●";

            this.lblTextoEntrada.AutoSize = true;
            this.lblTextoEntrada.BackColor = System.Drawing.Color.Transparent;
            this.lblTextoEntrada.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTextoEntrada.ForeColor = System.Drawing.Color.White;
            this.lblTextoEntrada.Location = new System.Drawing.Point(15, 62);
            this.lblTextoEntrada.Name = "lblTextoEntrada";
            this.lblTextoEntrada.TabIndex = 1;
            this.lblTextoEntrada.Text = "Entrada";

            // ── cardAlmuerzo ──────────────────────────────────────────────
            this.cardAlmuerzo.BackColor = System.Drawing.Color.FromArgb(18, 24, 48);
            this.cardAlmuerzo.Controls.Add(this.lblIconoAlmuerzo);
            this.cardAlmuerzo.Controls.Add(this.lblTextoAlmuerzo);
            this.cardAlmuerzo.Location = new System.Drawing.Point(221, 0);
            this.cardAlmuerzo.Name = "cardAlmuerzo";
            this.cardAlmuerzo.Size = new System.Drawing.Size(205, 100);
            this.cardAlmuerzo.TabIndex = 1;

            this.lblIconoAlmuerzo.AutoSize = true;
            this.lblIconoAlmuerzo.BackColor = System.Drawing.Color.Transparent;
            this.lblIconoAlmuerzo.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.lblIconoAlmuerzo.ForeColor = System.Drawing.Color.FromArgb(255, 180, 0);
            this.lblIconoAlmuerzo.Location = new System.Drawing.Point(15, 14);
            this.lblIconoAlmuerzo.Name = "lblIconoAlmuerzo";
            this.lblIconoAlmuerzo.TabIndex = 0;
            this.lblIconoAlmuerzo.Text = "●";

            this.lblTextoAlmuerzo.AutoSize = true;
            this.lblTextoAlmuerzo.BackColor = System.Drawing.Color.Transparent;
            this.lblTextoAlmuerzo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTextoAlmuerzo.ForeColor = System.Drawing.Color.White;
            this.lblTextoAlmuerzo.Location = new System.Drawing.Point(15, 62);
            this.lblTextoAlmuerzo.Name = "lblTextoAlmuerzo";
            this.lblTextoAlmuerzo.TabIndex = 1;
            this.lblTextoAlmuerzo.Text = "Almuerzo";

            // ── cardRetorno ───────────────────────────────────────────────
            this.cardRetorno.BackColor = System.Drawing.Color.FromArgb(18, 24, 48);
            this.cardRetorno.Controls.Add(this.lblIconoRetorno);
            this.cardRetorno.Controls.Add(this.lblTextoRetorno);
            this.cardRetorno.Location = new System.Drawing.Point(442, 0);
            this.cardRetorno.Name = "cardRetorno";
            this.cardRetorno.Size = new System.Drawing.Size(205, 100);
            this.cardRetorno.TabIndex = 2;

            this.lblIconoRetorno.AutoSize = true;
            this.lblIconoRetorno.BackColor = System.Drawing.Color.Transparent;
            this.lblIconoRetorno.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.lblIconoRetorno.ForeColor = System.Drawing.Color.FromArgb(255, 120, 0);
            this.lblIconoRetorno.Location = new System.Drawing.Point(15, 14);
            this.lblIconoRetorno.Name = "lblIconoRetorno";
            this.lblIconoRetorno.TabIndex = 0;
            this.lblIconoRetorno.Text = "●";

            this.lblTextoRetorno.AutoSize = true;
            this.lblTextoRetorno.BackColor = System.Drawing.Color.Transparent;
            this.lblTextoRetorno.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTextoRetorno.ForeColor = System.Drawing.Color.White;
            this.lblTextoRetorno.Location = new System.Drawing.Point(15, 62);
            this.lblTextoRetorno.Name = "lblTextoRetorno";
            this.lblTextoRetorno.TabIndex = 1;
            this.lblTextoRetorno.Text = "Retorno Almuerzo";

            // ── cardSalida ────────────────────────────────────────────────
            this.cardSalida.BackColor = System.Drawing.Color.FromArgb(18, 24, 48);
            this.cardSalida.Controls.Add(this.lblIconoSalida);
            this.cardSalida.Controls.Add(this.lblTextoSalida);
            this.cardSalida.Location = new System.Drawing.Point(663, 0);
            this.cardSalida.Name = "cardSalida";
            this.cardSalida.Size = new System.Drawing.Size(205, 100);
            this.cardSalida.TabIndex = 3;

            this.lblIconoSalida.AutoSize = true;
            this.lblIconoSalida.BackColor = System.Drawing.Color.Transparent;
            this.lblIconoSalida.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.lblIconoSalida.ForeColor = System.Drawing.Color.FromArgb(255, 80, 80);
            this.lblIconoSalida.Location = new System.Drawing.Point(15, 14);
            this.lblIconoSalida.Name = "lblIconoSalida";
            this.lblIconoSalida.TabIndex = 0;
            this.lblIconoSalida.Text = "●";

            this.lblTextoSalida.AutoSize = true;
            this.lblTextoSalida.BackColor = System.Drawing.Color.Transparent;
            this.lblTextoSalida.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTextoSalida.ForeColor = System.Drawing.Color.White;
            this.lblTextoSalida.Location = new System.Drawing.Point(15, 62);
            this.lblTextoSalida.Name = "lblTextoSalida";
            this.lblTextoSalida.TabIndex = 1;
            this.lblTextoSalida.Text = "Salida";

            // ── lblMensaje ────────────────────────────────────────────────
            this.lblMensaje.AutoSize = false;
            this.lblMensaje.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMensaje.ForeColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.lblMensaje.Location = new System.Drawing.Point(16, 290);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(700, 22);
            this.lblMensaje.TabIndex = 3;
            this.lblMensaje.Text = "";
            this.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // ── dgvAsistencias ────────────────────────────────────────────
            this.dgvAsistencias.AllowUserToAddRows = false;
            this.dgvAsistencias.AllowUserToDeleteRows = false;
            this.dgvAsistencias.BackgroundColor = System.Drawing.Color.FromArgb(18, 24, 48);
            this.dgvAsistencias.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAsistencias.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAsistencias.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvAsistencias.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(20, 28, 58);
            this.dgvAsistencias.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.dgvAsistencias.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.dgvAsistencias.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(20, 28, 58);
            this.dgvAsistencias.ColumnHeadersHeight = 36;
            this.dgvAsistencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAsistencias.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(18, 24, 48);
            this.dgvAsistencias.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvAsistencias.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvAsistencias.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(25, 35, 70);
            this.dgvAsistencias.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.dgvAsistencias.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dgvAsistencias.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(20, 28, 55);
            this.dgvAsistencias.EnableHeadersVisualStyles = false;
            this.dgvAsistencias.GridColor = System.Drawing.Color.FromArgb(30, 40, 80);
            this.dgvAsistencias.Location = new System.Drawing.Point(16, 320);
            this.dgvAsistencias.MultiSelect = false;
            this.dgvAsistencias.Name = "dgvAsistencias";
            this.dgvAsistencias.ReadOnly = true;
            this.dgvAsistencias.RowHeadersVisible = false;
            this.dgvAsistencias.RowTemplate.Height = 40;
            this.dgvAsistencias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAsistencias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAsistencias.Size = new System.Drawing.Size(868, 190);
            this.dgvAsistencias.TabIndex = 4;
            this.dgvAsistencias.Anchor = System.Windows.Forms.AnchorStyles.Top |
                                         System.Windows.Forms.AnchorStyles.Left |
                                         System.Windows.Forms.AnchorStyles.Right |
                                         System.Windows.Forms.AnchorStyles.Bottom;

            // ── FrmAsistencias ────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(13, 17, 35);
            this.ClientSize = new System.Drawing.Size(900, 537);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlFormulario);
            this.Controls.Add(this.pnlTarjetas);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.dgvAsistencias);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAsistencias";
            this.Text = "Asistencias";
            this.Load += new System.EventHandler(this.FrmAsistencias_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFormulario.ResumeLayout(false);
            this.pnlFormulario.PerformLayout();
            this.pnlTarjetas.ResumeLayout(false);
            this.cardEntrada.ResumeLayout(false);
            this.cardEntrada.PerformLayout();
            this.cardAlmuerzo.ResumeLayout(false);
            this.cardAlmuerzo.PerformLayout();
            this.cardRetorno.ResumeLayout(false);
            this.cardRetorno.PerformLayout();
            this.cardSalida.ResumeLayout(false);
            this.cardSalida.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistencias)).EndInit();
            this.ResumeLayout(false);
        }

        // ── Declaraciones ──────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTituloPagina;
        private System.Windows.Forms.Label lblSubtituloPagina;

        private System.Windows.Forms.Panel pnlFormulario;
        private System.Windows.Forms.Label lblLblEmpleado;
        private System.Windows.Forms.ComboBox cmbEmpleado;
        private System.Windows.Forms.Label lblLblTipo;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Button btnRegistrar;

        private System.Windows.Forms.Panel pnlTarjetas;

        private System.Windows.Forms.Panel cardEntrada;
        private System.Windows.Forms.Label lblIconoEntrada;
        private System.Windows.Forms.Label lblTextoEntrada;

        private System.Windows.Forms.Panel cardAlmuerzo;
        private System.Windows.Forms.Label lblIconoAlmuerzo;
        private System.Windows.Forms.Label lblTextoAlmuerzo;

        private System.Windows.Forms.Panel cardRetorno;
        private System.Windows.Forms.Label lblIconoRetorno;
        private System.Windows.Forms.Label lblTextoRetorno;

        private System.Windows.Forms.Panel cardSalida;
        private System.Windows.Forms.Label lblIconoSalida;
        private System.Windows.Forms.Label lblTextoSalida;

        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.DataGridView dgvAsistencias;
    }
}