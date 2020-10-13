using Arriendo.Entidades;
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
        public Multa()
        {
            InitializeComponent();
        }
        public Multa(CheckListBE checkTemp,string rut)
        {
            InitializeComponent();
            txtRutUsuario.Text = rut;
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

        }
    }
}
