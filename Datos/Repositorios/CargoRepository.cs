using Datos.Conexion;
using Entidades;
using System.Data.SqlClient;
using System.Data;

namespace Datos.Repositorios
{
    public class CargoRepository
    {
        public void Insertar(Cargo cargo)
        {
            using (SqlConnection con = new ConexionDB().AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Cargo (NombreCargo, Departamento) VALUES (@Nombre, @Depto)", con);
                cmd.Parameters.AddWithValue("@Nombre", cargo.NombreCargo);
                cmd.Parameters.AddWithValue("@Depto", cargo.Departamento);
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable Listar()
        {
            using (SqlConnection con = new ConexionDB().AbrirConexion())
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
            using (SqlConnection con = new ConexionDB().AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Cargo WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Actualizar(Cargo cargo)
        {
            using (SqlConnection con = new ConexionDB().AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(
                    @"UPDATE Cargo SET 
                      NombreCargo  = @Nombre, 
                      Departamento = @Depto 
                      WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@Nombre", cargo.NombreCargo);
                cmd.Parameters.AddWithValue("@Depto", cargo.Departamento);
                cmd.Parameters.AddWithValue("@Id", cargo.Id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}