using Negocio.Configuracion;
using Negocios.Seguridad;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmPrincipal : Form
    {
        // ── Colores ──────────────────────────────────────────────────────────
        private readonly Color ColorFondo = Color.FromArgb(13, 17, 35);
        private readonly Color ColorCyan = Color.FromArgb(0, 210, 230);
        private readonly Color ColorTexto = Color.White;
        private readonly Color ColorSubTexto = Color.FromArgb(130, 150, 190);
        private readonly Color ColorItemActivo = Color.FromArgb(25, 35, 70);
        private readonly Color ColorBorde = Color.FromArgb(30, 40, 80);

        // ── Estado ───────────────────────────────────────────────────────────
        private string _usuarioActual;
        private Panel _itemActivo;
        private Button _tabActiva;
        private Timer _timer;

        private Dictionary<string, bool> _seccionesExpandidas = new Dictionary<string, bool>
        {
            { "Config",    true },
            { "Empleados", true },
            { "Seguridad", true },
            { "Nomina",    true }
        };

        public FrmPrincipal(string usuario)
        {
            InitializeComponent();
            _usuarioActual = usuario;
            ConfigurarEventos();
            IniciarReloj();
        }

        // ════════════════════════════════════════════════════════════════════
        //  CONFIGURACIÓN DE EVENTOS
        // ════════════════════════════════════════════════════════════════════
        private void ConfigurarEventos()
        {
            this.MouseDown += (s, e) => {
                if (e.Button == MouseButtons.Left && e.Y < 50)
                {
                    NativeMethods.ReleaseCapture();
                    NativeMethods.SendMessage(this.Handle, 0xA1, 0x2, 0);
                }
            };

            btnCerrar.Region = CrearRegionCircular(14);
            btnMinimizar.Region = CrearRegionCircular(14);
            btnVerde.Region = CrearRegionCircular(14);
            pnlPuntito.Region = new Region(new RectangleF(0, 0, 8, 8));

            btnCerrar.Click += (s, e) => Application.Exit();
            btnMinimizar.Click += (s, e) => this.WindowState = FormWindowState.Minimized;

            // Solo dos tabs: Entrada y Nómina
            _tabActiva = btnTabEntrada;
            foreach (Button btn in new[] { btnTabEntrada, btnTabNomina })
            {
                btn.Paint += Tab_Paint;
                btn.Click += Tab_Click;
                btn.MouseEnter += (s, e) => { if ((Button)s != _tabActiva) ((Button)s).ForeColor = ColorTexto; };
                btn.MouseLeave += (s, e) => { if ((Button)s != _tabActiva) ((Button)s).ForeColor = ColorSubTexto; };
            }

            btnSalir.Click += (s, e) => {
                if (MessageBox.Show("¿Deseas cerrar sesión?", "Salir",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    new FrmLogin().Show();
                    this.Close();
                }
            };

            pnlHeader.Paint += (s, e) => {
                using (Pen p = new Pen(ColorBorde, 1))
                    e.Graphics.DrawLine(p, 0, pnlHeader.Height - 1, pnlHeader.Width, pnlHeader.Height - 1);
            };
            pnlSidebar.Paint += (s, e) => {
                using (Pen p = new Pen(ColorBorde, 1))
                    e.Graphics.DrawLine(p, pnlSidebar.Width - 1, 0, pnlSidebar.Width - 1, pnlSidebar.Height);
            };
            pnlStatusBar.Paint += (s, e) => {
                using (Pen p = new Pen(ColorBorde, 1))
                    e.Graphics.DrawLine(p, 0, 0, pnlStatusBar.Width, 0);
            };

            // Items sidebar — Entrada
            ConfigurarItem(pnlDepartamentos, barDepartamentos, bulletDepartamentos, lblDepartamentos, "Departamentos");
            ConfigurarItem(pnlPosiciones, barPosiciones, bulletPosiciones, lblPosiciones, "Posiciones");
            ConfigurarItem(pnlDeducciones, barDeducciones, bulletDeducciones, lblDeducciones, "Deducciones");
            ConfigurarItem(pnlAsignaciones, barAsignaciones, bulletAsignaciones, lblAsignaciones, "Asignaciones");
            ConfigurarItem(pnlEmpleados, barEmpleados, bulletEmpleados, lblEmpleados, "Empleados");
            ConfigurarItem(pnlAsistencias, barAsistencias, bulletAsistencias, lblAsistencias, "Asistencias");
            ConfigurarItem(pnlAccesoSistema, barAccesoSistema, bulletAccesoSistema, lblAccesoSistema, "AccesoSistema");

            // Items sidebar — Nómina
            ConfigurarItem(pnlVolantesLista, barVolantesLista, bulletVolantesLista, lblVolantesLista, "VolantesLista");
            ConfigurarItem(pnlVolantesPago, barVolantesPago, bulletVolantesPago, lblVolantesPago, "VolantesPago");
            ConfigurarItem(pnlDeduccionesEmpleado, barDeduccionesEmpleado, bulletDeduccionesEmpleado, lblDeduccionesEmpleado, "DeduccionesEmpleado");
            ConfigurarItem(pnlAsignacionesEmpleado, barAsignacionesEmpleado, bulletAsignacionesEmpleado, lblAsignacionesEmpleado, "AsignacionesEmpleado");

            // Headers desplegables — Entrada
            Panel[] itemsConfig = { pnlDepartamentos, pnlPosiciones, pnlDeducciones, pnlAsignaciones };
            Panel[] itemsEmpleados = { pnlEmpleados, pnlAsistencias };
            Panel[] itemsSeguridad = { pnlAccesoSistema };

            lblSeccionConfig.Text = "CONFIGURACIÓN  ▾";
            lblSeccionEmpleados.Text = "EMPLEADOS  ▾";
            lblSeccionSeguridad.Text = "SEGURIDAD  ▾";

            lblSeccionConfig.Cursor = Cursors.Hand;
            lblSeccionEmpleados.Cursor = Cursors.Hand;
            lblSeccionSeguridad.Cursor = Cursors.Hand;

            lblSeccionConfig.Click += (s, e) => ToggleSeccion("Config", lblSeccionConfig, itemsConfig);
            lblSeccionEmpleados.Click += (s, e) => ToggleSeccion("Empleados", lblSeccionEmpleados, itemsEmpleados);
            lblSeccionSeguridad.Click += (s, e) => ToggleSeccion("Seguridad", lblSeccionSeguridad, itemsSeguridad);

            // Headers desplegables — Nómina
            Panel[] itemsNomina = { pnlVolantesLista, pnlVolantesPago, pnlDeduccionesEmpleado, pnlAsignacionesEmpleado };

            lblSeccionNomina.Text = "NÓMINA  ▾";
            lblSeccionNomina.Cursor = Cursors.Hand;
            lblSeccionNomina.Click += (s, e) => ToggleSeccion("Nomina", lblSeccionNomina, itemsNomina);

            _itemActivo = pnlEmpleados;
            MostrarSidebarEntrada();
        }

        // ════════════════════════════════════════════════════════════════════
        //  TABS
        // ════════════════════════════════════════════════════════════════════
        private void Tab_Click(object sender, EventArgs e)
        {
            _tabActiva = (Button)sender;

            foreach (Button btn in new[] { btnTabEntrada, btnTabNomina })
                btn.ForeColor = ColorSubTexto;

            _tabActiva.ForeColor = ColorTexto;
            _tabActiva.Invalidate();

            if (_tabActiva == btnTabEntrada)
            {
                MostrarSidebarEntrada();
                MostrarBienvenida();
            }
            else if (_tabActiva == btnTabNomina)
            {
                MostrarSidebarNomina();
                MostrarBienvenida();
            }
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

        // ════════════════════════════════════════════════════════════════════
        //  CONTROL DEL SIDEBAR POR TAB
        // ════════════════════════════════════════════════════════════════════
        private void MostrarSidebarEntrada()
        {
            lblSeccionNomina.Visible = false;
            pnlVolantesLista.Visible = false;
            pnlVolantesPago.Visible = false;
            pnlDeduccionesEmpleado.Visible = false;
            pnlAsignacionesEmpleado.Visible = false;

            lblSeccionConfig.Visible = true;
            lblSeccionEmpleados.Visible = true;
            lblSeccionSeguridad.Visible = true;

            RecalcularPosicionesEntrada();
        }

        private void MostrarSidebarNomina()
        {
            lblSeccionConfig.Visible = false;
            lblSeccionEmpleados.Visible = false;
            lblSeccionSeguridad.Visible = false;
            pnlDepartamentos.Visible = false;
            pnlPosiciones.Visible = false;
            pnlDeducciones.Visible = false;
            pnlAsignaciones.Visible = false;
            pnlEmpleados.Visible = false;
            pnlAsistencias.Visible = false;
            pnlAccesoSistema.Visible = false;

            lblSeccionNomina.Visible = true;
            RecalcularPosicionesNomina();
        }

        // ════════════════════════════════════════════════════════════════════
        //  SECCIONES DESPLEGABLES
        // ════════════════════════════════════════════════════════════════════
        private void ToggleSeccion(string key, Label lblHeader, Panel[] items)
        {
            bool abierto = _seccionesExpandidas[key];
            _seccionesExpandidas[key] = !abierto;

            if (lblHeader.Text.EndsWith("▾"))
                lblHeader.Text = lblHeader.Text.Replace("▾", "▸");
            else
                lblHeader.Text = lblHeader.Text.Replace("▸", "▾");

            var timerAnim = new System.Windows.Forms.Timer { Interval = 10 };
            int alturaActual = abierto ? items.Length * 28 : 0;
            int alturaObjetivo = abierto ? 0 : items.Length * 28;
            int paso = abierto ? -4 : 4;

            timerAnim.Tick += (s, e) =>
            {
                alturaActual = Math.Max(0, Math.Min(items.Length * 28, alturaActual + paso));
                foreach (var item in items)
                    item.Visible = alturaActual > 0;

                if (_tabActiva == btnTabEntrada || _tabActiva == null)
                    RecalcularPosicionesEntrada();
                else if (_tabActiva == btnTabNomina)
                    RecalcularPosicionesNomina();

                if (alturaActual == alturaObjetivo)
                    timerAnim.Stop();
            };
            timerAnim.Start();
        }

        private void RecalcularPosicionesEntrada()
        {
            int y = 10;

            lblSeccionConfig.Top = y;
            y += lblSeccionConfig.Height + 4;

            if (_seccionesExpandidas["Config"])
            {
                foreach (var item in new[] { pnlDepartamentos, pnlPosiciones, pnlDeducciones, pnlAsignaciones })
                { item.Top = y; item.Visible = true; y += 28; }
            }
            else
            {
                foreach (var item in new[] { pnlDepartamentos, pnlPosiciones, pnlDeducciones, pnlAsignaciones })
                    item.Visible = false;
            }

            y += 8;
            lblSeccionEmpleados.Top = y;
            y += lblSeccionEmpleados.Height + 4;

            if (_seccionesExpandidas["Empleados"])
            {
                foreach (var item in new[] { pnlEmpleados, pnlAsistencias })
                { item.Top = y; item.Visible = true; y += 28; }
            }
            else
            {
                foreach (var item in new[] { pnlEmpleados, pnlAsistencias })
                    item.Visible = false;
            }

            y += 8;
            lblSeccionSeguridad.Top = y;
            y += lblSeccionSeguridad.Height + 4;

            if (_seccionesExpandidas["Seguridad"])
            { pnlAccesoSistema.Top = y; pnlAccesoSistema.Visible = true; }
            else
            { pnlAccesoSistema.Visible = false; }
        }

        private void RecalcularPosicionesNomina()
        {
            int y = 10;

            lblSeccionNomina.Top = y;
            y += lblSeccionNomina.Height + 4;

            if (_seccionesExpandidas["Nomina"])
            {
                foreach (var item in new[] { pnlVolantesLista, pnlVolantesPago, pnlDeduccionesEmpleado, pnlAsignacionesEmpleado })
                { item.Top = y; item.Visible = true; y += 28; }
            }
            else
            {
                foreach (var item in new[] { pnlVolantesLista, pnlVolantesPago, pnlDeduccionesEmpleado, pnlAsignacionesEmpleado })
                    item.Visible = false;
            }
        }

        // ════════════════════════════════════════════════════════════════════
        //  ITEMS DEL SIDEBAR
        // ════════════════════════════════════════════════════════════════════
        private void ConfigurarItem(Panel item, Panel barra, Label bullet, Label lbl, string tag)
        {
            item.MouseEnter += (s, e) => { if (item != _itemActivo) item.BackColor = Color.FromArgb(20, 30, 58); };
            item.MouseLeave += (s, e) => { if (item != _itemActivo) item.BackColor = Color.Transparent; };

            Action onClick = () => Item_Click(item, barra, bullet, lbl, tag);
            item.Click += (s, e) => onClick();
            lbl.Click += (s, e) => onClick();
            bullet.Click += (s, e) => onClick();
        }

        private void Item_Click(Panel item, Panel barra, Label bullet, Label lbl, string tag)
        {
            if (_itemActivo != null)
            {
                _itemActivo.BackColor = Color.Transparent;
                foreach (Control c in _itemActivo.Controls)
                {
                    if (c is Panel bar) bar.BackColor = Color.Transparent;
                    if (c is Label l)
                    {
                        l.ForeColor = l.Text == "●" ? ColorSubTexto : ColorTexto;
                        l.Font = new Font("Segoe UI", l.Text == "●" ? 7f : 9f);
                    }
                }
            }

            _itemActivo = item;
            item.BackColor = ColorItemActivo;
            barra.BackColor = ColorCyan;
            bullet.ForeColor = ColorCyan;
            lbl.ForeColor = ColorCyan;
            lbl.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            AbrirModulo(tag);
        }

        // ════════════════════════════════════════════════════════════════════
        //  MÓDULOS
        // ════════════════════════════════════════════════════════════════════
        private void MostrarBienvenida()
        {
            foreach (Control c in pnlContenido.Controls)
                if (c is Form) { c.Dispose(); }

            pnlContenido.Controls.Clear();
            pnlContenido.Controls.Add(picLogoBienvenida);
            pnlContenido.Controls.Add(lblBienvenida);
            pnlContenido.Controls.Add(lblSubBienvenida);
        }

        private void AbrirModulo(string tag)
        {
            foreach (Control c in pnlContenido.Controls)
                if (c is Form f) f.Dispose();
            pnlContenido.Controls.Clear();

            Form frm = null;
            switch (tag)
            {
                // Tab Entrada
                case "Departamentos": frm = new FrmDepartamentos(); break;
                case "Posiciones": frm = new FrmPosiciones(); break;
                case "Deducciones": frm = new FrmDeducciones(); break;
                case "Asignaciones": frm = new FrmAsignaciones(); break;
                case "Empleados": frm = new FrmEmpleados(); break;
                case "Asistencias": frm = new FrmAsistencias(); break;
                case "AccesoSistema": frm = new FrmAccesoSistema(); break;
                // Tab Nómina
                case "VolantesLista": frm = new FrmVolantesLista(); break;  // Volantes de Pago
                case "VolantesPago": frm = new FrmVolantesPago(); break;  // Sueldo Neto
                case "DeduccionesEmpleado": frm = new FrmDeduccionesEmpleado(); break;
                case "AsignacionesEmpleado": frm = new FrmAsignacionesEmpleado(); break;
                default: MostrarBienvenida(); return;
            }

            if (frm != null)
            {
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                frm.BackColor = ColorFondo;
                pnlContenido.Controls.Add(frm);
                frm.Show();
            }
        }

        // ════════════════════════════════════════════════════════════════════
        //  HELPERS
        // ════════════════════════════════════════════════════════════════════
        private void IniciarReloj()
        {
            _timer = new Timer { Interval = 1000 };
            _timer.Tick += (s, e) => lblHora.Text = DateTime.Now.ToString("h:mm:ss tt");
            _timer.Start();
        }

        private Region CrearRegionCircular(int size)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, size, size);
            return new Region(path);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _timer?.Stop();
            base.OnFormClosed(e);
        }

        private void FrmPrincipal_Load(object sender, EventArgs e) { }
    }
}