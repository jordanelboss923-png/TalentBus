using Capa_Datos;
using Datos.Conexion;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Datos.Repositorios.Nomina
{
    public class VolantesPagoCD : BaseCD
    {
        protected override string ObtenerNombreTabla() => "VolantesPago";

        // ─── Propiedades ──────────────────────────────────────────────────
        public int IdEmpleado { get; set; }
        public int IdAsignaciones { get; set; } // FK → SalarioST(Id)
        public int IdDeducciones { get; set; } // FK → DeduccionesEmpleado(Id)
        public DateTime FechaEfectividad { get; set; }

        // ─── ObtenerTodos ─────────────────────────────────────────────────
        public override DataTable ObtenerTodos()
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT vp.Id,
                             vp.IdEmpleado,
                             e.CodigoEmpleado,
                             e.Nombre + ' ' + e.Apellido  AS Empleado,
                             pos.Nombre                   AS Posicion,
                             vp.Subtotal,
                             vp.Deducciones,
                             vp.Total,
                             vp.FechaEfectividad,
                             vp.FechaRegistro
                      FROM VolantesPago vp
                      INNER JOIN Empleados  e   ON e.Id   = vp.IdEmpleado
                      INNER JOIN Posiciones pos ON pos.ID = e.IdPosicion
                      ORDER BY vp.FechaEfectividad DESC", con);
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
                    @"SELECT vp.Id,
                             vp.IdEmpleado,
                             e.CodigoEmpleado,
                             e.Nombre + ' ' + e.Apellido  AS Empleado,
                             pos.Nombre                   AS Posicion,
                             vp.Subtotal,
                             vp.Deducciones,
                             vp.Total,
                             vp.FechaEfectividad,
                             vp.FechaRegistro
                      FROM VolantesPago vp
                      INNER JOIN Empleados  e   ON e.Id   = vp.IdEmpleado
                      INNER JOIN Posiciones pos ON pos.ID = e.IdPosicion
                      ORDER BY vp.FechaEfectividad DESC", con);
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
                    @"SELECT vp.Id,
                             vp.IdEmpleado,
                             e.CodigoEmpleado,
                             e.Nombre + ' ' + e.Apellido  AS Empleado,
                             pos.Nombre                   AS Posicion,
                             vp.Subtotal,
                             vp.Deducciones,
                             vp.Total,
                             vp.FechaEfectividad,
                             vp.FechaRegistro
                      FROM VolantesPago vp
                      INNER JOIN Empleados  e   ON e.Id   = vp.IdEmpleado
                      INNER JOIN Posiciones pos ON pos.ID = e.IdPosicion
                      WHERE vp.IdEmpleado = @IdEmpleado
                      ORDER BY vp.FechaEfectividad DESC", con);
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
                    @"SELECT vp.Id,
                             vp.IdEmpleado,
                             e.CodigoEmpleado,
                             e.Nombre + ' ' + e.Apellido  AS Empleado,
                             pos.Nombre                   AS Posicion,
                             vp.Subtotal,
                             vp.Deducciones,
                             vp.Total,
                             vp.FechaEfectividad,
                             vp.FechaRegistro
                      FROM VolantesPago vp
                      INNER JOIN Empleados  e   ON e.Id   = vp.IdEmpleado
                      INNER JOIN Posiciones pos ON pos.ID = e.IdPosicion
                      WHERE vp.Id = @Id", con);
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
                    @"SELECT vp.Id,
                             vp.IdEmpleado,
                             e.CodigoEmpleado,
                             e.Nombre + ' ' + e.Apellido  AS Empleado,
                             pos.Nombre                   AS Posicion,
                             vp.Subtotal,
                             vp.Deducciones,
                             vp.Total,
                             vp.FechaEfectividad,
                             vp.FechaRegistro
                      FROM VolantesPago vp
                      INNER JOIN Empleados  e   ON e.Id   = vp.IdEmpleado
                      INNER JOIN Posiciones pos ON pos.ID = e.IdPosicion
                      WHERE vp.Id = @Id", con);
                da.SelectCommand.Parameters.AddWithValue("@Id", id);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // ─── Helpers para ComboBoxes ──────────────────────────────────────

        /// <summary>Empleados disponibles para el combo.</summary>
        public DataTable MostrarEmpleados()
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT Id, CodigoEmpleado, Nombre + ' ' + Apellido AS NombreCompleto FROM Empleados",
                    con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        /// <summary>Registros de SalarioST del empleado para el combo de período.</summary>
        public DataTable MostrarSalariosPorEmpleado(int idEmpleado)
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT Id,
                             CONVERT(varchar,FechaEfectividad,103) + 
                             '  —  Subtotal: $' + CAST(Total AS varchar) AS Descripcion,
                             FechaEfectividad,
                             Total
                      FROM SalarioST
                      WHERE IdEmpleado = @Id
                      ORDER BY FechaEfectividad DESC", con);
                da.SelectCommand.Parameters.AddWithValue("@Id", idEmpleado);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        /// <summary>Deducciones registradas del empleado para el combo.</summary>
        public DataTable MostrarDeduccionesEmpleado(int idEmpleado)
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT de.Id,
                             d.Nombre + '  —  $' + CAST(de.Monto AS varchar) AS Descripcion,
                             de.Monto,
                             de.FechaEfectividad
                      FROM DeduccionesEmpleado de
                      INNER JOIN Deducciones d ON d.Id = de.IdDeduccion
                      WHERE de.IdEmpleado = @Id
                      ORDER BY de.FechaEfectividad DESC", con);
                da.SelectCommand.Parameters.AddWithValue("@Id", idEmpleado);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // ─── Insertar ─────────────────────────────────────────────────────
        // Subtotal, Deducciones y Total los calcula el trigger trg_VolantesPago_Calcular
        public override bool Insertar()
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                con.Open();
                string sql = @"INSERT INTO VolantesPago
                               (IdEmpleado, IdAsignaciones, IdDeducciones, FechaEfectividad)
                               VALUES (@IdEmpleado, @IdAsignaciones, @IdDeducciones, @FechaEfectividad)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IdEmpleado", IdEmpleado);
                cmd.Parameters.AddWithValue("@IdAsignaciones", IdAsignaciones);
                cmd.Parameters.AddWithValue("@IdDeducciones", IdDeducciones);
                cmd.Parameters.AddWithValue("@FechaEfectividad", FechaEfectividad);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public override async Task<bool> InsertarAsync()
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                string sql = @"INSERT INTO VolantesPago
                               (IdEmpleado, IdAsignaciones, IdDeducciones, FechaEfectividad)
                               VALUES (@IdEmpleado, @IdAsignaciones, @IdDeducciones, @FechaEfectividad)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IdEmpleado", IdEmpleado);
                cmd.Parameters.AddWithValue("@IdAsignaciones", IdAsignaciones);
                cmd.Parameters.AddWithValue("@IdDeducciones", IdDeducciones);
                cmd.Parameters.AddWithValue("@FechaEfectividad", FechaEfectividad);
                await con.OpenAsync();
                return await cmd.ExecuteNonQueryAsync() > 0;
            }
        }

        // ─── Eliminar ─────────────────────────────────────────────────────
        public override bool Eliminar(int id)
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM VolantesPago WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@Id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public override async Task<bool> EliminarAsync(int id)
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM VolantesPago WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@Id", id);
                return await cmd.ExecuteNonQueryAsync() > 0;
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
                        ISNULL(st.Total, 0)                          AS Subtotal,
                        ISNULL(SUM(de.Monto), 0)                     AS TotalDeducciones,
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

        // Actualizar no aplica — los montos los recalcula el trigger automáticamente
        public override bool Actualizar(int id) => throw new NotSupportedException(
            "Los volantes de pago no se editan. Elimine y cree uno nuevo.");
        public override Task<bool> ActualizarAsync(int id) =>
            throw new NotSupportedException(
            "Los volantes de pago no se editan. Elimine y cree uno nuevo.");
    }
}