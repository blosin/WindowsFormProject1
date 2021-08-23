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

namespace Gestionador.Formularios.Soporte
{
    public partial class AltaRubro : Form
    {
        RepositorioRubros repositorioRubros;
        public AltaRubro()
        {
            InitializeComponent();
            repositorioRubros = new RepositorioRubros();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            var rubro = new Rubro();
            rubro.nombre = txtNombre.Text;


            if (!rubro.NombreValido())
            {
                MessageBox.Show("Nombre inválido");
                return;
            }
            DataTable tablatemporal = repositorioRubros.SoyRubroExistente(rubro.nombre);
            if (tablatemporal.Rows.Count == 0)
            {
                if (repositorioRubros.Guardar(rubro))
                {
                    MessageBox.Show("Se registro con éxito");
                    this.Dispose();
                }
            }
            else
                MessageBox.Show($"ya existe un rubro con ese nombre");
        }
    }
}
