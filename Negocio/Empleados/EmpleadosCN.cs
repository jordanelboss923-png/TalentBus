using Datos.Repositorios;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Negocios
{
    public class EmpleadosCN
    {

        // Constantes de tipo de empleado

        public const int TIPO_FIJO = 1;
        public const int TIPO_POR_HORA = 2;


        // Instancia de la capa de datos

        private readonly EmpleadosCD _cd = new EmpleadosCD();


        //TODO: ObtenerTodos, metodo para obtener todos los registros de empleados

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


        // ObtenerPorCedula

        public DataTable ObtenerPorCedula(string cedula)
        {
            ValidarCedula(cedula);
            return _cd.ObtenerPorCedula(cedula.Trim());
        }

        //TODO: creacion de metodo Insertar, Actualizar, con validaciones para asegurar que los campos requeridos sean válidos

        // Insertar

        public bool Insertar(string codigoEmpleado, string nombre, string apellido,
                             string cedula, int tipo, int idPosicion)
        {
            ValidarCampos(codigoEmpleado, nombre, apellido, cedula, tipo, idPosicion);

            _cd.CodigoEmpleado = codigoEmpleado.Trim().ToUpper();
            _cd.Nombre = nombre.Trim();
            _cd.Apellido = apellido.Trim();
            _cd.Cedula = cedula.Trim();
            _cd.Tipo = tipo;
            _cd.IdPosicion = idPosicion;

            return _cd.Insertar();
        }

        public async Task<bool> InsertarAsync(string codigoEmpleado, string nombre, string apellido,
                                              string cedula, int tipo, int idPosicion)
        {
            ValidarCampos(codigoEmpleado, nombre, apellido, cedula, tipo, idPosicion);

            _cd.CodigoEmpleado = codigoEmpleado.Trim().ToUpper();
            _cd.Nombre = nombre.Trim();
            _cd.Apellido = apellido.Trim();
            _cd.Cedula = cedula.Trim();
            _cd.Tipo = tipo;
            _cd.IdPosicion = idPosicion;

            return await _cd.InsertarAsync();
        }


        // Actualizar

        public bool Actualizar(int id, string nombre, string apellido,
                               string cedula, int tipo, int idPosicion)
        {
            if (id <= 0)
                throw new ArgumentException("El Id debe ser un valor positivo.", nameof(id));

            ValidarCampos(null, nombre, apellido, cedula, tipo, idPosicion, validarCodigo: false);

            _cd.Nombre = nombre.Trim();
            _cd.Apellido = apellido.Trim();
            _cd.Cedula = cedula.Trim();
            _cd.Tipo = tipo;
            _cd.IdPosicion = idPosicion;

            return _cd.Actualizar(id);
        }

        public async Task<bool> ActualizarAsync(int id, string nombre, string apellido,
                                                string cedula, int tipo, int idPosicion)
        {
            if (id <= 0)
                throw new ArgumentException("El Id debe ser un valor positivo.", nameof(id));

            ValidarCampos(null, nombre, apellido, cedula, tipo, idPosicion, validarCodigo: false);

            _cd.Nombre = nombre.Trim();
            _cd.Apellido = apellido.Trim();
            _cd.Cedula = cedula.Trim();
            _cd.Tipo = tipo;
            _cd.IdPosicion = idPosicion;

            return await _cd.ActualizarAsync(id);
        }


        // Validaciones centralizadas, para evitar duplicación de código en los métodos Insertar y Actualizar

        private void ValidarCampos(string codigoEmpleado, string nombre, string apellido,
                                   string cedula, int tipo, int idPosicion,
                                   bool validarCodigo = true)
        {
            if (validarCodigo)
            {
                if (string.IsNullOrWhiteSpace(codigoEmpleado))
                    throw new ArgumentException("El código de empleado es obligatorio.", nameof(codigoEmpleado));

                if (codigoEmpleado.Trim().Length > 20)
                    throw new ArgumentException("El código de empleado no puede superar 20 caracteres.", nameof(codigoEmpleado));
            }

            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre del empleado es obligatorio.", nameof(nombre));

            if (nombre.Trim().Length > 100)
                throw new ArgumentException("El nombre no puede superar 100 caracteres.", nameof(nombre));

            if (string.IsNullOrWhiteSpace(apellido))
                throw new ArgumentException("El apellido del empleado es obligatorio.", nameof(apellido));

            if (apellido.Trim().Length > 100)
                throw new ArgumentException("El apellido no puede superar 100 caracteres.", nameof(apellido));

            ValidarCedula(cedula);

            if (tipo != TIPO_FIJO && tipo != TIPO_POR_HORA)
                throw new ArgumentException("El tipo de empleado debe ser 1 (Fijo) o 2 (Por hora).", nameof(tipo));

            if (idPosicion <= 0)
                throw new ArgumentException("Debe seleccionar una posición válida.", nameof(idPosicion));
        }

        // Validación específica para el formato de cédula, asegurando que contenga solo dígitos y tenga una longitud de 11 caracteres
        private void ValidarCedula(string cedula)
        {
            if (string.IsNullOrWhiteSpace(cedula))
                throw new ArgumentException("La cédula es obligatoria.", nameof(cedula));

            string soloDigitos = Regex.Replace(cedula.Trim(), @"[^0-9]", "");

            if (soloDigitos.Length != 11)
                throw new ArgumentException("La cédula debe contener exactamente 11 dígitos.", nameof(cedula));
        }
    }
}
