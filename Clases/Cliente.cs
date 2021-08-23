using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestionador.Clases
{
    class Cliente
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public DateTime fechaNac { get; set; }        
        public int? tipoDoc { get; set; }
        public string nroDoc { get; set; }
        public string direccion { get; set; }
        public string localidad { get; set; }
        public int? provincia { get; set; }
        public string telFijo { get; set; }
        public string telCel { get; set; }
        public int? condIVA { get; set; }
        public string cuit { get; set; }
        public decimal montoCuenta { get; set; }
        public string mail { get; set; }
        public string observaciones { get; set; }
        public string codPostal { get; set; }
        public decimal montoUsado { get; set; }
        public DateTime fechaMod { get; set; }


        public bool nombreValido()
        {
            if (!string.IsNullOrEmpty(nombre) && nombre.Length < 100)
                return true;
            return false;
        }

        public string returnFechaNacimiento()
        {
            return fechaNac.ToString("yyyy-MM-dd");//"yyyy-MM-dd HH:mm"); AAAA - MM - DD hh: mm
        }

        public string returnFechaModificacion()
        {
            return fechaMod.ToString("yyyy-MM-ddTHH:mm:ss.fff");//"yyyy-MM-dd HH:mm"); AAAA - MM - DD hh: mm
        }

        public bool nroDocValido()
        {
            if (!string.IsNullOrEmpty(nroDoc.ToString()) && nroDoc.ToString().Length < 50)
                return true;
            return false;
        }

        public bool direccionValida()
        {
            if (!string.IsNullOrEmpty(direccion) && direccion.Length < 200)
                return true;
            return false;
        }

        public bool localidadValida()
        {
            if (!string.IsNullOrEmpty(localidad) && localidad.Length < 100)
                return true;
            return false;
        }

        public bool telefenoFijoValido()
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
        public bool cuitValido()
        {
            if (!string.IsNullOrEmpty(cuit) && cuit.Length < 150)
                return true;
            return false;
        }
        public bool montoCuentaValido()
        {
            if (!string.IsNullOrEmpty(montoCuenta.ToString()) && montoCuenta >= 0)
                return true;
            return false;
        }
        public bool mailValido()
        {
            if (!string.IsNullOrEmpty(mail) && mail.Length < 200)
                return true;
            return false;
        }
        public bool obvervacionValida()
        {
            if (!string.IsNullOrEmpty(observaciones) && observaciones.Length < 700)
                return true;
            return false;
        }
        public bool codigoPostalValido()
        {
            if (!string.IsNullOrEmpty(codPostal) && codPostal.Length < 50)
                return true;
            return false;
        }
        public bool montoUsadoValido()
        {
            if (!string.IsNullOrEmpty(montoUsado.ToString()) && montoUsado >= 0 && montoUsado<=montoCuenta)
                return true;
            return false;
        }

    }
}
