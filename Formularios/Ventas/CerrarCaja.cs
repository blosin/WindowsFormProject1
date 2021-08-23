using Gestionador.Clases;
using Gestionador.Formularios.Caja;
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
    public partial class CerrarCaja : Form
    {

        RepositorioCaja repositorioCaja;
        Cajaa caja;
        int usuarioID;
        Principio principio;
        public CerrarCaja(Principio principio, int usuarioID)
        {
            InitializeComponent();
            repositorioCaja = new RepositorioCaja();
            caja = new Cajaa();
            this.usuarioID = usuarioID;
            this.principio = principio;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var confirmacion = MessageBox.Show("¿Esta seguro que desea salir, aun no cerro la caja?", "Confirme operacion", MessageBoxButtons.YesNo);
            if (confirmacion.Equals(DialogResult.No))
                return;
            else
            {
                this.Dispose();
            }
        }

        private void btnOtrosGastos_Click(object sender, EventArgs e)
        {
            var ventana = new OtrosGastos(this, usuarioID);
            ventana.ShowDialog();
        }

        private void btnRetiros_Click(object sender, EventArgs e)
        {
            var ventana = new Retiros(this, usuarioID);
            ventana.ShowDialog();
        }

        private void btnOtrosIngresos_Click(object sender, EventArgs e)
        {
            var ventana = new OtrosIngresos(this, usuarioID);
            ventana.ShowDialog();
        }

        private void CerrarCaja_Load(object sender, EventArgs e)
        {
            lblfecha.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm");// dd-MM-yyyy hh:mi");
            DataTable tablatemporal = repositorioCaja.ExisteCajaAbierta();
            if (tablatemporal.Rows.Count == 0)
            {
                MessageBox.Show("Aun no abrio la caja");
            }
            else
            {
                caja = repositorioCaja.ObtenerCajaActual();
                txtCajaActual.Text = caja.cajaActual.ToString();
                txtCajaInicial.Text = caja.cajaInicial.ToString();
                txtCompras.Text = caja.gastoCompras.ToString();
                txtOtrosGastos.Text = caja.otrosGastos.ToString();
                txtOtrosIngresos.Text = caja.otrosIngresos.ToString();
                txtRetiros.Text = caja.retiros.ToString();
                txtVentas.Text = caja.ventas.ToString();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            caja.fechaCerrado = DateTime.Now;


            if (repositorioCaja.CerrarCajaAbierta(caja))
            {
                MessageBox.Show("Se cerro con exito");
                principio.abrirCajaToolStripMenuItem1.Enabled = true;
                principio.cerrarCajaToolStripMenuItem1.Enabled = false;

                this.Dispose();
            }
            else
                MessageBox.Show("Error de actualizacion");
        }

        private void btnDetalleOtrosGastos_Click(object sender, EventArgs e)
        {
            var ventana = new DetalleOtrosGastos();
            ventana.ShowDialog();
        }

        private void btnDetalleRetiros_Click(object sender, EventArgs e)
        {
            var ventana = new DetalleRetiros();
            ventana.ShowDialog();
        }

        private void btnDetalleOtrosIngresos_Click(object sender, EventArgs e)
        {
            var ventana = new DetalleOtrosIngresos();
            ventana.ShowDialog();
        }


        public void ActualizarCaja()
        {
            caja = repositorioCaja.ObtenerCajaActual();
            txtCajaActual.Text = caja.cajaActual.ToString();
            txtCajaInicial.Text = caja.cajaInicial.ToString();
            txtCompras.Text = caja.gastoCompras.ToString();
            txtOtrosGastos.Text = caja.otrosGastos.ToString();
            txtOtrosIngresos.Text = caja.otrosIngresos.ToString();
            txtRetiros.Text = caja.retiros.ToString();
            txtVentas.Text = caja.ventas.ToString();
        }
    }
}
