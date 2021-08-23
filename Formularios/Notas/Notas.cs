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

namespace Gestionador.Formularios.notas
{
    public partial class Notas : Form
    {
        RepositorioNotas repositorioNotas;
        int usuarioID;
        public Notas(int usuarioID)
        {
            InitializeComponent();
            repositorioNotas = new RepositorioNotas();
            this.usuarioID = usuarioID;
            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var ventana = new AgregarNota(usuarioID);
            ventana.ShowDialog();
            ActualizarNotas();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            var ventana = new ModificarNota();
            ventana.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            var seleccion = dgvNotas.SelectedRows;
            if (seleccion.Count == 0 || seleccion.Count > 1)
            {
                MessageBox.Show("Debe seleccionar una fila");
                return;
            }
            foreach (DataGridViewRow fila in seleccion)
            {
                var id = fila.Cells[0].Value;

                var ventanaNota = new NotaParticular(id.ToString());
                ventanaNota.ShowDialog();
                ActualizarNotas();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Notas_Load(object sender, EventArgs e)
        {
            ActualizarNotas();
        }
        public void ActualizarNotas()
        {
            dgvNotas.Rows.Clear();
            var notas = repositorioNotas.ObtenerNotas().Rows;
            ActualizarGrilla(notas);
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
                    

                };

                dgvNotas.Rows.Add(fila);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var seleccion = dgvNotas.SelectedRows;
            if (seleccion.Count == 0 || seleccion.Count > 1)
            {
                MessageBox.Show("Debe seleccionar una fila");
                return;
            }
            foreach (DataGridViewRow fila in seleccion)
            {
                var id = fila.Cells["id"].Value;
                

                var confirmacion = MessageBox.Show($"¿Esta seguro que desea elimiar la nota numero: {id}? ",
                       "Confirme operacion",
                       MessageBoxButtons.YesNo);
                if (confirmacion.Equals(DialogResult.No))
                    return;

                if (repositorioNotas.Eliminar(id.ToString()))
                {
                    MessageBox.Show("Se elimino exitosamente");
                    ActualizarNotas();
                }
            }
        }
    }
}
