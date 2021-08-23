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
    public partial class ModificarMarca : Form
    {
        RepositorioMarcas repositorioMarcas;
        Marca marca;

        public ModificarMarca(string id)
        {
            InitializeComponent();
            repositorioMarcas = new RepositorioMarcas();
            marca = repositorioMarcas.ObtenerMarca(id);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ModificarMarca_Load(object sender, EventArgs e)
        {
            lblName.Text = marca.nombre;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            var datosMarca = new Marca();
            datosMarca.id = marca.id;
            datosMarca.nombre = txtNombre.Text;

            if (!datosMarca.NombreValido())
            {
                MessageBox.Show("Nombre inválido");
                return;
            }
            if (repositorioMarcas.Actualizar(datosMarca))
            {
                MessageBox.Show("Se actualizó con éxito");
                this.Dispose();
            }
        }
    }
}

