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
    public partial class Proveedores : Form
    {
        RepositorioProveedores repositorioProveedores;
        public Proveedores()
        {
            InitializeComponent();
            repositorioProveedores = new RepositorioProveedores();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var ventana = new AgregarProveedor();
            ventana.ShowDialog();
            ActualizarProveedores();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
           
            var seleccion = dgvProveedores.SelectedRows;
            if (seleccion.Count == 0 || seleccion.Count > 1)
            {
                MessageBox.Show("Debe seleccionar una fila");
                return;
            }
            foreach (DataGridViewRow fila in seleccion)
            {
                var id = fila.Cells[0].Value;

                var ventana = new ModificarProveedor(id.ToString());
                ventana.ShowDialog();
                ActualizarProveedores();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var seleccion = dgvProveedores.SelectedRows;
            if (seleccion.Count == 0 || seleccion.Count > 1)
            {
                MessageBox.Show("Debe seleccionar una fila");
                return;
            }
            foreach (DataGridViewRow fila in seleccion)
            {
                var id = fila.Cells["id"].Value;
                var nombre = fila.Cells["nombre"].Value;


                var confirmacion = MessageBox.Show($"¿Esta seguro que desea elimiar al proveedor {nombre}? ",
                       "Confirme operacion",
                       MessageBoxButtons.YesNo);
                if (confirmacion.Equals(DialogResult.No))
                    return;

                if (repositorioProveedores.Eliminar(id.ToString()))
                {
                    MessageBox.Show("Se elimino exitosamente");
                    ActualizarProveedores();
                }
            }
        }

        private void Proveedores_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm");// dd-MM-yyyy hh:mi");
            ActualizarProveedores();
        }
        public void ActualizarProveedores()
        {
            dgvProveedores.Rows.Clear();
            var proveedores = repositorioProveedores.ObtenerProveedores().Rows;
            ActualizarGrilla(proveedores);
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
                    registro.ItemArray[9].ToString(),
                    registro.ItemArray[10].ToString(),
                    registro.ItemArray[11].ToString(),
                    registro.ItemArray[12].ToString(),
                    registro.ItemArray[13].ToString(),
                    registro.ItemArray[14].ToString(),

                };

                dgvProveedores.Rows.Add(fila);
            }
        }
    }
}
