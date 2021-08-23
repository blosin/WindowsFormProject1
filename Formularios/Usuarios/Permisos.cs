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

namespace Gestionador.Formularios.Usuarios
{
    public partial class Permisos : Form
    {
        RepositorioUsuarios repositorioUsuarios;
        Usuario usuario;

        public Permisos(int id)
        {
            InitializeComponent();
            repositorioUsuarios = new RepositorioUsuarios();
            usuario = repositorioUsuarios.ObtenerUsuario(id);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Permisos_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = usuario.nombre + " " + usuario.login;
            if (usuario.admin == 1)
            {
                cbAdmin.Checked = true;

                cbACaja.Checked = true;
                cbAClientes.Checked = true;
                cbACompras.Checked = true;
                cbAProductos.Checked = true;
                cbAProveedores.Checked = true;
                cbAUsuarios.Checked = true;
                cbAVentas.Checked = true;
                cbAReportes.Checked = true;                
            }
            else
            {
                cbAdmin.Checked = false;

                if (usuario.aCaja == 1)
                    cbACaja.Checked = true;
                else
                    cbACaja.Checked = false;

                if (usuario.aClientes == 1)
                    cbAClientes.Checked = true;
                else
                    cbAClientes.Checked = false;

                if (usuario.aCompras == 1)
                    cbACompras.Checked = true;
                else
                    cbACompras.Checked = false;

                if (usuario.aProductos == 1)
                    cbAProductos.Checked = true;
                else
                    cbAProductos.Checked = false;

                if (usuario.aProveedores == 1)
                    cbAProveedores.Checked = true;
                else
                    cbAProveedores.Checked = false;

                if (usuario.aUsuarios == 1)
                    cbAUsuarios.Checked = true;
                else
                    cbAUsuarios.Checked = false;

                if (usuario.aVentas == 1)
                    cbAVentas.Checked = true;
                else
                    cbAVentas.Checked = false;

                if (usuario.aGenerarReportes == 1)
                    cbAReportes.Checked = true;
                else
                    cbAReportes.Checked = false;
            }
        }
    }
}
