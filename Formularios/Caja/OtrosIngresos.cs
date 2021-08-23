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
    public partial class OtrosIngresos : Form
    {
        RepositorioDetalleIngresos repositorioDetalleIngresos;
        RepositorioCaja repositorioCaja;
        RepositorioDetallesCaja repositorioDetallesCaja;
        OtroIngreso otroIngreso;
        Cajaa cajaa;
        Caja caja;
        CerrarCaja cerrarCaja;
        int id;
        public OtrosIngresos(Caja cajaaaaaa,int id)
        {
            InitializeComponent();
            repositorioDetalleIngresos = new RepositorioDetalleIngresos();
            repositorioDetallesCaja = new RepositorioDetallesCaja();
            repositorioCaja = new RepositorioCaja();
            cajaa = repositorioCaja.ObtenerCajaActual();
            otroIngreso = new OtroIngreso();
            caja = cajaaaaaa;
            this.id = id;
        }
        public OtrosIngresos(CerrarCaja cajaaaaaa, int id)
        {
            InitializeComponent();
            repositorioDetalleIngresos = new RepositorioDetalleIngresos();
            repositorioDetallesCaja = new RepositorioDetallesCaja();
            repositorioCaja = new RepositorioCaja();
            cajaa = repositorioCaja.ObtenerCajaActual();
            otroIngreso = new OtroIngreso();
            cerrarCaja = cajaaaaaa;
            this.id = id;
        }
        public OtrosIngresos()
        {
            InitializeComponent();
            repositorioDetalleIngresos = new RepositorioDetalleIngresos();
            repositorioDetallesCaja = new RepositorioDetallesCaja();
            repositorioCaja = new RepositorioCaja();
            cajaa = repositorioCaja.ObtenerCajaActual();
            otroIngreso = new OtroIngreso();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void OtrosIngresos_Load(object sender, EventArgs e)
        {

            DataTable Detalles;

            Detalles = repositorioDetalleIngresos.ObtenerDetalles();
            cmbDetalle.DataSource = Detalles;
            cmbDetalle.ValueMember = "id";
            cmbDetalle.DisplayMember = "nombre";

            cmbDetalle.SelectedIndex = -1;
            lblFecha.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm");// dd-MM-yyyy hh:mi");
        }

        public void cargarCombos()
        {
            DataTable Detalles;

            Detalles = repositorioDetalleIngresos.ObtenerDetalles();
            cmbDetalle.DataSource = Detalles;
            cmbDetalle.ValueMember = "id";
            cmbDetalle.DisplayMember = "nombre";

            cmbDetalle.SelectedIndex = -1;

            lblFecha.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            var ventana = new DetalleIngresos();
            ventana.ShowDialog();
            cargarCombos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbDetalle.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar el detalle");
                return;
            }

            if (txtImporte.Text == "")
            {
                MessageBox.Show("Debe ingresar el importe");
                return;
            }

            cajaa.otrosIngresos += decimal.Parse(txtImporte.Text);
            cajaa.cajaActual += decimal.Parse(txtImporte.Text);

            otroIngreso.fecha = DateTime.Now;
            otroIngreso.detalle = int.Parse(cmbDetalle.SelectedValue.ToString());
            otroIngreso.importe = decimal.Parse(txtImporte.Text);
            if (txtObservaciones.Text == "")
            {
                otroIngreso.observaciones = "--Sin observaciones--";
            }
            else
            {
                otroIngreso.observaciones = txtObservaciones.Text;
            }
            otroIngreso.caja = cajaa.id;
            otroIngreso.usuario = id;

            if (cajaa.otrosGastosValido() == false)
            {
                MessageBox.Show("Gasto invalido");
                return;
            }
            if (cajaa.cajaActualValida() == false)
            {
                MessageBox.Show("Gasto invalido");
                return;
            }

            if (otroIngreso.detalleValido() == false)
            {
                MessageBox.Show("Error detalle");
                return;
            }
            if (otroIngreso.importeValido() == false)
            {
                MessageBox.Show("Importe invalido");
                return;
            }
            if (otroIngreso.observacionesValido() == false)
            {
                MessageBox.Show("Error en observaciones");
                return;
            }
            if (otroIngreso.usuarioValido() == false)
            {
                MessageBox.Show("Error usuario");
                return;
            }
            if (otroIngreso.cajaValido() == false)
            {
                MessageBox.Show("Error id de Caja");
                return;
            }



            try
            {
                repositorioCaja.ActualizarCajaIngresos(cajaa);
                repositorioDetallesCaja.GuardarOtroIngreso(otroIngreso);
            }
            catch
            {
                MessageBox.Show("error al guardar");
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
