using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestionador.Clases
{
    public class Ventaa
    {
        public int id { get; set; }

        public DateTime fecha { get; set; }

        public int usuario { get; set; }

        public int tipoFactura { get; set; }
        
        public int cliente { get; set; }

        public string tipoPago { get; set; }

        public IList<DetalleVentaa> detalleVenta { get; set; }       

        public decimal MontoFinal { get; set; }

        public int caja { get; set; }
        //falta crear clase y otras propiedades

        public void Validar()
        {
            if (string.IsNullOrEmpty(usuario.ToString()))
                throw new ApplicationException("Error inesperado, problemas con el usuario");
            if (string.IsNullOrEmpty(tipoFactura.ToString()))
                throw new ApplicationException("Ingrese tipo de factira, error inesperado");
            if(string.IsNullOrEmpty(tipoPago.ToString()))
                throw new ApplicationException("Ingrese tipo de pago, error inesperado");
            if (detalleVenta == null || detalleVenta.Count == 0)
                throw new ApplicationException("Al menos se requiere un detalle");
            else
                foreach (var da in detalleVenta)
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
