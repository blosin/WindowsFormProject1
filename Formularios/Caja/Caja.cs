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
    public partial class Caja : Form
    {
        RepositorioCaja repositorioCaja;
        Cajaa caja;
        int usuarioID;

        public Caja(int UsuarioID)
        {
            InitializeComponent();
            repositorioCaja = new RepositorioCaja();
            caja = new Cajaa();
            usuarioID = UsuarioID;
        }

        private void Caja_Load(object sender, EventArgs e)
        {
            //lblfecha.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm");// dd-MM-yyyy hh:mi");
            lblTitulo.Text += " " + DateTime.Now.ToString("dd-MM-yyyy HH:mm");
            DataTable tablatemporal = repositorioCaja.ExisteCajaAbierta();
            if (tablatemporal.Rows.Count == 0)
            {
                MessageBox.Show("Aun no abrio la caja");
            }
            else
            {
                caja= repositorioCaja.ObtenerCajaActual();
                txtCajaActual.Text = caja.cajaActual.ToString();
                txtCajaInicial.Text = caja.cajaInicial.ToString();
                txtGastoCompras.Text = caja.gastoCompras.ToString();
                txtOtrosGastos.Text = caja.otrosGastos.ToString();
                txtOtrosIngresos.Text = caja.otrosIngresos.ToString();
                txtRetiros.Text = caja.retiros.ToString();
                txtVentas.Text = caja.ventas.ToString();
            }

            

            
        }
        public void ActualizarCaja()
        {
            caja = repositorioCaja.ObtenerCajaActual();
            txtCajaActual.Text = caja.cajaActual.ToString();
            txtCajaInicial.Text = caja.cajaInicial.ToString();
            txtGastoCompras.Text = caja.gastoCompras.ToString();
            txtOtrosGastos.Text = caja.otrosGastos.ToString();
            txtOtrosIngresos.Text = caja.otrosIngresos.ToString();
            txtRetiros.Text = caja.retiros.ToString();
            txtVentas.Text = caja.ventas.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            var ventana = new OtrosGastos(this, usuarioID);
            ventana.ShowDialog();

        }

        private void btnOtrosIngresos_Click(object sender, EventArgs e)
        {
            var ventana = new OtrosIngresos(this, usuarioID);
            ventana.ShowDialog();
        }

        private void btnRetiros_Click(object sender, EventArgs e)
        {
            var ventana = new Retiros(this, usuarioID);
            ventana.ShowDialog();
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
    }
}
