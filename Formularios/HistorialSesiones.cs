using Gestionador.Repositorios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestionador.Formularios
{
    public partial class HistorialSesiones : Form
    {
        RepositorioSesiones repositorioSesiones;
        public HistorialSesiones()
        {
            InitializeComponent();
            repositorioSesiones = new RepositorioSesiones();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void HistorialSesiones_Load(object sender, EventArgs e)
        {
            ActualizarSesiones();
        }
        public void ActualizarSesiones()
        {
            dgvSesiones.Rows.Clear();
            var sesiones = repositorioSesiones.ObtenerSesiones().Rows;
            ActualizarGrilla(sesiones);
        }
        private void ActualizarGrilla(DataRowCollection registros)
        {
            foreach (DataRow registro in registros)
            {
                if (registro.HasErrors)
                    continue; // no corto el ciclo
                var fila = new string[] {
                    registro.ItemArray[0].ToString(),
                    registro.ItemArray[3].ToString(),
                    registro.ItemArray[1].ToString(),
                    registro.ItemArray[2].ToString(),
                    registro.ItemArray[4].ToString(),                   

                };

                dgvSesiones.Rows.Add(fila);
            }
        }
    }
}
