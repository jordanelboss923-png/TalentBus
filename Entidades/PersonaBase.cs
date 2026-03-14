using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    // CLASE ABSTRACTA: No se puede instanciar directamente
   
    public abstract class PersonaBase
    {
        // PROPIEDADES BASE que toda persona tiene
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }

        
        // Inicializa los datos básicos
        public PersonaBase(string nombre, string apellido, string cedula)
        {
            Nombre = nombre;
            Apellido = apellido;
            Cedula = cedula;
        }

        // Constructor vacío 
        public PersonaBase() { }

        
        // Obliga a cada hijo a definir su propia versión
        public abstract string ObtenerRol();

        // MÉTODO VIRTUAL
        public virtual string ObtenerNombreCompleto()
        {
            return $"{Nombre} {Apellido}";
        }

        // MÉTODO NORMAL Retorna un valor (función)
        
        public string ObtenerIniciales()
        {
            return $"{Nombre[0]}.{Apellido[0]}.";
        }
    }
}