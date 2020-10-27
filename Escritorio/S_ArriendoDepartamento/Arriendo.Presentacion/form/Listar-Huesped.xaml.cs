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
    /// Lógica de interacción para Listar_Huesped.xaml
    /// </summary>
    public partial class Listar_Huesped : Window
    {
        HuespedBL huespedBL;
        HuespedBE oHuespedBE;
        List<HuespedBE> listHuesped;
        public Listar_Huesped()
        {
            InitializeComponent();
        }
        public Listar_Huesped(int idReserva)
        {
            InitializeComponent();
            lblUsuario.Content = Login.oUsuarioBE.NombreUsuario + " " + Login.oUsuarioBE.ApellidosUsuario;
            huespedBL = new HuespedBL();
            ListarHuespedId(idReserva);
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
            catch (Exception )
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

        private void GvListaHuesped_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {

                listHuesped = new List<HuespedBE>();

                //reservaTemp = (ReservaBE)((DataGrid)sender).CurrentItem;
                HuespedBE oHuesped = new HuespedBE();
                oHuesped = (HuespedBE)((DataGrid)sender).CurrentItem;
                foreach (HuespedBE item in ((List<HuespedBE>)((DataGrid)sender).ItemsSource).ToList())
                {
                    oHuespedBE = new HuespedBE();
                    oHuespedBE = item;
                    if (item.RutHuesped.Equals(oHuesped.RutHuesped))
                    {
                        oHuespedBE.IsSelected = true;
                        txtRutHuesped.Text = oHuespedBE.RutHuesped.ToString() + " "+ oHuespedBE.DvHuesped;
                        txtNombre.Text = oHuespedBE.NombreHuesped;
                        txtApellido.Text = oHuespedBE.ApellidosHuesped;
                        txtTelefono.Text = oHuespedBE.TelefonoHuesped.ToString();
                    }else
                    {
                        oHuespedBE.IsSelected = false;
                    }
                    listHuesped.Add(oHuespedBE);
                }



                ((DataGrid)sender).ItemsSource = listHuesped;



            }
            catch (Exception)
            {

            }
        }

        private void gvListaHuesped_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, TextChangedEventArgs e)
        {

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
