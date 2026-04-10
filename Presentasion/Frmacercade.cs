using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Presentacion
{
    /// <summary>
    /// Muestra información del sistema y los participantes del grupo.
    /// Requisito #9: opción Sistema > Acerca de.
    /// </summary>
    public partial class FrmAcercaDe : Form
    {
        // ─── Colores ───────────────────────────────────────────────────────
        private readonly Color ColorFondo = Color.FromArgb(13, 17, 35);
        private readonly Color ColorPanel = Color.FromArgb(18, 24, 48);
        private readonly Color ColorCyan = Color.FromArgb(0, 210, 230);
        private readonly Color ColorTexto = Color.White;
        private readonly Color ColorSubTexto = Color.FromArgb(130, 150, 190);
        private readonly Color ColorBorde = Color.FromArgb(30, 40, 80);
        private readonly Color ColorEliminar = Color.FromArgb(255, 80, 80);

        public FrmAcercaDe()
        {
            InitializeComponent();
            ConfigurarEventos();
        }

        private void ConfigurarEventos()
        {
            btnCerrar.Click += (s, e) => this.Close();

            btnCerrar.MouseEnter += (s, e) => btnCerrar.BackColor = Color.FromArgb(200, 60, 60);
            btnCerrar.MouseLeave += (s, e) => btnCerrar.BackColor = ColorEliminar;

            pnlCuerpo.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen p = new Pen(ColorBorde, 1))
                {
                    GraphicsPath path = new GraphicsPath();
                    int r = 8;
                    path.AddArc(0, 0, r * 2, r * 2, 180, 90);
                    path.AddArc(pnlCuerpo.Width - r * 2, 0, r * 2, r * 2, 270, 90);
                    path.AddArc(pnlCuerpo.Width - r * 2, pnlCuerpo.Height - r * 2, r * 2, r * 2, 0, 90);
                    path.AddArc(0, pnlCuerpo.Height - r * 2, r * 2, r * 2, 90, 90);
                    path.CloseAllFigures();
                    e.Graphics.DrawPath(p, path);
                }
            };
        }

        private void FrmAcercaDe_Load(object sender, System.EventArgs e) { }
    }
}