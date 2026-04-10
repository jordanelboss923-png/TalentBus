using Capa_Datos;
using Datos.Conexion;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Datos.Repositorios.Empleados
{
    public class AsignacionesEmpleadoCD : BaseCD
    {
        //TODO: clase para manejar las operaciones CRUD de la tabla AsignacionesEmpleado, con validaciones y manejo de errores.
        protected override string ObtenerNombreTabla() => "AsignacionesEmpleado";

        // Propiedades que corresponden a las columnas de la tabla AsignacionesEmpleado
        public int IdAsignacion { get; set; }
        public int IdEmpleado { get; set; }
        public int Tipo { get; set; } // 1=Mensual, 2=Quincenal
        public decimal Monto { get; set; }
        public DateTime FechaEfectividad { get; set; }

        //TODO: Métodos CRUD con validaciones y manejo de errores
        public override DataTable ObtenerTodos()
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT ae.Id,
                             ae.IdEmpleado,
                             e.Nombre + ' ' + e.Apellido AS Empleado,
                             ae.IdAsignacion,
                             a.Nombre        AS Asignacion,
                             ae.Tipo,
                             ae.Monto,
                             ae.FechaEfectividad,
                             ae.FechaRegistro
                      FROM AsignacionesEmpleado ae
                      INNER JOIN Empleados    e ON ae.IdEmpleado   = e.Id
                      INNER JOIN Asignaciones a ON ae.IdAsignacion = a.Id", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        //TODO: versión asíncrona de ObtenerTodos
        public override async Task<DataTable> ObtenerTodosAsync()
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                await con.OpenAsync();
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT ae.Id,
                             ae.IdEmpleado,
                             e.Nombre + ' ' + e.Apellido AS Empleado,
                             ae.IdAsignacion,
                             a.Nombre        AS Asignacion,
                             ae.Tipo,
                             ae.Monto,
                             ae.FechaEfectividad,
                             ae.FechaRegistro
                      FROM AsignacionesEmpleado ae
                      INNER JOIN Empleados    e ON ae.IdEmpleado   = e.Id
                      INNER JOIN Asignaciones a ON ae.IdAsignacion = a.Id", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        //TODO: Obtener por Id con validación de entrada y manejo de errores
        public override DataTable ObtenerPorId(int id)
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT ae.Id,
                             ae.IdEmpleado,
                             e.Nombre + ' ' + e.Apellido AS Empleado,
                             ae.IdAsignacion,
                             a.Nombre        AS Asignacion,
                             ae.Tipo,
                             ae.Monto,
                             ae.FechaEfectividad,
                             ae.FechaRegistro
                      FROM AsignacionesEmpleado ae
                      INNER JOIN Empleados    e ON ae.IdEmpleado   = e.Id
                      INNER JOIN Asignaciones a ON ae.IdAsignacion = a.Id
                      WHERE ae.Id = @Id", con);
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
                    @"SELECT ae.Id,
                             ae.IdEmpleado,
                             e.Nombre + ' ' + e.Apellido AS Empleado,
                             ae.IdAsignacion,
                             a.Nombre        AS Asignacion,
                             ae.Tipo,
                             ae.Monto,
                             ae.FechaEfectividad,
                             ae.FechaRegistro
                      FROM AsignacionesEmpleado ae
                      INNER JOIN Empleados    e ON ae.IdEmpleado   = e.Id
                      INNER JOIN Asignaciones a ON ae.IdAsignacion = a.Id
                      WHERE ae.Id = @Id", con);
                da.SelectCommand.Parameters.AddWithValue("@Id", id);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // ─── Helpers ComboBox ─────────────────────────────────────────────
        public DataTable MostrarAsignaciones()
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT Id, Nombre FROM Asignaciones", con);
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

        // ─── Insertar ─────────────────────────────────────────────────────
        public override bool Insertar()
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                string sql = @"INSERT INTO AsignacionesEmpleado
                               (IdAsignacion, IdEmpleado, Tipo, Monto, FechaEfectividad)
                               VALUES (@IdAsignacion, @IdEmpleado, @Tipo, @Monto, @FechaEfectividad)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IdAsignacion", IdAsignacion);
                cmd.Parameters.AddWithValue("@IdEmpleado", IdEmpleado);
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
                string sql = @"INSERT INTO AsignacionesEmpleado
                               (IdAsignacion, IdEmpleado, Tipo, Monto, FechaEfectividad)
                               VALUES (@IdAsignacion, @IdEmpleado, @Tipo, @Monto, @FechaEfectividad)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IdAsignacion", IdAsignacion);
                cmd.Parameters.AddWithValue("@IdEmpleado", IdEmpleado);
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
                string sql = @"UPDATE AsignacionesEmpleado SET
                               IdAsignacion     = @IdAsignacion,
                               IdEmpleado       = @IdEmpleado,
                               Tipo             = @Tipo,
                               Monto            = @Monto,
                               FechaEfectividad = @FechaEfectividad
                               WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IdAsignacion", IdAsignacion);
                cmd.Parameters.AddWithValue("@IdEmpleado", IdEmpleado);
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
                string sql = @"UPDATE AsignacionesEmpleado SET
                               IdAsignacion     = @IdAsignacion,
                               IdEmpleado       = @IdEmpleado,
                               Tipo             = @Tipo,
                               Monto            = @Monto,
                               FechaEfectividad = @FechaEfectividad
                               WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IdAsignacion", IdAsignacion);
                cmd.Parameters.AddWithValue("@IdEmpleado", IdEmpleado);
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