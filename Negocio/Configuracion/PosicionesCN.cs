using Datos.CD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Configuracion
{
    public class PosicionesCN : BaseCN
    {
        // Instancia del CD para todas las operaciones con la BD
        private readonly PosicionesCD _cd = new PosicionesCD();


        // ─────────────────────────────────────────
        // MÉTODOS ABSTRACTOS AUXILIARES
        // Implementaciones obligatorias que BaseCN necesita
        // ─────────────────────────────────────────

        protected override string ObtenerNombreEntidad()
        {
            return "Posicion";
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
        // para no repetir el mismo bloque en cada método
        // ─────────────────────────────────────────

        private void AsignarPropiedades(string nombre, decimal salario, int idDepartamento)
        {
            _cd.Nombre = nombre.Trim();
            _cd.Salario = salario;
            _cd.IdDepartamento = idDepartamento;
        }


        // ─────────────────────────────────────────
        // MÉTODO PRIVADO AUXILIAR
        // Valida que el salario sea mayor a 0
        // No se usa ValidarPorcentaje de BaseCN porque
        // el salario no es un porcentaje — puede superar 100
        // ─────────────────────────────────────────

        private (bool esValido, string mensaje) ValidarSalario(decimal salario)
        {
            if (salario <= 0)
            {
                return (false, "El salario debe ser mayor a 0.");
            }

            return (true, string.Empty);
        }


        // ─────────────────────────────────────────
        // CREATE — método propio de PosicionesCN
        // PosicionesCD usa el patrón de propiedades:
        // se asignan los valores al objeto antes de llamar al método
        // ─────────────────────────────────────────

        public (bool exito, string mensaje) Insertar(string nombre, decimal salario,
                                                      int idDepartamento)
        {
            // Validamos el nombre — viene de BaseCN
            var validacionNombre = ValidarTexto(nombre, "Nombre");

            if (!validacionNombre.esValido)
            {
                return (false, validacionNombre.mensaje);
            }

            // Validamos el salario — método propio de PosicionesCN
            var validacionSalario = ValidarSalario(salario);

            if (!validacionSalario.esValido)
            {
                return (false, validacionSalario.mensaje);
            }

            // Validamos que el departamento sea un ID válido — viene de BaseCN
            var validacionDepartamento = ValidarId(idDepartamento, "Departamento");

            if (!validacionDepartamento.esValido)
            {
                return (false, validacionDepartamento.mensaje);
            }

            // Asignamos las propiedades del CD antes de llamar al método
            AsignarPropiedades(nombre, salario, idDepartamento);

            bool resultado = _cd.Insertar();

            if (!resultado)
            {
                return (false, "No se pudo registrar la posicion.");
            }

            return (true, "Posicion registrada correctamente.");
        }

        public async Task<(bool exito, string mensaje)> InsertarAsync(string nombre,
                                                                       decimal salario,
                                                                       int idDepartamento)
        {
            var validacionNombre = ValidarTexto(nombre, "Nombre");

            if (!validacionNombre.esValido)
            {
                return (false, validacionNombre.mensaje);
            }

            var validacionSalario = ValidarSalario(salario);

            if (!validacionSalario.esValido)
            {
                return (false, validacionSalario.mensaje);
            }

            var validacionDepartamento = ValidarId(idDepartamento, "Departamento");

            if (!validacionDepartamento.esValido)
            {
                return (false, validacionDepartamento.mensaje);
            }

            AsignarPropiedades(nombre, salario, idDepartamento);

            bool resultado = await _cd.InsertarAsync();

            if (!resultado)
            {
                return (false, "No se pudo registrar la posicion.");
            }

            return (true, "Posicion registrada correctamente.");
        }


        // ─────────────────────────────────────────
        // READ — implementaciones obligatorias de BaseCN
        // ─────────────────────────────────────────

        // Retorna todas las posiciones con su departamento
        // El JOIN con Departamentos lo hace directamente el CD
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

        // Retorna una posicion específica por su ID
        public override DataTable ObtenerPorId(int id)
        {
            // ValidarId viene de BaseCN — verifica que el ID sea mayor a 0
            var validacion = ValidarId(id, "Posicion");

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
            var validacion = ValidarId(id, "Posicion");

            if (!validacion.esValido)
            {
                return new DataTable();
            }

            DataTable tabla = await _cd.ObtenerPorIdAsync(id);
            return tabla;
        }


        // ─────────────────────────────────────────
        // UPDATE — método propio de PosicionesCN
        // ─────────────────────────────────────────

        public (bool exito, string mensaje) Actualizar(int id, string nombre,
                                                        decimal salario, int idDepartamento)
        {
            // Validamos el ID primero — debe ser un registro existente
            var validacionId = ValidarId(id, "Posicion");

            if (!validacionId.esValido)
            {
                return (false, validacionId.mensaje);
            }

            var validacionNombre = ValidarTexto(nombre, "Nombre");

            if (!validacionNombre.esValido)
            {
                return (false, validacionNombre.mensaje);
            }

            var validacionSalario = ValidarSalario(salario);

            if (!validacionSalario.esValido)
            {
                return (false, validacionSalario.mensaje);
            }

            var validacionDepartamento = ValidarId(idDepartamento, "Departamento");

            if (!validacionDepartamento.esValido)
            {
                return (false, validacionDepartamento.mensaje);
            }

            // Asignamos las propiedades del CD antes de llamar al método
            AsignarPropiedades(nombre, salario, idDepartamento);

            bool resultado = _cd.Actualizar(id);

            if (!resultado)
            {
                return (false, "No se pudo actualizar la posicion.");
            }

            return (true, "Posicion actualizada correctamente.");
        }

        public async Task<(bool exito, string mensaje)> ActualizarAsync(int id, string nombre,
                                                                         decimal salario,
                                                                         int idDepartamento)
        {
            var validacionId = ValidarId(id, "Posicion");

            if (!validacionId.esValido)
            {
                return (false, validacionId.mensaje);
            }

            var validacionNombre = ValidarTexto(nombre, "Nombre");

            if (!validacionNombre.esValido)
            {
                return (false, validacionNombre.mensaje);
            }

            var validacionSalario = ValidarSalario(salario);

            if (!validacionSalario.esValido)
            {
                return (false, validacionSalario.mensaje);
            }

            var validacionDepartamento = ValidarId(idDepartamento, "Departamento");

            if (!validacionDepartamento.esValido)
            {
                return (false, validacionDepartamento.mensaje);
            }

            AsignarPropiedades(nombre, salario, idDepartamento);

            bool resultado = await _cd.ActualizarAsync(id);

            if (!resultado)
            {
                return (false, "No se pudo actualizar la posicion.");
            }

            return (true, "Posicion actualizada correctamente.");
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
