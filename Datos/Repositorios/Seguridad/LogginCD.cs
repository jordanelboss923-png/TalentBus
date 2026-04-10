using Capa_Datos;
using Datos.Conexion;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios.Seguridad
{
    public class LogginCD : BaseCD
    {
        protected override string ObtenerNombreTabla()
        {
            return "Loggin";
        }

        // ─────────────────────────────────────────────────────
        // Propiedades para Insertar/Actualizar
        // ─────────────────────────────────────────────────────
        public int IdEmpleado { get; set; }
        public string Clave { get; set; } // Se recibe en texto, se guarda encriptada

        // ─────────────────────────────────────────────────────
        // Metodo privado: convierte texto a VARBINARY (bytes)
        // para guardar la clave encriptada en la BD
        // ─────────────────────────────────────────────────────
        private byte[] EncriptarClave(string clave)
        {
            using (var sha1 = System.Security.Cryptography.SHA1.Create())
            {
                return sha1.ComputeHash(Encoding.UTF8.GetBytes(clave));
            }
        }
        // ─────────────────────────────────────────────────────
        // ObtenerTodos
        // ─────────────────────────────────────────────────────
        public override DataTable ObtenerTodos()
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT l.Id,
                             l.Usser,
                             e.Nombre + ' ' + e.Apellido AS Empleado,
                             e.CodigoEmpleado
                      FROM Loggin l
                      INNER JOIN Empleados e ON l.IdEmpleado = e.Id", con);
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
                    @"SELECT l.Id,
                             l.Usser,
                             e.Nombre + ' ' + e.Apellido AS Empleado,
                             e.CodigoEmpleado
                      FROM Loggin l
                      INNER JOIN Empleados e ON l.IdEmpleado = e.Id", con);
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
                    @"SELECT l.Id,
                             l.Usser,
                             e.Nombre + ' ' + e.Apellido AS Empleado,
                             e.CodigoEmpleado
                      FROM Loggin l
                      INNER JOIN Empleados e ON l.IdEmpleado = e.Id
                      WHERE l.Id = @Id", con);
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
                    @"SELECT l.Id,
                             l.Usser,
                             e.Nombre + ' ' + e.Apellido AS Empleado,
                             e.CodigoEmpleado
                      FROM Loggin l
                      INNER JOIN Empleados e ON l.IdEmpleado = e.Id
                      WHERE l.Id = @Id", con);
                da.SelectCommand.Parameters.AddWithValue("@Id", id);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // ─────────────────────────────────────────────────────
        // Insertar
        // El trigger trg_Loggin_Usser asigna el Usser solo
        // ─────────────────────────────────────────────────────
        public override bool Insertar()
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                string sql = @"INSERT INTO Loggin
                               (IdEmpleado, Clave)
                               VALUES (@IdEmpleado, @Clave)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IdEmpleado", IdEmpleado);
                cmd.Parameters.AddWithValue("@Clave", EncriptarClave(Clave));
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public override async Task<bool> InsertarAsync()
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                string sql = @"INSERT INTO Loggin
                               (IdEmpleado, Clave)
                               VALUES (@IdEmpleado, @Clave)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IdEmpleado", IdEmpleado);
                cmd.Parameters.AddWithValue("@Clave", EncriptarClave(Clave));
                await con.OpenAsync();
                int filas = await cmd.ExecuteNonQueryAsync();
                return filas > 0;
            }
        }

        // ─────────────────────────────────────────────────────
        // Actualizar (cambiar clave)
        // ─────────────────────────────────────────────────────
        public override bool Actualizar(int id)
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                string sql = @"UPDATE Loggin SET
                               Clave = @Clave
                               WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Clave", EncriptarClave(Clave));
                cmd.Parameters.AddWithValue("@Id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public override async Task<bool> ActualizarAsync(int id)
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                string sql = @"UPDATE Loggin SET
                               Clave = @Clave
                               WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Clave", EncriptarClave(Clave));
                cmd.Parameters.AddWithValue("@Id", id);
                await con.OpenAsync();
                int filas = await cmd.ExecuteNonQueryAsync();
                return filas > 0;
            }
        }

        // ─────────────────────────────────────────────────────
        // Validar login (usuario + clave)
        // ─────────────────────────────────────────────────────
        public bool ValidarAcceso(string usser, string clave)
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                string sql = @"SELECT COUNT(1) 
                       FROM Loggin 
                       WHERE Usser = @Usser 
                       AND Clave = @Clave";

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@Usser", SqlDbType.VarChar).Value = usser;
                    cmd.Parameters.Add("@Clave", SqlDbType.VarBinary).Value = EncriptarClave(clave);

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    int resultado = (int)cmd.ExecuteScalar();

                    return resultado > 0;
                }
            }
        }

        public async Task<bool> ValidarAccesoAsync(string usser, string clave)
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                string sql = @"SELECT COUNT(1) 
                               FROM Loggin 
                               WHERE Usser = @Usser 
                               AND   Clave = @Clave";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Usser", usser);
                cmd.Parameters.AddWithValue("@Clave", EncriptarClave(clave));
                await con.OpenAsync();
                int resultado = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                return resultado > 0;
            }
        }
    }
}