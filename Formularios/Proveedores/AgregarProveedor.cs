using Gestionador.Clases;
using Gestionador.Formularios.Soporte;
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

namespace Gestionador.Formularios.Proveedores
{
    public partial class AgregarProveedor : Form
    {
        RepositorioRubros repositorioRubros;
        RepositorioIVA repositorioIVA;
        RepositorioProvincia repositorioProvincia;
        Proveedor proveedor;
        RepositorioProveedores repositorioProveedores;
        public AgregarProveedor()
        {
            InitializeComponent();
            repositorioRubros = new RepositorioRubros();
            repositorioIVA = new RepositorioIVA();
            repositorioProvincia = new RepositorioProvincia();
            proveedor = new Proveedor();
            repositorioProveedores = new RepositorioProveedores();


        }

        private void AgregarProveedor_Load(object sender, EventArgs e)
        {
            lblfecha.Text= DateTime.Now.ToString("dd-MM-yyyy HH:mm");// dd-MM-yyyy hh:mi");
            DataTable IVAS;
            DataTable Provincias;
            DataTable Rubros;


            IVAS = repositorioIVA.ObtenerIVAS();
            cmbIVA.DataSource = IVAS;
            cmbIVA.ValueMember = "id";
            cmbIVA.DisplayMember = "nombre";

            Provincias = repositorioProvincia.ObtenerProvincias();
            cmbProvincia.DataSource = Provincias;
            cmbProvincia.ValueMember = "id";
            cmbProvincia.DisplayMember = "nombre";

            Rubros = repositorioRubros.ObtenerRubros();
            cmbRubro.DataSource = Rubros;
            cmbRubro.ValueMember = "id";
            cmbRubro.DisplayMember = "nombre";

            cmbRubro.SelectedIndex = -1;
            cmbIVA.SelectedIndex = -1;
            cmbProvincia.SelectedIndex = -1;
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void cargarCombos()
        {
            
            DataTable Rubros;
            
            Rubros = repositorioRubros.ObtenerRubros();
            cmbRubro.DataSource = Rubros;
            cmbRubro.ValueMember = "id";
            cmbRubro.DisplayMember = "nombre";
            
            cmbRubro.SelectedIndex = -1;
            lblfecha.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
        }

        private void btnAgregarRubro_Click(object sender, EventArgs e)
        {
            var ventana = new Rubros();
            ventana.ShowDialog();
            cargarCombos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("El nombre es obligatorio");
                txtNombre.Focus();
                return;
            }
            if (cmbRubro.SelectedValue == null)
            {
                MessageBox.Show("seleccione rubro");
                return;
            }
            if (cmbIVA.SelectedValue == null)
            {
                MessageBox.Show("seleccione una condicion de IVA");
                return;
            }
            if (cmbProvincia.SelectedValue == null)
            {
                MessageBox.Show("seleccione una provincia");
                return;
            }

            proveedor.nombre = txtNombre.Text;

            if(txtNombreContacto.Text=="")
            {
                proveedor.nombreContacto = "--Sin contacto--";
            }
            else
            {
                proveedor.nombreContacto = txtNombreContacto.Text;
            }
            proveedor.rubro= int.Parse(cmbRubro.SelectedValue.ToString());//cmbEstaciones.SelectedValue.ToString();
            proveedor.iva= int.Parse(cmbIVA.SelectedValue.ToString());//cmbEstaciones.SelectedValue.ToString();

            if (txtCuit.Text=="")
            {
                proveedor.cuit = "--Sin cuit--";
            }
            else
            {
                proveedor.cuit = txtCuit.Text;
            }

            if(txtTelefono.Text=="")
            {
                proveedor.telFijo = "--Sin telefono--";
            }
            else
            {
                proveedor.telFijo = txtTelefono.Text;
            }

            if(txtCelular.Text=="")
            {
                proveedor.telCel = "--Sin celular--";
            }
            else
            {
                proveedor.telCel = txtCelular.Text;
            }

            proveedor.provincia= int.Parse(cmbProvincia.SelectedValue.ToString());//cmbEstaciones.SelectedValue.ToString();

            if (txtLocalidad.Text=="")
            {
                proveedor.localidad = "--Sin localidad--";
            }
            else
            {
                proveedor.localidad = txtLocalidad.Text;
            }
            if(txtDireccion.Text=="")
            {
                proveedor.direccion = "--Sin direccion--";
            }
            else
            {
                proveedor.direccion = txtDireccion.Text;
            }
            if(txtCp.Text=="")
            {
                MessageBox.Show("El cuit es obligatorio");
                txtCuit.Focus();
                return;
            }
            else
            {
                proveedor.cp = txtCp.Text;
            }
            if(txtMail.Text=="")
            {
                proveedor.mail = "--Sin E-mail--";
            }
            else
            {
                proveedor.mail = txtMail.Text;
            }
            if(txtObservacion.Text=="")
            {
                proveedor.observaciones = "--Sin observaciones--";
            }
            else
            {
                proveedor.observaciones = txtObservacion.Text;
            }
            proveedor.fechaMod = DateTime.Now;



            if (proveedor.nombreValido() == false)
            {
                MessageBox.Show("Ingrese nombre valido");
                txtNombre.Text = null;
                txtNombre.Focus();
                return;
            }

            if (proveedor.nombreContactoValido() == false)
            {
                MessageBox.Show("Nombre de contacto invalido");
                txtNombreContacto.Text = null;
                txtNombreContacto.Focus();
                return;
            }

            if (proveedor.cuitValido() == false)
            {
                MessageBox.Show("Cuit invalido");
                txtCuit.Text = null;
                txtCuit.Focus();
                return;
            }

            if (proveedor.telefonoFijoValido() == false)
            {
                MessageBox.Show("Telefono invalido");
                txtTelefono.Text = null;
                txtTelefono.Focus();
                return;
            }

            if (proveedor.telefonoCelularValido() == false)
            {
                MessageBox.Show("Celular invalido");
                txtCelular.Text = null;
                txtCelular.Focus();
                return;
            }

            if (proveedor.localidadValida() == false)
            {
                MessageBox.Show("Localidad invalida");
                txtLocalidad.Text = null;
                txtLocalidad.Focus();
                return;
            }

            if (proveedor.direccionValida() == false)
            {
                MessageBox.Show("Direccion invalida");
                txtDireccion.Text = null;
                txtDireccion.Focus();
                return;
            }

            if (proveedor.codigoPostalValido() == false)
            {
                MessageBox.Show("CP invalido");
                txtCp.Text = null;
                txtCp.Focus();
                return;
            }

            if (proveedor.mailValido() == false)
            {
                MessageBox.Show("E-mail invalido");
                txtMail.Text = null;
                txtMail.Focus();
                return;
            }

            if (proveedor.observacionValida() == false)
            {
                MessageBox.Show("Observaciones invalidad, 700 caracteres");
                txtObservacion.Text = null;
                txtObservacion.Focus();
                return;
            }

            

            DataTable tablatemporal = repositorioProveedores.ProveedorExistente(proveedor.cuit);
            if (tablatemporal.Rows.Count == 0)
            {
                repositorioProveedores.Guardar(proveedor);
                MessageBox.Show("Se registro con exito");
                this.Dispose();
            }
            else
                MessageBox.Show($"ya existe un proveedor con ese cuit");

        }
    }
}
