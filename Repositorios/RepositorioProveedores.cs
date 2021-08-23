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
    class RepositorioProveedores
    {
        private AccesoBD _BD;

        public RepositorioProveedores()
        {
            _BD = new AccesoBD();
        }

        public DataTable ObtenerComboProveedores()
        {
            string sqltxt = "SELECT cuit, nombre+' '+\'('+cuit+\')' as proveedores FROM dbo.proveedor";

            return _BD.consulta(sqltxt);
        }

        public DataTable ObtenerProveedores()
        {
            string sqltxt = "SELECT a.id, a.nombre, a.nombreContacto, b.nombre, c.nombre, a.cuit, a.telFijo, a.telCel, d.nombre, a.localidad, a.direccion, a.cp, a.mail, a.observaciones, a.fechaMod FROM proveedor a, rubro b, iva c, provincia d WHERE a.rubro=b.id AND a.iva=c.id AND a.provincia=d.id";
            //
            return _BD.consulta(sqltxt);
        }

        public bool Guardar(Proveedor proveedor)
        {
            string sqltxt = "";

            sqltxt = $"INSERT dbo.proveedor (nombre, nombreContacto, rubro, iva, cuit, telFijo, telCel, provincia, localidad, direccion, cp, mail, observaciones, fechaMod)" +
                    $"VALUES ('{proveedor.nombre}', '{proveedor.nombreContacto}', '{proveedor.rubro}', '{proveedor.iva}', '{proveedor.cuit}', '{proveedor.telFijo}', '{proveedor.telCel}', '{proveedor.provincia}', '{proveedor.localidad}', '{proveedor.direccion}', '{proveedor.cp}', '{proveedor.mail}', '{proveedor.observaciones}', '{proveedor.returnFechaModificacion()}')";

            return _BD.EjecutarSQL(sqltxt);
        }
        public bool Eliminar(string proveedorID)
        {
            string sqltxt = $"DELETE FROM [dbo].[proveedor] WHERE id = '{proveedorID}'";

            return _BD.EjecutarSQL(sqltxt);
        }
        public DataTable ProveedorExistente(string cuit)
        {
            string sqltxt = $"SELECT * FROM proveedor WHERE cuit='{cuit}'";
            return _BD.consulta(sqltxt);
        }

        public bool Actualizar(Proveedor proveedor)
        {
            string sqltxt = $"UPDATE dbo.proveedor SET nombre= '{proveedor.nombre}', nombreContacto = '{proveedor.nombreContacto}', " +
                $"rubro = '{proveedor.rubro}', iva= '{proveedor.iva}', cuit = '{proveedor.cuit}', telFijo= '{proveedor.telFijo}', " +
                $"telCel= '{proveedor.telCel}', provincia= '{proveedor.provincia}', localidad= '{proveedor.localidad}', direccion= '{proveedor.direccion}', cp= '{proveedor.cp}', " +
                $"mail= '{proveedor.mail}', observaciones= '{proveedor.mail}', fechaMod= '{proveedor.returnFechaModificacion()}' WHERE id={proveedor.id}";

            return _BD.EjecutarSQL(sqltxt);
        }

        public Proveedor ObtenerProveedor(string proveedorID)
        {
            string sqltxt = $"SELECT * FROM dbo.proveedor WHERE id={proveedorID}";
            var tablaTemporal = _BD.consulta(sqltxt);

            if (tablaTemporal.Rows.Count == 0)
                return null;
            var proveedor = new Proveedor();
            foreach (DataRow fila in tablaTemporal.Rows)
            {
                if (fila.HasErrors)
                    continue;
                proveedor.id = int.Parse(fila.ItemArray[0].ToString());
                proveedor.nombre = fila.ItemArray[1].ToString();
                proveedor.nombreContacto = fila.ItemArray[2].ToString();//DateTime.Parse(fila.ItemArray[2].ToString());
                proveedor.rubro = int.Parse(fila.ItemArray[3].ToString());
                proveedor.iva = int.Parse(fila.ItemArray[4].ToString());
                proveedor.cuit = fila.ItemArray[5].ToString();
                proveedor.telFijo = fila.ItemArray[6].ToString();
                proveedor.telCel = fila.ItemArray[7].ToString();
                proveedor.provincia = int.Parse(fila.ItemArray[8].ToString());
                proveedor.localidad = fila.ItemArray[9].ToString();
                proveedor.direccion = fila.ItemArray[10].ToString();
                proveedor.cp = fila.ItemArray[11].ToString();
                proveedor.mail = fila.ItemArray[12].ToString();
                proveedor.observaciones = fila.ItemArray[13].ToString();
                proveedor.fechaMod = DateTime.Parse(fila.ItemArray[14].ToString());
               

            }
            return proveedor;
        }

    }
    
}
