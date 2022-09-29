using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Backend.Modelos
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }
        public string Año { get; set; }

    }

    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }

    }

    public class Alquiler
    {
        public int Id { get; set; }
        public Libro[] Libros { get; set; }
        public Persona Persona { get; set; }
        public DateTime Fecha { get; set; }
    }
}
