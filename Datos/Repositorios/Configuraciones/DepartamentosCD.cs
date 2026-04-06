using CapaDatos;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class DepartamentosCD : BaseCD
    {

        // TODO  PROPIEDAD Guarda el nombre del departamento

        public string Nombre { get; set; }

       
        // TODO MÉTODO PROTEGIDO Le dice a BaseCD qué tabla usar para que el método Eliminar
       
        protected override string ObtenerNombreTabla()
        {
            return "Departamentos";
        }


        // TODO OBTENER TODOS LOS DEPARTAMENTOS (síncrono)

        public override DataTable ObtenerTodos()
        {
            string query = "SELECT Id, Nombre FROM Departamentos";

            DataTable tabla = new DataTable();

            using (SqlConnection con = new ConexionDB().AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(tabla);
            }

            return tabla;
        }


        // TODO OBTENER UN DEPARTAMENTO POR SU ID síncrono

        public override DataTable ObtenerPorId(int id)
        {
            string query = "SELECT Id, Nombre FROM Departamentos WHERE Id = @Id";

            DataTable tabla = new DataTable();

            using (SqlConnection con = new ConexionDB().AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(tabla);
            }

            return tabla;
        }


        // TODO INSERTAR UN NUEVO DEPARTAMENTO síncrono

        public override bool Insertar()
        {
            string query = "INSERT INTO Departamentos (Nombre) VALUES (@Nombre)";

            using (SqlConnection con = new ConexionDB().AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nombre", this.Nombre);
                con.Open();

                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }


        // TODO ACTUALIZAR UN DEPARTAMENTO EXISTENTE síncrono

        public override bool Actualizar(int id)
        {
            string query = "UPDATE Departamentos SET Nombre = @Nombre WHERE Id = @Id";

            using (SqlConnection con = new ConexionDB().AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nombre", this.Nombre);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();

                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }


        // TODO OBTENER TODOS LOS DEPARTAMENTOS asíncrono

        public override async Task<DataTable> ObtenerTodosAsync()
        {
            string query = "SELECT Id, Nombre FROM Departamentos";

            DataTable tabla = new DataTable();

            using (SqlConnection con = new ConexionDB().AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(query, con);
                await con.OpenAsync();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(tabla);
            }

            return tabla;
        }


        // TODO OBTENER UN DEPARTAMENTO POR ID asíncrono

        public override async Task<DataTable> ObtenerPorIdAsync(int id)
        {
            string query = "SELECT Id, Nombre FROM Departamentos WHERE Id = @Id";

            DataTable tabla = new DataTable();

            using (SqlConnection con = new ConexionDB().AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);
                await con.OpenAsync();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(tabla);
            }

            return tabla;
        }


        // TODO INSERTAR UN DEPARTAMENTO asíncrono

        public override async Task<bool> InsertarAsync()
        {
            string query = "INSERT INTO Departamentos (Nombre) VALUES (@Nombre)";

            using (SqlConnection con = new ConexionDB().AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nombre", this.Nombre);
                await con.OpenAsync();

                int filasAfectadas = await cmd.ExecuteNonQueryAsync();
                return filasAfectadas > 0;
            }
        }


        // TODO ACTUALIZAR UN DEPARTAMENTO asíncrono

        public override async Task<bool> ActualizarAsync(int id)
        {
            string query = "UPDATE Departamentos SET Nombre = @Nombre WHERE Id = @Id";

            using (SqlConnection con = new ConexionDB().AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nombre", this.Nombre);
                cmd.Parameters.AddWithValue("@Id", id);
                await con.OpenAsync();

                int filasAfectadas = await cmd.ExecuteNonQueryAsync();
                return filasAfectadas > 0;
            }
        }
    }
}