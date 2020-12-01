using Arriendo.Negocio;
using Arriendo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Office.Interop.Word;
using System.Diagnostics;
using Word = Microsoft.Office.Interop.Word;
using Arriendo.Datos.Conexion;

namespace Arriendo.Test
{
    class Test
    {
        //static RegionDA regionDa;
        static ComunaBL comunaDL;
        static UsuarioBL usuarioBL;
        //static ProvinciaDA provinciaDa;
        static List<ComunaBE> listComuna;
        static List<UsuarioBE> listUsuario;
        static void Main(string[] args)
        {
            try
            {
                CrearPDF();
                //ListaComunaId();
                //LoginUsuario();
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("error : " + ex.Message);
                Console.ReadKey();
            }
           
        }

        private static void ListaComunaId()
        {
            ConexionDA.GetConexion();
            comunaDL = new ComunaBL();
            listComuna = new List<ComunaBE>();
            int idComuna = 338;
            listComuna = comunaDL.ListarComunaPorId(idComuna);

            foreach (ComunaBE item in listComuna.ToList())
            {
                Console.WriteLine("Id COmuna : " + item.IdComuna);
                Console.WriteLine("Nombre COmuna : " + item.NombreComuna);
                Console.WriteLine("Id Provincia : " + item.Provincia.IdProvincia);
                Console.WriteLine("-------------------------------------------");
            }
            
        }

        private static void LoginUsuario() {
            usuarioBL = new UsuarioBL();
            listUsuario = new List<UsuarioBE>();
            listUsuario = usuarioBL.ListarUsuarios();

            foreach (UsuarioBE item in listUsuario.ToList())
            {
                Console.WriteLine("-----------------Usuarios--------------------------");
                Console.WriteLine("Rut : " + item.RutUsuario);
                Console.WriteLine("Dv : " + item.DvUsuario);
                Console.WriteLine("Nombre : " + item.NombreUsuario);
                Console.WriteLine("-------------------------------------------");
            }
        }

        private static void CrearPDF() {

            try
            {
                CrearWord();
                Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();

                object oMissing = System.Reflection.Missing.Value;
                word.Visible = false;
                word.ScreenUpdating = false;

                FileInfo wordFile = new FileInfo("C:\\Users\\juanc\\projects\\Portafolio\\Escritorio\\S_ArriendoDepartamento\\Arriendo.Test\\plantilla\\WordGenerado.docx");
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
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            

        }

        private static bool CrearWord() {
            try
            {
               

                object ObjMiss = System.Reflection.Missing.Value;
                Word.Application ObjWord = new Word.Application();

                object parametro = "C:\\xampp\\htdocs\\plantilla.docx";
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
                rutClient.Text = "23210664-6";
                Word.Range nombreClient = ObjDoc.Bookmarks.get_Item(ref nombreCliente).Range;
                nombreClient.Text = "Juan Colonia";
                Word.Range telefonoClient = ObjDoc.Bookmarks.get_Item(ref telefonoCliente).Range;
                telefonoClient.Text = "965845162";
                Word.Range servicioExtr = ObjDoc.Bookmarks.get_Item(ref servicioExtra).Range;
                servicioExtr.Text = "Si";
                Word.Range fechaCheckI = ObjDoc.Bookmarks.get_Item(ref fechaCheckIn).Range;
                fechaCheckI.Text = "15-11-2020";
                Word.Range fechaCheckOu = ObjDoc.Bookmarks.get_Item(ref fechaCheckOut).Range;
                fechaCheckOu.Text = "19-11-2020";

                Word.Range nombreDe = ObjDoc.Bookmarks.get_Item(ref nombreDep).Range;
                nombreDe.Text = "departamento 1";
                Word.Range direccionDe = ObjDoc.Bookmarks.get_Item(ref direccionDep).Range;
                direccionDe.Text = "av siempre viva 123";
                Word.Range cantBanio = ObjDoc.Bookmarks.get_Item(ref cantBanios).Range;
                cantBanio.Text = "2";
                Word.Range cantHuespe = ObjDoc.Bookmarks.get_Item(ref cantHuesped).Range;
                cantHuespe.Text = "3";
                Word.Range cantHabitacio = ObjDoc.Bookmarks.get_Item(ref cantHabitacion).Range;
                cantHabitacio.Text = "3";

                Word.Range entregaT = ObjDoc.Bookmarks.get_Item(ref entregaTv).Range;
                entregaT.Text = "Si";
                Word.Range entregaAi = ObjDoc.Bookmarks.get_Item(ref entregaAir).Range;
                entregaAi.Text = "Si";
                Word.Range entregaLlav = ObjDoc.Bookmarks.get_Item(ref entregaLlave).Range;
                entregaAi.Text = "Si";
                Word.Range entregaRegal = ObjDoc.Bookmarks.get_Item(ref entregaRegalo).Range;
                entregaRegal.Text = "Si";
                Word.Range valorTota = ObjDoc.Bookmarks.get_Item(ref valorTotal).Range;
                valorTota.Text = "59.990";

               
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

                string RutaSave = "C:\\Users\\juanc\\projects\\Portafolio\\Escritorio\\S_ArriendoDepartamento\\Arriendo.Test\\plantilla\\";
                
                object FileName = (object)(RutaSave + "WordGenerado");
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
    }
}
