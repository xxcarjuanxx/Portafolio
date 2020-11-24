using Arriendo.Negocio;
using Arriendo.Presentacion.form_mensaje;
using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Lógica de interacción para OlvidoContrasenia.xaml
    /// </summary>
    public partial class OlvidoContrasenia : Window
    {
        UsuarioBL usuarioBL;
        public OlvidoContrasenia()
        {
            InitializeComponent();
            SnackbarError.Visibility = Visibility.Visible;
            SnackbarCorrecto.Visibility = Visibility.Visible;
            usuarioBL = new UsuarioBL();
        }

        private void Btn_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void BtnEnviar_Click(object sender, RoutedEventArgs e)
        {
            Task<bool> taskmensaje = new Task<bool>(CorreoBL.TimeMensaje);
            try
            {
                if (txtUsuario.Text.Trim().Length<=0)
                {
                    txtUsuario.Focus();
                    throw new Exception("Ingrese su usuario");
                }
            
                int idRol = int.Parse(ConfigurationManager.AppSettings["RolAdmin"]);//
                string correoCliente = ZthSeguridad.Metodos.Desencriptar(ConfigurationManager.AppSettings["CorreoCliente"]);
                string pss = ZthSeguridad.Metodos.Desencriptar(ConfigurationManager.AppSettings["CorreoClave"]);
                string puerto = ZthSeguridad.Metodos.Desencriptar(ConfigurationManager.AppSettings["Port"]);
                string host = ZthSeguridad.Metodos.Desencriptar(ConfigurationManager.AppSettings["Host"]);
                string correo = usuarioBL.GetCorreoAdministrador(idRol);
                string html = CorreoBL.Html(txtUsuario.Text);

                SnackbarCorrecto.IsActive = true;
                SnackbarCorrecto.Message.Content = "Enviando correo a TI ...";
                btnOlvidoContrasenia.IsEnabled = false;
                string resultado = await CorreoBL.EnviarCorreo(correo, correoCliente, "Olvide mi contraseña - RUT " + txtUsuario.Text, html, pss, puerto, host);
                if (resultado.Equals("1"))
                {
                    SnackbarCorrecto.IsActive = true;
                    SnackbarCorrecto.Message.Content = "Se envió el correo a TI";
                    taskmensaje.Start();
                    bool resp = await taskmensaje;
                    if (resp)
                    {
                        SnackbarCorrecto.IsActive = false;
                    }
                    //FormSuccess form = new FormSuccess();
                    //form.lblMensaje.Text = "Se envió el correo a TI"; ;
                    //form.Show();
                }
                else
                {
                    SnackbarError.IsActive = true;
                    SnackbarError.Message.Content = "Algo ocurrió, inténtelo más tarde ";
                    taskmensaje.Start();
                    bool resp = await taskmensaje;
                    if (resp)
                    {
                        SnackbarError.IsActive = false;
                        SnackbarCorrecto.IsActive = false;
                    }
                    //FormError formError = new FormError();
                    //formError.lblMensaje.Content = "Algo ocurrió, inténtelo más tarde ";
                    //formError.Show();
                }
            }
            catch (Exception ex)
            {
                SnackbarError.IsActive = true;
                SnackbarError.Message.Content = ex.Message;
                taskmensaje.Start();
                bool resp = await taskmensaje;
                if (resp)
                {
                    SnackbarError.IsActive = false;
                }
                //FormError formError = new FormError();
                //formError.lblMensaje.Content = "Algo ocurrió, inténtelo más tarde ";
                //formError.Show();

            }

        }
      

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

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
