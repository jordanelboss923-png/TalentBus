using Datos.Conexion;
using System.Data.SqlClient;

// =========================================================
// Esta clase maneja los CRUD de los datos de cada empleado,
// tambien indica el tipo de empleado (fijo, temporal, etc.)
// =========================================================

// usa using (SqlConnection con = ConexionDB.AbrirConexion()) para
// abrir la conexion con la base de datos

// Modifica esta clase para usar la herencia de la clase BaseCD
// ¡¡¡¡¡¡¡¡¡¡REVISA LA CLASE BaseCD!!!!!!!!!

namespace Datos.Repositorios
{
    public class EmpleadosCD
    {
        public void Insertar(string Cedula, string Nombre, string Apellido, int IdCargo, decimal SalarioBase)
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                string sql = @"INSERT INTO Empleado 
                              (Cedula, Nombre, Apellido, IdCargo, SalarioBase)
                              VALUES (@Cedula, @Nombre, @Apellido, @IdCargo, @Salario)";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Cedula", Cedula);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Apellido", Apellido);
                cmd.Parameters.AddWithValue("@IdCargo", IdCargo);
                cmd.Parameters.AddWithValue("@Salario", SalarioBase);

                cmd.ExecuteNonQuery();
            }
        }
        public SqlDataReader Listar()
        {
            SqlConnection con = ConexionDB.AbrirConexion();
            SqlCommand cmd = new SqlCommand(
                @"SELECT e.Cedula, e.Nombre, e.Apellido, 
                 c.NombreCargo, e.SalarioBase, e.FechaIngreso
          FROM Empleado e
          INNER JOIN Cargo c ON e.IdCargo = c.Id", con);

            return cmd.ExecuteReader();
        }
        public void Eliminar(string cedula)
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                // Primero elimina el detalle de nómina relacionado
                SqlCommand cmdDetalle = new SqlCommand(
                    @"DELETE FROM NominaDetalle 
              WHERE IdEmpleado = (SELECT Id FROM Empleado WHERE Cedula = @Cedula)", con);
                cmdDetalle.Parameters.AddWithValue("@Cedula", cedula);
                cmdDetalle.ExecuteNonQuery();

                // Luego elimina el empleado
                SqlCommand cmdEmpleado = new SqlCommand(
                    "DELETE FROM Empleado WHERE Cedula = @Cedula", con);
                cmdEmpleado.Parameters.AddWithValue("@Cedula", cedula);
                cmdEmpleado.ExecuteNonQuery();
            }
        }
        public void Actualizar(string Cedula, string Nombre, string Apellido, decimal SalarioBase)
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                string sql = @"UPDATE Empleado SET
                              Nombre = @Nombre,
                              Apellido = @Apellido,
                              SalarioBase = @Salario
                              WHERE Cedula = @Cedula";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Apellido", Apellido);
                cmd.Parameters.AddWithValue("@Salario", SalarioBase);
                cmd.Parameters.AddWithValue("@Cedula", Cedula);

                cmd.ExecuteNonQuery();
            }
        }
        public bool ProbarConexion()
        {
            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                return con.State == System.Data.ConnectionState.Open;
            }
        }

    }

}

