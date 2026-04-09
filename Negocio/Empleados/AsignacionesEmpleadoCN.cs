using Datos.Repositorios;
using Datos.Repositorios.Empleados;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Negocios.Empleados
{
    public class AsignacionesEmpleadoCN
    {

        // Constantes de tipo de asignación

        public const int TIPO_MENSUAL = 1;
        public const int TIPO_QUINCENAL = 2;


        // Instancia de la capa de datos

        private readonly AsignacionesEmpleadoCD _cd = new AsignacionesEmpleadoCD();


        //TODO: ObtenerTodos, metodo para obtener todos los registros de asignaciones de empleados

        public DataTable ObtenerTodos()
        {
            return _cd.ObtenerTodos();
        }

        public async Task<DataTable> ObtenerTodosAsync()
        {
            return await _cd.ObtenerTodosAsync();
        }


        // TODO: ObtenerPorId, metodo para obtener una asignación de empleado por su Id, con validaciones para asegurar que el Id sea un valor positivo

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

        //TODO: creacion de metodo Insertar, Actualizar, con validaciones para asegurar que los campos requeridos sean válidos
        //(por ejemplo, monto positivo, fecha de efectividad no futura, etc.)

        // Insertar

        public bool Insertar(int idAsignacion, int idEmpleado, int idSubtotal,
                             int tipo, decimal monto, DateTime fechaEfectividad)
        {
            ValidarCampos(idAsignacion, idEmpleado, idSubtotal, tipo, monto, fechaEfectividad);

            _cd.IdAsignacion = idAsignacion;
            _cd.IdEmpleado = idEmpleado;
            _cd.IdSubtotal = idSubtotal;
            _cd.Tipo = tipo;
            _cd.Monto = monto;
            _cd.FechaEfectividad = fechaEfectividad;

            return _cd.Insertar();
        }

        public async Task<bool> InsertarAsync(int idAsignacion, int idEmpleado, int idSubtotal,
                                              int tipo, decimal monto, DateTime fechaEfectividad)
        {
            ValidarCampos(idAsignacion, idEmpleado, idSubtotal, tipo, monto, fechaEfectividad);

            _cd.IdAsignacion = idAsignacion;
            _cd.IdEmpleado = idEmpleado;
            _cd.IdSubtotal = idSubtotal;
            _cd.Tipo = tipo;
            _cd.Monto = monto;
            _cd.FechaEfectividad = fechaEfectividad;

            return await _cd.InsertarAsync();
        }


        // Actualizar

        public bool Actualizar(int id, int idAsignacion, int idEmpleado, int idSubtotal,
                               int tipo, decimal monto, DateTime fechaEfectividad)
        {
            if (id <= 0)
                throw new ArgumentException("El Id debe ser un valor positivo.", nameof(id));

            ValidarCampos(idAsignacion, idEmpleado, idSubtotal, tipo, monto, fechaEfectividad);

            _cd.IdAsignacion = idAsignacion;
            _cd.IdEmpleado = idEmpleado;
            _cd.IdSubtotal = idSubtotal;
            _cd.Tipo = tipo;
            _cd.Monto = monto;
            _cd.FechaEfectividad = fechaEfectividad;

            return _cd.Actualizar(id);
        }

        public async Task<bool> ActualizarAsync(int id, int idAsignacion, int idEmpleado, int idSubtotal,
                                                int tipo, decimal monto, DateTime fechaEfectividad)
        {
            if (id <= 0)
                throw new ArgumentException("El Id debe ser un valor positivo.", nameof(id));

            ValidarCampos(idAsignacion, idEmpleado, idSubtotal, tipo, monto, fechaEfectividad);

            _cd.IdAsignacion = idAsignacion;
            _cd.IdEmpleado = idEmpleado;
            _cd.IdSubtotal = idSubtotal;
            _cd.Tipo = tipo;
            _cd.Monto = monto;
            _cd.FechaEfectividad = fechaEfectividad;

            return await _cd.ActualizarAsync(id);
        }


        // Validaciones centralizadas, para evitar duplicación de código en los métodos Insertar y Actualizar

        private void ValidarCampos(int idAsignacion, int idEmpleado, int idSubtotal,
                                   int tipo, decimal monto, DateTime fechaEfectividad)
        {
            if (idAsignacion <= 0)
                throw new ArgumentException("Debe seleccionar una asignación válida.", nameof(idAsignacion));

            if (idEmpleado <= 0)
                throw new ArgumentException("Debe seleccionar un empleado válido.", nameof(idEmpleado));

            if (idSubtotal <= 0)
                throw new ArgumentException("Debe asociar un subtotal válido.", nameof(idSubtotal));

            if (tipo != TIPO_MENSUAL && tipo != TIPO_QUINCENAL)
                throw new ArgumentException("El tipo de asignación debe ser 1 (Mensual) o 2 (Quincenal).", nameof(tipo));

            if (monto <= 0)
                throw new ArgumentException("El monto de la asignación debe ser mayor a cero.", nameof(monto));

            if (fechaEfectividad == default)
                throw new ArgumentException("Debe indicar una fecha de efectividad válida.", nameof(fechaEfectividad));

            if (fechaEfectividad > DateTime.Today)
                throw new InvalidOperationException("La fecha de efectividad no puede ser futura.");
        }
    }
}
