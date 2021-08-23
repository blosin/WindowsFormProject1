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
    class RepositorioSesiones
    {
        private AccesoBD _BD;

        public RepositorioSesiones()
        {
            _BD = new AccesoBD();
        }

        public DataTable ObtenerSesiones()
        {
            //se define una variable local a la función <sqltxt> del tipo <string> donde en el 
            //momento de su creación se le asigan su contenido, que es el comando SELECT  
            //necesario para poder establecer la veracidad del usuario.// nombre+' '+\'('+cuit+\')' as proveedores 
            string sqltxt = "SELECT a.id, a.fechaInicio, a.fechaFin, b.nombre+' '+\'('+b.login+\')' as usuario, a.estado FROM sesiones a, usuarios b WHERE a.usuario=b.id";

            return _BD.consulta(sqltxt);
        }

        public bool InicioSesion(Sesion sesion)
        {
            string sqltxt = $"INSERT dbo.sesiones (fechaInicio, usuario, estado) " +
                $"VALUES ('{sesion.retunrFechaApertura()}', '{sesion.usuario}', 'Abierta')";

            return _BD.EjecutarSQL(sqltxt);
        }
        
        public bool CierreSesion(Sesion sesion)
        {
            string sqltxt = $"UPDATE dbo.sesiones SET fechaFin = '{sesion.returnFechaCerrada()}', estado = 'Cerrada' WHERE estado = 'Abierta'";

            return _BD.EjecutarSQL(sqltxt);

        }

        public bool VerificarSesionesAbiertas()
        {
            string sqltxt= $"UPDATE dbo.sesiones SET fechaFin = '{DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff")}', estado = 'Cerrada' WHERE estado= 'Abierta'";

            return _BD.EjecutarSQL(sqltxt);
        }

    

    }
}
