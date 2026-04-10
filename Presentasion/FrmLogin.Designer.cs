namespace Presentacion  // ← corregido (sin "s")
{
    partial class FrmLogin
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
            this.SuspendLayout();
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 600);
            this.Name = "FrmLogin";
            this.Text = "TalentBus — Iniciar Sesión";
            // ← se eliminó el FrmLogin_Load que no existe
            this.ResumeLayout(false);
        }
    }
}