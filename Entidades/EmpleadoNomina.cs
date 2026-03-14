using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    
    // Agrega todo lo relacionado a cálculos de nómina
    public class EmpleadoNomina : Empleado
    {
        public int HorasExtra { get; set; }

        // CONSTRUCTOR que recibe todo
        public EmpleadoNomina(string nombre, string apellido, string cedula,
                               int idCargo, decimal salarioBase, int horasExtra)
            : base(nombre, apellido, cedula, idCargo, salarioBase)
        {
            HorasExtra = horasExtra;
        }

        public EmpleadoNomina() : base() { }

        // SOBREESCRIBE ObtenerRol()
        public override string ObtenerRol()
        {
            return "Empleado en Nómina";
        }

        // ── MÉTODOS COMO FUNCIONES 

        // AFP: 2.87% del salario
        public decimal CalcularAFP()
        {
            return SalarioBase * 0.0287m;
        }

        // ARS: 3.04% del salario
        public decimal CalcularARS()
        {
            return SalarioBase * 0.0304m;
        }

        // ISR dominicano según tabla oficial
        public decimal CalcularISR()
        {
            decimal anual = SalarioBase * 12;

            if (anual <= 416220m) return 0;
            else if (anual <= 624329m) return (anual - 416220m) * 0.15m / 12;
            else if (anual <= 867123m) return (31216m + (anual - 624329m) * 0.20m) / 12;
            else return (79776m + (anual - 867123m) * 0.25m) / 12;
        }

        
        public decimal CalcularHorasExtra()
        {
            return (SalarioBase / 240) * 1.35m * HorasExtra;
        }

        
        public decimal CalcularNeto()
        {
            return SalarioBase
                   + CalcularHorasExtra()
                   - CalcularAFP()
                   - CalcularARS()
                   - CalcularISR();
        }
    }
}
