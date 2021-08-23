using Gestionador.Clases;
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

namespace Gestionador.Formularios.Compras
{
    public partial class AltaCompra : Form
    {
        RepositorioProveedores repositorioProveedores;
        RepositorioUsuarios repositorioUsuarios;
        Usuario usuario;
        RepositorioArticulos repositorioArticulos;
        int id;
        RepositorioCaja repositorioCaja;
        RepositorioCompras repositorioCompras;
        Cajaa caja;
        public AltaCompra(int id)
        {
            

            InitializeComponent();
            repositorioProveedores = new RepositorioProveedores();
            repositorioUsuarios = new RepositorioUsuarios();
            repositorioArticulos = new RepositorioArticulos();
            usuario = repositorioUsuarios.ObtenerUsuario(id);
            this.id = id;
            repositorioCaja = new RepositorioCaja();
            caja = repositorioCaja.ObtenerCajaActual();
            repositorioCompras = new RepositorioCompras();
        }

        private void AltaCompra_Load(object sender, EventArgs e)
        {
            lblfecha.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm");// dd-MM-yyyy hh:mi");
            lblUsuario.Text = usuario.nombre;

            DataTable Proveedores;

            Proveedores = repositorioProveedores.ObtenerComboProveedores();
            cmbProveedores.DataSource = Proveedores;
            cmbProveedores.ValueMember = "cuit";
            cmbProveedores.DisplayMember = "proveedores";

            cmbProveedores.SelectedIndex = -1;

            

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            var confirmacion = MessageBox.Show("¿Esta seguro que desea salir, aun no realizo registro la compra?", "Confirme operacion", MessageBoxButtons.YesNo);
            if (confirmacion.Equals(DialogResult.No))
                return;
            else
            {
                this.Dispose();
            }
        }

        private void btnAgregarMarca_Click(object sender, EventArgs e)
        {

        }

        private void cbAfectarCaja_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(txtCodigo.Text=="")
            {
                var ventana = new Productosss(this);
                ventana.ShowDialog();

            }
            else
            {
                try
                {
                    var articulo = repositorioArticulos.ObtenerProductoConCodigo(txtCodigo.Text).Rows;
                    
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
                    registro.ItemArray[5].ToString(),
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
            if (cmbProveedores.Text == "")
            {
                MessageBox.Show("ingrese proveedor");
                return;
            }

            

            try
            {
                var compra = new Compraa();
                compra.fecha = DateTime.Now;
                compra.usuario = id;
                compra.proveedor = int.Parse(cmbProveedores.SelectedValue.ToString());
                if(cbAfectarCaja.Checked==true)
                {
                    compra.afectoCaja = "Si";
                }
                else
                {
                    compra.afectoCaja = "No";
                }
                compra.MontoFinal = string.IsNullOrEmpty(txtTotal.Text) ? 0 : decimal.Parse(txtTotal.Text);//decimal.Parse(txtTotal.Text);
                compra.caja = caja.id;
                compra.detalleCompra= PrepararDetalles();
                compra.Validar();
                
                if(compra.afectoCaja=="Si")
                {
                    caja.cajaActual -= compra.MontoFinal;
                    if(caja.cajaActual<0)
                    {
                        MessageBox.Show("Error caja negativa");
                        return;
                    }
                    else
                    {
                        caja.gastoCompras += compra.MontoFinal;
                        repositorioCompras.Guardar(compra);
                    }
                   

                }
                else
                {
                    caja.gastoCompras += compra.MontoFinal;
                    repositorioCompras.Guardar(compra);
                }

                
                repositorioCaja.ActualizarCajaPorCompras(caja);
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
                cmbProveedores.SelectedIndex = -1;
            }
        }

        public List<DetalleCompraa> PrepararDetalles()
        {
            var detalles = new List<DetalleCompraa>();

            var filas = dgvProductos.Rows;

            foreach (DataGridViewRow fila in filas)
            {
                if (fila.Cells["subtotal"].Value == null)
                    continue;
                var detalle = new DetalleCompraa()
                {
                   
                    cantidad = int.Parse(fila.Cells["cantidad"].Value.ToString()),
                    precio = decimal.Parse(fila.Cells["precio"].Value.ToString()),                   
                    producto = new Producto() { codigo = fila.Cells["codigo"].Value.ToString() }
                };
                detalles.Add(detalle);
            }
            return detalles;
        }
    }
}
