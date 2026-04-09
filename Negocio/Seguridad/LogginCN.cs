using Datos.Repositorios.Seguridad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.Seguridad
{
    public class LogginCN
    {

        // Constantes de reglas de contraseña

        private const int LONGITUD_MINIMA_CLAVE = 6;
        private const int LONGITUD_MAXIMA_CLAVE = 50;


        // Instancia de la capa de datos

        private readonly LogginCD _cd = new LogginCD();


        // TODO: ObtenerTodos, metodo para obtener todos los registros de usuarios

        public DataTable ObtenerTodos()
        {
            return _cd.ObtenerTodos();
        }

        public async Task<DataTable> ObtenerTodosAsync()
        {
            return await _cd.ObtenerTodosAsync();
        }


        // ObtenerPorId

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


        //TODO: ValidarAcceso, metodo para validar el acceso de un usuario, con validaciones para asegurar que el nombre de usuario
        //y la clave no estén vacíos o nulos, y que cumplan con las reglas establecidas.

        public bool ValidarAcceso(string usser, string clave)
        {
            ValidarCredencialesEntrada(usser, clave);
            return _cd.ValidarAcceso(usser.Trim(), clave);
        }

        public async Task<bool> ValidarAccesoAsync(string usser, string clave)
        {
            ValidarCredencialesEntrada(usser, clave);
            return await _cd.ValidarAccesoAsync(usser.Trim(), clave);
        }


        // TODO: CreacionUsuario, Insertar, metodo para insertar un nuevo usuario, con validaciones para asegurar que el Id del empleado sea un valor positivo,

        public bool Insertar(int idEmpleado, string clave, string confirmarClave)
        {
            if (idEmpleado <= 0)
                throw new ArgumentException("Debe seleccionar un empleado válido.", nameof(idEmpleado));

            ValidarClave(clave, confirmarClave);

            _cd.IdEmpleado = idEmpleado;
            _cd.Clave = clave;

            return _cd.Insertar();
        }

        public async Task<bool> InsertarAsync(int idEmpleado, string clave, string confirmarClave)
        {
            if (idEmpleado <= 0)
                throw new ArgumentException("Debe seleccionar un empleado válido.", nameof(idEmpleado));

            ValidarClave(clave, confirmarClave);

            _cd.IdEmpleado = idEmpleado;
            _cd.Clave = clave;

            return await _cd.InsertarAsync();
        }


        // Actualizar, metodo para actualizar la clave de un usuario existente, con validaciones para asegurar que el Id del usuario sea un valor positivo,
        // y que la nueva clave cumpla con las reglas establecidas.

        public bool Actualizar(int id, string claveNueva, string confirmarClave)
        {
            if (id <= 0)
                throw new ArgumentException("El Id debe ser un valor positivo.", nameof(id));

            ValidarClave(claveNueva, confirmarClave);

            _cd.Clave = claveNueva;

            return _cd.Actualizar(id);
        }

        public async Task<bool> ActualizarAsync(int id, string claveNueva, string confirmarClave)
        {
            if (id <= 0)
                throw new ArgumentException("El Id debe ser un valor positivo.", nameof(id));

            ValidarClave(claveNueva, confirmarClave);

            _cd.Clave = claveNueva;

            return await _cd.ActualizarAsync(id);
        }


        // Validaciones centralizadas, para evitar duplicación de código y asegurar que todas las validaciones se apliquen de manera consistente en los métodos correspondientes.

        private void ValidarCredencialesEntrada(string usser, string clave)
        {
            if (string.IsNullOrWhiteSpace(usser))
                throw new ArgumentException("El nombre de usuario es obligatorio.", nameof(usser));

            if (string.IsNullOrWhiteSpace(clave))
                throw new ArgumentException("La clave es obligatoria.", nameof(clave));
        }

        private void ValidarClave(string clave, string confirmarClave)
        {
            if (string.IsNullOrWhiteSpace(clave))
                throw new ArgumentException("La clave es obligatoria.", nameof(clave));

            if (clave.Length < LONGITUD_MINIMA_CLAVE)
                throw new ArgumentException(
                    $"La clave debe tener al menos {LONGITUD_MINIMA_CLAVE} caracteres.", nameof(clave));

            if (clave.Length > LONGITUD_MAXIMA_CLAVE)
                throw new ArgumentException(
                    $"La clave no puede superar {LONGITUD_MAXIMA_CLAVE} caracteres.", nameof(clave));

            if (clave != confirmarClave)
                throw new InvalidOperationException("La clave y la confirmación no coinciden.");
        }
    }
}
