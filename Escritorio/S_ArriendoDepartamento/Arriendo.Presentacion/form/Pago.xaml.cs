using Arriendo.Entidades;
using Arriendo.Negocio;
using Arriendo.Presentacion.form_mensaje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            SnackbarError.Visibility = Visibility.Visible;
            SnackbarCorrecto.Visibility = Visibility.Visible;
            CircularProgress.IsIndeterminate = false;
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

        private async void BtnRegistrarPago_Click(object sender, RoutedEventArgs e)
        {
            Task<bool> taskmensaje = new Task<bool>(TimeMensaje);
            try
            {
                oReservaBE = new ReservaBE(oReservaBE.IdReserva, 0, "PAG");
                CircularProgress.IsIndeterminate = true;


                string respuesta =  await oReservaBL.Registra_Pago_Reserva(oReservaBE);
                string[] respuestaDB = respuesta.Split(',');
                string estado = respuestaDB[0];
                string mensaje = respuestaDB[1];
                if (estado.Equals("0"))
                {
                    txtMontoPagar.Text = "0";
                    CircularProgress.IsIndeterminate = false;
                    btnRegistrarPago.IsEnabled = false;
                    SnackbarCorrecto.IsActive = true;
                    SnackbarCorrecto.Message.Content = mensaje.ToLower(); ;
                    taskmensaje.Start();
                    bool resp = await taskmensaje;
                    if (resp)
                    {
                       
                        SnackbarCorrecto.IsActive = false;
                        MainWindow form = new MainWindow();
                        this.Close();
                        form.ShowDialog();
                    }
              
                }
                else {
                    CircularProgress.IsIndeterminate = false;
                    SnackbarError.IsActive = true;
                    SnackbarError.Message.Content = mensaje.ToLower();
                    taskmensaje.Start();
                    bool resp = await taskmensaje;
                    if (resp)
                    {
                        SnackbarError.IsActive = false;
                    }
               
                }
                    
            }
            catch (Exception ex)
            {
                CircularProgress.IsIndeterminate = false;
                SnackbarError.IsActive = true;
                SnackbarError.Message.Content = "Algo ocurrió, inténtelo más tarde ";
                taskmensaje.Start();
                bool resp = await taskmensaje;
                if (resp)
                {
                    SnackbarError.IsActive = false;
                }
            
            }
        }

        public bool TimeMensaje()
        {

            Thread.Sleep(3000);
            return true;
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
         
        }

        private void Btn_Maximizar_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                iconMaximizar.Kind = MaterialDesignThemes.Wpf.PackIconKind.WindowMaximize;
                this.WindowState = WindowState.Normal;
            }
            else
            {
                iconMaximizar.Kind = MaterialDesignThemes.Wpf.PackIconKind.WindowRestore;
                this.WindowState = WindowState.Maximized;

            }
        }
    }
}
