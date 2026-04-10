namespace Presentacion
{
    partial class FrmConsulta
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
            this.pnlFiltro = new System.Windows.Forms.Panel();
            this.lblLblTabla = new System.Windows.Forms.Label();
            this.lblTablaTitulo = new System.Windows.Forms.Label();
            this.cmbTabla = new System.Windows.Forms.ComboBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.lblConteo = new System.Windows.Forms.Label();
            this.dgvResultados = new System.Windows.Forms.DataGridView();

            this.pnlHeader.SuspendLayout();
            this.pnlFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).BeginInit();
            this.SuspendLayout();

            // ── pnlHeader ────────────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(18, 24, 48);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Controls.Add(this.lblSubtitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Size = new System.Drawing.Size(900, 64);
            this.pnlHeader.TabIndex = 0;

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(28, 12);
            this.lblTitulo.Text = "Consulta";

            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblSubtitulo.Location = new System.Drawing.Point(30, 40);
            this.lblSubtitulo.Text = "Visualización de datos guardados en el sistema — solo lectura";

            // ── pnlFiltro ─────────────────────────────────────────────────
            this.pnlFiltro.BackColor = System.Drawing.Color.FromArgb(18, 24, 48);
            this.pnlFiltro.Controls.Add(this.lblTablaTitulo);
            this.pnlFiltro.Controls.Add(this.lblLblTabla);
            this.pnlFiltro.Controls.Add(this.cmbTabla);
            this.pnlFiltro.Controls.Add(this.btnConsultar);
            this.pnlFiltro.Location = new System.Drawing.Point(16, 72);
            this.pnlFiltro.Size = new System.Drawing.Size(868, 76);
            this.pnlFiltro.TabIndex = 1;

            this.lblTablaTitulo.AutoSize = true;
            this.lblTablaTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTablaTitulo.ForeColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.lblTablaTitulo.Location = new System.Drawing.Point(14, 10);
            this.lblTablaTitulo.Text = "Seleccionar tabla a consultar";

            this.lblLblTabla.AutoSize = true;
            this.lblLblTabla.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblLblTabla.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblLblTabla.Location = new System.Drawing.Point(14, 36);
            this.lblLblTabla.Text = "Módulo";

            this.cmbTabla.BackColor = System.Drawing.Color.FromArgb(25, 35, 65);
            this.cmbTabla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTabla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTabla.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbTabla.ForeColor = System.Drawing.Color.White;
            this.cmbTabla.Location = new System.Drawing.Point(74, 32);
            this.cmbTabla.Size = new System.Drawing.Size(300, 23);
            this.cmbTabla.TabIndex = 1;

            this.btnConsultar.BackColor = System.Drawing.Color.FromArgb(30, 80, 180);
            this.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConsultar.FlatAppearance.BorderSize = 0;
            this.btnConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnConsultar.ForeColor = System.Drawing.Color.White;
            this.btnConsultar.Location = new System.Drawing.Point(388, 30);
            this.btnConsultar.Size = new System.Drawing.Size(110, 28);
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = false;
            this.btnConsultar.TabIndex = 2;

            // ── lblConteo ─────────────────────────────────────────────────
            this.lblConteo.AutoSize = false;
            this.lblConteo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblConteo.ForeColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.lblConteo.Location = new System.Drawing.Point(16, 154);
            this.lblConteo.Size = new System.Drawing.Size(700, 22);
            this.lblConteo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblConteo.Text = "";

            // ── dgvResultados ─────────────────────────────────────────────
            this.dgvResultados.AllowUserToAddRows = false;
            this.dgvResultados.AllowUserToDeleteRows = false;
            this.dgvResultados.BackgroundColor = System.Drawing.Color.FromArgb(18, 24, 48);
            this.dgvResultados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvResultados.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvResultados.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvResultados.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(20, 28, 58);
            this.dgvResultados.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.dgvResultados.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.dgvResultados.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(20, 28, 58);
            this.dgvResultados.ColumnHeadersHeight = 36;
            this.dgvResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvResultados.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(18, 24, 48);
            this.dgvResultados.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvResultados.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvResultados.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(25, 35, 70);
            this.dgvResultados.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.dgvResultados.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dgvResultados.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(20, 28, 55);
            this.dgvResultados.EnableHeadersVisualStyles = false;
            this.dgvResultados.GridColor = System.Drawing.Color.FromArgb(30, 40, 80);
            this.dgvResultados.Location = new System.Drawing.Point(16, 180);
            this.dgvResultados.MultiSelect = false;
            this.dgvResultados.Name = "dgvResultados";
            this.dgvResultados.ReadOnly = true;
            this.dgvResultados.RowHeadersVisible = false;
            this.dgvResultados.RowTemplate.Height = 40;
            this.dgvResultados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResultados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResultados.Size = new System.Drawing.Size(868, 340);
            this.dgvResultados.TabIndex = 3;
            this.dgvResultados.Anchor = System.Windows.Forms.AnchorStyles.Top |
                                        System.Windows.Forms.AnchorStyles.Left |
                                        System.Windows.Forms.AnchorStyles.Right |
                                        System.Windows.Forms.AnchorStyles.Bottom;

            // ── FrmConsulta ───────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(13, 17, 35);
            this.ClientSize = new System.Drawing.Size(900, 537);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlFiltro);
            this.Controls.Add(this.lblConteo);
            this.Controls.Add(this.dgvResultados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmConsulta";
            this.Text = "Consulta";
            this.Load += new System.EventHandler(this.FrmConsulta_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFiltro.ResumeLayout(false);
            this.pnlFiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel pnlFiltro;
        private System.Windows.Forms.Label lblTablaTitulo;
        private System.Windows.Forms.Label lblLblTabla;
        private System.Windows.Forms.ComboBox cmbTabla;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Label lblConteo;
        private System.Windows.Forms.DataGridView dgvResultados;
    }
}
