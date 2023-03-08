//using ConsolaMonitoreo._bimovilDesaV2;
//using ConsolaMonitoreo._BiMovilProduccionV3;
using ConsolaMonitoreo.desarrollo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaMonitoreo
{
    public class ServiceBIMovil
    {
        public static void SendBiMovil(string msg) 
        {
            string biMovilUsername = ConfigurationManager.AppSettings["BMUsername"];
            string biMovilPassword = ConfigurationManager.AppSettings["BMPassword"];
            string emailAlert = ConfigurationManager.AppSettings["EmailAlert"];
            string telSms = ConfigurationManager.AppSettings["TelSMS"];
            string deliveryAlertBI = ConfigurationManager.AppSettings["DeliveryAlertBI"];
            DataTable result = new DataTable();
            Mensajes_Tokens biMovil = new Mensajes_Tokens();

            try
            {
                //Validamos por cual medio enviaremos la alerta de BI
                if (deliveryAlertBI.Equals("1")) //1 = SMS, 2 = Email
                {
                    result = biMovil.Envia_Mensaje(biMovilUsername, biMovilPassword, telSms, "C", msg, "|1", "14", "19");
                }
                else
                {
                    result = biMovil.envia_mensaje_email(biMovilUsername, biMovilPassword, emailAlert, msg, "1", "1", "gt", "1", "2");
                }

                if (result.Rows.Count > 0)
                {
                    int status = Convert.ToInt32(result.Rows[0][0]);

                    if (status == 0)
                    {
                        Console.WriteLine("BiMovil - Alerta enviada con éxito");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"BiMovil - Error en el envío de alerta - {ex.Message}");
            }
        }
    }
}
