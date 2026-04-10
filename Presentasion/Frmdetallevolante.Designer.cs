namespace Presentacion
{
    partial class FrmDetalleVolante
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
            this.btnCerrarX = new System.Windows.Forms.Button();

            this.pnlCuerpo = new System.Windows.Forms.Panel();

            // Info empleado
            this.lblRotCodigo = new System.Windows.Forms.Label();
            this.lblVCodigo = new System.Windows.Forms.Label();
            this.lblRotEmpleado = new System.Windows.Forms.Label();
            this.lblVEmpleado = new System.Windows.Forms.Label();
            this.lblRotPosicion = new System.Windows.Forms.Label();
            this.lblVPosicion = new System.Windows.Forms.Label();
            this.lblRotFecha = new System.Windows.Forms.Label();
            this.lblVFecha = new System.Windows.Forms.Label();

            // Separadores
            this.sep1 = new System.Windows.Forms.Panel();
            this.sep2 = new System.Windows.Forms.Panel();
            this.sep3 = new System.Windows.Forms.Panel();
            this.sep3b = new System.Windows.Forms.Panel();

            // Ingresos
            this.lblTitIngresos = new System.Windows.Forms.Label();
            this.lblRotSueldo = new System.Windows.Forms.Label();
            this.lblVSueldo = new System.Windows.Forms.Label();
            this.lblRotAsig = new System.Windows.Forms.Label();
            this.lblVAsignacion = new System.Windows.Forms.Label();
            this.lblRotSubtotal = new System.Windows.Forms.Label();
            this.lblVSubtotal = new System.Windows.Forms.Label();

            // Deducciones
            this.lblTitDed = new System.Windows.Forms.Label();
            this.lblRotTotalDed = new System.Windows.Forms.Label();
            this.lblVDeducciones = new System.Windows.Forms.Label();

            // Neto
            this.lblRotNeto = new System.Windows.Forms.Label();
            this.lblVNeto = new System.Windows.Forms.Label();

            // Botones
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlCuerpo.SuspendLayout();
            this.SuspendLayout();

            // ── pnlHeader ────────────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(15, 22, 45);
            this.pnlHeader.Controls.Add(this.lblHeaderTitulo);
            this.pnlHeader.Controls.Add(this.lblHeaderSub);
            this.pnlHeader.Controls.Add(this.btnCerrarX);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(400, 70);
            this.pnlHeader.TabIndex = 0;

            this.lblHeaderTitulo.AutoSize = true;
            this.lblHeaderTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitulo.ForeColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.lblHeaderTitulo.Location = new System.Drawing.Point(20, 12);
            this.lblHeaderTitulo.Name = "lblHeaderTitulo";
            this.lblHeaderTitulo.TabIndex = 0;
            this.lblHeaderTitulo.Text = "SUELDO NETO";

            this.lblHeaderSub.AutoSize = true;
            this.lblHeaderSub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblHeaderSub.Location = new System.Drawing.Point(22, 38);
            this.lblHeaderSub.Name = "lblHeaderSub";
            this.lblHeaderSub.TabIndex = 1;
            this.lblHeaderSub.Text = "TalentBus DB3";

            this.btnCerrarX.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrarX.FlatAppearance.BorderSize = 0;
            this.btnCerrarX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarX.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCerrarX.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.btnCerrarX.Location = new System.Drawing.Point(362, 18);
            this.btnCerrarX.Name = "btnCerrarX";
            this.btnCerrarX.Size = new System.Drawing.Size(28, 28);
            this.btnCerrarX.TabIndex = 2;
            this.btnCerrarX.Text = "✕";
            this.btnCerrarX.UseVisualStyleBackColor = false;
            this.btnCerrarX.Click += new System.EventHandler(this.FrmDetalleVolante_Load);

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
            this.pnlCuerpo.Controls.Add(this.lblTitIngresos);
            this.pnlCuerpo.Controls.Add(this.lblRotSueldo);
            this.pnlCuerpo.Controls.Add(this.lblVSueldo);
            this.pnlCuerpo.Controls.Add(this.lblRotAsig);
            this.pnlCuerpo.Controls.Add(this.lblVAsignacion);
            this.pnlCuerpo.Controls.Add(this.lblRotSubtotal);
            this.pnlCuerpo.Controls.Add(this.lblVSubtotal);
            this.pnlCuerpo.Controls.Add(this.sep2);
            this.pnlCuerpo.Controls.Add(this.lblTitDed);
            this.pnlCuerpo.Controls.Add(this.lblRotTotalDed);
            this.pnlCuerpo.Controls.Add(this.lblVDeducciones);
            this.pnlCuerpo.Controls.Add(this.sep3);
            this.pnlCuerpo.Controls.Add(this.sep3b);
            this.pnlCuerpo.Controls.Add(this.lblRotNeto);
            this.pnlCuerpo.Controls.Add(this.lblVNeto);
            this.pnlCuerpo.Controls.Add(this.btnCerrar);
            this.pnlCuerpo.Controls.Add(this.btnImprimir);
            this.pnlCuerpo.Location = new System.Drawing.Point(16, 78);
            this.pnlCuerpo.Name = "pnlCuerpo";
            this.pnlCuerpo.Size = new System.Drawing.Size(368, 440);
            this.pnlCuerpo.TabIndex = 1;

            // ── Info empleado ─────────────────────────────────────────────
            // Código
            this.lblRotCodigo.AutoSize = true;
            this.lblRotCodigo.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblRotCodigo.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblRotCodigo.Location = new System.Drawing.Point(20, 16);
            this.lblRotCodigo.Name = "lblRotCodigo";
            this.lblRotCodigo.TabIndex = 0;
            this.lblRotCodigo.Text = "Código:";

            this.lblVCodigo.AutoSize = true;
            this.lblVCodigo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVCodigo.ForeColor = System.Drawing.Color.White;
            this.lblVCodigo.Location = new System.Drawing.Point(150, 16);
            this.lblVCodigo.Name = "lblVCodigo";
            this.lblVCodigo.TabIndex = 1;
            this.lblVCodigo.Text = "—";

            // Empleado
            this.lblRotEmpleado.AutoSize = true;
            this.lblRotEmpleado.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblRotEmpleado.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblRotEmpleado.Location = new System.Drawing.Point(20, 40);
            this.lblRotEmpleado.Name = "lblRotEmpleado";
            this.lblRotEmpleado.TabIndex = 2;
            this.lblRotEmpleado.Text = "Empleado:";

            this.lblVEmpleado.AutoSize = true;
            this.lblVEmpleado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblVEmpleado.ForeColor = System.Drawing.Color.White;
            this.lblVEmpleado.Location = new System.Drawing.Point(150, 40);
            this.lblVEmpleado.Name = "lblVEmpleado";
            this.lblVEmpleado.TabIndex = 3;
            this.lblVEmpleado.Text = "—";

            // Posición
            this.lblRotPosicion.AutoSize = true;
            this.lblRotPosicion.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblRotPosicion.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblRotPosicion.Location = new System.Drawing.Point(20, 64);
            this.lblRotPosicion.Name = "lblRotPosicion";
            this.lblRotPosicion.TabIndex = 4;
            this.lblRotPosicion.Text = "Posición:";

            this.lblVPosicion.AutoSize = true;
            this.lblVPosicion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVPosicion.ForeColor = System.Drawing.Color.White;
            this.lblVPosicion.Location = new System.Drawing.Point(150, 64);
            this.lblVPosicion.Name = "lblVPosicion";
            this.lblVPosicion.TabIndex = 5;
            this.lblVPosicion.Text = "—";

            // Período
            this.lblRotFecha.AutoSize = true;
            this.lblRotFecha.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblRotFecha.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblRotFecha.Location = new System.Drawing.Point(20, 88);
            this.lblRotFecha.Name = "lblRotFecha";
            this.lblRotFecha.TabIndex = 6;
            this.lblRotFecha.Text = "Período:";

            this.lblVFecha.AutoSize = true;
            this.lblVFecha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVFecha.ForeColor = System.Drawing.Color.White;
            this.lblVFecha.Location = new System.Drawing.Point(150, 88);
            this.lblVFecha.Name = "lblVFecha";
            this.lblVFecha.TabIndex = 7;
            this.lblVFecha.Text = "—";

            // sep1
            this.sep1.BackColor = System.Drawing.Color.FromArgb(30, 40, 80);
            this.sep1.Location = new System.Drawing.Point(20, 112);
            this.sep1.Name = "sep1";
            this.sep1.Size = new System.Drawing.Size(328, 1);
            this.sep1.TabIndex = 8;

            // ── INGRESOS ──────────────────────────────────────────────────
            this.lblTitIngresos.AutoSize = true;
            this.lblTitIngresos.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblTitIngresos.ForeColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.lblTitIngresos.Location = new System.Drawing.Point(20, 122);
            this.lblTitIngresos.Name = "lblTitIngresos";
            this.lblTitIngresos.TabIndex = 9;
            this.lblTitIngresos.Text = "INGRESOS";

            this.lblRotSueldo.AutoSize = true;
            this.lblRotSueldo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblRotSueldo.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblRotSueldo.Location = new System.Drawing.Point(20, 146);
            this.lblRotSueldo.Name = "lblRotSueldo";
            this.lblRotSueldo.TabIndex = 10;
            this.lblRotSueldo.Text = "Sueldo Base:";

            this.lblVSueldo.AutoSize = true;
            this.lblVSueldo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVSueldo.ForeColor = System.Drawing.Color.White;
            this.lblVSueldo.Location = new System.Drawing.Point(230, 146);
            this.lblVSueldo.Name = "lblVSueldo";
            this.lblVSueldo.TabIndex = 11;
            this.lblVSueldo.Text = "—";

            this.lblRotAsig.AutoSize = true;
            this.lblRotAsig.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblRotAsig.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblRotAsig.Location = new System.Drawing.Point(20, 170);
            this.lblRotAsig.Name = "lblRotAsig";
            this.lblRotAsig.TabIndex = 12;
            this.lblRotAsig.Text = "Asignaciones:";

            this.lblVAsignacion.AutoSize = true;
            this.lblVAsignacion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVAsignacion.ForeColor = System.Drawing.Color.White;
            this.lblVAsignacion.Location = new System.Drawing.Point(230, 170);
            this.lblVAsignacion.Name = "lblVAsignacion";
            this.lblVAsignacion.TabIndex = 13;
            this.lblVAsignacion.Text = "—";

            this.lblRotSubtotal.AutoSize = true;
            this.lblRotSubtotal.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblRotSubtotal.ForeColor = System.Drawing.Color.White;
            this.lblRotSubtotal.Location = new System.Drawing.Point(20, 194);
            this.lblRotSubtotal.Name = "lblRotSubtotal";
            this.lblRotSubtotal.TabIndex = 14;
            this.lblRotSubtotal.Text = "Subtotal:";

            this.lblVSubtotal.AutoSize = true;
            this.lblVSubtotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblVSubtotal.ForeColor = System.Drawing.Color.White;
            this.lblVSubtotal.Location = new System.Drawing.Point(230, 194);
            this.lblVSubtotal.Name = "lblVSubtotal";
            this.lblVSubtotal.TabIndex = 15;
            this.lblVSubtotal.Text = "—";

            // sep2
            this.sep2.BackColor = System.Drawing.Color.FromArgb(30, 40, 80);
            this.sep2.Location = new System.Drawing.Point(20, 218);
            this.sep2.Name = "sep2";
            this.sep2.Size = new System.Drawing.Size(328, 1);
            this.sep2.TabIndex = 16;

            // ── DEDUCCIONES ───────────────────────────────────────────────
            this.lblTitDed.AutoSize = true;
            this.lblTitDed.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblTitDed.ForeColor = System.Drawing.Color.FromArgb(255, 80, 80);
            this.lblTitDed.Location = new System.Drawing.Point(20, 228);
            this.lblTitDed.Name = "lblTitDed";
            this.lblTitDed.TabIndex = 17;
            this.lblTitDed.Text = "DEDUCCIONES";

            this.lblRotTotalDed.AutoSize = true;
            this.lblRotTotalDed.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblRotTotalDed.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblRotTotalDed.Location = new System.Drawing.Point(20, 252);
            this.lblRotTotalDed.Name = "lblRotTotalDed";
            this.lblRotTotalDed.TabIndex = 18;
            this.lblRotTotalDed.Text = "Total Deducciones:";

            this.lblVDeducciones.AutoSize = true;
            this.lblVDeducciones.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVDeducciones.ForeColor = System.Drawing.Color.FromArgb(255, 80, 80);
            this.lblVDeducciones.Location = new System.Drawing.Point(230, 252);
            this.lblVDeducciones.Name = "lblVDeducciones";
            this.lblVDeducciones.TabIndex = 19;
            this.lblVDeducciones.Text = "—";

            // sep3 doble
            this.sep3.BackColor = System.Drawing.Color.FromArgb(30, 40, 80);
            this.sep3.Location = new System.Drawing.Point(20, 278);
            this.sep3.Name = "sep3";
            this.sep3.Size = new System.Drawing.Size(328, 1);
            this.sep3.TabIndex = 20;

            this.sep3b.BackColor = System.Drawing.Color.FromArgb(30, 40, 80);
            this.sep3b.Location = new System.Drawing.Point(20, 282);
            this.sep3b.Name = "sep3b";
            this.sep3b.Size = new System.Drawing.Size(328, 1);
            this.sep3b.TabIndex = 21;

            // ── SALARIO NETO ──────────────────────────────────────────────
            this.lblRotNeto.AutoSize = true;
            this.lblRotNeto.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblRotNeto.ForeColor = System.Drawing.Color.White;
            this.lblRotNeto.Location = new System.Drawing.Point(20, 294);
            this.lblRotNeto.Name = "lblRotNeto";
            this.lblRotNeto.TabIndex = 22;
            this.lblRotNeto.Text = "SALARIO NETO:";

            this.lblVNeto.AutoSize = true;
            this.lblVNeto.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblVNeto.ForeColor = System.Drawing.Color.FromArgb(39, 201, 63);
            this.lblVNeto.Location = new System.Drawing.Point(200, 290);
            this.lblVNeto.Name = "lblVNeto";
            this.lblVNeto.TabIndex = 23;
            this.lblVNeto.Text = "—";

            // ── Botones ───────────────────────────────────────────────────
            this.btnImprimir.BackColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnImprimir.ForeColor = System.Drawing.Color.FromArgb(13, 17, 35);
            this.btnImprimir.Location = new System.Drawing.Point(20, 374);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(160, 34);
            this.btnImprimir.TabIndex = 24;
            this.btnImprimir.Text = "🖨  Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = false;

            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(255, 80, 80);
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(196, 374);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(152, 34);
            this.btnCerrar.TabIndex = 25;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;

            // ── FrmDetalleVolante ─────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(13, 17, 35);
            this.ClientSize = new System.Drawing.Size(400, 536);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlCuerpo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDetalleVolante";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle — Sueldo Neto";
            this.Load += new System.EventHandler(this.FrmDetalleVolante_Load);

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
        private System.Windows.Forms.Button btnCerrarX;

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
        private System.Windows.Forms.Label lblTitIngresos;
        private System.Windows.Forms.Label lblRotSueldo;
        private System.Windows.Forms.Label lblVSueldo;
        private System.Windows.Forms.Label lblRotAsig;
        private System.Windows.Forms.Label lblVAsignacion;
        private System.Windows.Forms.Label lblRotSubtotal;
        private System.Windows.Forms.Label lblVSubtotal;
        private System.Windows.Forms.Panel sep2;
        private System.Windows.Forms.Label lblTitDed;
        private System.Windows.Forms.Label lblRotTotalDed;
        private System.Windows.Forms.Label lblVDeducciones;
        private System.Windows.Forms.Panel sep3;
        private System.Windows.Forms.Panel sep3b;
        private System.Windows.Forms.Label lblRotNeto;
        private System.Windows.Forms.Label lblVNeto;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnCerrar;
    }
}