using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   
    public class Empleado : PersonaBase
    {
        // Propiedades propias del Empleado
        public int IdCargo { get; set; }
        public decimal SalarioBase { get; set; }
        public string FechaIngreso { get; set; }

        // CONSTRUCTOR CON PARÁMETROS
        
        public Empleado(string nombre, string apellido, string cedula,
                        int idCargo, decimal salarioBase)
            : base(nombre, apellido, cedula)  
        {
            IdCargo = idCargo;
            SalarioBase = salarioBase;
        }

        
        public Empleado() : base() { }

        // IMPLEMENTACIÓN del método abstracto ObtenerRol()
      
        public override string ObtenerRol()
        {
            return "Empleado";
        }

        
        // Añade la cédula al nombre completo
        public override string ObtenerNombreCompleto()
        {
            return $"{Nombre} {Apellido} - CI: {Cedula}";
        }
    }
}