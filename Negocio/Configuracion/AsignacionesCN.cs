using Datos.CD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Configuracion
{
    public class AsignacionesCN : BaseCN
    {
        // Instancia del CD para todas las operaciones con la BD
        private readonly AsignacionesCD asigCD = new AsignacionesCD();


        // ─────────────────────────────────────────
        // MÉTODOS ABSTRACTOS
        // ─────────────────────────────────────────

        protected override string ObtenerNombreEntidad()
        {
            return "Asignacion";
        }

        protected override bool EjecutarEliminar(int id)
        {
            return asigCD.Eliminar(id);
        }

        protected override async Task<bool> EjecutarEliminarAsync(int id)
        {
            bool resultado = await asigCD.EliminarAsync(id);
            return resultado;
        }


        // ─────────────────────────────────────────
        // Prepara la descripcion antes de asignarla al CD
        // Si viene null la deja null, si viene con texto la limpia
        // ─────────────────────────────────────────

        private void AsignarPropiedades(string nombre, decimal porcentaje, string descripcion)
        {
            asigCD.Nombre = nombre.Trim();
            asigCD.Porcentaje = porcentaje;

            if (descripcion != null)
            {
                asigCD.Descripcion = descripcion.Trim();
            }
            else
            {
                asigCD.Descripcion = null;
            }
        }


        // ─────────────────────────────────────────
        // CREATE
        // ─────────────────────────────────────────

        public (bool exito, string mensaje) Insertar(string nombre, decimal porcentaje,
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

            // Asignamos las propiedades del CD antes de llamar al método
            AsignarPropiedades(nombre, porcentaje, descripcion);

            bool resultado = asigCD.Insertar();

            if (!resultado)
            {
                return (false, "No se pudo registrar la asignacion.");
            }

            return (true, "Asignacion registrada correctamente.");
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

            bool resultado = await asigCD.InsertarAsync();

            if (!resultado)
            {
                return (false, "No se pudo registrar la asignacion.");
            }

            return (true, "Asignacion registrada correctamente.");
        }


        // ─────────────────────────────────────────
        // READ
        // ─────────────────────────────────────────

        public override DataTable ObtenerTodos()
        {
            DataTable tabla = asigCD.ObtenerTodos();
            return tabla;
        }

        public override async Task<DataTable> ObtenerTodosAsync()
        {
            DataTable tabla = await asigCD.ObtenerTodosAsync();
            return tabla;
        }

        public override DataTable ObtenerPorId(int id)
        {
            var validacion = ValidarId(id, "Asignacion");

            if (!validacion.esValido)
            {
                return new DataTable();
            }

            DataTable tabla = asigCD.ObtenerPorId(id);
            return tabla;
        }

        public override async Task<DataTable> ObtenerPorIdAsync(int id)
        {
            var validacion = ValidarId(id, "Asignacion");

            if (!validacion.esValido)
            {
                return new DataTable();
            }

            DataTable tabla = await asigCD.ObtenerPorIdAsync(id);
            return tabla;
        }


        // ─────────────────────────────────────────
        // UPDATE
        // ─────────────────────────────────────────

        public (bool exito, string mensaje) Actualizar(int id, string nombre,
                                                        decimal porcentaje, string descripcion)
        {
            var validacionId = ValidarId(id, "Asignacion");

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

            bool resultado = asigCD.Actualizar(id);

            if (!resultado)
            {
                return (false, "No se pudo actualizar la asignacion.");
            }

            return (true, "Asignacion actualizada correctamente.");
        }

        public async Task<(bool exito, string mensaje)> ActualizarAsync(int id, string nombre,
                                                                         decimal porcentaje,
                                                                         string descripcion)
        {
            var validacionId = ValidarId(id, "Asignacion");

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

            bool resultado = await asigCD.ActualizarAsync(id);

            if (!resultado)
            {
                return (false, "No se pudo actualizar la asignacion.");
            }

            return (true, "Asignacion actualizada correctamente.");
        }


        // ─────────────────────────────────────────
        // DELETE — heredado completo de BaseCN
        // Uso: var (exito, mensaje) = cn.Eliminar(id);
        // ─────────────────────────────────────────
    }
}
