using Arriendo.Entidades;
using Arriendo.Entidades.Enumerador;
using Arriendo.Negocio;
using Arriendo.Presentacion.form_mensaje;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Word = Microsoft.Office.Interop.Word;

namespace Arriendo.Presentacion.form
{
    /// <summary>
    /// Lógica de interacción para CheckList.xaml
    /// </summary>
    public partial class CheckList : System.Windows.Window
    {
        
        CheckListBL oCheckDL;
        List<CheckListBE> oListcheck;
        CheckListBE oCheckBE;
        CheckListBE checktemp;
        ReservaBE reservaTemp;
        ServicioExtraBL oServicioExtraBL;
        private int idReserva;
        private int id_Check;
        public CheckList()
        {
            InitializeComponent();
            //ListaComunaId();

        }
        public CheckList(ReservaBE reservaTempo)
        {
            InitializeComponent();
            SnackbarError.Visibility = Visibility.Visible;
            SnackbarCorrecto.Visibility = Visibility.Visible;
            oCheckDL = new CheckListBL();
            oServicioExtraBL = new ServicioExtraBL();
            reservaTemp = reservaTempo;
            btnEditar.IsEnabled = false;
            btnRegistrarMulta.IsEnabled = false;
            txtRutUsuario.IsEnabled = false;
            lblUsuario.Content = Login.oUsuarioBE.NombreUsuario + " " + Login.oUsuarioBE.ApellidosUsuario;
            txtRutUsuario.Text = reservaTemp.Usuario.RutUsuario;
            ListaCheck(reservaTemp.IdReserva);
            idReserva = reservaTemp.IdReserva;
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


        private void ListaCheck(int Idreserva)
        {
            try
            {
               // oCheckDL = new CheckListBL();
               
                var oListcheck = oCheckDL.ListarChecklist(Idreserva);
                btnAceptar.IsEnabled = true;

                if (oListcheck.Count > 0)
                {
                    oCheckBE = new CheckListBE();
                    oCheckBE = oListcheck.First();
                    switch (oCheckBE.TipoCheck)
                    {
                        case "Check In":
                            columnPdf.Visibility = Visibility.Visible;
                            break;
                        case "Check Out":
                            columnPdf.Visibility = Visibility.Collapsed;
                            break;

                    }
                    btnAceptar.IsEnabled = false;
                }
                else {
                    cbxTipoCheck.IsEnabled = false;
                }
                gvCheckList.ItemsSource = oListcheck;

            }
            catch {

                gvCheckList.ItemsSource = null;
            }

        }

        private void BtnRegistrarMulta_Click(object sender, RoutedEventArgs e)
        {
            string rut = txtRutUsuario.Text;
            
            Multa formMulta = new Multa(checktemp, reservaTemp);
            this.Close();
            formMulta.ShowDialog();


        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        private void Limpiar() {
            cbControlAir.IsChecked = false;
            cbControlTv.IsChecked = false;
            cbLlave.IsChecked = false;
            cbRegalo.IsChecked = false;
            cbxTipoCheck.SelectedIndex = 0;
            
            btnRegistrarMulta.IsEnabled = false;
            btnEditar.IsEnabled = false;
            ListaCheck(idReserva);
        }

        int count = 0;
        private void GvcheckList_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
               
                oListcheck = new List<CheckListBE>();
                CheckListBE oCheck = new CheckListBE();
                oCheck = (CheckListBE)((DataGrid)sender).CurrentItem;
                var columna = ((DataGrid)sender).CurrentColumn.Header;
                foreach (CheckListBE item in ((List<CheckListBE>)((DataGrid)sender).ItemsSource).ToList())
                {
                    btnAceptar.IsEnabled = false;
                    oCheckBE = new CheckListBE();
                    oCheckBE = item;
                    if (item.IdCheckIn.Equals(oCheck.IdCheckIn) )
                    {
                        oCheckBE.IsSelected = true;
                        btnEditar.IsEnabled = true;
                        btnRegistrarMulta.IsEnabled = true;
                        id_Check = item.IdCheckIn;
                        switch (item.TipoCheck)
                        {
                            case "Check In":
                                cbxTipoCheck.SelectedIndex = 0;
                                btnRegistrarMulta.IsEnabled = false;
                                cbRegalo.IsEnabled = true;
                                columnPdf.Visibility = Visibility.Visible;
                                break;
                            case "Check Out":
                                cbxTipoCheck.SelectedIndex = 1;
                                btnRegistrarMulta.IsEnabled = true;
                                cbRegalo.IsEnabled = false;
                                columnPdf.Visibility = Visibility.Collapsed;
                                break;

                        }
                      
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
                   
                    oListcheck.Add(oCheckBE);
                    checktemp = new CheckListBE();
                    checktemp = oCheckBE;
                    
                   


                }
                
                ((DataGrid)sender).ItemsSource = oListcheck;
                if (columna.Equals(" "))
                {
                    if (count < 1)
                    {
                        BtnPdf_Click(sender, null);
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

        private async void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            Task<bool> taskmensaje = new Task<bool>(CorreoBL.TimeMensaje);
            try
            {
                
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
                SnackbarCorrecto.IsActive = true;
                btnAceptar.IsEnabled = false;
                SnackbarCorrecto.Message.Content = "Se esta registrando el check-In...";
                taskmensaje.Start();
                bool respp = await taskmensaje;
                taskmensaje = new Task<bool>(CorreoBL.TimeMensaje);

                if (oCheckDL.AgregarCheckList(oCheckBE))
                {
                    Limpiar();
                    btnAceptar.IsEnabled = false;
                    cbxTipoCheck.IsEnabled = true;
                    SnackbarCorrecto.IsActive = true;
                    SnackbarCorrecto.Message.Content = "Se registro correctamente el check-In";
                    taskmensaje.Start();
                    bool resp = await taskmensaje;
                    if (resp)
                    {
                        SnackbarCorrecto.IsActive = false;
                    }
                   
                }
                else {
                    Limpiar();
                    SnackbarCorrecto.IsActive = false;
                    btnAceptar.IsEnabled = true;
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
                Limpiar();
                SnackbarCorrecto.IsActive = false;
                btnAceptar.IsEnabled = true;
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

                btnEditar.IsEnabled = false;
                SnackbarCorrecto.IsActive = true;
                SnackbarCorrecto.Message.Content = $"Se esta modificando el {cbxTipoCheck.SelectedValue.ToString()}...";
                taskmensaje.Start();
                bool respp = await taskmensaje;
                taskmensaje = new Task<bool>(CorreoBL.TimeMensaje);
                if (oCheckDL.actualizarCheckList(oCheckBE))
                {
                    Limpiar();
                    btnAceptar.IsEnabled = false;
                    SnackbarCorrecto.IsActive = true;
                    SnackbarCorrecto.Message.Content = "Se modificó correctamente el cheklist";
                    taskmensaje.Start();
                    bool resp = await taskmensaje;
                    if (resp)
                    {
                        SnackbarCorrecto.IsActive = false;
                    }
                }
                else
                {
                    Limpiar();
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
                Limpiar();
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

        private async void BtnPdf_Click(object sender, RoutedEventArgs e)
        {
            Task<bool> taskmensaje = new Task<bool>(CorreoBL.TimeMensaje);
            try
            {



                SnackbarCorrecto.IsActive = true;
                SnackbarCorrecto.Message.Content = "Espere unos segundos, estamos generando el PDF";
                taskmensaje.Start();
                bool resp = await taskmensaje;
                if (resp)
                {
                    SnackbarCorrecto.IsActive = false;
                }
                Task<bool> taskPDF = new Task<bool>(CrearPDF);
                taskPDF.Start();
                await taskPDF;
            }
            catch (Exception ex)
            {

              
            }
           
        }
        static string nombreDocumento = ConfigurationManager.AppSettings["NombreDocumento"];
        static string NombrePlantilla = ConfigurationManager.AppSettings["NombrePlantilla"];
        static string CarpetaPlantilla = ConfigurationManager.AppSettings["CarpetaPlantilla"];
        static string rutaCarpeta = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, CarpetaPlantilla);
        private bool CrearPDF()
        {

            try
            {
               
                rutaCarpeta = rutaCarpeta.Replace("\\bin\\Debug", "");

                CrearWord();
                Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();

                object oMissing = System.Reflection.Missing.Value;
                word.Visible = false;
                word.ScreenUpdating = false;

                FileInfo wordFile = new FileInfo(rutaCarpeta+ nombreDocumento);
                Object filename = (Object)wordFile.FullName;

                Microsoft.Office.Interop.Word.Document doc = word.Documents.Open(ref filename, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing, ref oMissing);
                doc.Activate();

                object outputFileName = wordFile.FullName.Replace(".docx", ".pdf");
                object fileFormat = WdSaveFormat.wdFormatPDF;

                // Save document into PDF Format
                doc.SaveAs(ref outputFileName,
                    ref fileFormat, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing, ref oMissing);

                object saveChanges = WdSaveOptions.wdDoNotSaveChanges;
                ((_Document)doc).Close(ref saveChanges, ref oMissing, ref oMissing);
                doc = null;


                ((_Application)word).Quit(ref oMissing, ref oMissing, ref oMissing);
                word = null;
                Process.Start(outputFileName.ToString());
                return true;
            }
            catch (Exception ex)
            {
                return true;
                throw new Exception(ex.Message);
            }

        }

        private bool CrearWord()
        {
            try
            {


                object ObjMiss = System.Reflection.Missing.Value;
                Word.Application ObjWord = new Word.Application();

                object parametro = rutaCarpeta + NombrePlantilla;
                //nombre de las variables del word
                object rutCliente = "rutCliente";
                object nombreCliente = "nombreCliente";
                object telefonoCliente = "telefonoCliente";
                object servicioExtra = "servicioExtra";
                object fechaCheckIn = "fechaCheckIn";
                object fechaCheckOut = "fechaCheckOut";
                object nombreDep = "nombreDep";
                object direccionDep = "direccionDep";
                object cantBanios = "cantBanios";
                object cantHuesped = "cantHuesped";
                object cantHabitacion = "cantHabitacion";
                object entregaTv = "entregaTv";
                object entregaAir = "entregaAir";
                object entregaLlave = "entregaLlave";
                object entregaRegalo = "entregaRegalo";
                object valorTotal = "valorTotal";

                Word.Document ObjDoc = ObjWord.Documents.Open(parametro, ObjMiss);
                Word.Range rutClient = ObjDoc.Bookmarks.get_Item(ref rutCliente).Range;
                rutClient.Text = $"{reservaTemp.Usuario.RutUsuario}-{reservaTemp.Usuario.DvUsuario}";
                Word.Range nombreClient = ObjDoc.Bookmarks.get_Item(ref nombreCliente).Range;
                nombreClient.Text = $"{reservaTemp.Usuario.NombreUsuario} {reservaTemp.Usuario.ApellidosUsuario}";
                Word.Range telefonoClient = ObjDoc.Bookmarks.get_Item(ref telefonoCliente).Range;
                telefonoClient.Text = reservaTemp.Usuario.TelefonoUsuario.ToString();
                Word.Range servicioExtr = ObjDoc.Bookmarks.get_Item(ref servicioExtra).Range;
                if (oServicioExtraBL.BuscarReserServExtPorReserID(reservaTemp.IdReserva))
                {
                    servicioExtr.Text = "Si";
                }
                else {
                    servicioExtr.Text = "No";
                }
               
                Word.Range fechaCheckI = ObjDoc.Bookmarks.get_Item(ref fechaCheckIn).Range;
                fechaCheckI.Text = reservaTemp.FechaEntrada;
                Word.Range fechaCheckOu = ObjDoc.Bookmarks.get_Item(ref fechaCheckOut).Range;
                fechaCheckOu.Text = reservaTemp.FechaSalida;

                Word.Range nombreDe = ObjDoc.Bookmarks.get_Item(ref nombreDep).Range;
                nombreDe.Text = reservaTemp.Propiedad.Nombre;
                Word.Range direccionDe = ObjDoc.Bookmarks.get_Item(ref direccionDep).Range;
                direccionDe.Text = reservaTemp.Propiedad.Direccion;
                Word.Range cantBanio = ObjDoc.Bookmarks.get_Item(ref cantBanios).Range;
                cantBanio.Text =reservaTemp.Propiedad.CantBanio.ToString();
                Word.Range cantHuespe = ObjDoc.Bookmarks.get_Item(ref cantHuesped).Range;
                cantHuespe.Text = reservaTemp.Propiedad.CantHuespedes.ToString();
                Word.Range cantHabitacio = ObjDoc.Bookmarks.get_Item(ref cantHabitacion).Range;
                cantHabitacio.Text = reservaTemp.Propiedad.CantHabitaciones.ToString();

                Word.Range entregaT = ObjDoc.Bookmarks.get_Item(ref entregaTv).Range;
                entregaT.Text = checktemp.EntregaControlTv;
                Word.Range entregaAi = ObjDoc.Bookmarks.get_Item(ref entregaAir).Range;
                entregaAi.Text = checktemp.EntregaControlAir;
                Word.Range entregaLlav = ObjDoc.Bookmarks.get_Item(ref entregaLlave).Range;
                entregaLlav.Text = checktemp.EntregaLlave;
                Word.Range entregaRegal = ObjDoc.Bookmarks.get_Item(ref entregaRegalo).Range;
                entregaRegal.Text = checktemp.RecibeRegalo;
                Word.Range valorTota = ObjDoc.Bookmarks.get_Item(ref valorTotal).Range;
                valorTota.Text = $"${reservaTemp.MontoTotal.ToString()}";


                object rangorutCliente = rutClient;
                object rangonombreCliente = nombreClient;
                object rangotelefonoCliente = telefonoClient;
                object rangoservicioExtra = servicioExtr;
                object rangofechaCheckIn = fechaCheckI;
                object rangofechaCheckOut = fechaCheckOu;
                object rangonombreDep = nombreDe;
                object rangodireccionDep = direccionDe;
                object rangocantBanios = cantBanio;
                object rangocantHuesped = cantHuespe;
                object rangocantHabitacion = cantHabitacio;
                object rangoentregaTv = entregaT;
                object rangoentregaAir = entregaAi;
                object rangoentregaLlave = entregaLlav;
                object rangoentregaRegalo = entregaRegal;
                object rangovalorTotal = valorTota;

                ObjDoc.Bookmarks.Add("rutCliente", ref rangorutCliente);
                ObjDoc.Bookmarks.Add("nombreCliente", ref rangonombreCliente);
                ObjDoc.Bookmarks.Add("telefonoCliente", ref rangotelefonoCliente);
                ObjDoc.Bookmarks.Add("servicioExtra", ref rangoservicioExtra);
                ObjDoc.Bookmarks.Add("fechaCheckIn", ref rangofechaCheckIn);
                ObjDoc.Bookmarks.Add("fechaCheckOut", ref rangofechaCheckOut);
                ObjDoc.Bookmarks.Add("nombreDep", ref rangonombreDep);
                ObjDoc.Bookmarks.Add("direccionDep", ref rangodireccionDep);
                ObjDoc.Bookmarks.Add("cantBanios", ref rangocantBanios);
                ObjDoc.Bookmarks.Add("cantHuesped", ref rangocantHuesped);
                ObjDoc.Bookmarks.Add("cantHabitacion", ref rangocantHabitacion);
                ObjDoc.Bookmarks.Add("entregaTv", ref rangoentregaTv);
                ObjDoc.Bookmarks.Add("entregaAir", ref rangoentregaAir);
                ObjDoc.Bookmarks.Add("entregaLlave", ref rangoentregaLlave);
                ObjDoc.Bookmarks.Add("entregaRegalo", ref rangoentregaRegalo);
                ObjDoc.Bookmarks.Add("valorTotal", ref rangovalorTotal);

                string RutaSave = rutaCarpeta;

                object FileName = (object)(RutaSave + nombreDocumento);
                Document document2 = ObjDoc;

                document2.SaveAs2(ref FileName);
                ObjWord.Documents.Close();
                ObjWord.Visible = false;
       
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void CbxTipoCheck_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxTipoCheck.SelectedValue.ToString().Equals("CheckOut")) {
                cbControlTv.IsChecked = false;
                cbControlAir.IsChecked = false;
                cbLlave.IsChecked = false;
            }
        }
    }


}
