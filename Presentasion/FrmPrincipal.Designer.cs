namespace Presentasion
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnEmpleados = new System.Windows.Forms.Button();
            this.btnNomina = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnCargos = new System.Windows.Forms.Button();
            this.btnConfiguracion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEmpleados
            // 
            this.btnEmpleados.BackColor = System.Drawing.Color.PeachPuff;
            this.btnEmpleados.ForeColor = System.Drawing.Color.Black;
            this.btnEmpleados.Location = new System.Drawing.Point(304, 74);
            this.btnEmpleados.Name = "btnEmpleados";
            this.btnEmpleados.Size = new System.Drawing.Size(158, 23);
            this.btnEmpleados.TabIndex = 0;
            this.btnEmpleados.Text = "Registrar Empleados";
            this.btnEmpleados.UseVisualStyleBackColor = false;
            this.btnEmpleados.Click += new System.EventHandler(this.btnEmpleados_Click_1);
            // 
            // btnNomina
            // 
            this.btnNomina.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnNomina.Location = new System.Drawing.Point(304, 132);
            this.btnNomina.Name = "btnNomina";
            this.btnNomina.Size = new System.Drawing.Size(158, 23);
            this.btnNomina.TabIndex = 1;
            this.btnNomina.Text = "Calcular Nomina";
            this.btnNomina.UseVisualStyleBackColor = false;
            this.btnNomina.Click += new System.EventHandler(this.btnNomina_Click_1);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSalir.Location = new System.Drawing.Point(304, 190);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(158, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir Del Sistema";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click_1);
            // 
            // btnCargos
            // 
            this.btnCargos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCargos.Location = new System.Drawing.Point(304, 103);
            this.btnCargos.Name = "btnCargos";
            this.btnCargos.Size = new System.Drawing.Size(158, 23);
            this.btnCargos.TabIndex = 3;
            this.btnCargos.Text = "Verificar Cargos";
            this.btnCargos.UseVisualStyleBackColor = false;
            this.btnCargos.Click += new System.EventHandler(this.btnCargos_Click_1);
            // 
            // btnConfiguracion
            // 
            this.btnConfiguracion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnConfiguracion.Location = new System.Drawing.Point(304, 161);
            this.btnConfiguracion.Name = "btnConfiguracion";
            this.btnConfiguracion.Size = new System.Drawing.Size(158, 23);
            this.btnConfiguracion.TabIndex = 4;
            this.btnConfiguracion.Text = "Configurar Deducciones";
            this.btnConfiguracion.UseVisualStyleBackColor = false;
            this.btnConfiguracion.Click += new System.EventHandler(this.btnConfiguracion_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.IndianRed;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnConfiguracion);
            this.Controls.Add(this.btnCargos);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnNomina);
            this.Controls.Add(this.btnEmpleados);
            this.Name = "FrmPrincipal";
            this.Text = "FrmPrincipal";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEmpleados;
        private System.Windows.Forms.Button btnNomina;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnCargos;
        private System.Windows.Forms.Button btnConfiguracion;
    }
}