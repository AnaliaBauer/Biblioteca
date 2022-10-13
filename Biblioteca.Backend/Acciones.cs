using System.Data;
using System.Net;
using Biblioteca.Backend.Modelos;

namespace Biblioteca.Backend
{
    public class Acciones
    {
        public DataTable DTClientes { get; set; } = new DataTable();
        public DataTable DTLibros { get; set; } = new DataTable();
        public Acciones()
        {
            DTClientes.TableName = "Clientes";
            DTClientes.Columns.Add("DNI", typeof(string));
            DTClientes.Columns.Add("Nombre", typeof(string));
            DTClientes.Columns.Add("Apellido", typeof(string));
            DTClientes.Columns.Add("Telefono", typeof(string));

            LeerPersonas();

            DTLibros.TableName = "Libros";
            DTLibros.Columns.Add("Código", typeof(int));
            DTLibros.Columns.Add("Titulo", typeof(string));
            DTLibros.Columns.Add("Autor", typeof(string));
            DTLibros.Columns.Add("Editorial", typeof(string));
            DTLibros.Columns.Add("Año", typeof(string));

            LeerLibros();

        }

        public void AgregarCliente(Persona persona)
        {
            DTClientes.Rows.Add();
            int i = DTClientes.Rows.Count - 1;

            DTClientes.Rows[i]["DNI"] = persona.DNI;
            DTClientes.Rows[i]["Nombre"] = persona.Nombre;
            DTClientes.Rows[i]["Apellido"] = persona.Apellido;
            DTClientes.Rows[i]["Telefono"] = persona.Telefono;

            DTClientes.WriteXml("Clientes.xml");
        }

        public void AgregarLibro(Libro libro)
        {

            DTLibros.Rows.Add();
            int i = DTLibros.Rows.Count - 1;

            DTLibros.Rows[i]["Código"] = libro.Código;
            DTLibros.Rows[i]["Titulo"] = libro.Titulo;
            DTLibros.Rows[i]["Autor"] = libro.Autor;
            DTLibros.Rows[i]["Editorial"] = libro.Editorial;
            DTLibros.Rows[i]["Año"] = libro.Año.ToString();


            DTLibros.WriteXml("Libros.xml");

        }



        public bool BorrarPersona(string dni)
        {
            bool resultado = false;

            int fila = BuscarFila(dni);

            if (fila != -1)
            {

                DTClientes.Rows[fila].Delete();
                DTClientes.WriteXml("Clientes.xml");
                resultado = true;

            }

            return resultado;
        }

        public bool BorrarLibro(string codigo)
        {
            bool resultado = false;

            int fila = BuscarFilaLibro(codigo);

            if (fila != -1)
            {
                DTLibros.Rows[fila].Delete();
                DTLibros.WriteXml("Libros.xml");
                resultado = true;
            }

            return resultado;
        }

        public int BuscarFila(string dni)
        {
            for (int i = 0; i < DTClientes.Rows.Count; i++)
            {
                if ((string)DTClientes.Rows[i]["DNI"] == dni)
                {
                    return i;

                }
            }
            return -1;
        }

        public int BuscarFilaLibro(string codigo)
        {
            for (int i = 0; i < DTLibros.Rows.Count; i++)
            {

                if (DTLibros.Rows[i]["Código"].ToString() == codigo)
                {
                    return i;
                }



            }

            return -1;
        }

        public Persona BuscarPersona(string dni)
        {

            Persona persona = null;
            for (int i = 0; i < DTClientes.Rows.Count; i++)
            {
                if ((string)DTClientes.Rows[i]["DNI"] == dni)
                {
                    persona = new Persona();
                    persona.DNI = (string)DTClientes.Rows[i]["DNI"];
                    persona.Nombre = (string)DTClientes.Rows[i]["Nombre"];
                    persona.Apellido = (string)DTClientes.Rows[i]["Apellido"];
                    persona.Telefono = (string)DTClientes.Rows[i]["Telefono"];

                    return persona;
                }

            }
            return persona;
        }

        public Libro BuscarLibro(string codigo)
        {
            Libro libro = null;
            for (int i = 0; i < DTLibros.Rows.Count; i++)

            {
                if (DTLibros.Rows[i]["Código"].ToString() == codigo)
                {
                    libro = new Libro();
                    libro.Código = DTLibros.Rows[i]["Código"].ToString();
                    libro.Titulo = (string)DTLibros.Rows[i]["Titulo"];
                    libro.Autor = (string)DTLibros.Rows[i]["Autor"];
                    libro.Editorial = (string)DTLibros.Rows[i]["Editorial"];
                    libro.Año = Convert.ToInt32(DTLibros.Rows[i]["Año"]);

                    return libro;

                }

            }

            return libro;
        }

        public void LeerPersonas()
        {
            if (System.IO.File.Exists("Clientes.xml"))
            {
                DTClientes.ReadXml("Clientes.xml");
            }
        }

        private void LeerLibros()
        {
            if (System.IO.File.Exists("Libros.xml"))
            {
                DTLibros.ReadXml("Libros.xml");
            }
        }

        public bool ModificarPersona(Persona persona)
        {
            int fila = BuscarFila(persona.DNI);
            if (fila >= 0)
            {

                DTClientes.Rows[fila]["Nombre"] = persona.Nombre;
                DTClientes.Rows[fila]["Apellido"] = persona.Apellido;
                DTClientes.Rows[fila]["Telefono"] = persona.Telefono;

                DTClientes.WriteXml("Clientes.xml");
                return true;
            }

            return false;
        }


        public bool ModificarLibro(Libro libro)
        {
            int fila = BuscarFilaLibro(libro.Código);

            if (fila >= 0)
            {
                DTLibros.Rows[fila]["Titulo"] = libro.Titulo;
                DTLibros.Rows[fila]["Autor"] = libro.Autor;
                DTLibros.Rows[fila]["Editorial"] = libro.Editorial;
                DTLibros.Rows[fila]["Año"] = libro.Año.ToString();

                DTLibros.WriteXml("Libros.xml");
                return true;
            }

            return false;
        }

    }

}



