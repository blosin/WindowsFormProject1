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

namespace Gestionador.Formularios.Compras
{
    public partial class CompraAnterior : Form
    {
        RepositorioCompras repositorioCompras;
        public CompraAnterior()
        {
            InitializeComponent();
            repositorioCompras = new RepositorioCompras();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {


            var seleccion = dgvCompras.SelectedRows;
            if (seleccion.Count == 0 || seleccion.Count > 1)
            {
                MessageBox.Show("Debe seleccionar una fila");
                return;
            }
            foreach (DataGridViewRow fila in seleccion)
            {
                var numCompra = fila.Cells[0].Value;
                var montoTotal = fila.Cells[7].Value;

                var ventana = new DetalleCompra(int.Parse(numCompra.ToString()), decimal.Parse(montoTotal.ToString()));
                //new DetalleCompra(numOrden.ToString(), decimal.Parse(montoTotal.ToString()));
                ventana.ShowDialog();

            }
        }

        private void CompraAnterior_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm");

            ActualizarCompras();
        }

        public void ActualizarCompras()
        {
            dgvCompras.Rows.Clear();
            var compras = repositorioCompras.ObtenerComprasAnteriores().Rows;
            ActualizarGrilla(compras);
        }
        private void ActualizarGrilla(DataRowCollection registros)
        {
            foreach (DataRow registro in registros)
            {
                if (registro.HasErrors)
                    continue; // no corto el ciclo
                var fila = new string[] {
                    registro.ItemArray[0].ToString(),
                    registro.ItemArray[7].ToString(),
                    registro.ItemArray[1].ToString(),
                    registro.ItemArray[2].ToString(),
                    registro.ItemArray[3].ToString(),
                    registro.ItemArray[4].ToString(),
                    registro.ItemArray[5].ToString(),
                    registro.ItemArray[6].ToString(),



                };

                dgvCompras.Rows.Add(fila);
            }
        }
    }
}
