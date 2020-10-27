using Arriendo.Entidades;
using Arriendo.Negocio;
using Arriendo.Presentacion.form_mensaje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Arriendo.Presentacion.form
{
    /// <summary>
    /// Lógica de interacción para Pago.xaml
    /// </summary>
    public partial class Pago : Window
    {
        ReservaBE oReservaBE = new ReservaBE();
        ReservaBL oReservaBL = new ReservaBL();
        public Pago()
        {
            InitializeComponent();
        }
        public Pago(ReservaBE reservaBE )
        {
            InitializeComponent();
            oReservaBL = new ReservaBL();
            oReservaBE = new ReservaBE();
            oReservaBE.IdReserva = reservaBE.IdReserva;
            txtRutUsuario.Text = reservaBE.Usuario.RutUsuario;
            txtMontoTotal.Text = reservaBE.MontoTotal.ToString();
            txtMontoAnticipado.Text = reservaBE.MontoAnticipo.ToString();
            txtMontoPagar.Text = reservaBE.MontoPagar.ToString();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Btn_Salir_Click(object sender, RoutedEventArgs e)
        {
          
            MainWindow form = new MainWindow();
            this.Close();
            form.ShowDialog();
        }

        private void BtnRegistrarPago_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                oReservaBE = new ReservaBE(oReservaBE.IdReserva, 0, "PAG");

                string[] respuestaDB =  oReservaBL.Registra_Pago_Reserva(oReservaBE);
                string estado = respuestaDB[0];
                string mensaje = respuestaDB[1];
                if (estado.Equals("0"))
                {
                    txtMontoPagar.Text = "0";
                    FormSuccess form = new FormSuccess();
                    form.lblMensaje.Content = mensaje;
                    form.Show();
                }
                else {
                    FormError formError = new FormError();
                    formError.lblMensaje.Content = mensaje;
                    formError.Show();
                }
                    
            }
            catch (Exception ex)
            {
                FormError formError = new FormError();
                formError.lblMensaje.Content = ex.Message;
                formError.Show();
            }
        }
       

        private void ListReserva_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow form = new MainWindow();
            this.Close();
            form.ShowDialog();
        }

        private void ListCerrarSesion_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            bool? resultado = this.DialogResult;
            FormAdvertencia form = new FormAdvertencia();
            resultado = form.ShowDialog();
            if (resultado == true)
            {
                Login formLogin = new Login();
                this.Close();
                formLogin.ShowDialog();
            }
            else
            {
                form.Close();
            }
        }

        private void Btn_Minimizar_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }
        }
    }
}
