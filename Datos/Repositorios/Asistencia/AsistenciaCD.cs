using CapaDatos;
using System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class AsistenciaCD : BaseCD
    {
        
        public int IdEmpleado { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaHora { get; set; }

        
        // TODO MÉTODO PROTEGIDO: Nombre de tabla para Eliminar()
     
        protected override string ObtenerNombreTabla()
        {
            return "Asistencias";
        }


        // TODO OBTENER TODOS LOS REGISTROS DE ASISTENCIA síncrono

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

            using (SqlConnection con = new ConexionDB().AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(tabla);
            }

            return tabla;
        }


        // TODO OBTENER UN REGISTRO DE ASISTENCIA POR SU ID síncrono

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


        // TODO OBTENER TODA LA ASISTENCIA DE UN EMPLEADO síncrono

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

            using (SqlConnection con = new ConexionDB().AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@IdEmpleado", idEmpleado);
                con.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(tabla);
            }

            return tabla;
        }


        // TODO INSERTAR UN NUEVO REGISTRO DE ASISTENCIA síncrono

        public override bool Insertar()
        {
            string query = @"INSERT INTO Asistencias (IdEmpleado, Descripcion) 
                             VALUES (@IdEmpleado, @Descripcion)";

            using (SqlConnection con = new ConexionDB().AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@IdEmpleado", this.IdEmpleado);
                cmd.Parameters.AddWithValue("@Descripcion", this.Descripcion);
                con.Open();

                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }


        // TODO ACTUALIZAR UN REGISTRO DE ASISTENCIA síncrono

        public override bool Actualizar(int id)
        {
            string query = @"UPDATE Asistencias 
                             SET Descripcion = @Descripcion 
                             WHERE Id = @Id";

            using (SqlConnection con = new ConexionDB().AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Descripcion", this.Descripcion);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();

                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }


        // TODO OBTENER TODOS LOS REGISTROS DE ASISTENCIA asíncrono

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

            using (SqlConnection con = new ConexionDB().AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(query, con);
                await con.OpenAsync();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(tabla);
            }

            return tabla;
        }


        // TODO OBTENER UN REGISTRO DE ASISTENCIA POR ID asíncrono

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


        //  TODO INSERTAR UN REGISTRO DE ASISTENCIA asíncrono

        public override async Task<bool> InsertarAsync()
        {
            string query = @"INSERT INTO Asistencias (IdEmpleado, Descripcion) 
                             VALUES (@IdEmpleado, @Descripcion)";

            using (SqlConnection con = new ConexionDB().AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@IdEmpleado", this.IdEmpleado);
                cmd.Parameters.AddWithValue("@Descripcion", this.Descripcion);
                await con.OpenAsync();

                int filasAfectadas = await cmd.ExecuteNonQueryAsync();
                return filasAfectadas > 0;
            }
        }


        // TODO ACTUALIZAR UN REGISTRO DE ASISTENCIA asíncrono

        public override async Task<bool> ActualizarAsync(int id)
        {
            string query = @"UPDATE Asistencias 
                             SET Descripcion = @Descripcion 
                             WHERE Id = @Id";

            using (SqlConnection con = new ConexionDB().AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Descripcion", this.Descripcion);
                cmd.Parameters.AddWithValue("@Id", id);
                await con.OpenAsync();

                int filasAfectadas = await cmd.ExecuteNonQueryAsync();
                return filasAfectadas > 0;
            }
        }
    }
}
