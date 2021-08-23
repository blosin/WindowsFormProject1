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

namespace Gestionador.Formularios.Empleados
{
    public partial class ModificarUsuario : Form
    {
        Usuario usuario;
        RepositorioUsuarios repositorioUsuarios;
        
        public ModificarUsuario(int id)
        {
            InitializeComponent();
            
            repositorioUsuarios = new RepositorioUsuarios();
            usuario = repositorioUsuarios.ObtenerUsuario(id);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtContrasena.Enabled = true;
            txtContrasena2.Enabled = true;
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            txtContrasena.Enabled = true;
            txtContrasena2.Enabled = true;
        }

        private void ModificarUsuario_Load(object sender, EventArgs e)
        {
            lblfecha.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm");


            txtNombre.Text = usuario.nombre;
            txtLogin.Text = usuario.login;
            txtObservacion.Text = usuario.observaciones;

            if(usuario.admin==1)
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


                cbACaja.Enabled = false;
                cbAClientes.Enabled = false;
                cbACompras.Enabled = false;
                cbAProductos.Enabled = false;
                cbAProveedores.Enabled = false;
                cbAUsuarios.Enabled = false;
                cbAVentas.Enabled = false;
                cbAReportes.Enabled = false;
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

        private void cbAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAdmin.Checked)
            {
                cbACaja.Checked = true;
                cbAClientes.Checked = true;
                cbACompras.Checked = true;
                cbAProductos.Checked = true;
                cbAProveedores.Checked = true;
                cbAUsuarios.Checked = true;
                cbAVentas.Checked = true;
                cbAReportes.Checked = true;


                cbACaja.Enabled = false;
                cbAClientes.Enabled = false;
                cbACompras.Enabled = false;
                cbAProductos.Enabled = false;
                cbAProveedores.Enabled = false;
                cbAUsuarios.Enabled = false;
                cbAVentas.Enabled = false;
                cbAReportes.Enabled = false;

            }
            else
            {
                cbACaja.Checked = false;
                cbAClientes.Checked = false;
                cbACompras.Checked = false;
                cbAProductos.Checked = false;
                cbAProveedores.Checked = false;
                cbAUsuarios.Checked = false;
                cbAVentas.Checked = false;
                cbAReportes.Checked = false;

                cbACaja.Enabled = true;
                cbAClientes.Enabled = true;
                cbACompras.Enabled = true;
                cbAProductos.Enabled = true;
                cbAProveedores.Enabled = true;
                cbAUsuarios.Enabled = true;
                cbAVentas.Enabled = true;
                cbAReportes.Enabled = true;

            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Ingrese el nombre del usuario");
                txtNombre.Focus();
                return;
            }

            if (txtLogin.Text == "")
            {
                MessageBox.Show("Ingrese usuario");
                txtLogin.Focus();
                return;
            }
            if(txtContrasena.Enabled)
            {
                if (txtContrasena.Text == "")
                {
                    MessageBox.Show("Ingrese contraseña");
                    txtContrasena.Focus();
                    return;
                }
                if (txtContrasena2.Text == "")
                {
                    MessageBox.Show("Repita la contraseña");
                    txtContrasena2.Focus();
                    return;
                }
            }
            
            usuario.fechaMod = DateTime.Now;
            usuario.nombre = txtNombre.Text;
            usuario.login = txtLogin.Text;
            if(txtContrasena.Enabled)
            {
                if (txtContrasena.Text == txtContrasena2.Text)
                {
                    usuario.contrasena = Encriptacion.GetSHA256(txtContrasena.Text);
                }
                else
                {
                    MessageBox.Show("Las contraseñas no coinciden");
                    txtContrasena.Text = "";
                    txtContrasena2.Text = "";
                    txtContrasena.Focus();
                    return;
                }
            }
            

            if (txtObservacion.Text == "")
            {
                usuario.observaciones = "--Sin observaciones--";
            }
            else
            {
                usuario.observaciones = txtObservacion.Text;
            }

            if (cbAdmin.Checked)
            {
                usuario.admin = 1;
                usuario.aClientes = 1;
                usuario.aCompras = 1;
                usuario.aProductos = 1;
                usuario.aProveedores = 1;
                usuario.aUsuarios = 1;
                usuario.aVentas = 1;
                usuario.aCaja = 1;
                usuario.aGenerarReportes = 1;



            }
            else
            {
                usuario.admin = 0;
                if (cbAClientes.Checked)
                    usuario.aClientes = 1;
                else
                    usuario.aClientes = 0;

                if (cbACompras.Checked)
                    usuario.aCompras = 1;
                else
                    usuario.aCompras = 0;

                if (cbAProductos.Checked)
                    usuario.aProductos = 1;
                else
                    usuario.aProductos = 0;

                if (cbAProveedores.Checked)
                    usuario.aProveedores = 1;
                else
                    usuario.aProveedores = 0;

                if (cbAUsuarios.Checked)
                    usuario.aUsuarios = 1;
                else
                    usuario.aUsuarios = 0;

                if (cbAVentas.Checked)
                    usuario.aVentas = 1;
                else
                    usuario.aVentas = 0;

                if (cbACaja.Checked)
                    usuario.aCaja = 1;
                else
                    usuario.aCaja = 0;

                if (cbAReportes.Checked)
                    usuario.aGenerarReportes = 1;
                else
                    usuario.aGenerarReportes = 0;

            }


            if (usuario.nombreValido() == false)
            {
                MessageBox.Show("nombre invalido");
                txtNombre.Text = null;
                txtNombre.Focus();
                return;
            }
            if (usuario.loginValido() == false)
            {
                MessageBox.Show("Ingrese usuario valido");
                txtLogin.Text = null;
                txtLogin.Focus();
                return;
            }
            if (usuario.contrasenaValida() == false)
            {
                MessageBox.Show("Contraseña invalida");
                txtContrasena.Text = null;
                txtContrasena2.Text = null;
                txtContrasena.Focus();
                return;
            }
            if (usuario.observacionesValida() == false)
            {
                MessageBox.Show("Observaciones no validas(700 caracteres)");
                txtObservacion.Text = null;
                txtObservacion.Focus();
                return;
            }


            if (usuario.adminValido() == false)
            {
                MessageBox.Show("Error de chequeo");
                return;
            }
            if (usuario.aClientesValido() == false)
            {
                MessageBox.Show("Error de chequeo");
                return;
            }
            if (usuario.aComprasValido() == false)
            {
                MessageBox.Show("Error de chequeo");
                return;
            }
            if (usuario.aProductosValido() == false)
            {
                MessageBox.Show("Error de chequeo");
                return;
            }
            if (usuario.aProveedoresValido() == false)
            {
                MessageBox.Show("Error de chequeo");
                return;
            }
            if (usuario.aUsuariosValido() == false)
            {
                MessageBox.Show("Error de chequeo");
                return;
            }
            if (usuario.aVentasValido() == false)
            {
                MessageBox.Show("Error de chequeo");
                return;
            }
            if (usuario.aCajaValido() == false)
            {
                MessageBox.Show("Error de chequeo");
                return;
            }
            if (usuario.aGenerarReportesValido() == false)
            {
                MessageBox.Show("Error de chequeo");
                return;
            }

            DataTable tablatemporal = repositorioUsuarios.UsuarioExistente(usuario.login);
            if (tablatemporal.Rows.Count == 0)
            {
                if(repositorioUsuarios.Actualizar(usuario))
                {
                    MessageBox.Show("Se actualizo con exito");
                    this.Dispose();
                }
                else
                MessageBox.Show("Error de actualizacion");
                


            }
            else
                MessageBox.Show($"ya existe un usuario con ese login");

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
