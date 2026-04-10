using Negocio.Configuracion;
using Negocios.Seguridad;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmPrincipal : Form
    {
        // Colores personalizados para la interfaz 
        private readonly Color ColorFondo = Color.FromArgb(13, 17, 35);
        private readonly Color ColorCyan = Color.FromArgb(0, 210, 230);
        private readonly Color ColorTexto = Color.White;
        private readonly Color ColorSubTexto = Color.FromArgb(130, 150, 190);
        private readonly Color ColorItemActivo = Color.FromArgb(25, 35, 70);
        private readonly Color ColorBorde = Color.FromArgb(30, 40, 80);

        // Variables para controlar estado de la interfaz
        private string _usuarioActual;
        private Panel _itemActivo;
        private Button _tabActiva;
        private Timer _timer;

        
        public FrmPrincipal(string usuario)
        {
            InitializeComponent(); 
            _usuarioActual = usuario; // Guardar usuario para mostrar en bienvenida y controlar permisos
            ConfigurarEventos(); // Configura eventos personalizados para la interfaz
            IniciarReloj(); // Inicia el reloj para mostrar la hora actual en la barra de estado
        }

        // Configura eventos personalizados para la interfaz, como arrastre de ventana, clicks en botones y tabs, hover en items del sidebar, etc.
        private void ConfigurarEventos()
        {
            // Arrastrar ventana
            this.MouseDown += (s, e) => {
                if (e.Button == MouseButtons.Left && e.Y < 50)
                {
                    NativeMethods.ReleaseCapture();
                    NativeMethods.SendMessage(this.Handle, 0xA1, 0x2, 0);
                }
            };

            // Bordes redondeados en botones macOS
            btnCerrar.Region = CrearRegionCircular(14);
            btnMinimizar.Region = CrearRegionCircular(14);
            btnVerde.Region = CrearRegionCircular(14);
            pnlPuntito.Region = new Region(new RectangleF(0, 0, 8, 8));

            // Clicks botones ventana
            btnCerrar.Click += (s, e) => Application.Exit();
            btnMinimizar.Click += (s, e) => this.WindowState = FormWindowState.Minimized;

            // Tabs — Paint y Click
            _tabActiva = btnTabEntrada;
            foreach (Button btn in new[] { btnTabEntrada, btnTabNomina, btnTabConsulta })
            {
                btn.Paint += Tab_Paint;
                btn.Click += Tab_Click;
                btn.MouseEnter += (s, e) => { if ((Button)s != _tabActiva) ((Button)s).ForeColor = ColorTexto; };
                btn.MouseLeave += (s, e) => { if ((Button)s != _tabActiva) ((Button)s).ForeColor = ColorSubTexto; };
            }

            // Salir
            btnSalir.Click += (s, e) => {
                if (MessageBox.Show("¿Deseas cerrar sesión?", "Salir",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    new FrmLogin().Show();
                    this.Close();
                }
            };

            // Header — borde inferior
            pnlHeader.Paint += (s, e) => {
                using (Pen p = new Pen(ColorBorde, 1))
                    e.Graphics.DrawLine(p, 0, pnlHeader.Height - 1,
                                           pnlHeader.Width, pnlHeader.Height - 1);
            };

            // Sidebar — borde derecho
            pnlSidebar.Paint += (s, e) => {
                using (Pen p = new Pen(ColorBorde, 1))
                    e.Graphics.DrawLine(p, pnlSidebar.Width - 1, 0,
                                           pnlSidebar.Width - 1, pnlSidebar.Height);
            };

            // StatusBar — borde superior
            pnlStatusBar.Paint += (s, e) => {
                using (Pen p = new Pen(ColorBorde, 1))
                    e.Graphics.DrawLine(p, 0, 0, pnlStatusBar.Width, 0);
            };

            

            // Items del sidebar 
            _itemActivo = pnlEmpleados;
            ConfigurarItem(pnlDepartamentos, barDepartamentos, bulletDepartamentos, lblDepartamentos, "Departamentos");
            ConfigurarItem(pnlPosiciones, barPosiciones, bulletPosiciones, lblPosiciones, "Posiciones");
            ConfigurarItem(pnlDeducciones, barDeducciones, bulletDeducciones, lblDeducciones, "Deducciones");
            ConfigurarItem(pnlAsignaciones, barAsignaciones, bulletAsignaciones, lblAsignaciones, "Asignaciones");
            ConfigurarItem(pnlEmpleados, barEmpleados, bulletEmpleados, lblEmpleados, "Empleados");
            ConfigurarItem(pnlAsistencias, barAsistencias, bulletAsistencias, lblAsistencias, "Asistencias");
            ConfigurarItem(pnlAccesoSistema, barAccesoSistema, bulletAccesoSistema, lblAccesoSistema, "AccesoSistema");
        }

        // Configura eventos de hover y click para un item del sidebar, recibiendo sus controles relacionados
        // (barra lateral, bullet y label) y el tag que identifica el módulo a abrir
        private void ConfigurarItem(Panel item, Panel barra, Label bullet, Label lbl, string tag)
        {
            item.MouseEnter += (s, e) => { if (item != _itemActivo) item.BackColor = Color.FromArgb(20, 30, 58); };
            item.MouseLeave += (s, e) => { if (item != _itemActivo) item.BackColor = Color.Transparent; };

            Action onClick = () => Item_Click(item, barra, bullet, lbl, tag);
            item.Click += (s, e) => onClick();
            lbl.Click += (s, e) => onClick();
            bullet.Click += (s, e) => onClick();
        }

        // Evento click para las tabs principales, cambia la tab activa y muestra la pantalla de bienvenida
        private void Tab_Click(object sender, EventArgs e)
        {
            _tabActiva = (Button)sender;

            foreach (Button btn in new[] { btnTabEntrada, btnTabNomina, btnTabConsulta })
                btn.ForeColor = ColorSubTexto;

            _tabActiva.ForeColor = ColorTexto;
            _tabActiva.Invalidate();
            MostrarBienvenida();
        }

        // Evento Paint para las tabs, dibuja una línea inferior si es la tab activa
        private void Tab_Paint(object sender, PaintEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn == _tabActiva)
            {
                using (Pen p = new Pen(ColorCyan, 2))
                    e.Graphics.DrawLine(p, 0, btn.Height - 2, btn.Width, btn.Height - 2);
            }
        }

        // Evento click para los items del sidebar, desactiva el item anterior, activa el nuevo y abre el módulo correspondiente
        private void Item_Click(Panel item, Panel barra, Label bullet, Label lbl, string tag)
        {
            // Desactivar anterior
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

            // Activar nuevo
            _itemActivo = item;
            item.BackColor = ColorItemActivo;
            barra.BackColor = ColorCyan;
            bullet.ForeColor = ColorCyan;
            lbl.ForeColor = ColorCyan;
            lbl.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            AbrirModulo(tag);
        }

        // Muestra la pantalla de bienvenida, limpiando cualquier sub-formulario abierto y dejando visibles solo los controles estáticos de bienvenida
        private void MostrarBienvenida()
        {
            // Limpiar sub-formularios, dejar visibles solo los controles estáticos
            foreach (Control c in pnlContenido.Controls)
                if (c is Form) { c.Dispose(); }

            pnlContenido.Controls.Clear();
            pnlContenido.Controls.Add(picLogoBienvenida);
            pnlContenido.Controls.Add(lblBienvenida);
            pnlContenido.Controls.Add(lblSubBienvenida);
        }

        // Abre el módulo correspondiente al tag recibido, creando una instancia del formulario asociado, configurándolo como hijo del panel de contenido y mostrándolo
        private void AbrirModulo(string tag)
        {
            // Limpiar contenido anterior
            foreach (Control c in pnlContenido.Controls)
                if (c is Form f) f.Dispose();
            pnlContenido.Controls.Clear();

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
                pnlContenido.Controls.Add(frm);
                frm.Show();
            }
        }

        // Inicia un timer que actualiza la hora en la barra de estado cada segundo
        private void IniciarReloj()
        {
            _timer = new Timer { Interval = 1000 };
            _timer.Tick += (s, e) => lblHora.Text = DateTime.Now.ToString("h:mm:ss tt");
            _timer.Start();
        }

        // Crea una región circular para aplicar a los botones de ventana, recibiendo el tamaño del botón
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