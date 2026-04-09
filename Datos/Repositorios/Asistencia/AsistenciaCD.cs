using Capa_Datos;
using Datos.Conexion;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Datos.CD
{
    
    public class AsistenciaCD : BaseCD
    {
        
        public int IdEmpleado { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaHora { get; set; }

       
        protected override string ObtenerNombreTabla()
        {
            return "Asistencias";
        }

        
        public override DataTable ObtenerTodos()
        {
            string query = @"SELECT a.Id,
                                    a.IdEmpleado,
                                    e.Nombre + ' ' + e.Apellido AS NombreEmpleado,
                                    a.Descripcion,
                                    a.FechaHora
                             FROM Asistencias a
                             INNER JOIN Empleados e ON e.Id = a.IdEmpleado
                             ORDER BY a.FechaHora DESC";

            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection con = ConexionDB.AbrirConexion())
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(tabla);
                }
            }
            catch (SqlException ex)
            {
                
                throw new Exception("Error al obtener asistencias: " + ex.Message);
            }

            return tabla;
        }

       
        public override DataTable ObtenerPorId(int id)
        {
            string query = @"SELECT a.Id,
                                    a.IdEmpleado,
                                    e.Nombre + ' ' + e.Apellido AS NombreEmpleado,
                                    a.Descripcion,
                                    a.FechaHora
                             FROM Asistencias a
                             INNER JOIN Empleados e ON e.Id = a.IdEmpleado
                             WHERE a.Id = @Id";

            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection con = ConexionDB.AbrirConexion())
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(tabla);
                }
            }
            catch (SqlException ex)
            {
                
                throw new Exception("Error al obtener asistencia: " + ex.Message);
            }

            return tabla;
        }

        
        public DataTable ObtenerPorEmpleado(int idEmpleado)
        {
            string query = @"SELECT a.Id,
                                    a.IdEmpleado,
                                    e.Nombre + ' ' + e.Apellido AS NombreEmpleado,
                                    a.Descripcion,
                                    a.FechaHora
                             FROM Asistencias a
                             INNER JOIN Empleados e ON e.Id = a.IdEmpleado
                             WHERE a.IdEmpleado = @IdEmpleado
                             ORDER BY a.FechaHora DESC";

            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection con = ConexionDB.AbrirConexion())
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@IdEmpleado", idEmpleado);
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(tabla);
                }
            }
            catch (SqlException ex)
            {
                
                throw new Exception("Error al obtener asistencia del empleado: " + ex.Message);
            }

            return tabla;
        }

       
        public override bool Insertar()
        {
            string query = @"INSERT INTO Asistencias (IdEmpleado, Descripcion)
                             VALUES (@IdEmpleado, @Descripcion)";

            try
            {
                using (SqlConnection con = ConexionDB.AbrirConexion())
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@IdEmpleado", this.IdEmpleado);
                    cmd.Parameters.AddWithValue("@Descripcion", this.Descripcion);
                    con.Open();
                    int filas = cmd.ExecuteNonQuery();
                    return filas > 0;
                }
            }
            catch (SqlException ex)
            {
               
                throw new Exception("Error al insertar asistencia: " + ex.Message);
            }
        }

       
        public override bool Actualizar(int id)
        {
            string query = @"UPDATE Asistencias
                             SET Descripcion = @Descripcion
                             WHERE Id = @Id";

            try
            {
                using (SqlConnection con = ConexionDB.AbrirConexion())
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Descripcion", this.Descripcion);
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    int filas = cmd.ExecuteNonQuery();
                    return filas > 0;
                }
            }
            catch (SqlException ex)
            {
                
                throw new Exception("Error al actualizar asistencia: " + ex.Message);
            }
        }

        
        public override async Task<DataTable> ObtenerTodosAsync()
        {
            string query = @"SELECT a.Id,
                                    a.IdEmpleado,
                                    e.Nombre + ' ' + e.Apellido AS NombreEmpleado,
                                    a.Descripcion,
                                    a.FechaHora
                             FROM Asistencias a
                             INNER JOIN Empleados e ON e.Id = a.IdEmpleado
                             ORDER BY a.FechaHora DESC";

            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection con = ConexionDB.AbrirConexion())
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    await con.OpenAsync();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(tabla);
                }
            }
            catch (SqlException ex)
            {
                
                throw new Exception("Error al obtener asistencias: " + ex.Message);
            }

            return tabla;
        }

        
        public override async Task<DataTable> ObtenerPorIdAsync(int id)
        {
            string query = @"SELECT a.Id,
                                    a.IdEmpleado,
                                    e.Nombre + ' ' + e.Apellido AS NombreEmpleado,
                                    a.Descripcion,
                                    a.FechaHora
                             FROM Asistencias a
                             INNER JOIN Empleados e ON e.Id = a.IdEmpleado
                             WHERE a.Id = @Id";

            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection con = ConexionDB.AbrirConexion())
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Id", id);
                    await con.OpenAsync();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(tabla);
                }
            }
            catch (SqlException ex)
            {
                
                throw new Exception("Error al obtener asistencia: " + ex.Message);
            }

            return tabla;
        }

        
        public override async Task<bool> InsertarAsync()
        {
            string query = @"INSERT INTO Asistencias (IdEmpleado, Descripcion)
                             VALUES (@IdEmpleado, @Descripcion)";

            try
            {
                using (SqlConnection con = ConexionDB.AbrirConexion())
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@IdEmpleado", this.IdEmpleado);
                    cmd.Parameters.AddWithValue("@Descripcion", this.Descripcion);
                    await con.OpenAsync();
                    int filas = await cmd.ExecuteNonQueryAsync();
                    return filas > 0;
                }
            }
            catch (SqlException ex)
            {
                
                throw new Exception("Error al insertar asistencia: " + ex.Message);
            }
        }

        
        public override async Task<bool> ActualizarAsync(int id)
        {
            string query = @"UPDATE Asistencias
                             SET Descripcion = @Descripcion
                             WHERE Id = @Id";

            try
            {
                using (SqlConnection con = ConexionDB.AbrirConexion())
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Descripcion", this.Descripcion);
                    cmd.Parameters.AddWithValue("@Id", id);
                    await con.OpenAsync();
                    int filas = await cmd.ExecuteNonQueryAsync();
                    return filas > 0;
                }
            }
            catch (SqlException ex)
            {
                
                throw new Exception("Error al actualizar asistencia: " + ex.Message);
            }
        }
    }
}