using Gestionador.Formularios.Soporte.DetalleIngresos;
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

namespace Gestionador.Formularios.Caja
{
    public partial class DetalleIngresos : Form
    {
        RepositorioDetalleIngresos repositorioDetalleIngresos;
        public DetalleIngresos()
        {
            repositorioDetalleIngresos = new RepositorioDetalleIngresos();
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            var ventana = new AltaDetalleIngresos();
            ventana.ShowDialog();
            ActualizarDetalles();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            var seieccionadas = dgvDetalles.SelectedRows;
            if (seieccionadas.Count == 0 || seieccionadas.Count > 1)
            {
                MessageBox.Show("Debe seleccionar una fila");
                return;
            }
            foreach (DataGridViewRow fila in seieccionadas)
            {
                var id = fila.Cells[0].Value;

                var ventana = new ModificarDetalleIngresos(id.ToString());
                ventana.ShowDialog();
                ActualizarDetalles();
            }
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

                dgvDetalles.Rows.Add(fila);
            }
        }

        private void ActualizarDetalles()
        {
            dgvDetalles.Rows.Clear();
            var detalles = repositorioDetalleIngresos.ObtenerDetalles().Rows;
            ActualizarGrilla(detalles);
        }

        private void DetalleIngresos_Load(object sender, EventArgs e)
        {
            ActualizarDetalles();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            var seleccionadas = dgvDetalles.SelectedRows;
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

                if (repositorioDetalleIngresos.Eliminar(id.ToString()))
                {
                    MessageBox.Show("Se elimino exitosamente");
                    ActualizarDetalles();
                }
            }
        }
    }
}
