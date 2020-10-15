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
    /// Lógica de interacción para Multa.xaml
    /// </summary>
    public partial class Multa : Window
    {

        MultaBL oMultaBL;
        CheckListMultaBE oCheckMultaBE;
        MultaBE oMultaBE;
        private int id_check_list;
        public Multa()
        {
            InitializeComponent();
        }
        public Multa(CheckListBE checkTemp, string rut, int id_Check)
        {
            InitializeComponent();
            txtRutUsuario.Text = rut;
            id_check_list = id_Check;
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
            oMultaBL = new MultaBL();
            oMultaBE = new MultaBE();
            oCheckMultaBE = new CheckListMultaBE();

            oMultaBE.DescripcionMulta = txtDescripcion.Text;
            oMultaBE.ValorMulta = int.Parse(txtValorMulta.Text);
            oCheckMultaBE.ComentarioUsuario = txtComentario.Text;
            oCheckMultaBE.CheckList.IdCheckIn = id_check_list;

            oMultaBL.AgregarMulta(oMultaBE, oCheckMultaBE);

            MessageBox.Show("agregado", "Mensaje",MessageBoxButton.OK,MessageBoxImage.Question);
            
            



        }

        private void txtDescripcion_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }

    
    }

