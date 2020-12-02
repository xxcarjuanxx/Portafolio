using Arriendo.Entidades;
using Arriendo.Negocio;
using Arriendo.Presentacion.form;
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
using System.Windows.Media.Animation;
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
        ReservaBE reservaTemp { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            oHuespedBL = new HuespedBL();
            oReservaBL = new ReservaBL();
            oServicioExtraBL = new ServicioExtraBL();
            lblUsuario.Content =  Login.oUsuarioBE.NombreUsuario + " " + Login.oUsuarioBE.ApellidosUsuario;
            ListaReservas("");
            CargarDatosStatic();


        }

        private async void CargarDatosStatic() {
            
     
            Task<List<HuespedBE>> taskHuesped = new Task<List<HuespedBE>>(oHuespedBL.ListarHuespedes);
            taskHuesped.Start();
           await taskHuesped;
            Task<List<ReservaServicioExtraBE>> taskServicioExtra = new Task<List<ReservaServicioExtraBE>>(oServicioExtraBL.ListarReservaServicioExtra);
            taskServicioExtra.Start();
            await taskServicioExtra;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void ListaReservas(string rut)
        {
            try
            {
               
                if (oListReserva.Count == 0)
                {
                    if (rut.Trim() == string.Empty)
                    {
                        oListReserva = oReservaBL.GetAllReservas();
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

        private async void ActualizarReservas() {
            Task<List<ReservaBE>> taskListaReserva = new Task<List<ReservaBE>>(oReservaBL.ListarReservas);
            taskListaReserva.Start();
            gvReservas.ItemsSource = await taskListaReserva;
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
            else
            {
                form.Close();
            }
            
        }

        private void BtnCheckList_Click(object sender, RoutedEventArgs e)
        {
            CheckList formCheckList = new CheckList(reservaTemp);
            this.Close();
            formCheckList.ShowDialog();
        }
        private void BtnPagar_Click(object sender, RoutedEventArgs e)
        {
            Pago form = new Pago(reservaTemp);
            this.Close();
            form.ShowDialog(); 
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


        //int count = 0;
        private void GvReservas_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {

                txtBuscarReserva.Text = "";
                btnCheckList.IsEnabled = true;
                btnPagar.IsEnabled = true;
                
                btnVerServicioExtra.IsEnabled = true;
                reservaTemp = (ReservaBE)((DataGrid)sender).CurrentItem;
                var lista = oListReserva;
                oListReserva = new List<ReservaBE>();
                foreach (ReservaBE item in lista.ToList())
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
                        if (item.MontoPagar.Equals(0)) {
                            btnPagar.IsEnabled = false;
                            btnCheckList.IsEnabled = true;
                        }
                        else{
                            btnPagar.IsEnabled = true;
                            btnCheckList.IsEnabled = false;
                        }
                        if (item.EstadoReserva.ToLower().Contains("can") || item.EstadoReserva.ToLower().Contains("res"))
                        {
                            btnCheckList.IsEnabled = false;
                        }
                        else
                        {
                            btnCheckList.IsEnabled = true;
                        }

                    }
                    else
                    {
                        oReservaBE.IsSelected = false;
                    }
                    oListReserva.Add(oReservaBE);
                }



                ((DataGrid)sender).ItemsSource = oListReserva;


                if (reservaTemp == null)
                {
                    btnCheckList.IsEnabled = false;
                    btnPagar.IsEnabled = false;
                    btnVerHuesped.IsEnabled = false;
                    btnVerServicioExtra.IsEnabled = false;
                }
                //}
                //else
                //{
                //    count = 0;
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
            //if (WindowState == WindowState.Maximized)
            //{
            //    WindowState = WindowState.Normal;
            //}
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

        private void DataGrid_OnTargetUpdated(object sender, DataTransferEventArgs e)
        {
            //if (count == 0)
            //{
            //    count++;
            //Obtengo el datagrid que llama
            var dg = (DataGrid)sender;
            //Seteo el ancho de la columna que ocupa el ''resto'' del espacio
            dg.Columns[0].Width = 0;
            //Actualizo
            dg.UpdateLayout();
            //Luego vuelvo a setear el ancho relativo.
            dg.Columns[0].Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            //}
            //else
            //{
            //    count = 0;
            //}


        }

        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            ActualizarReservas();
        }
    }
}
