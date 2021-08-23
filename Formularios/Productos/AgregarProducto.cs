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

namespace Gestionador.Formularios
{
    public partial class AgregarProducto : Form
    {
        RepositorioArticulos repositorioArticulos;
        Producto producto;
        RepositorioMarcas repositorioMarcas;
        RepositorioRubros repositorioRubros;
        public AgregarProducto()
        {
            InitializeComponent();
            producto = new Producto();
            repositorioArticulos = new RepositorioArticulos();
            repositorioRubros = new RepositorioRubros();
            repositorioMarcas = new RepositorioMarcas();

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {


            if(txtCodigo.Text=="")
            {
                MessageBox.Show("El codigo es obligatorio");
                txtCodigo.Focus();
                return;
            }
            
            if(txtDescripcion.Text=="")
            {
                MessageBox.Show("Ingrese descripción");
                txtDescripcion.Focus();
                return;
            }
            
            if(txtPrecio.Text=="")
            {
                MessageBox.Show("Ingrese precio");
                txtPrecio.Focus();
                return;
            }            
            if(txtCosto.Text=="")
            {
                MessageBox.Show("Ingrese costo");
                txtCosto.Focus();
                return;
            }

            if(txtStock.Text=="")
            {
                MessageBox.Show("Ingrese stock");
                txtStock.Focus();
                return;
            }
            if(txtStockMin.Text=="")
            {
                MessageBox.Show("Ingrese stock minimo");
                txtStockMin.Focus();
                return;
            }

            producto.codigo = txtCodigo.Text;
            producto.descripcion = txtDescripcion.Text;
            producto.precio = decimal.Parse(txtPrecio.Text);
            producto.costo = decimal.Parse(txtCosto.Text);
            producto.stock = int.Parse(txtStock.Text);
            producto.stockMinimo = int.Parse(txtStockMin.Text);
            producto.fechaModificacion = DateTime.Now;

            if(producto.DescripcionValida()==false)
            {
                MessageBox.Show("Ingrese descripcion valida");
                txtDescripcion.Text = null;
                txtDescripcion.Focus();
                return;
            }
            if (producto.precioValido() == false)
            {
                MessageBox.Show("Ingrese precio valido");
                txtPrecio.Text = null;
                txtPrecio.Focus();
                return;
            }
            if (producto.costoValido() == false)
            {
                MessageBox.Show("Ingrese costo valido");
                txtCosto.Text = null;
                txtCosto.Focus();
                return;
            }            
            if (producto.StockValido() == false)
            {
                MessageBox.Show("Ingrese stock valido");
                txtStock.Text = null;
                txtStock.Focus();
                return;
            }
            if (producto.stockMinValido() == false)
            {
                MessageBox.Show("Ingrese stock minimo valido");
                txtStockMin.Text = null;
                txtStockMin.Focus();
                return;
            }
            if(producto.costo>producto.precio)
            {
                MessageBox.Show("El precio de venta tiene que ser mayor al costo");
                txtCosto.Text = "";
                txtPrecio.Text = "";
                txtPrecio.Focus();
                return;
            }
            DataTable tablatemporal = repositorioArticulos.ProductoExistente(producto.codigo);
            if (tablatemporal.Rows.Count == 0)
            {
               

                if (cmbMarca.SelectedValue == null && cmbRubro.SelectedValue == null)
                {
                
                        repositorioArticulos.GuardarSinMarcaSinRubro(producto);
                        MessageBox.Show("Se registro con exito");
                        this.Dispose();
               
                
                }
                else
                {
                    if (cmbMarca.SelectedValue == null)
                    {
                        producto.rubro = int.Parse(cmbRubro.SelectedValue.ToString());
                        repositorioArticulos.GuardarSinMarca(producto);
                        MessageBox.Show("Se registro con exito");
                        this.Dispose();
                    }

                    if (cmbRubro.SelectedValue == null)
                    {
                        producto.marca = int.Parse(cmbMarca.SelectedValue.ToString());
                        repositorioArticulos.GuardarSinRubro(producto);
                        MessageBox.Show("Se registro con exito");
                        this.Dispose();
                    }

                    if(cmbMarca.SelectedValue!=null && cmbRubro.SelectedValue!=null)
                    {
                        producto.marca = int.Parse(cmbMarca.SelectedValue.ToString());
                        producto.rubro = int.Parse(cmbRubro.SelectedValue.ToString());
                        repositorioArticulos.GuardarConTodo(producto);
                        MessageBox.Show("Se registro con exito");
                        this.Dispose();
                    }
                }
            }
            else
                MessageBox.Show($"ya existe un producto con ese codigo");





        }
        private void AgregarProducto_Load(object sender, EventArgs e)
        {
            
            DataTable Marcas;
            DataTable Rubros;
            Marcas = repositorioMarcas.ObtenerMarcas();
            cmbMarca.DataSource = Marcas;
            cmbMarca.ValueMember = "id";
            cmbMarca.DisplayMember = "nombre";
            Rubros = repositorioRubros.ObtenerRubros();
            cmbRubro.DataSource = Rubros;
            cmbRubro.ValueMember = "id";
            cmbRubro.DisplayMember = "nombre";
            cmbMarca.SelectedIndex = -1;
            cmbRubro.SelectedIndex = -1;
            lblfecha.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm");// dd-MM-yyyy hh:mi");

        }
        public void cargarCombos()
        {
            DataTable Marcas;
            DataTable Rubros;
            Marcas = repositorioMarcas.ObtenerMarcas();
            cmbMarca.DataSource = Marcas;
            cmbMarca.ValueMember = "id";
            cmbMarca.DisplayMember = "nombre";
            Rubros = repositorioRubros.ObtenerRubros();
            cmbRubro.DataSource = Rubros;
            cmbRubro.ValueMember = "id";
            cmbRubro.DisplayMember = "nombre";
            cmbMarca.SelectedIndex = -1;
            cmbRubro.SelectedIndex = -1;
            lblfecha.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
        }

        private void txtPrecio_KeyUp(object sender, KeyEventArgs e)
        {
            decimal defaul;
            if (decimal.TryParse(txtPrecio.Text, out defaul))
            {
                
            }
            else
            {
                txtPrecio.Text = "";
                txtPrecio.Focus();
                return;
            }
        }

        private void txtCosto_KeyUp(object sender, KeyEventArgs e)
        {
            decimal defaul;
            if (decimal.TryParse(txtCosto.Text, out defaul))
            {

            }
            else
            {
                txtCosto.Text = "";
                txtCosto.Focus();
                return;
            }
        }

        private void txtStock_KeyUp(object sender, KeyEventArgs e)
        {
            int defaul;
            if (int.TryParse(txtStock.Text, out defaul))
            {

            }
            else
            {
                txtStock.Text = "";
                txtStock.Focus();
                return;
            }
        }

        private void txtStockMin_KeyUp(object sender, KeyEventArgs e)
        {
            int defaul;
            if (int.TryParse(txtStockMin.Text, out defaul))
            {

            }
            else
            {
                txtStockMin.Text = "";
                txtStockMin.Focus();
                return;
            }
        }

        private void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            var ventana = new Marcas();
            ventana.ShowDialog();
            cargarCombos();
            

        }

        private void btnAgregarRubro_Click(object sender, EventArgs e)
        {
            var ventana = new Rubros();
            ventana.ShowDialog();
            cargarCombos();
        }
    }

   
}

