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
    /// Lógica de interacción para Listar_Huesped.xaml
    /// </summary>
    public partial class Listar_Huesped : Window
    {
        HuespedBL huespedBL;
        public Listar_Huesped()
        {
            InitializeComponent();
        }
        public Listar_Huesped(int idReserva)
        {
            InitializeComponent();
            huespedBL = new HuespedBL();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        public void ListarHuespedId(int idReserva) {
            try
            {
                gvListaHuesped.ItemsSource = huespedBL.ListarHuespedPorIdReserva(idReserva);
            }
            catch (Exception ex)
            {

                gvListaHuesped.ItemsSource = null;
            }
        }

        private void Btn_Salir_Click(object sender, RoutedEventArgs e)
        {
           
            MainWindow form = new MainWindow();
            this.Close();
            form.ShowDialog();
        }
    }
}
