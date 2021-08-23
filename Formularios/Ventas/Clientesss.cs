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
    public partial class Clientesss : Form
    {
        RepositorioClientes repositorioClientes;
        NuevaVenta nuevaVenta;
        public Clientesss(NuevaVenta nuevaVenta)
        {
            InitializeComponent();
            repositorioClientes = new RepositorioClientes();
            this.nuevaVenta = nuevaVenta;
        }

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {           

                var seleccion = dgvClientes.SelectedRows;
                if (seleccion.Count == 0 || seleccion.Count > 1)
                {
                    MessageBox.Show("Debe seleccionar una fila");
                    return;
                }
                foreach (DataGridViewRow fila in seleccion)
                {
                    var doc = fila.Cells[4].Value;

                    nuevaVenta.ElegirCliente(doc.ToString());
                    this.Dispose();
                }
            }
            catch { }

        }

        private void Clientesss_Load(object sender, EventArgs e)
        {
            
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
                try
                {              
                if (registro.HasErrors)
                    continue; // no corto el ciclo
                var fila = new string[] {
                    registro.ItemArray[0].ToString(),
                    registro.ItemArray[1].ToString(),
                    registro.ItemArray[2].ToString(),
                    registro.ItemArray[3].ToString(),
                    registro.ItemArray[4].ToString(),
                    registro.ItemArray[10].ToString(),
                    registro.ItemArray[16].ToString(),
                    registro.ItemArray[12].ToString(),
                    registro.ItemArray[14].ToString(),
                    registro.ItemArray[17].ToString(),                    

                };

                dgvClientes.Rows.Add(fila);
                }
                catch
                {
                    MessageBox.Show("Sin resultados");
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            dgvClientes.Rows.Clear();
            var clientes = repositorioClientes.ObtenerClienteTableDoc(txtDoc.Text).Rows;
            ActualizarGrilla(clientes);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtNombre_KeyUp(object sender, KeyEventArgs e)
        {
            dgvClientes.Rows.Clear();
            var clientes = repositorioClientes.ObtenerClienteTableNombre(txtNombre.Text).Rows;
            ActualizarGrilla(clientes);
        }
    }
}
