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

namespace Gestionador.Formularios
{
    public partial class Login : Form
    {
        Inicio inicio;
        Principio principio;
        Usuario usuario;
        RepositorioUsuarios repositorioUsuarios;
        RepositorioCaja repositorioCaja;
        InicioCaja inicioCaja;
        RepositorioSesiones repositorioSesiones;
        Sesion sesion;
        public Login(Inicio inicio)
        {
            InitializeComponent();
            this.inicio = inicio;
            repositorioUsuarios = new RepositorioUsuarios();
            repositorioCaja = new RepositorioCaja();
            inicioCaja = new InicioCaja();
            repositorioSesiones = new RepositorioSesiones();
            sesion = new Sesion();

        }
        public Login( )
        {
            InitializeComponent();
            


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();          
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                usuario = repositorioUsuarios.ObtenerUsuarioConLogin(txtUsuario.Text);

                if (usuario.contrasena == Encriptacion.GetSHA256(txtCodigo.Text))
                {
                    inicio.CancelarEfectos();
                    inicio.Hide();
                    principio = new Principio(inicio, usuario);
                    
                    DataTable tablatemporal = repositorioCaja.ExisteCajaAbierta();
                    if (tablatemporal.Rows.Count == 0)
                    {
                        inicioCaja.Show();
                    }
                    else
                        MessageBox.Show($"La caja sigue abierta");
                    ;
                    sesion.fechaApertura = DateTime.Now;
                    sesion.usuario = usuario.id;
                    repositorioSesiones.InicioSesion(sesion);

                    this.Dispose();
                    
                    principio.ShowDialog();
                   


                }
                else
                {
                    MessageBox.Show("Error de datos");
                }

            }
            catch 
            {
                MessageBox.Show("Error de datos");
            }
           

            
        }

        public void BotonAceptar()
        {
            try
            {
                usuario = repositorioUsuarios.ObtenerUsuarioConLogin(txtUsuario.Text);

                if (usuario.contrasena == Encriptacion.GetSHA256(txtCodigo.Text))
                {
                    inicio.CancelarEfectos();
                    inicio.Hide();
                    principio = new Principio(inicio, usuario);

                    DataTable tablatemporal = repositorioCaja.ExisteCajaAbierta();
                    if (tablatemporal.Rows.Count == 0)
                    {
                        inicioCaja.Show();
                    }
                    else
                        MessageBox.Show($"La caja sigue abierta");


                    sesion.fechaApertura = DateTime.Now;
                    sesion.usuario = usuario.id;
                    repositorioSesiones.InicioSesion(sesion);
                    this.Dispose();

                    principio.ShowDialog();



                }
                else
                {
                    MessageBox.Show("Error de datos");
                }

            }
            catch(Exception ex) 
            {
                MessageBox.Show("Error de datos");
            }
        }

       
        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                BotonAceptar();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
