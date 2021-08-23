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

namespace Gestionador.Formularios.Soporte
{
    public partial class Marcas : Form
    {
        RepositorioMarcas repositorioMarcas;
        public Marcas()
        {
            InitializeComponent();
            repositorioMarcas = new RepositorioMarcas();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            var ventana = new AltaMarca();
            ventana.ShowDialog();
            ActualizarMarcas();
        }

        private void ActualizarMarcas()
        {
            dgvMarcas.Rows.Clear();
            var marcas = repositorioMarcas.ObtenerMarcas().Rows;
            ActualizarGrilla(marcas);
        }

        private void ActualizarGrilla(DataRowCollection registros)
        {
            foreach (DataRow registro in registros)
            {
                if (registro.HasErrors)
                    continue; // no corto el ciclo
                var fila = new string[] {
                    registro.ItemArray[0].ToString(), // Codigo
                    registro.ItemArray[1].ToString(), // Nombre
                    
                };

                dgvMarcas.Rows.Add(fila);
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            var seleccionadas = dgvMarcas.SelectedRows;
            if (seleccionadas.Count == 0 || seleccionadas.Count > 1)
            {
                MessageBox.Show("Debe seleccionar una fila");
                return;
            }
            foreach (DataGridViewRow fila in seleccionadas)
            {
                var nombre = fila.Cells[1].Value;
                var id = fila.Cells[0].Value;
                var confirmacion = MessageBox.Show($"Esta seguro que desea elimiar a {nombre}? ",
                    "Confirme operacion",
                    MessageBoxButtons.YesNo);
                if (confirmacion.Equals(DialogResult.No))
                    return;

                if (repositorioMarcas.Eliminar(id.ToString()))
                {
                    MessageBox.Show("Se elimino exitosamente");
                    ActualizarMarcas();
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            var seieccionadas = dgvMarcas.SelectedRows;
            if (seieccionadas.Count == 0 || seieccionadas.Count > 1)
            {
                MessageBox.Show("Debe seleccionar una fila");
                return;
            }
            foreach (DataGridViewRow fila in seieccionadas)
            {
                var id = fila.Cells[0].Value;

                var ventana = new ModificarMarca(id.ToString());
                ventana.ShowDialog();
                ActualizarMarcas();
            }
        }

        private void Marcas_Load(object sender, EventArgs e)
        {
            ActualizarMarcas();
        }
    }
}
