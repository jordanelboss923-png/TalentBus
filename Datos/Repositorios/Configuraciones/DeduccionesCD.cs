using Datos.Conexion;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

// ===============================================
// Esta clase maneja las deducciones configurables
// Ej: AFP, SFS, etc.
// ===============================================

// usa using (SqlConnection con = ConexionDB.AbrirConexion()) para
// abrir la conexion con la base de datos

// Modifica esta clase para usar la herencia de la clase BaseCD
// ¡¡¡¡¡¡¡¡¡¡REVISA LA CLASE BaseCD!!!!!!!!!

/* TODO ELIMINAR ESTO PARA QUITAR COMENTADO

namespace Datos.Repositorios
{
    public class DeduccionRepository
    {
        public DataTable Listar()
        {
            using (SqlConnection con = new ConexionDB().AbrirConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT Id, Nombre, Tipo, Porcentaje FROM DeduccionBeneficio", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
=======
            return "Deducciones";
>>>>>>> Stashed changes:Datos/Repositorios/Configuraciones/DeduccionesCD.cs
        }


        // TODO OBTENER TODAS LAS DEDUCCIONES síncrono

        public override DataTable ObtenerTodos()
        {
<<<<<<< Updated upstream:Datos/Repositorios/DeduccionRepository.cs
=======
            string query = @"SELECT Id, 
                                    Nombre, 
                                    Porcentaje, 
                                    Descripcion 
                             FROM Deducciones";

            DataTable tabla = new DataTable();

>>>>>>> Stashed changes:Datos/Repositorios/Configuraciones/DeduccionesCD.cs
            using (SqlConnection con = new ConexionDB().AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(tabla);
            }

            return tabla;
        }


        // TODO OBTENER UNA DEDUCCIÓN POR SU ID síncrono

        public override DataTable ObtenerPorId(int id)
        {
            string query = @"SELECT Id, 
                                    Nombre, 
                                    Porcentaje, 
                                    Descripcion 
                             FROM Deducciones 
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


        // TODO INSERTAR UNA NUEVA DEDUCCIÓN síncrono

        public override bool Insertar()
        {
            string query = @"INSERT INTO Deducciones (Nombre, Porcentaje, Descripcion) 
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


        //TODO ACTUALIZAR UNA DEDUCCIÓN EXISTENTE síncrono

        public override bool Actualizar(int id)
        {
<<<<<<< Updated upstream:Datos/Repositorios/DeduccionRepository.cs
=======
            string query = @"UPDATE Deducciones 
                             SET Nombre      = @Nombre, 
                                 Porcentaje  = @Porcentaje, 
                                 Descripcion = @Descripcion 
                             WHERE Id = @Id";

>>>>>>> Stashed changes:Datos/Repositorios/Configuraciones/DeduccionesCD.cs
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


        // TODO OBTENER TODAS LAS DEDUCCIONES asíncrono

        public override async Task<DataTable> ObtenerTodosAsync()
        {
            using (SqlConnection con = new ConexionDB().AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(query, con);
                await con.OpenAsync();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(tabla);
            }

            return tabla;
        }


        // TODO OBTENER UNA DEDUCCIÓN POR ID asíncrono

        public override async Task<DataTable> ObtenerPorIdAsync(int id)
        {
            string query = @"SELECT Id, 
                                    Nombre, 
                                    Porcentaje, 
                                    Descripcion 
                             FROM Deducciones 
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


        // TODO INSERTAR UNA DEDUCCIÓN asíncrono

        public override async Task<bool> InsertarAsync()
        {
            string query = @"INSERT INTO Deducciones (Nombre, Porcentaje, Descripcion) 
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


        // TODO ACTUALIZAR UNA DEDUCCIÓN (asíncrono)

        public override async Task<bool> ActualizarAsync(int id)
        {
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

*/ // TODO QUITAR ESTO PARA ELIMINAR COMENTADO