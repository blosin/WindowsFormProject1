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
    class RepositorioRubros
    {
        private AccesoBD _BD;

        public RepositorioRubros()
        {
            _BD = new AccesoBD();
        }

        public DataTable ObtenerRubros()
        {
            //se define una variable local a la función <sqltxt> del tipo <string> donde en el 
            //momento de su creación se le asigan su contenido, que es el comando SELECT  
            //necesario para poder establecer la veracidad del usuario.
            string sqltxt = "SELECT * FROM dbo.rubro";

            return _BD.consulta(sqltxt);
        }

        public DataTable SoyRubroExistente(string nombre)
        {
            string sqltxt = $"SELECT * FROM rubro WHERE nombre='{nombre}'";
            return _BD.consulta(sqltxt);
        }


        public bool Guardar(Rubro rubro)
        {
            string sqltxt = $"INSERT dbo.rubro ( nombre) " +
                $"VALUES ('{rubro.nombre}')";

            return _BD.EjecutarSQL(sqltxt);
        }

        public bool Eliminar(string rubroID)
        {
            string sqltxt = $"DELETE FROM [dbo].[rubro] WHERE id = {rubroID}";

            return _BD.EjecutarSQL(sqltxt);
        }

        public Rubro ObtenerRubro(string rubroID)
        {
            string sqltxt = $"SELECT * FROM dbo.rubro WHERE id={rubroID}";
            var tablaTemporal = _BD.consulta(sqltxt);

            if (tablaTemporal.Rows.Count == 0)
                return null;
            var rubro = new Rubro();
            foreach (DataRow fila in tablaTemporal.Rows)
            {
                if (fila.HasErrors)
                    continue;
                rubro.id = int.Parse(fila.ItemArray[0].ToString());
                rubro.nombre = fila.ItemArray[1].ToString();
            }
            return rubro;
        }

        public bool Actualizar(Rubro rubro)
        {
            string sqltxt = $"UPDATE dbo.rubro SET nombre = '{rubro.nombre}' WHERE id={rubro.id}";

            return _BD.EjecutarSQL(sqltxt);
        }
    }
}
