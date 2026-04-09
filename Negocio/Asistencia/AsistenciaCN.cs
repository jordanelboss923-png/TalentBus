using Datos.CD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Asistencia
{
    // TODO enums
    public enum EstadoRegistrado
    {
        Entrada,
        Salida,
        Almuerzo,
        RetornoDeAlmuerzo
    }

    public class AsistenciasCN : BaseCN
    {
        private readonly AsistenciaCD asisCD = new AsistenciaCD();


        // ─────────────────────────────────────────
        // MÉTODOS ABSTRACTOS AUXILIARES
        // ─────────────────────────────────────────

        protected override string ObtenerNombreEntidad()
        {
            return "Asistencia";
        }

        protected override bool EjecutarEliminar(int id)
        {
            return asisCD.Eliminar(id);
        }

        protected override async Task<bool> EjecutarEliminarAsync(int id)
        {
            bool resultado = await asisCD.EliminarAsync(id);
            return resultado;
        }


        // ─────────────────────────────────────────
        // MÉTODO PRIVADO AUXILIAR
        // **Convierte el enum a string compatible con la BD**
        // ─────────────────────────────────────────

        private string ConvertirTipoAString(EstadoRegistrado tipo)
        {
            if (tipo == EstadoRegistrado.RetornoDeAlmuerzo)
            {
                return "Retorno de Almuerzo";
            }

            return tipo.ToString();
        }

        private void AsignarPropiedades(int idEmpleado, EstadoRegistrado tipo)
        {
            asisCD.IdEmpleado = idEmpleado;
            asisCD.Descripcion = ConvertirTipoAString(tipo);
        }


        // ─────────────────────────────────────────
        // CREATE
        // ─────────────────────────────────────────

        public (bool exito, string mensaje) RegistrarMarcacion(int idEmpleado, EstadoRegistrado tipo)
        {
            // El enum reemplaza la validación de tipo — el compilador
            // garantiza que solo se pueden pasar valores definidos en EstadoRegistrado
            var validacionEmpleado = ValidarId(idEmpleado, "Empleado");

            if (!validacionEmpleado.esValido)
            {
                return (false, validacionEmpleado.mensaje);
            }

            AsignarPropiedades(idEmpleado, tipo);

            bool resultado = asisCD.Insertar();

            if (!resultado)
            {
                return (false, "No se pudo registrar la marcacion.");
            }

            return (true, $"{ConvertirTipoAString(tipo)} registrada correctamente.");
        }

        public async Task<(bool exito, string mensaje)> RegistrarMarcacionAsync(int idEmpleado,
                                                                                  EstadoRegistrado tipo)
        {
            var validacionEmpleado = ValidarId(idEmpleado, "Empleado");

            if (!validacionEmpleado.esValido)
            {
                return (false, validacionEmpleado.mensaje);
            }

            AsignarPropiedades(idEmpleado, tipo);

            bool resultado = await asisCD.InsertarAsync();

            if (!resultado)
            {
                return (false, "No se pudo registrar la marcacion.");
            }

            return (true, $"{ConvertirTipoAString(tipo)} registrada correctamente.");
        }


        // ─────────────────────────────────────────
        // READ
        // ─────────────────────────────────────────

        public override DataTable ObtenerTodos()
        {
            DataTable tabla = asisCD.ObtenerTodos();
            return tabla;
        }

        public override async Task<DataTable> ObtenerTodosAsync()
        {
            DataTable tabla = await asisCD.ObtenerTodosAsync();
            return tabla;
        }

        public override DataTable ObtenerPorId(int id)
        {
            var validacion = ValidarId(id, "Asistencia");

            if (!validacion.esValido)
            {
                return new DataTable();
            }

            DataTable tabla = asisCD.ObtenerPorId(id);
            return tabla;
        }

        public override async Task<DataTable> ObtenerPorIdAsync(int id)
        {
            var validacion = ValidarId(id, "Asistencia");

            if (!validacion.esValido)
            {
                return new DataTable();
            }

            DataTable tabla = await asisCD.ObtenerPorIdAsync(id);
            return tabla;
        }

        public DataTable ObtenerPorEmpleado(int idEmpleado)
        {
            var validacion = ValidarId(idEmpleado, "Empleado");

            if (!validacion.esValido)
            {
                return new DataTable();
            }

            DataTable tabla = asisCD.ObtenerPorEmpleado(idEmpleado);
            return tabla;
        }


        // ─────────────────────────────────────────
        // DELETE — heredado completo de BaseCN
        // Uso: var (exito, mensaje) = cn.Eliminar(id);
        // ─────────────────────────────────────────
    }
}
