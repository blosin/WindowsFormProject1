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
    
    class RepositorioClientes
    {
        private AccesoBD _BD;


        public RepositorioClientes()
        {
            _BD = new AccesoBD();
        }


        public DataTable ObtenerClientes()
        {
            string sqltxt = "SELECT a.id, a.nombre, a.fechaNac, b.nombre, a.nroDoc, a.direccion, a.localidad, c.nombre, a.telFijo, a.telCel, d.nombre, a.cuit, a.montoCuenta, a.mail, a.observaciones, a.codPostal, a.montoUsado, a.fechaMod FROM cliente a, tipoDoc b, provincia c, iva d WHERE a.tipoDoc=b.id AND a.provincia=c.id AND a.condIVA=d.id";//WHERE a.marca=marca.id AND a.rubro=rubro.id";
            //
            return _BD.consulta(sqltxt);
        }
        public DataTable ObtenerClienteTableDoc(string numeroDoc)
        {
            string sqltxt = $"SELECT a.id, a.nombre, a.fechaNac, b.nombre, a.nroDoc, a.direccion, a.localidad, c.nombre, a.telFijo, a.telCel, d.nombre, a.cuit, a.montoCuenta, a.mail, a.observaciones, a.codPostal, a.montoUsado, a.fechaMod FROM cliente a, tipoDoc b, provincia c, iva d WHERE a.tipoDoc=b.id AND a.provincia=c.id AND a.condIVA=d.id WHERE a.nroDoc LIKE ''{numeroDoc}'%'";//WHERE a.marca=marca.id AND a.rubro=rubro.id";
            //
            return _BD.consulta(sqltxt);
        }
        public DataTable ObtenerClienteTableNombre(string nombre)
        {
            string sqltxt = $"SELECT a.id, a.nombre, a.fechaNac, b.nombre, a.nroDoc, a.direccion, a.localidad, c.nombre, a.telFijo, a.telCel, d.nombre, a.cuit, a.montoCuenta, a.mail, a.observaciones, a.codPostal, a.montoUsado, a.fechaMod FROM cliente a, tipoDoc b, provincia c, iva d WHERE a.tipoDoc=b.id AND a.provincia=c.id AND a.condIVA=d.id WHERE a.nombre LIKE ''{nombre}'%'";//WHERE a.marca=marca.id AND a.rubro=rubro.id";
            //
            return _BD.consulta(sqltxt);
        }


        public bool Guardar(Cliente cliente)
        {
            string sqltxt = "";

            sqltxt = $"INSERT dbo.cliente (nombre, fechaNac, tipoDoc, nroDoc, direccion, localidad, provincia, telFijo, telCel, condIVA, cuit, montoCuenta, mail, observaciones, codPostal, montoUsado, fechaMod)" +
                    $"VALUES ('{cliente.nombre}', '{cliente.returnFechaNacimiento()}', '{cliente.tipoDoc}', '{cliente.nroDoc}', '{cliente.direccion}', '{cliente.localidad}', '{cliente.provincia}', '{cliente.telFijo}', '{cliente.telCel}', '{cliente.condIVA}', '{cliente.cuit}', '{cliente.montoCuenta}', '{cliente.mail}', '{cliente.observaciones}', '{cliente.codPostal}', '{cliente.montoUsado}', '{cliente.returnFechaModificacion()}')";

            return _BD.EjecutarSQL(sqltxt);
        }
        public bool Eliminar(string clienteID)
        {
            string sqltxt = $"DELETE FROM [dbo].[cliente] WHERE id = '{clienteID}'";

            return _BD.EjecutarSQL(sqltxt);
        }
        public DataTable ClienteExistente(string documento)
        {
            string sqltxt = $"SELECT * FROM cliente WHERE nroDoc='{documento}'";
            return _BD.consulta(sqltxt);
        }        

        public bool Actualizar(Cliente cliente)
        {
            string sqltxt = $"UPDATE dbo.cliente SET nombre= '{cliente.nombre}', fechaNac = '{cliente.returnFechaNacimiento()}', " +
                $"tipoDoc = '{cliente.tipoDoc}', nroDoc= '{cliente.nroDoc}', direccion = '{cliente.direccion}', localidad= '{cliente.localidad}', " +
                $"provincia= '{cliente.provincia}', telFijo= '{cliente.telFijo}', telCel= '{cliente.telCel}', condIVA= '{cliente.condIVA}', cuit= '{cliente.cuit}', " +
                $"montoCuenta= '{cliente.montoCuenta}', mail= '{cliente.mail}', observaciones= '{cliente.observaciones}', " +
                $"codPostal= '{cliente.codPostal}', montoUsado= '{cliente.montoUsado}', fechaMod= '{cliente.returnFechaModificacion()}' " +
                $"WHERE id={cliente.id}";

            return _BD.EjecutarSQL(sqltxt);
        }

        public Cliente ObtenerCliente(string clienteID)
        {
            string sqltxt = $"SELECT * FROM dbo.cliente WHERE id={clienteID}";
            var tablaTemporal = _BD.consulta(sqltxt);

            if (tablaTemporal.Rows.Count == 0)
                return null;
            var cliente = new Cliente();
            foreach (DataRow fila in tablaTemporal.Rows)
            {
                if (fila.HasErrors)
                    continue;
                cliente.id = int.Parse(fila.ItemArray[0].ToString());
                cliente.nombre= fila.ItemArray[1].ToString();
                cliente.fechaNac = DateTime.Parse(fila.ItemArray[2].ToString());
                cliente.tipoDoc= int.Parse(fila.ItemArray[3].ToString());
                cliente.nroDoc= fila.ItemArray[4].ToString();
                cliente.direccion= fila.ItemArray[5].ToString();
                cliente.localidad=fila.ItemArray[6].ToString();
                cliente.provincia= int.Parse(fila.ItemArray[7].ToString());
                cliente.telFijo= fila.ItemArray[8].ToString();
                cliente.telCel= fila.ItemArray[9].ToString();
                cliente.condIVA = int.Parse(fila.ItemArray[10].ToString());
                cliente.cuit= fila.ItemArray[11].ToString();
                cliente.montoCuenta = decimal.Parse(fila.ItemArray[12].ToString());
                cliente.mail= fila.ItemArray[13].ToString();
                cliente.observaciones= fila.ItemArray[14].ToString();
                cliente.codPostal= fila.ItemArray[15].ToString();
                cliente.montoUsado = decimal.Parse(fila.ItemArray[16].ToString());
                cliente.fechaMod = DateTime.Parse(fila.ItemArray[17].ToString());
                
            }
            return cliente;
        }

    }
}

