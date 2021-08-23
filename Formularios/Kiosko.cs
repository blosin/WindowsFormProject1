using Gestionador.Clases;
using Gestionador.Formularios;
using Gestionador.Formularios.Caja;
using Gestionador.Formularios.Clientes;
using Gestionador.Formularios.Compras;
using Gestionador.Formularios.Empleados;
using Gestionador.Formularios.notas;
using Gestionador.Formularios.Proveedores;
using Gestionador.Formularios.Ventas;
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

namespace Gestionador
{
    
    public partial class Principio : Form
    {
        Inicio inicio;
        Usuario usuario;
        RepositorioUsuarios repositoriosUsuarios;
        Sesion sesion;
        RepositorioSesiones repositorioSesiones;
        RepositorioCaja repositorioCaja;
        
        public Principio()
        {
            InitializeComponent();
        }

        public Principio(Inicio inicio, Usuario usuario)
        {
            InitializeComponent();
            this.inicio = inicio;
            this.usuario = usuario;
            repositoriosUsuarios = new RepositorioUsuarios();
            sesion = new Sesion();
            repositorioSesiones = new RepositorioSesiones();
            repositorioCaja = new RepositorioCaja();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            var confirmacion = MessageBox.Show("¿Esta seguro que desea salir?","Confirme operacion",MessageBoxButtons.YesNo);
            if (confirmacion.Equals(DialogResult.No))
                return;
            else
            {
                inicio.Dispose();
            }
            
        }

        private void agregarEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gestionarProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void agregarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ventana = new AgregarProducto();
            ventana.ShowDialog();

        }

        private void verProductosActualesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ventana = new Productoss();
            ventana.ShowDialog();
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {

        }

        private void Principio_Load(object sender, EventArgs e)
        {
            this.Text += " "+usuario.nombre;
            DataTable tablatemporal = repositorioCaja.ExisteCajaAbierta();
            if (tablatemporal.Rows.Count == 0)
            {
                cerrarCajaToolStripMenuItem1.Enabled = false;
            }
            else
            {
                abrirCajaToolStripMenuItem1.Enabled = false;
            }
            

        }

        private void modificarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ventana = new Productoss();
            ventana.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void agregarEmpleadoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var ventana = new AgregarUsuario();
            ventana.ShowDialog();
        }

        private void consultarmodificarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ventana = new Clientess();
            ventana.ShowDialog();

        }

        private void nuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ventana = new AgregarCliente();
            ventana.ShowDialog();
        }

        private void modificarEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ventana = new Usuarios();
            ventana.ShowDialog();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            var confirmacion = MessageBox.Show("¿Esta seguro que desea salir?", "Confirme operacion", MessageBoxButtons.YesNo);
            if (confirmacion.Equals(DialogResult.No))
                return;
            else
            {
                //repositoriosUsuarios.CerrarSesion(string UsuarioID);
                sesion.fechaCerrado = DateTime.Now;
                //repositoriosUsuarios.CerrarSesion(string UsuarioID);
                repositorioSesiones.CierreSesion(sesion);
                inicio.Dispose();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var ventana = new NuevaVenta(usuario.id);
            ventana.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ventana = new Productoss();
            ventana.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var ventana = new AgregarCliente();
            ventana.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var ventana = new Caja(usuario.id);
            ventana.ShowDialog();

        }

        private void modificarCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ventana = new Caja(usuario.id);
            ventana.ShowDialog();
        }

        private void estadoCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ventana = new CajaActual();
            ventana.ShowDialog();
        }

        private void verVentasActualesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ventana = new Ventas(usuario.id);
            ventana.ShowDialog();
        }

        private void nuevaVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ventana = new NuevaVenta(usuario.id);
            ventana.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var ventana = new Notas(usuario.id);
            ventana.ShowDialog();
        }

        private void ultimoCierreDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ventana = new VentaAnterior();
            ventana.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var ventana = new CerrarCaja(this, usuario.id);
            ventana.ShowDialog();
        }

        private void abrirCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ventana = new InicioCaja();
            ventana.ShowDialog();
        }

        private void cerrarCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ventana = new CerrarCaja(this, usuario.id);
            ventana.ShowDialog();
        }

        private void agregarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ventana = new AgregarProveedor();
            ventana.ShowDialog();
        }

        private void verModificarProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ventana = new Proveedores();
            ventana.ShowDialog();
        }

        private void agregarCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ventana = new AltaCompra(usuario.id);
            ventana.ShowDialog();
        }

        private void verModificarCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ventana = new HistorialCompras(usuario.id);
            ventana.ShowDialog();
        }

        private void btnCerrarsesion_Click(object sender, EventArgs e)
        {
            var confirmacion = MessageBox.Show("¿Esta seguro que desea cerrar sesion?", "Confirme operacion", MessageBoxButtons.YesNo);
            if (confirmacion.Equals(DialogResult.No))
                return;
            else
            {
                sesion.fechaCerrado=DateTime.Now;
                //repositoriosUsuarios.CerrarSesion(string UsuarioID);
                repositorioSesiones.CierreSesion(sesion);
                this.Dispose();

                inicio.ActivarEfectos();
                inicio.Show();

            }

            //repositoriosUsuarios.CerrarSesion(string UsuarioID);
            
            
        }

        private void historialDeSesionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ventana = new HistorialSesiones();
            ventana.ShowDialog();
        }

        private void comprasActualesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ventana = new ComprasActuales(usuario.id);
            ventana.ShowDialog();
        }

        private void ultimoCierreDeCajaToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void abrirCajaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var ventana = new InicioCaja();
            ventana.ShowDialog();
        }

        private void cerrarCajaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var ventana = new CerrarCaja(this, usuario.id);
            ventana.ShowDialog();
        }
    }
}
