using DSNotification.Client;
using ServiceStack.Configuration;
using ServiceStack.Web;
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
            if (bool.Parse(ConfigurationManager.AppSettings["SendByDSNotification"]))
            {
                try
                {
                    DSNotificationClient ds = new DSNotificationClient(new DSNotificationConfig
                    {

                        ApiUri = ConfigurationManager.AppSettings["ApiUri"],
                        IgnoreSslErrors = bool.Parse(ConfigurationManager.AppSettings["IgnoreSslErrors"]),
                        UserName = ConfigurationManager.AppSettings["UserName"],
                        Password = ConfigurationManager.AppSettings["Password"]

                    });

                    var notiResponse = ds.SendNotification(new DSNotification.ServiceModel.NotificationService.SendMessage
                    {
                        CompanyId = 1,
                        Identificator = "TokenApi_ConsolaBam",
                        To = ConfigurationManager.AppSettings["EmailAlert"],
                        Dictionary = new Dictionary<string, object>
                         {
                         { "Text", msg }
                         }
                    });

                    Console.WriteLine("DSNotification - Alerta enviada con éxito");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"DSNotification - Error en el envío de alerta - {ex.Message}");
                }
            }
            else
            {
                try
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

                    Console.WriteLine("SmtpBAM - Alerta enviada con éxito");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"SmtpBAM - Error en el envío de alerta - {ex.Message}");
                }
            }
          

          
        }
    }
}
