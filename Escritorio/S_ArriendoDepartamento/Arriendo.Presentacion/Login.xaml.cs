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

namespace Arriendo.Presentacion
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        UsuarioBL oUsuarioBL;
        UsuarioBE oUsuarioBE;
        public Login()
        {
            InitializeComponent();
            CircularProgress.IsIndeterminate = false;
            CircularProgress.Value = 0;
            oUsuarioBL = new UsuarioBL();
           
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Btn_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                oUsuarioBE = new UsuarioBE();
                oUsuarioBE.RutUsuario = txtUsuario.Text;
                oUsuarioBE.PasswordUsuario = txtPassword.Password;
                oUsuarioBE.RolUsuario.IdRol = 2;
                CircularProgress.IsIndeterminate = true;
                btnLogin.IsEnabled = false;
                await TaskUsuario(oUsuarioBE);


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

        internal async Task TaskUsuario(UsuarioBE usuarioBE)
        {
            try
            {
                for (int i = 30; i <= 100; i++)
                {
                
                    CircularProgress.Value = i;


                    if (i == 97)
                    {
                        oUsuarioBE = new UsuarioBE();
                        oUsuarioBE = oUsuarioBL.Login(usuarioBE);
                        if (oUsuarioBE!=null)
                        {
                            MainWindow form = new MainWindow();
                            form.lblUsuario.Content = oUsuarioBE.NombreUsuario + " "+ oUsuarioBE.ApellidosUsuario;
                            this.Close();
                            form.ShowDialog();
                        }
                        else
                        {
                            FormError formError = new FormError();
                            formError.lblMensaje.Content = "Usuario o Contraseña incorrecta";
                            formError.Show();
                        }
                        CircularProgress.IsIndeterminate = false;
                        btnLogin.IsEnabled = true;
                    }
                    await Task.Delay(51);
                }
                
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
    }
}
