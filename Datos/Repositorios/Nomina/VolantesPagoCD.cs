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
        protected override string ObtenerNombreTabla()
        {
            return "SalarioST";
        }

        // ─────────────────────────────────────────────────────
        // Propiedades para Insertar/Actualizar
        // ─────────────────────────────────────────────────────
        public int IdEmpleado { get; set; }
        public decimal SueldoBase { get; set; }
        public decimal Asignacion { get; set; }
        public decimal Total { get; set; }
        public DateTime FechaEfectividad { get; set; }

        // ─────────────────────────────────────────────────────
        // ObtenerTodos
        // ─────────────────────────────────────────────────────
        public override DataTable ObtenerTodos()
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT s.Id,
                             e.CodigoEmpleado,
                             e.Nombre + ' ' + e.Apellido AS Empleado,
                             p.Nombre                    AS Posicion,
                             s.Sueldobase,
                             s.Asignacion,
                             s.Total,
                             s.FechaEfectividad,
                             s.FechaRegistro
                      FROM SalarioST s
                      INNER JOIN Empleados  e ON s.IdEmpleado  = e.Id
                      INNER JOIN Posiciones p ON e.IdPosicion  = p.ID", con);
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
                    @"SELECT s.Id,
                             e.CodigoEmpleado,
                             e.Nombre + ' ' + e.Apellido AS Empleado,
                             p.Nombre                    AS Posicion,
                             s.Sueldobase,
                             s.Asignacion,
                             s.Total,
                             s.FechaEfectividad,
                             s.FechaRegistro
                      FROM SalarioST s
                      INNER JOIN Empleados  e ON s.IdEmpleado = e.Id
                      INNER JOIN Posiciones p ON e.IdPosicion = p.ID", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // ─────────────────────────────────────────────────────
        // ObtenerPorId
        // ─────────────────────────────────────────────────────
        public override DataTable ObtenerPorId(int id)
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT s.Id,
                             e.CodigoEmpleado,
                             e.Nombre + ' ' + e.Apellido AS Empleado,
                             p.Nombre                    AS Posicion,
                             s.Sueldobase,
                             s.Asignacion,
                             s.Total,
                             s.FechaEfectividad,
                             s.FechaRegistro
                      FROM SalarioST s
                      INNER JOIN Empleados  e ON s.IdEmpleado = e.Id
                      INNER JOIN Posiciones p ON e.IdPosicion = p.ID
                      WHERE s.Id = @Id", con);
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
                    @"SELECT s.Id,
                             e.CodigoEmpleado,
                             e.Nombre + ' ' + e.Apellido AS Empleado,
                             p.Nombre                    AS Posicion,
                             s.Sueldobase,
                             s.Asignacion,
                             s.Total,
                             s.FechaEfectividad,
                             s.FechaRegistro
                      FROM SalarioST s
                      INNER JOIN Empleados  e ON s.IdEmpleado = e.Id
                      INNER JOIN Posiciones p ON e.IdPosicion = p.ID
                      WHERE s.Id = @Id", con);
                da.SelectCommand.Parameters.AddWithValue("@Id", id);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // ─────────────────────────────────────────────────────
        // ObtenerPorEmpleado (extra útil para el volante)
        // ─────────────────────────────────────────────────────
        public DataTable ObtenerPorEmpleado(int idEmpleado)
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT s.Id,
                             e.CodigoEmpleado,
                             e.Nombre + ' ' + e.Apellido AS Empleado,
                             p.Nombre                    AS Posicion,
                             s.Sueldobase,
                             s.Asignacion,
                             s.Total,
                             s.FechaEfectividad,
                             s.FechaRegistro
                      FROM SalarioST s
                      INNER JOIN Empleados  e ON s.IdEmpleado = e.Id
                      INNER JOIN Posiciones p ON e.IdPosicion = p.ID
                      WHERE s.IdEmpleado = @IdEmpleado
                      ORDER BY s.FechaEfectividad DESC", con);
                da.SelectCommand.Parameters.AddWithValue("@IdEmpleado", idEmpleado);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // ─────────────────────────────────────────────────────
        // ObtenerVolanteCompleto (incluye deducciones)
        // ─────────────────────────────────────────────────────
        public DataTable ObtenerVolanteCompleto(int idEmpleado, DateTime fechaEfectividad)
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT 
                             e.CodigoEmpleado,
                             e.Nombre + ' ' + e.Apellido AS Empleado,
                             p.Nombre                    AS Posicion,
                             s.Sueldobase,
                             s.Asignacion,
                             s.Total                     AS TotalAsignado,
                             ISNULL(SUM(de.Monto), 0)    AS TotalDeducciones,
                             s.Total - ISNULL(SUM(de.Monto), 0) AS SalarioNeto,
                             s.FechaEfectividad
                      FROM SalarioST s
                      INNER JOIN Empleados  e  ON s.IdEmpleado  = e.Id
                      INNER JOIN Posiciones p  ON e.IdPosicion  = p.ID
                      LEFT  JOIN DeduccionesEmpleado de 
                             ON de.IdEmpleado       = s.IdEmpleado
                            AND de.IdSubtotal       = s.Id
                      WHERE s.IdEmpleado       = @IdEmpleado
                        AND s.FechaEfectividad = @Fecha
                      GROUP BY e.CodigoEmpleado, e.Nombre, e.Apellido,
                               p.Nombre, s.Sueldobase, s.Asignacion,
                               s.Total, s.FechaEfectividad", con);
                da.SelectCommand.Parameters.AddWithValue("@IdEmpleado", idEmpleado);
                da.SelectCommand.Parameters.AddWithValue("@Fecha", fechaEfectividad);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // ─────────────────────────────────────────────────────
        // Insertar
        // ─────────────────────────────────────────────────────
        public override bool Insertar()
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                string sql = @"INSERT INTO SalarioST
                               (IdEmpleado, Sueldobase, Asignacion, Total, FechaEfectividad)
                               VALUES (@IdEmpleado, @Sueldobase, @Asignacion, @Total, @FechaEfectividad)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IdEmpleado", IdEmpleado);
                cmd.Parameters.AddWithValue("@Sueldobase", SueldoBase);
                cmd.Parameters.AddWithValue("@Asignacion", Asignacion);
                cmd.Parameters.AddWithValue("@Total", Total);
                cmd.Parameters.AddWithValue("@FechaEfectividad", FechaEfectividad);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public override async Task<bool> InsertarAsync()
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                string sql = @"INSERT INTO SalarioST
                               (IdEmpleado, Sueldobase, Asignacion, Total, FechaEfectividad)
                               VALUES (@IdEmpleado, @Sueldobase, @Asignacion, @Total, @FechaEfectividad)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IdEmpleado", IdEmpleado);
                cmd.Parameters.AddWithValue("@Sueldobase", SueldoBase);
                cmd.Parameters.AddWithValue("@Asignacion", Asignacion);
                cmd.Parameters.AddWithValue("@Total", Total);
                cmd.Parameters.AddWithValue("@FechaEfectividad", FechaEfectividad);
                await con.OpenAsync();
                int filas = await cmd.ExecuteNonQueryAsync();
                return filas > 0;
            }
        }

        // ─────────────────────────────────────────────────────
        // Actualizar
        // ─────────────────────────────────────────────────────
        public override bool Actualizar(int id)
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                string sql = @"UPDATE SalarioST SET
                               Sueldobase       = @Sueldobase,
                               Asignacion       = @Asignacion,
                               Total            = @Total,
                               FechaEfectividad = @FechaEfectividad
                               WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Sueldobase", SueldoBase);
                cmd.Parameters.AddWithValue("@Asignacion", Asignacion);
                cmd.Parameters.AddWithValue("@Total", Total);
                cmd.Parameters.AddWithValue("@FechaEfectividad", FechaEfectividad);
                cmd.Parameters.AddWithValue("@Id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public override async Task<bool> ActualizarAsync(int id)
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                string sql = @"UPDATE SalarioST SET
                               Sueldobase       = @Sueldobase,
                               Asignacion       = @Asignacion,
                               Total            = @Total,
                               FechaEfectividad = @FechaEfectividad
                               WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Sueldobase", SueldoBase);
                cmd.Parameters.AddWithValue("@Asignacion", Asignacion);
                cmd.Parameters.AddWithValue("@Total", Total);
                cmd.Parameters.AddWithValue("@FechaEfectividad", FechaEfectividad);
                cmd.Parameters.AddWithValue("@Id", id);
                await con.OpenAsync();
                int filas = await cmd.ExecuteNonQueryAsync();
                return filas > 0;
            }
        }
    }
}