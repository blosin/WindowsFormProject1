using Gestionador.Clases;
using Gestionador.Formularios.Ventas;
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
    public partial class Retiros : Form
    {
        RepositorioCaja repositorioCaja;
        RepositorioDetallesCaja repositorioDetallesCaja;
        Retiro retiro;
        Cajaa cajaa;
        Caja caja;
        CerrarCaja cerrarCaja;
        int id;
        public Retiros(Caja cajaaaaaa, int id)
        {
            InitializeComponent();
            repositorioDetallesCaja = new RepositorioDetallesCaja();
            repositorioCaja = new RepositorioCaja();
            cajaa = repositorioCaja.ObtenerCajaActual();
            retiro = new Retiro();
            caja = cajaaaaaa;
            this.id = id;
        }
        public Retiros(CerrarCaja cajaaaaaa, int id)
        {
            InitializeComponent();
            repositorioDetallesCaja = new RepositorioDetallesCaja();
            repositorioCaja = new RepositorioCaja();
            cajaa = repositorioCaja.ObtenerCajaActual();
            retiro = new Retiro();
            cerrarCaja = cajaaaaaa;
            this.id = id;
        }
        public Retiros()
        {
            InitializeComponent();
            repositorioDetallesCaja = new RepositorioDetallesCaja();
            repositorioCaja = new RepositorioCaja();
            cajaa = repositorioCaja.ObtenerCajaActual();
            retiro = new Retiro();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Retiros_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm");// dd-MM-yyyy hh:mi");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtDetalle.Text == "")
            {
                MessageBox.Show("Debe ingresar detalle");
                return;
            }

            if (txtImporte.Text == "")
            {
                MessageBox.Show("Debe ingresar el importe");
                return;
            }

            cajaa.retiros += decimal.Parse(txtImporte.Text);
            cajaa.cajaActual -= decimal.Parse(txtImporte.Text);

            retiro.fecha = DateTime.Now;
            retiro.detalle = txtDetalle.Text;
            retiro.importe = decimal.Parse(txtImporte.Text);
            if (txtObservaciones.Text == "")
            {
                retiro.observaciones = "--Sin observaciones--";
            }
            else
            {
                retiro.observaciones = txtObservaciones.Text;
            }
            retiro.caja = cajaa.id;
            retiro.usuario = id;

            if (cajaa.otrosGastosValido() == false)
            {
                MessageBox.Show("Gasto invalido");
                return;
            }
            if (cajaa.cajaActualValida() == false)
            {
                MessageBox.Show("Gasto invalido, caja actual");
                return;
            }

            if (retiro.detalleValido() == false)
            {
                MessageBox.Show("Error detalle");
                return;
            }
            if (retiro.importeValido() == false)
            {
                MessageBox.Show("Importe invalido");
                return;
            }
            if (retiro.observacionesValido() == false)
            {
                MessageBox.Show("Error en observaciones");
                return;
            }
            if (retiro.usuarioValido() == false)
            {
                MessageBox.Show("Error usuario");
                return;
            }
            if (retiro.cajaValido() == false)
            {
                MessageBox.Show("Error id de Caja");
                return;
            }








            try
            {
                repositorioCaja.ActualizarCajaRetiros(cajaa);
                repositorioDetallesCaja.GuardarRetiro(retiro);
            }
            catch(Exception ex)
            {
                MessageBox.Show("error al guardar"+ex);
                return;
            }
            try
            {
                caja.ActualizarCaja();
            }
            catch { }

            try
            {
                cerrarCaja.ActualizarCaja();
            }
            catch { }
            
            this.Dispose();
        }

        private void txtImporte_KeyUp(object sender, KeyEventArgs e)
        {
            decimal defaul;
            if (decimal.TryParse(txtImporte.Text, out defaul))
            {

            }
            else
            {
                txtImporte.Text = "";
                txtImporte.Focus();
                return;
            }
        }
    }
}
