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

namespace Gestionador.Formularios.Clientes
{
    public partial class ModificarCliente : Form
    {
        RepositorioIVA repositorioIVA;
        RepositorioProvincia repositorioProvincia;
        RepositorioTipoDNI repositorioTipoDNI;
        Cliente cliente;
        RepositorioClientes repositorioClientes;
        public ModificarCliente(string id)
        {
            InitializeComponent();
            repositorioIVA = new RepositorioIVA();
            repositorioProvincia = new RepositorioProvincia();
            repositorioTipoDNI = new RepositorioTipoDNI();            
            repositorioClientes = new RepositorioClientes();
            cliente = repositorioClientes.ObtenerCliente(id);

        }

        private void ModificarCliente_Load(object sender, EventArgs e)
        {
            this.AutoScroll = true;
            lblfecha.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
            DataTable IVAS;
            DataTable Provincias;
            DataTable TiposDNI;

            IVAS = repositorioIVA.ObtenerIVAS();
            cmbIVA.DataSource = IVAS;
            cmbIVA.ValueMember = "id";
            cmbIVA.DisplayMember = "nombre";

            Provincias = repositorioProvincia.ObtenerProvincias();
            cmbProvincia.DataSource = Provincias;
            cmbProvincia.ValueMember = "id";
            cmbProvincia.DisplayMember = "nombre";

            TiposDNI = repositorioTipoDNI.ObtenerTipoDNI();
            cmbTipoDoc.DataSource = TiposDNI;
            cmbTipoDoc.ValueMember = "id";
            cmbTipoDoc.DisplayMember = "nombre";

            txtNombre.Text = cliente.nombre;
            dtpFechaNacimiento.Value = cliente.fechaNac;
            cmbTipoDoc.SelectedValue = cliente.tipoDoc;
            txtDocumento.Text = cliente.nroDoc;
            txtCuit.Text = cliente.cuit;
            cmbIVA.SelectedValue = cliente.condIVA;
            txtTelefono.Text = cliente.telFijo;
            txtCelular.Text = cliente.telCel;
            cmbProvincia.SelectedValue = cliente.provincia;
            txtLocalidad.Text = cliente.localidad;
            txtDireccion.Text = cliente.direccion;
            txtCp.Text = cliente.codPostal;
            txtMail.Text = cliente.mail;
            txtCuentaCorriente.Text = cliente.montoCuenta.ToString();
            txtObservacion.Text = cliente.observaciones;



        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cbCuentaCorriente_CheckedChanged(object sender, EventArgs e)
        {
            if(cbCuentaCorriente.Checked == true)
                txtCuentaCorriente.Enabled = true;
            else
                txtCuentaCorriente.Text = "";
            txtCuentaCorriente.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("El nombre es obligatorio");
                txtNombre.Focus();
                return;
            }

            if (cmbTipoDoc.SelectedValue == null)
            {
                MessageBox.Show("seleccione un tipo de Documento valido");
                return;
            }
            if (cmbProvincia.SelectedValue == null)
            {
                MessageBox.Show("seleccione una provincia");
                return;
            }
            if (cmbIVA.SelectedValue == null)
            {
                MessageBox.Show("seleccione una condicion de IVA");
                return;
            }


            cliente.nombre = txtNombre.Text;
            cliente.fechaNac = dtpFechaNacimiento.Value.Date;
            cliente.tipoDoc = int.Parse(cmbTipoDoc.SelectedValue.ToString());//cmbEstaciones.SelectedValue.ToString();
            if (txtDocumento.Text == "")
            {
                cliente.nroDoc = "--Sin numero--";
            }
            else
            {
                cliente.nroDoc = txtDocumento.Text;
            }

            if (txtCuit.Text == "")
            {
                cliente.cuit = "--Sin cuit--";
            }
            else
            {
                cliente.cuit = txtCuit.Text;
            }
            cliente.condIVA = int.Parse(cmbIVA.SelectedValue.ToString());

            if (txtTelefono.Text == "")
            {
                cliente.telFijo = "--Sin telefono--";
            }
            else
            {
                cliente.telFijo = txtTelefono.Text;
            }

            if (txtCelular.Text == "")
            {
                cliente.telCel = "--Sin celular--";
            }
            else
            {
                cliente.telCel = txtCelular.Text;
            }

            cliente.provincia = int.Parse(cmbProvincia.SelectedValue.ToString());

            if (txtLocalidad.Text == "")
            {
                cliente.localidad = "--Sin localidad--";
            }
            else
            {
                cliente.localidad = txtLocalidad.Text;
            }

            if (txtDireccion.Text == "")
            {
                cliente.direccion = "Sin direccion";
            }
            else
            {
                cliente.direccion = txtDireccion.Text;
            }

            if (txtCp.Text == "")
            {
                cliente.codPostal = "--Sin CP--";
            }
            else
            {
                cliente.codPostal = txtCp.Text;
            }

            if (txtMail.Text == "")
            {
                cliente.mail = "--Sin E-mail--";
            }
            else
            {
                cliente.mail = txtMail.Text;
            }

            if (cbCuentaCorriente.Checked)
            {
                if (txtCuentaCorriente.Text == "")
                {
                    MessageBox.Show("Ingrese monto de cuenta");
                    txtCuentaCorriente.Focus();
                    return;
                }
                else
                {
                    cliente.montoCuenta = decimal.Parse(txtCuentaCorriente.Text);
                    cliente.montoUsado = 0;
                }
            }
            else
            {
                cliente.montoCuenta = 0;
                cliente.montoUsado = 0;
            }

            if (txtObservacion.Text == "")
            {
                cliente.observaciones = "--Sin observaciones--";
            }
            else
            {
                cliente.observaciones = txtObservacion.Text;
            }

            cliente.fechaMod = DateTime.Now;



            if (cliente.nombreValido() == false)
            {
                MessageBox.Show("Ingrese nombre valido");
                txtNombre.Text = null;
                txtNombre.Focus();
                return;
            }
            if (cliente.nroDocValido() == false)
            {
                MessageBox.Show("Ingrese numero valido");
                txtDocumento.Text = null;
                txtDocumento.Focus();
                return;
            }
            if (cliente.direccionValida() == false)
            {
                MessageBox.Show("Ingrese direccion valida");
                txtDireccion.Text = null;
                txtDireccion.Focus();
                return;
            }
            if (cliente.localidadValida() == false)
            {
                MessageBox.Show("Ingrese localidad valida");
                txtLocalidad.Text = null;
                txtLocalidad.Focus();
                return;
            }
            if (cliente.telefenoFijoValido() == false)
            {
                MessageBox.Show("Ingrese numero valido");
                txtTelefono.Text = null;
                txtTelefono.Focus();
                return;
            }
            if (cliente.telefonoCelularValido() == false)
            {
                MessageBox.Show("Ingrese celular valido");
                txtCelular.Text = null;
                txtCelular.Focus();
                return;
            }
            if (cliente.cuitValido() == false)
            {
                MessageBox.Show("Ingrese cuit valido");
                txtDocumento.Text = null;
                txtDocumento.Focus();
                return;
            }
            if (cliente.montoCuentaValido() == false)
            {
                MessageBox.Show("Ingrese monto valido");
                txtCuentaCorriente.Text = null;
                txtCuentaCorriente.Focus();
                return;
            }
            if (cliente.mailValido() == false)
            {
                MessageBox.Show("Ingrese mail valido");
                txtCuentaCorriente.Text = null;
                txtCuentaCorriente.Focus();
                return;
            }
            if (cliente.obvervacionValida() == false)
            {
                MessageBox.Show("Ingrese observacion valida, 700 caracteres");
                txtCuentaCorriente.Text = null;
                txtCuentaCorriente.Focus();
                return;
            }
            if (cliente.codigoPostalValido() == false)
            {
                MessageBox.Show("Ingrese cp valido");
                txtCp.Text = null;
                txtCp.Focus();
                return;
            }

            if (cliente.montoUsadoValido() == false)
            {
                MessageBox.Show("Error inesperado, monto usado erroneo");
                return;
            }

            DataTable tablatemporal = repositorioClientes.ClienteExistente(cliente.nroDoc);
            if (tablatemporal.Rows.Count == 0)
            {
                if (repositorioClientes.Actualizar(cliente))
                {
                    MessageBox.Show("Se actualizo con exito");
                    this.Dispose();
                }
                else
                    MessageBox.Show("Problemas durante la actualizacion");
            }
            else
                MessageBox.Show($"ya existe un cliente con ese documento");
        }
    }
}
