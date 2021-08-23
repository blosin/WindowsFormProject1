using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestionador.Clases
{
    public class DetalleCompraa
    {
        public int id { get; set; }

        public Compraa compraa { get; set; }

        public Producto producto { get; set; }

        public int cantidad { get; set; }        

        public decimal precio { get; set; }
               


        public void Validar()
        {
            
            if(string.IsNullOrEmpty(cantidad.ToString()) || cantidad < 0)
                throw new ApplicationException("Error inesperado, error de cantidad");

            if (string.IsNullOrEmpty(precio.ToString()) || precio < 0)
                throw new ApplicationException("Error inesperado, error de precioo");
        }

    }
}
