using Arriendo.Entidades;
using Arriendo.Negocio;
using Arriendo.Presentacion.form_mensaje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        private int id_multa;
        List<MultaBE> oListcheck;
        MultaBE checktemp;
        ReservaBE reservaTemp;





        public Multa()
        {
            InitializeComponent();
        }
        public Multa(CheckListBE checkTemp, ReservaBE reservaTempo)
        {
            InitializeComponent();
            reservaTemp = reservaTempo;
            txtRutUsuario.Text = reservaTempo.Usuario.RutUsuario;
            btnEditar.IsEnabled = false;
            SnackbarError.Visibility = Visibility.Visible;
            SnackbarCorrecto.Visibility = Visibility.Visible;

            id_check_list = checkTemp.IdCheckIn;
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
            
            ListaCheck(id_check_list);
        }
        private void Btn_Salir_Click(object sender, RoutedEventArgs e)
        {
            CheckList form = new CheckList(reservaTemp);
            this.Close();
            form.ShowDialog();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private async void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            Task<bool> taskmensaje = new Task<bool>(CorreoBL.TimeMensaje);
            try
            {
                oMultaBL = new MultaBL();
                oMultaBE = new MultaBE();
                oCheckMultaBE = new CheckListMultaBE();

                if (txtValorMulta.Text.Trim().Length.Equals(0)) {
                    txtValorMulta.Focus();
                    throw new Exception("Ingrese el valor de la multa");
                }
                if (!IsNumerico(txtValorMulta.Text))
                {
                    txtValorMulta.Focus();
                    throw new Exception("El valor de la multa debe ser numérico");
                }

                oMultaBE.DescripcionMulta = txtDescripcion.Text;
                oMultaBE.ValorMulta = int.Parse(txtValorMulta.Text);
                oCheckMultaBE.ComentarioUsuario = txtComentario.Text;
                oCheckMultaBE.CheckList.IdCheckIn = id_check_list;
                btnAceptar.IsEnabled = false;
                SnackbarCorrecto.IsActive = true;
                SnackbarCorrecto.Message.Content = "Se esta registrando la multa...";
                taskmensaje.Start();
                bool respp = await taskmensaje;
                taskmensaje = new Task<bool>(CorreoBL.TimeMensaje);

                if (oMultaBL.AgregarMulta(oMultaBE, oCheckMultaBE))
                {

            
                    txtComentario.Text = "";
                    txtValorMulta.Text = "0";
                    ListaCheck(id_check_list);
                    Limpiar();
                    SnackbarCorrecto.IsActive = true;
                    SnackbarCorrecto.Message.Content = "Se registro correctamente la multa";
                    taskmensaje.Start();
                    bool resp = await taskmensaje;
                    if (resp)
                    {
                        SnackbarCorrecto.IsActive = false;
                    }



                }
                else {
                    SnackbarCorrecto.IsActive = false;
                    SnackbarError.IsActive = true;
                    SnackbarError.Message.Content = "Algo ocurrió, inténtelo más tarde ";
                    taskmensaje.Start();
                    bool resp = await taskmensaje;
                    if (resp)
                    {
                        SnackbarError.IsActive = false;
                    }
             
                }

              
            }
            catch (Exception ex)
            {
                SnackbarCorrecto.IsActive = false;
                SnackbarError.IsActive = true;
                SnackbarError.Message.Content = ex.Message;
                taskmensaje.Start();
                bool resp = await taskmensaje;
                if (resp)
                {
                    SnackbarError.IsActive = false;
                }

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

        private void ListaCheck(int id_check_list)
        {
            try
            {

                var oListcheck = oMultaBL.ListarMulta(id_check_list);
                gvCheckList.ItemsSource = oListcheck;

            }
            catch
            {

                gvCheckList.ItemsSource = null;
            }

        }

     
        private void gvCheckList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        private void Limpiar()
        {
            txtComentario.Text = "-";
            txtValorMulta.Text = "0";
            btnAceptar.IsEnabled = true;
            btnEditar.IsEnabled = false;
            ListaCheck(id_check_list);
            
        }

        int count = 0;
        private void GvcheckList_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {

                oListcheck = new List<MultaBE>();
                MultaBE oCheck = new MultaBE();
                oCheck = (MultaBE)((DataGrid)sender).CurrentItem;
                var columna = ((DataGrid)sender).CurrentColumn.Header;
                
                foreach (MultaBE item in ((List<MultaBE>)((DataGrid)sender).ItemsSource).ToList())
                {
                    btnAceptar.IsEnabled = false;
                    oMultaBE = new MultaBE();
                    oMultaBE = item;
                    oMultaBE.IsSelected = false;
                    if (item.IdMulta.Equals(oCheck.IdMulta))
                    {
                        oMultaBE.IsSelected = true;
                      
                        btnEditar.IsEnabled = true;

                        txtValorMulta.Text = oCheck.ValorMulta.ToString();
                        txtDescripcion.Text = oCheck.DescripcionMulta;
                        txtComentario.Text = oCheck.Comentario;
                        id_multa = oCheck.IdMulta;

                        btnAceptar.IsEnabled = false;
                    }

                    oListcheck.Add(oMultaBE);
                   
                }
                btnEditar.IsEnabled = true;
                ((DataGrid)sender).ItemsSource = oListcheck;
                if (columna.Equals(" "))
                {
                    if (count < 1)
                    {
                        BtnEliminar_Click(sender, null);
                        count++;
                    }
                    else
                    {
                        count = 0;
                    }


                }
               

            }
            catch (Exception ex)
            {

            }
        }

        private async void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Task<bool> taskmensaje = new Task<bool>(CorreoBL.TimeMensaje);
            try
            {
                bool? resultado = this.DialogResult;
                FormAdvertencia form = new FormAdvertencia();
                resultado = form.ShowDialog();
                if (resultado == true)
                {
                    //Eliminar
                    //capturo el ID
                    var obj = (MultaBE)((DataGrid)sender).CurrentItem;


                    if (oMultaBL.EliminarMulta(id_check_list, id_multa))
                    {
                      
                        ListaCheck(id_check_list);
                        Limpiar();
                        SnackbarCorrecto.IsActive = true;
                        SnackbarCorrecto.Message.Content = "Se elimino correctamente la multa";
                        taskmensaje.Start();
                        bool resp = await taskmensaje;
                        if (resp)
                        {
                            SnackbarCorrecto.IsActive = false;
                        }
                       
                    }
                }
                else
                {
                    form.Close();
                }
            }
            catch (Exception ex)
            {
                SnackbarCorrecto.IsActive = false;
                SnackbarError.IsActive = true;
                SnackbarError.Message.Content = ex.Message;
                taskmensaje.Start();
                bool resp = await taskmensaje;
                if (resp)
                {
                    SnackbarError.IsActive = false;
                }
            }
            
        }

        private async void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            Task<bool> taskmensaje = new Task<bool>(CorreoBL.TimeMensaje);
            try
            {
                oMultaBE = new MultaBE();


                oMultaBE.idCheck = id_check_list.ToString();
                oMultaBE.IdMulta = id_multa;
                oMultaBE.Comentario = txtComentario.Text;

                if (txtValorMulta.Text.Trim().Length.Equals(0))
                {
                    txtValorMulta.Focus();
                    throw new Exception("Ingrese el valor de la multa");
                }

                if (!IsNumerico(txtValorMulta.Text)) {
                    txtValorMulta.Focus();
                    throw new Exception("El valor de la multa debe ser numérico");
                }
                
                oMultaBE.ValorMulta = int.Parse(txtValorMulta.Text);
               
                oMultaBE.DescripcionMulta = txtDescripcion.Text;
                btnEditar.IsEnabled = false;
                SnackbarCorrecto.IsActive = true;
                SnackbarCorrecto.Message.Content = "Se esta modificando la multa...";
                taskmensaje.Start();
                bool respp = await taskmensaje;
                taskmensaje = new Task<bool>(CorreoBL.TimeMensaje);


                if (oMultaBL.actualizarMulta(oMultaBE))
                {
                    Limpiar();
                    SnackbarCorrecto.IsActive = true;
                    SnackbarCorrecto.Message.Content = "Se modificó correctamente la multa";
                    taskmensaje.Start();
                    bool resp = await taskmensaje;
                    if (resp)
                    {
                        SnackbarCorrecto.IsActive = false;
                    }

                }
                else
                {
                    SnackbarCorrecto.IsActive = false;
                    SnackbarError.IsActive = true;
                    SnackbarError.Message.Content = "Algo ocurrió, inténtelo más tarde ";
                    taskmensaje.Start();
                    bool resp = await taskmensaje;
                    if (resp)
                    {
                        SnackbarError.IsActive = false;

                    }
                }
            }
            catch (Exception ex)
            {
                SnackbarCorrecto.IsActive = false;
                SnackbarError.IsActive = true;
                SnackbarError.Message.Content = ex.Message;
                taskmensaje.Start();
                bool resp = await taskmensaje;
                if (resp)
                {
                    SnackbarError.IsActive = false;
                }
 
            }
        }

        private bool IsNumerico(string var1) {
            try
            {
                int numero = int.Parse(var1);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
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

        private void TxtValorMulta_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
                if (ascci >= 48 && ascci <= 57) e.Handled = false;
                else e.Handled = true;
            }
            catch (Exception)
            {
               
            }
        }
    }


}

