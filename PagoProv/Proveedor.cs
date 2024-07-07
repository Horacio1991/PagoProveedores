using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoProv
{
    public class Proveedor
    {
        // propiedades
        public int Legajo { get; set; }
        public string Nombre { get; set; }

        // constructor que inicializa un nuevo proveedor con un legajo y nombre
        public Proveedor(int legajo, string nombre)
        {
            Legajo = legajo;
            Nombre = nombre;
        }
    }
}
