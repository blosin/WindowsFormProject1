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
    public partial class Inicio : Form
    {
        Timer Timer1;
        Timer Timer2;
        Timer Timer3;
        Timer TimerInicio2;
        Timer TimerInicio3;
        
        Login login;
        //Principio kiosko;
        RepositorioCaja repositorioCaja;
        RepositorioSesiones repositorioSesiones;


        public Inicio()
        {
            InitializeComponent();
            Timer1 = new Timer();
            Timer2 = new Timer();
            Timer3 = new Timer();
            TimerInicio2 = new Timer();
            TimerInicio3 = new Timer();

            //Timer1.Enabled = true;
            Timer1.Interval = 3000;
            Timer1.Enabled = true;
            Timer1.Start();
            TimerInicio2.Interval = 1000;
            TimerInicio2.Enabled = true;
            TimerInicio2.Start();
            TimerInicio3.Interval = 2000;
            TimerInicio3.Enabled = true;
            TimerInicio3.Start();
            Timer2.Interval = 3000;            
            Timer3.Interval = 3000;
            
            
            //kiosko = new Principio(this);
            repositorioCaja = new RepositorioCaja();
            repositorioSesiones = new RepositorioSesiones();
            


        }

        public void Login()
        {
            /*Timer1 = new Timer();
            Timer2 = new Timer();
            Timer3 = new Timer();
            TimerInicio2 = new Timer();
            TimerInicio3 = new Timer();

            //Timer1.Enabled = true;
            Timer1.Interval = 3000;
            Timer1.Enabled = true;
            Timer1.Start();
            TimerInicio2.Interval = 1000;
            TimerInicio2.Enabled = true;
            TimerInicio2.Start();
            TimerInicio3.Interval = 2000;
            TimerInicio3.Enabled = true;
            TimerInicio3.Start();
            Timer2.Interval = 3000;
            Timer3.Interval = 3000;

            Timer1.Tick += _animationTimer_Tick;
            TimerInicio2.Tick += TimerInicio2_Tick;
            TimerInicio3.Tick += TimerInicio3_Tick;*/
           
            //kiosko = new Principio(this);
            //repositorioCaja = new RepositorioCaja();
            login = new Login(this);
        }
        private void Inicio_Load(object sender, EventArgs e)
        {
            Timer1.Tick += _animationTimer_Tick;
            TimerInicio2.Tick += TimerInicio2_Tick;
            TimerInicio3.Tick += TimerInicio3_Tick;
            repositorioSesiones.VerificarSesionesAbiertas();
        }

        private void TimerInicio3_Tick(object sender, EventArgs e)
        {
            TimerInicio3.Enabled = false;
            TimerInicio3.Stop();
            Timer3.Enabled = true;
            Timer3.Start();
            Timer3.Tick += Timer3_Tick;  

        }

        private void Timer3_Tick(object sender, EventArgs e)
        {
            lblTitulo.ForeColor = Color.YellowGreen;
        }

        private void TimerInicio2_Tick(object sender, EventArgs e)
        {
            TimerInicio2.Enabled = false;
            TimerInicio2.Stop();
            Timer2.Enabled = true;
            Timer2.Start();
            Timer2.Tick += Timer2_Tick;
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            lblTitulo.ForeColor = Color.Blue; 
        }

        private void _animationTimer_Tick(object sender, EventArgs e)
        {

            lblTitulo.ForeColor = Color.Red;
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
            
            

            //this.Hide();
            Login();
            login.ShowDialog();
            
           
            
        }

        public void ActivarEfectos()
        {
            /*Timer1 = new Timer();
            Timer2 = new Timer();
            Timer3 = new Timer();
            TimerInicio2 = new Timer();
            TimerInicio3 = new Timer();*/

            //Timer1.Enabled = true;
            //Timer1.Interval = 3000;
            Timer1.Enabled = true;
            Timer1.Start();
            //TimerInicio2.Interval = 1000;
            TimerInicio2.Enabled = true;
            TimerInicio2.Start();
            //TimerInicio3.Interval = 2000;
            TimerInicio3.Enabled = true;
            TimerInicio3.Start();
            //Timer2.Interval = 3000;
            //Timer3.Interval = 3000;

            /*Timer1.Tick += _animationTimer_Tick;
            TimerInicio2.Tick += TimerInicio2_Tick;
            TimerInicio3.Tick += TimerInicio3_Tick;*/
        }

        public void CancelarEfectos()
        {
            Timer1.Enabled = false;
            Timer2.Enabled = false;
            Timer3.Enabled = false;
            TimerInicio2.Enabled = false;
            TimerInicio3.Enabled = false;
            Timer1.Stop();
            Timer2.Stop();
            Timer3.Stop();
            TimerInicio2.Stop(); 
            TimerInicio3.Stop(); 
        }
    }
}
