using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestionador.Clases
{
    public class Compraa
    {
        public int id { get; set; }

        public DateTime fecha { get; set; }

        public int usuario { get; set; }

        public int proveedor { get; set; }
        
        public int IVA { get; set; }

        public IList<DetalleCompraa> detalleCompra { get; set; }

        public string afectoCaja { get; set; }

        public decimal MontoFinal { get; set; }

        public int caja { get; set; }
        //falta crear clase y otras propiedades

        public Compraa()
        {

        }


        public void Validar()
        {
            if (string.IsNullOrEmpty(usuario.ToString()))
                throw new ApplicationException("Error inesperado, error de usuario");
            if (string.IsNullOrEmpty(afectoCaja.ToString()))
                throw new ApplicationException("Error inesperado error de afectacion de caja");
            if (detalleCompra == null || detalleCompra.Count == 0)
                throw new ApplicationException("Al menos se requiere un detalle");
            else
                foreach (var da in detalleCompra)
                    da.Validar();
            if (MontoFinal == 0)
                throw new ApplicationException("Al menos se requiere un detalle");
        }

        public string ObtenerFecha()
        {
            return fecha.ToString("yyyy-MM-ddTHH:mm:ss.fff");
        }
    }
}
