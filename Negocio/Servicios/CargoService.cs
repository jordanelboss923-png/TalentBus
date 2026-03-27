using Datos.Repositorios;
using System.Data;

namespace Negocio.Servicios
{
    public class CargoService
    {
        CargoRepository repo = new CargoRepository();

        public void Registrar(string NombreCargo, string Departamento)
        {
            repo.Insertar(NombreCargo, Departamento);
        }

        public DataTable Listar()
        {
            return repo.Listar();
        }

        public void Eliminar(int id)
        {
            repo.Eliminar(id);
        }

        public void Actualizar(string NombreCargo, string Departamento, int Id)
        {
            repo.Actualizar(NombreCargo, Departamento, Id);
        }
    }
}