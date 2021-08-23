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
    public partial class CajaActual : Form
    {
        RepositorioCaja repositorioCaja;
        public CajaActual()
        {
            InitializeComponent();
            repositorioCaja = new RepositorioCaja();
        }

        private void CajaActual_Load(object sender, EventArgs e)
        {
            lblTitulo.Text += " " + DateTime.Now.ToString("dd-MM-yyyy HH:mm");
            var caja = repositorioCaja.ObtenerCajaActual();
            lblCaja.Text += " " + caja.cajaActual.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
