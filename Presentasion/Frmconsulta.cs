using Negocio.Asistencia;
using Negocio.Configuracion;
using Negocio.Servicios;
using Negocios;
using Negocios.Empleados;
using Negocios.Nomina;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Presentacion
{
    /// <summary>
    /// Formulario de Consulta (Requisito #8 y #11).
    /// Permite visualizar los datos guardados en todas las tablas del sistema.
    /// Solo lectura — no permite insertar ni modificar.
    /// </summary>
    public partial class FrmConsulta : Form
    {
        // ─── Colores ───────────────────────────────────────────────────────
        private readonly Color ColorFondo = Color.FromArgb(13, 17, 35);
        private readonly Color ColorPanel = Color.FromArgb(18, 24, 48);
        private readonly Color ColorCyan = Color.FromArgb(0, 210, 230);
        private readonly Color ColorTexto = Color.White;
        private readonly Color ColorSubTexto = Color.FromArgb(130, 150, 190);
        private readonly Color ColorBorde = Color.FromArgb(30, 40, 80);
        private readonly Color ColorEliminar = Color.FromArgb(255, 80, 80);
        private readonly Color ColorVerde = Color.FromArgb(39, 201, 63);
        private readonly Color ColorEditar = Color.FromArgb(30, 80, 180);

        // ─── Capas de negocio ──────────────────────────────────────────────
        private readonly EmpleadosCN _cnEmp = new EmpleadosCN();
        private readonly AsistenciasCN _cnAsi = new AsistenciasCN();
        private readonly DepartamentosCN _cnDep = new DepartamentosCN();
        private readonly PosicionesCN _cnPos = new PosicionesCN();
        private readonly DeduccionesCN _cnDed = new DeduccionesCN();
        private readonly AsignacionesCN _cnAsig = new AsignacionesCN();
        private readonly AsignacionesEmpleadoCN _cnAE = new AsignacionesEmpleadoCN();
        private readonly DeduccionesEmpleadoCN _cnDE = new DeduccionesEmpleadoCN();
        private readonly SueldoNetoCN _cnSN = new SueldoNetoCN();
        private readonly VolantesPagoCN _cnVP = new VolantesPagoCN();

        public FrmConsulta()
        {
            InitializeComponent();
            ConfigurarEventos();
            CargarOpcionesConsulta();
        }

        // ══════════════════════════════════════════════════════════════════
        //  CONFIGURACIÓN
        // ══════════════════════════════════════════════════════════════════
        private void ConfigurarEventos()
        {
            pnlFiltro.Paint += PnlBorde_Paint;

            btnConsultar.Click += BtnConsultar_Click;
            cmbTabla.SelectedIndexChanged += (s, e) => lblConteo.Text = "";

            ConfigurarHover(btnConsultar, ColorEditar, Color.FromArgb(40, 100, 210));

            btnConsultar.Region = CrearRegionRedondeada(btnConsultar.Size, 6);
            btnConsultar.SizeChanged += (s, e) =>
                btnConsultar.Region = CrearRegionRedondeada(btnConsultar.Size, 6);
        }

        private void CargarOpcionesConsulta()
        {
            // Opciones de consulta disponibles — valor = tag interno
            cmbTabla.Items.Clear();
            cmbTabla.Items.Add("Empleados");
            cmbTabla.Items.Add("Asistencias");
            cmbTabla.Items.Add("Departamentos");
            cmbTabla.Items.Add("Posiciones");
            cmbTabla.Items.Add("Deducciones");
            cmbTabla.Items.Add("Asignaciones");
            cmbTabla.Items.Add("Asignaciones de Empleados");
            cmbTabla.Items.Add("Deducciones de Empleados");
            cmbTabla.Items.Add("Sueldo Neto (SalarioST)");
            cmbTabla.Items.Add("Volantes de Pago");
            cmbTabla.SelectedIndex = 0;
        }

        private void ConfigurarHover(Button btn, Color normal, Color hover)
        {
            btn.BackColor = normal;
            btn.MouseEnter += (s, e) => btn.BackColor = hover;
            btn.MouseLeave += (s, e) => btn.BackColor = normal;
        }

        // ══════════════════════════════════════════════════════════════════
        //  CONSULTA
        // ══════════════════════════════════════════════════════════════════
        private async void BtnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                btnConsultar.Enabled = false;
                lblConteo.Text = "Consultando...";
                lblConteo.ForeColor = ColorSubTexto;

                DataTable dt = null;

                // Cada opción consulta su CN correspondiente (solo lectura)
                switch (cmbTabla.SelectedItem?.ToString())
                {
                    case "Empleados":
                        dt = _cnEmp.ObtenerTodos();
                        break;
                    case "Asistencias":
                        dt = await _cnAsi.ObtenerTodosAsync();
                        break;
                    case "Departamentos":
                        dt = _cnDep.ObtenerTodos();
                        break;
                    case "Posiciones":
                        dt = _cnPos.ObtenerTodos();
                        break;
                    case "Deducciones":
                        dt = _cnDed.ObtenerTodos();
                        break;
                    case "Asignaciones":
                        dt = _cnAsig.ObtenerTodos();
                        break;
                    case "Asignaciones de Empleados":
                        dt = await _cnAE.ObtenerTodosAsync();
                        break;
                    case "Deducciones de Empleados":
                        dt = await _cnDE.ObtenerTodosAsync();
                        break;
                    case "Sueldo Neto (SalarioST)":
                        dt = _cnSN.ObtenerTodos();
                        break;
                    case "Volantes de Pago":
                        dt = _cnVP.ObtenerTodos();
                        break;
                    default:
                        lblConteo.Text = "Selecciona una opción.";
                        lblConteo.ForeColor = ColorEliminar;
                        return;
                }

                // Mostrar resultados en el grid
                dgvResultados.DataSource = null;
                dgvResultados.DataSource = dt;

                // Formatear columnas de fecha y montos automáticamente
                foreach (DataGridViewColumn col in dgvResultados.Columns)
                {
                    if (col.Name.Contains("Fecha"))
                        col.DefaultCellStyle.Format = "dd/MM/yyyy";
                    if (col.Name.Contains("Monto") || col.Name.Contains("Total") ||
                        col.Name.Contains("Sueldo") || col.Name.Contains("Salario") ||
                        col.Name.Contains("Subtotal") || col.Name.Contains("Deduccion"))
                        col.DefaultCellStyle.Format = "N2";
                }

                lblConteo.Text = $"{dt.Rows.Count} registro(s) encontrado(s)";
                lblConteo.ForeColor = ColorCyan;
            }
            catch (Exception ex)
            {
                lblConteo.Text = "✗  Error al consultar: " + ex.Message;
                lblConteo.ForeColor = ColorEliminar;
            }
            finally
            {
                btnConsultar.Enabled = true;
            }
        }

        // ══════════════════════════════════════════════════════════════════
        //  HELPERS
        // ══════════════════════════════════════════════════════════════════
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

        private void PnlBorde_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = (Panel)sender;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen p = new Pen(ColorBorde, 1))
            {
                GraphicsPath path = new GraphicsPath();
                int r = 8;
                path.AddArc(0, 0, r * 2, r * 2, 180, 90);
                path.AddArc(pnl.Width - r * 2, 0, r * 2, r * 2, 270, 90);
                path.AddArc(pnl.Width - r * 2, pnl.Height - r * 2, r * 2, r * 2, 0, 90);
                path.AddArc(0, pnl.Height - r * 2, r * 2, r * 2, 90, 90);
                path.CloseAllFigures();
                e.Graphics.DrawPath(p, path);
            }
        }

        private void FrmConsulta_Load(object sender, EventArgs e) { }
    }
}
