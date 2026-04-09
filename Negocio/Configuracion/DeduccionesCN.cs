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
        // MÉTODOS ABSTRACTOS AUXILIARES
        // Implementaciones obligatorias que BaseCN necesita
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


        // ─────────────────────────────────────────
        // MÉTODO PRIVADO AUXILIAR
        // Centraliza la asignación de propiedades del CD
        // para no repetir el bloque if/else de Descripcion
        // en cada método que lo necesite
        // ─────────────────────────────────────────

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
        // CREATE — método propio de DeduccionesCN
        // DeduccionesCD usa el patrón de propiedades:
        // se asignan los valores al objeto antes de llamar al método
        // ─────────────────────────────────────────

        public (bool exito, string mensaje) Insertar(string nombre, decimal porcentaje,
                                                      string descripcion)
        {
            // Validamos el nombre — viene de BaseCN
            var validacionNombre = ValidarTexto(nombre, "Nombre");

            if (!validacionNombre.esValido)
            {
                return (false, validacionNombre.mensaje);
            }

            // Validamos el porcentaje — viene de BaseCN
            var validacionPorcentaje = ValidarPorcentaje(porcentaje);

            if (!validacionPorcentaje.esValido)
            {
                return (false, validacionPorcentaje.mensaje);
            }

            // Asignamos las propiedades del CD antes de llamar al método
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
        // READ — implementaciones obligatorias de BaseCN
        // ─────────────────────────────────────────

        // Retorna todas las deducciones sin filtro
        public override DataTable ObtenerTodos()
        {
            DataTable tabla = _cd.ObtenerTodos();
            return tabla;
        }

        // Versión asíncrona — no bloquea la interfaz mientras consulta la BD
        public override async Task<DataTable> ObtenerTodosAsync()
        {
            DataTable tabla = await _cd.ObtenerTodosAsync();
            return tabla;
        }

        // Retorna una deduccion específica por su ID
        public override DataTable ObtenerPorId(int id)
        {
            // ValidarId viene de BaseCN — verifica que el ID sea mayor a 0
            var validacion = ValidarId(id, "Deduccion");

            // Si el ID no es válido retornamos una tabla vacía
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
        // UPDATE — método propio de DeduccionesCN
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

            // Asignamos las propiedades del CD antes de llamar al método
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
