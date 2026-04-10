using Datos.Repositorios.Nomina;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Negocios.Nomina
{
    public class VolantesPagoCN
    {
        private readonly VolantesPagoCD _cd = new VolantesPagoCD();

        // ─── Obtener ──────────────────────────────────────────────────────
        public DataTable ObtenerTodos() => _cd.ObtenerTodos();
        public async Task<DataTable> ObtenerTodosAsync() => await _cd.ObtenerTodosAsync();

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

        // ─── Helpers para ComboBoxes ──────────────────────────────────────
        public DataTable MostrarEmpleados()
            => _cd.MostrarEmpleados();

        public DataTable MostrarSalariosPorEmpleado(int idEmpleado)
            => _cd.MostrarSalariosPorEmpleado(idEmpleado);

        public DataTable MostrarDeduccionesEmpleado(int idEmpleado)
            => _cd.MostrarDeduccionesEmpleado(idEmpleado);

        // ─── Insertar ─────────────────────────────────────────────────────
        public (bool exito, string mensaje) Insertar(int idEmpleado, int idAsignaciones,
                                                     int idDeducciones, DateTime fechaEfectividad)
        {
            try
            {
                ValidarCampos(idEmpleado, idAsignaciones, idDeducciones, fechaEfectividad);

                _cd.IdEmpleado = idEmpleado;
                _cd.IdAsignaciones = idAsignaciones;
                _cd.IdDeducciones = idDeducciones;
                _cd.FechaEfectividad = fechaEfectividad;

                bool ok = _cd.Insertar();
                return ok
                    ? (true, "Volante de pago registrado correctamente.")
                    : (false, "No se pudo guardar el volante de pago.");
            }
            catch (ArgumentException ex) { return (false, ex.Message); }
            catch (InvalidOperationException ex) { return (false, ex.Message); }
            catch (Exception ex) { return (false, "Error: " + ex.Message); }
        }

        public async Task<(bool exito, string mensaje)> InsertarAsync(
            int idEmpleado, int idAsignaciones, int idDeducciones, DateTime fechaEfectividad)
        {
            try
            {
                ValidarCampos(idEmpleado, idAsignaciones, idDeducciones, fechaEfectividad);

                _cd.IdEmpleado = idEmpleado;
                _cd.IdAsignaciones = idAsignaciones;
                _cd.IdDeducciones = idDeducciones;
                _cd.FechaEfectividad = fechaEfectividad;

                bool ok = await _cd.InsertarAsync();
                return ok
                    ? (true, "Volante de pago registrado correctamente.")
                    : (false, "No se pudo guardar el volante de pago.");
            }
            catch (ArgumentException ex) { return (false, ex.Message); }
            catch (InvalidOperationException ex) { return (false, ex.Message); }
            catch (Exception ex) { return (false, "Error: " + ex.Message); }
        }

        // ─── Eliminar ─────────────────────────────────────────────────────
        public (bool exito, string mensaje) Eliminar(int id)
        {
            try
            {
                if (id <= 0) return (false, "Id inválido.");
                bool ok = _cd.Eliminar(id);
                return ok
                    ? (true, "Volante eliminado correctamente.")
                    : (false, "No se pudo eliminar el volante.");
            }
            catch (Exception ex) { return (false, "Error: " + ex.Message); }
        }

        // ─── Volante completo (sueldo neto con deducciones) ───────────────
        /// <summary>
        /// Consulta el total de deducciones y el salario neto para un empleado
        /// en una fecha dada. Usado por FrmDetalleVolante.
        /// </summary>
        public DataTable ObtenerVolanteCompleto(int idEmpleado, DateTime fecha)
        {
            try
            {
                return _cd.ObtenerVolanteCompleto(idEmpleado, fecha);
            }
            catch
            {
                return new DataTable();
            }
        }

        // ─── Validaciones ─────────────────────────────────────────────────
        private void ValidarCampos(int idEmpleado, int idAsignaciones,
                                   int idDeducciones, DateTime fechaEfectividad)
        {
            if (idEmpleado <= 0)
                throw new ArgumentException("Debe seleccionar un empleado válido.");

            if (idAsignaciones <= 0)
                throw new ArgumentException("Debe seleccionar un período de sueldo (SalarioST) válido.");

            if (idDeducciones <= 0)
                throw new ArgumentException("Debe seleccionar una deducción válida.");

            if (fechaEfectividad == default)
                throw new ArgumentException("Debe indicar una fecha de efectividad válida.");

            if (fechaEfectividad.Date < DateTime.Today)
                throw new InvalidOperationException("La fecha de efectividad no puede ser anterior a hoy.");
        }
    }
}