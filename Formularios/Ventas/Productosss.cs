using Gestionador.Formularios.Compras;
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
    public partial class Productosss : Form
    {
        RepositorioArticulos repositorioArticulos;
        NuevaVenta nuevaVenta;
        AltaCompra altaCompra;
        public Productosss()
        {
            InitializeComponent();
            repositorioArticulos = new RepositorioArticulos();
        }

        public Productosss(NuevaVenta nuevaVenta)
        {
            InitializeComponent();
            repositorioArticulos = new RepositorioArticulos();
            this.nuevaVenta = nuevaVenta;
        }
        public Productosss(AltaCompra altaCompra)
        {
            InitializeComponent();
            repositorioArticulos = new RepositorioArticulos();
            this.altaCompra = altaCompra;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

                var seleccion = dgvProductos.SelectedRows;
                if (seleccion.Count == 0 || seleccion.Count > 1)
                {
                    MessageBox.Show("Debe seleccionar una fila");
                    return;
                }
                foreach (DataGridViewRow fila in seleccion)
                {
                    var codigo = fila.Cells[0].Value;

                    nuevaVenta.AgregarRowConCodigo(codigo.ToString());
                    this.Dispose();
                }
            
        }

        private void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            txtDescripcion.Text = "";
            txtCodigo.Focus();
            dgvProductos.Rows.Clear();
            var productos = repositorioArticulos.ObtenerProductoConCodigo(txtCodigo.Text).Rows;
            ActualizarGrilla(productos);
        }

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            txtCodigo.Text = "";
            txtCodigo.Focus();
            dgvProductos.Rows.Clear();
            var productos = repositorioArticulos.ObtenerProductosPorDescripcion(txtDescripcion.Text).Rows;
            ActualizarGrilla(productos);
        }
        private void ActualizarGrilla(DataRowCollection registros)
        {
            foreach (DataRow registro in registros)
            {
                if (registro.HasErrors)
                    continue; // no corto el ciclo
                var fila = new string[] {
                    registro.ItemArray[0].ToString(),
                    registro.ItemArray[1].ToString(),
                    registro.ItemArray[2].ToString(),
                    registro.ItemArray[3].ToString(),
                    registro.ItemArray[4].ToString(),
                    registro.ItemArray[5].ToString(),
                    registro.ItemArray[6].ToString(),
                    registro.ItemArray[7].ToString(),
                    registro.ItemArray[8].ToString(),

                };

                dgvProductos.Rows.Add(fila);
            }
        }

        private void Productosss_Load(object sender, EventArgs e)
        {
            ActualizarProductos();
        }
        public void ActualizarProductos()
        {
            dgvProductos.Rows.Clear();
            var productos = repositorioArticulos.ObtenerProductos().Rows;
            ActualizarGrilla(productos);
        }
    }
}
