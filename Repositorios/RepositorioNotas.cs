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
    class RepositorioNotas
    {
        private AccesoBD _BD;

        public RepositorioNotas()
        {
            _BD = new AccesoBD();
        }


        public DataTable ObtenerNotas()// nombre+' '+\'('+cuit+\')' as proveedores
        {
            string sqltxt = "SELECT a.id, b.nombre+' '+\'('+b.login+\')' as usuario, a.fechaCreacion, c.nombre, a.mensaje FROM notas a, usuarios b, estados c WHERE a.usuario=b.id AND a.estado=c.id";
            //
            return _BD.consulta(sqltxt);
        }


        public bool Guardar(Nota nota)
        {
            string sqltxt = "";

            sqltxt = $"INSERT dbo.notas (usuario, fechaCreacion, estado, mensaje)" +
                    $"VALUES ('{nota.usuario}', '{nota.returnFechaCreacion()}', '{nota.estado}', '{nota.mensaje}')";

            return _BD.EjecutarSQL(sqltxt);
        }
        public bool Eliminar(string notaID)
        {
            string sqltxt = $"DELETE FROM [dbo].[notas] WHERE id = '{notaID}'";

            return _BD.EjecutarSQL(sqltxt);
        }

        public Nota ObtenerNotaParticular(string notaID)
        {
            string sqltxt = $"SELECT a.id, b.nombre+' '+\'('+b.login+\')' as usuario, a.fechaCreacion, a.estado, a.mensaje FROM notas a, usuarios b WHERE a.usuario=b.id AND a.id={notaID}";
            var tablaTemporal = _BD.consulta(sqltxt);

            if (tablaTemporal.Rows.Count == 0)
                return null;
            var nota = new Nota();
            foreach (DataRow fila in tablaTemporal.Rows)
            {
                if (fila.HasErrors)
                    continue;
                nota.id = int.Parse(fila.ItemArray[0].ToString());
                nota.usuarioParticular = fila.ItemArray[1].ToString();
                nota.fechaCreacion = DateTime.Parse(fila.ItemArray[2].ToString());
                nota.mensaje = fila.ItemArray[4].ToString();

                if(int.Parse(fila.ItemArray[3].ToString())==0)
                {
                    string sqltxt2 = $"UPDATE dbo.notas SET estado = 1 WHERE id='{notaID}'";
                    _BD.EjecutarSQL(sqltxt2);
                }
                             


            }
            return nota;
        }

    }
}
