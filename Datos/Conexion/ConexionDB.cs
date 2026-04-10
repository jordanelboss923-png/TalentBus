using System.Data;
using System.Data.SqlClient;

namespace Datos.Conexion
{
    //TODO: clase para manejar la conexión a la base de datos, con métodos para abrir y cerrar la conexión.
    public class ConexionDB
    {

        //TODO: la cadena de conexión debe ser configurada para apuntar a la base de datos correcta.
        private static readonly string cadena =
            "Server=localhost;Database=TalentBus;Trusted_Connection=True;";

        public static SqlConnection AbrirConexion()
        {
            return new SqlConnection(cadena);
        }


    }
}