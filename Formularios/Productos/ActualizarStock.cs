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

namespace Gestionador.Formularios.Productos
{
    public partial class ActualizarStock : Form
    {
        RepositorioArticulos repositorioArticulos;
        Producto producto;
        public ActualizarStock(string id)
        {
            InitializeComponent();
            repositorioArticulos = new RepositorioArticulos();
            producto = repositorioArticulos.ObtenerProducto(id);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtStockAgregado.Text == "" && txtStockRemplazo.Text == "")
            {
                MessageBox.Show("ingrese un stock valido");
                return;
            }
            else
            {
                if (txtStockAgregado.Text == "")
                {
                    int defaul;
                    if (int.TryParse(txtStockRemplazo.Text, out defaul))
                    {
                        producto.stock = defaul;
                    }
                    else
                    {
                        MessageBox.Show("ingrese un stock valido");
                        txtStockRemplazo.Text = null;
                        txtStockRemplazo.Focus();
                        return;
                    }
                }

                if (txtStockRemplazo.Text == "")
                {
                    int defaul;
                    if (int.TryParse(txtStockAgregado.Text, out defaul))
                    {
                        producto.stock += defaul;
                    }
                    else
                    {
                        MessageBox.Show("ingrese un stock valido");
                        txtStockAgregado.Text = null;
                        txtStockAgregado.Focus();
                        return;
                    }
                }
            }
            if (producto.StockValido() == false)
            {
                MessageBox.Show("ingrese un stock valido");
                return;
            }
            else
            {
                producto.fechaModificacion = DateTime.Now;
                repositorioArticulos.ActualizarStock(producto);
                this.Dispose();
            }
        }

        private void ActualizarStock_Load(object sender, EventArgs e)
        {
            lblProducto.Text = producto.descripcion;
            lblStock.Text = producto.stock.ToString();
            lblStockResultante.Text = producto.stock.ToString();
        }

        private void txtStockAgregado_TextChanged(object sender, EventArgs e)
        {
            txtStockRemplazo.Enabled = false;
        }

        private void txtStockRemplazo_TextChanged(object sender, EventArgs e)
        {
            txtStockAgregado.Enabled = false;
        }

        private void txtStockAgregado_KeyUp(object sender, KeyEventArgs e)
        {
            int defaul;
            if (int.TryParse(txtStockAgregado.Text, out defaul))
            {
                lblStockResultante.Text = (defaul + producto.stock).ToString();
            }
            else
            {
                txtStockAgregado.Text = "";
                lblStockResultante.Text = producto.stock.ToString();
                txtStockAgregado.Focus();
                return;
            }
        }

        private void txtStockRemplazo_KeyUp(object sender, KeyEventArgs e)
        {
            int defaul;
            if (int.TryParse(txtStockRemplazo.Text, out defaul))
            {
                lblStockResultante.Text = defaul.ToString();
            }
            else
            {
                txtStockRemplazo.Text = "";
                lblStockResultante.Text = producto.stock.ToString();
                txtStockRemplazo.Focus();
                return;
            }
        }
    }
}
