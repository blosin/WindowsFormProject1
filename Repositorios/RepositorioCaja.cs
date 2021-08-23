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
    class RepositorioCaja
    {
        private AccesoBD _BD;

        public RepositorioCaja()
        {
            _BD = new AccesoBD();
        }

        public bool EstablecerCajaInicial(decimal montoInicio)
        {
            string sqltxt = "";

            sqltxt = $"INSERT dbo.cajas (cajaInicial, cajaActual, gastoCompras, otrosGastos, retiros, Ventas, otrosIngresos, fechaApertura)" +
                    $"VALUES (REPLACE( '{montoInicio}', ',', '.'), REPLACE( '{montoInicio}', ',', '.'), 0, 0, 0, 0, 0, '{DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff")}')";//ToString("yyyy-MM-ddTHH:mm:ss.fff");

            return _BD.EjecutarSQL(sqltxt);
        }

        public bool ActualizarCajaGastos(Cajaa cajaa)
        {
            string sqltxt = $"UPDATE dbo.cajas SET cajaActual = REPLACE( '{cajaa.cajaActual}', ',', '.'), otrosGastos = REPLACE( '{cajaa.otrosGastos}', ',', '.') WHERE fechaCerrado IS NULL";//
            return _BD.EjecutarSQL(sqltxt);
        }
        public bool ActualizarCajaIngresos(Cajaa cajaa)
        {
            string sqltxt = $"UPDATE dbo.cajas SET cajaActual = REPLACE( '{cajaa.cajaActual}', ',', '.'), otrosIngresos = REPLACE( '{cajaa.otrosIngresos}', ',', '.') WHERE fechaCerrado IS NULL";//
            return _BD.EjecutarSQL(sqltxt);
        }
        public bool ActualizarCajaRetiros(Cajaa cajaa)
        {
            string sqltxt = $"UPDATE dbo.cajas SET cajaActual = REPLACE( '{cajaa.cajaActual}', ',', '.'), retiros = REPLACE( '{cajaa.retiros}', ',', '.') WHERE fechaCerrado IS NULL";//
            return _BD.EjecutarSQL(sqltxt);
        }


        public bool ActualizarCajaPorCompras(Cajaa cajaa)
        {
            string sqltxt = $"UPDATE dbo.cajas SET cajaActual = REPLACE( '{cajaa.cajaActual}', ',', '.'), castoCompras = REPLACE( '{cajaa.gastoCompras}', ',', '.') WHERE fechaCerrado IS NULL";//
            return _BD.EjecutarSQL(sqltxt);
        }

        public bool ActualizarCajaPorVentas(Cajaa cajaa)
        {
            string sqltxt = $"UPDATE dbo.cajas SET cajaActual = REPLACE( '{cajaa.cajaActual}', ',', '.'), castoCompras = REPLACE( '{cajaa.ventas}', ',', '.') WHERE fechaCerrado IS NULL";//
            return _BD.EjecutarSQL(sqltxt);
        }






        public DataTable ExisteCajaAbierta()
        {
            string sqltxt = $"SELECT * FROM cajas WHERE fechaCerrado IS NULL";//SELECT * FROM cajas WHERE fechaCerrado IS NULL
            return _BD.consulta(sqltxt);
        }
        public Cajaa ObtenerCajaActual()
        {
            string sqltxt = $"SELECT * FROM cajas WHERE fechaCerrado IS NULL";//WHERE a.marca=marca.id AND a.rubro=rubro.id";
            //           
            var tablaTemporal = _BD.consulta(sqltxt);

            if (tablaTemporal.Rows.Count == 0)
                return null;
            var caja = new Cajaa();
            foreach (DataRow fila in tablaTemporal.Rows)
            {
                //DateTime fecha1;
                if (fila.HasErrors)
                    continue;
                caja.id = int.Parse(fila.ItemArray[0].ToString());
                caja.cajaInicial = decimal.Parse(fila.ItemArray[1].ToString());
                caja.cajaActual = decimal.Parse(fila.ItemArray[2].ToString());
                caja.gastoCompras = decimal.Parse(fila.ItemArray[3].ToString());
                caja.otrosGastos = decimal.Parse(fila.ItemArray[4].ToString());
                caja.retiros = decimal.Parse(fila.ItemArray[5].ToString());
                caja.ventas = decimal.Parse(fila.ItemArray[6].ToString());
                caja.otrosIngresos = decimal.Parse(fila.ItemArray[7].ToString());
                caja.fechaApertura = DateTime.Parse(fila.ItemArray[8]?.ToString());
                /*if (fila.ItemArray[9].ToString() == "")
                {
                    //caja.fechaCerrado = null;
                }
                else
                {
                    
                    caja.fechaCerrado = DateTime.Parse(fila.ItemArray[9]?.ToString());                    
                }*/           


            }
            return caja;
        }

        public bool CerrarCajaAbierta(Cajaa caja)
        {
            string sqltxt = "";

            sqltxt = $"UPDATE dbo.cajas SET cajaAnterior = 0 WHERE cajaAnterior = 1";

            _BD.EjecutarSQL(sqltxt);

            sqltxt = $"UPDATE dbo.cajas SET fechaCerrado = '{caja.returnFechaCerrado()}', cajaAnterior 1 WHERE id='{caja.id}'";

            //                         SET         stock = '{producto.stock}',           fechaMod ='{producto.returnFechaModificacion()}' WHERE codigo='{producto.codigo}'";

            return _BD.EjecutarSQL(sqltxt);

            
        }
        

        /*public bool Eliminar(string productoID)
        {
            string sqltxt = $"DELETE FROM [dbo].[producto] WHERE codigo = '{productoID}'";

            return _BD.EjecutarSQL(sqltxt);
        }

        public Producto ObtenerProducto(string productoID)
        {
            string sqltxt = $"SELECT * FROM dbo.producto WHERE codigo='{productoID}'";
            var tablaTemporal = _BD.consulta(sqltxt);

            if (tablaTemporal.Rows.Count == 0)
                return null;
            var producto = new Producto();
            foreach (DataRow fila in tablaTemporal.Rows)
            {
                //DateTime fecha1;
                if (fila.HasErrors)
                    continue;
                producto.codigo = fila.ItemArray[0].ToString();
                producto.descripcion = fila.ItemArray[1].ToString();
                if (fila.ItemArray[2] == null)
                {
                    producto.marca = null;
                }
                else
                {
                    int defaul;
                    if (int.TryParse(fila.ItemArray[2].ToString(), out defaul))
                        producto.marca = defaul;
                }
                if (fila.ItemArray[3] == null)
                {
                    producto.rubro = null;
                }
                else
                {
                    int defaul;
                    if (int.TryParse(fila.ItemArray[3].ToString(), out defaul))
                    {
                        producto.rubro = defaul;
                    }

                }

                producto.precio = decimal.Parse(fila.ItemArray[4].ToString());
                producto.costo = decimal.Parse(fila.ItemArray[5].ToString());
                producto.stock = int.Parse(fila.ItemArray[6].ToString());
                producto.stockMinimo = int.Parse(fila.ItemArray[7].ToString());
                producto.fechaModificacion = DateTime.Parse(fila.ItemArray[8]?.ToString());


            }
            return producto;
        }
        public bool ActualizarStock(Producto producto)
        {
            string sqltxt = $"UPDATE dbo.producto SET stock = '{producto.stock}', fechaMod ='{producto.returnFechaModificacion()}' WHERE codigo='{producto.codigo}'";
            return _BD.EjecutarSQL(sqltxt);
        }

        public DataTable ProductoExistente(string codigo)
        {
            string sqltxt = $"SELECT * FROM producto WHERE codigo='{codigo}'";
            return _BD.consulta(sqltxt);
        }
        /*public bool Actualizar(Producto producto)
         {
             string sqltxt;
             sqltxt = $"UPDATE dbo.producto SET codigo = '{producto.codigo}', descripcion = '{producto.descripcion}', " +
                     $"marca = '{producto.marca}', rubro='{producto.rubro}', precio = CAST(REPLACE( '{producto.precio}', ',', '.') as decimal), " +
                     $"costo = CAST(REPLACE( '{producto.costo}', ',', '.') as decimal), stockMin = '{producto.stockMinimo}', fechaMod = '{producto.returnFechaModificacion()}'" +
                     $"WHERE codigo={producto.}";



             return _BD.EjecutarSQL(sqltxt);
         }*/
        /*         */

    }
}
