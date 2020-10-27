using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
      string mensaje,
      string correoClave,
      string Port,
      string Host)
        {
            MailMessage message = new MailMessage();
            string addresses = para;
            message.To.Add(addresses);
          
            message.Subject = asunto;
            message.SubjectEncoding = Encoding.UTF8;
            message.Body = mensaje;
            message.BodyEncoding = Encoding.UTF8;
            message.From = new MailAddress(correoCliente);
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
    }
}
