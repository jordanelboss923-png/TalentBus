using Datos.Repositorios.Empleados;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Negocios.Empleados
{
    public class AsignacionesEmpleadoCN
    {
        public const int TIPO_MENSUAL = 1;
        public const int TIPO_QUINCENAL = 2;

        private readonly AsignacionesEmpleadoCD _cd = new AsignacionesEmpleadoCD();

        // ─── Obtener ──────────────────────────────────────────────────────
        public DataTable ObtenerTodos()
            => _cd.ObtenerTodos();

        public async Task<DataTable> ObtenerTodosAsync()
            => await _cd.ObtenerTodosAsync();

        public DataTable MostrarAsignaciones()
            => _cd.MostrarAsignaciones();

        public DataTable MostrarEmpleados()
            => _cd.MostrarEmpleados();

        public DataTable ObtenerPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El Id debe ser un valor positivo.", nameof(id));
            return _cd.ObtenerPorId(id);
        }

        public async Task<DataTable> ObtenerPorIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El Id debe ser un valor positivo.", nameof(id));
            return await _cd.ObtenerPorIdAsync(id);
        }

        // ─── Insertar ─────────────────────────────────────────────────────
        // Sin idSubtotal: AsignacionesEmpleado no tiene esa columna.
        // El trigger trg_SalarioST_Calcular crea SalarioST automáticamente.
        public bool Insertar(int idAsignacion, int idEmpleado,
                             int tipo, decimal monto, DateTime fechaEfectividad)
        {
            ValidarCampos(idAsignacion, idEmpleado, tipo, monto, fechaEfectividad);

            _cd.IdAsignacion = idAsignacion;
            _cd.IdEmpleado = idEmpleado;
            _cd.Tipo = tipo;
            _cd.Monto = monto;
            _cd.FechaEfectividad = fechaEfectividad;

            return _cd.Insertar();
        }

        public async Task<bool> InsertarAsync(int idAsignacion, int idEmpleado,
                                              int tipo, decimal monto, DateTime fechaEfectividad)
        {
            ValidarCampos(idAsignacion, idEmpleado, tipo, monto, fechaEfectividad);

            _cd.IdAsignacion = idAsignacion;
            _cd.IdEmpleado = idEmpleado;
            _cd.Tipo = tipo;
            _cd.Monto = monto;
            _cd.FechaEfectividad = fechaEfectividad;

            return await _cd.InsertarAsync();
        }

        // ─── Actualizar ───────────────────────────────────────────────────
        public bool Actualizar(int id, int idAsignacion, int idEmpleado,
                               int tipo, decimal monto, DateTime fechaEfectividad)
        {
            if (id <= 0)
                throw new ArgumentException("El Id debe ser un valor positivo.", nameof(id));

            ValidarCampos(idAsignacion, idEmpleado, tipo, monto, fechaEfectividad);

            _cd.IdAsignacion = idAsignacion;
            _cd.IdEmpleado = idEmpleado;
            _cd.Tipo = tipo;
            _cd.Monto = monto;
            _cd.FechaEfectividad = fechaEfectividad;

            return _cd.Actualizar(id);
        }

        public async Task<bool> ActualizarAsync(int id, int idAsignacion, int idEmpleado,
                                                int tipo, decimal monto, DateTime fechaEfectividad)
        {
            if (id <= 0)
                throw new ArgumentException("El Id debe ser un valor positivo.", nameof(id));

            ValidarCampos(idAsignacion, idEmpleado, tipo, monto, fechaEfectividad);

            _cd.IdAsignacion = idAsignacion;
            _cd.IdEmpleado = idEmpleado;
            _cd.Tipo = tipo;
            _cd.Monto = monto;
            _cd.FechaEfectividad = fechaEfectividad;

            return await _cd.ActualizarAsync(id);
        }

        // ─── Validaciones ─────────────────────────────────────────────────
        private void ValidarCampos(int idAsignacion, int idEmpleado,
                                   int tipo, decimal monto, DateTime fechaEfectividad)
        {
            if (idAsignacion <= 0)
                throw new ArgumentException("Debe seleccionar una asignación válida.", nameof(idAsignacion));

            if (idEmpleado <= 0)
                throw new ArgumentException("Debe seleccionar un empleado válido.", nameof(idEmpleado));

            if (tipo != TIPO_MENSUAL && tipo != TIPO_QUINCENAL)
                throw new ArgumentException("El tipo debe ser 1 (Mensual) o 2 (Quincenal).", nameof(tipo));

            if (monto <= 0)
                throw new ArgumentException("El monto debe ser mayor a cero.", nameof(monto));

            if (fechaEfectividad == default)
                throw new ArgumentException("Debe indicar una fecha de efectividad válida.", nameof(fechaEfectividad));

            if (fechaEfectividad.Date < DateTime.Today)
                throw new InvalidOperationException("La fecha de efectividad no puede ser anterior a hoy.");
        }
    }
}