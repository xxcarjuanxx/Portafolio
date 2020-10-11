using Arriendo.Entidades;
using Arriendo.Negocio;
using Arriendo.Presentacion.form;
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
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace Arriendo.Presentacion
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ReservaBL oReservaBL;
        HuespedBL oHuespedBL;
        ServicioExtraBL oServicioExtraBL;
        ReservaBE oReservaBE;
        List<ReservaBE> oListReserva = new List<ReservaBE>();
        static ReservaBE reservaTemp { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            oHuespedBL = new HuespedBL();
            oServicioExtraBL = new ServicioExtraBL();
            lblUsuario.Content =  Login.oUsuarioBE.NombreUsuario + " " + Login.oUsuarioBE.ApellidosUsuario;
            ListaReservas("");

            oHuespedBL.ListarHuespedes();
            oServicioExtraBL.ListarReservaServicioExtra();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void ListaReservas(string rut)
        {
            try
            {
                oReservaBL = new ReservaBL();
                if (oListReserva.Count == 0)
                {
                    if (rut.Trim() == string.Empty)
                    {
                        oListReserva = oReservaBL.ListarReservas();
                        gvReservas.ItemsSource = oListReserva;
                    }
                    else {
                        gvReservas.ItemsSource = oListReserva;
                    }
                    
                }
                else {
                    gvReservas.ItemsSource = oReservaBL.ReservaPorRut(oListReserva, rut);
                }
               
            }
            catch (Exception)
            {
                gvReservas.ItemsSource = null;
            }
            

        }

        private void Btn_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnCheckList_Click(object sender, RoutedEventArgs e)
        {
            CheckList formCheckList = new CheckList(reservaTemp.IdReserva,reservaTemp.Usuario.RutUsuario);
            this.Close();
            formCheckList.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Pago form = new Pago();
            this.Close();
            form .ShowDialog();
        }

        private void BtnVerHuesped_Click(object sender, RoutedEventArgs e)
        {
            Listar_Huesped form = new Listar_Huesped(reservaTemp.IdReserva);
            this.Close();
            form.ShowDialog();
        }

        private void BtnVerServicioExtra_Click(object sender, RoutedEventArgs e)
        {
            Servicio_Extra form = new Servicio_Extra(reservaTemp.IdReserva);
            this.Close();
            form.ShowDialog();
        }

        

        private void GvReservas_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                
                oListReserva = new List<ReservaBE>();
                btnCheckList.IsEnabled = true;
                btnPagar.IsEnabled = true;
                
                btnVerServicioExtra.IsEnabled = true;
                reservaTemp = (ReservaBE)((DataGrid)sender).CurrentItem;

                foreach (ReservaBE item in ((List<ReservaBE>)((DataGrid)sender).ItemsSource).ToList())
                {
                    oReservaBE = new ReservaBE();
                    oReservaBE = item;
                    if (item.IdReserva == reservaTemp.IdReserva)
                    {
                        oReservaBE.IsSelected = true;
                        if (oHuespedBL.BuscarHuespedPorIdReserva(reservaTemp.IdReserva).Count > 0)
                        {
                            btnVerHuesped.IsEnabled = true;
                        }
                        else {
                            btnVerHuesped.IsEnabled = false;
                        }

                        oReservaBE.IsSelected = true;
                        if (oServicioExtraBL.BuscarReserServExtPorReserID(reservaTemp.IdReserva))
                        {
                            btnVerServicioExtra.IsEnabled = true;
                        }
                        else
                        {
                            btnVerServicioExtra.IsEnabled = false;
                        }

                    }
                    else
                    {
                        oReservaBE.IsSelected = false;
                    }
                    oListReserva.Add(oReservaBE);
                }



                ((DataGrid)sender).ItemsSource = oListReserva;


                //clienteTemp = respp;
                if (reservaTemp == null)
                {
                    btnCheckList.IsEnabled = false;
                    btnPagar.IsEnabled = false;
                    btnVerHuesped.IsEnabled = false;
                    btnVerServicioExtra.IsEnabled = false;
                }
                else {
                    //txtBuscarReserva.Text = reservaTemp.CantidadPersonas.ToString();
                }
                //else
                //{
                //    if (clienteTemp.Rut.Trim().Equals(string.Empty))
                //    {
                //        btnactualizar.IsEnabled = false;
                //        btneliminar.IsEnabled = false;
                //    }
                //}


            }
            catch (Exception)
            {
                btnCheckList.IsEnabled = false;
                btnPagar.IsEnabled = false;
                btnVerHuesped.IsEnabled = false;
                btnVerServicioExtra.IsEnabled = false;

            }
        }

        private void TxtBuscarReserva_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtBuscarReserva.Text.Trim().Length <= 0)
            {
                ListaReservas("");
            }
            else
            {
                oReservaBE = new ReservaBE();
                oReservaBE.Usuario.RutUsuario = txtBuscarReserva.Text;

                ListaReservas(oReservaBE.Usuario.RutUsuario);
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
            Login form = new Login();
            this.Close();
            form.ShowDialog();
        }

        private void gvReservas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void listCerrarSesion_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void listReserva_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}
