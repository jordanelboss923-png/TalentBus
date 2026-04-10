using Negocios.Seguridad;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmLogin : Form
    {
        /// Instancia de la capa de negocios
        private readonly LogginCN _cn = new LogginCN();

        // Variable para controlar si la contraseña se muestra o no
        private bool _mostrandoClave = false;

        // Colores personalizados
        private readonly Color ColorCyan = Color.FromArgb(0, 210, 230);
        private readonly Color ColorSubTexto = Color.FromArgb(130, 150, 190);
        private readonly Color ColorBoton = Color.FromArgb(0, 210, 230);
        private readonly Color ColorBotonTexto = Color.FromArgb(13, 17, 35);
        private readonly Color ColorBorde = Color.FromArgb(0, 210, 230);
        private readonly Color ColorInput = Color.FromArgb(25, 35, 65);


        public FrmLogin()
        {

            InitializeComponent();
            AplicarEstilosYEventos(); // Configura estilos y eventos personalizados
        }

        //Metodo para configurar estilos personalizados y eventos de la interfaz
        private void AplicarEstilosYEventos()
        {
            // Arrastrar ventana sin barra de título
            this.MouseDown += (s, e) => {
                if (e.Button == MouseButtons.Left)
                {
                    NativeMethods.ReleaseCapture(); // Libera el mouse para permitir el arrastre
                    NativeMethods.SendMessage(this.Handle, 0xA1, 0x2, 0); // Envía mensaje para iniciar arrastre de ventana
                }
            };

            // Bordes redondeados en botones
            btnIngresar.Region = CrearRegionRedondeada(btnIngresar.Size, 8);
            btnCerrar.Region = CrearRegionRedondeada(btnCerrar.Size, 7);
            btnMin.Region = CrearRegionRedondeada(btnMin.Size, 7);
            btnVerde.Region = CrearRegionRedondeada(btnVerde.Size, 7);

            // Eventos de botones de ventana (hover y click)
            btnCerrar.Click += (s, e) => Application.Exit();
            btnMin.Click += (s, e) => this.WindowState = FormWindowState.Minimized;

            // Estilos personalizados para el botón ingresar y su hover 
            btnIngresar.MouseEnter += (s, e) => btnIngresar.BackColor = Color.FromArgb(0, 180, 200);
            btnIngresar.MouseLeave += (s, e) => btnIngresar.BackColor = ColorBoton;

   

            // Borde de los paneles input (se dibuja en Paint) 
            pnlUser.Paint += (s, e) => DibujarBordePanel(e, pnlUser);
            pnlPass.Paint += (s, e) => DibujarBordePanel(e, pnlPass);

            // Borde redondeado del card
            pnlCard.Paint += PnlCard_Paint;

           

            // Placeholder usuario
            AplicarPlaceholder(pnlUser, txtUsuario, lblPlaceholderUser);

            // Placeholder contraseña
            AplicarPlaceholder(pnlPass, txtClave, lblPlaceholderPass);

            // Botón mostrar/ocultar contraseña
            btnMostrar.Click += BtnMostrar_Click;

            // Tecla Enter navega entre campos
            txtUsuario.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) txtClave.Focus(); };
            txtClave.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) BtnIngresar_Click(s, e); };

            // Botón ingresar
            btnIngresar.Click += BtnIngresar_Click;
        }

        // Método para dibujar el borde de los paneles de input (pnlUser y pnlPass) 
        private void DibujarBordePanel(PaintEventArgs e, Panel pnl)
        {
            using (Pen p = new Pen(ColorBorde, 1))
                e.Graphics.DrawRectangle(p, 0, 0, pnl.Width - 1, pnl.Height - 1);
        }

        // Método para aplicar el efecto placeholder a los TextBox de usuario y contraseña
        private void AplicarPlaceholder(Panel pnl, TextBox txt, Label lbl)
        {
            txt.GotFocus += (s, e) => lbl.Visible = false;
            txt.LostFocus += (s, e) => lbl.Visible = string.IsNullOrEmpty(txt.Text);
            txt.TextChanged += (s, e) => lbl.Visible = string.IsNullOrEmpty(txt.Text);
            lbl.Click += (s, e) => txt.Focus();
            lbl.BringToFront();
        }

        // Método para crear una región con bordes redondeados, utilizado para los botones y el card
        private Region CrearRegionRedondeada(Size size, int radio)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radio * 2, radio * 2, 180, 90);
            path.AddArc(size.Width - radio * 2, 0, radio * 2, radio * 2, 270, 90);
            path.AddArc(size.Width - radio * 2, size.Height - radio * 2, radio * 2, radio * 2, 0, 90);
            path.AddArc(0, size.Height - radio * 2, radio * 2, radio * 2, 90, 90);
            path.CloseAllFigures();
            return new Region(path);
        }

        // Método para dibujar el borde redondeado del card (pnlCard) en su evento Paint
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

        
        // Método para mostrar u ocultar la contraseña al hacer clic en el botón btnMostrar
        private void BtnMostrar_Click(object sender, EventArgs e)
        {
            _mostrandoClave = !_mostrandoClave; // Alterna el estado de mostrar/ocultar contraseña
            txtClave.UseSystemPasswordChar = !_mostrandoClave; // Cambia el modo de visualización del TextBox de contraseña
            btnMostrar.ForeColor = _mostrandoClave ? ColorCyan : ColorSubTexto; // Cambia el color del botón según el estado
        }

        public string UsuarioAutenticado { get; private set; }

        // Método para validar el acceso al hacer clic en el botón btnIngresar
        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            string usuario = txtUsuario.Text.Trim();
            string clave = txtClave.Text;

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(clave))
            {
                lblError.Text = "Por favor completa todos los campos.";
                return;
            }

            try
            {
                bool acceso = _cn.ValidarAcceso(usuario, clave);
                if (acceso)
                {
                    UsuarioAutenticado = usuario;   // Guarda el usuario
                    this.DialogResult = DialogResult.OK;  // Cierra el login con resultado OK
                    this.Close();                   // Cierra definitivamente el form
                }
                else
                {
                    lblError.Text = "Usuario o contraseña incorrectos.";
                    txtClave.Clear();
                    txtUsuario.Focus();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error de conexión: " + ex.Message;
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e) { }

        private void FrmLogin_Load_1(object sender, EventArgs e)
        {

        }
    }

    // Clase para métodos nativos de Windows, utilizada para permitir el arrastre de la ventana sin barra de título

    internal static class NativeMethods
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")] // Importa la función ReleaseCapture de la biblioteca user32.dll para liberar el mouse
        public static extern bool ReleaseCapture(); // Permite que la ventana capture el mouse para iniciar el arrastre

        [System.Runtime.InteropServices.DllImport("user32.dll")] // Importa la función SendMessage de la biblioteca user32.dll para enviar mensajes a la ventana
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam); // Envía un mensaje a la ventana para iniciar el arrastre (0xA1 = WM_NCLBUTTONDOWN, 0x2 = HTCAPTION)
    }
}