namespace Presentacion  // ← corregido "Presentasion" → "Presentacion"
{
    partial class FrmVolantesPago
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
            this.Name = "FrmVolantesPago";
            this.Text = "Volantes de Pago";
            // ← eliminado: this.Load += ...FrmVolantesPago_Load
            this.ResumeLayout(false);
        }
    }
}