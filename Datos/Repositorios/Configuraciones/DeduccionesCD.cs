using Capa_Datos;
using Datos.Conexion;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Datos.CD
{
    //TODO: Clase para manejar las operaciones CRUD de la tabla Deducciones, con métodos para obtener todas las deducciones, obtener por id, insertar y actualizar.
    public class DeduccionesCD : BaseCD
    {
        
        public string Nombre { get; set; }
        public decimal Porcentaje { get; set; }
        public string Descripcion { get; set; }

        //TODO: Método para obtener el nombre de la tabla, utilizado por la clase base para operaciones genéricas.
        protected override string ObtenerNombreTabla()
        {
            return "Deducciones";
        }

        //TODO: Implementación de los métodos CRUD, con manejo de excepciones y uso de parámetros para evitar inyección SQL.
        public override DataTable ObtenerTodos()
        {
            string query = @"SELECT Id,
                                    Nombre,
                                    Porcentaje,
                                    Descripcion
                             FROM Deducciones";

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
               
                throw new Exception("Error al obtener deducciones: " + ex.Message);
            }

            return tabla;
        }

        //TODO: Método para obtener una deducción por su id, con manejo de excepciones y uso de parámetros.
        public override DataTable ObtenerPorId(int id)
        {
            string query = @"SELECT Id,
                                    Nombre,
                                    Porcentaje,
                                    Descripcion
                             FROM Deducciones
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
               
                throw new Exception("Error al obtener deduccion: " + ex.Message);
            }

            return tabla;
        }

        //TODO: Método para insertar una nueva deducción, con manejo de excepciones y uso de parámetros.
        public override bool Insertar()
        {
            string query = @"INSERT INTO Deducciones (Nombre, Porcentaje, Descripcion)
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
                
                throw new Exception("Error al insertar deduccion: " + ex.Message);
            }
        }

        //TODO: Método para actualizar una deducción existente, con manejo de excepciones y uso de parámetros.
        public override bool Actualizar(int id)
        {
            string query = @"UPDATE Deducciones
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
                
                throw new Exception("Error al actualizar deduccion: " + ex.Message);
            }
        }

        //TODO: Implementación de las versiones asíncronas de los métodos CRUD, con manejo de excepciones y uso de parámetros.
        public override async Task<DataTable> ObtenerTodosAsync()
        {
            string query = @"SELECT Id,
                                    Nombre,
                                    Porcentaje,
                                    Descripcion
                             FROM Deducciones";

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
                
                throw new Exception("Error al obtener deducciones: " + ex.Message);
            }

            return tabla;
        }

        //TODO: Método asíncrono para obtener una deducción por su id, con manejo de excepciones y uso de parámetros.
        public override async Task<DataTable> ObtenerPorIdAsync(int id)
        {
            string query = @"SELECT Id,
                                    Nombre,
                                    Porcentaje,
                                    Descripcion
                             FROM Deducciones
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
                
                throw new Exception("Error al obtener deduccion: " + ex.Message);
            }

            return tabla;
        }

        //TODO: Método asíncrono para insertar una nueva deducción, con manejo de excepciones y uso de parámetros.
        public override async Task<bool> InsertarAsync()
        {
            string query = @"INSERT INTO Deducciones (Nombre, Porcentaje, Descripcion)
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
                
                throw new Exception("Error al insertar deduccion: " + ex.Message);
            }
        }

        //TODO: Método asíncrono para actualizar una deducción existente, con manejo de excepciones y uso de parámetros.
        public override async Task<bool> ActualizarAsync(int id)
        {
            string query = @"UPDATE Deducciones
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
                
                throw new Exception("Error al actualizar deduccion: " + ex.Message);
            }
        }
    }
}