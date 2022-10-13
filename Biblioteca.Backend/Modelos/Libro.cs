using System.Data;

namespace Biblioteca.Backend.Modelos
{
    public class Libro
    {
        public string Código { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }
        public int Año { get; set; }

    }
}
