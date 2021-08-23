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

namespace Gestionador.Formularios.Ventas
{
    public partial class NuevaVenta : Form
    {
        RepositorioVentas repositorioVentas;
        RepositorioUsuarios repositorioUsuarios;
        Usuario usuario;
        RepositorioArticulos repositorioArticulos;
        int id;
        Cajaa caja;
        RepositorioCaja repositorioCaja;
        public NuevaVenta(int id)
        {
            
            InitializeComponent();
            repositorioVentas = new RepositorioVentas();
            repositorioUsuarios = new RepositorioUsuarios();
            repositorioArticulos = new RepositorioArticulos();
            usuario = repositorioUsuarios.ObtenerUsuario(id);
            this.id = id;
            repositorioCaja = new RepositorioCaja();
            caja = repositorioCaja.ObtenerCajaActual();
        }

        private void NuevaVenta_Load(object sender, EventArgs e)
        {
            rbContado.Checked = true;
            DataTable Clientes;
            DataTable facturas;

            Clientes = repositorioVentas.ObtenerComboClientes();
            cmbClientes.DataSource = Clientes;
            cmbClientes.ValueMember = "nroDoc";
            cmbClientes.DisplayMember = "clientes";

            facturas = repositorioVentas.ObtenerTiposFacturas();
            cmbTipoFactura.DataSource = facturas;
            cmbTipoFactura.ValueMember = "id";
            cmbTipoFactura.DisplayMember = "nombre";

            cmbClientes.SelectedIndex = 0;
            cmbTipoFactura.SelectedIndex = -1;

            lblUsuario.Text = usuario.nombre;
            lblFecha.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm");// dd-MM-yyyy hh:mi");

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            var confirmacion = MessageBox.Show("¿Esta seguro que desea salir, aun no realizo venta?", "Confirme operacion", MessageBoxButtons.YesNo);
            if (confirmacion.Equals(DialogResult.No))
                return;
            else
            {
                this.Dispose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {            
                var ventana = new Clientesss(this);
                ventana.ShowDialog();
            
        }

        private void btnBuscarCodigo_Click(object sender, EventArgs e)
        {
            if(txtCodigo.Text=="")
            {
                var ventana = new Productosss(this);

            }
            else
            {
                try
                {
                    var articulo = repositorioArticulos.ObtenerProductoConCodigoFinal(txtCodigo.Text).Rows;

                    ActualizarGrilla(articulo);
                }
                catch
                {
                    MessageBox.Show("El producto no existe con ese codigo");

                    txtCodigo.Text = "";
                    txtCodigo.Focus();
                    
                }
            }
        }

        public void ActualizarGrilla(DataRowCollection registros)
        {
            foreach (DataRow registro in registros)
            {
                if (registro.HasErrors)
                    continue; // no corto el ciclo
                var fila = new string[] {
                    registro.ItemArray[0].ToString(),
                    registro.ItemArray[1].ToString(),
                    registro.ItemArray[2].ToString(),
                    registro.ItemArray[3].ToString(),
                    registro.ItemArray[4].ToString(),
                    registro.ItemArray[6].ToString(),
                    registro.ItemArray[7].ToString(),
                    registro.ItemArray[8].ToString(),


                };

                dgvProductos.Rows.Add(fila);
            }
        }

        private void dgvProductos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var fila = dgvProductos.Rows[e.RowIndex];
            int cantidad = 0;
            if (!int.TryParse(fila.Cells["cantidad"].Value?.ToString(), out cantidad))
            {
                fila.Cells["cantidad"].Value = null;
                fila.Cells["subtotal"].Value = null;
                ActualizarTotal();
                return;
            }
            if (cantidad < 0)
            {
                MessageBox.Show("ingrese cantidad valida");
                fila.Cells["cantidad"].Value = null;
                fila.Cells["subtotal"].Value = null;
                ActualizarTotal();
                return;
            }
            var precioUnitario = float.Parse(fila.Cells["precio"].Value.ToString());
            var subtotal = cantidad * precioUnitario;
            fila.Cells["subtotal"].Value = subtotal;
            ActualizarTotal();
            return;
        }

        private void ActualizarTotal()
        {
            var filas = dgvProductos.Rows;

            decimal total = 0;
            foreach (DataGridViewRow fila in filas)
            {
                if (fila.Cells["subtotal"].Value == null)
                    continue;
                total += decimal.Parse(fila.Cells["Subtotal"].Value.ToString());
            }
            if (total != 0)
                txtTotal.Text = total.ToString();
            else
                txtTotal.Text = null;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbTipoFactura.Text == "")
            {
                MessageBox.Show("ingrese tipo de factura");
                return;
            }      



            try
            {
                var venta = new Ventaa();
                venta.fecha = DateTime.Now;
                venta.usuario = id;
                venta.tipoFactura = int.Parse(cmbTipoFactura.SelectedValue.ToString());
                venta.cliente = int.Parse(cmbClientes.SelectedValue.ToString());
                if(rbContado.Checked==true)
                {
                    venta.tipoPago = "Contado";
                }
                if(rbTarjeta.Checked==true)
                {
                    venta.tipoPago = "Tarjeta";
                }
                if(rbCuentaCorriente.Checked==true)
                {
                    venta.tipoPago = "Cuenta corriente";
                }
                venta.MontoFinal= string.IsNullOrEmpty(txtTotal.Text) ? 0 : decimal.Parse(txtTotal.Text);//decimal.Parse(txtTotal.Text);
                venta.caja = caja.id;
                venta.detalleVenta = PrepararDetalles();
                venta.Validar();                             

                
                caja.cajaActual += venta.MontoFinal;
                if (caja.cajaActual < 0)
                {
                    MessageBox.Show("Error caja negativa");
                    return;
                }
                else
                {
                    caja.ventas += venta.MontoFinal;
                    repositorioVentas.Guardar(venta);
                }

                repositorioCaja.ActualizarCajaPorVentas(caja);
                MessageBox.Show("La operación se realizó con exito");
                this.Dispose();
            }
            catch (ApplicationException aex)
            {
                MessageBox.Show(aex.Message);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocurrio un error inesperado: " + ex);
            }
            finally
            {
                dgvProductos.Rows.Clear();
                cmbTipoFactura.SelectedIndex = -1;
                cmbClientes.SelectedIndex = 0;
            }
        }

        public List<DetalleVentaa> PrepararDetalles()
        {
            var detalles = new List<DetalleVentaa>();

            var filas = dgvProductos.Rows;

            foreach (DataGridViewRow fila in filas)
            {
                if (fila.Cells["subtotal"].Value == null)
                    continue;
                var detalle = new DetalleVentaa()
                {

                    cantidad = int.Parse(fila.Cells["cantidad"].Value.ToString()),
                    precio = decimal.Parse(fila.Cells["precio"].Value.ToString()),
                    producto = new Producto() { codigo = fila.Cells["codigo"].Value.ToString() }
                };
                detalles.Add(detalle);
            }
            return detalles;
        }

        public void ElegirCliente(string id)
        {
            cmbClientes.SelectedValue = id;
        }
        public void AgregarRowConCodigo(string codigo)
        {
            
                var articulo = repositorioArticulos.ObtenerProductoConCodigoFinal(codigo).Rows;

                ActualizarGrilla(articulo);
            
        }

    }
}
