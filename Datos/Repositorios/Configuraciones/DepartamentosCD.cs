using Capa_Datos;
using Datos.Conexion;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Datos.CD
{
    //TODO: Clase para manejar operaciones CRUD de Departamentos.
    public class DepartamentosCD : BaseCD
    {
        
        public string Nombre { get; set; }

        //TODO: implementar el método para obtener el nombre de la tabla, que será usado por los métodos heredados de BaseCD.
        protected override string ObtenerNombreTabla()
        {
            return "Departamentos";
        }

        //TODO: implementar los métodos CRUD heredados de BaseCD, usando ADO.NET para interactuar con la base de datos.
        public override DataTable ObtenerTodos()
        {
            string query = "SELECT Id, Nombre FROM Departamentos";
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
                
                throw new Exception("Error al obtener departamentos: " + ex.Message);
            }

            return tabla;
        }

        //TODO: implementar el método para obtener un departamento por su Id, usando un parámetro en la consulta SQL para evitar inyección de SQL.
        public override DataTable ObtenerPorId(int id)
        {
            string query = "SELECT Id, Nombre FROM Departamentos WHERE Id = @Id";
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
                
                throw new Exception("Error al obtener departamento: " + ex.Message);
            }

            return tabla;
        }

        //TODO: implementar el método para insertar un nuevo departamento, usando un parámetro en la consulta SQL para evitar inyección de SQL.
        public override bool Insertar()
        {
            string query = "INSERT INTO Departamentos (Nombre) VALUES (@Nombre)";

            try
            {
                using (SqlConnection con = ConexionDB.AbrirConexion())
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Nombre", this.Nombre);
                    con.Open();
                    int filas = cmd.ExecuteNonQuery();
                    return filas > 0;
                }
            }
            catch (SqlException ex)
            {
                
                throw new Exception("Error al insertar departamento: " + ex.Message);
            }
        }

        //TODO: implementar el método para actualizar un departamento existente, usando parámetros en la consulta SQL para evitar inyección de SQL.
        public override bool Actualizar(int id)
        {
            string query = "UPDATE Departamentos SET Nombre = @Nombre WHERE Id = @Id";

            try
            {
                using (SqlConnection con = ConexionDB.AbrirConexion())
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Nombre", this.Nombre);
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    int filas = cmd.ExecuteNonQuery();
                    return filas > 0;
                }
            }
            catch (SqlException ex)
            {
                
                throw new Exception("Error al actualizar departamento: " + ex.Message);
            }
        }

        //TODO: implementar las versiones asíncronas de los métodos CRUD, usando async/await y los métodos asíncronos de ADO.NET.
        public override async Task<DataTable> ObtenerTodosAsync()
        {
            string query = "SELECT Id, Nombre FROM Departamentos";
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
                
                throw new Exception("Error al obtener departamentos: " + ex.Message);
            }

            return tabla;
        }

        //TODO: implementar la versión asíncrona del método para obtener un departamento por su Id, usando un parámetro en la consulta SQL para evitar inyección de SQL.
        public override async Task<DataTable> ObtenerPorIdAsync(int id)
        {
            string query = "SELECT Id, Nombre FROM Departamentos WHERE Id = @Id";
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
                
                throw new Exception("Error al obtener departamento: " + ex.Message);
            }

            return tabla;
        }

        //TODO: implementar la versión asíncrona del método para insertar un nuevo departamento, usando un parámetro en la consulta SQL para evitar inyección de SQL.
        public override async Task<bool> InsertarAsync()
        {
            string query = "INSERT INTO Departamentos (Nombre) VALUES (@Nombre)";

            try
            {
                using (SqlConnection con = ConexionDB.AbrirConexion())
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Nombre", this.Nombre);
                    await con.OpenAsync();
                    int filas = await cmd.ExecuteNonQueryAsync();
                    return filas > 0;
                }
            }
            catch (SqlException ex)
            {
                
                throw new Exception("Error al insertar departamento: " + ex.Message);
            }
        }

        //TODO: implementar la versión asíncrona del método para actualizar un departamento existente, usando parámetros en la consulta SQL para evitar inyección de SQL.
        public override async Task<bool> ActualizarAsync(int id)
        {
            string query = "UPDATE Departamentos SET Nombre = @Nombre WHERE Id = @Id";

            try
            {
                using (SqlConnection con = ConexionDB.AbrirConexion())
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Nombre", this.Nombre);
                    cmd.Parameters.AddWithValue("@Id", id);
                    await con.OpenAsync();
                    int filas = await cmd.ExecuteNonQueryAsync();
                    return filas > 0;
                }
            }
            catch (SqlException ex)
            {
                
                throw new Exception("Error al actualizar departamento: " + ex.Message);
            }
        }
    }
}