namespace Presentacion
{
    partial class FrmDetalleVolantePago
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
            this.lblHeaderTitulo = new System.Windows.Forms.Label();
            this.lblHeaderSub = new System.Windows.Forms.Label();

            this.pnlCuerpo = new System.Windows.Forms.Panel();

            this.lblRotCodigo = new System.Windows.Forms.Label();
            this.lblVCodigo = new System.Windows.Forms.Label();
            this.lblRotEmpleado = new System.Windows.Forms.Label();
            this.lblVEmpleado = new System.Windows.Forms.Label();
            this.lblRotPosicion = new System.Windows.Forms.Label();
            this.lblVPosicion = new System.Windows.Forms.Label();
            this.lblRotFecha = new System.Windows.Forms.Label();
            this.lblVFecha = new System.Windows.Forms.Label();

            this.sep1 = new System.Windows.Forms.Panel();

            this.lblRotSubtotal = new System.Windows.Forms.Label();
            this.lblVSubtotal = new System.Windows.Forms.Label();
            this.lblRotDed = new System.Windows.Forms.Label();
            this.lblVDeducciones = new System.Windows.Forms.Label();

            this.sep2 = new System.Windows.Forms.Panel();
            this.sep2b = new System.Windows.Forms.Panel();

            this.lblRotTotal = new System.Windows.Forms.Label();
            this.lblVTotal = new System.Windows.Forms.Label();

            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlCuerpo.SuspendLayout();
            this.SuspendLayout();

            // ── pnlHeader ────────────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(15, 22, 45);
            this.pnlHeader.Controls.Add(this.lblHeaderTitulo);
            this.pnlHeader.Controls.Add(this.lblHeaderSub);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(400, 64);
            this.pnlHeader.TabIndex = 0;

            this.lblHeaderTitulo.AutoSize = true;
            this.lblHeaderTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitulo.ForeColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.lblHeaderTitulo.Location = new System.Drawing.Point(20, 12);
            this.lblHeaderTitulo.Name = "lblHeaderTitulo";
            this.lblHeaderTitulo.TabIndex = 0;
            this.lblHeaderTitulo.Text = "VOLANTE DE PAGO";

            this.lblHeaderSub.AutoSize = true;
            this.lblHeaderSub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblHeaderSub.Location = new System.Drawing.Point(22, 38);
            this.lblHeaderSub.Name = "lblHeaderSub";
            this.lblHeaderSub.TabIndex = 1;
            this.lblHeaderSub.Text = "TalentBus DB3";

            // ── pnlCuerpo ─────────────────────────────────────────────────
            this.pnlCuerpo.BackColor = System.Drawing.Color.FromArgb(18, 24, 48);
            this.pnlCuerpo.Controls.Add(this.lblRotCodigo);
            this.pnlCuerpo.Controls.Add(this.lblVCodigo);
            this.pnlCuerpo.Controls.Add(this.lblRotEmpleado);
            this.pnlCuerpo.Controls.Add(this.lblVEmpleado);
            this.pnlCuerpo.Controls.Add(this.lblRotPosicion);
            this.pnlCuerpo.Controls.Add(this.lblVPosicion);
            this.pnlCuerpo.Controls.Add(this.lblRotFecha);
            this.pnlCuerpo.Controls.Add(this.lblVFecha);
            this.pnlCuerpo.Controls.Add(this.sep1);
            this.pnlCuerpo.Controls.Add(this.lblRotSubtotal);
            this.pnlCuerpo.Controls.Add(this.lblVSubtotal);
            this.pnlCuerpo.Controls.Add(this.lblRotDed);
            this.pnlCuerpo.Controls.Add(this.lblVDeducciones);
            this.pnlCuerpo.Controls.Add(this.sep2);
            this.pnlCuerpo.Controls.Add(this.sep2b);
            this.pnlCuerpo.Controls.Add(this.lblRotTotal);
            this.pnlCuerpo.Controls.Add(this.lblVTotal);
            this.pnlCuerpo.Controls.Add(this.btnImprimir);
            this.pnlCuerpo.Controls.Add(this.btnCerrar);
            this.pnlCuerpo.Location = new System.Drawing.Point(16, 72);
            this.pnlCuerpo.Name = "pnlCuerpo";
            this.pnlCuerpo.Size = new System.Drawing.Size(368, 360);
            this.pnlCuerpo.TabIndex = 1;

            // Info empleado
            this.lblRotCodigo.AutoSize = true;
            this.lblRotCodigo.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblRotCodigo.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblRotCodigo.Location = new System.Drawing.Point(20, 16);
            this.lblRotCodigo.Name = "lblRotCodigo"; this.lblRotCodigo.TabIndex = 0;
            this.lblRotCodigo.Text = "Código:";

            this.lblVCodigo.AutoSize = true;
            this.lblVCodigo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVCodigo.ForeColor = System.Drawing.Color.White;
            this.lblVCodigo.Location = new System.Drawing.Point(160, 16);
            this.lblVCodigo.Name = "lblVCodigo"; this.lblVCodigo.TabIndex = 1;
            this.lblVCodigo.Text = "—";

            this.lblRotEmpleado.AutoSize = true;
            this.lblRotEmpleado.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblRotEmpleado.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblRotEmpleado.Location = new System.Drawing.Point(20, 40);
            this.lblRotEmpleado.Name = "lblRotEmpleado"; this.lblRotEmpleado.TabIndex = 2;
            this.lblRotEmpleado.Text = "Empleado:";

            this.lblVEmpleado.AutoSize = true;
            this.lblVEmpleado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblVEmpleado.ForeColor = System.Drawing.Color.White;
            this.lblVEmpleado.Location = new System.Drawing.Point(160, 40);
            this.lblVEmpleado.Name = "lblVEmpleado"; this.lblVEmpleado.TabIndex = 3;
            this.lblVEmpleado.Text = "—";

            this.lblRotPosicion.AutoSize = true;
            this.lblRotPosicion.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblRotPosicion.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblRotPosicion.Location = new System.Drawing.Point(20, 64);
            this.lblRotPosicion.Name = "lblRotPosicion"; this.lblRotPosicion.TabIndex = 4;
            this.lblRotPosicion.Text = "Posición:";

            this.lblVPosicion.AutoSize = true;
            this.lblVPosicion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVPosicion.ForeColor = System.Drawing.Color.White;
            this.lblVPosicion.Location = new System.Drawing.Point(160, 64);
            this.lblVPosicion.Name = "lblVPosicion"; this.lblVPosicion.TabIndex = 5;
            this.lblVPosicion.Text = "—";

            this.lblRotFecha.AutoSize = true;
            this.lblRotFecha.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblRotFecha.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblRotFecha.Location = new System.Drawing.Point(20, 88);
            this.lblRotFecha.Name = "lblRotFecha"; this.lblRotFecha.TabIndex = 6;
            this.lblRotFecha.Text = "Período:";

            this.lblVFecha.AutoSize = true;
            this.lblVFecha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVFecha.ForeColor = System.Drawing.Color.White;
            this.lblVFecha.Location = new System.Drawing.Point(160, 88);
            this.lblVFecha.Name = "lblVFecha"; this.lblVFecha.TabIndex = 7;
            this.lblVFecha.Text = "—";

            // sep1
            this.sep1.BackColor = System.Drawing.Color.FromArgb(30, 40, 80);
            this.sep1.Location = new System.Drawing.Point(20, 112); this.sep1.Name = "sep1";
            this.sep1.Size = new System.Drawing.Size(328, 1); this.sep1.TabIndex = 8;

            // Montos
            this.lblRotSubtotal.AutoSize = true;
            this.lblRotSubtotal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRotSubtotal.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblRotSubtotal.Location = new System.Drawing.Point(20, 122);
            this.lblRotSubtotal.Name = "lblRotSubtotal"; this.lblRotSubtotal.TabIndex = 9;
            this.lblRotSubtotal.Text = "Subtotal (Ingresos):";

            this.lblVSubtotal.AutoSize = true;
            this.lblVSubtotal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVSubtotal.ForeColor = System.Drawing.Color.White;
            this.lblVSubtotal.Location = new System.Drawing.Point(230, 122);
            this.lblVSubtotal.Name = "lblVSubtotal"; this.lblVSubtotal.TabIndex = 10;
            this.lblVSubtotal.Text = "—";

            this.lblRotDed.AutoSize = true;
            this.lblRotDed.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRotDed.ForeColor = System.Drawing.Color.FromArgb(255, 80, 80);
            this.lblRotDed.Location = new System.Drawing.Point(20, 148);
            this.lblRotDed.Name = "lblRotDed"; this.lblRotDed.TabIndex = 11;
            this.lblRotDed.Text = "Deducciones:";

            this.lblVDeducciones.AutoSize = true;
            this.lblVDeducciones.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVDeducciones.ForeColor = System.Drawing.Color.FromArgb(255, 80, 80);
            this.lblVDeducciones.Location = new System.Drawing.Point(230, 148);
            this.lblVDeducciones.Name = "lblVDeducciones"; this.lblVDeducciones.TabIndex = 12;
            this.lblVDeducciones.Text = "—";

            this.sep2.BackColor = System.Drawing.Color.FromArgb(30, 40, 80);
            this.sep2.Location = new System.Drawing.Point(20, 178); this.sep2.Name = "sep2";
            this.sep2.Size = new System.Drawing.Size(328, 1); this.sep2.TabIndex = 13;

            this.sep2b.BackColor = System.Drawing.Color.FromArgb(30, 40, 80);
            this.sep2b.Location = new System.Drawing.Point(20, 182); this.sep2b.Name = "sep2b";
            this.sep2b.Size = new System.Drawing.Size(328, 1); this.sep2b.TabIndex = 14;

            this.lblRotTotal.AutoSize = true;
            this.lblRotTotal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblRotTotal.ForeColor = System.Drawing.Color.White;
            this.lblRotTotal.Location = new System.Drawing.Point(20, 192);
            this.lblRotTotal.Name = "lblRotTotal"; this.lblRotTotal.TabIndex = 15;
            this.lblRotTotal.Text = "TOTAL NETO:";

            this.lblVTotal.AutoSize = true;
            this.lblVTotal.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblVTotal.ForeColor = System.Drawing.Color.FromArgb(39, 201, 63);
            this.lblVTotal.Location = new System.Drawing.Point(200, 189);
            this.lblVTotal.Name = "lblVTotal"; this.lblVTotal.TabIndex = 16;
            this.lblVTotal.Text = "—";

            // Botones
            this.btnImprimir.BackColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnImprimir.ForeColor = System.Drawing.Color.FromArgb(13, 17, 35);
            this.btnImprimir.Location = new System.Drawing.Point(20, 310);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(156, 34);
            this.btnImprimir.TabIndex = 17;
            this.btnImprimir.Text = "🖨  Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = false;

            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(255, 80, 80);
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(192, 310);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(156, 34);
            this.btnCerrar.TabIndex = 18;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;

            // ── FrmDetalleVolantePago ─────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(13, 17, 35);
            this.ClientSize = new System.Drawing.Size(400, 448);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlCuerpo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDetalleVolantePago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Volante de Pago";
            this.Load += new System.EventHandler(this.FrmDetalleVolantePago_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlCuerpo.ResumeLayout(false);
            this.pnlCuerpo.PerformLayout();
            this.ResumeLayout(false);
        }

        // ── Declaraciones ──────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitulo;
        private System.Windows.Forms.Label lblHeaderSub;
        private System.Windows.Forms.Panel pnlCuerpo;
        private System.Windows.Forms.Label lblRotCodigo;
        private System.Windows.Forms.Label lblVCodigo;
        private System.Windows.Forms.Label lblRotEmpleado;
        private System.Windows.Forms.Label lblVEmpleado;
        private System.Windows.Forms.Label lblRotPosicion;
        private System.Windows.Forms.Label lblVPosicion;
        private System.Windows.Forms.Label lblRotFecha;
        private System.Windows.Forms.Label lblVFecha;
        private System.Windows.Forms.Panel sep1;
        private System.Windows.Forms.Label lblRotSubtotal;
        private System.Windows.Forms.Label lblVSubtotal;
        private System.Windows.Forms.Label lblRotDed;
        private System.Windows.Forms.Label lblVDeducciones;
        private System.Windows.Forms.Panel sep2;
        private System.Windows.Forms.Panel sep2b;
        private System.Windows.Forms.Label lblRotTotal;
        private System.Windows.Forms.Label lblVTotal;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnCerrar;
    }
}
