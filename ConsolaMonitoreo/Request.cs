using FileHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaMonitoreo
{
    public class Request
    {
        public static void AssignTokenType()
        {
            var rnd = new Random();
            var dataList = new List<Transaction>();
            var engine = new FileHelperEngine<User>();
            var records = engine.ReadFile("datos.txt");

            int i = 0;
            foreach (var record in records)
            {
                var transaction = new Transaction
                {
                    Id = i + 1,
                    Installation = "0",
                    Username = record.Username,
                    Channel = record.Channel,
                    Country = record.Country,
                    TokenType = record.TokenType,
                    TelefonoDefault = record.Phone,
                    TelefonoBackup = "",
                    EmailDefault = "",
                    EmailBackup = "",
                    TelcommService = "C",
                };

                try
                {
                    dataList.Add(transaction);

                    var assignTokenType = ServiceBIToken.ExecuteAssignTokenType(transaction);

                    if (assignTokenType != null)
                    {
                        var response = JsonConvert.DeserializeObject<Response>(assignTokenType);

                        if (!response.errCode.Equals("204"))
                        {
                            string msg = "Respuesta no esperada - AssignTokenType - " + transaction.Username + " - Respuesta: " + response.errMsg.ToString() + " - Server " + ConfigurationManager.AppSettings[("ServerOrigin")];

                            Console.WriteLine(msg);

                            //Enviamos alerta interna por medio de Slack
                            WebHookPostMessage(msg);

                            //Enviamos alerta al banco por medio de BIMovil
                            ServiceBIMovil.SendBiMovil(msg);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"AssignTokenType - Error - {ex.Message}");
                }

                i++;
            }
        }

        public static void GetTokenType()
        {
            var rnd = new Random();
            var dataList = new List<Transaction>();
            var engine = new FileHelperEngine<User>();
            var records = engine.ReadFile("datos.txt");

            int i = 0;
            foreach (var record in records)
            {
                var transaction = new Transaction
                {
                    Id = i + 1,
                    Installation = "0",
                    Username = record.Username,
                    Channel = record.Channel,
                    Country = record.Country
                };

                try
                {
                    dataList.Add(transaction);

                    var getTokenType = ServiceBIToken.ExecuteGetTokenType(transaction);

                    if (getTokenType != null)
                    {
                        var response = JsonConvert.DeserializeObject<Response>(getTokenType);

                        if (!response.errCode.Equals("003"))
                        {
                            string msg = "Respuesta no esperada - GetTokenType - " + transaction.Username + " - Respuesta: " + response.errMsg.ToString() + " - Server " + ConfigurationManager.AppSettings[("ServerOrigin")];

                            Console.WriteLine(msg);

                            //Enviamos alerta interna por medio de Slack
                            WebHookPostMessage(msg);

                            //Enviamos alerta al banco por medio de BIMovil
                            ServiceBIMovil.SendBiMovil(msg);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"GetTokenType - Error - {ex.Message}");
                }

                i++;
            }
        }

        public static void GenerateToken()
        {
            var rnd = new Random();
            var dataList = new List<Transaction>();
            var engine = new FileHelperEngine<User>();
            var records = engine.ReadFile("datos.txt");

            int i = 0;
            foreach (var record in records)
            {
                var transaction = new Transaction
                {
                    Id = i + 1,
                    Installation = "0",
                    Channel = record.Channel,
                    Username = record.Username,
                    Country = record.Country,
                    TransactionId = record.TransactionID,
                    TransactionAmount = rnd.Next(100).ToString(),
                    TransactionValue = rnd.Next(100000, 999999).ToString(),
                    TransactionIp = rnd.Next(255) + "." + rnd.Next(255) + "." + rnd.Next(255) + "." + rnd.Next(255),
                    TransactionDatetime = DateTime.Now.ToString("dd-MM-yy HH:mm:ss")
                };

                try
                {
                    dataList.Add(transaction);

                    if (record.Country.Equals("1"))
                    {
                        var generateToken = ServiceBIToken.ExecuteGenerateToken(transaction);

                        if (generateToken != null)
                        {
                            var response = JsonConvert.DeserializeObject<Response>(generateToken);

                            if (response.errCode.Equals("200") || response.errCode.Equals("602"))
                            {

                            }
                            else
                            {
                                string msg = "Respuesta no esperada - GenerateToken - " + transaction.Username + " - Respuesta: " + response.errMsg.ToString() + " - Server " + ConfigurationManager.AppSettings[("ServerOrigin")];

                                Console.WriteLine(msg);

                                //Enviamos alerta interna por medio de Slack
                                WebHookPostMessage(msg);

                                //Enviamos alerta al banco por medio de BIMovil
                                ServiceBIMovil.SendBiMovil(msg);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"GenerateToken - Error - {ex.Message}");
                }

                i++;
            }
        }

        public static void WebHookPostMessage(string message)
        {
            var uri = ConfigurationManager.AppSettings[("WebHookUri")];

            var slackClient = new SlackClient(uri);

            try
            {
                var resp = slackClient.PostMessage(message);

                if (resp)
                {
                    Console.WriteLine("Slack - Alerta enviada con éxito");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Slack - Error en el envío de alerta - {ex.Message}");
            }

        }

        public static void ChatPostMessage(string message)
        {
            string channel = ConfigurationManager.AppSettings[("Channel")];

            var uri = ConfigurationManager.AppSettings[("ChatUri")];
            var apiKey = ConfigurationManager.AppSettings[("ApiKey")];

            var slackClient = new SlackClient(uri, apiKey);

            var resp = slackClient.PostMessage(message, channel);

            if (resp)
            {
                //Console.WriteLine("Mensaje enviado con exito");
            }

            //Console.ReadKey();
        }
    }
}
