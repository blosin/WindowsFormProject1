using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestionador.Clases
{
    class Cajaa
    {
        public int id { get; set; }
        public decimal? cajaInicial { get; set; }
        public decimal? cajaActual { get; set; }
        public decimal? gastoCompras { get; set; }
        public decimal? otrosGastos { get; set; }
        public decimal? retiros { get; set; }
        public decimal? ventas { get; set; }
        public decimal? otrosIngresos { get; set; }

        public DateTime fechaApertura { get; set; }
        public DateTime fechaCerrado { get; set; }

        public bool cajaInicialValida()
        {
            if (!string.IsNullOrEmpty(cajaInicial.ToString()) && cajaInicial >= 0)
                return true;
            return false;
        }

        public bool cajaActualValida()
        {
            if (!string.IsNullOrEmpty(cajaActual.ToString()) && cajaActual >= 0)
                return true;
            return false;
        }

        public bool gastoComprasValido()
        {
            if (!string.IsNullOrEmpty(gastoCompras.ToString()) && gastoCompras >= 0)
                return true;
            return false;
        }

        public bool otrosGastosValido()
        {
            if (!string.IsNullOrEmpty(otrosGastos.ToString()) && otrosGastos >= 0)
                return true;
            return false;
        }

        public bool retirosValido()
        {
            if (!string.IsNullOrEmpty(retiros.ToString()) && retiros >= 0)
                return true;
            return false;
        }

        public bool ventasValido()
        {
            if (!string.IsNullOrEmpty(ventas.ToString()) && ventas >= 0)
                return true;
            return false;
        }

        public bool otrosIngresosValido()
        {
            if (!string.IsNullOrEmpty(otrosIngresos.ToString()) && otrosIngresos >= 0)
                return true;
            return false;
        }        

        public string returnFechaCerrado()
        {
            return fechaCerrado.ToString("yyyy-MM-ddTHH:mm:ss.fff");//"yyyy-MM-dd HH:mm"); AAAA - MM - DD hh: mm
        }
    }
}
