using Datos.Conexion;
using System;
using System.Data;
using System.Data.SqlClient;

// ===============================================
// Esta clase maneja las deducciones configurables
// Ej: AFP, SFS, etc.
// ===============================================

// usa using (SqlConnection con = ConexionDB.AbrirConexion()) para
// abrir la conexion con la base de datos

// Modifica esta clase para usar la herencia de la clase BaseCD
// ¡¡¡¡¡¡¡¡¡¡REVISA LA CLASE BaseCD!!!!!!!!!

namespace Datos.Repositorios
{
    public class DeduccionesCD
    {
        public DataTable Listar()
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT Id, Nombre, Tipo, Porcentaje FROM DeduccionBeneficio", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void Actualizar(int id, decimal porcentaje)
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(
                    "UPDATE DeduccionBeneficio SET Porcentaje = @Porcentaje WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@Porcentaje", porcentaje);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public decimal ObtenerPorcentaje(string tipo)
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT Porcentaje FROM DeduccionBeneficio WHERE Tipo = @Tipo", con);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToDecimal(result) : 0;
            }
        }
    }
}