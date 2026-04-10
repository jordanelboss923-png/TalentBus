namespace Presentacion
{
    partial class FrmPrincipal
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnTabNomina = new System.Windows.Forms.Button();
            this.btnTabEntrada = new System.Windows.Forms.Button();
            this.lblMarca = new System.Windows.Forms.Label();
            this.picLogoMini = new System.Windows.Forms.PictureBox();
            this.btnVerde = new System.Windows.Forms.Button();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();

            this.pnlSidebar = new System.Windows.Forms.Panel();

            // ── Sección Configuración ──
            this.lblSeccionConfig = new System.Windows.Forms.Label();
            this.pnlDepartamentos = new System.Windows.Forms.Panel();
            this.barDepartamentos = new System.Windows.Forms.Panel();
            this.bulletDepartamentos = new System.Windows.Forms.Label();
            this.lblDepartamentos = new System.Windows.Forms.Label();
            this.pnlPosiciones = new System.Windows.Forms.Panel();
            this.barPosiciones = new System.Windows.Forms.Panel();
            this.bulletPosiciones = new System.Windows.Forms.Label();
            this.lblPosiciones = new System.Windows.Forms.Label();
            this.pnlDeducciones = new System.Windows.Forms.Panel();
            this.barDeducciones = new System.Windows.Forms.Panel();
            this.bulletDeducciones = new System.Windows.Forms.Label();
            this.lblDeducciones = new System.Windows.Forms.Label();
            this.pnlAsignaciones = new System.Windows.Forms.Panel();
            this.barAsignaciones = new System.Windows.Forms.Panel();
            this.bulletAsignaciones = new System.Windows.Forms.Label();
            this.lblAsignaciones = new System.Windows.Forms.Label();

            // ── Sección Empleados ──
            this.lblSeccionEmpleados = new System.Windows.Forms.Label();
            this.pnlEmpleados = new System.Windows.Forms.Panel();
            this.barEmpleados = new System.Windows.Forms.Panel();
            this.bulletEmpleados = new System.Windows.Forms.Label();
            this.lblEmpleados = new System.Windows.Forms.Label();
            this.pnlAsistencias = new System.Windows.Forms.Panel();
            this.barAsistencias = new System.Windows.Forms.Panel();
            this.bulletAsistencias = new System.Windows.Forms.Label();
            this.lblAsistencias = new System.Windows.Forms.Label();

            // ── Sección Seguridad ──
            this.lblSeccionSeguridad = new System.Windows.Forms.Label();
            this.pnlAccesoSistema = new System.Windows.Forms.Panel();
            this.barAccesoSistema = new System.Windows.Forms.Panel();
            this.bulletAccesoSistema = new System.Windows.Forms.Label();
            this.lblAccesoSistema = new System.Windows.Forms.Label();

            // ── Sección Nómina (tab Nómina) ──
            this.lblSeccionNomina = new System.Windows.Forms.Label();
            this.pnlVolantesLista = new System.Windows.Forms.Panel();
            this.barVolantesLista = new System.Windows.Forms.Panel();
            this.bulletVolantesLista = new System.Windows.Forms.Label();
            this.lblVolantesLista = new System.Windows.Forms.Label();
            this.pnlVolantesPago = new System.Windows.Forms.Panel();
            this.barVolantesPago = new System.Windows.Forms.Panel();
            this.bulletVolantesPago = new System.Windows.Forms.Label();
            this.lblVolantesPago = new System.Windows.Forms.Label();
            this.pnlDeduccionesEmpleado = new System.Windows.Forms.Panel();
            this.barDeduccionesEmpleado = new System.Windows.Forms.Panel();
            this.bulletDeduccionesEmpleado = new System.Windows.Forms.Label();
            this.lblDeduccionesEmpleado = new System.Windows.Forms.Label();
            this.pnlAsignacionesEmpleado = new System.Windows.Forms.Panel();
            this.barAsignacionesEmpleado = new System.Windows.Forms.Panel();
            this.bulletAsignacionesEmpleado = new System.Windows.Forms.Label();
            this.lblAsignacionesEmpleado = new System.Windows.Forms.Label();

            // ── Contenido y status ──
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.picLogoBienvenida = new System.Windows.Forms.PictureBox();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.lblSubBienvenida = new System.Windows.Forms.Label();
            this.pnlStatusBar = new System.Windows.Forms.Panel();
            this.pnlPuntito = new System.Windows.Forms.Panel();
            this.lblConectado = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();

            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoMini)).BeginInit();
            this.pnlSidebar.SuspendLayout();
            this.pnlDepartamentos.SuspendLayout();
            this.pnlPosiciones.SuspendLayout();
            this.pnlDeducciones.SuspendLayout();
            this.pnlAsignaciones.SuspendLayout();
            this.pnlEmpleados.SuspendLayout();
            this.pnlAsistencias.SuspendLayout();
            this.pnlAccesoSistema.SuspendLayout();
            this.pnlVolantesLista.SuspendLayout();
            this.pnlVolantesPago.SuspendLayout();
            this.pnlDeduccionesEmpleado.SuspendLayout();
            this.pnlAsignacionesEmpleado.SuspendLayout();
            this.pnlContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoBienvenida)).BeginInit();
            this.pnlStatusBar.SuspendLayout();
            this.SuspendLayout();

            // ── pnlHeader ────────────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(18, 24, 48);
            this.pnlHeader.Controls.Add(this.btnSalir);
            this.pnlHeader.Controls.Add(this.btnTabNomina);
            this.pnlHeader.Controls.Add(this.btnTabEntrada);
            this.pnlHeader.Controls.Add(this.lblMarca);
            this.pnlHeader.Controls.Add(this.picLogoMini);
            this.pnlHeader.Controls.Add(this.btnVerde);
            this.pnlHeader.Controls.Add(this.btnMinimizar);
            this.pnlHeader.Controls.Add(this.btnCerrar);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(840, 43);
            this.pnlHeader.TabIndex = 0;

            this.btnSalir.BackColor = System.Drawing.Color.Transparent;
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSalir.ForeColor = System.Drawing.Color.FromArgb(255, 80, 80);
            this.btnSalir.Location = new System.Drawing.Point(771, 9);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(51, 26);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;

            this.btnTabNomina.BackColor = System.Drawing.Color.Transparent;
            this.btnTabNomina.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabNomina.FlatAppearance.BorderSize = 0;
            this.btnTabNomina.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnTabNomina.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabNomina.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTabNomina.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.btnTabNomina.Location = new System.Drawing.Point(257, 0);
            this.btnTabNomina.Name = "btnTabNomina";
            this.btnTabNomina.Size = new System.Drawing.Size(77, 43);
            this.btnTabNomina.TabIndex = 6;
            this.btnTabNomina.Tag = "Nómina";
            this.btnTabNomina.Text = "Nómina";
            this.btnTabNomina.UseVisualStyleBackColor = false;

            this.btnTabEntrada.BackColor = System.Drawing.Color.Transparent;
            this.btnTabEntrada.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabEntrada.FlatAppearance.BorderSize = 0;
            this.btnTabEntrada.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnTabEntrada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabEntrada.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTabEntrada.ForeColor = System.Drawing.Color.White;
            this.btnTabEntrada.Location = new System.Drawing.Point(180, 0);
            this.btnTabEntrada.Name = "btnTabEntrada";
            this.btnTabEntrada.Size = new System.Drawing.Size(77, 43);
            this.btnTabEntrada.TabIndex = 5;
            this.btnTabEntrada.Tag = "Entrada";
            this.btnTabEntrada.Text = "Entrada";
            this.btnTabEntrada.UseVisualStyleBackColor = false;

            this.lblMarca.AutoSize = true;
            this.lblMarca.BackColor = System.Drawing.Color.Transparent;
            this.lblMarca.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMarca.ForeColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.lblMarca.Location = new System.Drawing.Point(101, 13);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.TabIndex = 4;
            this.lblMarca.Text = "TalentBus";

            this.picLogoMini.BackColor = System.Drawing.Color.Transparent;
            this.picLogoMini.Image = global::Presentasion.Properties.Resources.WhatsApp_Image_2026_04_10_at_10_25_56_AM;
            this.picLogoMini.Location = new System.Drawing.Point(73, 10);
            this.picLogoMini.Name = "picLogoMini";
            this.picLogoMini.Size = new System.Drawing.Size(24, 24);
            this.picLogoMini.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogoMini.TabIndex = 3;
            this.picLogoMini.TabStop = false;

            this.btnVerde.BackColor = System.Drawing.Color.FromArgb(39, 201, 63);
            this.btnVerde.FlatAppearance.BorderSize = 0;
            this.btnVerde.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerde.Location = new System.Drawing.Point(48, 16);
            this.btnVerde.Name = "btnVerde";
            this.btnVerde.Size = new System.Drawing.Size(12, 12);
            this.btnVerde.TabIndex = 2;
            this.btnVerde.UseVisualStyleBackColor = false;

            this.btnMinimizar.BackColor = System.Drawing.Color.FromArgb(255, 189, 46);
            this.btnMinimizar.FlatAppearance.BorderSize = 0;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.Location = new System.Drawing.Point(31, 16);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(12, 12);
            this.btnMinimizar.TabIndex = 1;
            this.btnMinimizar.UseVisualStyleBackColor = false;

            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(255, 95, 86);
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Location = new System.Drawing.Point(14, 16);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(12, 12);
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.UseVisualStyleBackColor = false;

            // ── pnlSidebar ───────────────────────────────────────────────
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(18, 24, 48);
            this.pnlSidebar.Controls.Add(this.lblSeccionConfig);
            this.pnlSidebar.Controls.Add(this.pnlDepartamentos);
            this.pnlSidebar.Controls.Add(this.pnlPosiciones);
            this.pnlSidebar.Controls.Add(this.pnlDeducciones);
            this.pnlSidebar.Controls.Add(this.pnlAsignaciones);
            this.pnlSidebar.Controls.Add(this.lblSeccionEmpleados);
            this.pnlSidebar.Controls.Add(this.pnlEmpleados);
            this.pnlSidebar.Controls.Add(this.pnlAsistencias);
            this.pnlSidebar.Controls.Add(this.lblSeccionSeguridad);
            this.pnlSidebar.Controls.Add(this.pnlAccesoSistema);
            // Nómina
            this.pnlSidebar.Controls.Add(this.lblSeccionNomina);
            this.pnlSidebar.Controls.Add(this.pnlVolantesLista);
            this.pnlSidebar.Controls.Add(this.pnlVolantesPago);
            this.pnlSidebar.Controls.Add(this.pnlDeduccionesEmpleado);
            this.pnlSidebar.Controls.Add(this.pnlAsignacionesEmpleado);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 43);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(189, 468);
            this.pnlSidebar.TabIndex = 1;

            // ── lblSeccionConfig ─────────────────────────────────────────
            this.lblSeccionConfig.AutoSize = true;
            this.lblSeccionConfig.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblSeccionConfig.ForeColor = System.Drawing.Color.FromArgb(80, 100, 150);
            this.lblSeccionConfig.Location = new System.Drawing.Point(17, 17);
            this.lblSeccionConfig.Name = "lblSeccionConfig";
            this.lblSeccionConfig.TabIndex = 0;
            this.lblSeccionConfig.Text = "CONFIGURACIÓN";

            // helper macro para items del sidebar
            // ── pnlDepartamentos ─────────────────────────────────────────
            this.pnlDepartamentos.BackColor = System.Drawing.Color.Transparent;
            this.pnlDepartamentos.Controls.Add(this.barDepartamentos);
            this.pnlDepartamentos.Controls.Add(this.bulletDepartamentos);
            this.pnlDepartamentos.Controls.Add(this.lblDepartamentos);
            this.pnlDepartamentos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlDepartamentos.Location = new System.Drawing.Point(0, 39);
            this.pnlDepartamentos.Name = "pnlDepartamentos";
            this.pnlDepartamentos.Size = new System.Drawing.Size(189, 28);
            this.pnlDepartamentos.TabIndex = 1;

            this.barDepartamentos.BackColor = System.Drawing.Color.Transparent;
            this.barDepartamentos.Location = new System.Drawing.Point(0, 0);
            this.barDepartamentos.Name = "barDepartamentos";
            this.barDepartamentos.Size = new System.Drawing.Size(3, 28);
            this.barDepartamentos.TabIndex = 0;

            this.bulletDepartamentos.AutoSize = true;
            this.bulletDepartamentos.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.bulletDepartamentos.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.bulletDepartamentos.Location = new System.Drawing.Point(13, 9);
            this.bulletDepartamentos.Name = "bulletDepartamentos";
            this.bulletDepartamentos.TabIndex = 1;
            this.bulletDepartamentos.Text = "●";

            this.lblDepartamentos.AutoSize = true;
            this.lblDepartamentos.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDepartamentos.ForeColor = System.Drawing.Color.White;
            this.lblDepartamentos.Location = new System.Drawing.Point(30, 7);
            this.lblDepartamentos.Name = "lblDepartamentos";
            this.lblDepartamentos.TabIndex = 2;
            this.lblDepartamentos.Text = "Departamentos";

            // ── pnlPosiciones ────────────────────────────────────────────
            this.pnlPosiciones.BackColor = System.Drawing.Color.Transparent;
            this.pnlPosiciones.Controls.Add(this.barPosiciones);
            this.pnlPosiciones.Controls.Add(this.bulletPosiciones);
            this.pnlPosiciones.Controls.Add(this.lblPosiciones);
            this.pnlPosiciones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlPosiciones.Location = new System.Drawing.Point(0, 69);
            this.pnlPosiciones.Name = "pnlPosiciones";
            this.pnlPosiciones.Size = new System.Drawing.Size(189, 28);
            this.pnlPosiciones.TabIndex = 2;

            this.barPosiciones.BackColor = System.Drawing.Color.Transparent;
            this.barPosiciones.Location = new System.Drawing.Point(0, 0);
            this.barPosiciones.Name = "barPosiciones";
            this.barPosiciones.Size = new System.Drawing.Size(3, 28);
            this.barPosiciones.TabIndex = 0;

            this.bulletPosiciones.AutoSize = true;
            this.bulletPosiciones.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.bulletPosiciones.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.bulletPosiciones.Location = new System.Drawing.Point(13, 9);
            this.bulletPosiciones.Name = "bulletPosiciones";
            this.bulletPosiciones.TabIndex = 1;
            this.bulletPosiciones.Text = "●";

            this.lblPosiciones.AutoSize = true;
            this.lblPosiciones.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPosiciones.ForeColor = System.Drawing.Color.White;
            this.lblPosiciones.Location = new System.Drawing.Point(30, 7);
            this.lblPosiciones.Name = "lblPosiciones";
            this.lblPosiciones.TabIndex = 2;
            this.lblPosiciones.Text = "Posiciones";

            // ── pnlDeducciones ───────────────────────────────────────────
            this.pnlDeducciones.BackColor = System.Drawing.Color.Transparent;
            this.pnlDeducciones.Controls.Add(this.barDeducciones);
            this.pnlDeducciones.Controls.Add(this.bulletDeducciones);
            this.pnlDeducciones.Controls.Add(this.lblDeducciones);
            this.pnlDeducciones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlDeducciones.Location = new System.Drawing.Point(0, 100);
            this.pnlDeducciones.Name = "pnlDeducciones";
            this.pnlDeducciones.Size = new System.Drawing.Size(189, 28);
            this.pnlDeducciones.TabIndex = 3;

            this.barDeducciones.BackColor = System.Drawing.Color.Transparent;
            this.barDeducciones.Location = new System.Drawing.Point(0, 0);
            this.barDeducciones.Name = "barDeducciones";
            this.barDeducciones.Size = new System.Drawing.Size(3, 28);
            this.barDeducciones.TabIndex = 0;

            this.bulletDeducciones.AutoSize = true;
            this.bulletDeducciones.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.bulletDeducciones.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.bulletDeducciones.Location = new System.Drawing.Point(13, 9);
            this.bulletDeducciones.Name = "bulletDeducciones";
            this.bulletDeducciones.TabIndex = 1;
            this.bulletDeducciones.Text = "●";

            this.lblDeducciones.AutoSize = true;
            this.lblDeducciones.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDeducciones.ForeColor = System.Drawing.Color.White;
            this.lblDeducciones.Location = new System.Drawing.Point(30, 7);
            this.lblDeducciones.Name = "lblDeducciones";
            this.lblDeducciones.TabIndex = 2;
            this.lblDeducciones.Text = "Deducciones";

            // ── pnlAsignaciones ──────────────────────────────────────────
            this.pnlAsignaciones.BackColor = System.Drawing.Color.Transparent;
            this.pnlAsignaciones.Controls.Add(this.barAsignaciones);
            this.pnlAsignaciones.Controls.Add(this.bulletAsignaciones);
            this.pnlAsignaciones.Controls.Add(this.lblAsignaciones);
            this.pnlAsignaciones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlAsignaciones.Location = new System.Drawing.Point(0, 130);
            this.pnlAsignaciones.Name = "pnlAsignaciones";
            this.pnlAsignaciones.Size = new System.Drawing.Size(189, 28);
            this.pnlAsignaciones.TabIndex = 4;

            this.barAsignaciones.BackColor = System.Drawing.Color.Transparent;
            this.barAsignaciones.Location = new System.Drawing.Point(0, 0);
            this.barAsignaciones.Name = "barAsignaciones";
            this.barAsignaciones.Size = new System.Drawing.Size(3, 28);
            this.barAsignaciones.TabIndex = 0;

            this.bulletAsignaciones.AutoSize = true;
            this.bulletAsignaciones.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.bulletAsignaciones.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.bulletAsignaciones.Location = new System.Drawing.Point(13, 9);
            this.bulletAsignaciones.Name = "bulletAsignaciones";
            this.bulletAsignaciones.TabIndex = 1;
            this.bulletAsignaciones.Text = "●";

            this.lblAsignaciones.AutoSize = true;
            this.lblAsignaciones.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAsignaciones.ForeColor = System.Drawing.Color.White;
            this.lblAsignaciones.Location = new System.Drawing.Point(30, 7);
            this.lblAsignaciones.Name = "lblAsignaciones";
            this.lblAsignaciones.TabIndex = 2;
            this.lblAsignaciones.Text = "Asignaciones";

            // ── lblSeccionEmpleados ──────────────────────────────────────
            this.lblSeccionEmpleados.AutoSize = true;
            this.lblSeccionEmpleados.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblSeccionEmpleados.ForeColor = System.Drawing.Color.FromArgb(80, 100, 150);
            this.lblSeccionEmpleados.Location = new System.Drawing.Point(17, 169);
            this.lblSeccionEmpleados.Name = "lblSeccionEmpleados";
            this.lblSeccionEmpleados.TabIndex = 5;
            this.lblSeccionEmpleados.Text = "EMPLEADOS";

            // ── pnlEmpleados ─────────────────────────────────────────────
            this.pnlEmpleados.BackColor = System.Drawing.Color.FromArgb(25, 35, 70);
            this.pnlEmpleados.Controls.Add(this.barEmpleados);
            this.pnlEmpleados.Controls.Add(this.bulletEmpleados);
            this.pnlEmpleados.Controls.Add(this.lblEmpleados);
            this.pnlEmpleados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlEmpleados.Location = new System.Drawing.Point(0, 191);
            this.pnlEmpleados.Name = "pnlEmpleados";
            this.pnlEmpleados.Size = new System.Drawing.Size(189, 28);
            this.pnlEmpleados.TabIndex = 6;

            this.barEmpleados.BackColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.barEmpleados.Location = new System.Drawing.Point(0, 0);
            this.barEmpleados.Name = "barEmpleados";
            this.barEmpleados.Size = new System.Drawing.Size(3, 28);
            this.barEmpleados.TabIndex = 0;

            this.bulletEmpleados.AutoSize = true;
            this.bulletEmpleados.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.bulletEmpleados.ForeColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.bulletEmpleados.Location = new System.Drawing.Point(13, 9);
            this.bulletEmpleados.Name = "bulletEmpleados";
            this.bulletEmpleados.TabIndex = 1;
            this.bulletEmpleados.Text = "●";

            this.lblEmpleados.AutoSize = true;
            this.lblEmpleados.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEmpleados.ForeColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.lblEmpleados.Location = new System.Drawing.Point(30, 7);
            this.lblEmpleados.Name = "lblEmpleados";
            this.lblEmpleados.TabIndex = 2;
            this.lblEmpleados.Text = "Empleados";

            // ── pnlAsistencias ───────────────────────────────────────────
            this.pnlAsistencias.BackColor = System.Drawing.Color.Transparent;
            this.pnlAsistencias.Controls.Add(this.barAsistencias);
            this.pnlAsistencias.Controls.Add(this.bulletAsistencias);
            this.pnlAsistencias.Controls.Add(this.lblAsistencias);
            this.pnlAsistencias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlAsistencias.Location = new System.Drawing.Point(0, 221);
            this.pnlAsistencias.Name = "pnlAsistencias";
            this.pnlAsistencias.Size = new System.Drawing.Size(189, 28);
            this.pnlAsistencias.TabIndex = 7;

            this.barAsistencias.BackColor = System.Drawing.Color.Transparent;
            this.barAsistencias.Location = new System.Drawing.Point(0, 0);
            this.barAsistencias.Name = "barAsistencias";
            this.barAsistencias.Size = new System.Drawing.Size(3, 28);
            this.barAsistencias.TabIndex = 0;

            this.bulletAsistencias.AutoSize = true;
            this.bulletAsistencias.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.bulletAsistencias.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.bulletAsistencias.Location = new System.Drawing.Point(13, 9);
            this.bulletAsistencias.Name = "bulletAsistencias";
            this.bulletAsistencias.TabIndex = 1;
            this.bulletAsistencias.Text = "●";

            this.lblAsistencias.AutoSize = true;
            this.lblAsistencias.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAsistencias.ForeColor = System.Drawing.Color.White;
            this.lblAsistencias.Location = new System.Drawing.Point(30, 7);
            this.lblAsistencias.Name = "lblAsistencias";
            this.lblAsistencias.TabIndex = 2;
            this.lblAsistencias.Text = "Asistencias";

            // ── lblSeccionSeguridad ──────────────────────────────────────
            this.lblSeccionSeguridad.AutoSize = true;
            this.lblSeccionSeguridad.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblSeccionSeguridad.ForeColor = System.Drawing.Color.FromArgb(80, 100, 150);
            this.lblSeccionSeguridad.Location = new System.Drawing.Point(17, 260);
            this.lblSeccionSeguridad.Name = "lblSeccionSeguridad";
            this.lblSeccionSeguridad.TabIndex = 8;
            this.lblSeccionSeguridad.Text = "SEGURIDAD";

            // ── pnlAccesoSistema ─────────────────────────────────────────
            this.pnlAccesoSistema.BackColor = System.Drawing.Color.Transparent;
            this.pnlAccesoSistema.Controls.Add(this.barAccesoSistema);
            this.pnlAccesoSistema.Controls.Add(this.bulletAccesoSistema);
            this.pnlAccesoSistema.Controls.Add(this.lblAccesoSistema);
            this.pnlAccesoSistema.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlAccesoSistema.Location = new System.Drawing.Point(0, 282);
            this.pnlAccesoSistema.Name = "pnlAccesoSistema";
            this.pnlAccesoSistema.Size = new System.Drawing.Size(189, 28);
            this.pnlAccesoSistema.TabIndex = 9;

            this.barAccesoSistema.BackColor = System.Drawing.Color.Transparent;
            this.barAccesoSistema.Location = new System.Drawing.Point(0, 0);
            this.barAccesoSistema.Name = "barAccesoSistema";
            this.barAccesoSistema.Size = new System.Drawing.Size(3, 28);
            this.barAccesoSistema.TabIndex = 0;

            this.bulletAccesoSistema.AutoSize = true;
            this.bulletAccesoSistema.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.bulletAccesoSistema.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.bulletAccesoSistema.Location = new System.Drawing.Point(13, 9);
            this.bulletAccesoSistema.Name = "bulletAccesoSistema";
            this.bulletAccesoSistema.TabIndex = 1;
            this.bulletAccesoSistema.Text = "●";

            this.lblAccesoSistema.AutoSize = true;
            this.lblAccesoSistema.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAccesoSistema.ForeColor = System.Drawing.Color.White;
            this.lblAccesoSistema.Location = new System.Drawing.Point(30, 7);
            this.lblAccesoSistema.Name = "lblAccesoSistema";
            this.lblAccesoSistema.TabIndex = 2;
            this.lblAccesoSistema.Text = "Acceso Sistema";

            // ════════════════════════════════════════════════════════════
            //  SECCIÓN NÓMINA (oculta por defecto, aparece con tab Nómina)
            // ════════════════════════════════════════════════════════════

            // lblSeccionNomina
            this.lblSeccionNomina.AutoSize = true;
            this.lblSeccionNomina.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblSeccionNomina.ForeColor = System.Drawing.Color.FromArgb(80, 100, 150);
            this.lblSeccionNomina.Location = new System.Drawing.Point(17, 17);
            this.lblSeccionNomina.Name = "lblSeccionNomina";
            this.lblSeccionNomina.TabIndex = 20;
            this.lblSeccionNomina.Text = "NÓMINA";
            this.lblSeccionNomina.Visible = false;

            // ── pnlVolantesLista ─────────────────────────────────────────
            this.pnlVolantesLista.BackColor = System.Drawing.Color.Transparent;
            this.pnlVolantesLista.Controls.Add(this.barVolantesLista);
            this.pnlVolantesLista.Controls.Add(this.bulletVolantesLista);
            this.pnlVolantesLista.Controls.Add(this.lblVolantesLista);
            this.pnlVolantesLista.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlVolantesLista.Location = new System.Drawing.Point(0, 39);
            this.pnlVolantesLista.Name = "pnlVolantesLista";
            this.pnlVolantesLista.Size = new System.Drawing.Size(189, 28);
            this.pnlVolantesLista.TabIndex = 24;
            this.pnlVolantesLista.Visible = false;

            this.barVolantesLista.BackColor = System.Drawing.Color.Transparent;
            this.barVolantesLista.Location = new System.Drawing.Point(0, 0);
            this.barVolantesLista.Name = "barVolantesLista";
            this.barVolantesLista.Size = new System.Drawing.Size(3, 28);
            this.barVolantesLista.TabIndex = 0;

            this.bulletVolantesLista.AutoSize = true;
            this.bulletVolantesLista.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.bulletVolantesLista.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.bulletVolantesLista.Location = new System.Drawing.Point(13, 9);
            this.bulletVolantesLista.Name = "bulletVolantesLista";
            this.bulletVolantesLista.TabIndex = 1;
            this.bulletVolantesLista.Text = "●";

            this.lblVolantesLista.AutoSize = true;
            this.lblVolantesLista.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVolantesLista.ForeColor = System.Drawing.Color.White;
            this.lblVolantesLista.Location = new System.Drawing.Point(30, 7);
            this.lblVolantesLista.Name = "lblVolantesLista";
            this.lblVolantesLista.TabIndex = 2;
            this.lblVolantesLista.Text = "Volantes de Pago";

            // ── pnlVolantesPago ──────────────────────────────────────────
            this.pnlVolantesPago.BackColor = System.Drawing.Color.Transparent;
            this.pnlVolantesPago.Controls.Add(this.barVolantesPago);
            this.pnlVolantesPago.Controls.Add(this.bulletVolantesPago);
            this.pnlVolantesPago.Controls.Add(this.lblVolantesPago);
            this.pnlVolantesPago.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlVolantesPago.Location = new System.Drawing.Point(0, 39);
            this.pnlVolantesPago.Name = "pnlVolantesPago";
            this.pnlVolantesPago.Size = new System.Drawing.Size(189, 28);
            this.pnlVolantesPago.TabIndex = 21;
            this.pnlVolantesPago.Visible = false;

            this.barVolantesPago.BackColor = System.Drawing.Color.Transparent;
            this.barVolantesPago.Location = new System.Drawing.Point(0, 0);
            this.barVolantesPago.Name = "barVolantesPago";
            this.barVolantesPago.Size = new System.Drawing.Size(3, 28);
            this.barVolantesPago.TabIndex = 0;

            this.bulletVolantesPago.AutoSize = true;
            this.bulletVolantesPago.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.bulletVolantesPago.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.bulletVolantesPago.Location = new System.Drawing.Point(13, 9);
            this.bulletVolantesPago.Name = "bulletVolantesPago";
            this.bulletVolantesPago.TabIndex = 1;
            this.bulletVolantesPago.Text = "●";

            this.lblVolantesPago.AutoSize = true;
            this.lblVolantesPago.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVolantesPago.ForeColor = System.Drawing.Color.White;
            this.lblVolantesPago.Location = new System.Drawing.Point(30, 7);
            this.lblVolantesPago.Name = "lblVolantesPago";
            this.lblVolantesPago.TabIndex = 2;
            this.lblVolantesPago.Text = "Sueldo Neto";

            // ── pnlDeduccionesEmpleado ───────────────────────────────────
            this.pnlDeduccionesEmpleado.BackColor = System.Drawing.Color.Transparent;
            this.pnlDeduccionesEmpleado.Controls.Add(this.barDeduccionesEmpleado);
            this.pnlDeduccionesEmpleado.Controls.Add(this.bulletDeduccionesEmpleado);
            this.pnlDeduccionesEmpleado.Controls.Add(this.lblDeduccionesEmpleado);
            this.pnlDeduccionesEmpleado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlDeduccionesEmpleado.Location = new System.Drawing.Point(0, 69);
            this.pnlDeduccionesEmpleado.Name = "pnlDeduccionesEmpleado";
            this.pnlDeduccionesEmpleado.Size = new System.Drawing.Size(189, 28);
            this.pnlDeduccionesEmpleado.TabIndex = 22;
            this.pnlDeduccionesEmpleado.Visible = false;

            this.barDeduccionesEmpleado.BackColor = System.Drawing.Color.Transparent;
            this.barDeduccionesEmpleado.Location = new System.Drawing.Point(0, 0);
            this.barDeduccionesEmpleado.Name = "barDeduccionesEmpleado";
            this.barDeduccionesEmpleado.Size = new System.Drawing.Size(3, 28);
            this.barDeduccionesEmpleado.TabIndex = 0;

            this.bulletDeduccionesEmpleado.AutoSize = true;
            this.bulletDeduccionesEmpleado.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.bulletDeduccionesEmpleado.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.bulletDeduccionesEmpleado.Location = new System.Drawing.Point(13, 9);
            this.bulletDeduccionesEmpleado.Name = "bulletDeduccionesEmpleado";
            this.bulletDeduccionesEmpleado.TabIndex = 1;
            this.bulletDeduccionesEmpleado.Text = "●";

            this.lblDeduccionesEmpleado.AutoSize = true;
            this.lblDeduccionesEmpleado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDeduccionesEmpleado.ForeColor = System.Drawing.Color.White;
            this.lblDeduccionesEmpleado.Location = new System.Drawing.Point(30, 7);
            this.lblDeduccionesEmpleado.Name = "lblDeduccionesEmpleado";
            this.lblDeduccionesEmpleado.TabIndex = 2;
            this.lblDeduccionesEmpleado.Text = "Deducciones";

            // ── pnlAsignacionesEmpleado ──────────────────────────────────
            this.pnlAsignacionesEmpleado.BackColor = System.Drawing.Color.Transparent;
            this.pnlAsignacionesEmpleado.Controls.Add(this.barAsignacionesEmpleado);
            this.pnlAsignacionesEmpleado.Controls.Add(this.bulletAsignacionesEmpleado);
            this.pnlAsignacionesEmpleado.Controls.Add(this.lblAsignacionesEmpleado);
            this.pnlAsignacionesEmpleado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlAsignacionesEmpleado.Location = new System.Drawing.Point(0, 99);
            this.pnlAsignacionesEmpleado.Name = "pnlAsignacionesEmpleado";
            this.pnlAsignacionesEmpleado.Size = new System.Drawing.Size(189, 28);
            this.pnlAsignacionesEmpleado.TabIndex = 23;
            this.pnlAsignacionesEmpleado.Visible = false;

            this.barAsignacionesEmpleado.BackColor = System.Drawing.Color.Transparent;
            this.barAsignacionesEmpleado.Location = new System.Drawing.Point(0, 0);
            this.barAsignacionesEmpleado.Name = "barAsignacionesEmpleado";
            this.barAsignacionesEmpleado.Size = new System.Drawing.Size(3, 28);
            this.barAsignacionesEmpleado.TabIndex = 0;

            this.bulletAsignacionesEmpleado.AutoSize = true;
            this.bulletAsignacionesEmpleado.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.bulletAsignacionesEmpleado.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.bulletAsignacionesEmpleado.Location = new System.Drawing.Point(13, 9);
            this.bulletAsignacionesEmpleado.Name = "bulletAsignacionesEmpleado";
            this.bulletAsignacionesEmpleado.TabIndex = 1;
            this.bulletAsignacionesEmpleado.Text = "●";

            this.lblAsignacionesEmpleado.AutoSize = true;
            this.lblAsignacionesEmpleado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAsignacionesEmpleado.ForeColor = System.Drawing.Color.White;
            this.lblAsignacionesEmpleado.Location = new System.Drawing.Point(30, 7);
            this.lblAsignacionesEmpleado.Name = "lblAsignacionesEmpleado";
            this.lblAsignacionesEmpleado.TabIndex = 2;
            this.lblAsignacionesEmpleado.Text = "Asignaciones";

            // ── pnlContenido ─────────────────────────────────────────────
            this.pnlContenido.BackColor = System.Drawing.Color.FromArgb(13, 17, 35);
            this.pnlContenido.Controls.Add(this.picLogoBienvenida);
            this.pnlContenido.Controls.Add(this.lblBienvenida);
            this.pnlContenido.Controls.Add(this.lblSubBienvenida);
            this.pnlContenido.Location = new System.Drawing.Point(189, 43);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Size = new System.Drawing.Size(651, 468);
            this.pnlContenido.TabIndex = 2;

            this.picLogoBienvenida.BackColor = System.Drawing.Color.Transparent;
            this.picLogoBienvenida.Image = global::Presentasion.Properties.Resources.WhatsApp_Image_2026_04_10_at_10_25_56_AM;
            this.picLogoBienvenida.Location = new System.Drawing.Point(279, 130);
            this.picLogoBienvenida.Name = "picLogoBienvenida";
            this.picLogoBienvenida.Size = new System.Drawing.Size(94, 95);
            this.picLogoBienvenida.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogoBienvenida.TabIndex = 0;
            this.picLogoBienvenida.TabStop = false;

            this.lblBienvenida.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblBienvenida.ForeColor = System.Drawing.Color.FromArgb(0, 210, 230);
            this.lblBienvenida.Location = new System.Drawing.Point(0, 238);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(651, 26);
            this.lblBienvenida.TabIndex = 1;
            this.lblBienvenida.Text = "Bienvenido al Sistema de Nómina";
            this.lblBienvenida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblSubBienvenida.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubBienvenida.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblSubBienvenida.Location = new System.Drawing.Point(0, 270);
            this.lblSubBienvenida.Name = "lblSubBienvenida";
            this.lblSubBienvenida.Size = new System.Drawing.Size(651, 21);
            this.lblSubBienvenida.TabIndex = 2;
            this.lblSubBienvenida.Text = "Selecciona una opción del menú para comenzar";
            this.lblSubBienvenida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── pnlStatusBar ─────────────────────────────────────────────
            this.pnlStatusBar.BackColor = System.Drawing.Color.FromArgb(10, 14, 30);
            this.pnlStatusBar.Controls.Add(this.pnlPuntito);
            this.pnlStatusBar.Controls.Add(this.lblConectado);
            this.pnlStatusBar.Controls.Add(this.lblHora);
            this.pnlStatusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlStatusBar.Location = new System.Drawing.Point(0, 511);
            this.pnlStatusBar.Name = "pnlStatusBar";
            this.pnlStatusBar.Size = new System.Drawing.Size(840, 26);
            this.pnlStatusBar.TabIndex = 3;

            this.pnlPuntito.BackColor = System.Drawing.Color.FromArgb(39, 201, 63);
            this.pnlPuntito.Location = new System.Drawing.Point(12, 10);
            this.pnlPuntito.Name = "pnlPuntito";
            this.pnlPuntito.Size = new System.Drawing.Size(7, 7);
            this.pnlPuntito.TabIndex = 0;

            this.lblConectado.AutoSize = true;
            this.lblConectado.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblConectado.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblConectado.Location = new System.Drawing.Point(24, 7);
            this.lblConectado.Name = "lblConectado";
            this.lblConectado.TabIndex = 1;
            this.lblConectado.Text = "Conectado — TalentBusDB3";

            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblHora.ForeColor = System.Drawing.Color.FromArgb(130, 150, 190);
            this.lblHora.Location = new System.Drawing.Point(737, 7);
            this.lblHora.Name = "lblHora";
            this.lblHora.TabIndex = 2;
            this.lblHora.Text = "12:00:00 PM";

            // ── FrmPrincipal ─────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(13, 17, 35);
            this.ClientSize = new System.Drawing.Size(840, 537);
            this.Controls.Add(this.pnlContenido);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlStatusBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TalentBus DB3 — Sistema de Nómina";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoMini)).EndInit();
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            this.pnlDepartamentos.ResumeLayout(false);
            this.pnlDepartamentos.PerformLayout();
            this.pnlPosiciones.ResumeLayout(false);
            this.pnlPosiciones.PerformLayout();
            this.pnlDeducciones.ResumeLayout(false);
            this.pnlDeducciones.PerformLayout();
            this.pnlAsignaciones.ResumeLayout(false);
            this.pnlAsignaciones.PerformLayout();
            this.pnlEmpleados.ResumeLayout(false);
            this.pnlEmpleados.PerformLayout();
            this.pnlAsistencias.ResumeLayout(false);
            this.pnlAsistencias.PerformLayout();
            this.pnlAccesoSistema.ResumeLayout(false);
            this.pnlAccesoSistema.PerformLayout();
            this.pnlVolantesLista.ResumeLayout(false);
            this.pnlVolantesLista.PerformLayout();
            this.pnlVolantesPago.ResumeLayout(false);
            this.pnlVolantesPago.PerformLayout();
            this.pnlDeduccionesEmpleado.ResumeLayout(false);
            this.pnlDeduccionesEmpleado.PerformLayout();
            this.pnlAsignacionesEmpleado.ResumeLayout(false);
            this.pnlAsignacionesEmpleado.PerformLayout();
            this.pnlContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogoBienvenida)).EndInit();
            this.pnlStatusBar.ResumeLayout(false);
            this.pnlStatusBar.PerformLayout();
            this.ResumeLayout(false);
        }

        // ── Declaraciones ──────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Button btnVerde;
        private System.Windows.Forms.PictureBox picLogoMini;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Button btnTabEntrada;
        private System.Windows.Forms.Button btnTabNomina;
        private System.Windows.Forms.Button btnSalir;

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Label lblSeccionConfig;
        private System.Windows.Forms.Panel pnlDepartamentos;
        private System.Windows.Forms.Panel barDepartamentos;
        private System.Windows.Forms.Label bulletDepartamentos;
        private System.Windows.Forms.Label lblDepartamentos;
        private System.Windows.Forms.Panel pnlPosiciones;
        private System.Windows.Forms.Panel barPosiciones;
        private System.Windows.Forms.Label bulletPosiciones;
        private System.Windows.Forms.Label lblPosiciones;
        private System.Windows.Forms.Panel pnlDeducciones;
        private System.Windows.Forms.Panel barDeducciones;
        private System.Windows.Forms.Label bulletDeducciones;
        private System.Windows.Forms.Label lblDeducciones;
        private System.Windows.Forms.Panel pnlAsignaciones;
        private System.Windows.Forms.Panel barAsignaciones;
        private System.Windows.Forms.Label bulletAsignaciones;
        private System.Windows.Forms.Label lblAsignaciones;
        private System.Windows.Forms.Label lblSeccionEmpleados;
        private System.Windows.Forms.Panel pnlEmpleados;
        private System.Windows.Forms.Panel barEmpleados;
        private System.Windows.Forms.Label bulletEmpleados;
        private System.Windows.Forms.Label lblEmpleados;
        private System.Windows.Forms.Panel pnlAsistencias;
        private System.Windows.Forms.Panel barAsistencias;
        private System.Windows.Forms.Label bulletAsistencias;
        private System.Windows.Forms.Label lblAsistencias;
        private System.Windows.Forms.Label lblSeccionSeguridad;
        private System.Windows.Forms.Panel pnlAccesoSistema;
        private System.Windows.Forms.Panel barAccesoSistema;
        private System.Windows.Forms.Label bulletAccesoSistema;
        private System.Windows.Forms.Label lblAccesoSistema;

        // Sección Nómina
        private System.Windows.Forms.Label lblSeccionNomina;
        private System.Windows.Forms.Panel pnlVolantesLista;
        private System.Windows.Forms.Panel barVolantesLista;
        private System.Windows.Forms.Label bulletVolantesLista;
        private System.Windows.Forms.Label lblVolantesLista;
        private System.Windows.Forms.Panel pnlVolantesPago;
        private System.Windows.Forms.Panel barVolantesPago;
        private System.Windows.Forms.Label bulletVolantesPago;
        private System.Windows.Forms.Label lblVolantesPago;
        private System.Windows.Forms.Panel pnlDeduccionesEmpleado;
        private System.Windows.Forms.Panel barDeduccionesEmpleado;
        private System.Windows.Forms.Label bulletDeduccionesEmpleado;
        private System.Windows.Forms.Label lblDeduccionesEmpleado;
        private System.Windows.Forms.Panel pnlAsignacionesEmpleado;
        private System.Windows.Forms.Panel barAsignacionesEmpleado;
        private System.Windows.Forms.Label bulletAsignacionesEmpleado;
        private System.Windows.Forms.Label lblAsignacionesEmpleado;

        private System.Windows.Forms.Panel pnlContenido;
        private System.Windows.Forms.PictureBox picLogoBienvenida;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Label lblSubBienvenida;

        private System.Windows.Forms.Panel pnlStatusBar;
        private System.Windows.Forms.Panel pnlPuntito;
        private System.Windows.Forms.Label lblConectado;
        private System.Windows.Forms.Label lblHora;
    }
}