using CapaDatos;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class AsignacionesCD : BaseCD
    {
        public string Nombre { get; set; }
        public decimal Porcentaje { get; set; }
        public string Descripcion { get; set; }


        // TODO metodo protegido Nombre de tabla para Eliminar

        protected override string ObtenerNombreTabla()
        {
            return "Asignaciones";
        }


        // TODO OBTENER TODAS LAS ASIGNACIONES síncrono

        public override DataTable ObtenerTodos()
        {
            string query = @"SELECT Id, 
                                    Nombre, 
                                    Porcentaje, 
                                    Descripcion 
                             FROM Asignaciones";

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


        // TODO OBTENER UNA ASIGNACIÓN POR SU ID síncrono

        public override DataTable ObtenerPorId(int id)
        {
            string query = @"SELECT Id, 
                                    Nombre, 
                                    Porcentaje, 
                                    Descripcion 
                             FROM Asignaciones 
                             WHERE Id = @Id";

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


        // TODO INSERTAR UNA NUEVA ASIGNACIÓN síncrono

        public override bool Insertar()
        {
            string query = @"INSERT INTO Asignaciones (Nombre, Porcentaje, Descripcion) 
                             VALUES (@Nombre, @Porcentaje, @Descripcion)";

            using (SqlConnection con = new ConexionDB().AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nombre", this.Nombre);
                cmd.Parameters.AddWithValue("@Porcentaje", this.Porcentaje);
                cmd.Parameters.AddWithValue("@Descripcion", this.Descripcion);
                con.Open();

                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }


        // TODO ACTUALIZAR UNA ASIGNACIÓN EXISTENTE síncrono

        public override bool Actualizar(int id)
        {
            string query = @"UPDATE Asignaciones 
                             SET Nombre      = @Nombre, 
                                 Porcentaje  = @Porcentaje, 
                                 Descripcion = @Descripcion 
                             WHERE Id = @Id";

            using (SqlConnection con = new ConexionDB().AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nombre", this.Nombre);
                cmd.Parameters.AddWithValue("@Porcentaje", this.Porcentaje);
                cmd.Parameters.AddWithValue("@Descripcion", this.Descripcion);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();

                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }


        // TODO OBTENER TODAS LAS ASIGNACIONES asíncrono

        public override async Task<DataTable> ObtenerTodosAsync()
        {
            string query = @"SELECT Id, 
                                    Nombre, 
                                    Porcentaje, 
                                    Descripcion 
                             FROM Asignaciones";

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


        // TODO OBTENER UNA ASIGNACIÓN POR ID asíncrono

        public override async Task<DataTable> ObtenerPorIdAsync(int id)
        {
            string query = @"SELECT Id, 
                                    Nombre, 
                                    Porcentaje, 
                                    Descripcion 
                             FROM Asignaciones 
                             WHERE Id = @Id";

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


        // TODO INSERTAR UNA ASIGNACIÓN asíncrono

        public override async Task<bool> InsertarAsync()
        {
            string query = @"INSERT INTO Asignaciones (Nombre, Porcentaje, Descripcion) 
                             VALUES (@Nombre, @Porcentaje, @Descripcion)";

            using (SqlConnection con = new ConexionDB().AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nombre", this.Nombre);
                cmd.Parameters.AddWithValue("@Porcentaje", this.Porcentaje);
                cmd.Parameters.AddWithValue("@Descripcion", this.Descripcion);
                await con.OpenAsync();

                int filasAfectadas = await cmd.ExecuteNonQueryAsync();
                return filasAfectadas > 0;
            }
        }


        // TODO ACTUALIZAR UNA ASIGNACIÓN asíncrono

        public override async Task<bool> ActualizarAsync(int id)
        {
            string query = @"UPDATE Asignaciones 
                             SET Nombre      = @Nombre, 
                                 Porcentaje  = @Porcentaje, 
                                 Descripcion = @Descripcion 
                             WHERE Id = @Id";

            using (SqlConnection con = new ConexionDB().AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nombre", this.Nombre);
                cmd.Parameters.AddWithValue("@Porcentaje", this.Porcentaje);
                cmd.Parameters.AddWithValue("@Descripcion", this.Descripcion);
                cmd.Parameters.AddWithValue("@Id", id);
                await con.OpenAsync();

                int filasAfectadas = await cmd.ExecuteNonQueryAsync();
                return filasAfectadas > 0;
            }
        }
    }
}
