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
        public CheckList()
        {
            InitializeComponent();
            ListaComunaId();
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

        private void ListaComunaId()
        {
            oComunaDL = new ComunaBL();
            oListComuna = new List<ComunaBE>();
            int idComuna = 338;
            oListComuna = oComunaDL.ListarComunaPorId(idComuna);

            gvCheckList.ItemsSource = oListComuna;
       

        }

        private void BtnRegistrarMulta_Click(object sender, RoutedEventArgs e)
        {
            Multa form = new Multa();
            this.Close();
            form.ShowDialog();
        }
    }
}
