namespace Presentacion
{
    partial class FrmVolantesPago
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
            this.lblTituloPagina = new System.Windows.Forms.Label();
            this.lblSubtituloPagina = new System.Windows.Forms.Label();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.pnlFiltro = new System.Windows.Forms.Panel();
            this.lblFiltroTitulo = new System.Windows.Forms.Label();
            this.lblFiltroEmp = new System.Windows.Forms.Label();
            this.cmbFiltroEmpleado = new System.Windows.Forms.ComboBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lblConteo = new System.Windows.Forms.Label();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.pnlTabla = new System.Windows.Forms.Panel();
            this.dgvVolantes = new System.Windows.Forms.DataGridView();
            this.pnlVistaVolante = new System.Windows.Forms.Panel();
            this.pnlVolanteHeader = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblVolanteTitulo = new System.Windows.Forms.Label();
            this.lblSistema = new System.Windows.Forms.Label();
            this.lblRotCodigo = new System.Windows.Forms.Label();
            this.lblVCodigo = new System.Windows.Forms.Label();
            this.lblRotEmpleado = new System.Windows.Forms.Label();
            this.lblVEmpleado = new System.Windows.Forms.Label();
            this.lblRotPosicion = new System.Windows.Forms.Label();
            this.lblVPosicion = new System.Windows.Forms.Label();
            this.lblRotFecha = new System.Windows.Forms.Label();
            this.lblVFecha = new System.Windows.Forms.Label();
            this.sep1 = new System.Windows.Forms.Panel();
            this.lblRotIngresos = new System.Windows.Forms.Label();
            this.lblRotSueldo = new System.Windows.Forms.Label();
            this.lblVSueldo = new System.Windows.Forms.Label();
            this.lblRotAsignacion = new System.Windows.Forms.Label();
            this.lblVAsignacion = new System.Windows.Forms.Label();
            this.lblRotSubtotal = new System.Windows.Forms.Label();
            this.lblVTotalAsig = new System.Windows.Forms.Label();
            this.sep2 = new System.Windows.Forms.Panel();
            this.lblRotDeducciones = new System.Windows.Forms.Label();
            this.lblRotTotalDed = new System.Windows.Forms.Label();
            this.lblVDeducciones = new System.Windows.Forms.Label();
            this.sep3 = new System.Windows.Forms.Panel();
            this.sep3b = new System.Windows.Forms.Panel();
            this.lblRotNeto = new System.Windows.Forms.Label();
            this.lblVNeto = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlFiltro.SuspendLayout();
            this.pnlTabla.SuspendLayout();
            this.pnlVistaVolante.SuspendLayout();
            this.pnlVolanteHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVolantes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();

            // ── pnlHeader ────────────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(18, 24, 48);
            this.pnlHeader.Controls.Add(this.lblTituloPagina);
            this.pnlHeader.Controls.Add(this.lblSubtituloPagina);
            this.pnlHeader.Controls.Add(this.btnNuevo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1100, 64);
            this.pnlHeader.TabIndex = 0;

            this.lblTituloPagina.AutoSize = true;
            this.lblTituloPagina.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTituloPagina.ForeColor = System.Drawing.Color.White;
            this.lblTituloPagina.Location = new System.Drawing.Point(28, 12);
            this.lblTituloPagina.Name = "lblTituloPagina";
            this.lblTituloPagina.TabIndex = 0;
            this.lblTituloPagina.Text = "Volantes de Pago";

            this.lblSubtituloPagina.AutoSize = true;
            this.lblSubtituloPagina.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSubtituloPagina.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblSubtituloPagina.Location = new System.Drawing.Point(30, 40);
            this.lblSubtituloPagina.Name = "lblSubtituloPagina";
            this.lblSubtituloPagina.TabIndex = 1;
            this.lblSubtituloPagina.Text = "Consulta y gestión de nómina por empleado";

            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNuevo.ForeColor = System.Drawing.Color.FromArgb(13, 17, 35);
            this.btnNuevo.Location = new System.Drawing.Point(920, 16);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(150, 34);
            this.btnNuevo.TabIndex = 2;
            this.btnNuevo.Text = "+ Nuevo Volante";
            this.btnNuevo.UseVisualStyleBackColor = false;

            // ── pnlFiltro ─────────────────────────────────────────────────
            this.pnlFiltro.BackColor = System.Drawing.Color.FromArgb(18, 24, 48);
            this.pnlFiltro.Controls.Add(this.lblFiltroTitulo);
            this.pnlFiltro.Controls.Add(this.lblFiltroEmp);
            this.pnlFiltro.Controls.Add(this.cmbFiltroEmpleado);
            this.pnlFiltro.Controls.Add(this.btnFiltrar);
            this.pnlFiltro.Controls.Add(this.btnLimpiar);
            this.pnlFiltro.Controls.Add(this.lblConteo);
            this.pnlFiltro.Location = new System.Drawing.Point(16, 72);
            this.pnlFiltro.Name = "pnlFiltro";
            this.pnlFiltro.Size = new System.Drawing.Size(1068, 76);
            this.pnlFiltro.TabIndex = 1;

            this.lblFiltroTitulo.AutoSize = true;
            this.lblFiltroTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFiltroTitulo.ForeColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.lblFiltroTitulo.Location = new System.Drawing.Point(14, 10);
            this.lblFiltroTitulo.Name = "lblFiltroTitulo";
            this.lblFiltroTitulo.TabIndex = 0;
            this.lblFiltroTitulo.Text = "Filtrar por empleado";

            this.lblFiltroEmp.AutoSize = true;
            this.lblFiltroEmp.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblFiltroEmp.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblFiltroEmp.Location = new System.Drawing.Point(14, 36);
            this.lblFiltroEmp.Name = "lblFiltroEmp";
            this.lblFiltroEmp.TabIndex = 1;
            this.lblFiltroEmp.Text = "Empleado";

            this.cmbFiltroEmpleado.BackColor = System.Drawing.Color.FromArgb(25, 35, 65);
            this.cmbFiltroEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFiltroEmpleado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbFiltroEmpleado.ForeColor = System.Drawing.Color.White;
            this.cmbFiltroEmpleado.Location = new System.Drawing.Point(84, 32);
            this.cmbFiltroEmpleado.Name = "cmbFiltroEmpleado";
            this.cmbFiltroEmpleado.Size = new System.Drawing.Size(370, 23);
            this.cmbFiltroEmpleado.TabIndex = 2;

            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(30, 80, 180);
            this.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.FlatAppearance.BorderSize = 0;
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnFiltrar.Location = new System.Drawing.Point(468, 32);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(110, 26);
            this.btnFiltrar.TabIndex = 3;
            this.btnFiltrar.Text = "Consultar";
            this.btnFiltrar.UseVisualStyleBackColor = false;

            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(25, 35, 65);
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLimpiar.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.btnLimpiar.Location = new System.Drawing.Point(588, 32);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(90, 26);
            this.btnLimpiar.TabIndex = 4;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;

            this.lblConteo.AutoSize = true;
            this.lblConteo.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblConteo.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblConteo.Location = new System.Drawing.Point(694, 38);
            this.lblConteo.Name = "lblConteo";
            this.lblConteo.TabIndex = 5;
            this.lblConteo.Text = "";

            // ── lblMensaje ────────────────────────────────────────────────
            this.lblMensaje.AutoSize = false;
            this.lblMensaje.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMensaje.ForeColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.lblMensaje.Location = new System.Drawing.Point(16, 154);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(700, 22);
            this.lblMensaje.TabIndex = 2;
            this.lblMensaje.Text = "";
            this.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // ── pnlTabla ──────────────────────────────────────────────────
            this.pnlTabla.BackColor = System.Drawing.Color.Transparent;
            this.pnlTabla.Controls.Add(this.dgvVolantes);
            this.pnlTabla.Location = new System.Drawing.Point(16, 180);
            this.pnlTabla.Name = "pnlTabla";
            this.pnlTabla.Size = new System.Drawing.Size(1068, 360);
            this.pnlTabla.TabIndex = 3;
            this.pnlTabla.Anchor = System.Windows.Forms.AnchorStyles.Top |
                                   System.Windows.Forms.AnchorStyles.Left |
                                   System.Windows.Forms.AnchorStyles.Right |
                                   System.Windows.Forms.AnchorStyles.Bottom;

            // dgvVolantes
            this.dgvVolantes.AllowUserToAddRows = false;
            this.dgvVolantes.AllowUserToDeleteRows = false;
            this.dgvVolantes.BackgroundColor = System.Drawing.Color.FromArgb(18, 24, 48);
            this.dgvVolantes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVolantes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvVolantes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvVolantes.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(20, 28, 58);
            this.dgvVolantes.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.dgvVolantes.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.dgvVolantes.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(20, 28, 58);
            this.dgvVolantes.ColumnHeadersHeight = 36;
            this.dgvVolantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvVolantes.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(18, 24, 48);
            this.dgvVolantes.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvVolantes.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvVolantes.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(25, 35, 70);
            this.dgvVolantes.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.dgvVolantes.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dgvVolantes.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(20, 28, 55);
            this.dgvVolantes.EnableHeadersVisualStyles = false;
            this.dgvVolantes.GridColor = System.Drawing.Color.FromArgb(30, 40, 80);
            this.dgvVolantes.Location = new System.Drawing.Point(0, 0);
            this.dgvVolantes.MultiSelect = false;
            this.dgvVolantes.Name = "dgvVolantes";
            this.dgvVolantes.ReadOnly = true;
            this.dgvVolantes.RowHeadersVisible = false;
            this.dgvVolantes.RowTemplate.Height = 40;
            this.dgvVolantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVolantes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVolantes.Size = new System.Drawing.Size(1068, 360);
            this.dgvVolantes.TabIndex = 0;
            this.dgvVolantes.Anchor = System.Windows.Forms.AnchorStyles.Top |
                                      System.Windows.Forms.AnchorStyles.Left |
                                      System.Windows.Forms.AnchorStyles.Right |
                                      System.Windows.Forms.AnchorStyles.Bottom;

            // ── pnlVistaVolante ───────────────────────────────────────────
            this.pnlVistaVolante.BackColor = System.Drawing.Color.FromArgb(18, 24, 48);
            this.pnlVistaVolante.Controls.Add(this.pnlVolanteHeader);
            this.pnlVistaVolante.Controls.Add(this.lblRotCodigo);
            this.pnlVistaVolante.Controls.Add(this.lblVCodigo);
            this.pnlVistaVolante.Controls.Add(this.lblRotEmpleado);
            this.pnlVistaVolante.Controls.Add(this.lblVEmpleado);
            this.pnlVistaVolante.Controls.Add(this.lblRotPosicion);
            this.pnlVistaVolante.Controls.Add(this.lblVPosicion);
            this.pnlVistaVolante.Controls.Add(this.lblRotFecha);
            this.pnlVistaVolante.Controls.Add(this.lblVFecha);
            this.pnlVistaVolante.Controls.Add(this.sep1);
            this.pnlVistaVolante.Controls.Add(this.lblRotIngresos);
            this.pnlVistaVolante.Controls.Add(this.lblRotSueldo);
            this.pnlVistaVolante.Controls.Add(this.lblVSueldo);
            this.pnlVistaVolante.Controls.Add(this.lblRotAsignacion);
            this.pnlVistaVolante.Controls.Add(this.lblVAsignacion);
            this.pnlVistaVolante.Controls.Add(this.lblRotSubtotal);
            this.pnlVistaVolante.Controls.Add(this.lblVTotalAsig);
            this.pnlVistaVolante.Controls.Add(this.sep2);
            this.pnlVistaVolante.Controls.Add(this.lblRotDeducciones);
            this.pnlVistaVolante.Controls.Add(this.lblRotTotalDed);
            this.pnlVistaVolante.Controls.Add(this.lblVDeducciones);
            this.pnlVistaVolante.Controls.Add(this.sep3);
            this.pnlVistaVolante.Controls.Add(this.sep3b);
            this.pnlVistaVolante.Controls.Add(this.lblRotNeto);
            this.pnlVistaVolante.Controls.Add(this.lblVNeto);
            this.pnlVistaVolante.Controls.Add(this.btnImprimir);
            this.pnlVistaVolante.Location = new System.Drawing.Point(748, 180);
            this.pnlVistaVolante.Name = "pnlVistaVolante";
            this.pnlVistaVolante.Size = new System.Drawing.Size(320, 500);
            this.pnlVistaVolante.TabIndex = 4;
            this.pnlVistaVolante.Visible = false;
            this.pnlVistaVolante.Anchor = System.Windows.Forms.AnchorStyles.Top |
                                          System.Windows.Forms.AnchorStyles.Right |
                                          System.Windows.Forms.AnchorStyles.Bottom;

            // pnlVolanteHeader
            this.pnlVolanteHeader.BackColor = System.Drawing.Color.FromArgb(15, 22, 45);
            this.pnlVolanteHeader.Controls.Add(this.picLogo);
            this.pnlVolanteHeader.Controls.Add(this.lblVolanteTitulo);
            this.pnlVolanteHeader.Controls.Add(this.lblSistema);
            this.pnlVolanteHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlVolanteHeader.Name = "pnlVolanteHeader";
            this.pnlVolanteHeader.Size = new System.Drawing.Size(320, 80);
            this.pnlVolanteHeader.TabIndex = 0;

            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Location = new System.Drawing.Point(15, 22);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(36, 36);
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;

            this.lblVolanteTitulo.AutoSize = true;
            this.lblVolanteTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblVolanteTitulo.ForeColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.lblVolanteTitulo.Location = new System.Drawing.Point(58, 18);
            this.lblVolanteTitulo.Name = "lblVolanteTitulo";
            this.lblVolanteTitulo.TabIndex = 1;
            this.lblVolanteTitulo.Text = "VOLANTE DE PAGO";

            this.lblSistema.AutoSize = true;
            this.lblSistema.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblSistema.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblSistema.Location = new System.Drawing.Point(60, 40);
            this.lblSistema.Name = "lblSistema";
            this.lblSistema.TabIndex = 2;
            this.lblSistema.Text = "TalentBus DB3";

            // ── Filas del volante — todo inline ───────────────────────────

            // Código
            this.lblRotCodigo.AutoSize = true;
            this.lblRotCodigo.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblRotCodigo.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblRotCodigo.Location = new System.Drawing.Point(20, 92);
            this.lblRotCodigo.Name = "lblRotCodigo";
            this.lblRotCodigo.TabIndex = 10;
            this.lblRotCodigo.Text = "Código:";

            this.lblVCodigo.AutoSize = true;
            this.lblVCodigo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVCodigo.ForeColor = System.Drawing.Color.White;
            this.lblVCodigo.Location = new System.Drawing.Point(148, 92);
            this.lblVCodigo.Name = "lblVCodigo";
            this.lblVCodigo.TabIndex = 11;
            this.lblVCodigo.Text = "—";

            // Empleado
            this.lblRotEmpleado.AutoSize = true;
            this.lblRotEmpleado.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblRotEmpleado.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblRotEmpleado.Location = new System.Drawing.Point(20, 122);
            this.lblRotEmpleado.Name = "lblRotEmpleado";
            this.lblRotEmpleado.TabIndex = 12;
            this.lblRotEmpleado.Text = "Empleado:";

            this.lblVEmpleado.AutoSize = true;
            this.lblVEmpleado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVEmpleado.ForeColor = System.Drawing.Color.White;
            this.lblVEmpleado.Location = new System.Drawing.Point(148, 122);
            this.lblVEmpleado.Name = "lblVEmpleado";
            this.lblVEmpleado.TabIndex = 13;
            this.lblVEmpleado.Text = "—";

            // Posición
            this.lblRotPosicion.AutoSize = true;
            this.lblRotPosicion.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblRotPosicion.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblRotPosicion.Location = new System.Drawing.Point(20, 152);
            this.lblRotPosicion.Name = "lblRotPosicion";
            this.lblRotPosicion.TabIndex = 14;
            this.lblRotPosicion.Text = "Posición:";

            this.lblVPosicion.AutoSize = true;
            this.lblVPosicion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVPosicion.ForeColor = System.Drawing.Color.White;
            this.lblVPosicion.Location = new System.Drawing.Point(148, 152);
            this.lblVPosicion.Name = "lblVPosicion";
            this.lblVPosicion.TabIndex = 15;
            this.lblVPosicion.Text = "—";

            // Período
            this.lblRotFecha.AutoSize = true;
            this.lblRotFecha.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblRotFecha.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblRotFecha.Location = new System.Drawing.Point(20, 182);
            this.lblRotFecha.Name = "lblRotFecha";
            this.lblRotFecha.TabIndex = 16;
            this.lblRotFecha.Text = "Período:";

            this.lblVFecha.AutoSize = true;
            this.lblVFecha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVFecha.ForeColor = System.Drawing.Color.White;
            this.lblVFecha.Location = new System.Drawing.Point(148, 182);
            this.lblVFecha.Name = "lblVFecha";
            this.lblVFecha.TabIndex = 17;
            this.lblVFecha.Text = "—";

            // sep1
            this.sep1.BackColor = System.Drawing.Color.FromArgb(30, 40, 80);
            this.sep1.Location = new System.Drawing.Point(20, 214);
            this.sep1.Name = "sep1";
            this.sep1.Size = new System.Drawing.Size(280, 1);
            this.sep1.TabIndex = 18;

            // INGRESOS
            this.lblRotIngresos.AutoSize = true;
            this.lblRotIngresos.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblRotIngresos.ForeColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.lblRotIngresos.Location = new System.Drawing.Point(20, 224);
            this.lblRotIngresos.Name = "lblRotIngresos";
            this.lblRotIngresos.TabIndex = 19;
            this.lblRotIngresos.Text = "INGRESOS";

            // Sueldo Base
            this.lblRotSueldo.AutoSize = true;
            this.lblRotSueldo.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblRotSueldo.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblRotSueldo.Location = new System.Drawing.Point(20, 250);
            this.lblRotSueldo.Name = "lblRotSueldo";
            this.lblRotSueldo.TabIndex = 20;
            this.lblRotSueldo.Text = "Sueldo Base:";

            this.lblVSueldo.AutoSize = true;
            this.lblVSueldo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVSueldo.ForeColor = System.Drawing.Color.White;
            this.lblVSueldo.Location = new System.Drawing.Point(148, 250);
            this.lblVSueldo.Name = "lblVSueldo";
            this.lblVSueldo.TabIndex = 21;
            this.lblVSueldo.Text = "—";

            // Asignaciones
            this.lblRotAsignacion.AutoSize = true;
            this.lblRotAsignacion.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblRotAsignacion.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblRotAsignacion.Location = new System.Drawing.Point(20, 278);
            this.lblRotAsignacion.Name = "lblRotAsignacion";
            this.lblRotAsignacion.TabIndex = 22;
            this.lblRotAsignacion.Text = "Asignaciones:";

            this.lblVAsignacion.AutoSize = true;
            this.lblVAsignacion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVAsignacion.ForeColor = System.Drawing.Color.White;
            this.lblVAsignacion.Location = new System.Drawing.Point(148, 278);
            this.lblVAsignacion.Name = "lblVAsignacion";
            this.lblVAsignacion.TabIndex = 23;
            this.lblVAsignacion.Text = "—";

            // Subtotal (bold cyan)
            this.lblRotSubtotal.AutoSize = true;
            this.lblRotSubtotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRotSubtotal.ForeColor = System.Drawing.Color.White;
            this.lblRotSubtotal.Location = new System.Drawing.Point(20, 306);
            this.lblRotSubtotal.Name = "lblRotSubtotal";
            this.lblRotSubtotal.TabIndex = 24;
            this.lblRotSubtotal.Text = "Subtotal:";

            this.lblVTotalAsig.AutoSize = true;
            this.lblVTotalAsig.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblVTotalAsig.ForeColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.lblVTotalAsig.Location = new System.Drawing.Point(148, 304);
            this.lblVTotalAsig.Name = "lblVTotalAsig";
            this.lblVTotalAsig.TabIndex = 25;
            this.lblVTotalAsig.Text = "—";

            // sep2
            this.sep2.BackColor = System.Drawing.Color.FromArgb(30, 40, 80);
            this.sep2.Location = new System.Drawing.Point(20, 332);
            this.sep2.Name = "sep2";
            this.sep2.Size = new System.Drawing.Size(280, 1);
            this.sep2.TabIndex = 26;

            // DEDUCCIONES
            this.lblRotDeducciones.AutoSize = true;
            this.lblRotDeducciones.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblRotDeducciones.ForeColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.lblRotDeducciones.Location = new System.Drawing.Point(20, 342);
            this.lblRotDeducciones.Name = "lblRotDeducciones";
            this.lblRotDeducciones.TabIndex = 27;
            this.lblRotDeducciones.Text = "DEDUCCIONES";

            // Total Deducciones
            this.lblRotTotalDed.AutoSize = true;
            this.lblRotTotalDed.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblRotTotalDed.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblRotTotalDed.Location = new System.Drawing.Point(20, 368);
            this.lblRotTotalDed.Name = "lblRotTotalDed";
            this.lblRotTotalDed.TabIndex = 28;
            this.lblRotTotalDed.Text = "Total Ded.:";

            this.lblVDeducciones.AutoSize = true;
            this.lblVDeducciones.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVDeducciones.ForeColor = System.Drawing.Color.White;
            this.lblVDeducciones.Location = new System.Drawing.Point(148, 368);
            this.lblVDeducciones.Name = "lblVDeducciones";
            this.lblVDeducciones.TabIndex = 29;
            this.lblVDeducciones.Text = "—";

            // sep3 doble
            this.sep3.BackColor = System.Drawing.Color.FromArgb(30, 40, 80);
            this.sep3.Location = new System.Drawing.Point(20, 396);
            this.sep3.Name = "sep3";
            this.sep3.Size = new System.Drawing.Size(280, 1);
            this.sep3.TabIndex = 30;

            this.sep3b.BackColor = System.Drawing.Color.FromArgb(30, 40, 80);
            this.sep3b.Location = new System.Drawing.Point(20, 400);
            this.sep3b.Name = "sep3b";
            this.sep3b.Size = new System.Drawing.Size(280, 1);
            this.sep3b.TabIndex = 31;

            // SALARIO NETO (bold verde)
            this.lblRotNeto.AutoSize = true;
            this.lblRotNeto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRotNeto.ForeColor = System.Drawing.Color.White;
            this.lblRotNeto.Location = new System.Drawing.Point(20, 410);
            this.lblRotNeto.Name = "lblRotNeto";
            this.lblRotNeto.TabIndex = 32;
            this.lblRotNeto.Text = "SALARIO NETO:";

            this.lblVNeto.AutoSize = true;
            this.lblVNeto.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblVNeto.ForeColor = System.Drawing.Color.FromArgb(39, 201, 63);
            this.lblVNeto.Location = new System.Drawing.Point(148, 408);
            this.lblVNeto.Name = "lblVNeto";
            this.lblVNeto.TabIndex = 33;
            this.lblVNeto.Text = "—";

            // btnImprimir
            this.btnImprimir.BackColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnImprimir.ForeColor = System.Drawing.Color.FromArgb(13, 17, 35);
            this.btnImprimir.Location = new System.Drawing.Point(90, 450);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(140, 34);
            this.btnImprimir.TabIndex = 34;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = false;

            // ── FrmVolantesPago ───────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(13, 17, 35);
            this.ClientSize = new System.Drawing.Size(1100, 570);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlFiltro);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.pnlTabla);
            this.Controls.Add(this.pnlVistaVolante);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmVolantesPago";
            this.Text = "Volantes de Pago";
            this.Load += new System.EventHandler(this.FrmVolantesPago_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFiltro.ResumeLayout(false);
            this.pnlFiltro.PerformLayout();
            this.pnlTabla.ResumeLayout(false);
            this.pnlVistaVolante.ResumeLayout(false);
            this.pnlVistaVolante.PerformLayout();
            this.pnlVolanteHeader.ResumeLayout(false);
            this.pnlVolanteHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVolantes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
        }

        // ── Declaraciones ──────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTituloPagina;
        private System.Windows.Forms.Label lblSubtituloPagina;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Panel pnlFiltro;
        private System.Windows.Forms.Label lblFiltroTitulo;
        private System.Windows.Forms.Label lblFiltroEmp;
        private System.Windows.Forms.ComboBox cmbFiltroEmpleado;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblConteo;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Panel pnlTabla;
        private System.Windows.Forms.DataGridView dgvVolantes;
        private System.Windows.Forms.Panel pnlVistaVolante;
        private System.Windows.Forms.Panel pnlVolanteHeader;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblVolanteTitulo;
        private System.Windows.Forms.Label lblSistema;
        private System.Windows.Forms.Label lblRotCodigo;
        private System.Windows.Forms.Label lblVCodigo;
        private System.Windows.Forms.Label lblRotEmpleado;
        private System.Windows.Forms.Label lblVEmpleado;
        private System.Windows.Forms.Label lblRotPosicion;
        private System.Windows.Forms.Label lblVPosicion;
        private System.Windows.Forms.Label lblRotFecha;
        private System.Windows.Forms.Label lblVFecha;
        private System.Windows.Forms.Panel sep1;
        private System.Windows.Forms.Label lblRotIngresos;
        private System.Windows.Forms.Label lblRotSueldo;
        private System.Windows.Forms.Label lblVSueldo;
        private System.Windows.Forms.Label lblRotAsignacion;
        private System.Windows.Forms.Label lblVAsignacion;
        private System.Windows.Forms.Label lblRotSubtotal;
        private System.Windows.Forms.Label lblVTotalAsig;
        private System.Windows.Forms.Panel sep2;
        private System.Windows.Forms.Label lblRotDeducciones;
        private System.Windows.Forms.Label lblRotTotalDed;
        private System.Windows.Forms.Label lblVDeducciones;
        private System.Windows.Forms.Panel sep3;
        private System.Windows.Forms.Panel sep3b;
        private System.Windows.Forms.Label lblRotNeto;
        private System.Windows.Forms.Label lblVNeto;
        private System.Windows.Forms.Button btnImprimir;
    }
}