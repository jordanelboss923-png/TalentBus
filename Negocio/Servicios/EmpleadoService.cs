using Datos.Repositorios;
using System.Data;
using System.Data.SqlClient;

namespace Negocio.Servicios
{
    public class EmpleadoService
    {
        EmpleadoRepository repo = new EmpleadoRepository();

        public void Registrar(string Cedula, string Nombre, string Apellido, int IdCargo, decimal SalarioBase)
        {
            repo.Insertar(Cedula, Nombre, Apellido, IdCargo, SalarioBase);
        }

        public SqlDataReader Listar()
        {
            return repo.Listar();
        }

        public void Eliminar(string cedula)
        {
            repo.Eliminar(cedula);
        }

        public void Actualizar(string Cedula, string Nombre, string Apellido, decimal SalarioBase)
        {
            repo.Actualizar(Cedula, Nombre, Apellido, SalarioBase);
        }
        public bool ProbarConexion()
        {
            return repo.ProbarConexion();
        }

        

    }

}