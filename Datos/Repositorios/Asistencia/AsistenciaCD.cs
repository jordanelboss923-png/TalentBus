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

// ===========================================================
// Esta clase lleva el registro de asistencia de los empleados
// (Entrada, salida, faltas justificadas)
// ===========================================================

// usa using (SqlConnection con = ConexionDB.AbrirConexion()) para
// abrir la conexion con la base de datos


{
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
