using Capa_Datos;
using Datos.Conexion;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Datos.CD
{
    //TODO: Clase para manejar las operaciones CRUD de la tabla Posiciones, con métodos para obtener todas las posiciones, obtener una posición por id,
    //insertar una nueva posición y actualizar una posición existente. Esta clase hereda de BaseCD, lo que le permite reutilizar el método Eliminar y su versión asíncrona.
    public class PosicionesCD : BaseCD
    {
        
        public string Nombre { get; set; }
        public decimal Salario { get; set; }
        public int IdDepartamento { get; set; }

        //TODO: Implementar el método ObtenerNombreTabla para retornar el nombre de la tabla "Posiciones", que es utilizado por los métodos heredados de BaseCD para construir las consultas SQL.
        protected override string ObtenerNombreTabla()
        {
            return "Posiciones";
        }

        //TODO: Implementar los métodos CRUD para la tabla Posiciones, utilizando consultas SQL parametrizadas para evitar inyecciones SQL.
        //Cada método debe manejar las excepciones de SQL y lanzar una excepción genérica con un mensaje descriptivo en caso de error.
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

        //TODO: El método ObtenerPorId debe recibir un id como parámetro, validar que sea un valor positivo y retornar la posición correspondiente a ese id.
        //Si el id es inválido, debe lanzar una excepción ArgumentException.
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

        //TODO: El método Insertar debe utilizar los valores de las propiedades Nombre, Salario e IdDepartamento para insertar una nueva posición en la base de datos.
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

        //TODO: El método Actualizar debe recibir un id como parámetro, validar que sea un valor positivo y actualizar la posición correspondiente a ese id con los valores de las propiedades Nombre, Salario e IdDepartamento.
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

        //TODO: Implementar las versiones asíncronas de los métodos ObtenerTodos, ObtenerPorId, Insertar y Actualizar,
        //utilizando las palabras clave async y await para realizar operaciones de base de datos de manera asíncrona.
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

        //TODO: El método ObtenerPorIdAsync debe recibir un id como parámetro, validar que sea un valor positivo y retornar la posición correspondiente a ese id de manera asíncrona.
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

        //TODO: El método InsertarAsync debe utilizar los valores de las propiedades Nombre, Salario e IdDepartamento para insertar una nueva posición en la base de datos de manera asíncrona.
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

        //TODO: El método ActualizarAsync debe recibir un id como parámetro, validar que sea un valor positivo y actualizar la posición correspondiente
        //a ese id con los valores de las propiedades Nombre, Salario e IdDepartamento de manera asíncrona.
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