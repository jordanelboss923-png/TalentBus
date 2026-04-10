using Capa_Datos;
using Datos.Conexion;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Datos.CD
{
    // TODO: Capa de datos para la tabla Asignaciones, con métodos CRUD.
    public class AsignacionesCD : BaseCD
    {
        
        public string Nombre { get; set; }
        public decimal Porcentaje { get; set; }
        public string Descripcion { get; set; }

        //Todo: constructor para inicializar las propiedades
        protected override string ObtenerNombreTabla()
        {
            return "Asignaciones";
        }

        //TODO: implementación de los métodos CRUD utilizando ADO.NET, con manejo de excepciones y uso de parámetros para evitar SQL Injection.
        public override DataTable ObtenerTodos()
        {
            string query = @"SELECT Id,
                                    Nombre,
                                    Porcentaje,
                                    Descripcion
                             FROM Asignaciones";

            DataTable tabla = new DataTable();

            // Manejo de excepciones para capturar errores de conexión o consulta
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
                
                throw new Exception("Error al obtener asignaciones: " + ex.Message);
            }

            return tabla;
        }


        // TODO: método para obtener una asignación por su ID, con manejo de excepciones y uso de parámetros para evitar SQL Injection.
        public override DataTable ObtenerPorId(int id)
        {
            string query = @"SELECT Id,
                                    Nombre,
                                    Porcentaje,
                                    Descripcion
                             FROM Asignaciones
                             WHERE Id = @Id";

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
                
                throw new Exception("Error al obtener asignacion: " + ex.Message);
            }

            return tabla;
        }

        // TODO: método para insertar una nueva asignación, con manejo de excepciones y uso de parámetros para evitar SQL Injection.
        public override bool Insertar()
        {
            string query = @"INSERT INTO Asignaciones (Nombre, Porcentaje, Descripcion)
                             VALUES (@Nombre, @Porcentaje, @Descripcion)";

            try
            {
                using (SqlConnection con = ConexionDB.AbrirConexion())
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Nombre", this.Nombre);
                    cmd.Parameters.AddWithValue("@Porcentaje", this.Porcentaje);
                    cmd.Parameters.AddWithValue("@Descripcion", this.Descripcion);
                    con.Open();
                    int filas = cmd.ExecuteNonQuery();
                    return filas > 0;
                }
            }
            catch (SqlException ex)
            {
                
                throw new Exception("Error al insertar asignacion: " + ex.Message);
            }
        }

        // TODO: método para actualizar una asignación existente, con manejo de excepciones y uso de parámetros para evitar SQL Injection.
        public override bool Actualizar(int id)
        {
            string query = @"UPDATE Asignaciones
                             SET Nombre      = @Nombre,
                                 Porcentaje  = @Porcentaje,
                                 Descripcion = @Descripcion
                             WHERE Id = @Id";

            try
            {
                using (SqlConnection con = ConexionDB.AbrirConexion())
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Nombre", this.Nombre);
                    cmd.Parameters.AddWithValue("@Porcentaje", this.Porcentaje);
                    cmd.Parameters.AddWithValue("@Descripcion", this.Descripcion);
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    int filas = cmd.ExecuteNonQuery();
                    return filas > 0;
                }
            }
            catch (SqlException ex)
            {
                
                throw new Exception("Error al actualizar asignacion: " + ex.Message);
            }
        }

        // TODO: versiones asíncronas de los métodos CRUD, utilizando async/await y manejo de excepciones.
        public override async Task<DataTable> ObtenerTodosAsync()
        {
            string query = @"SELECT Id,
                                    Nombre,
                                    Porcentaje,
                                    Descripcion
                             FROM Asignaciones";

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
                
                throw new Exception("Error al obtener asignaciones: " + ex.Message);
            }

            return tabla;
        }

        // TODO: método asíncrono para obtener una asignación por su ID, con manejo de excepciones y uso de parámetros para evitar SQL Injection.
        public override async Task<DataTable> ObtenerPorIdAsync(int id)
        {
            string query = @"SELECT Id,
                                    Nombre,
                                    Porcentaje,
                                    Descripcion
                             FROM Asignaciones
                             WHERE Id = @Id";

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
                
                throw new Exception("Error al obtener asignacion: " + ex.Message);
            }

            return tabla;
        }

        //  TODO: método asíncrono para insertar una nueva asignación, con manejo de excepciones y uso de parámetros para evitar SQL Injection.
        public override async Task<bool> InsertarAsync()
        {
            string query = @"INSERT INTO Asignaciones (Nombre, Porcentaje, Descripcion)
                             VALUES (@Nombre, @Porcentaje, @Descripcion)";

            try
            {
                using (SqlConnection con = ConexionDB.AbrirConexion())
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Nombre", this.Nombre);
                    cmd.Parameters.AddWithValue("@Porcentaje", this.Porcentaje);
                    cmd.Parameters.AddWithValue("@Descripcion", this.Descripcion);
                    await con.OpenAsync();
                    int filas = await cmd.ExecuteNonQueryAsync();
                    return filas > 0;
                }
            }
            catch (SqlException ex)
            {
                
                throw new Exception("Error al insertar asignacion: " + ex.Message);
            }
        }

        // TODO: método asíncrono para actualizar una asignación existente, con manejo de excepciones y uso de parámetros para evitar SQL Injection.
        public override async Task<bool> ActualizarAsync(int id)
        {
            string query = @"UPDATE Asignaciones
                             SET Nombre      = @Nombre,
                                 Porcentaje  = @Porcentaje,
                                 Descripcion = @Descripcion
                             WHERE Id = @Id";

            try
            {
                using (SqlConnection con = ConexionDB.AbrirConexion())
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Nombre", this.Nombre);
                    cmd.Parameters.AddWithValue("@Porcentaje", this.Porcentaje);
                    cmd.Parameters.AddWithValue("@Descripcion", this.Descripcion);
                    cmd.Parameters.AddWithValue("@Id", id);
                    await con.OpenAsync();
                    int filas = await cmd.ExecuteNonQueryAsync();
                    return filas > 0;
                }
            }
            catch (SqlException ex)
            {
                
                throw new Exception("Error al actualizar asignacion: " + ex.Message);
            }
        }
    }
}