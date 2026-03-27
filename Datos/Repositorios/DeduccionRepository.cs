using Datos.Conexion;

using System;
using System.Data;
using System.Data.SqlClient;

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
        }

        public void Actualizar(int id, decimal porcentaje)
        {
            using (SqlConnection con = new ConexionDB().AbrirConexion())
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
            using (SqlConnection con = new ConexionDB().AbrirConexion())
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