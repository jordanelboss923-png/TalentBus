using Datos.Repositorios;
using Datos.Repositorios.Nomina;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Negocios.Nomina
{
    public class VolantesPagoCN
    {

        //TODO: Instancia de la capa de datos

        private readonly VolantesPagoCD _cd = new VolantesPagoCD();


        // TODO: ObtenerTodos metodo para obtener todos los registros de volantes de pago

        public DataTable ObtenerTodos()
        {
            return _cd.ObtenerTodos();
        }

        public async Task<DataTable> ObtenerTodosAsync() // Método asíncrono para obtener todos los registros de volantes de pago
        {
            return await _cd.ObtenerTodosAsync();
        }


        // TODO: ObtenerPorId, metodo para obtener un volante de pago por su Id, con validaciones para asegurar que el Id sea un valor positivo

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


        // TODO: ObtenerPorEmpleado, metodo para obtener los volantes de pago de un empleado específico,
        // con validaciones para asegurar que el Id del empleado sea un valor positivo

        public DataTable ObtenerPorEmpleado(int idEmpleado)
        {
            if (idEmpleado <= 0)
                throw new ArgumentException("El IdEmpleado debe ser un valor positivo.", nameof(idEmpleado));

            return _cd.ObtenerPorEmpleado(idEmpleado);
        }


        // TODO: ObtenerVolanteCompleto, metodo para obtener el volante de pago completo de un empleado en una fecha específica,
        // con validaciones para asegurar que el Id del empleado sea un valor positivo y que la fecha de efectividad sea válida

        public DataTable ObtenerVolanteCompleto(int idEmpleado, DateTime fechaEfectividad)
        {
            if (idEmpleado <= 0)
                throw new ArgumentException("El IdEmpleado debe ser un valor positivo.", nameof(idEmpleado));

            if (fechaEfectividad == default)
                throw new ArgumentException("Debe indicar una fecha de efectividad válida.", nameof(fechaEfectividad));

            return _cd.ObtenerVolanteCompleto(idEmpleado, fechaEfectividad);
        }

        //TODO: Creacion de metodo insertar y actualizar, con validaciones para asegurar que los campos sean correctos
        //por ejemplo, que el sueldo base sea mayor a cero, que la asignación no sea negativa, que el total sea igual a la suma del sueldo base y la asignación.

        // Insertar

        public bool Insertar(int idEmpleado, decimal sueldoBase, decimal asignacion,
                             decimal total, DateTime fechaEfectividad)
        {
            ValidarCampos(idEmpleado, sueldoBase, asignacion, total, fechaEfectividad);

            _cd.IdEmpleado = idEmpleado;
            _cd.SueldoBase = sueldoBase;
            _cd.Asignacion = asignacion;
            _cd.Total = total;
            _cd.FechaEfectividad = fechaEfectividad;

            return _cd.Insertar();
        }

        public async Task<bool> InsertarAsync(int idEmpleado, decimal sueldoBase, decimal asignacion,
                                              decimal total, DateTime fechaEfectividad)
        {
            ValidarCampos(idEmpleado, sueldoBase, asignacion, total, fechaEfectividad);

            _cd.IdEmpleado = idEmpleado;
            _cd.SueldoBase = sueldoBase;
            _cd.Asignacion = asignacion;
            _cd.Total = total;
            _cd.FechaEfectividad = fechaEfectividad;

            return await _cd.InsertarAsync();
        }


        // Actualizar

        public bool Actualizar(int id, decimal sueldoBase, decimal asignacion,
                               decimal total, DateTime fechaEfectividad)
        {
            if (id <= 0)
                throw new ArgumentException("El Id debe ser un valor positivo.", nameof(id));

            ValidarCampos(0, sueldoBase, asignacion, total, fechaEfectividad, validarEmpleado: false);

            _cd.SueldoBase = sueldoBase;
            _cd.Asignacion = asignacion;
            _cd.Total = total;
            _cd.FechaEfectividad = fechaEfectividad;

            return _cd.Actualizar(id);
        }

        public async Task<bool> ActualizarAsync(int id, decimal sueldoBase, decimal asignacion,
                                                decimal total, DateTime fechaEfectividad)
        {
            if (id <= 0)
                throw new ArgumentException("El Id debe ser un valor positivo.", nameof(id));

            ValidarCampos(0, sueldoBase, asignacion, total, fechaEfectividad, validarEmpleado: false);

            _cd.SueldoBase = sueldoBase;
            _cd.Asignacion = asignacion;
            _cd.Total = total;
            _cd.FechaEfectividad = fechaEfectividad;

            return await _cd.ActualizarAsync(id);
        }


        // Validaciones centralizadas, para evitar duplicación de código en los métodos de insertar y actualizar

        private void ValidarCampos(int idEmpleado, decimal sueldoBase, decimal asignacion,
                                   decimal total, DateTime fechaEfectividad,
                                   bool validarEmpleado = true)
        {
            if (validarEmpleado && idEmpleado <= 0)
                throw new ArgumentException("Debe seleccionar un empleado válido.", nameof(idEmpleado));

            if (sueldoBase <= 0)
                throw new ArgumentException("El sueldo base debe ser mayor a cero.", nameof(sueldoBase));

            if (asignacion < 0)
                throw new ArgumentException("La asignación no puede ser negativa.", nameof(asignacion));

            decimal totalEsperado = sueldoBase + asignacion;
            if (total != totalEsperado)
                throw new InvalidOperationException(
                    $"El total ({total:N2}) no coincide con SueldoBase + Asignación ({totalEsperado:N2}).");

            if (fechaEfectividad == default)
                throw new ArgumentException("Debe indicar una fecha de efectividad válida.", nameof(fechaEfectividad));

            if (fechaEfectividad > DateTime.Today)
                throw new InvalidOperationException("La fecha de efectividad no puede ser futura.");
        }
    }
}
