﻿using Arriendo.Entidades;
using Arriendo.Entidades.Enumerador;
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
        
        CheckListBL oCheckDL;
        List<CheckListBE> oListcheck;
        CheckListBE oCheckBE;
        CheckListBE checktemp;
        private int idReserva;
        private int id_Check;
        public CheckList()
        {
            InitializeComponent();
            //ListaComunaId();

        }
        public CheckList(int Idreserva, string usuario)
        {
            InitializeComponent();
            //ListaComunaId();
            btnEliminar.IsEnabled = false;
            btnRegistrarMulta.IsEnabled = false;
            txtRutUsuario.IsEnabled = false;
            lblUsuario.Content = Login.oUsuarioBE.NombreUsuario + " " + Login.oUsuarioBE.ApellidosUsuario;
            txtRutUsuario.Text = usuario;
            ListaCheck(Idreserva);
            idReserva = Idreserva;
            cbxTipoCheck.ItemsSource = Enum.GetValues(typeof(TipoCheck));
           
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
            string rut = txtRutUsuario.Text;
            
            Multa formMulta = new Multa(checktemp, rut,id_Check);
            this.Close();
            formMulta.ShowDialog();


        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {

            cbControlAir.IsChecked = false;
            cbControlTv.IsChecked = false;
            cbLlave.IsChecked = false;
            cbRegalo.IsChecked = false;
            cbxTipoCheck.SelectedIndex = 0;
            btnAceptar.IsEnabled = true;
            btnRegistrarMulta.IsEnabled = false;
            btnEliminar.IsEnabled = false;
            ListaCheck(idReserva);


        }


        private void GvcheckList_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                oListcheck = new List<CheckListBE>();
                CheckListBE oCheck = new CheckListBE();
            oCheck = (CheckListBE)((DataGrid)sender).CurrentItem;
            foreach (CheckListBE item in ((List<CheckListBE>)((DataGrid)sender).ItemsSource).ToList())
            {
                oCheckBE = new CheckListBE();
                oCheckBE = item;
                if (item.IdCheckIn.Equals(oCheck.IdCheckIn) && item.TipoCheck.Equals("Check Out"))
                {
                    oCheckBE.IsSelected = true;
                        btnEliminar.IsEnabled = true;
                        btnRegistrarMulta.IsEnabled = true;
                        id_Check = item.IdCheckIn;
                        cbxTipoCheck.SelectedIndex = 0;
                        btnAceptar.IsEnabled = false;
                        if (oCheck.EntregaLlave.Equals("Si"))
                        {
                            cbLlave.IsChecked = true;
                        }
                        if (oCheck.EntregaControlAir.Equals("Si"))
                            {
                            cbControlAir.IsChecked = true;
                        }
                        if (oCheck.EntregaControlTv.Equals("Si"))
                        {
                            cbControlTv.IsChecked = true;
                        }
                        if (oCheck.RecibeRegalo.Equals("Si"))
                        {

                            cbRegalo.IsChecked = true;

                        }


                    }
                else
                {
                        if (item.IdCheckIn.Equals(oCheck.IdCheckIn) && item.TipoCheck.Equals("Check In"))
                        {
                            oCheckBE.IsSelected = true;
                            btnEliminar.IsEnabled = true;
                            btnRegistrarMulta.IsEnabled = false;
                            cbxTipoCheck.SelectedIndex = 0;

                            if (oCheck.EntregaLlave.Equals("Si"))
                            {
                                cbLlave.IsChecked = true;
                            }
                            if (oCheck.EntregaControlAir.Equals("Si"))
                            {
                                cbControlAir.IsChecked = true;
                            }
                            if (oCheck.EntregaControlTv.Equals("Si"))
                            {
                                cbControlTv.IsChecked = true;
                            }
                            if (oCheck.RecibeRegalo.Equals("Si"))
                            {

                                cbRegalo.IsChecked = true;

                            }
                        }
                    }
                   
                oListcheck.Add(oCheckBE);
                    checktemp = new CheckListBE();
                    checktemp.EntregaControlTv = oCheckBE.EntregaControlTv;
                    checktemp.EntregaControlAir = oCheckBE.EntregaControlAir;
                    checktemp.EntregaLlave = oCheckBE.EntregaLlave;
                    
            }



                ((DataGrid)sender).ItemsSource = oListcheck;



        }
            catch (Exception)
            {

            }
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

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            oCheckDL = new CheckListBL();
            oCheckBE = new CheckListBE();

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
            oCheckBE.TipoCheck = cbxTipoCheck.SelectedIndex.ToString();
            oCheckBE.EntregaLlave = llave.ToString();
            oCheckBE.EntregaControlTv = control_tv.ToString();
            oCheckBE.EntregaControlAir = control_air.ToString();
            oCheckBE.RecibeRegalo = regalo.ToString();
            oCheckBE.Reserva.IdReserva = idReserva;

            oCheckDL.AgregarCheckList(oCheckBE);
            cbControlAir.IsChecked = false;
            cbControlTv.IsChecked = false;
            cbLlave.IsChecked = false;
            cbRegalo.IsChecked = false;
            ListaCheck(idReserva);
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            oCheckDL = new CheckListBL();
            oCheckBE = new CheckListBE();

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
            oCheckBE.IdCheckIn = id_Check;
            oCheckBE.TipoCheck = cbxTipoCheck.SelectedIndex.ToString();
            oCheckBE.EntregaLlave = llave.ToString();
            oCheckBE.EntregaControlTv = control_tv.ToString();
            oCheckBE.EntregaControlAir = control_air.ToString();
            oCheckBE.RecibeRegalo = regalo.ToString();
           

            oCheckDL.actualizarCheckList(oCheckBE);
            cbControlAir.IsChecked = false;
            cbControlTv.IsChecked = false;
            cbLlave.IsChecked = false;
            cbRegalo.IsChecked = false;
            ListaCheck(idReserva);

        }

       private void btnEditar_Click(object sender, RoutedEventArgs e)
        {

        }
    }


}
