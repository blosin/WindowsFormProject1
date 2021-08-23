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

namespace Gestionador.Formularios.Ventas
{
    public partial class DetalleVenta : Form
    {
        int id;
        decimal monto;
        RepositorioVentas repositorioVentas;
        public DetalleVenta(int id, decimal monto)
        {
            InitializeComponent();
            this.id = id;
            this.monto = monto;
            repositorioVentas = new RepositorioVentas();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void DetalleVenta_Load(object sender, EventArgs e)
        {
            ActualizarDetalle();
            txtTotal.Text = "$$"+monto.ToString();
        }

        public void ActualizarDetalle()
        {
            dgvDetalle.Rows.Clear();
            var detalles = repositorioVentas.ObtenerDetalles(id).Rows;
            ActualizarGrilla(detalles);
        }

        private void ActualizarGrilla(DataRowCollection registros)
        {
            foreach (DataRow registro in registros)
            {
                if (registro.HasErrors)
                    continue; // no corto el ciclo
                var fila = new string[] {
                    registro.ItemArray[0].ToString(),
                    registro.ItemArray[1].ToString(),
                    registro.ItemArray[2].ToString(),                    
                    registro.ItemArray[4].ToString(),
                    registro.ItemArray[5].ToString(),

                };

                dgvDetalle.Rows.Add(fila);
            }
        }
    }
}
