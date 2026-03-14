namespace Presentasion
{
    partial class FrmNomina
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
            this.cmbEmpleado = new System.Windows.Forms.ComboBox();
            this.txtHorasExtra = new System.Windows.Forms.TextBox();
            this.btnCalcularUno = new System.Windows.Forms.Button();
            this.btnCalcularTodos = new System.Windows.Forms.Button();
            this.btnGenerarNomina = new System.Windows.Forms.Button();
            this.btnVolante = new System.Windows.Forms.Button();
            this.dgvNomina = new System.Windows.Forms.DataGridView();
            this.btnResumen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNomina)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbEmpleado
            // 
            this.cmbEmpleado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbEmpleado.FormattingEnabled = true;
            this.cmbEmpleado.Location = new System.Drawing.Point(634, 39);
            this.cmbEmpleado.Name = "cmbEmpleado";
            this.cmbEmpleado.Size = new System.Drawing.Size(121, 21);
            this.cmbEmpleado.TabIndex = 0;
            this.cmbEmpleado.SelectedIndexChanged += new System.EventHandler(this.cmbEmpleado_SelectedIndexChanged);
            // 
            // txtHorasExtra
            // 
            this.txtHorasExtra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtHorasExtra.Location = new System.Drawing.Point(637, 90);
            this.txtHorasExtra.Name = "txtHorasExtra";
            this.txtHorasExtra.Size = new System.Drawing.Size(100, 20);
            this.txtHorasExtra.TabIndex = 1;
            // 
            // btnCalcularUno
            // 
            this.btnCalcularUno.BackColor = System.Drawing.Color.GreenYellow;
            this.btnCalcularUno.Location = new System.Drawing.Point(639, 150);
            this.btnCalcularUno.Name = "btnCalcularUno";
            this.btnCalcularUno.Size = new System.Drawing.Size(116, 23);
            this.btnCalcularUno.TabIndex = 2;
            this.btnCalcularUno.Text = "CalcularUno";
            this.btnCalcularUno.UseVisualStyleBackColor = false;
            this.btnCalcularUno.Click += new System.EventHandler(this.btnCalcularUno_Click_1);
            // 
            // btnCalcularTodos
            // 
            this.btnCalcularTodos.BackColor = System.Drawing.Color.Lime;
            this.btnCalcularTodos.Location = new System.Drawing.Point(639, 188);
            this.btnCalcularTodos.Name = "btnCalcularTodos";
            this.btnCalcularTodos.Size = new System.Drawing.Size(116, 23);
            this.btnCalcularTodos.TabIndex = 3;
            this.btnCalcularTodos.Text = "CalcularTodos";
            this.btnCalcularTodos.UseVisualStyleBackColor = false;
            this.btnCalcularTodos.Click += new System.EventHandler(this.btnCalcularTodos_Click_1);
            // 
            // btnGenerarNomina
            // 
            this.btnGenerarNomina.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnGenerarNomina.Location = new System.Drawing.Point(639, 226);
            this.btnGenerarNomina.Name = "btnGenerarNomina";
            this.btnGenerarNomina.Size = new System.Drawing.Size(116, 23);
            this.btnGenerarNomina.TabIndex = 4;
            this.btnGenerarNomina.Text = "GenerarNomina";
            this.btnGenerarNomina.UseVisualStyleBackColor = false;
            this.btnGenerarNomina.Click += new System.EventHandler(this.btnGenerarNomina_Click_1);
            // 
            // btnVolante
            // 
            this.btnVolante.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnVolante.Location = new System.Drawing.Point(639, 264);
            this.btnVolante.Name = "btnVolante";
            this.btnVolante.Size = new System.Drawing.Size(116, 23);
            this.btnVolante.TabIndex = 5;
            this.btnVolante.Text = "GenerarVolante";
            this.btnVolante.UseVisualStyleBackColor = false;
            this.btnVolante.Click += new System.EventHandler(this.btnVolante_Click_1);
            // 
            // dgvNomina
            // 
            this.dgvNomina.AllowUserToAddRows = false;
            this.dgvNomina.AllowUserToDeleteRows = false;
            this.dgvNomina.BackgroundColor = System.Drawing.Color.IndianRed;
            this.dgvNomina.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNomina.Location = new System.Drawing.Point(62, 72);
            this.dgvNomina.Name = "dgvNomina";
            this.dgvNomina.ReadOnly = true;
            this.dgvNomina.Size = new System.Drawing.Size(426, 195);
            this.dgvNomina.TabIndex = 6;
            // 
            // btnResumen
            // 
            this.btnResumen.BackColor = System.Drawing.Color.Lime;
            this.btnResumen.Location = new System.Drawing.Point(639, 302);
            this.btnResumen.Name = "btnResumen";
            this.btnResumen.Size = new System.Drawing.Size(133, 23);
            this.btnResumen.TabIndex = 7;
            this.btnResumen.Text = "ResumenDepartamentos";
            this.btnResumen.UseVisualStyleBackColor = false;
            this.btnResumen.Click += new System.EventHandler(this.btnResumen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(549, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Horas Extras -->";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(559, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Empleado -->";
            // 
            // FrmNomina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnResumen);
            this.Controls.Add(this.dgvNomina);
            this.Controls.Add(this.btnVolante);
            this.Controls.Add(this.btnGenerarNomina);
            this.Controls.Add(this.btnCalcularTodos);
            this.Controls.Add(this.btnCalcularUno);
            this.Controls.Add(this.txtHorasExtra);
            this.Controls.Add(this.cmbEmpleado);
            this.Name = "FrmNomina";
            this.Text = "FrmNomina";
            this.Load += new System.EventHandler(this.FrmNomina_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNomina)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbEmpleado;
        private System.Windows.Forms.TextBox txtHorasExtra;
        private System.Windows.Forms.Button btnCalcularUno;
        private System.Windows.Forms.Button btnCalcularTodos;
        private System.Windows.Forms.Button btnGenerarNomina;
        private System.Windows.Forms.Button btnVolante;
        private System.Windows.Forms.DataGridView dgvNomina;
        private System.Windows.Forms.Button btnResumen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}