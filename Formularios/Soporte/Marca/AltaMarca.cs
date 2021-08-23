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
    public partial class AltaMarca : Form
    {
        RepositorioMarcas repositorioMarcas;
        public AltaMarca()
        {
            InitializeComponent();
            repositorioMarcas = new RepositorioMarcas();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            var marca = new Marca();
            marca.nombre = txtNombre.Text;


            if (!marca.NombreValido())
            {
                MessageBox.Show("Nombre inválido");
                return;
            }
            DataTable tablatemporal = repositorioMarcas.SoyMarcaExistente(marca.nombre);
            if (tablatemporal.Rows.Count == 0)
            {
                if (repositorioMarcas.Guardar(marca))
                {
                    MessageBox.Show("Se registro con éxito");
                    this.Dispose();
                }
            }
            else
                MessageBox.Show($"ya existe un rubro con ese nombre");
        }

        private void AltaMarca_Load(object sender, EventArgs e)
        {

        }
    }
}
