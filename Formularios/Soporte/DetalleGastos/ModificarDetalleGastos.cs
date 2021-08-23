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

namespace Gestionador.Formularios.Soporte.DetalleGastos
{
    public partial class ModificarDetalleGastos : Form
    {
        RepositorioDetalleGastos repositorioDetalleGastos;
        Detalle detalle;
        public ModificarDetalleGastos(string id)
        {
            repositorioDetalleGastos = new RepositorioDetalleGastos();
            detalle = repositorioDetalleGastos.ObtenerDetalle(id);
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ModificarDetalleGastos_Load(object sender, EventArgs e)
        {
            lblName.Text = detalle.nombre;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            var datosDetalle = new Detalle();
            datosDetalle.id = detalle.id;
            datosDetalle.nombre = txtNombre.Text;

            if (!datosDetalle.NombreValido())
            {
                MessageBox.Show("Nombre inválido");
                return;
            }
            if (repositorioDetalleGastos.Actualizar(datosDetalle))
            {
                MessageBox.Show("Se actualizó con éxito");
                this.Dispose();
            }
        }
    }
}
