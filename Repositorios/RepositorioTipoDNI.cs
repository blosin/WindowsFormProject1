using Gestionador.HelperBD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestionador.Repositorios
{
    class RepositorioTipoDNI
    {

        private AccesoBD _BD;

        public RepositorioTipoDNI()
        {
            _BD = new AccesoBD();
        }

        public DataTable ObtenerTipoDNI()
        {
            //se define una variable local a la función <sqltxt> del tipo <string> donde en el 
            //momento de su creación se le asigan su contenido, que es el comando SELECT  
            //necesario para poder establecer la veracidad del usuario.
            string sqltxt = "SELECT * FROM dbo.tipoDoc";

            return _BD.consulta(sqltxt);
        }

    }
}
