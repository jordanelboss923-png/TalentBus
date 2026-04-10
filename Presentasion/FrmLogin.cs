using Negocios.Seguridad;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmLogin : Form
    {
        private readonly LogginCN _cn = new LogginCN();

        // ─── Colores del tema ───
        private readonly Color ColorFondo = Color.FromArgb(13, 17, 35);
        private readonly Color ColorPanel = Color.FromArgb(18, 24, 48);
        private readonly Color ColorBorde = Color.FromArgb(0, 210, 230);
        private readonly Color ColorCyan = Color.FromArgb(0, 210, 230);
        private readonly Color ColorTexto = Color.White;
        private readonly Color ColorSubTexto = Color.FromArgb(130, 150, 190);
        private readonly Color ColorInput = Color.FromArgb(25, 35, 65);
        private readonly Color ColorBoton = Color.FromArgb(0, 210, 230);
        private readonly Color ColorBotonTexto = Color.FromArgb(13, 17, 35);

        // ─── Controles ───
        private Panel pnlCard;
        private PictureBox picLogo;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Label lblUsuario;
        private Label lblClave;
        private TextBox txtUsuario;
        private TextBox txtClave;
        private Label lblPlaceholderUser;
        private Label lblPlaceholderPass;
        private Button btnMostrar;
        private Button btnIngresar;
        private Label lblOlvide;
        private Label lblError;
        private bool _mostrandoClave = false;

        public FrmLogin()
        {
            InitializeComponent();
            ConfigurarFormulario();
            ConstruirUI();
        }

        // ════════════════════════════════════════
        //  CONFIGURACIÓN GENERAL
        // ════════════════════════════════════════
        private void ConfigurarFormulario()
        {
            this.Text = "TalentBus — Iniciar Sesión";
            this.Size = new Size(420, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = ColorFondo;
            this.DoubleBuffered = true;

            // Arrastrar ventana sin barra
            this.MouseDown += (s, e) => {
                if (e.Button == MouseButtons.Left)
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
            // ── Botones de ventana (●●●) ─────────
            AgregarBotonesVentana();

            // ── Card central ─────────────────────
            pnlCard = new Panel
            {
                Size = new Size(340, 480),
                BackColor = ColorPanel,
                Location = new Point(40, 60)
            };
            pnlCard.Paint += PnlCard_Paint;
            this.Controls.Add(pnlCard);

            // ── Logo ─────────────────────────────
            picLogo = new PictureBox
            {
                Size = new Size(80, 80),
                Location = new Point(130, 30),
                BackColor = Color.Transparent
            };
            picLogo.Paint += PicLogo_Paint;
            pnlCard.Controls.Add(picLogo);

            // ── Título ───────────────────────────
            lblTitulo = new Label
            {
                Text = "TALENTBUS DB3",
                ForeColor = ColorCyan,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                AutoSize = false,
                Size = new Size(300, 28),
                Location = new Point(20, 120),
                TextAlign = ContentAlignment.MiddleCenter
            };
            pnlCard.Controls.Add(lblTitulo);

            lblSubtitulo = new Label
            {
                Text = "Sistema de Nómina",
                ForeColor = ColorSubTexto,
                Font = new Font("Segoe UI", 9),
                AutoSize = false,
                Size = new Size(300, 20),
                Location = new Point(20, 148),
                TextAlign = ContentAlignment.MiddleCenter
            };
            pnlCard.Controls.Add(lblSubtitulo);

            // ── Label Usuario ────────────────────
            lblUsuario = new Label
            {
                Text = "Usuario",
                ForeColor = ColorTexto,
                Font = new Font("Segoe UI", 9),
                AutoSize = true,
                Location = new Point(30, 190)
            };
            pnlCard.Controls.Add(lblUsuario);

            // ── Input Usuario ─────────────────────
            Panel pnlUser = CrearPanelInput(30, 210, out txtUsuario, false);
            lblPlaceholderUser = CrearPlaceholder(pnlUser, "CodigoEmpleado");
            pnlCard.Controls.Add(pnlUser);

            // ── Label Clave ──────────────────────
            lblClave = new Label
            {
                Text = "Contraseña",
                ForeColor = ColorTexto,
                Font = new Font("Segoe UI", 9),
                AutoSize = true,
                Location = new Point(30, 280)
            };
            pnlCard.Controls.Add(lblClave);

            // ── Input Clave ───────────────────────
            Panel pnlPass = CrearPanelInput(30, 300, out txtClave, true);
            lblPlaceholderPass = CrearPlaceholder(pnlPass, "••••••");

            // Botón ojo
            btnMostrar = new Button
            {
                Size = new Size(30, 30),
                Location = new Point(238, 5),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                ForeColor = ColorSubTexto,
                Text = "👁",
                Font = new Font("Segoe UI", 11),
                Cursor = Cursors.Hand
            };
            btnMostrar.FlatAppearance.BorderSize = 0;
            btnMostrar.Click += BtnMostrar_Click;
            pnlPass.Controls.Add(btnMostrar);

            pnlCard.Controls.Add(pnlPass);

            // ── Mensaje de error ──────────────────
            lblError = new Label
            {
                Text = "",
                ForeColor = Color.FromArgb(255, 80, 80),
                Font = new Font("Segoe UI", 8),
                AutoSize = false,
                Size = new Size(280, 20),
                Location = new Point(30, 355),
                TextAlign = ContentAlignment.MiddleCenter
            };
            pnlCard.Controls.Add(lblError);

            // ── Botón Ingresar ────────────────────
            btnIngresar = new Button
            {
                Text = "INGRESAR",
                Size = new Size(280, 44),
                Location = new Point(30, 375),
                FlatStyle = FlatStyle.Flat,
                BackColor = ColorBoton,
                ForeColor = ColorBotonTexto,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.Region = CrearRegionRedondeada(btnIngresar.Size, 8);
            btnIngresar.Click += BtnIngresar_Click;
            btnIngresar.MouseEnter += (s, e) => btnIngresar.BackColor = Color.FromArgb(0, 180, 200);
            btnIngresar.MouseLeave += (s, e) => btnIngresar.BackColor = ColorBoton;
            pnlCard.Controls.Add(btnIngresar);

            // ── ¿Olvidaste tu contraseña? ─────────
            lblOlvide = new Label
            {
                Text = "¿Olvidaste tu contraseña?",
                ForeColor = ColorSubTexto,
                Font = new Font("Segoe UI", 9, FontStyle.Underline),
                AutoSize = true,
                Location = new Point(95, 432),
                Cursor = Cursors.Hand
            };
            lblOlvide.MouseEnter += (s, e) => lblOlvide.ForeColor = ColorCyan;
            lblOlvide.MouseLeave += (s, e) => lblOlvide.ForeColor = ColorSubTexto;
            pnlCard.Controls.Add(lblOlvide);

            // Evento Enter en campos
            txtUsuario.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) txtClave.Focus(); };
            txtClave.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) BtnIngresar_Click(s, e); };
        }

        // ════════════════════════════════════════
        //  HELPERS DE UI
        // ════════════════════════════════════════
        private Panel CrearPanelInput(int x, int y, out TextBox txt, bool esPassword)
        {
            Panel pnl = new Panel
            {
                Size = new Size(280, 40),
                Location = new Point(x, y),
                BackColor = ColorInput
            };
            pnl.Paint += (s, e) =>
            {
                using (Pen p = new Pen(ColorBorde, 1))
                    e.Graphics.DrawRectangle(p, 0, 0, pnl.Width - 1, pnl.Height - 1);
            };

            txt = new TextBox
            {
                Size = new Size(200, 24),
                Location = new Point(10, 8),
                BackColor = ColorInput,
                ForeColor = ColorTexto,
                BorderStyle = BorderStyle.None,
                Font = new Font("Segoe UI", 10),
                UseSystemPasswordChar = esPassword
            };

            pnl.Controls.Add(txt);
            return pnl;
        }

        private Label CrearPlaceholder(Panel pnl, string texto)
        {
            Label lbl = new Label
            {
                Text = texto,
                ForeColor = ColorSubTexto,
                Font = new Font("Segoe UI", 9),
                AutoSize = true,
                Location = new Point(12, 11),
                BackColor = Color.Transparent
            };

            TextBox txt = null;
            foreach (Control c in pnl.Controls)
                if (c is TextBox t) { txt = t; break; }

            if (txt != null)
            {
                txt.GotFocus += (s, e) => lbl.Visible = false;
                txt.LostFocus += (s, e) => lbl.Visible = string.IsNullOrEmpty(txt.Text);
                txt.TextChanged += (s, e) => lbl.Visible = string.IsNullOrEmpty(txt.Text);
            }

            pnl.Controls.Add(lbl);
            lbl.BringToFront();
            lbl.Click += (s, e) => txt?.Focus();
            return lbl;
        }

        private void AgregarBotonesVentana()
        {
            // Botón cerrar
            Button btnCerrar = new Button
            {
                Size = new Size(14, 14),
                Location = new Point(16, 20),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(255, 95, 86),
                Cursor = Cursors.Hand,
                Text = ""
            };
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.Region = CrearRegionRedondeada(btnCerrar.Size, 7);
            btnCerrar.Click += (s, e) => Application.Exit();
            this.Controls.Add(btnCerrar);

            // Botón minimizar
            Button btnMin = new Button
            {
                Size = new Size(14, 14),
                Location = new Point(36, 20),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(255, 189, 46),
                Cursor = Cursors.Hand,
                Text = ""
            };
            btnMin.FlatAppearance.BorderSize = 0;
            btnMin.Region = CrearRegionRedondeada(btnMin.Size, 7);
            btnMin.Click += (s, e) => this.WindowState = FormWindowState.Minimized;
            this.Controls.Add(btnMin);

            // Botón verde (decorativo)
            Button btnVerde = new Button
            {
                Size = new Size(14, 14),
                Location = new Point(56, 20),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(39, 201, 63),
                Cursor = Cursors.Hand,
                Text = ""
            };
            btnVerde.FlatAppearance.BorderSize = 0;
            btnVerde.Region = CrearRegionRedondeada(btnVerde.Size, 7);
            this.Controls.Add(btnVerde);
        }

        private Region CrearRegionRedondeada(Size size, int radio)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radio * 2, radio * 2, 180, 90);
            path.AddArc(size.Width - radio * 2, 0, radio * 2, radio * 2, 270, 90);
            path.AddArc(size.Width - radio * 2, size.Height - radio * 2, radio * 2, radio * 2, 0, 90);
            path.AddArc(0, size.Height - radio * 2, radio * 2, radio * 2, 90, 90);
            path.CloseAllFigures();
            return new Region(path);
        }

        // ════════════════════════════════════════
        //  PAINT EVENTS
        // ════════════════════════════════════════
        private void PnlCard_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen p = new Pen(ColorBorde, 1))
            {
                GraphicsPath path = new GraphicsPath();
                int r = 12;
                path.AddArc(0, 0, r * 2, r * 2, 180, 90);
                path.AddArc(pnlCard.Width - r * 2, 0, r * 2, r * 2, 270, 90);
                path.AddArc(pnlCard.Width - r * 2, pnlCard.Height - r * 2, r * 2, r * 2, 0, 90);
                path.AddArc(0, pnlCard.Height - r * 2, r * 2, r * 2, 90, 90);
                path.CloseAllFigures();
                e.Graphics.DrawPath(p, path);
            }
        }

        private void PicLogo_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Círculo exterior
            using (Pen p = new Pen(ColorCyan, 2))
                e.Graphics.DrawEllipse(p, 2, 2, 74, 74);

            // Círculo interior
            using (SolidBrush b = new SolidBrush(Color.FromArgb(20, 30, 60)))
                e.Graphics.FillEllipse(b, 10, 10, 58, 58);

            // Estrella
            DibujarEstrella(e.Graphics, 40, 40, 20, 10, 5, ColorCyan);
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

        // ════════════════════════════════════════
        //  EVENTOS
        // ════════════════════════════════════════
        private void BtnMostrar_Click(object sender, EventArgs e)
        {
            _mostrandoClave = !_mostrandoClave;
            txtClave.UseSystemPasswordChar = !_mostrandoClave;
            btnMostrar.ForeColor = _mostrandoClave ? ColorCyan : ColorSubTexto;
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            string usuario = txtUsuario.Text.Trim();
            string clave = txtClave.Text;

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(clave))
            {
                MostrarError("Por favor completa todos los campos.");
                return;
            }

            try
            {
                bool acceso = _cn.ValidarAcceso(usuario, clave);

                if (acceso)
                {
                    FrmPrincipal principal = new FrmPrincipal(usuario);
                    principal.Show();
                    this.Hide();
                }
                else
                {
                    MostrarError("Usuario o contraseña incorrectos.");
                    txtClave.Clear();
                    txtUsuario.Focus();
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error de conexión: " + ex.Message);
            }
        }

        private void MostrarError(string mensaje)
        {
            lblError.Text = mensaje;
        }
    }

    // ════════════════════════════════════════
    //  NATIVE METHODS (arrastrar ventana)
    // ════════════════════════════════════════
    internal static class NativeMethods
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
    }
}
