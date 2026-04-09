using Datos.CD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Configuracion
{
    public class DepartamentosCN : BaseCN
    {
        // Instancia del CD para todas las operaciones con la BD
        private readonly DepartamentosCD _cd = new DepartamentosCD();


        // ─────────────────────────────────────────
        // MÉTODOS ABSTRACTOS AUXILIARES
        // Implementaciones obligatorias que BaseCN necesita
        // ─────────────────────────────────────────

        protected override string ObtenerNombreEntidad()
        {
            return "Departamento";
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
        // CREATE — método propio de DepartamentosCN
        // No viene de BaseCN, cada CN define su propio Insertar
        // ─────────────────────────────────────────

        public (bool exito, string mensaje) Insertar(string nombre)
        {
            var validacion = ValidarTexto(nombre, "Nombre");

            if (!validacion.esValido)
            {
                return (false, validacion.mensaje);
            }

            // Primero asignas la propiedad, luego llamas al método
            _cd.Nombre = nombre.Trim();
            bool resultado = _cd.Insertar();

            if (!resultado)
            {
                return (false, "No se pudo registrar. El nombre del departamento puede estar duplicado.");
            }

            return (true, "Departamento registrado correctamente.");
        }

        public async Task<(bool exito, string mensaje)> InsertarAsync(string nombre)
        {
            var validacion = ValidarTexto(nombre, "Nombre");

            if (!validacion.esValido)
            {
                return (false, validacion.mensaje);
            }

            _cd.Nombre = nombre.Trim();
            bool resultado = await _cd.InsertarAsync();

            if (!resultado)
            {
                return (false, "No se pudo registrar. El nombre del departamento puede estar duplicado.");
            }

            return (true, "Departamento registrado correctamente.");
        }


        // ─────────────────────────────────────────
        // READ — implementaciones obligatorias de BaseCN
        // ─────────────────────────────────────────

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

        public override DataTable ObtenerPorId(int id)
        {
            var validacion = ValidarId(id, "Departamento");

            if (!validacion.esValido)
            {
                return new DataTable();
            }

            DataTable tabla = _cd.ObtenerPorId(id);
            return tabla;
        }

        public override async Task<DataTable> ObtenerPorIdAsync(int id)
        {
            var validacion = ValidarId(id, "Departamento");

            if (!validacion.esValido)
            {
                return new DataTable();
            }

            DataTable tabla = await _cd.ObtenerPorIdAsync(id);
            return tabla;
        }


        // ─────────────────────────────────────────
        // UPDATE — método propio de DepartamentosCN
        // No viene de BaseCN, cada CN define su propio Actualizar
        // ─────────────────────────────────────────

        public (bool exito, string mensaje) Actualizar(int id, string nombre)
        {
            var validacionId = ValidarId(id, "Departamento");

            if (!validacionId.esValido)
            {
                return (false, validacionId.mensaje);
            }

            var validacionNombre = ValidarTexto(nombre, "Nombre");

            if (!validacionNombre.esValido)
            {
                return (false, validacionNombre.mensaje);
            }

            _cd.Nombre = nombre.Trim();
            bool resultado = _cd.Actualizar(id);

            if (!resultado)
            {
                return (false, "No se pudo actualizar el departamento.");
            }

            return (true, "Departamento actualizado correctamente.");
        }

        public async Task<(bool exito, string mensaje)> ActualizarAsync(int id, string nombre)
        {
            var validacionId = ValidarId(id, "Departamento");

            if (!validacionId.esValido)
            {
                return (false, validacionId.mensaje);
            }

            var validacionNombre = ValidarTexto(nombre, "Nombre");

            if (!validacionNombre.esValido)
            {
                return (false, validacionNombre.mensaje);
            }

            _cd.Nombre = nombre.Trim();
            bool resultado = await _cd.ActualizarAsync(id);

            if (!resultado)
            {
                return (false, "No se pudo actualizar el departamento.");
            }

            return (true, "Departamento actualizado correctamente.");
        }


        // ─────────────────────────────────────────
        // DELETE — heredado completo de BaseCN
        // Uso: var (exito, mensaje) = cn.Eliminar(id);
        // ─────────────────────────────────────────
    }
}
