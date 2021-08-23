using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestionador.Clases
{
    class Sesion
    {
        public int id { get; set; }
        public DateTime fechaApertura { get; set; }
        public DateTime fechaCerrado { get; set; }
        public int usuario { get; set; }

       
        public string retunrFechaApertura()
        {
            return fechaApertura.ToString("yyyy-MM-ddTHH:mm:ss.fff");//"yyyy-MM-dd HH:mm"); AAAA - MM - DD hh: mm
        }
        public string returnFechaCerrada()
        {
            return fechaCerrado.ToString("yyyy-MM-ddTHH:mm:ss.fff");//"yyyy-MM-dd HH:mm"); AAAA - MM - DD hh: mm
        }
    }
}
