using System.Data.SqlClient;

namespace Datos.Conexion
{
    public class ConexionDB
    {
        private static readonly string cadena =
            "Server=localhost;Database=TalentBusDB;Trusted_Connection=True;";

        public static SqlConnection AbrirConexion()
        {
            return new SqlConnection(cadena);
        }
    }
}