using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestionador.Clases
{
    class Nota
    {
        public int  id { get; set; }
        public int usuario { get; set; }
        public DateTime fechaCreacion { get; set; }
        public int estado { get; set; }
        public string mensaje { get; set; }
        public string usuarioParticular { get; set; }


        public string returnFechaCreacion()
        {
            return fechaCreacion.ToString("yyyy-MM-ddTHH:mm:ss.fff");//"yyyy-MM-dd HH:mm"); AAAA - MM - DD hh: mm
        }


        public bool mensajeValido()
        {
            if (!string.IsNullOrEmpty(mensaje) && mensaje.Length < 1000)
                return true;
            return false;
        }

        

        

    }
}
