using Datos.Conexion;

using System.Data.SqlClient;
using System.Data;

// =====================================================
// Esta clase maneja los cargos con sus salarios
// Ej: Gerente, Analista, Representante, Jardinero, etc.
// =====================================================

// usa using (SqlConnection con = ConexionDB.AbrirConexion()) para
// abrir la conexion con la base de datos

// Modifica esta clase para usar la herencia de la clase BaseCD
// ¡¡¡¡¡¡¡¡¡¡REVISA LA CLASE BaseCD!!!!!!!!!

namespace Datos.Repositorios
{
    public class PosicionesCD
    {
        public void Insertar(string NombreCargo, string Departamento)
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Cargo (NombreCargo, Departamento) VALUES (@Nombre, @Depto)", con);
                cmd.Parameters.AddWithValue("@Nombre", NombreCargo);
                cmd.Parameters.AddWithValue("@Depto", Departamento);
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable Listar()
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT Id, NombreCargo, Departamento FROM Cargo", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void Eliminar(int id)
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Cargo WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Actualizar(string NombreCargo, string Departamento, int Id)
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(
                    @"UPDATE Cargo SET 
                      NombreCargo  = @Nombre, 
                      Departamento = @Depto 
                      WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@Nombre", NombreCargo);
                cmd.Parameters.AddWithValue("@Depto", Departamento);
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}