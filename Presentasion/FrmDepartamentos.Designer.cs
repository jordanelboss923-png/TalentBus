namespace Presentacion
{
    partial class FrmDepartamentos
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
            this.lblLblNombre = new System.Windows.Forms.Label();
            this.pnlNombre = new System.Windows.Forms.Panel();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();

            this.lblMensaje = new System.Windows.Forms.Label();
            this.dgvDepartamentos = new System.Windows.Forms.DataGridView();

            this.pnlHeader.SuspendLayout();
            this.pnlFormulario.SuspendLayout();
            this.pnlNombre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartamentos)).BeginInit();
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
            this.pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.pnlHeader.TabIndex = 0;

            this.lblTituloPagina.AutoSize = true;
            this.lblTituloPagina.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTituloPagina.ForeColor = System.Drawing.Color.White;
            this.lblTituloPagina.Location = new System.Drawing.Point(28, 12);
            this.lblTituloPagina.Name = "lblTituloPagina";
            this.lblTituloPagina.TabIndex = 0;
            this.lblTituloPagina.Text = "Departamentos";

            this.lblSubtituloPagina.AutoSize = true;
            this.lblSubtituloPagina.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSubtituloPagina.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblSubtituloPagina.Location = new System.Drawing.Point(30, 40);
            this.lblSubtituloPagina.Name = "lblSubtituloPagina";
            this.lblSubtituloPagina.TabIndex = 1;
            this.lblSubtituloPagina.Text = "Gestión de departamentos de la empresa";

            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNuevo.ForeColor = System.Drawing.Color.FromArgb(13, 17, 35);
            this.btnNuevo.Location = new System.Drawing.Point(770, 16);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(110, 34);
            this.btnNuevo.TabIndex = 2;
            this.btnNuevo.Text = "+ Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;

            // ── pnlFormulario ─────────────────────────────────────────────
            this.pnlFormulario.BackColor = System.Drawing.Color.FromArgb(18, 24, 48);
            this.pnlFormulario.Controls.Add(this.lblTituloFormulario);
            this.pnlFormulario.Controls.Add(this.lblLblNombre);
            this.pnlFormulario.Controls.Add(this.pnlNombre);
            this.pnlFormulario.Controls.Add(this.btnGuardar);
            this.pnlFormulario.Controls.Add(this.btnCancelar);
            this.pnlFormulario.Location = new System.Drawing.Point(16, 72);
            this.pnlFormulario.Name = "pnlFormulario";
            this.pnlFormulario.Size = new System.Drawing.Size(868, 130);
            this.pnlFormulario.TabIndex = 1;
            this.pnlFormulario.Visible = false;

            this.lblTituloFormulario.AutoSize = true;
            this.lblTituloFormulario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTituloFormulario.ForeColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.lblTituloFormulario.Location = new System.Drawing.Point(18, 14);
            this.lblTituloFormulario.Name = "lblTituloFormulario";
            this.lblTituloFormulario.TabIndex = 0;
            this.lblTituloFormulario.Text = "Nuevo Departamento";

            // Nombre
            this.lblLblNombre.AutoSize = true;
            this.lblLblNombre.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblLblNombre.ForeColor = System.Drawing.Color.White;
            this.lblLblNombre.Location = new System.Drawing.Point(18, 44);
            this.lblLblNombre.Name = "lblLblNombre";
            this.lblLblNombre.TabIndex = 1;
            this.lblLblNombre.Text = "Nombre";

            this.pnlNombre.BackColor = System.Drawing.Color.FromArgb(25, 35, 65);
            this.pnlNombre.Controls.Add(this.txtNombre);
            this.pnlNombre.Location = new System.Drawing.Point(18, 62);
            this.pnlNombre.Name = "pnlNombre";
            this.pnlNombre.Size = new System.Drawing.Size(280, 36);
            this.pnlNombre.TabIndex = 2;

            this.txtNombre.BackColor = System.Drawing.Color.FromArgb(25, 35, 65);
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNombre.ForeColor = System.Drawing.Color.White;
            this.txtNombre.Location = new System.Drawing.Point(10, 6);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(260, 22);
            this.txtNombre.TabIndex = 0;

            // btnGuardar
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.FromArgb(13, 17, 35);
            this.btnGuardar.Location = new System.Drawing.Point(314, 62);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 34);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;

            // btnCancelar
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(25, 35, 65);
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.btnCancelar.Location = new System.Drawing.Point(424, 62);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 34);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;

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

            // ── dgvDepartamentos ──────────────────────────────────────────
            this.dgvDepartamentos.AllowUserToAddRows = false;
            this.dgvDepartamentos.AllowUserToDeleteRows = false;
            this.dgvDepartamentos.BackgroundColor = System.Drawing.Color.FromArgb(18, 24, 48);
            this.dgvDepartamentos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDepartamentos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDepartamentos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDepartamentos.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(20, 28, 58);
            this.dgvDepartamentos.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.dgvDepartamentos.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.dgvDepartamentos.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(20, 28, 58);
            this.dgvDepartamentos.ColumnHeadersHeight = 36;
            this.dgvDepartamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDepartamentos.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(18, 24, 48);
            this.dgvDepartamentos.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDepartamentos.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvDepartamentos.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(25, 35, 70);
            this.dgvDepartamentos.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.dgvDepartamentos.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dgvDepartamentos.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(20, 28, 55);
            this.dgvDepartamentos.EnableHeadersVisualStyles = false;
            this.dgvDepartamentos.GridColor = System.Drawing.Color.FromArgb(30, 40, 80);
            this.dgvDepartamentos.Location = new System.Drawing.Point(16, 110);
            this.dgvDepartamentos.MultiSelect = false;
            this.dgvDepartamentos.Name = "dgvDepartamentos";
            this.dgvDepartamentos.ReadOnly = true;
            this.dgvDepartamentos.RowHeadersVisible = false;
            this.dgvDepartamentos.RowTemplate.Height = 40;
            this.dgvDepartamentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDepartamentos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDepartamentos.Size = new System.Drawing.Size(868, 400);
            this.dgvDepartamentos.TabIndex = 3;
            this.dgvDepartamentos.Anchor = System.Windows.Forms.AnchorStyles.Top |
                                           System.Windows.Forms.AnchorStyles.Left |
                                           System.Windows.Forms.AnchorStyles.Right |
                                           System.Windows.Forms.AnchorStyles.Bottom;

            // ── FrmDepartamentos ──────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(13, 17, 35);
            this.ClientSize = new System.Drawing.Size(900, 537);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlFormulario);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.dgvDepartamentos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDepartamentos";
            this.Text = "Departamentos";
            this.Load += new System.EventHandler(this.FrmDepartamentos_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFormulario.ResumeLayout(false);
            this.pnlFormulario.PerformLayout();
            this.pnlNombre.ResumeLayout(false);
            this.pnlNombre.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartamentos)).EndInit();
            this.ResumeLayout(false);
        }

        // ── Declaraciones ──────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTituloPagina;
        private System.Windows.Forms.Label lblSubtituloPagina;
        private System.Windows.Forms.Button btnNuevo;

        private System.Windows.Forms.Panel pnlFormulario;
        private System.Windows.Forms.Label lblTituloFormulario;
        private System.Windows.Forms.Label lblLblNombre;
        private System.Windows.Forms.Panel pnlNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;

        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.DataGridView dgvDepartamentos;
    }
}