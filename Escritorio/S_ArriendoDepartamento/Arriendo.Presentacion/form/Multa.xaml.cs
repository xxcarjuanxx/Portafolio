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
    /// Lógica de interacción para Multa.xaml
    /// </summary>
    public partial class Multa : Window
    {

        MultaBL oMultaBL;
        CheckListMultaBE oCheckMultaBE;
        MultaBE oMultaBE;
        private int id_check_list;
        List<MultaBE> oListcheck;

      
        
       
    
        public Multa()
        {
            InitializeComponent();
        }
        public Multa(CheckListBE checkTemp, string rut, int id_Check)
        {
            InitializeComponent();
            txtRutUsuario.Text = rut;
            id_check_list = id_Check;
            oMultaBL = new MultaBL();
            if (checkTemp.EntregaLlave.Equals("No"))
            {
                txtDescripcion.Text = "Se realiza cobro por lo siguiente:\n "+ "No entregar llave\n";
            }
            if (checkTemp.EntregaControlTv.Equals("No"))
            {
                txtDescripcion.Text += "No entrega control TV\n";

            }
            if (checkTemp.EntregaControlAir.Equals("No"))
            {
                txtDescripcion.Text += "No entrega control aire";
            }

            ListaCheck(id_Check);
        }
        private void Btn_Salir_Click(object sender, RoutedEventArgs e)
        {
            CheckList form = new CheckList();
            this.Close();
            form.ShowDialog();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                oMultaBL = new MultaBL();
                oMultaBE = new MultaBE();
                oCheckMultaBE = new CheckListMultaBE();

                oMultaBE.DescripcionMulta = txtDescripcion.Text;
                oMultaBE.ValorMulta = int.Parse(txtValorMulta.Text);
                oCheckMultaBE.ComentarioUsuario = txtComentario.Text;
                oCheckMultaBE.CheckList.IdCheckIn = id_check_list;

                if (oMultaBL.AgregarMulta(oMultaBE, oCheckMultaBE))
                {

                    FormSuccess form = new FormSuccess();
                    form.lblMensaje.Content = "Se Agrego correctamente";
                    form.Show();

                }
                else {
                    FormError formError = new FormError();
                    formError.lblMensaje.Content = "Ocurrió algo, revisa el log para mas detalles ";
                    formError.Show();
                }

              
            }
            catch (Exception ex)
            {

                FormError formError = new FormError();
                formError.lblMensaje.Content = ex.Message;
                formError.Show();
            }




        }

        private void txtDescripcion_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Btn_Minimizar_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
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

        private void ListaCheck(int id_check_list)
        {
            try
            {
                // oCheckDL = new CheckListBL();

                var oListcheck = oMultaBL.ListarMulta(id_check_list);
                btnAceptar.IsEnabled = true;
                if (oListcheck.Count > 0)
                {
                    btnAceptar.IsEnabled = false;
                }
                gvCheckList.ItemsSource = oListcheck;

            }
            catch
            {

                gvCheckList.ItemsSource = null;
            }

        }

        private void GvcheckList_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        { }
        private void gvCheckList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

    
}

