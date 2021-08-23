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

namespace Gestionador.Formularios.Productos
{
    public partial class ModificarProducto : Form
    {
        Producto producto;
        RepositorioArticulos repositorioArticulos;        
        RepositorioMarcas repositorioMarcas;
        RepositorioRubros repositorioRubros;
        string idViejo;

        public ModificarProducto(string id)
        {
            InitializeComponent();            
            repositorioArticulos = new RepositorioArticulos();
            producto = repositorioArticulos.ObtenerProducto(id);
            repositorioMarcas = new RepositorioMarcas();
            repositorioRubros = new RepositorioRubros();
            idViejo = producto.codigo;
        }

        private void ModificarProducto_Load(object sender, EventArgs e)
        {
            lblfecha.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm");//DateTime.Now.ToString("dd-MM-yyyy HH:mm")
            DataTable marcas;
            DataTable rubros;
            marcas = repositorioMarcas.ObtenerMarcas();
            rubros = repositorioRubros.ObtenerRubros();

            cmbMarca.DataSource = marcas;
            cmbRubro.DataSource = rubros;

            cmbRubro.ValueMember = "id";
            cmbMarca.ValueMember = "id";

            cmbMarca.DisplayMember = "nombre";
            cmbRubro.DisplayMember = "nombre";

            
            if (producto.marca == null && producto.rubro==null)
            {
                txtCodigo.Text = producto.codigo;
                txtDescripcion.Text = producto.descripcion;
                //cmbMarca.SelectedValue=producto
                cmbMarca.SelectedIndex = -1;
                cmbRubro.SelectedIndex = -1;
                txtPrecio.Text = producto.precio.ToString();
                txtCosto.Text = producto.costo.ToString();                
                txtStockMin.Text = producto.stockMinimo.ToString();                

            }
            else
            {
                if(producto.marca==null)
                {
                    txtCodigo.Text = producto.codigo;
                    txtDescripcion.Text = producto.descripcion;
                    //cmbMarca.SelectedValue=producto
                    cmbMarca.SelectedIndex = -1;
                    cmbRubro.SelectedValue = producto.rubro;
                    txtPrecio.Text = producto.precio.ToString();
                    txtCosto.Text = producto.costo.ToString();                    
                    txtStockMin.Text = producto.stockMinimo.ToString();
                }

                if(producto.rubro==null)
                {
                    txtCodigo.Text = producto.codigo;
                    txtDescripcion.Text = producto.descripcion;
                    //cmbMarca.SelectedValue=producto
                    cmbRubro.SelectedIndex = -1;
                    cmbMarca.SelectedValue = producto.marca;
                    txtPrecio.Text = producto.precio.ToString();
                    txtCosto.Text = producto.costo.ToString();                    
                    txtStockMin.Text = producto.stockMinimo.ToString();
                }

                if (producto.marca != null && producto.rubro != null)
                {
                    txtCodigo.Text = producto.codigo;
                    txtDescripcion.Text = producto.descripcion;
                    //cmbMarca.SelectedValue=producto
                    cmbRubro.SelectedValue = producto.rubro;
                    cmbMarca.SelectedValue = producto.marca;
                    txtPrecio.Text = producto.precio.ToString();
                    txtCosto.Text = producto.costo.ToString();                    
                    txtStockMin.Text = producto.stockMinimo.ToString();
                }
                
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
       
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //repositorioArticulos.Eliminar(idViejo);

            if (txtCodigo.Text == "")
            {
                MessageBox.Show("El codigo es obligatorio");
                txtCodigo.Focus();
                return;
            }

            if (txtDescripcion.Text == "")
            {
                MessageBox.Show("Ingrese descripción");
                txtDescripcion.Focus();
                return;
            }

            if (txtPrecio.Text == "")
            {
                MessageBox.Show("Ingrese precio");
                txtPrecio.Focus();
                return;
            }
            if (txtCosto.Text == "")
            {
                MessageBox.Show("Ingrese costo");
                txtCosto.Focus();
                return;
            }

            
            if (txtStockMin.Text == "")
            {
                MessageBox.Show("Ingrese stock minimo");
                txtStockMin.Focus();
                return;
            }

            producto.codigo = txtCodigo.Text;
            producto.descripcion = txtDescripcion.Text;
            producto.precio = decimal.Parse(txtPrecio.Text);
            producto.costo = decimal.Parse(txtCosto.Text);
            producto.stockMinimo = int.Parse(txtStockMin.Text);
            producto.fechaModificacion = DateTime.Now;

            if (producto.DescripcionValida() == false)
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
            
            if (producto.stockMinValido() == false)
            {
                MessageBox.Show("Ingrese stock minimo valido");
                txtStockMin.Text = null;
                txtStockMin.Focus();
                return;
            }
            if (producto.costo > producto.precio)
            {
                MessageBox.Show("El precio de venta tiene que ser mayor al costo");
                txtCosto.Text = "";
                txtPrecio.Text = "";
                txtPrecio.Focus();
                return;
            }
            if(producto.codigo==idViejo)
            {
                if (cmbMarca.SelectedValue == null && cmbRubro.SelectedValue == null)
                {
                    repositorioArticulos.Eliminar(idViejo);
                    repositorioArticulos.GuardarSinMarcaSinRubro(producto);
                    MessageBox.Show("Se actualizo con exito");
                    this.Dispose();
                }
                else
                {
                    if (cmbMarca.SelectedValue == null)
                    {
                        producto.rubro = int.Parse(cmbRubro.SelectedValue.ToString());
                        repositorioArticulos.Eliminar(idViejo);
                        repositorioArticulos.GuardarSinMarca(producto);
                        MessageBox.Show("Se actualizo con exito");
                        this.Dispose();
                    }

                    if (cmbRubro.SelectedValue == null)
                    {
                        producto.marca = int.Parse(cmbMarca.SelectedValue.ToString());
                        repositorioArticulos.Eliminar(idViejo);
                        repositorioArticulos.GuardarSinRubro(producto);
                        MessageBox.Show("Se actualizo con exito");
                        this.Dispose();
                    }

                    if (cmbMarca.SelectedValue != null && cmbRubro.SelectedValue != null)
                    {
                        producto.marca = int.Parse(cmbMarca.SelectedValue.ToString());
                        producto.rubro = int.Parse(cmbRubro.SelectedValue.ToString());
                        repositorioArticulos.Eliminar(idViejo);
                        repositorioArticulos.GuardarConTodo(producto);
                        MessageBox.Show("Se actualizo con exito");
                        this.Dispose();
                    }
                }
            }
            else
            { 
                DataTable tablatemporal = repositorioArticulos.ProductoExistente(producto.codigo);
                if (tablatemporal.Rows.Count == 0)
                {
                    if (cmbMarca.SelectedValue == null && cmbRubro.SelectedValue == null)
                    {
                        repositorioArticulos.Eliminar(idViejo);
                        repositorioArticulos.GuardarSinMarcaSinRubro(producto);
                        MessageBox.Show("Se actualizo con exito");
                        this.Dispose();
                    }
                    else
                    {
                        if (cmbMarca.SelectedValue == null)
                        {
                            producto.rubro = int.Parse(cmbRubro.SelectedValue.ToString());
                            repositorioArticulos.Eliminar(idViejo);
                            repositorioArticulos.GuardarSinMarca(producto);
                            MessageBox.Show("Se actualizo con exito");
                            this.Dispose();
                        }

                        if (cmbRubro.SelectedValue == null)
                        {
                            producto.marca = int.Parse(cmbMarca.SelectedValue.ToString());
                            repositorioArticulos.Eliminar(idViejo);
                            repositorioArticulos.GuardarSinRubro(producto);
                            MessageBox.Show("Se actualizo con exito");
                            this.Dispose();
                        }

                        if (cmbMarca.SelectedValue != null && cmbRubro.SelectedValue != null)
                        {
                            producto.marca = int.Parse(cmbMarca.SelectedValue.ToString());
                            producto.rubro = int.Parse(cmbRubro.SelectedValue.ToString());
                            repositorioArticulos.Eliminar(idViejo);
                            repositorioArticulos.GuardarConTodo(producto);
                            MessageBox.Show("Se actualizo con exito");
                            this.Dispose();
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"ya existe un producto con ese codigo");
                }
            }
            

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
            /*DataTable marcas;
            DataTable rubros;
            marcas = repositorioMarcas.ObtenerMarcas();
            rubros = repositorioRubros.ObtenerRubros();

            cmbMarca.DataSource = marcas;
            cmbRubro.DataSource = rubros;

            cmbRubro.ValueMember = "id";
            cmbMarca.ValueMember = "id";

            cmbMarca.DisplayMember = "nombre";
            cmbRubro.DisplayMember = "nombre";*/
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
