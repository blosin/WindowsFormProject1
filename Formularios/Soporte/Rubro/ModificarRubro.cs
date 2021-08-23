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
    public partial class ModificarRubro : Form
    {
        RepositorioRubros repositorioRubros;
        Rubro rubro;

        public ModificarRubro(string id)
        {
            InitializeComponent();
            repositorioRubros = new RepositorioRubros();
            rubro = repositorioRubros.ObtenerRubro(id);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ModificarRubro_Load(object sender, EventArgs e)
        {
            lblName.Text = rubro.nombre;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            var datosRubro = new Rubro();
            datosRubro.id = rubro.id;
            datosRubro.nombre = txtNombre.Text;

            if (!rubro.NombreValido())
            {
                MessageBox.Show("Nombre inválido");
                return;
            }
            if (repositorioRubros.Actualizar(datosRubro))
            {
                MessageBox.Show("Se actualizó con éxito");
                this.Dispose();
            }
        }
    }
}
