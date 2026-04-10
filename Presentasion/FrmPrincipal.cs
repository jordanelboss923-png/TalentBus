using Negocio.Configuracion;
using Negocios.Seguridad;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmPrincipal : Form
    {
        // ─── Colores del tema ───
        private readonly Color ColorFondo = Color.FromArgb(13, 17, 35);
        private readonly Color ColorSidebar = Color.FromArgb(18, 24, 48);
        private readonly Color ColorHeader = Color.FromArgb(18, 24, 48);
        private readonly Color ColorCyan = Color.FromArgb(0, 210, 230);
        private readonly Color ColorTexto = Color.White;
        private readonly Color ColorSubTexto = Color.FromArgb(130, 150, 190);
        private readonly Color ColorSeccion = Color.FromArgb(80, 100, 150);
        private readonly Color ColorItemActivo = Color.FromArgb(25, 35, 70);
        private readonly Color ColorBorde = Color.FromArgb(30, 40, 80);
        private readonly Color ColorStatusBar = Color.FromArgb(10, 14, 30);

        // ─── Estado ───
        private string _usuarioActual;
        private Panel _itemActivo;
        private Panel _contenido;
        private Panel _sidebar;
        private Panel _header;
        private Panel _statusBar;
        private Label _lblHora;
        private Timer _timer;

        // ─── Tabs del header ───
        private Button _tabActiva;

        public FrmPrincipal(string usuario)
        {
            InitializeComponent();
            _usuarioActual = usuario;
            ConfigurarFormulario();
            ConstruirUI();
            IniciarReloj();
        }

        // ════════════════════════════════════════
        //  CONFIGURACIÓN GENERAL
        // ════════════════════════════════════════
        private void ConfigurarFormulario()
        {
            this.Text = "TalentBus DB3 — Sistema de Nómina";
            this.Size = new Size(980, 620);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = ColorFondo;
            this.DoubleBuffered = true;

            this.MouseDown += (s, e) => {
                if (e.Button == MouseButtons.Left && e.Y < 50)
                {
                    NativeMethods.ReleaseCapture();
                    NativeMethods.SendMessage(this.Handle, 0xA1, 0x2, 0);
                }
            };
        }

        // ════════════════════════════════════════
        //  CONSTRUCCIÓN DE LA UI
        // ════════════════════════════════════════
        private void ConstruirUI()
        {
            ConstruirHeader();
            ConstruirSidebar();
            ConstruirContenido();
            ConstruirStatusBar();
            MostrarBienvenida();
        }

        // ── HEADER ───────────────────────────────
        private void ConstruirHeader()
        {
            _header = new Panel
            {
                Size = new Size(this.Width, 50),
                Location = new Point(0, 0),
                BackColor = ColorHeader
            };
            _header.Paint += (s, e) =>
            {
                using (Pen p = new Pen(ColorBorde, 1))
                    e.Graphics.DrawLine(p, 0, _header.Height - 1,
                                           _header.Width, _header.Height - 1);
            };
            this.Controls.Add(_header);

            // ── Botones macOS ─────────────────────
            AgregarBotonesVentana(_header);

            // ── Logo pequeño ──────────────────────
            PictureBox picMini = new PictureBox
            {
                Size = new Size(28, 28),
                Location = new Point(85, 11),
                BackColor = Color.Transparent
            };
            picMini.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen p = new Pen(ColorCyan, 1.5f))
                    e.Graphics.DrawEllipse(p, 1, 1, 24, 24);
                DibujarEstrella(e.Graphics, 14, 14, 9, 4, 5, ColorCyan);
            };
            _header.Controls.Add(picMini);

            // ── Label TalentBus ───────────────────
            Label lblMarca = new Label
            {
                Text = "TalentBus",
                ForeColor = ColorCyan,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(118, 15)
            };
            _header.Controls.Add(lblMarca);

            // ── Tabs ──────────────────────────────
            string[] tabs = { "Entrada", "Nómina", "Consulta" };
            int xTab = 210;

            foreach (string tab in tabs)
            {
                Button btn = new Button
                {
                    Text = tab,
                    Size = new Size(90, 50),
                    Location = new Point(xTab, 0),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.Transparent,
                    ForeColor = ColorSubTexto,
                    Font = new Font("Segoe UI", 9),
                    Cursor = Cursors.Hand,
                    Tag = tab
                };
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.MouseOverBackColor = Color.Transparent;
                btn.Paint += Tab_Paint;
                btn.Click += Tab_Click;
                btn.MouseEnter += (s, e) => {
                    if ((Button)s != _tabActiva)
                        ((Button)s).ForeColor = ColorTexto;
                };
                btn.MouseLeave += (s, e) => {
                    if ((Button)s != _tabActiva)
                        ((Button)s).ForeColor = ColorSubTexto;
                };
                _header.Controls.Add(btn);

                if (tab == "Entrada")
                {
                    _tabActiva = btn;
                    btn.ForeColor = ColorTexto;
                }

                xTab += 90;
            }

            // ── Botón Salir ───────────────────────
            Button btnSalir = new Button
            {
                Text = "Salir",
                Size = new Size(60, 30),
                Location = new Point(this.Width - 80, 10),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                ForeColor = Color.FromArgb(255, 80, 80),
                Font = new Font("Segoe UI", 9),
                Cursor = Cursors.Hand
            };
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.Click += (s, e) => {
                if (MessageBox.Show("¿Deseas cerrar sesión?", "Salir",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    new FrmLogin().Show();
                    this.Close();
                }
            };
            _header.Controls.Add(btnSalir);
        }

        // ── SIDEBAR ───────────────────────────────
        private void ConstruirSidebar()
        {
            _sidebar = new Panel
            {
                Size = new Size(220, this.Height - 80),
                Location = new Point(0, 50),
                BackColor = ColorSidebar
            };
            _sidebar.Paint += (s, e) =>
            {
                using (Pen p = new Pen(ColorBorde, 1))
                    e.Graphics.DrawLine(p, _sidebar.Width - 1, 0,
                                           _sidebar.Width - 1, _sidebar.Height);
            };
            this.Controls.Add(_sidebar);

            // Sección CONFIGURACIÓN
            AgregarSeccion(_sidebar, "CONFIGURACIÓN", 20);
            AgregarItem(_sidebar, "Departamentos", 45, "Departamentos");
            AgregarItem(_sidebar, "Posiciones", 80, "Posiciones");
            AgregarItem(_sidebar, "Deducciones", 115, "Deducciones");
            AgregarItem(_sidebar, "Asignaciones", 150, "Asignaciones");

            // Sección EMPLEADOS
            AgregarSeccion(_sidebar, "EMPLEADOS", 195);
            AgregarItem(_sidebar, "Empleados", 220, "Empleados", activo: true);
            AgregarItem(_sidebar, "Asistencias", 255, "Asistencias");

            // Sección SEGURIDAD
            AgregarSeccion(_sidebar, "SEGURIDAD", 300);
            AgregarItem(_sidebar, "Acceso Sistema", 325, "AccesoSistema");
        }

        private void AgregarSeccion(Panel sidebar, string texto, int y)
        {
            Label lbl = new Label
            {
                Text = texto,
                ForeColor = ColorSeccion,
                Font = new Font("Segoe UI", 7.5f, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, y)
            };
            sidebar.Controls.Add(lbl);
        }

        private void AgregarItem(Panel sidebar, string texto, int y,
                                  string tag, bool activo = false)
        {
            Panel item = new Panel
            {
                Size = new Size(220, 32),
                Location = new Point(0, y),
                BackColor = activo ? ColorItemActivo : Color.Transparent,
                Cursor = Cursors.Hand,
                Tag = tag
            };

            // Barra lateral cyan si está activo
            Panel barra = new Panel
            {
                Size = new Size(3, 32),
                Location = new Point(0, 0),
                BackColor = activo ? ColorCyan : Color.Transparent
            };
            item.Controls.Add(barra);

            // Bullet
            Label bullet = new Label
            {
                Text = "●",
                ForeColor = activo ? ColorCyan : ColorSubTexto,
                Font = new Font("Segoe UI", 7),
                AutoSize = true,
                Location = new Point(15, 10)
            };
            item.Controls.Add(bullet);

            // Texto
            Label lbl = new Label
            {
                Text = texto,
                ForeColor = activo ? ColorCyan : ColorTexto,
                Font = new Font("Segoe UI", 9, activo ? FontStyle.Bold : FontStyle.Regular),
                AutoSize = true,
                Location = new Point(35, 8)
            };
            item.Controls.Add(lbl);

            // Hover
            item.MouseEnter += (s, e) => {
                if (item != _itemActivo)
                    item.BackColor = Color.FromArgb(20, 30, 58);
            };
            item.MouseLeave += (s, e) => {
                if (item != _itemActivo)
                    item.BackColor = Color.Transparent;
            };

            // Click — propagar a todos los controles hijos
            Action<object, EventArgs> onClick = (s, e) => Item_Click(item, tag);
            item.Click += (s, e) => onClick(s, e);
            lbl.Click += (s, e) => onClick(s, e);
            bullet.Click += (s, e) => onClick(s, e);

            if (activo) _itemActivo = item;

            sidebar.Controls.Add(item);
        }

        // ── CONTENIDO ─────────────────────────────
        private void ConstruirContenido()
        {
            _contenido = new Panel
            {
                Size = new Size(this.Width - 220, this.Height - 80),
                Location = new Point(220, 50),
                BackColor = ColorFondo
            };
            this.Controls.Add(_contenido);
        }

        // ── STATUS BAR ────────────────────────────
        private void ConstruirStatusBar()
        {
            _statusBar = new Panel
            {
                Size = new Size(this.Width, 30),
                Location = new Point(0, this.Height - 30),
                BackColor = ColorStatusBar
            };
            _statusBar.Paint += (s, e) =>
            {
                using (Pen p = new Pen(ColorBorde, 1))
                    e.Graphics.DrawLine(p, 0, 0, _statusBar.Width, 0);
            };
            this.Controls.Add(_statusBar);

            // Punto verde + Conectado
            Panel puntito = new Panel
            {
                Size = new Size(8, 8),
                Location = new Point(14, 11),
                BackColor = Color.FromArgb(39, 201, 63)
            };
            puntito.Region = new Region(new RectangleF(0, 0, 8, 8));
            _statusBar.Controls.Add(puntito);

            Label lblConectado = new Label
            {
                Text = "Conectado — TalentBusDB3",
                ForeColor = ColorSubTexto,
                Font = new Font("Segoe UI", 8),
                AutoSize = true,
                Location = new Point(28, 8)
            };
            _statusBar.Controls.Add(lblConectado);

            // Reloj
            _lblHora = new Label
            {
                Text = DateTime.Now.ToString("h:mm:ss tt"),
                ForeColor = ColorSubTexto,
                Font = new Font("Segoe UI", 8),
                AutoSize = true,
                Location = new Point(this.Width - 120, 8)
            };
            _statusBar.Controls.Add(_lblHora);
        }

        // ════════════════════════════════════════
        //  PANTALLA DE BIENVENIDA
        // ════════════════════════════════════════
        private void MostrarBienvenida()
        {
            _contenido.Controls.Clear();

            // Logo grande
            PictureBox pic = new PictureBox
            {
                Size = new Size(110, 110),
                Location = new Point((_contenido.Width - 110) / 2,
                                       _contenido.Height / 2 - 120),
                BackColor = Color.Transparent
            };
            pic.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (SolidBrush bg = new SolidBrush(Color.FromArgb(20, 35, 70)))
                    e.Graphics.FillEllipse(bg, 5, 5, 98, 98);
                using (Pen p = new Pen(Color.FromArgb(30, 50, 100), 2))
                    e.Graphics.DrawEllipse(p, 5, 5, 98, 98);
                DibujarEstrella(e.Graphics, 55, 55, 35, 16, 5,
                                Color.FromArgb(0, 180, 210));
            };
            _contenido.Controls.Add(pic);

            Label lblBienvenida = new Label
            {
                Text = "Bienvenido al Sistema de Nómina",
                ForeColor = ColorCyan,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                AutoSize = false,
                Size = new Size(_contenido.Width, 30),
                Location = new Point(0, pic.Bottom + 20),
                TextAlign = ContentAlignment.MiddleCenter
            };
            _contenido.Controls.Add(lblBienvenida);

            Label lblSub = new Label
            {
                Text = "Selecciona una opción del menú para comenzar",
                ForeColor = ColorSubTexto,
                Font = new Font("Segoe UI", 9),
                AutoSize = false,
                Size = new Size(_contenido.Width, 24),
                Location = new Point(0, lblBienvenida.Bottom + 6),
                TextAlign = ContentAlignment.MiddleCenter
            };
            _contenido.Controls.Add(lblSub);
        }

        // ════════════════════════════════════════
        //  EVENTOS
        // ════════════════════════════════════════
        private void Tab_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            _tabActiva = btn;

            foreach (Control c in _header.Controls)
            {
                if (c is Button b && b.Tag is string t &&
                    new[] { "Entrada", "Nómina", "Consulta" }.Contains(t))
                {
                    b.ForeColor = ColorSubTexto;
                }
            }
            btn.ForeColor = ColorTexto;
            btn.Invalidate();

            // Actualizar sidebar según tab
            ActualizarSidebarPorTab(btn.Tag.ToString());
            MostrarBienvenida();
        }

        private void Tab_Paint(object sender, PaintEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn == _tabActiva)
            {
                using (Pen p = new Pen(ColorCyan, 2))
                    e.Graphics.DrawLine(p, 0, btn.Height - 2, btn.Width, btn.Height - 2);
            }
        }

        private void Item_Click(Panel item, string tag)
        {
            // Desactivar anterior
            if (_itemActivo != null)
            {
                _itemActivo.BackColor = Color.Transparent;
                foreach (Control c in _itemActivo.Controls)
                {
                    if (c is Panel bar) bar.BackColor = Color.Transparent;
                    if (c is Label lbl)
                    {
                        lbl.ForeColor = lbl.Text == "●" ? ColorSubTexto : ColorTexto;
                        lbl.Font = new Font("Segoe UI", lbl.Text == "●" ? 7f : 9f);
                    }
                }
            }

            // Activar nuevo
            _itemActivo = item;
            item.BackColor = ColorItemActivo;
            foreach (Control c in item.Controls)
            {
                if (c is Panel bar) bar.BackColor = ColorCyan;
                if (c is Label lbl)
                {
                    lbl.ForeColor = ColorCyan;
                    if (lbl.Text != "●")
                        lbl.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                }
            }

            // Abrir formulario hijo
            AbrirModulo(tag);
        }

        private void ActualizarSidebarPorTab(string tab)
        {
            // Limpiar y reconstruir sidebar según tab seleccionada
            _sidebar.Controls.Clear();

            if (tab == "Entrada")
            {
                AgregarSeccion(_sidebar, "CONFIGURACIÓN", 20);
                AgregarItem(_sidebar, "Departamentos", 45, "Departamentos");
                AgregarItem(_sidebar, "Posiciones", 80, "Posiciones");
                AgregarItem(_sidebar, "Deducciones", 115, "Deducciones");
                AgregarItem(_sidebar, "Asignaciones", 150, "Asignaciones");
                AgregarSeccion(_sidebar, "EMPLEADOS", 195);
                AgregarItem(_sidebar, "Empleados", 220, "Empleados");
                AgregarItem(_sidebar, "Asistencias", 255, "Asistencias");
                AgregarSeccion(_sidebar, "SEGURIDAD", 300);
                AgregarItem(_sidebar, "Acceso Sistema", 325, "AccesoSistema");
            }
            else if (tab == "Nómina")
            {
                AgregarSeccion(_sidebar, "NÓMINA", 20);
                AgregarItem(_sidebar, "Volantes de Pago", 45, "VolantesPago");
                AgregarItem(_sidebar, "Asignaciones", 80, "AsignacionesEmp");
                AgregarItem(_sidebar, "Deducciones", 115, "DeduccionesEmp");
            }
            else if (tab == "Consulta")
            {
                AgregarSeccion(_sidebar, "CONSULTAS", 20);
                AgregarItem(_sidebar, "Historial Nómina", 45, "HistorialNomina");
            }

            _itemActivo = null;
        }

        private void AbrirModulo(string tag)
        {
            _contenido.Controls.Clear();

            Form frm = null;

            switch (tag)
            {
                case "Departamentos": frm = new FrmDepartamentos(); break;
                case "Posiciones": frm = new FrmPosiciones(); break;
                case "Deducciones": frm = new FrmDeducciones(); break;
                case "Asignaciones": frm = new FrmAsignaciones(); break;
                case "Empleados": frm = new FrmEmpleados(); break;
                case "Asistencias": frm = new FrmAsistencias(); break;
                case "AccesoSistema": frm = new FrmAccesoSistema(); break;
                case "VolantesPago": frm = new FrmVolantesPago(); break;
                default: MostrarBienvenida(); return;
            }

            if (frm != null)
            {
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                frm.BackColor = ColorFondo;
                _contenido.Controls.Add(frm);
                frm.Show();
            }
        }

        // ════════════════════════════════════════
        //  RELOJ
        // ════════════════════════════════════════
        private void IniciarReloj()
        {
            _timer = new Timer { Interval = 1000 };
            _timer.Tick += (s, e) =>
                _lblHora.Text = DateTime.Now.ToString("h:mm:ss tt");
            _timer.Start();
        }

        // ════════════════════════════════════════
        //  HELPERS
        // ════════════════════════════════════════
        private void AgregarBotonesVentana(Panel parent)
        {
            int[] x = { 16, 36, 56 };
            Color[] cols = {
                Color.FromArgb(255, 95, 86),
                Color.FromArgb(255, 189, 46),
                Color.FromArgb(39, 201, 63)
            };

            for (int i = 0; i < 3; i++)
            {
                int idx = i;
                Button btn = new Button
                {
                    Size = new Size(14, 14),
                    Location = new Point(x[idx], 18),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = cols[idx],
                    Text = ""
                };
                btn.FlatAppearance.BorderSize = 0;
                btn.Region = CrearRegionCircular(14);

                if (idx == 0)
                    btn.Click += (s, e) => Application.Exit();
                else if (idx == 1)
                    btn.Click += (s, e) =>
                        this.WindowState = FormWindowState.Minimized;

                parent.Controls.Add(btn);
            }
        }

        private Region CrearRegionCircular(int size)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, size, size);
            return new Region(path);
        }

        private void DibujarEstrella(Graphics g, float cx, float cy,
                                     float radioExt, float radioInt,
                                     int puntas, Color color)
        {
            PointF[] pts = new PointF[puntas * 2];
            double angulo = -Math.PI / 2;
            double paso = Math.PI / puntas;

            for (int i = 0; i < puntas * 2; i++)
            {
                float r = (i % 2 == 0) ? radioExt : radioInt;
                pts[i] = new PointF(
                    cx + r * (float)Math.Cos(angulo),
                    cy + r * (float)Math.Sin(angulo));
                angulo += paso;
            }

            using (SolidBrush b = new SolidBrush(color))
                g.FillPolygon(b, pts);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _timer?.Stop();
            base.OnFormClosed(e);
        }
    }
}