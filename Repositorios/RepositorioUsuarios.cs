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
    class RepositorioUsuarios
    {
        private AccesoBD _BD;

        public RepositorioUsuarios()
        {
            _BD = new AccesoBD();
        }

        public DataTable ObtenerUsuarios()
        {
            string sqltxt = "SELECT * FROM usuarios";
            //
            return _BD.consulta(sqltxt);
        }

        public bool Guardar(Usuario usuario)
        {
            string sqltxt = "";

            sqltxt = $"INSERT dbo.usuarios (fechaMod, nombre, login, contrasena, observaciones, admin, aClientes, aCompras, aProductos, aProveedores, aUsuarios, aVentas, aCaja, aGenerarReportes)" +
                    $"VALUES ('{usuario.returnFechaModificacion()}', '{usuario.nombre}', '{usuario.login}', '{usuario.contrasena}', '{usuario.observaciones}', '{usuario.admin}', '{usuario.aClientes}', '{usuario.aCompras}', '{usuario.aProductos}', '{usuario.aProveedores}', '{usuario.aUsuarios}', '{usuario.aVentas}', '{usuario.aCaja}', '{usuario.aGenerarReportes}')";

            return _BD.EjecutarSQL(sqltxt);
        }
        public bool Eliminar(string usuarioID)
        {
            string sqltxt = $"DELETE FROM [dbo].[usuarios] WHERE id = '{usuarioID}'";

            return _BD.EjecutarSQL(sqltxt);
        }
        public DataTable UsuarioExistente(string login)
        {
            string sqltxt = $"SELECT * FROM usuarios WHERE login='{login}'";
            return _BD.consulta(sqltxt);
        }

        public bool Actualizar(Usuario usuario)
        {
            string sqltxt = $"UPDATE dbo.usuarios SET fechaMod= '{usuario.returnFechaModificacion()}', nombre = '{usuario.nombre}', " +
                $"login = '{usuario.login}', contrasena= '{usuario.contrasena}', observaciones = '{usuario.observaciones}', admin= '{usuario.admin}', " +
                $"aClientes= '{usuario.aClientes}', aCompras= '{usuario.aCompras}', aProductos= '{usuario.aProductos}', aProveedores= '{usuario.aProveedores}', aUsuarios= '{usuario.aUsuarios}', " +
                $"aVentas= '{usuario.aVentas}', aCaja= '{usuario.aCaja}', aGenerarReportes= '{usuario.aGenerarReportes}' WHERE id={usuario.id}";

            return _BD.EjecutarSQL(sqltxt);
        }

        public Usuario ObtenerUsuario(int UsuarioID)
        {
            string sqltxt = $"SELECT * FROM dbo.usuarios WHERE id={UsuarioID}";
            var tablaTemporal = _BD.consulta(sqltxt);

            if (tablaTemporal.Rows.Count == 0)
                return null;
            var usuario = new Usuario();
            foreach (DataRow fila in tablaTemporal.Rows)
            {
                if (fila.HasErrors)
                    continue;
                usuario.id = int.Parse(fila.ItemArray[0].ToString());
                usuario.fechaMod = DateTime.Parse(fila.ItemArray[1].ToString());
                usuario.nombre = fila.ItemArray[2].ToString();//DateTime.Parse(fila.ItemArray[2].ToString());
                usuario.login = fila.ItemArray[3].ToString();
                usuario.contrasena = fila.ItemArray[4].ToString();
                usuario.observaciones = fila.ItemArray[5].ToString();
                usuario.admin = int.Parse(fila.ItemArray[6].ToString());
                usuario.aClientes = int.Parse(fila.ItemArray[7].ToString());
                usuario.aCompras = int.Parse(fila.ItemArray[8].ToString());
                usuario.aProductos = int.Parse(fila.ItemArray[9].ToString());
                usuario.aProveedores = int.Parse(fila.ItemArray[10].ToString());
                usuario.aUsuarios = int.Parse(fila.ItemArray[11].ToString());
                usuario.aVentas = int.Parse(fila.ItemArray[12].ToString());
                usuario.aCaja = int.Parse(fila.ItemArray[13].ToString());
                usuario.aGenerarReportes = int.Parse(fila.ItemArray[14].ToString());


            }
            return usuario;
        }

        public Usuario ObtenerUsuarioConLogin(string login)
        {
            string sqltxt = $"SELECT * FROM dbo.usuarios WHERE login='{login}'";
            var tablaTemporal = _BD.consulta(sqltxt);

            if (tablaTemporal.Rows.Count == 0)
                return null;
            var usuario = new Usuario();
            foreach (DataRow fila in tablaTemporal.Rows)
            {
                if (fila.HasErrors)
                    continue;
                usuario.id = int.Parse(fila.ItemArray[0].ToString());
                usuario.fechaMod = DateTime.Parse(fila.ItemArray[1].ToString());
                usuario.nombre = fila.ItemArray[2].ToString();//DateTime.Parse(fila.ItemArray[2].ToString());
                usuario.login = fila.ItemArray[3].ToString();
                usuario.contrasena = fila.ItemArray[4].ToString();
                usuario.observaciones = fila.ItemArray[5].ToString();
                usuario.admin = int.Parse(fila.ItemArray[6].ToString());
                usuario.aClientes = int.Parse(fila.ItemArray[7].ToString());
                usuario.aCompras = int.Parse(fila.ItemArray[8].ToString());
                usuario.aProductos = int.Parse(fila.ItemArray[9].ToString());
                usuario.aProveedores = int.Parse(fila.ItemArray[10].ToString());
                usuario.aUsuarios = int.Parse(fila.ItemArray[11].ToString());
                usuario.aVentas = int.Parse(fila.ItemArray[12].ToString());
                usuario.aCaja = int.Parse(fila.ItemArray[13].ToString());
                usuario.aGenerarReportes = int.Parse(fila.ItemArray[14].ToString());


            }
            return usuario;
        }

    }
}
