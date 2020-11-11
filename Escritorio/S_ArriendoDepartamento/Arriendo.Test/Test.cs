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
                Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();

                object oMissing = System.Reflection.Missing.Value;
                word.Visible = false;
                word.ScreenUpdating = false;

                FileInfo wordFile = new FileInfo("C:\\xampp\\htdocs\\prueba.docx");
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
    }
}
