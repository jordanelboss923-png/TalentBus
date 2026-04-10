using Capa_Datos;
using Datos.Conexion;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Datos.Repositorios.Empleados
{
    public class DeduccionesEmpleadoCD : BaseCD
    {
        protected override string ObtenerNombreTabla() => "DeduccionesEmpleado";

        public int IdDeduccion { get; set; }
        public int IdEmpleado { get; set; }
        public int IdSubtotal { get; set; }
        public int Tipo { get; set; } // 1 = Mensual, 2 = Quincenal
        public decimal Monto { get; set; }
        public DateTime FechaEfectividad { get; set; }

        // ─── ObtenerTodos ─────────────────────────────────────────────────
        public override DataTable ObtenerTodos()
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT de.Id,
                             e.Nombre + ' ' + e.Apellido AS Empleado,
                             d.Nombre AS Deduccion,
                             de.Tipo,
                             de.Monto,
                             de.FechaEfectividad,
                             de.FechaRegistro
                      FROM DeduccionesEmpleado de
                      INNER JOIN Empleados   e ON de.IdEmpleado  = e.Id
                      INNER JOIN Deducciones d ON de.IdDeduccion = d.Id", con);
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
                    @"SELECT de.Id,
                             e.Nombre + ' ' + e.Apellido AS Empleado,
                             d.Nombre AS Deduccion,
                             de.Tipo,
                             de.Monto,
                             de.FechaEfectividad,
                             de.FechaRegistro
                      FROM DeduccionesEmpleado de
                      INNER JOIN Empleados   e ON de.IdEmpleado  = e.Id
                      INNER JOIN Deducciones d ON de.IdDeduccion = d.Id", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // ─── Helpers ──────────────────────────────────────────────────────
        public DataTable MostrarDeducciones()
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT Id, Nombre FROM Deducciones", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable MostrarEmpleados()
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT Id, Nombre + ' ' + Apellido AS NombreCompleto FROM Empleados", con);
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
                    @"SELECT de.Id,
                             e.Nombre + ' ' + e.Apellido AS Empleado,
                             d.Nombre AS Deduccion,
                             de.Tipo,
                             de.Monto,
                             de.FechaEfectividad,
                             de.FechaRegistro
                      FROM DeduccionesEmpleado de
                      INNER JOIN Empleados   e ON de.IdEmpleado  = e.Id
                      INNER JOIN Deducciones d ON de.IdDeduccion = d.Id
                      WHERE de.Id = @Id", con);
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
                    @"SELECT de.Id,
                             e.Nombre + ' ' + e.Apellido AS Empleado,
                             d.Nombre AS Deduccion,
                             de.Tipo,
                             de.Monto,
                             de.FechaEfectividad,
                             de.FechaRegistro
                      FROM DeduccionesEmpleado de
                      INNER JOIN Empleados   e ON de.IdEmpleado  = e.Id
                      INNER JOIN Deducciones d ON de.IdDeduccion = d.Id
                      WHERE de.Id = @Id", con);
                da.SelectCommand.Parameters.AddWithValue("@Id", id);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // ─── Insertar ─────────────────────────────────────────────────────
        public override bool Insertar()
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                string sql = @"INSERT INTO DeduccionesEmpleado
                               (IdDeduccion, IdEmpleado, IdSubtotal, Tipo, Monto, FechaEfectividad)
                               VALUES (@IdDeduccion, @IdEmpleado, @IdSubtotal, @Tipo, @Monto, @FechaEfectividad)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IdDeduccion", IdDeduccion);
                cmd.Parameters.AddWithValue("@IdEmpleado", IdEmpleado);
                cmd.Parameters.AddWithValue("@IdSubtotal", IdSubtotal);
                cmd.Parameters.AddWithValue("@Tipo", Tipo);
                cmd.Parameters.AddWithValue("@Monto", Monto);
                cmd.Parameters.AddWithValue("@FechaEfectividad", FechaEfectividad);
                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public override async Task<bool> InsertarAsync()
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                string sql = @"INSERT INTO DeduccionesEmpleado
                               (IdDeduccion, IdEmpleado, IdSubtotal, Tipo, Monto, FechaEfectividad)
                               VALUES (@IdDeduccion, @IdEmpleado, @IdSubtotal, @Tipo, @Monto, @FechaEfectividad)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IdDeduccion", IdDeduccion);
                cmd.Parameters.AddWithValue("@IdEmpleado", IdEmpleado);
                cmd.Parameters.AddWithValue("@IdSubtotal", IdSubtotal);
                cmd.Parameters.AddWithValue("@Tipo", Tipo);
                cmd.Parameters.AddWithValue("@Monto", Monto);
                cmd.Parameters.AddWithValue("@FechaEfectividad", FechaEfectividad);
                await con.OpenAsync();
                return await cmd.ExecuteNonQueryAsync() > 0;
            }
        }

        // ─── Actualizar ───────────────────────────────────────────────────
        public override bool Actualizar(int id)
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                string sql = @"UPDATE DeduccionesEmpleado SET
                               IdDeduccion      = @IdDeduccion,
                               IdEmpleado       = @IdEmpleado,
                               IdSubtotal       = @IdSubtotal,
                               Tipo             = @Tipo,
                               Monto            = @Monto,
                               FechaEfectividad = @FechaEfectividad
                               WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IdDeduccion", IdDeduccion);
                cmd.Parameters.AddWithValue("@IdEmpleado", IdEmpleado);
                cmd.Parameters.AddWithValue("@IdSubtotal", IdSubtotal);
                cmd.Parameters.AddWithValue("@Tipo", Tipo);
                cmd.Parameters.AddWithValue("@Monto", Monto);
                cmd.Parameters.AddWithValue("@FechaEfectividad", FechaEfectividad);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public override async Task<bool> ActualizarAsync(int id)
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                string sql = @"UPDATE DeduccionesEmpleado SET
                               IdDeduccion      = @IdDeduccion,
                               IdEmpleado       = @IdEmpleado,
                               IdSubtotal       = @IdSubtotal,
                               Tipo             = @Tipo,
                               Monto            = @Monto,
                               FechaEfectividad = @FechaEfectividad
                               WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IdDeduccion", IdDeduccion);
                cmd.Parameters.AddWithValue("@IdEmpleado", IdEmpleado);
                cmd.Parameters.AddWithValue("@IdSubtotal", IdSubtotal);
                cmd.Parameters.AddWithValue("@Tipo", Tipo);
                cmd.Parameters.AddWithValue("@Monto", Monto);
                cmd.Parameters.AddWithValue("@FechaEfectividad", FechaEfectividad);
                cmd.Parameters.AddWithValue("@Id", id);
                await con.OpenAsync();
                return await cmd.ExecuteNonQueryAsync() > 0;
            }
        }
    }
}
