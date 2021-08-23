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

namespace Gestionador.Formularios.Soporte.DetalleIngresos
{
    public partial class AltaDetalleIngresos : Form
    {
        RepositorioDetalleIngresos repositorioDetalleIngresos;
        public AltaDetalleIngresos()
        {
            repositorioDetalleIngresos = new RepositorioDetalleIngresos();
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            var detalle = new Detalle();
            detalle.nombre = txtNombre.Text;


            if (!detalle.NombreValido())
            {
                MessageBox.Show("Nombre inválido");
                return;
            }
            DataTable tablatemporal = repositorioDetalleIngresos.SoyDetalleExistente(detalle.nombre);
            if (tablatemporal.Rows.Count == 0)
            {
                if (repositorioDetalleIngresos.Guardar(detalle))
                {
                    MessageBox.Show("Se registro con éxito");
                    this.Dispose();
                }
            }
            else
                MessageBox.Show($"ya existe un detalle con ese nombre");
        }
    }
}
