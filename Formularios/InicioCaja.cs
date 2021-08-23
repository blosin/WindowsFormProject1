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

namespace Gestionador.Formularios
{
    public partial class InicioCaja : Form
    {
        RepositorioCaja repositorioCaja;
        public InicioCaja()
        {
            repositorioCaja = new RepositorioCaja();
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            repositorioCaja.EstablecerCajaInicial(decimal.Parse(txtCajaInicial.Text));
            this.Dispose();
        }

        private void txtCajaInicial_KeyUp(object sender, KeyEventArgs e)
        {
            decimal defaul;
            if (decimal.TryParse(txtCajaInicial.Text, out defaul))
            {

            }
            else
            {
                txtCajaInicial.Text = "";
                txtCajaInicial.Focus();
                return;
            }
        }
    }
}
