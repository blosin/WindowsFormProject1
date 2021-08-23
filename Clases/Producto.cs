using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestionador.Clases
{
    public class Producto       
    {
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public int? marca { get; set; }
        public int? rubro { get; set; }
        public decimal precio { get; set; }
        public decimal costo { get; set; }
        public int stock { get; set; }
        public int stockMinimo { get; set; }
        public DateTime fechaModificacion { get; set; }


        public bool DescripcionValida()
        {
            if (!string.IsNullOrEmpty(descripcion) && descripcion.Length < 70)
                return true;
            return false;
        }

        public bool precioValido()
        {
            if (!string.IsNullOrEmpty(precio.ToString()) && precio > 0)
                return true;
            return false;
        }
        public bool costoValido()
        {
            if (!string.IsNullOrEmpty(costo.ToString()) && costo > 0)
                return true;
            return false;
        }
        public bool StockValido()
        {
            if (!string.IsNullOrEmpty(stock.ToString()) && stock >= 0)
                return true;
            return false;
        }
        public bool stockMinValido()
        {
            if (!string.IsNullOrEmpty(stockMinimo.ToString()) && stockMinimo >= 0)
                return true;
            return false;
        }

        public string returnFechaModificacion()
        {
            return fechaModificacion.ToString("yyyy-MM-ddTHH:mm:ss.fff");//"yyyy-MM-dd HH:mm"); AAAA - MM - DD hh: mm
        }

    }
}
