using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestionador.Clases
{
    class Proveedor
    {
        public int id { get; set; }
        public string  nombre { get; set; }
        public string nombreContacto { get; set; }
        public int? rubro { get; set; }
        public int? iva { get; set; }
        public string cuit { get; set; }
        public string telFijo { get; set; }
        public string telCel { get; set; }
        public int? provincia { get; set; }
        public string localidad { get; set; }
        public string direccion { get; set; }
        public string cp { get; set; }
        public string mail { get; set; }
        public string observaciones { get; set; }
        public DateTime fechaMod { get; set; }



        public bool nombreValido()
        {
            if (!string.IsNullOrEmpty(nombre) && nombre.Length < 150)
                return true;
            return false;
        }

        public bool nombreContactoValido()
        {
            if (!string.IsNullOrEmpty(nombreContacto) && nombreContacto.Length < 150)
                return true;
            return false;
        }
        public bool cuitValido()
        {
            if (!string.IsNullOrEmpty(cuit) && cuit.Length < 150)
                return true;
            return false;
        }
        public bool telefonoFijoValido()
        {
            if (!string.IsNullOrEmpty(telFijo) && telFijo.Length < 200)
                return true;
            return false;
        }
        public bool telefonoCelularValido()
        {
            if (!string.IsNullOrEmpty(telCel) && telCel.Length < 200)
                return true;
            return false;
        }
        public bool localidadValida()
        {
            if (!string.IsNullOrEmpty(localidad) && localidad.Length < 100)
                return true;
            return false;
        }
        public bool direccionValida()
        {
            if (!string.IsNullOrEmpty(direccion) && direccion.Length < 200)
                return true;
            return false;
        }
        public bool codigoPostalValido()
        {
            if (!string.IsNullOrEmpty(cp) && cp.Length < 50)
                return true;
            return false;
        }
        public bool mailValido()
        {
            if (!string.IsNullOrEmpty(mail) && mail.Length < 200)
                return true;
            return false;
        }
        public bool observacionValida()
        {
            if (!string.IsNullOrEmpty(observaciones) && observaciones.Length < 700)
                return true;
            return false;
        }
        public string returnFechaModificacion()
        {
            return fechaMod.ToString("yyyy-MM-ddTHH:mm:ss.fff");//"yyyy-MM-dd HH:mm"); AAAA - MM - DD hh: mm
        }

    }
}
