using Capa_Datos;
using Datos.Conexion;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Datos.CD
{
    
    public class PosicionesCD : BaseCD
    {
        
        public string Nombre { get; set; }
        public decimal Salario { get; set; }
        public int IdDepartamento { get; set; }

        
        protected override string ObtenerNombreTabla()
        {
            return "Posiciones";
        }

        
        public override DataTable ObtenerTodos()
        {
            string query = @"SELECT p.Id,
                                    p.Nombre,
                                    p.Salario,
                                    d.Nombre AS NombreDepartamento
                             FROM Posiciones p
                             INNER JOIN Departamentos d ON d.Id = p.IdDepartamento";

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
                
                throw new Exception("Error al obtener posiciones: " + ex.Message);
            }

            return tabla;
        }

        
        public override DataTable ObtenerPorId(int id)
        {
            string query = @"SELECT p.Id,
                                    p.Nombre,
                                    p.Salario,
                                    p.IdDepartamento,
                                    d.Nombre AS NombreDepartamento
                             FROM Posiciones p
                             INNER JOIN Departamentos d ON d.Id = p.IdDepartamento
                             WHERE p.Id = @Id";

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
                
                throw new Exception("Error al obtener posicion: " + ex.Message);
            }

            return tabla;
        }

        
        public override bool Insertar()
        {
            string query = @"INSERT INTO Posiciones (Nombre, Salario, IdDepartamento)
                             VALUES (@Nombre, @Salario, @IdDepartamento)";

            try
            {
                using (SqlConnection con = ConexionDB.AbrirConexion())
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Nombre", this.Nombre);
                    cmd.Parameters.AddWithValue("@Salario", this.Salario);
                    cmd.Parameters.AddWithValue("@IdDepartamento", this.IdDepartamento);
                    con.Open();
                    int filas = cmd.ExecuteNonQuery();
                    return filas > 0;
                }
            }
            catch (SqlException ex)
            {
                
                throw new Exception("Error al insertar posicion: " + ex.Message);
            }
        }

        
        public override bool Actualizar(int id)
        {
            string query = @"UPDATE Posiciones
                             SET Nombre         = @Nombre,
                                 Salario        = @Salario,
                                 IdDepartamento = @IdDepartamento
                             WHERE Id = @Id";

            try
            {
                using (SqlConnection con = ConexionDB.AbrirConexion())
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Nombre", this.Nombre);
                    cmd.Parameters.AddWithValue("@Salario", this.Salario);
                    cmd.Parameters.AddWithValue("@IdDepartamento", this.IdDepartamento);
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    int filas = cmd.ExecuteNonQuery();
                    return filas > 0;
                }
            }
            catch (SqlException ex)
            {
                
                throw new Exception("Error al actualizar posicion: " + ex.Message);
            }
        }

        
        public override async Task<DataTable> ObtenerTodosAsync()
        {
            string query = @"SELECT p.Id,
                                    p.Nombre,
                                    p.Salario,
                                    d.Nombre AS NombreDepartamento
                             FROM Posiciones p
                             INNER JOIN Departamentos d ON d.Id = p.IdDepartamento";

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
                
                throw new Exception("Error al obtener posiciones: " + ex.Message);
            }

            return tabla;
        }

        
        public override async Task<DataTable> ObtenerPorIdAsync(int id)
        {
            string query = @"SELECT p.Id,
                                    p.Nombre,
                                    p.Salario,
                                    p.IdDepartamento,
                                    d.Nombre AS NombreDepartamento
                             FROM Posiciones p
                             INNER JOIN Departamentos d ON d.Id = p.IdDepartamento
                             WHERE p.Id = @Id";

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
                
                throw new Exception("Error al obtener posicion: " + ex.Message);
            }

            return tabla;
        }

        
        public override async Task<bool> InsertarAsync()
        {
            string query = @"INSERT INTO Posiciones (Nombre, Salario, IdDepartamento)
                             VALUES (@Nombre, @Salario, @IdDepartamento)";

            try
            {
                using (SqlConnection con = ConexionDB.AbrirConexion())
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Nombre", this.Nombre);
                    cmd.Parameters.AddWithValue("@Salario", this.Salario);
                    cmd.Parameters.AddWithValue("@IdDepartamento", this.IdDepartamento);
                    await con.OpenAsync();
                    int filas = await cmd.ExecuteNonQueryAsync();
                    return filas > 0;
                }
            }
            catch (SqlException ex)
            {
                
                throw new Exception("Error al insertar posicion: " + ex.Message);
            }
        }

        
        public override async Task<bool> ActualizarAsync(int id)
        {
            string query = @"UPDATE Posiciones
                             SET Nombre         = @Nombre,
                                 Salario        = @Salario,
                                 IdDepartamento = @IdDepartamento
                             WHERE Id = @Id";

            try
            {
                using (SqlConnection con = ConexionDB.AbrirConexion())
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Nombre", this.Nombre);
                    cmd.Parameters.AddWithValue("@Salario", this.Salario);
                    cmd.Parameters.AddWithValue("@IdDepartamento", this.IdDepartamento);
                    cmd.Parameters.AddWithValue("@Id", id);
                    await con.OpenAsync();
                    int filas = await cmd.ExecuteNonQueryAsync();
                    return filas > 0;
                }
            }
            catch (SqlException ex)
            {
                
                throw new Exception("Error al actualizar posicion: " + ex.Message);
            }
        }
    }
}