using Datos.CD;
using Datos.Repositorios;
using System.Data;
using System.Threading.Tasks;

namespace Negocio.Servicios
{
    public class DeduccionesCN : BaseCN
    {
        // Instancia del CD para todas las operaciones con la BD
        private readonly DeduccionesCD _cd = new DeduccionesCD();


        // ─────────────────────────────────────────
        // IMPLENTACION DE METODOS ABSTRACTOS CLASE PADRE
        // ─────────────────────────────────────────

        protected override string ObtenerNombreEntidad()
        {
            return "Deduccion";
        }

        protected override bool EjecutarEliminar(int id)
        {
            return _cd.Eliminar(id);
        }

        protected override async Task<bool> EjecutarEliminarAsync(int id)
        {
            bool resultado = await _cd.EliminarAsync(id);
            return resultado;
        }



        private void AsignarPropiedades(string nombre, decimal porcentaje, string descripcion)
        {
            _cd.Nombre = nombre.Trim();
            _cd.Porcentaje = porcentaje;

            if (descripcion != null)
            {
                _cd.Descripcion = descripcion.Trim();
            }
            else
            {
                _cd.Descripcion = null;
            }
        }


        // ─────────────────────────────────────────
        // CREATE
        // ─────────────────────────────────────────

        public (bool exito, string mensaje) Insertar(string nombre, decimal porcentaje,
                                                      string descripcion)
        {
            // Validamos el nombre
            var validacionNombre = ValidarTexto(nombre, "Nombre");

            if (!validacionNombre.esValido)
            {
                return (false, validacionNombre.mensaje);
            }

            // Validamos el porcentaje
            var validacionPorcentaje = ValidarPorcentaje(porcentaje);

            if (!validacionPorcentaje.esValido)
            {
                return (false, validacionPorcentaje.mensaje);
            }


            AsignarPropiedades(nombre, porcentaje, descripcion);

            bool resultado = _cd.Insertar();

            if (!resultado)
            {
                return (false, "No se pudo registrar la deduccion.");
            }

            return (true, "Deduccion registrada correctamente.");
        }

        public async Task<(bool exito, string mensaje)> InsertarAsync(string nombre,
                                                                       decimal porcentaje,
                                                                       string descripcion)
        {
            var validacionNombre = ValidarTexto(nombre, "Nombre");

            if (!validacionNombre.esValido)
            {
                return (false, validacionNombre.mensaje);
            }

            var validacionPorcentaje = ValidarPorcentaje(porcentaje);

            if (!validacionPorcentaje.esValido)
            {
                return (false, validacionPorcentaje.mensaje);
            }

            AsignarPropiedades(nombre, porcentaje, descripcion);

            bool resultado = await _cd.InsertarAsync();

            if (!resultado)
            {
                return (false, "No se pudo registrar la deduccion.");
            }

            return (true, "Deduccion registrada correctamente.");
        }


        // ─────────────────────────────────────────
        // READ
        // ─────────────────────────────────────────

        // Retorna todas las deducciones sin filtro
        public override DataTable ObtenerTodos()
        {
            DataTable tabla = _cd.ObtenerTodos();
            return tabla;
        }

        public override async Task<DataTable> ObtenerTodosAsync()
        {
            DataTable tabla = await _cd.ObtenerTodosAsync();
            return tabla;
        }

        // Retorna una deduccion específica por su ID
        public override DataTable ObtenerPorId(int id)
        {
            // ValidarId verifica que el ID sea mayor a 0
            var validacion = ValidarId(id, "Deduccion");

            // Si el ID no es válido retorna una tabla vacía
            // para evitar una consulta innecesaria a la BD
            if (!validacion.esValido)
            {
                return new DataTable();
            }

            DataTable tabla = _cd.ObtenerPorId(id);
            return tabla;
        }

        public override async Task<DataTable> ObtenerPorIdAsync(int id)
        {
            var validacion = ValidarId(id, "Deduccion");

            if (!validacion.esValido)
            {
                return new DataTable();
            }

            DataTable tabla = await _cd.ObtenerPorIdAsync(id);
            return tabla;
        }


        // ─────────────────────────────────────────
        // UPDATE
        // ─────────────────────────────────────────

        public (bool exito, string mensaje) Actualizar(int id, string nombre,
                                                        decimal porcentaje, string descripcion)
        {
            // Validamos el ID primero — debe ser un registro existente
            var validacionId = ValidarId(id, "Deduccion");

            if (!validacionId.esValido)
            {
                return (false, validacionId.mensaje);
            }

            // Luego validamos el nuevo nombre
            var validacionNombre = ValidarTexto(nombre, "Nombre");

            if (!validacionNombre.esValido)
            {
                return (false, validacionNombre.mensaje);
            }

            // Luego validamos el nuevo porcentaje
            var validacionPorcentaje = ValidarPorcentaje(porcentaje);

            if (!validacionPorcentaje.esValido)
            {
                return (false, validacionPorcentaje.mensaje);
            }

            
            AsignarPropiedades(nombre, porcentaje, descripcion);

            bool resultado = _cd.Actualizar(id);

            if (!resultado)
            {
                return (false, "No se pudo actualizar la deduccion.");
            }

            return (true, "Deduccion actualizada correctamente.");
        }

        public async Task<(bool exito, string mensaje)> ActualizarAsync(int id, string nombre,
                                                                         decimal porcentaje,
                                                                         string descripcion)
        {
            var validacionId = ValidarId(id, "Deduccion");

            if (!validacionId.esValido)
            {
                return (false, validacionId.mensaje);
            }

            var validacionNombre = ValidarTexto(nombre, "Nombre");

            if (!validacionNombre.esValido)
            {
                return (false, validacionNombre.mensaje);
            }

            var validacionPorcentaje = ValidarPorcentaje(porcentaje);

            if (!validacionPorcentaje.esValido)
            {
                return (false, validacionPorcentaje.mensaje);
            }

            AsignarPropiedades(nombre, porcentaje, descripcion);

            bool resultado = await _cd.ActualizarAsync(id);

            if (!resultado)
            {
                return (false, "No se pudo actualizar la deduccion.");
            }

            return (true, "Deduccion actualizada correctamente.");
        }


        // ─────────────────────────────────────────
        // DELETE — heredado completo de BaseCN
        // BaseCN ya maneja la validación del ID y los mensajes
        // usando ObtenerNombreEntidad() y EjecutarEliminar()
        //
        // Uso: var (exito, mensaje) = cn.Eliminar(id);
        // ─────────────────────────────────────────
    }
}
