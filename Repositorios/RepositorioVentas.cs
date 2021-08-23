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
    class RepositorioVentas
    {
        private AccesoBD _BD;

        public RepositorioVentas()
        {
            _BD = new AccesoBD();
        }

        public DataTable ObtenerComboClientes()
        {
            string sqltxt = "SELECT nroDoc, nombre+' '+\'('+nroDoc+\')' as clientes FROM dbo.cliente";

            return _BD.consulta(sqltxt);
        }

        public DataTable ObtenerTiposFacturas()
        {
            string sqltxt = "SELECT id, nombre FROM dbo.tipoFactura";
            return _BD.consulta(sqltxt);
        }

        public DataTable ObtenerVentasActuales()
        {
            string sqltxt = "SELECT a.id, a.fecha, b.nombre+' '+\'('+b.login+\')' as usuario, c.nombre, d.nombre+' '+\'('+d.nroDoc+\')' as cliente, a.tipoPago, a.montoFinal FROM venta a, usuarios b, tipoFactura c, cliente d, cajas e WHERE a.usuario=b.id AND a.tipoFactura=c.id AND a.cliente=d.id AND a.caja=e.id AND e.fechaCerrado IS NULL";

            return _BD.consulta(sqltxt);
        }

        public DataTable ObtenerVentasAnteriores()
        {                  //SELECT a.id, a.fecha, b.nombre+' '+\'('+b.login+\')' as usuario, c.nombre, d.nombre+' '+\'('+d.nroDoc+\')' as cliente, a.tipoPago, a.montoFinal         FROM venta a, usuarios b, tipoFactura c, cliente d, cajas e WHERE a.usuario=b.id AND a.tipoFactura=c.id AND a.cliente=d.id AND a.caja=e.id
            string sqltxt = "SELECT a.id, a.fecha, b.nombre+' '+\'('+b.login+\')' as usuario, c.nombre, d.nombre+' '+\'('+d.nroDoc+\')' as cliente, a.tipoPago, a.montoFinal, a.caja FROM venta a, usuarios b, tipoFactura c, cliente d, cajas e WHERE a.usuario=b.id AND a.tipoFactura=c.id AND a.cliente=d.id AND a.caja=e.id AND e.cajaAnterior=1";

            return _BD.consulta(sqltxt);
        }

        public DataTable HistorialVentas()
        {                  //SELECT a.id, a.fecha, b.nombre+' '+\'('+b.login+\')' as usuario, c.nombre, d.nombre+' '+\'('+d.nroDoc+\')' as cliente, a.tipoPago, a.montoFinal, a.caja FROM venta a, usuarios b, tipoFactura c, cliente d, cajas e WHERE a.usuario=b.id AND a.tipoFactura=c.id AND a.cliente=d.id AND a.caja=e.id
            string sqltxt = "SELECT a.id, a.fecha, b.nombre+' '+\'('+b.login+\')' as usuario, c.nombre, d.nombre+' '+\'('+d.nroDoc+\')' as cliente, d.tipoPago, a.montoFinal, a.caja FROM venta a, usuarios b, tipoFactura c, cliente d WHERE a.usuario=b.id AND a.tipoFactura=c.id AND a.cliente=d.id";
                                                                                                                                                                                                                                     

            return _BD.consulta(sqltxt);
        }

        public DataTable ObtenerDetalles(int numVenta)
        {
            //SELECT a.nroDetalleTicket, b.nombre, a.cantidad, a.precio, CAST(REPLACE(a.precio, ',', '.') as float) * a.cantidad as subtotal FROM DetalleTicket a, Producto b WHERE a.idProducto = b.idProducto AND a.nroTicket =
            string sqltxt = $"SELECT a.id, b.descripcion, a.cantidad, a.precio, CAST(REPLACE(a.precio, ',', '.') as decimal)*a.cantidad as subtotal FROM detalleVenta a, Producto b WHERE a.producto=b.codigo AND a.venta='{numVenta}'";
            return _BD.consulta(sqltxt);
        }

        

        public int Guardar(Ventaa v)
        {
            int numVenta = 0;
            using (var tx = _BD.IniciarTransaccion())
            {
                try
                {                    //CAST(REPLACE( '{producto.PrecioCompra}', ',', '.') as float)
                    string sqltxt = $"INSERT [dbo].[venta] ([fecha], [usuario], [tipoFactura], [cliente], [tipoPago], [montoFinal], [caja])" +
                        $" VALUES ('{v.ObtenerFecha()}', '{v.usuario}', '{v.tipoFactura}', '{v.cliente}', '{v.tipoPago}', CAST(REPLACE( '{v.MontoFinal}', ',', '.') as decimal), '{v.caja}')";
                    v.id = _BD.EjecutarTransaccion(sqltxt);
                    numVenta = v.id;
                    if (v.id == 0)
                        throw new ApplicationException();                   
                   

                    foreach (var d in v.detalleVenta)
                    {

                        sqltxt = $"INSERT [dbo].[detalleVenta] " +
                            $"([venta], [producto], [cantidad], [precio]) " +
                            $"VALUES ({v.id}, {d.producto.codigo}, {d.cantidad}, CAST(REPLACE( '{d.precio}', ',', '.') as decimal))";
                        _BD.EjecutarTransaccion(sqltxt);

                        sqltxt = $"SELECT stock FROM producto WHERE codigo={d.producto.codigo}";

                        var stock =
                            int.Parse(_BD.ConsultaDuranteTransaccion(sqltxt).Rows[0]["stock"].ToString());
                        if (stock - d.cantidad < 0)
                            throw new ApplicationException("falta stock");

                        sqltxt = $"UPDATE [dbo].[producto] SET stock = '{stock - d.cantidad}' WHERE codigo={d.producto.codigo}";
                        _BD.EjecutarTransaccion(sqltxt);
                    }

                    tx.Commit();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    throw new ApplicationException("No se pudo guardar la venta." + ex.Message);
                }
                finally
                {
                    _BD.cerrar();

                }

            }
            return numVenta;
        }
    }
}
