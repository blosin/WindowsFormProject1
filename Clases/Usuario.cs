using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestionador.Clases
{
   public class Usuario
    {
        public int id { get; set; }
        public DateTime fechaMod { get; set; }
        public string nombre { get; set; }
        public string login { get; set; }
        public string contrasena { get; set; }
        public string observaciones { get; set; }
        public int admin { get; set; }
        public int aClientes { get; set; }
        public int aCompras { get; set; }
        public int aProductos { get; set; }
        public int aProveedores { get; set; }
        public int aUsuarios { get; set; }
        public int aVentas { get; set; }
        public int aCaja { get; set; }
        public int aGenerarReportes { get; set; }

        public string returnFechaModificacion()
        {
            return fechaMod.ToString("yyyy-MM-ddTHH:mm:ss.fff");//"yyyy-MM-dd HH:mm"); AAAA - MM - DD hh: mm
        }

        public bool nombreValido()
        {
            if (!string.IsNullOrEmpty(nombre) && nombre.Length < 100)
                return true;
            return false;
        }

        public bool loginValido()
        {
            if (!string.IsNullOrEmpty(login) && nombre.Length < 70)
                return true;
            return false;
        }

        public bool contrasenaValida()
        {
            if (!string.IsNullOrEmpty(contrasena) && contrasena.Length < 70)
                return true;
            return false;
        }

        public bool observacionesValida()
        {
            if (!string.IsNullOrEmpty(observaciones) && observaciones.Length < 700)
                return true;
            return false;
        }

        public bool adminValido()
        {
            if (admin == 0 || admin == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
                
        }
        public bool aClientesValido()
        {
            if (aClientes == 0 || aClientes == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool aComprasValido()
        {
            if (aCompras == 0 || aCompras == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool aProductosValido()
        {
            if (aProductos == 0 || aProductos == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool aProveedoresValido()
        {
            if (aProveedores == 0 || aProveedores == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool aUsuariosValido()
        {
            if (aUsuarios == 0 || aUsuarios == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool aVentasValido()
        {
            if (aVentas == 0 || aVentas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool aCajaValido()
        {
            if (aCaja == 0 || aCaja == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool aGenerarReportesValido()
        {
            if (aGenerarReportes == 0 || aGenerarReportes == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }




    }
}
