using Arriendo.Negocio;
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
        public Servicio_Extra()
        {
            InitializeComponent();
            
        }

        public Servicio_Extra(int idPropiedad)
        {
            InitializeComponent();
            servicioExtraBL = new ServicioExtraBL();
            ListarServicioExtraId(idPropiedad);
        }

        public void ListarServicioExtraId(int idPropiedad)
        {
            try
            {
                gvServicioExtra.ItemsSource = servicioExtraBL.BuscarServioExtraPorIdPropiedad(idPropiedad);
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
            Login form = new Login();
            this.Close();
            form.ShowDialog();
        }
    }
}
