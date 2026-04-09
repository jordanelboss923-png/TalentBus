using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    // TODO Interfaz IOperacionesCN
    public interface IOperacionesCN
    {
        // Métodos síncronos
        DataTable ObtenerTodos();
        DataTable ObtenerPorId(int id);
        (bool exito, string mensaje) Eliminar(int id);

        // Métodos asíncronos
        Task<DataTable> ObtenerTodosAsync();
        Task<DataTable> ObtenerPorIdAsync(int id);
        Task<(bool exito, string mensaje)> EliminarAsync(int id);

        /*
        Nota: Insertar() y Actualizar() NO forman parte del contrato base
        porque cada entidad tiene parámetros distintos.
        */
    }

    public abstract class BaseCN : IOperacionesCN
    {
        // ─────────────────────────────────────────
        // MÉTODOS ABSTRACTOS
        // ─────────────────────────────────────────

        public abstract DataTable ObtenerTodos();
        public abstract DataTable ObtenerPorId(int id);
        public abstract Task<DataTable> ObtenerTodosAsync();
        public abstract Task<DataTable> ObtenerPorIdAsync(int id);

        // ─────────────────────────────────────────
        // MÉTODOS VIRTUALES
        // ─────────────────────────────────────────

        public virtual (bool exito, string mensaje) Eliminar(int id)
        {
            if (id <= 0)
                return (false, "ID no válido.");

            bool resultado = EjecutarEliminar(id);

            if (!resultado)
                return (false, $"No se pudo eliminar. {ObtenerNombreEntidad()} puede tener registros asociados.");

            return (true, $"{ObtenerNombreEntidad()} eliminado correctamente.");
        }

        public virtual async Task<(bool exito, string mensaje)> EliminarAsync(int id)
        {
            if (id <= 0)
                return (false, "ID no válido.");

            bool resultado = await EjecutarEliminarAsync(id);

            if (!resultado)
                return (false, $"No se pudo eliminar. {ObtenerNombreEntidad()} puede tener registros asociados.");

            return (true, $"{ObtenerNombreEntidad()} eliminado correctamente.");
        }

        // ─────────────────────────────────────────
        // MÉTODOS ABSTRACTOS
        // ─────────────────────────────────────────

        protected abstract bool EjecutarEliminar(int id);
        protected abstract Task<bool> EjecutarEliminarAsync(int id);
        protected abstract string ObtenerNombreEntidad();

        // ─────────────────────────────────────────
        // MÉTODOS NORMALES
        // Validaciones comunes disponibles para todas las clases hijas
        // ─────────────────────────────────────────

        protected (bool esValido, string mensaje) ValidarTexto(string valor,
                                                                string nombreCampo,
                                                                int longitudMaxima = 100)
        {
            if (string.IsNullOrWhiteSpace(valor))
                return (false, $"El campo {nombreCampo} es obligatorio.");

            if (valor.Trim().Length > longitudMaxima)
                return (false, $"El campo {nombreCampo} no puede superar {longitudMaxima} caracteres.");

            return (true, string.Empty);
        }

        protected (bool esValido, string mensaje) ValidarPorcentaje(decimal porcentaje)
        {
            if (porcentaje < 0 || porcentaje > 100)
                return (false, "El porcentaje debe estar entre 0 y 100.");

            return (true, string.Empty);
        }

        protected (bool esValido, string mensaje) ValidarId(int id, string nombreCampo)
        {
            if (id <= 0)
                return (false, $"Debe seleccionar un {nombreCampo} válido.");

            return (true, string.Empty);
        }
    }
}
