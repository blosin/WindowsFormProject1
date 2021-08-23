using Gestionador.HelperBD;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestionador.Clases;
using Gestionador.Formularios;

namespace Gestionador.Repositorios
{
    class RepositorioArticulos
    {
        private AccesoBD _BD;

        public RepositorioArticulos()
        {
            _BD = new AccesoBD();
        }
        public bool GuardarSinMarcaSinRubro(Producto producto)
        {
            string sqltxt = "";    
            
            sqltxt = $"INSERT dbo.producto (codigo, descripcion, precio, costo, stock, stockMin, fechaMod)" +
                    $"VALUES ('{producto.codigo}', '{producto.descripcion}', REPLACE( '{producto.precio}', ',', '.'), REPLACE( '{producto.costo}', ',', '.'),'{producto.stock}', '{producto.stockMinimo}', '{producto.returnFechaModificacion()}')";
                       
            return _BD.EjecutarSQL(sqltxt);
        }
        public bool GuardarSinMarca(Producto producto)
        {
            string sqltxt = "";

            sqltxt = $"INSERT dbo.producto (codigo, descripcion, rubro, precio, costo, stock, stockMin, fechaMod)" +
                    $"VALUES ('{producto.codigo}', '{producto.descripcion}', '{producto.rubro}', REPLACE( '{producto.precio}', ',', '.'), REPLACE( '{producto.costo}', ',', '.'),'{producto.stock}', '{producto.stockMinimo}', '{producto.returnFechaModificacion()}')";

            return _BD.EjecutarSQL(sqltxt);
        }
        public bool GuardarSinRubro(Producto producto)
        {
            string sqltxt = "";

            sqltxt = $"INSERT dbo.producto (codigo, descripcion, marca, precio, costo, stock, stockMin, fechaMod)" +
                    $"VALUES ('{producto.codigo}', '{producto.descripcion}', '{producto.marca}', REPLACE( '{producto.precio}', ',', '.'), REPLACE( '{producto.costo}', ',', '.'),'{producto.stock}', '{producto.stockMinimo}', '{producto.returnFechaModificacion()}')";

            return _BD.EjecutarSQL(sqltxt);
        }

        public bool GuardarConTodo(Producto producto)
        {
            string sqltxt = "";

            sqltxt = $"INSERT dbo.producto (codigo, descripcion, marca, rubro, precio, costo, stock, stockMin, fechaMod)" +
                    $"VALUES ('{producto.codigo}', '{producto.descripcion}', '{producto.marca}', '{producto.rubro}', REPLACE( '{producto.precio}', ',', '.'), REPLACE( '{producto.costo}', ',', '.'),'{producto.stock}', '{producto.stockMinimo}', '{producto.returnFechaModificacion()}')";

            return _BD.EjecutarSQL(sqltxt);
        }

        public DataTable ObtenerProductos()
        {
            string sqltxt = "SELECT a.codigo, a.descripcion, b.nombre, c.nombre, a.precio, a.costo, a.stock, a.stockMin, a.fechaMod FROM producto a LEFT JOIN marca b ON a.marca = b.id LEFT JOIN rubro c ON a.rubro = c.id";//WHERE a.marca=marca.id AND a.rubro=rubro.id";
            //
            return _BD.consulta(sqltxt);
        }
        public DataTable ObtenerProductoConCodigo(string codigo)
        {
            string sqltxt = $"SELECT a.codigo, a.descripcion, b.nombre, c.nombre, a.precio, a.costo, a.stock, a.stockMin, a.fechaMod FROM producto a LEFT JOIN marca b ON a.marca = b.id LEFT JOIN rubro c ON a.rubro = c.id WHERE a.codigo LIKE ''{codigo}'%'";//WHERE a.nroDoc LIKE ''{numeroDoc}'%'"
            //"               SELECT a.codigo, a.descripcion, b.nombre, c.nombre, a.precio, a.costo, a.stock, a.stockMin, a.fechaMod FROM producto a LEFT JOIN marca b ON a.marca = b.id LEFT JOIN rubro c ON a.rubro = c.id"
            return _BD.consulta(sqltxt);
        }
        public DataTable ObtenerProductosPorDescripcion(string descripcion)
        {
            string sqltxt = $"SELECT a.codigo, a.descripcion, b.nombre, c.nombre, a.precio, a.costo, a.stock, a.stockMin, a.fechaMod FROM producto a LEFT JOIN marca b ON a.marca = b.id LEFT JOIN rubro c ON a.rubro = c.idWHERE a.descripcion LIKE ''{descripcion}'%'";//WHERE a.marca=marca.id AND a.rubro=rubro.id";
            //
            return _BD.consulta(sqltxt);
        }


        public bool Eliminar(string productoID)
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
                if(fila.ItemArray[2]==null)
                {
                    producto.marca =null;
                }
                else
                {
                    int defaul;
                    if (int.TryParse(fila.ItemArray[2].ToString(), out defaul))
                    producto.marca = defaul;
                }
                if(fila.ItemArray[3]==null)
                {
                    producto.rubro = null;
                }
                else
                {
                    int defaul;
                    if(int.TryParse(fila.ItemArray[3].ToString(), out defaul))
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

        public DataTable ObtenerProductoConCodigoFinal(string codigo)
        {
            string sqltxt = $"SELECT a.codigo, a.descripcion, b.nombre, c.nombre, a.precio, a.costo, a.stock, a.stockMin, a.fechaMod FROM producto a LEFT JOIN marca b ON a.marca = b.id LEFT JOIN rubro c ON a.rubro = c.id WHERE a.codigo ='{codigo}'";//WHERE a.nroDoc LIKE ''{numeroDoc}'%'"
            //"               SELECT a.codigo, a.descripcion, b.nombre, c.nombre, a.precio, a.costo, a.stock, a.stockMin, a.fechaMod FROM producto a LEFT JOIN marca b ON a.marca = b.id LEFT JOIN rubro c ON a.rubro = c.id"
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
