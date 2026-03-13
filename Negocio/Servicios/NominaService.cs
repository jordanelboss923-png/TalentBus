using Datos.Repositorios;
using System.Data;

namespace Negocio.Servicios
{
    public class NominaService
    {
        NominaRepository repo = new NominaRepository();
        DeduccionRepository repoDeduccion = new DeduccionRepository();

        public DataTable ListarEmpleados()
        {
            return repo.ListarEmpleados();
        }

        public decimal ObtenerPctAFP()
        {
            return repoDeduccion.ObtenerPorcentaje("AFP");
        }

        public decimal ObtenerPctARS()
        {
            return repoDeduccion.ObtenerPorcentaje("ARS");
        }

        public void GenerarNomina(DataTable empleados)
        {
            decimal pctAFP = ObtenerPctAFP();
            decimal pctARS = ObtenerPctARS();
            repo.GenerarNomina(empleados, pctAFP, pctARS);
        }

        public decimal CalcularISR(decimal salario)
        {
            return repo.CalcularISR(salario);
        }

        public DataTable ResumenPorDepartamento()
        {
            return repo.ResumenPorDepartamento();
        }
        public DataTable ListarNominaCompleta()
        {
            return repo.ListarNominaCompleta();
        }
    }
}