namespace Presentacion
{
    partial class FrmDepartamentos
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
            this.Name = "FrmDepartamentos";
            this.Text = "Departamentos";
            // ← eliminado: this.Load += ...FrmDepartamentos_Load
            this.ResumeLayout(false);
        }
    }
}