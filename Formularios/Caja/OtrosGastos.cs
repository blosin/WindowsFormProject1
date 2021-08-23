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
    public partial class OtrosGastos : Form
    {
        RepositorioDetalleGastos repositorioDetalleGastos;
        RepositorioCaja repositorioCaja;
        RepositorioDetallesCaja repositorioDetallesCaja;
        OtroGasto otroGasto;
        Cajaa cajaa;
        Caja caja;
        CerrarCaja cerrarCaja;
        int id;
        //positorio


        public OtrosGastos(Caja cajaaaaaa, int id)
        {
            InitializeComponent();
            repositorioDetalleGastos = new RepositorioDetalleGastos();
            repositorioDetallesCaja = new RepositorioDetallesCaja();
            repositorioCaja = new RepositorioCaja();
            cajaa = repositorioCaja.ObtenerCajaActual();
            otroGasto = new OtroGasto();
            caja = cajaaaaaa;
            this.id = id;

        }
        public OtrosGastos(CerrarCaja cajaaaaaa, int id)
        {
            InitializeComponent();
            repositorioDetalleGastos = new RepositorioDetalleGastos();
            repositorioDetallesCaja = new RepositorioDetallesCaja();
            repositorioCaja = new RepositorioCaja();
            cajaa = repositorioCaja.ObtenerCajaActual();
            otroGasto = new OtroGasto();
            cerrarCaja = cajaaaaaa;
            this.id = id;

        }
        public OtrosGastos()
        {
            InitializeComponent();
            repositorioDetalleGastos = new RepositorioDetalleGastos();
            repositorioDetallesCaja = new RepositorioDetallesCaja();
            repositorioCaja = new RepositorioCaja();
            cajaa = repositorioCaja.ObtenerCajaActual();
            otroGasto = new OtroGasto();
            

        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void OtrosGastos_Load(object sender, EventArgs e)
        {

            DataTable Detalles;

            Detalles = repositorioDetalleGastos.ObtenerDetalles();
            cmbDetalle.DataSource = Detalles;
            cmbDetalle.ValueMember = "id";
            cmbDetalle.DisplayMember = "nombre";

            cmbDetalle.SelectedIndex = -1;
            
            lblFecha.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm");// dd-MM-yyyy hh:mi");
        }

        public void cargarCombos()
        {
            DataTable Detalles;

            Detalles = repositorioDetalleGastos.ObtenerDetalles();
            cmbDetalle.DataSource = Detalles;
            cmbDetalle.ValueMember = "id";
            cmbDetalle.DisplayMember = "nombre";

            cmbDetalle.SelectedIndex = -1;
            
            lblFecha.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            var ventana = new DetalleGastos();
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

            if(txtImporte.Text == "")
            {
                MessageBox.Show("Debe ingresar el importe");
                return;
            }

            cajaa.otrosGastos += decimal.Parse(txtImporte.Text);
            cajaa.cajaActual -= decimal.Parse(txtImporte.Text);

            otroGasto.fecha = DateTime.Now;
            otroGasto.detalle = int.Parse(cmbDetalle.SelectedValue.ToString());
            otroGasto.importe = decimal.Parse(txtImporte.Text);
            if (txtObservaciones.Text == "")
            {
                otroGasto.observaciones = "--Sin observaciones--";
            }
            else
            {
                otroGasto.observaciones = txtObservaciones.Text;
            }
            otroGasto.caja = cajaa.id;
            otroGasto.usuario = id;

            if(cajaa.otrosGastosValido()==false)
            {
                MessageBox.Show("Gasto invalido");
                return;
            }
            if(cajaa.cajaActualValida()==false)
            {
                MessageBox.Show("Gasto invalido");
                return;
            }

            if(otroGasto.detalleValido()==false)
            {
                MessageBox.Show("Error detalle");
                return;
            }
            if(otroGasto.importeValido()==false)
            {
                MessageBox.Show("Importe invalido");
                return;
            }
            if(otroGasto.observacionesValido()==false)
            {
                MessageBox.Show("Error en observaciones");
                return;
            }
            if(otroGasto.usuarioValido()==false)
            {
                MessageBox.Show("Error usuario");
                return;
            }
            if(otroGasto.cajaValido()==false)
            {
                MessageBox.Show("Error id de Caja");
                return;
            }

           /* using (var tx = _BD.IniciarTransaccion())
            {         
           
                try
                {          
                    repositorioCaja.ActualizarCajaGastos(cajaa);
                    repositorioDetallesCaja.GuardarOtroGasto(otroGasto);
                }

                    tx.Commit();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    throw new ApplicationException("No se pudo guardar la orden de compra." + ex.Message);
                }
                
            }*/

            try
            {
                repositorioCaja.ActualizarCajaGastos(cajaa);
                repositorioDetallesCaja.GuardarOtroGasto(otroGasto);
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
