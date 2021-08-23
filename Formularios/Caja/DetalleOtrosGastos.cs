using Gestionador.Clases;
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

namespace Gestionador.Formularios.Caja
{
    public partial class DetalleOtrosGastos : Form
    {
        RepositorioDetallesCaja repositorioDetalles;
        Cajaa cajaa;
        RepositorioCaja repositorioCaja;
        public DetalleOtrosGastos()
        {
            InitializeComponent();
            repositorioDetalles = new RepositorioDetallesCaja();
            repositorioCaja = new RepositorioCaja();
            cajaa = repositorioCaja.ObtenerCajaActual();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void DetalleOtrosGastos_Load(object sender, EventArgs e)
        {
            ActualizarOtrosGastos();
        }
        public void ActualizarOtrosGastos()
        {
            dgvOtrosGastos.Rows.Clear();
            var otrosGastos = repositorioDetalles.ObtenerDetallesOtrosGastos(cajaa.id).Rows;
            ActualizarGrilla(otrosGastos);
        }

        private void ActualizarGrilla(DataRowCollection registros)
        {
            foreach (DataRow registro in registros)
            {
                if (registro.HasErrors)
                    continue; // no corto el ciclo
                var fila = new string[] {

                    registro.ItemArray[0].ToString(),
                    registro.ItemArray[6].ToString(),
                    registro.ItemArray[1].ToString(),
                    registro.ItemArray[2].ToString(),
                    registro.ItemArray[3].ToString(),
                    registro.ItemArray[4].ToString(),
                    registro.ItemArray[5].ToString(),





                };

                dgvOtrosGastos.Rows.Add(fila);
            }
        }
    }
}
