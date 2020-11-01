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
    /// Lógica de interacción para Servicio_Extra.xaml
    /// </summary>
    public partial class Servicio_Extra : Window
    {
        ServicioExtraBL servicioExtraBL;
        ServicioExtraBE oServicioExtra;
        List<ServicioExtraBE> listServicioExtra;
        public Servicio_Extra()
        {
            InitializeComponent();
            
        }

        public Servicio_Extra(int idReserva)
        {
            InitializeComponent();
            servicioExtraBL = new ServicioExtraBL();
            lblUsuario.Content = Login.oUsuarioBE.NombreUsuario + " " + Login.oUsuarioBE.ApellidosUsuario;
            ListarServicioExtraId(idReserva);
        }

        public void ListarServicioExtraId(int idReserva)
        {
            try
            {
                gvServicioExtra.ItemsSource = servicioExtraBL.BuscarServioExtraPorIdReserva(idReserva);
            }
            catch (Exception)
            {

                gvServicioExtra.ItemsSource = null;
            }
        }

        /// <summary>
        /// boton que lleva a la vista reserva
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Salir_Click(object sender, RoutedEventArgs e)
        {
           
            MainWindow form = new MainWindow();
            this.Close();
            form.ShowDialog();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
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

        private void GvServicioExtra_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {

                listServicioExtra = new List<ServicioExtraBE>();

                //reservaTemp = (ReservaBE)((DataGrid)sender).CurrentItem;
                oServicioExtra = new ServicioExtraBE();
                oServicioExtra = (ServicioExtraBE)((DataGrid)sender).CurrentItem;
                foreach (ServicioExtraBE item in ((List<ServicioExtraBE>)((DataGrid)sender).ItemsSource).ToList())
                {
                    ServicioExtraBE oServicio = new ServicioExtraBE();
                    oServicio = item;
                    if (item.IdServicio.Equals(oServicioExtra.IdServicio))
                    {
                        oServicio.IsSelected = true;
                        txtValor.Text = oServicio.ValorServicio.ToString();
                        txtCantidadPersona.Text = oServicio.CantidadPersonas.ToString();
                        txtValorTotal.Text = oServicio.ValorTotalServicio.ToString();
                        txtEstado.Text = oServicio.EstadoServicio.NombreEstadoServicio;
                        txtDescripcion.Text = oServicio.DescripcionServicio;
                    }
                    else
                    {
                        oServicio.IsSelected = false;
                    }
                    listServicioExtra.Add(oServicio);
                }



                ((DataGrid)sender).ItemsSource = listServicioExtra;



            }
            catch (Exception)
            {

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
