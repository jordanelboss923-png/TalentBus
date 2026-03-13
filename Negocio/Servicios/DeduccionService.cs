using Datos.Repositorios;
using System.Data;

namespace Negocio.Servicios
{
    public class DeduccionService
    {
        DeduccionRepository repo = new DeduccionRepository();

        public DataTable Listar()
        {
            return repo.Listar();
        }

        public void Actualizar(int id, decimal porcentaje)
        {
            repo.Actualizar(id, porcentaje);
        }

        public decimal ObtenerPorcentaje(string tipo)
        {
            return repo.ObtenerPorcentaje(tipo);
        }
    }
}