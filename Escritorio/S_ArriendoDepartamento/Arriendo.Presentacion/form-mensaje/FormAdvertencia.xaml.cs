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

namespace Arriendo.Presentacion.form_mensaje
{
    /// <summary>
    /// Lógica de interacción para FormAdvertencia.xaml
    /// </summary>
    public partial class FormAdvertencia : Window
    {
        public bool sioNo = false;
        public FormAdvertencia()
        {
            InitializeComponent();
            btnNo.Focus();
        }

        private void Btn_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public bool Respuesta() {
            try
            {
                return sioNo;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void BtnSi_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void BtnNo_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
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
