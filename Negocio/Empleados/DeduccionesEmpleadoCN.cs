using Datos.Repositorios.Empleados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.Empleados
{
    public class DeduccionesEmpleadoCN
    {

        // Constantes de tipo de deducción

        public const int TIPO_MENSUAL = 1;
        public const int TIPO_QUINCENAL = 2;

        // Instancia de la capa de datos

        private readonly DeduccionesEmpleadoCD _cd = new DeduccionesEmpleadoCD();


        //TODO: ObtenerTodos, metodo para obtener todos los registros de deducciones de empleados

        public DataTable ObtenerTodos()
        {
            return _cd.ObtenerTodos();
        }

        public async Task<DataTable> ObtenerTodosAsync()
        {
            return await _cd.ObtenerTodosAsync();
        }


        // TODO: ObtenerPorId, metodo para obtener una deducción de empleado por su Id, con validaciones para asegurar que el Id sea un valor positivo

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

        // Insertar

        public bool Insertar(int idDeduccion, int idEmpleado, int idSubtotal,
                             int tipo, decimal monto, DateTime fechaEfectividad)
        {
            ValidarCampos(idDeduccion, idEmpleado, idSubtotal, tipo, monto, fechaEfectividad);

            _cd.IdDeduccion = idDeduccion;
            _cd.IdEmpleado = idEmpleado;
            _cd.IdSubtotal = idSubtotal;
            _cd.Tipo = tipo;
            _cd.Monto = monto;
            _cd.FechaEfectividad = fechaEfectividad;

            return _cd.Insertar();
        }

        public async Task<bool> InsertarAsync(int idDeduccion, int idEmpleado, int idSubtotal,
                                              int tipo, decimal monto, DateTime fechaEfectividad)
        {
            ValidarCampos(idDeduccion, idEmpleado, idSubtotal, tipo, monto, fechaEfectividad);

            _cd.IdDeduccion = idDeduccion;
            _cd.IdEmpleado = idEmpleado;
            _cd.IdSubtotal = idSubtotal;
            _cd.Tipo = tipo;
            _cd.Monto = monto;
            _cd.FechaEfectividad = fechaEfectividad;

            return await _cd.InsertarAsync();
        }


        // Actualizar

        public bool Actualizar(int id, int idDeduccion, int idEmpleado, int idSubtotal,
                               int tipo, decimal monto, DateTime fechaEfectividad)
        {
            if (id <= 0)
                throw new ArgumentException("El Id debe ser un valor positivo.", nameof(id));

            ValidarCampos(idDeduccion, idEmpleado, idSubtotal, tipo, monto, fechaEfectividad);

            _cd.IdDeduccion = idDeduccion;
            _cd.IdEmpleado = idEmpleado;
            _cd.IdSubtotal = idSubtotal;
            _cd.Tipo = tipo;
            _cd.Monto = monto;
            _cd.FechaEfectividad = fechaEfectividad;

            return _cd.Actualizar(id);
        }

        public async Task<bool> ActualizarAsync(int id, int idDeduccion, int idEmpleado, int idSubtotal,
                                                int tipo, decimal monto, DateTime fechaEfectividad)
        {
            if (id <= 0)
                throw new ArgumentException("El Id debe ser un valor positivo.", nameof(id));

            ValidarCampos(idDeduccion, idEmpleado, idSubtotal, tipo, monto, fechaEfectividad);

            _cd.IdDeduccion = idDeduccion;
            _cd.IdEmpleado = idEmpleado;
            _cd.IdSubtotal = idSubtotal;
            _cd.Tipo = tipo;
            _cd.Monto = monto;
            _cd.FechaEfectividad = fechaEfectividad;

            return await _cd.ActualizarAsync(id);
        }


        // Validaciones centralizadas, para evitar duplicación de código en los métodos Insertar y Actualizar

        private void ValidarCampos(int idDeduccion, int idEmpleado, int idSubtotal,
                                   int tipo, decimal monto, DateTime fechaEfectividad)
        {
            if (idDeduccion <= 0)
                throw new ArgumentException("Debe seleccionar una deducción válida.", nameof(idDeduccion));

            if (idEmpleado <= 0)
                throw new ArgumentException("Debe seleccionar un empleado válido.", nameof(idEmpleado));

            if (idSubtotal <= 0)
                throw new ArgumentException("Debe asociar un subtotal válido.", nameof(idSubtotal));

            if (tipo != TIPO_MENSUAL && tipo != TIPO_QUINCENAL)
                throw new ArgumentException("El tipo de deducción debe ser 1 (Mensual) o 2 (Quincenal).", nameof(tipo));

            if (monto <= 0)
                throw new ArgumentException("El monto de la deducción debe ser mayor a cero.", nameof(monto));

            if (fechaEfectividad == default)
                throw new ArgumentException("Debe indicar una fecha de efectividad válida.", nameof(fechaEfectividad));

            if (fechaEfectividad > DateTime.Today)
                throw new InvalidOperationException("La fecha de efectividad no puede ser futura.");
        }
    }
}
