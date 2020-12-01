using Arriendo.Entidades;
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
        UsuarioBE usuarioBE;
        public OlvidoContrasenia()
        {
            InitializeComponent();
            SnackbarError.Visibility = Visibility.Visible;
            SnackbarCorrecto.Visibility = Visibility.Visible;
            CircularProgress.IsIndeterminate = false;
            CircularProgress.Value = 0;
            usuarioBL = new UsuarioBL();
            usuarioBE = new UsuarioBE();
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
                int idRol = int.Parse(ConfigurationManager.AppSettings["RolAdmin"]);//
                int idRolFuncionario = int.Parse(ConfigurationManager.AppSettings["RolId"]);//
                string correoCliente = ZthSeguridad.Metodos.Desencriptar(ConfigurationManager.AppSettings["CorreoCliente"]);
                string pss = ZthSeguridad.Metodos.Desencriptar(ConfigurationManager.AppSettings["CorreoClave"]);
                string puerto = ZthSeguridad.Metodos.Desencriptar(ConfigurationManager.AppSettings["Port"]);
                string host = ZthSeguridad.Metodos.Desencriptar(ConfigurationManager.AppSettings["Host"]);


                if (txtUsuario.Text.Trim().Length<=0)
                {
                    txtUsuario.Focus();
                    throw new Exception("Ingrese su usuario");
                }
                usuarioBE.RutUsuario = txtUsuario.Text;
                usuarioBE.RolUsuario.IdRol = idRolFuncionario;

                if (usuarioBL.ListarUsuarioRutRol(usuarioBE).Count<1) {
                    txtUsuario.Focus();
                    throw new Exception("Usuario no válido");
                }
                
                string correo = usuarioBL.GetCorreoAdministrador(idRol);
                string html = CorreoBL.Html(txtUsuario.Text);

                CircularProgress.IsIndeterminate = true;
                SnackbarCorrecto.IsActive = true;
                SnackbarCorrecto.Message.Content = "Enviando correo a TI ...";
                btnOlvidoContrasenia.IsEnabled = false;
                string resultado = await CorreoBL.EnviarCorreo(correo, correoCliente, "Olvide mi contraseña - RUT " + txtUsuario.Text, html, pss, puerto, host);
                if (resultado.Equals("1"))
                {
                    CircularProgress.IsIndeterminate = false;
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
                    CircularProgress.IsIndeterminate = false;
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
