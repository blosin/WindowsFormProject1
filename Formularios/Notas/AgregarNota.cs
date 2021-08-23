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
    public partial class AgregarNota : Form
    {
        Nota nota;
        RepositorioNotas repositorioNotas;
        int usuarioID;
        public AgregarNota(int usuarioID)
        {
            InitializeComponent();
            nota = new Nota();
            repositorioNotas = new RepositorioNotas();
            this.usuarioID = usuarioID;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void AgregarNota_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm");// dd-MM-yyyy hh:mi");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNota.Text == "")
            {
                MessageBox.Show("Ingrese algun mensaje");
                txtNota.Focus();
                return;
            }



            nota.usuario = usuarioID;
            nota.fechaCreacion = DateTime.Now; 
            nota.estado = 0;
            nota.mensaje= txtNota.Text;
            

            if (nota.mensajeValido() == false)
            {
                MessageBox.Show("nota invalida demasiados caracteres(1000)");
                txtNota.Text = null;
                txtNota.Focus();
                return;
            }

            repositorioNotas.Guardar(nota);
            MessageBox.Show("Se registro con exito");
            this.Dispose();        


        }
    }
}
