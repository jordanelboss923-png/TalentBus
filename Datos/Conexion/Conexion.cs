using System.Data.SqlClient;

namespace Datos.Conexion
{
    public class ConexionDB
    {
        private readonly string cadena =
            "Server=localhost;Database=TalentPlusDBs;Trusted_Connection=True;";

        public SqlConnection AbrirConexion()
        {
            SqlConnection conexion = new SqlConnection(cadena);
            conexion.Open();
            return conexion;
        }
    }
}