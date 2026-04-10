namespace Presentacion
{
    partial class FrmNuevoVolante
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(0, 0);
            this.Name = "FrmNuevoVolante";
            this.Load += new System.EventHandler(this.FrmNuevoVolante_Load);
            this.ResumeLayout(false);
        }
    }
}