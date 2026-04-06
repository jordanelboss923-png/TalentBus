using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public interface IOperacionesCN
    {
        // Métodos sincronos
        DataTable ObtenerTodos();
        DataTable ObtenerPorId(int id);
        (bool exito, string mensaje) Eliminar(int id);

        // Métodos asincronos — llamadas asincronas al CD
        Task<DataTable> ObtenerTodosAsync();
        Task<DataTable> ObtenerPorIdAsync(int id);
        Task<(bool exito, string mensaje)> EliminarAsync(int id);
    }

    // CLASE ABSTRACTA
    public abstract class BaseCN : IOperacionesCN
    {
        // MÉTODOS ABSTRACTOS

        // Síncronos
        public abstract DataTable ObtenerTodos();
        public abstract DataTable ObtenerPorId(int id);

        // Asíncronos
        public abstract Task<DataTable> ObtenerTodosAsync();
        public abstract Task<DataTable> ObtenerPorIdAsync(int id);

        // MÉTODOS VIRTUALES

        // Síncrono
        public virtual (bool exito, string mensaje) Eliminar(int id)
        {
            if (id <= 0)
                return (false, "ID no válido.");

            bool resultado = EjecutarEliminar(id);
            return resultado
                ? (true, $"{ObtenerNombreEntidad()} eliminado correctamente.")
                : (false, $"No se pudo eliminar. {ObtenerNombreEntidad()} puede tener registros asociados.");
        }

        // Asíncrono
        public virtual async Task<(bool exito, string mensaje)> EliminarAsync(int id)
        {
            if (id <= 0)
                return (false, "ID no válido.");

            bool resultado = await EjecutarEliminarAsync(id);
            return resultado
                ? (true, $"{ObtenerNombreEntidad()} eliminado correctamente.")
                : (false, $"No se pudo eliminar. {ObtenerNombreEntidad()} puede tener registros asociados.");
        }

        // ─────────────────────────────────────────
        // MÉTODOS ABSTRACTOS AUXILIARES
        // Le permiten a BaseCN funcionar de forma genérica
        // sin conocer los detalles de cada clase hija
        // ─────────────────────────────────────────

        // Cada CN le dice a BaseCN cómo llamar al Eliminar de su CD
        protected abstract bool EjecutarEliminar(int id);
        protected abstract Task<bool> EjecutarEliminarAsync(int id);

        // Cada CN le dice a BaseCN su nombre para los mensajes
        // Ejemplo: "Departamento", "Deducción", "Asignación"
        protected abstract string ObtenerNombreEntidad();

        // ─────────────────────────────────────────
        // MÉTODO NORMAL REUTILIZABLE
        // Validación de campos de texto común para todas las CN
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

        // Validación de porcentajes reutilizable
        protected (bool esValido, string mensaje) ValidarPorcentaje(decimal porcentaje)
        {
            if (porcentaje < 0 || porcentaje > 100)
                return (false, "El porcentaje debe estar entre 0 y 100.");

            return (true, string.Empty);
        }

        // Validación de IDs reutilizable
        protected (bool esValido, string mensaje) ValidarId(int id, string nombreCampo)
        {
            if (id <= 0)
                return (false, $"Debe seleccionar un {nombreCampo} válido.");

            return (true, string.Empty);
        }
    }
}
