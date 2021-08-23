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
    class RepositorioCompras
    {
        private AccesoBD _BD;

        public RepositorioCompras()
        {
            _BD = new AccesoBD();
        }


        public DataTable ObtenerComprasActuales()
        {
            string sqltxt = "SELECT a.id, a.fecha, b.nombre+' '+\'('+b.login+\')' as usuario, c.nombre+' '+\'('+c.cuit+\')' as proveedor, d.nombre, a.afectoCaja, a.montoFinal FROM compra a, usuarios b, proveedor c, iva d, cajas e WHERE a.usuario=b.id AND a.proveedor=c.id AND a.IVA=d.id AND a.caja=e.id AND e.fechaCerrado IS NULL";

            return _BD.consulta(sqltxt);
        }

        public DataTable ObtenerComprasAnteriores()
        {
            string sqltxt = "SELECT a.id, a.fecha, b.nombre+' '+\'('+b.login+\')' as usuario, c.nombre+' '+\'('+c.cuit+\')' as proveedor, d.nombre, a.afectoCaja, a.montoFinal, a.caja FROM compra a, usuarios b, proveedor c, iva d, cajas e WHERE a.usuario=b.id AND a.proveedor=c.id AND a.IVA=d.id AND a.caja=e.id AND e.cajaAnterior=1";

            return _BD.consulta(sqltxt);
        }

        public DataTable HistorialCompras()
        {
            string sqltxt = "SELECT a.id, a.fecha, b.nombre+' '+\'('+b.login+\')' as usuario, c.nombre+' '+\'('+c.cuit+\')' as proveedor, d.nombre, a.afectoCaja, a.montoFinal, a.caja FROM compra a, usuarios b, proveedor c, iva d WHERE a.usuario=b.id AND a.proveedor=c.id AND a.IVA=d.id";
            //SELECT a.id, a.nombre, a.fechaNac, b.nombre, a.telFijo, a.telCel, d.nombre, a.observaciones FROM cliente a, tipoDoc b, provincia c WHERE a.tipoDoc=b.id 

            return _BD.consulta(sqltxt);
        }

        public DataTable ObtenerDetalles(int nroCompra)
        {
            string sqltxt = $"SELECT a.id, b.descripcion, a.cantidad, a.precio, CAST(REPLACE(a.precio, ',', '.') as decimal)*a.cantidad as subtotal FROM detalleCompra a, producto b WHERE a.producto=b.codigo AND a.compra='{nroCompra}'";

            return _BD.consulta(sqltxt);
        }

        public int Guardar(Compraa v)
        {
            int numCompra = 0;
            using (var tx = _BD.IniciarTransaccion())
            {
                try
                {                    //CAST(REPLACE( '{producto.PrecioCompra}', ',', '.') as float)
                    string sqltxt = $"INSERT [dbo].[compra] ([fecha], [usuario], [proveedor], [IVA], [afectoCaja], [montoFinal], [caja])" +
                        $" VALUES ('{v.ObtenerFecha()}', '{v.usuario}', '{v.proveedor}','{v.IVA}', '{v.afectoCaja}' CAST(REPLACE( '{v.MontoFinal}', ',', '.') as decimal), '{v.caja}')";
                    v.id = _BD.EjecutarTransaccion(sqltxt);
                    numCompra = v.id;
                    if (v.id == 0)
                        throw new ApplicationException();

                    foreach (var d in v.detalleCompra)
                    {

                        sqltxt = $"INSERT [dbo].[detalleCompra] " +
                            $"([compra], [producto], [cantidad], [precio]) " +
                            $"VALUES ({v.id}, {d.producto.codigo}, {d.cantidad}, CAST(REPLACE( '{d.precio}', ',', '.') as decimal))";
                        _BD.EjecutarTransaccion(sqltxt);

                        sqltxt = $"SELECT stock FROM producto WHERE codigo={d.producto.codigo}";

                        var stock =
                            int.Parse(_BD.ConsultaDuranteTransaccion(sqltxt).Rows[0]["stock"].ToString());
                        if (stock + d.cantidad < 0)
                            throw new ApplicationException("Error de stock");

                        sqltxt = $"UPDATE [dbo].[producto] SET stock = '{stock + d.cantidad}' WHERE codigo={d.producto.codigo}";
                        _BD.EjecutarTransaccion(sqltxt);
                    }

                    tx.Commit();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    throw new ApplicationException("No se pudo guardar la orden de compra." + ex.Message);
                }
                finally
                {
                    _BD.cerrar();
                }
            }
            return numCompra;
        }
    }
}
