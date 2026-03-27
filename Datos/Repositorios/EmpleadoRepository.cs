using CapaDatos;
using Entidades;
using System.Data.SqlClient;

namespace Datos.Repositorios
{
    public class EmpleadoRepository
    {
        public void Insertar(Empleado emp)
        {
            using (SqlConnection con = new ConexionDB().AbrirConexion())
            {
                string sql = @"INSERT INTO Empleado 
                              (Cedula, Nombre, Apellido, IdCargo, SalarioBase)
                              VALUES (@Cedula, @Nombre, @Apellido, @IdCargo, @Salario)";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Cedula", emp.Cedula);
                cmd.Parameters.AddWithValue("@Nombre", emp.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", emp.Apellido);
                cmd.Parameters.AddWithValue("@IdCargo", emp.IdCargo);
                cmd.Parameters.AddWithValue("@Salario", emp.SalarioBase);

                cmd.ExecuteNonQuery();
            }
        }
        public SqlDataReader Listar()
        {
            SqlConnection con = new ConexionDB().AbrirConexion();
            SqlCommand cmd = new SqlCommand(
                @"SELECT e.Cedula, e.Nombre, e.Apellido, 
                 c.NombreCargo, e.SalarioBase, e.FechaIngreso
          FROM Empleado e
          INNER JOIN Cargo c ON e.IdCargo = c.Id", con);

            return cmd.ExecuteReader();
        }
        public void Eliminar(string cedula)
        {
            using (SqlConnection con = new ConexionDB().AbrirConexion())
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
        public void Actualizar(Empleado emp)
        {
            using (SqlConnection con = new ConexionDB().AbrirConexion())
            {
                string sql = @"UPDATE Empleado SET
                              Nombre = @Nombre,
                              Apellido = @Apellido,
                              SalarioBase = @Salario
                              WHERE Cedula = @Cedula";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Nombre", emp.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", emp.Apellido);
                cmd.Parameters.AddWithValue("@Salario", emp.SalarioBase);
                cmd.Parameters.AddWithValue("@Cedula", emp.Cedula);

                cmd.ExecuteNonQuery();
            }
        }
        public bool ProbarConexion()
        {
            using (SqlConnection con = new ConexionDB().AbrirConexion())
            {
                return con.State == System.Data.ConnectionState.Open;
            }
        }

    }

}

