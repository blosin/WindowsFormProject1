using Gestionador.Formularios.Usuarios;
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

namespace Gestionador.Formularios.Empleados
{
    public partial class Usuarios : Form
    {
        RepositorioUsuarios repositorioUsuarios;
        public Usuarios()
        {
            InitializeComponent();
            repositorioUsuarios = new RepositorioUsuarios();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            
            var seleccion = dgvUsuarios.SelectedRows;
            if (seleccion.Count == 0 || seleccion.Count > 1)
            {
                MessageBox.Show("Debe seleccionar una fila");
                return;
            }
            foreach (DataGridViewRow fila in seleccion)
            {
                var id = fila.Cells[0].Value;

                var ventana = new ModificarUsuario(int.Parse(id.ToString()));
                ventana.ShowDialog();
                ActualizarUsuarios();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var ventana = new AgregarUsuario();
            ventana.ShowDialog();            
            ActualizarUsuarios();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            ActualizarUsuarios();
        }
        public void ActualizarUsuarios()
        {
            dgvUsuarios.Rows.Clear();
            var usuarios = repositorioUsuarios.ObtenerUsuarios().Rows;
            ActualizarGrilla(usuarios);
        }
        private void ActualizarGrilla(DataRowCollection registros)
        {
            foreach (DataRow registro in registros)
            {
                if (registro.HasErrors)
                    continue; // no corto el ciclo
                var fila = new string[] {
                    registro.ItemArray[0].ToString(),
                    registro.ItemArray[2].ToString(),
                    registro.ItemArray[3].ToString(),
                    registro.ItemArray[5].ToString(),
                    registro.ItemArray[1].ToString(),
                    

                };

                dgvUsuarios.Rows.Add(fila);
            }
        }

        private void btnPermisos_Click(object sender, EventArgs e)
        {
            
            var seleccion = dgvUsuarios.SelectedRows;
            if (seleccion.Count == 0 || seleccion.Count > 1)
            {
                MessageBox.Show("Debe seleccionar una fila");
                return;
            }
            foreach (DataGridViewRow fila in seleccion)
            {
                var id = fila.Cells[0].Value;

                var ventana = new Permisos(int.Parse(id.ToString()));
                ventana.ShowDialog();                
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var seleccion = dgvUsuarios.SelectedRows;
            if (seleccion.Count == 0 || seleccion.Count > 1)
            {
                MessageBox.Show("Debe seleccionar una fila");
                return;
            }
            foreach (DataGridViewRow fila in seleccion)
            {
                var id = fila.Cells["codigo"].Value;
                var nombre = fila.Cells["nombre"].Value;

                var confirmacion = MessageBox.Show($"¿Esta seguro que desea elimiar al usuario {nombre}? ",
                       "Confirme operacion",
                       MessageBoxButtons.YesNo);
                if (confirmacion.Equals(DialogResult.No))
                    return;

                if (repositorioUsuarios.Eliminar(id.ToString()))
                {
                    MessageBox.Show("Se elimino exitosamente");
                    ActualizarUsuarios();
                }
            }
        }
    }
}
