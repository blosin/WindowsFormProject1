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

namespace Gestionador.Formularios.notas
{
    public partial class NotaParticular : Form
    {
        RepositorioNotas repositorioNotas;
        Nota nota;
        public NotaParticular(string id)
        {
            InitializeComponent();
            repositorioNotas = new RepositorioNotas();
            nota = repositorioNotas.ObtenerNotaParticular(id);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void NotaParticular_Load(object sender, EventArgs e)
        {
            dtpFecha.Value = nota.fechaCreacion;
            lblUsuario.Text = nota.usuarioParticular;
            txtNota.Text = nota.mensaje;
        }
    }
}
