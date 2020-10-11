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
    /// Lógica de interacción para CheckList.xaml
    /// </summary>
    public partial class CheckList : Window
    {
        ComunaBL oComunaDL;
        List<ComunaBE> oListComuna;
        CheckListBL oCheckDL;
        List<CheckListBE> oListcheck;
        CheckListBE oCheckBE;
        int idReserva = 0;
        public CheckList()
        {
            InitializeComponent();
            //ListaComunaId();
           
        }
        public CheckList(int Idreserva,string usuario)
        {
            InitializeComponent();
            //ListaComunaId();
            lblUsuario.Content = Login.oUsuarioBE.NombreUsuario + "" + Login.oUsuarioBE.ApellidosUsuario;
            txtRutUsuario.Text = usuario;
            ListaCheck(Idreserva);
            idReserva = Idreserva;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Btn_Salir_Click(object sender, RoutedEventArgs e)
        {

            MainWindow form = new MainWindow();
            this.Close();
            form.ShowDialog();
        }

        //private void ListaComunaId()
        //{
        //    oComunaDL = new ComunaBL();
        //    oListComuna = new List<ComunaBE>();
        //    int idComuna = 338;
        //    oListComuna = oComunaDL.ListarComunaPorId(idComuna);

        //    gvCheckList.ItemsSource = oListComuna;


        //}
        private void ListaCheck(int Idreserva)
        {
            try
            {
                oCheckDL = new CheckListBL();
                //oListcheck = new List<CheckListBE>();
              

                gvCheckList.ItemsSource = oCheckDL.ListarChecklist(Idreserva);
            }
            catch {

                gvCheckList.ItemsSource = null;
            }

        }

        private void BtnRegistrarMulta_Click(object sender, RoutedEventArgs e)
        {
            Multa form = new Multa();
            this.Close();
            form.ShowDialog();
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtRutUsuario.Text = "";
            cbControlAir.IsChecked = false;
            cbControlTv.IsChecked = false;
            cbLlave.IsChecked = false;
            cbRegalo.IsChecked = false;
            cbxTipoCheck.SelectedIndex = 0;
        }

      
        private void gvCheckList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
            MainWindow form = new MainWindow();
            this.Close();
            form.ShowDialog();
        }

        private void listCerrarSesion_Selected(object sender, RoutedEventArgs e)
        {
            Login form = new Login();
            this.Close();
            form.ShowDialog();
        }

        private void BtnAceptar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                oCheckDL = new CheckListBL();
                //oCheckBE = new CheckListBE();

                int llave = 0;
                int control_tv = 0;
                int control_air = 0;
                int regalo = 0;

                if (cbLlave.IsChecked == true)
                {
                    llave = 1;
                }
                if (cbControlTv.IsChecked == true)
                {
                    control_tv = 1;
                }
                if (cbControlAir.IsChecked == true)
                {
                    control_air = 1;
                }
                if (cbRegalo.IsChecked == true)
                {
                    regalo = 1;
                }
                //oCheckBE.TipoCheck = cbxTipoCheck.SelectedIndex.ToString();
                //oCheckBE.EntregaLlave = llave.ToString();
                //oCheckBE.EntregaControlTv = control_tv.ToString();
                //oCheckBE.EntregaControlAir = control_air.ToString();
                //oCheckBE.RecibeRegalo = regalo.ToString();
                //oCheckBE.Reserva.IdReserva = idReserva;

                oCheckBE = new CheckListBE(cbxTipoCheck.SelectedIndex.ToString(), 
                    llave.ToString(),
                    control_tv.ToString(),
                    control_air.ToString(),
                    regalo.ToString(),
                    idReserva);
                string resultado = oCheckDL.AgregarCheckList(oCheckBE);
                if (resultado.Equals("0"))
                {
                    FormSuccess form = new FormSuccess();
                    form.lblMensaje.Content = "Agrego con éxito";
                    form.Show();
                    ListaCheck(idReserva);
                }
                else {
                    FormError formError = new FormError();
                    formError.lblMensaje.Content = "No se pudo agregar";
                    formError.Show();
                }
                
            }
            catch (Exception ex)
            {
                FormError formError = new FormError();
                formError.lblMensaje.Content = $"Error: {ex.Message}";
                formError.Show();

            }
        }
    }
}
