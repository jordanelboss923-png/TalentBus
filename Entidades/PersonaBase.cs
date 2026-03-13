using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    // CLASE ABSTRACTA: No se puede instanciar directamente
    // Es una "plantilla" que obliga a sus hijos a implementar ciertos métodos
    public abstract class PersonaBase
    {
        // PROPIEDADES BASE que toda persona tiene
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }

        // CONSTRUCTOR: Se ejecuta al crear el objeto
        // Inicializa los datos básicos
        public PersonaBase(string nombre, string apellido, string cedula)
        {
            Nombre = nombre;
            Apellido = apellido;
            Cedula = cedula;
        }

        // Constructor vacío (también es un constructor, pero sin parámetros)
        public PersonaBase() { }

        // MÉTODO ABSTRACTO: No tiene cuerpo aquí
        // Obliga a cada hijo a definir su propia versión
        public abstract string ObtenerRol();

        // MÉTODO VIRTUAL: Tiene cuerpo aquí pero los hijos PUEDEN sobreescribirlo
        public virtual string ObtenerNombreCompleto()
        {
            return $"{Nombre} {Apellido}";
        }

        // MÉTODO NORMAL: Retorna un valor (función)
        // Los hijos lo heredan tal cual, no pueden cambiarlo
        public string ObtenerIniciales()
        {
            return $"{Nombre[0]}.{Apellido[0]}.";
        }
    }
}