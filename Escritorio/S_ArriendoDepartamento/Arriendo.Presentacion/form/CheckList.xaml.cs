using Arriendo.Entidades;
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
    /// Lógica de interacción para CheckList.xaml
    /// </summary>
    public partial class CheckList : Window
    {
        ComunaBL oComunaDL;
        List<ComunaBE> oListComuna;
        CheckListBL oCheckDL;
        List<CheckListBE> oListcheck;
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
                oListcheck = new List<CheckListBE>();
              

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
    }
}
