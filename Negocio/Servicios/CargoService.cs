using Datos.Repositorios;
using Entidades;
using System.Data;

namespace Negocio.Servicios
{
    public class CargoService
    {
        CargoRepository repo = new CargoRepository();

        public void Registrar(Cargo cargo)
        {
            repo.Insertar(cargo);
        }

        public DataTable Listar()
        {
            return repo.Listar();
        }

        public void Eliminar(int id)
        {
            repo.Eliminar(id);
        }

        public void Actualizar(Cargo cargo)
        {
            repo.Actualizar(cargo);
        }
    }
}