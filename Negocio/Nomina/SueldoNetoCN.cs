using Datos.Repositorios.Nomina;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Negocios.Nomina
{
    /// <summary>
    /// Capa de negocio para SalarioST (sueldo neto antes de deducciones).
    /// Usada por FrmVolantesPago y FrmDetalleVolante.
    /// </summary>
    public class SueldoNetoCN
    {
        private readonly SueldoNetoCD _cd = new SueldoNetoCD();

        // ─── Obtener ──────────────────────────────────────────────────────
        public DataTable ObtenerTodos()
            => _cd.ObtenerTodos();

        public async Task<DataTable> ObtenerTodosAsync()
            => await _cd.ObtenerTodosAsync();

        public DataTable ObtenerPorEmpleado(int idEmpleado)
        {
            if (idEmpleado <= 0)
                throw new ArgumentException("Id de empleado inválido.", nameof(idEmpleado));
            return _cd.ObtenerPorEmpleado(idEmpleado);
        }

        public DataTable ObtenerPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id inválido.", nameof(id));
            return _cd.ObtenerPorId(id);
        }

        /// <summary>
        /// Devuelve TotalDeducciones y SalarioNeto para un empleado en una fecha.
        /// Usado por FrmDetalleVolante.
        /// </summary>
        public DataTable ObtenerVolanteCompleto(int idEmpleado, DateTime fecha)
        {
            try { return _cd.ObtenerVolanteCompleto(idEmpleado, fecha); }
            catch { return new DataTable(); }
        }
    }
}
