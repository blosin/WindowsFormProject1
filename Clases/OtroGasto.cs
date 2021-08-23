using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestionador.Clases
{
    class OtroGasto
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public int detalle { get; set; }
        public decimal importe { get; set; }
        public string observaciones { get; set; }
        public int caja { get; set; }
        public int usuario { get; set; }
       


        public bool detalleValido()
        {
            if (!string.IsNullOrEmpty(detalle.ToString()))
                return true;
            return false;
        }

        public bool importeValido()
        {
            if (!string.IsNullOrEmpty(importe.ToString()) && importe > 0)
                return true;
            return false;
        }
        public bool observacionesValido()
        {
            if (!string.IsNullOrEmpty(observaciones.ToString()) && observaciones.Length < 700)
                return true;
            return false;
        }
        public bool cajaValido()
        {
            if (!string.IsNullOrEmpty(caja.ToString()))
                return true;
            return false;
        }
        public bool usuarioValido()
        {
            if (!string.IsNullOrEmpty(usuario.ToString()))
                return true;
            return false;
        }


        public string returnFecha()
        {
            return fecha.ToString("yyyy-MM-ddTHH:mm:ss.fff");//"yyyy-MM-dd HH:mm"); AAAA - MM - DD hh: mm
        }
    }
}
