using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Arriendo.Negocio
{
    public class CorreoBL
    {
        public static string EnviarCorreo(
      string para,
      string correoCliente,
      string asunto,
      //string Ruta,
      string html,
      string correoClave,
      string Port,
      string Host)
        {
            MailMessage message = new MailMessage();
            string addresses = para;
            message.To.Add(addresses);
            message.From = new MailAddress(correoCliente,"Equipo Turismo Real", System.Text.Encoding.UTF8);
            message.Subject = asunto;
            message.SubjectEncoding = Encoding.UTF8;

            message.Body = "";
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = false;

            AlternateView htmlView =
               AlternateView.CreateAlternateViewFromString(html,
                                       Encoding.UTF8,
                                       MediaTypeNames.Text.Html);
            message.AlternateViews.Add(htmlView);

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Credentials = (ICredentialsByHost)new NetworkCredential(correoCliente, correoClave);
            smtpClient.Port = Conversions.ToInteger(Port);
            smtpClient.EnableSsl = true;
            smtpClient.Host = Host;
            string str5;
            try
            {
                smtpClient.Send(message);
                str5 = Conversions.ToString(1);
            }
            catch (SmtpException ex)
            {
                ProjectData.SetProjectError((Exception)ex);
                str5 = ex.ToString();
                ProjectData.ClearProjectError();
            }
            return str5;
        }

        public static string rellenaCerosIzquierda(string Valor, int largo)
        {
            while (Strings.Len(Valor) < largo && (uint)Strings.Len(Conversions.ToDouble(Valor) < (double)largo) > 0U)
                Valor = "0" + Valor;
            return Valor;
        }

        public static string Html(string rut)
        {
            try
            {
                string html = "";

                html = "<!DOCTYPE html>" +
             "<html lang='es'>" +
                    "<head>" +
                        "<meta charset='utf-8'>" +
                        "<title>Turismo Real</title>" +
                    "</head>" +
                "<body>" +
                    "<table style='max-width: 600px; padding: 10px; margin:0 auto; border-collapse: collapse;' >" +
                        "<tr>" +
                            "<td style='padding: 0;background-color: #ecf0f1'>" +
                                "<center>" +
                                    "<img style='padding: 0; display: block' src='" + "http://imgfz.com/i/QZqeADH.png" + "' width='70%'>" +
                                "</center>" +
                            "</td>" +
                        "</tr>" +

                        "<tr>" +
                            "<td style='background-color: #ecf0f1'>" +
                                "<div style='color: #34495e; margin: 4% 10% 2%; text-align: justify;font-family: sans-serif'>" +

                                   // "<center><h2 style='color: #000080; margin: 0 0 7px'>Te damos la Bienvenida</h2>" +
                                        "<p style='margin: 2px; font-size: 15px;color: #084B8A' >" +
                                        " Estimados, <br><br>" +
                                        $"Por favor generar una nueva contraseña para mi usuario con rut {rut}."+ "<br><br>" +
                                        "Gracias<br></center>" +




                                    "<p style='color: #b3b3b3; font-size: 12px; text-align: center;margin: 30px 0 0'>Turismo real " + DateTime.Now.ToString("yyyy") + "</p>" +

                                "</div>" +

                            "</td>" +
                        "</tr>" +
                    "</table>" +
                //< !--hasta aquí-- >                                  
                "</body>" +
             "</html>";

                return html;
            }
            catch (Exception ex)
            {
               
                return "";
            }

        }

    }
}
