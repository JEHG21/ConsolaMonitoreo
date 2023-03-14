using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaMonitoreo
{
    public class ServiceEmail
    {
        public static void SendMail(string msg)
        {
            string emailAlert = ConfigurationManager.AppSettings["EmailAlert"];
            string emailFrom = ConfigurationManager.AppSettings["EmailFrom"];
            string subjectEmail = ConfigurationManager.AppSettings["EmailSubject"];

            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigurationManager.AppSettings["EmailHost"];
            smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["EmailPort"]);
            smtp.Timeout = Convert.ToInt32(ConfigurationManager.AppSettings["EmailTimeout"]);

            MailMessage mail = new MailMessage(emailFrom, emailAlert, subjectEmail, msg);
            mail.IsBodyHtml = true;

            try
            {
                smtp.Send(mail);

                Console.WriteLine("SmtpBAM - Alerta enviada con éxito");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SmtpBAM - Error en el envío de alerta - {ex.Message}");
            }
        }
    }
}
