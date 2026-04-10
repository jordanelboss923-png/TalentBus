namespace Presentacion
{
    partial class FrmVolantesLista
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

            this.pnlFiltro = new System.Windows.Forms.Panel();
            this.lblFiltroTitulo = new System.Windows.Forms.Label();
            this.lblFiltroEmp = new System.Windows.Forms.Label();
            this.cmbFiltroEmpleado = new System.Windows.Forms.ComboBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lblConteo = new System.Windows.Forms.Label();

            this.lblMensaje = new System.Windows.Forms.Label();

            this.pnlTabla = new System.Windows.Forms.Panel();
            this.dgvVolantes = new System.Windows.Forms.DataGridView();

            this.pnlHeader.SuspendLayout();
            this.pnlFiltro.SuspendLayout();
            this.pnlTabla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVolantes)).BeginInit();
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
            this.lblTituloPagina.Text = "Volantes de Pago";

            this.lblSubtituloPagina.AutoSize = true;
            this.lblSubtituloPagina.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSubtituloPagina.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblSubtituloPagina.Location = new System.Drawing.Point(30, 40);
            this.lblSubtituloPagina.Name = "lblSubtituloPagina";
            this.lblSubtituloPagina.TabIndex = 1;
            this.lblSubtituloPagina.Text = "Gestión de volantes de pago";

            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNuevo.ForeColor = System.Drawing.Color.FromArgb(13, 17, 35);
            this.btnNuevo.Location = new System.Drawing.Point(762, 16);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(120, 34);
            this.btnNuevo.TabIndex = 2;
            this.btnNuevo.Text = "+ Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;

            // ── pnlFiltro ─────────────────────────────────────────────────
            this.pnlFiltro.BackColor = System.Drawing.Color.FromArgb(18, 24, 48);
            this.pnlFiltro.Controls.Add(this.lblFiltroTitulo);
            this.pnlFiltro.Controls.Add(this.lblFiltroEmp);
            this.pnlFiltro.Controls.Add(this.cmbFiltroEmpleado);
            this.pnlFiltro.Controls.Add(this.btnFiltrar);
            this.pnlFiltro.Controls.Add(this.btnLimpiar);
            this.pnlFiltro.Controls.Add(this.lblConteo);
            this.pnlFiltro.Location = new System.Drawing.Point(16, 72);
            this.pnlFiltro.Name = "pnlFiltro";
            this.pnlFiltro.Size = new System.Drawing.Size(868, 76);
            this.pnlFiltro.TabIndex = 1;

            this.lblFiltroTitulo.AutoSize = true;
            this.lblFiltroTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFiltroTitulo.ForeColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.lblFiltroTitulo.Location = new System.Drawing.Point(14, 10);
            this.lblFiltroTitulo.Name = "lblFiltroTitulo";
            this.lblFiltroTitulo.TabIndex = 0;
            this.lblFiltroTitulo.Text = "Filtrar por empleado";

            this.lblFiltroEmp.AutoSize = true;
            this.lblFiltroEmp.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblFiltroEmp.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblFiltroEmp.Location = new System.Drawing.Point(14, 36);
            this.lblFiltroEmp.Name = "lblFiltroEmp";
            this.lblFiltroEmp.TabIndex = 1;
            this.lblFiltroEmp.Text = "Empleado";

            this.cmbFiltroEmpleado.BackColor = System.Drawing.Color.FromArgb(25, 35, 65);
            this.cmbFiltroEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFiltroEmpleado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbFiltroEmpleado.ForeColor = System.Drawing.Color.White;
            this.cmbFiltroEmpleado.Location = new System.Drawing.Point(84, 32);
            this.cmbFiltroEmpleado.Name = "cmbFiltroEmpleado";
            this.cmbFiltroEmpleado.Size = new System.Drawing.Size(370, 23);
            this.cmbFiltroEmpleado.TabIndex = 2;

            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(30, 80, 180);
            this.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.FlatAppearance.BorderSize = 0;
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnFiltrar.Location = new System.Drawing.Point(468, 30);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(110, 28);
            this.btnFiltrar.TabIndex = 3;
            this.btnFiltrar.Text = "Consultar";
            this.btnFiltrar.UseVisualStyleBackColor = false;

            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(25, 35, 65);
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLimpiar.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.btnLimpiar.Location = new System.Drawing.Point(588, 30);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(90, 28);
            this.btnLimpiar.TabIndex = 4;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;

            this.lblConteo.AutoSize = true;
            this.lblConteo.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblConteo.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblConteo.Location = new System.Drawing.Point(694, 38);
            this.lblConteo.Name = "lblConteo";
            this.lblConteo.TabIndex = 5;
            this.lblConteo.Text = "";

            // ── lblMensaje ────────────────────────────────────────────────
            this.lblMensaje.AutoSize = false;
            this.lblMensaje.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMensaje.ForeColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.lblMensaje.Location = new System.Drawing.Point(16, 154);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(700, 22);
            this.lblMensaje.TabIndex = 2;
            this.lblMensaje.Text = "";
            this.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // ── pnlTabla ──────────────────────────────────────────────────
            this.pnlTabla.BackColor = System.Drawing.Color.Transparent;
            this.pnlTabla.Controls.Add(this.dgvVolantes);
            this.pnlTabla.Location = new System.Drawing.Point(16, 180);
            this.pnlTabla.Name = "pnlTabla";
            this.pnlTabla.Size = new System.Drawing.Size(868, 340);
            this.pnlTabla.TabIndex = 3;
            this.pnlTabla.Anchor = System.Windows.Forms.AnchorStyles.Top |
                                   System.Windows.Forms.AnchorStyles.Left |
                                   System.Windows.Forms.AnchorStyles.Right |
                                   System.Windows.Forms.AnchorStyles.Bottom;

            // ── dgvVolantes ───────────────────────────────────────────────
            this.dgvVolantes.AllowUserToAddRows = false;
            this.dgvVolantes.AllowUserToDeleteRows = false;
            this.dgvVolantes.BackgroundColor = System.Drawing.Color.FromArgb(18, 24, 48);
            this.dgvVolantes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVolantes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvVolantes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvVolantes.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(20, 28, 58);
            this.dgvVolantes.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.dgvVolantes.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.dgvVolantes.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(20, 28, 58);
            this.dgvVolantes.ColumnHeadersHeight = 36;
            this.dgvVolantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvVolantes.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(18, 24, 48);
            this.dgvVolantes.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvVolantes.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvVolantes.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(25, 35, 70);
            this.dgvVolantes.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.dgvVolantes.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dgvVolantes.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(20, 28, 55);
            this.dgvVolantes.EnableHeadersVisualStyles = false;
            this.dgvVolantes.GridColor = System.Drawing.Color.FromArgb(30, 40, 80);
            this.dgvVolantes.Location = new System.Drawing.Point(0, 0);
            this.dgvVolantes.MultiSelect = false;
            this.dgvVolantes.Name = "dgvVolantes";
            this.dgvVolantes.ReadOnly = true;
            this.dgvVolantes.RowHeadersVisible = false;
            this.dgvVolantes.RowTemplate.Height = 40;
            this.dgvVolantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVolantes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVolantes.Size = new System.Drawing.Size(868, 340);
            this.dgvVolantes.TabIndex = 0;
            this.dgvVolantes.Anchor = System.Windows.Forms.AnchorStyles.Top |
                                      System.Windows.Forms.AnchorStyles.Left |
                                      System.Windows.Forms.AnchorStyles.Right |
                                      System.Windows.Forms.AnchorStyles.Bottom;

            // ── FrmVolantesLista ──────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(13, 17, 35);
            this.ClientSize = new System.Drawing.Size(900, 537);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlFiltro);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.pnlTabla);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmVolantesLista";
            this.Text = "Volantes de Pago";
            this.Load += new System.EventHandler(this.FrmVolantesLista_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFiltro.ResumeLayout(false);
            this.pnlFiltro.PerformLayout();
            this.pnlTabla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVolantes)).EndInit();
            this.ResumeLayout(false);
        }

        // ── Declaraciones ──────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTituloPagina;
        private System.Windows.Forms.Label lblSubtituloPagina;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Panel pnlFiltro;
        private System.Windows.Forms.Label lblFiltroTitulo;
        private System.Windows.Forms.Label lblFiltroEmp;
        private System.Windows.Forms.ComboBox cmbFiltroEmpleado;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblConteo;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Panel pnlTabla;
        private System.Windows.Forms.DataGridView dgvVolantes;
    }
}