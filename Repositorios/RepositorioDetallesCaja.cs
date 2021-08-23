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
    class RepositorioDetallesCaja
    {
        private AccesoBD _BD;

        public RepositorioDetallesCaja()
        {
            _BD = new AccesoBD();
        }

        public DataTable ObtenerDetallesOtrosGastos(int caja)//nombre+' '+\'('+cuit+\')' as proveedores
        {
            string sqltxt = $"SELECT a.id, a.fecha, b.nombre, a.importe, a.observaciones, a.caja, c.nombre+' '+\'('+c.login+\')' as usuario FROM otrosGastos a, DetalleGastos b, usuarios c WHERE a.detalle=b.id AND a.usuario=c.id AND a.caja='{caja}'";//WHERE a.marca=marca.id AND a.rubro=rubro.id";
            //
            return _BD.consulta(sqltxt);
        }

        public DataTable ObtenerDetallesRetiros(int caja)
        {
            string sqltxt = $"SELECT a.id, a.fecha, a.detalle, a.importe, a.observaciones, a.caja, c.nombre+' '+\'('+c.login+\')' as usuario FROM retiros a, usuarios c WHERE a.usuario=c.id AND caja='{caja}'";//WHERE a.marca=marca.id AND a.rubro=rubro.id";
            //
            return _BD.consulta(sqltxt);
        }

        public DataTable ObtenerDetallesOtrosIngresos(int caja)
        {
            string sqltxt = $"SELECT a.id, a.fecha, b.nombre, a.importe, a.observaciones, a.caja, c.nombre+' '+\'('+c.login+\')' as usuario FROM otrosIngresos a, DetalleIngresos b, usuarios c WHERE a.detalle=b.id AND a.usuario=c.id AND a.caja='{caja}'";//WHERE a.marca=marca.id AND a.rubro=rubro.id";
            //
            return _BD.consulta(sqltxt);
        }

        public bool GuardarOtroGasto(OtroGasto otroGasto)
        {
            string sqltxt = "";

            sqltxt = $"INSERT dbo.otrosGastos (fecha, detalle, importe, observaciones, caja, usuario)" +
                    $"VALUES ('{otroGasto.returnFecha()}', '{otroGasto.detalle}', REPLACE( '{otroGasto.importe}', ',', '.'), '{otroGasto.observaciones}', '{otroGasto.caja}', '{otroGasto.usuario}')";

            return _BD.EjecutarSQL(sqltxt);
        }
        public bool GuardarOtroIngreso(OtroIngreso otroIngreso)
        {
            string sqltxt = "";

            sqltxt = $"INSERT dbo.otrosIngresos (fecha, detalle, importe, observaciones, caja, usuario)" +
                    $"VALUES ('{otroIngreso.returnFecha()}', '{otroIngreso.detalle}', REPLACE( '{otroIngreso.importe}', ',', '.'), '{otroIngreso.observaciones}', '{otroIngreso.caja}', '{otroIngreso.usuario}')";

            return _BD.EjecutarSQL(sqltxt);
        }
        public bool GuardarRetiro(Retiro retiro)
        {
            string sqltxt = "";

            sqltxt = $"INSERT dbo.retiros (fecha, detalle, importe, observaciones, caja, usuario)" +
                    $"VALUES ('{retiro.returnFecha()}', '{retiro.detalle}', REPLACE( '{retiro.importe}', ',', '.'), '{retiro.observaciones}', '{retiro.caja}', '{retiro.usuario}')";

            return _BD.EjecutarSQL(sqltxt);
        }

        
    }
}
