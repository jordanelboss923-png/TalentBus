namespace Presentacion
{
    partial class FrmDeducciones
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
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Name = "FrmDeducciones";
            this.Text = "Deducciones";
            // ← eliminado: this.Load += ...FrmDeducciones_Load
            this.ResumeLayout(false);
        }
    }
}