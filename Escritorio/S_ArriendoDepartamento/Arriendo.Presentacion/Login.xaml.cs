using Arriendo.Entidades;
using Arriendo.Negocio;
using Arriendo.Presentacion.form_mensaje;
using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace Arriendo.Presentacion
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        UsuarioBL oUsuarioBL;
        public static UsuarioBE oUsuarioBE;
       
        public Login()
        {
            InitializeComponent();
            CircularProgress.IsIndeterminate = false;
            CircularProgress.Value = 0;
            oUsuarioBL = new UsuarioBL();
            oUsuarioBE = new UsuarioBE();
        }


        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Btn_Salir_Click(object sender, RoutedEventArgs e)
        {
           
            bool? resultado = this.DialogResult;
            FormAdvertencia form = new FormAdvertencia();
            resultado = form.ShowDialog();
            if (resultado == true)
            {
                this.Close();
            }
            else {
                form.Close();
            }
        }

        private async void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                oUsuarioBE = new UsuarioBE();
                oUsuarioBE.RutUsuario = txtUsuario.Text;
                oUsuarioBE.PasswordUsuario = txtPassword.Password;
                oUsuarioBE.RolUsuario.IdRol = int.Parse( ConfigurationManager.AppSettings["RolId"]);//
                CircularProgress.IsIndeterminate = true;
                btnLogin.IsEnabled = false;
               
                string resp = await inciar();
                Task<UsuarioBE> task = new Task<UsuarioBE>(TaskUsuario);
                task.Start();
                
                UsuarioBE resultado = await task;
                
                if (resultado != null)
                {
                    MainWindow form = new MainWindow();
                    this.Close();
                    form.ShowDialog();
                    CircularProgress.IsIndeterminate = false;
                }
                else
                {
                    FormError formError = new FormError();
                    formError.lblMensaje.Content = "Usuario o Contraseña incorrecta";
                    formError.Show();
                    CircularProgress.IsIndeterminate = false;
                }
                
                btnLogin.IsEnabled = true;

            }
            catch (Exception ex)
            {
                FormError formError = new FormError();
                formError.lblMensaje.Content = $"  {ex.Message}";
                formError.Show();
                CircularProgress.IsIndeterminate = false;
                btnLogin.IsEnabled = true;

            }
        }

        public  async Task<string> inciar() {
       
            await Task.Run(() =>
            {

                for (int i = 1; i <= 100; i++)
                {
                    //Thread.Sleep(51);
                }
            });
            return "";
        }

        private UsuarioBE TaskUsuario()
        {
            try
            {
                oUsuarioBE = oUsuarioBL.Login(oUsuarioBE);
                return oUsuarioBE;
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        internal async Task TaskFor()
        {
            try
            {
                for (int i = 1; i <= 100; i++)
                {
                    CircularProgress.Value = i;
                    await Task.Delay(1);
                }
            }
            catch (Exception)
            {

            }

        }


        //textbox solo número
        private void TxtUsuario_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
                if (ascci >= 48 && ascci <= 57) e.Handled = false;
                else e.Handled = true;
            }
            catch (Exception)
            {   
            }
            
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BtnLogin_Click(sender, null);
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
