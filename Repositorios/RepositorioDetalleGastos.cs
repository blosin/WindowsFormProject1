using Gestionador.Clases;
using Gestionador.HelperBD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestionador.Repositorios
{
    class RepositorioDetalleGastos
    {

        private AccesoBD _BD;

        public RepositorioDetalleGastos()
        {
            _BD = new AccesoBD();
        }

        public DataTable ObtenerDetalles()
        {
            //se define una variable local a la función <sqltxt> del tipo <string> donde en el 
            //momento de su creación se le asigan su contenido, que es el comando SELECT  
            //necesario para poder establecer la veracidad del usuario.
            string sqltxt = "SELECT * FROM dbo.DetalleGastos";

            return _BD.consulta(sqltxt);
        }

        public DataTable SoyDetalleExistente(string nombre)
        {
            string sqltxt = $"SELECT * FROM DetalleGastos WHERE nombre='{nombre}'";
            return _BD.consulta(sqltxt);
        }


        public bool Guardar(Detalle detalle)
        {
            string sqltxt = $"INSERT dbo.DetalleGastos ( nombre) " +
                $"VALUES ('{detalle.nombre}')";

            return _BD.EjecutarSQL(sqltxt);
        }

        public bool Eliminar(string DetalleID)
        {
            string sqltxt = $"DELETE FROM [dbo].[DetalleGastos] WHERE id = {DetalleID}";

            return _BD.EjecutarSQL(sqltxt);
        }

        public Detalle ObtenerDetalle(string DetalleID)
        {
            string sqltxt = $"SELECT * FROM dbo.DetalleGastos WHERE id={DetalleID}";
            var tablaTemporal = _BD.consulta(sqltxt);

            if (tablaTemporal.Rows.Count == 0)
                return null;
            var detalle = new Detalle();
            foreach (DataRow fila in tablaTemporal.Rows)
            {
                if (fila.HasErrors)
                    continue;
                detalle.id = int.Parse(fila.ItemArray[0].ToString());
                detalle.nombre = fila.ItemArray[1].ToString();
            }
            return detalle;
        }

        public bool Actualizar(Detalle detalle)
        {
            string sqltxt = $"UPDATE dbo.DetalleGastos SET nombre = '{detalle.nombre}' WHERE id={detalle.id}";

            return _BD.EjecutarSQL(sqltxt);
        }
    }
}
