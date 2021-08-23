
using Gestionador.Formularios.Productos;
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
    public partial class Productoss : Form
    {
        
        RepositorioArticulos repositorioArticulos;
        public Productoss()
        {
            InitializeComponent();
            repositorioArticulos = new RepositorioArticulos();
            
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToString();
            ActualizarProductos();
        }
        public void ActualizarProductos()
        {
            dgvProductos.Rows.Clear();
            var productos = repositorioArticulos.ObtenerProductos().Rows;
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            AgregarProducto form = new AgregarProducto();
            form.ShowDialog();
            ActualizarProductos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            var seleccion = dgvProductos.SelectedRows;
            if (seleccion.Count == 0 || seleccion.Count > 1)
            {
                MessageBox.Show("Debe seleccionar una fila");
                return;
            }
            foreach (DataGridViewRow fila in seleccion)
            {
                var id = fila.Cells[0].Value;

                var ventana = new ModificarProducto(id.ToString());
                ventana.ShowDialog();
                ActualizarProductos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var seleccion = dgvProductos.SelectedRows;
            if (seleccion.Count == 0 || seleccion.Count > 1)
            {
                MessageBox.Show("Debe seleccionar una fila");
                return;
            }
            foreach (DataGridViewRow fila in seleccion)
            {
                var id = fila.Cells["codigo"].Value;
                var nombre = fila.Cells["descripcion"].Value;

                var confirmacion = MessageBox.Show($"¿Esta seguro que desea elimiar el producto {nombre}? ",
                       "Confirme operacion",
                       MessageBoxButtons.YesNo);
                if (confirmacion.Equals(DialogResult.No))
                    return;

                if (repositorioArticulos.Eliminar(id.ToString()))
                {
                    MessageBox.Show("Se elimino exitosamente");
                    ActualizarProductos();
                }
            }
        }

        private void btnModificarStock_Click(object sender, EventArgs e)
        {
            var seleccion = dgvProductos.SelectedRows;
            if (seleccion.Count == 0 || seleccion.Count > 1)
            {
                MessageBox.Show("Debe seleccionar una fila");
                return;
            }
            foreach (DataGridViewRow fila in seleccion)
            {
                var id = fila.Cells[0].Value;

                var ventana = new ActualizarStock(id.ToString());
                ventana.ShowDialog();
                ActualizarProductos();
            }
            
        }

        
        
    }
}
