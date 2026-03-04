using Datos.Repositorios;
using Entidades;
using System.Data.SqlClient;

namespace Negocio.Servicios
{
    public class EmpleadoService
    {
        EmpleadoRepository repo = new EmpleadoRepository();

        public void Registrar(Empleado emp)
        {
            repo.Insertar(emp);
        }

        public SqlDataReader Listar()
        {
            return repo.Listar();
        }

        public void Eliminar(string cedula)
        {
            repo.Eliminar(cedula);
        }

        public void Actualizar(Empleado emp)
        {
            repo.Actualizar(emp);
        }
        public bool ProbarConexion()
        {
            return repo.ProbarConexion();
        }

    }

}