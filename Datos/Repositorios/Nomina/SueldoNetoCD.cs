using Capa_Datos;
using Datos.Conexion;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Datos.Repositorios.Nomina
{
    /// <summary>
    /// Capa de datos para la tabla SalarioST (sueldo neto antes de deducciones).
    /// SalarioST se crea automáticamente via trigger trg_SalarioST_Calcular
    /// al insertar en AsignacionesEmpleado — no se inserta manualmente.
    /// </summary>
    public class SueldoNetoCD : BaseCD
    {
        protected override string ObtenerNombreTabla() => "SalarioST";

        // ─── ObtenerTodos ─────────────────────────────────────────────────
        public override DataTable ObtenerTodos()
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT st.Id,
                             st.IdEmpleado,
                             e.CodigoEmpleado,
                             e.Nombre + ' ' + e.Apellido AS Empleado,
                             pos.Nombre                  AS Posicion,
                             st.SueldoBase               AS Sueldobase,
                             st.Asignacion,
                             st.Total,
                             st.FechaEfectividad,
                             st.FechaRegistro
                      FROM SalarioST st
                      INNER JOIN Empleados  e   ON e.Id   = st.IdEmpleado
                      INNER JOIN Posiciones pos ON pos.ID = e.IdPosicion
                      ORDER BY st.FechaEfectividad DESC", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public override async Task<DataTable> ObtenerTodosAsync()
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                await con.OpenAsync();
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT st.Id,
                             st.IdEmpleado,
                             e.CodigoEmpleado,
                             e.Nombre + ' ' + e.Apellido AS Empleado,
                             pos.Nombre                  AS Posicion,
                             st.SueldoBase               AS Sueldobase,
                             st.Asignacion,
                             st.Total,
                             st.FechaEfectividad,
                             st.FechaRegistro
                      FROM SalarioST st
                      INNER JOIN Empleados  e   ON e.Id   = st.IdEmpleado
                      INNER JOIN Posiciones pos ON pos.ID = e.IdPosicion
                      ORDER BY st.FechaEfectividad DESC", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // ─── ObtenerPorEmpleado ───────────────────────────────────────────
        public DataTable ObtenerPorEmpleado(int idEmpleado)
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT st.Id,
                             st.IdEmpleado,
                             e.CodigoEmpleado,
                             e.Nombre + ' ' + e.Apellido AS Empleado,
                             pos.Nombre                  AS Posicion,
                             st.SueldoBase               AS Sueldobase,
                             st.Asignacion,
                             st.Total,
                             st.FechaEfectividad,
                             st.FechaRegistro
                      FROM SalarioST st
                      INNER JOIN Empleados  e   ON e.Id   = st.IdEmpleado
                      INNER JOIN Posiciones pos ON pos.ID = e.IdPosicion
                      WHERE st.IdEmpleado = @IdEmpleado
                      ORDER BY st.FechaEfectividad DESC", con);
                da.SelectCommand.Parameters.AddWithValue("@IdEmpleado", idEmpleado);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // ─── ObtenerPorId ─────────────────────────────────────────────────
        public override DataTable ObtenerPorId(int id)
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT st.Id,
                             st.IdEmpleado,
                             e.CodigoEmpleado,
                             e.Nombre + ' ' + e.Apellido AS Empleado,
                             pos.Nombre                  AS Posicion,
                             st.SueldoBase               AS Sueldobase,
                             st.Asignacion,
                             st.Total,
                             st.FechaEfectividad,
                             st.FechaRegistro
                      FROM SalarioST st
                      INNER JOIN Empleados  e   ON e.Id   = st.IdEmpleado
                      INNER JOIN Posiciones pos ON pos.ID = e.IdPosicion
                      WHERE st.Id = @Id", con);
                da.SelectCommand.Parameters.AddWithValue("@Id", id);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public override async Task<DataTable> ObtenerPorIdAsync(int id)
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                await con.OpenAsync();
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT st.Id,
                             st.IdEmpleado,
                             e.CodigoEmpleado,
                             e.Nombre + ' ' + e.Apellido AS Empleado,
                             pos.Nombre                  AS Posicion,
                             st.SueldoBase               AS Sueldobase,
                             st.Asignacion,
                             st.Total,
                             st.FechaEfectividad,
                             st.FechaRegistro
                      FROM SalarioST st
                      INNER JOIN Empleados  e   ON e.Id   = st.IdEmpleado
                      INNER JOIN Posiciones pos ON pos.ID = e.IdPosicion
                      WHERE st.Id = @Id", con);
                da.SelectCommand.Parameters.AddWithValue("@Id", id);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // ─── ObtenerVolanteCompleto ───────────────────────────────────────
        /// <summary>
        /// Devuelve TotalDeducciones y SalarioNeto para un empleado en una fecha.
        /// </summary>
        public DataTable ObtenerVolanteCompleto(int idEmpleado, DateTime fecha)
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT
                        ISNULL(st.Total, 0)                             AS Subtotal,
                        ISNULL(SUM(de.Monto), 0)                        AS TotalDeducciones,
                        ISNULL(st.Total, 0) - ISNULL(SUM(de.Monto), 0) AS SalarioNeto
                      FROM SalarioST st
                      LEFT JOIN DeduccionesEmpleado de
                             ON de.IdEmpleado       = st.IdEmpleado
                            AND de.FechaEfectividad = st.FechaEfectividad
                      WHERE st.IdEmpleado       = @IdEmpleado
                        AND st.FechaEfectividad = @Fecha
                      GROUP BY st.Total", con);
                da.SelectCommand.Parameters.AddWithValue("@IdEmpleado", idEmpleado);
                da.SelectCommand.Parameters.AddWithValue("@Fecha", fecha.Date);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // SalarioST se genera por trigger — no se inserta/actualiza manualmente
        public override bool Insertar() =>
            throw new NotSupportedException("SalarioST se genera automáticamente por trigger.");
        public override Task<bool> InsertarAsync() =>
            throw new NotSupportedException("SalarioST se genera automáticamente por trigger.");
        public override bool Actualizar(int id) =>
            throw new NotSupportedException("SalarioST se actualiza automáticamente por trigger.");
        public override Task<bool> ActualizarAsync(int id) =>
            throw new NotSupportedException("SalarioST se actualiza automáticamente por trigger.");
    }
}
