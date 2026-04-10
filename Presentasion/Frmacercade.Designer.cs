namespace Presentacion
{
    partial class FrmAcercaDe
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
            this.lblSub = new System.Windows.Forms.Label();
            this.pnlCuerpo = new System.Windows.Forms.Panel();
            this.lblSistema = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblSep = new System.Windows.Forms.Panel();
            this.lblGrupo = new System.Windows.Forms.Label();

            this.lblP1 = new System.Windows.Forms.Label();
            this.lblP2 = new System.Windows.Forms.Label();
            this.lblP3 = new System.Windows.Forms.Label();
            this.lblP4 = new System.Windows.Forms.Label();
            this.lblP5 = new System.Windows.Forms.Label();

            this.lblTecno = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlCuerpo.SuspendLayout();
            this.SuspendLayout();

            // ── pnlHeader ────────────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(15, 22, 45);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Controls.Add(this.lblSub);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Size = new System.Drawing.Size(440, 70);
            this.pnlHeader.TabIndex = 0;

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.lblTitulo.Location = new System.Drawing.Point(20, 12);
            this.lblTitulo.Text = "TalentBus DB3";

            this.lblSub.AutoSize = true;
            this.lblSub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSub.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblSub.Location = new System.Drawing.Point(22, 38);
            this.lblSub.Text = "Sistema de Gestión de Nómina";

            // ── pnlCuerpo ─────────────────────────────────────────────────
            this.pnlCuerpo.BackColor = System.Drawing.Color.FromArgb(18, 24, 48);
            this.pnlCuerpo.Controls.Add(this.lblSistema);
            this.pnlCuerpo.Controls.Add(this.lblVersion);
            this.pnlCuerpo.Controls.Add(this.lblSep);
            this.pnlCuerpo.Controls.Add(this.lblGrupo);
            this.pnlCuerpo.Controls.Add(this.lblP1);
            this.pnlCuerpo.Controls.Add(this.lblP2);
            this.pnlCuerpo.Controls.Add(this.lblP3);
            this.pnlCuerpo.Controls.Add(this.lblP4);
            this.pnlCuerpo.Controls.Add(this.lblP5);
            this.pnlCuerpo.Controls.Add(this.lblTecno);
            this.pnlCuerpo.Controls.Add(this.btnCerrar);
            this.pnlCuerpo.Location = new System.Drawing.Point(16, 78);
            this.pnlCuerpo.Size = new System.Drawing.Size(408, 344);
            this.pnlCuerpo.TabIndex = 1;

            // Info del sistema
            this.lblSistema.AutoSize = true;
            this.lblSistema.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSistema.ForeColor = System.Drawing.Color.White;
            this.lblSistema.Location = new System.Drawing.Point(20, 20);
            this.lblSistema.Text = "Sistema de Gestion de Nomina";

            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblVersion.Location = new System.Drawing.Point(20, 42);
            this.lblVersion.Text = "Versión 1.0  |  C# .NET Framework  |  SQL Server";

            // Separador
            this.lblSep.BackColor = System.Drawing.Color.FromArgb(30, 40, 80);
            this.lblSep.Location = new System.Drawing.Point(20, 68);
            this.lblSep.Size = new System.Drawing.Size(368, 1);

            // Participantes
            this.lblGrupo.AutoSize = true;
            this.lblGrupo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblGrupo.ForeColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.lblGrupo.Location = new System.Drawing.Point(20, 80);
            this.lblGrupo.Text = "PARTICIPANTES DEL GRUPO";

            this.lblP1.AutoSize = true;
            this.lblP1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblP1.ForeColor = System.Drawing.Color.White;
            this.lblP1.Location = new System.Drawing.Point(30, 108);
            this.lblP1.Text = "►  Javier Bisonó  —  2024-4027";

            this.lblP2.AutoSize = true;
            this.lblP2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblP2.ForeColor = System.Drawing.Color.White;
            this.lblP2.Location = new System.Drawing.Point(30, 134);
            this.lblP2.Text = "►  Julio César Rivera Peguero  —  2023-0728";

            this.lblP3.AutoSize = true;
            this.lblP3.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblP3.ForeColor = System.Drawing.Color.White;
            this.lblP3.Location = new System.Drawing.Point(30, 160);
            this.lblP3.Text = "►  Erick Montero  —  2024-3344";

            this.lblP4.AutoSize = true;
            this.lblP4.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblP4.ForeColor = System.Drawing.Color.White;
            this.lblP4.Location = new System.Drawing.Point(30, 186);
            this.lblP4.Text = "►  Jordan Alexander Guzmán Cedano  —  2024-3553";

            this.lblP5.AutoSize = true;
            this.lblP5.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblP5.ForeColor = System.Drawing.Color.White;
            this.lblP5.Location = new System.Drawing.Point(30, 212);
            this.lblP5.Name = "lblP5";
            this.lblP5.TabIndex = 9;
            this.lblP5.Text = "►  Angel Natera  —  2023-3607";

            this.lblTecno.AutoSize = true;
            this.lblTecno.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblTecno.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblTecno.Location = new System.Drawing.Point(20, 252);
            this.lblTecno.Text = "Desarrollado en Visual Studio  |  Arquitectura en Capas  |  2026";

            // Botón cerrar
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(255, 80, 80);
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(154, 292);
            this.btnCerrar.Size = new System.Drawing.Size(100, 34);
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;

            // ── FrmAcercaDe ───────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(13, 17, 35);
            this.ClientSize = new System.Drawing.Size(440, 438);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlCuerpo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAcercaDe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acerca de TalentBus";
            this.Load += new System.EventHandler(this.FrmAcercaDe_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlCuerpo.ResumeLayout(false);
            this.pnlCuerpo.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSub;
        private System.Windows.Forms.Panel pnlCuerpo;
        private System.Windows.Forms.Label lblSistema;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Panel lblSep;
        private System.Windows.Forms.Label lblGrupo;
        private System.Windows.Forms.Label lblP1;
        private System.Windows.Forms.Label lblP2;
        private System.Windows.Forms.Label lblP3;
        private System.Windows.Forms.Label lblP4;
        private System.Windows.Forms.Label lblP5;
        private System.Windows.Forms.Label lblTecno;
        private System.Windows.Forms.Button btnCerrar;
    }
}
