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
    public partial class Clientess : Form
    {
        RepositorioClientes repositorioClientes;
        public Clientess()
        {
            InitializeComponent();
            repositorioClientes = new RepositorioClientes();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var ventana = new AgregarCliente();
                ventana.ShowDialog();
            ActualizarClientes();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {            
            var seleccion = dgvClientes.SelectedRows;
            if (seleccion.Count == 0 || seleccion.Count > 1)
            {
                MessageBox.Show("Debe seleccionar una fila");
                return;
            }
            foreach (DataGridViewRow fila in seleccion)
            {
                var id = fila.Cells[0].Value;

                var ventana = new ModificarCliente(id.ToString());
                ventana.ShowDialog();
                ActualizarClientes();
            }

        }

        private void Clientess_Load(object sender, EventArgs e)
        {
            this.AutoScroll = true;
            lblFecha.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
            ActualizarClientes();
        }
        public void ActualizarClientes()
        {
            dgvClientes.Rows.Clear();
            var clientes = repositorioClientes.ObtenerClientes().Rows;
            ActualizarGrilla(clientes);
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
                    registro.ItemArray[8].ToString(),
                    registro.ItemArray[9].ToString(),
                    registro.ItemArray[7].ToString(),
                    registro.ItemArray[6].ToString(),
                    registro.ItemArray[5].ToString(),
                    registro.ItemArray[15].ToString(),
                    registro.ItemArray[10].ToString(),
                    registro.ItemArray[11].ToString(),
                    registro.ItemArray[16].ToString(),
                    registro.ItemArray[12].ToString(),
                    registro.ItemArray[13].ToString(),
                    registro.ItemArray[14].ToString(),
                    registro.ItemArray[17].ToString(),

                };

                dgvClientes.Rows.Add(fila);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var seleccion = dgvClientes.SelectedRows;
            if (seleccion.Count == 0 || seleccion.Count > 1)
            {
                MessageBox.Show("Debe seleccionar una fila");
                return;
            }
            foreach (DataGridViewRow fila in seleccion)
            {
                var id = fila.Cells["id"].Value;
                var nombre = fila.Cells["nombre"].Value;


                var confirmacion = MessageBox.Show($"¿Esta seguro que desea elimiar al cliente {nombre}? ",
                       "Confirme operacion",
                       MessageBoxButtons.YesNo);
                if (confirmacion.Equals(DialogResult.No))
                    return;

                if (repositorioClientes.Eliminar(id.ToString()))
                {
                    MessageBox.Show("Se elimino exitosamente");
                    ActualizarClientes();
                }
            }
        }
    }
}
