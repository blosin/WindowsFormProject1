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
    class RepositorioMarcas
    {
        private AccesoBD _BD;

        public RepositorioMarcas()
        {
            _BD = new AccesoBD();
        }

        public DataTable ObtenerMarcas()
        {
            //se define una variable local a la función <sqltxt> del tipo <string> donde en el 
            //momento de su creación se le asigan su contenido, que es el comando SELECT  
            //necesario para poder establecer la veracidad del usuario.
            string sqltxt = "SELECT * FROM dbo.marca";

            return _BD.consulta(sqltxt);
        }

        public DataTable SoyMarcaExistente(string nombre)
        {
            string sqltxt = $"SELECT * FROM marca WHERE nombre='{nombre}'";
            return _BD.consulta(sqltxt);
        }
        

        public bool Guardar(Marca marca)
        {
            string sqltxt = $"INSERT dbo.marca ( nombre) " +
                $"VALUES ('{marca.nombre}')";

            return _BD.EjecutarSQL(sqltxt);
        }

        public bool Eliminar(string marcaID)
        {
            string sqltxt = $"DELETE FROM [dbo].[marca] WHERE id = {marcaID}";

            return _BD.EjecutarSQL(sqltxt);
        }

        public Marca ObtenerMarca(string marcaID)
        {
            string sqltxt = $"SELECT * FROM dbo.marca WHERE id={marcaID}";
            var tablaTemporal = _BD.consulta(sqltxt);

            if (tablaTemporal.Rows.Count == 0)
                return null;
            var marca = new Marca();
            foreach (DataRow fila in tablaTemporal.Rows)
            {
                if (fila.HasErrors)
                    continue;
                marca.id = int.Parse(fila.ItemArray[0].ToString());
                marca.nombre = fila.ItemArray[1].ToString();
            }
            return marca;
        }

        public bool Actualizar(Marca marca)
        {
            string sqltxt = $"UPDATE dbo.marca SET nombre = '{marca.nombre}' WHERE id={marca.id}";

            return _BD.EjecutarSQL(sqltxt);
        }
    }
}
