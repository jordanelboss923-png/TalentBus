using Capa_Datos;
using Datos.Conexion;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Datos.Repositorios
{
    public class EmpleadosCD : BaseCD
    {
        protected override string ObtenerNombreTabla() => "Empleados";

        public string CodigoEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public int Tipo { get; set; } // 1 = Fijo, 2 = Por hora
        public int IdPosicion { get; set; }

        // ─── ObtenerTodos ─────────────────────────────────────────────────
        public override DataTable ObtenerTodos()
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT e.Id, e.CodigoEmpleado, e.Nombre, e.Apellido,
                             e.Cedula, e.Tipo, e.SalarioBase, e.FechaIngreso,
                             p.Nombre AS Posicion
                      FROM Empleados e
                      INNER JOIN Posiciones p ON e.IdPosicion = p.ID", con);
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
                    @"SELECT e.Id, e.CodigoEmpleado, e.Nombre, e.Apellido,
                             e.Cedula, e.Tipo, e.SalarioBase, e.FechaIngreso,
                             p.Nombre AS Posicion
                      FROM Empleados e
                      INNER JOIN Posiciones p ON e.IdPosicion = p.ID", con);
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
                    @"SELECT e.Id, e.CodigoEmpleado, e.Nombre, e.Apellido,
                             e.Cedula, e.Tipo, e.SalarioBase, e.FechaIngreso,
                             p.Nombre AS Posicion
                      FROM Empleados e
                      INNER JOIN Posiciones p ON e.IdPosicion = p.ID
                      WHERE e.Id = @Id", con);
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
                    @"SELECT e.Id, e.CodigoEmpleado, e.Nombre, e.Apellido,
                             e.Cedula, e.Tipo, e.SalarioBase, e.FechaIngreso,
                             p.Nombre AS Posicion
                      FROM Empleados e
                      INNER JOIN Posiciones p ON e.IdPosicion = p.ID
                      WHERE e.Id = @Id", con);
                da.SelectCommand.Parameters.AddWithValue("@Id", id);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // ─── ObtenerPorCedula ─────────────────────────────────────────────
        public DataTable ObtenerPorCedula(string cedula)
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT e.Id, e.CodigoEmpleado, e.Nombre, e.Apellido,
                             e.Cedula, e.Tipo, e.SalarioBase, e.FechaIngreso,
                             p.Nombre AS Posicion
                      FROM Empleados e
                      INNER JOIN Posiciones p ON e.IdPosicion = p.ID
                      WHERE e.Cedula = @Cedula", con);
                da.SelectCommand.Parameters.AddWithValue("@Cedula", cedula);
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
                string sql = @"INSERT INTO Empleados
                               (CodigoEmpleado, Nombre, Apellido, Cedula, Tipo, IdPosicion)
                               VALUES (@Codigo, @Nombre, @Apellido, @Cedula, @Tipo, @IdPosicion)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Codigo", CodigoEmpleado);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Apellido", Apellido);
                cmd.Parameters.AddWithValue("@Cedula", Cedula);
                cmd.Parameters.AddWithValue("@Tipo", Tipo);
                cmd.Parameters.AddWithValue("@IdPosicion", IdPosicion);
                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public override async Task<bool> InsertarAsync()
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                string sql = @"INSERT INTO Empleados
                               (CodigoEmpleado, Nombre, Apellido, Cedula, Tipo, IdPosicion)
                               VALUES (@Codigo, @Nombre, @Apellido, @Cedula, @Tipo, @IdPosicion)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Codigo", CodigoEmpleado);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Apellido", Apellido);
                cmd.Parameters.AddWithValue("@Cedula", Cedula);
                cmd.Parameters.AddWithValue("@Tipo", Tipo);
                cmd.Parameters.AddWithValue("@IdPosicion", IdPosicion);
                await con.OpenAsync();
                return await cmd.ExecuteNonQueryAsync() > 0;
            }
        }

        // ─── Actualizar ───────────────────────────────────────────────────
        public override bool Actualizar(int id)
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                string sql = @"UPDATE Empleados SET
                               Nombre     = @Nombre,
                               Apellido   = @Apellido,
                               Cedula     = @Cedula,
                               Tipo       = @Tipo,
                               IdPosicion = @IdPosicion
                               WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Apellido", Apellido);
                cmd.Parameters.AddWithValue("@Cedula", Cedula);
                cmd.Parameters.AddWithValue("@Tipo", Tipo);
                cmd.Parameters.AddWithValue("@IdPosicion", IdPosicion);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public override async Task<bool> ActualizarAsync(int id)
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                string sql = @"UPDATE Empleados SET
                               Nombre     = @Nombre,
                               Apellido   = @Apellido,
                               Cedula     = @Cedula,
                               Tipo       = @Tipo,
                               IdPosicion = @IdPosicion
                               WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Apellido", Apellido);
                cmd.Parameters.AddWithValue("@Cedula", Cedula);
                cmd.Parameters.AddWithValue("@Tipo", Tipo);
                cmd.Parameters.AddWithValue("@IdPosicion", IdPosicion);
                cmd.Parameters.AddWithValue("@Id", id);
                await con.OpenAsync();
                return await cmd.ExecuteNonQueryAsync() > 0;
            }
        }
    }
}
