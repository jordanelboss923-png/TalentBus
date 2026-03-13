using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    // HERENCIA: Empleado "es una" PersonaBase
    // Hereda Nombre, Apellido, Cedula y todos sus métodos
    public class Empleado : PersonaBase
    {
        // Propiedades propias del Empleado
        public int IdCargo { get; set; }
        public decimal SalarioBase { get; set; }
        public string FechaIngreso { get; set; }

        // CONSTRUCTOR CON PARÁMETROS
        // Llama al constructor del padre con "base()"
        public Empleado(string nombre, string apellido, string cedula,
                        int idCargo, decimal salarioBase)
            : base(nombre, apellido, cedula)  // ← llama a PersonaBase
        {
            IdCargo = idCargo;
            SalarioBase = salarioBase;
        }

        // Constructor vacío (necesario para crear objeto sin datos)
        public Empleado() : base() { }

        // IMPLEMENTACIÓN del método abstracto ObtenerRol()
        // Es OBLIGATORIO implementarlo porque PersonaBase lo exige
        public override string ObtenerRol()
        {
            return "Empleado";
        }

        // SOBREESCRIBIR método virtual del padre
        // Añade la cédula al nombre completo
        public override string ObtenerNombreCompleto()
        {
            return $"{Nombre} {Apellido} - CI: {Cedula}";
        }
    }
}