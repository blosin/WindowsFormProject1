﻿using Gestionador.Clases;
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
    public partial class Ventas : Form
    {
        int id;
        RepositorioCaja repositorioCaja;
        Cajaa cajaActual;
        RepositorioVentas repositorioVentas;
        public Ventas(int id)
        {

            InitializeComponent();
            this.id = id;
            repositorioCaja = new RepositorioCaja();
            cajaActual = repositorioCaja.ObtenerCajaActual();
            repositorioVentas = new RepositorioVentas();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var ventana = new NuevaVenta(id);
            ventana.ShowDialog();
            ActualizarVentas();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            var seleccion = dgvVentas.SelectedRows;
            if (seleccion.Count == 0 || seleccion.Count > 1)
            {
                MessageBox.Show("Debe seleccionar una fila");
                return;
            }
            foreach (DataGridViewRow fila in seleccion)
            {
                var numVenta = fila.Cells[0].Value;
                var montoTotal = fila.Cells[6].Value;

                var ventana = new DetalleVenta(int.Parse(numVenta.ToString()), decimal.Parse(montoTotal.ToString()));
                //new DetalleCompra(numOrden.ToString(), decimal.Parse(montoTotal.ToString()));
                ventana.ShowDialog();

            }
        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm");

            ActualizarVentas();
        }
        public void ActualizarVentas()
        {
            dgvVentas.Rows.Clear();
            var ventas = repositorioVentas.ObtenerVentasActuales().Rows;
            ActualizarGrilla(ventas);
        }
        private void ActualizarGrilla(DataRowCollection registros)
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
                    registro.ItemArray[5].ToString(),
                    registro.ItemArray[6].ToString(),


                };

                dgvVentas.Rows.Add(fila);
            }
        }
    }
}
