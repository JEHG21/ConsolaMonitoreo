using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Diagnostics;

namespace ConsolaMonitoreo
{
    public class ServiceBIToken
    {
        public static HttpWebRequest CreateWebRequest()
        {
            HttpWebRequest webRequest = (HttpWebRequest)System.Net.WebRequest.Create(ConfigurationManager.AppSettings[("UrlCore")]);
            webRequest.Headers.Add(@"SOAP:Action");
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";

            return webRequest;
        }
        public static string ExecuteAssignTokenType(Transaction transaction)
        {
            var stopWatch = new Stopwatch();
            int responseTimeLimit = Convert.ToInt32(ConfigurationManager.AppSettings[("ResponseTimeLimit")]);
            long responseTime = 0;
            var request = (dynamic)null;

            try
            {
                stopWatch.Start();

                var xml = $@"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:tem=""http://tempuri.org/""><soapenv:Header/><soapenv:Body><tem:usr_AssignTokenType_c1><tem:installation>{transaction.Installation}</tem:installation><tem:username>{transaction.Username}</tem:username><tem:channel>{transaction.Channel}</tem:channel><tem:country>{transaction.Country}</tem:country><tem:token_type>{transaction.TokenType}</tem:token_type><tem:telephone_default>{transaction.TelefonoDefault}</tem:telephone_default><tem:telephone_backup>{transaction.TelefonoBackup}</tem:telephone_backup><tem:email_default>{transaction.EmailDefault}</tem:email_default><tem:email_backup>{transaction.EmailBackup}</tem:email_backup><tem:telcomm_service>{transaction.TelcommService}</tem:telcomm_service><tem:result_type>1</tem:result_type></tem:usr_AssignTokenType_c1></soapenv:Body></soapenv:Envelope>";
                transaction.AssignTokenTypeRequest = xml;
                request = CreateWebRequest();
                request.Timeout = responseTimeLimit;
                var soapEnvelopeXml = new XmlDocument();
                soapEnvelopeXml.LoadXml(xml);

                using (var stream = request.GetRequestStream())
                {
                    soapEnvelopeXml.Save(stream);
                }
                using (var response = request.GetResponse())
                {
                    using (var rd = new StreamReader(response.GetResponseStream()))
                    {
                        string soapResult = rd.ReadToEnd();
                        transaction.AssignTokenTypeResponse = soapResult;

                        var xdoc = XDocument.Parse(soapResult);
                        var node2 = xdoc.Descendants().Where(e => e.Name.LocalName == "usr_AssignTokenType_c1Result").Nodes();
                        var xNodes2 = node2 as IList<XNode> ?? node2.ToList();
                        if (xNodes2.Count > 0)
                        {
                            return xNodes2[0].ToString();
                        }
                    }
                }
            }
            catch (WebException e)
            {
                //Si el tiempo de respuesta excede el límite configurado, cancelamos la petición por time out
                if (e.Status == WebExceptionStatus.Timeout)
                {
                    if (request != null)
                    {
                        request.Abort();
                    }
                }

                stopWatch.Stop();
                responseTime = stopWatch.ElapsedMilliseconds;

                string msg = "Lentitud en el servicio BIToken - AssignTokenType - " + transaction.Username + " - Petición cancelada por TimeOut - " + responseTime + " ms - Server " + ConfigurationManager.AppSettings[("ServerOrigin")];

                Console.WriteLine(msg);

                //Enviamos alerta interna por medio de Slack
                Request.WebHookPostMessage(msg);

                //Enviamos alerta al banco por medio de BIMovil
                ServiceBIMovil.SendBiMovil(msg);

                transaction.AssignTokenTypeStackTrace = e.StackTrace;
            }

            return null;
        }

        public static string ExecuteGetTokenType(Transaction transaction)
        {
            var stopWatch = new Stopwatch();
            int responseTimeLimit = Convert.ToInt32(ConfigurationManager.AppSettings[("ResponseTimeLimit")]);
            long responseTime = 0;
            var request = (dynamic)null;

            try
            {
                stopWatch.Start();

                var xml = $@"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:tem=""http://tempuri.org/""><soapenv:Header/><soapenv:Body><tem:usr_GetTokenType_c1><tem:instalacion>{transaction.Installation}</tem:instalacion><tem:usuario>{transaction.Username}</tem:usuario><tem:canal>{transaction.Channel}</tem:canal><tem:pais>{transaction.Country}</tem:pais><tem:result_type>1</tem:result_type></tem:usr_GetTokenType_c1></soapenv:Body></soapenv:Envelope>";
                transaction.GetTokenTypeRequest = xml;
                request = CreateWebRequest();
                request.Timeout = responseTimeLimit;
                var soapEnvelopeXml = new XmlDocument();
                soapEnvelopeXml.LoadXml(xml);

                using (var stream = request.GetRequestStream())
                {
                    soapEnvelopeXml.Save(stream);
                }
                using (var response = request.GetResponse())
                {
                    using (var rd = new StreamReader(response.GetResponseStream()))
                    {
                        string soapResult = rd.ReadToEnd();
                        transaction.GetTokenTypeResponse = soapResult;

                        var xdoc = XDocument.Parse(soapResult);
                        var node2 = xdoc.Descendants().Where(e => e.Name.LocalName == "usr_GetTokenType_c1Result").Nodes();
                        var xNodes2 = node2 as IList<XNode> ?? node2.ToList();
                        if (xNodes2.Count > 0)
                        {
                            return xNodes2[0].ToString();
                        }
                    }
                }
            }
            catch (WebException e)
            {
                //Si el tiempo de respuesta excede el límite configurado, cancelamos la petición por time out
                if (e.Status == WebExceptionStatus.Timeout)
                {
                    if (request != null)
                    {
                        request.Abort();
                    }
                }

                stopWatch.Stop();
                responseTime = stopWatch.ElapsedMilliseconds;

                string msg = "Lentitud en el servicio BIToken - GetTokenType - " + transaction.Username + " - Petición cancelada por TimeOut - " + responseTime + " ms - Server " + ConfigurationManager.AppSettings[("ServerOrigin")];

                Console.WriteLine(msg);

                //Enviamos alerta interna por medio de Slack
                Request.WebHookPostMessage(msg);

                //Enviamos alerta al banco por medio de BIMovil
                ServiceBIMovil.SendBiMovil(msg);

                transaction.GetTokenTypeStackTrace = e.StackTrace;
            }

            return null;
        }

        public static string ExecuteGenerateToken(Transaction transaction)
        {
            var stopWatch = new Stopwatch();
            int responseTimeLimit = Convert.ToInt32(ConfigurationManager.AppSettings[("ResponseTimeLimit")]);
            long responseTime = 0;
            var request = (dynamic)null;

            try
            {
                stopWatch.Start();

                var xml = $@"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:tem=""http://tempuri.org/""><soapenv:Header/><soapenv:Body><tem:GenerateToken_with_TransactionId_TransactionAmount_TransactionValue_Ip_Datetime><tem:installation>{transaction.Installation}</tem:installation><tem:channel>{transaction.Channel}</tem:channel><tem:username>{transaction.Username}</tem:username><tem:country>{transaction.Country}</tem:country><tem:result_type>1</tem:result_type><tem:transaction_id>{transaction.TransactionId}</tem:transaction_id><tem:transaction_amount>{transaction.TransactionAmount}</tem:transaction_amount><tem:transaction_value>{transaction.TransactionValue}</tem:transaction_value><tem:ip>{transaction.TransactionIp}</tem:ip><tem:datetime>{transaction.TransactionDatetime}</tem:datetime></tem:GenerateToken_with_TransactionId_TransactionAmount_TransactionValue_Ip_Datetime></soapenv:Body></soapenv:Envelope>";
                transaction.GenerateTokenRequest = xml;
                request = CreateWebRequest();
                request.Timeout = responseTimeLimit;
                var soapEnvelopeXml = new XmlDocument();
                soapEnvelopeXml.LoadXml(xml);

                using (var stream = request.GetRequestStream())
                {
                    soapEnvelopeXml.Save(stream);
                }
                using (var response = request.GetResponse())
                {
                    using (var rd = new StreamReader(response.GetResponseStream()))
                    {
                        string soapResult = rd.ReadToEnd();
                        transaction.GenerateTokenResponse = soapResult;

                        var xdoc = XDocument.Parse(soapResult);
                        var node2 = xdoc.Descendants().Where(e => e.Name.LocalName == "GenerateToken_with_TransactionId_TransactionAmount_TransactionValue_Ip_DatetimeResult").Nodes();
                        var xNodes2 = node2 as IList<XNode> ?? node2.ToList();
                        if (xNodes2.Count > 0)
                        {
                            return xNodes2[0].ToString();
                        }
                    }
                }
            }
            catch (WebException e)
            {
                //Si el tiempo de respuesta excede el límite configurado, cancelamos la petición por time out
                if (e.Status == WebExceptionStatus.Timeout)
                {
                    if (request != null)
                    {
                        request.Abort();
                    }
                }

                stopWatch.Stop();
                responseTime = stopWatch.ElapsedMilliseconds;

                string msg = "Lentitud en el servicio BIToken - GenerateToken - " + transaction.Username + " - Petición cancelada por TimeOut - " + responseTime + " ms - Server " + ConfigurationManager.AppSettings[("ServerOrigin")];

                Console.WriteLine(msg);

                //Enviamos alerta interna por medio de Slack
                Request.WebHookPostMessage(msg);

                //Enviamos alerta al banco por medio de BIMovil
                ServiceBIMovil.SendBiMovil(msg);

                transaction.GenerateTokenStackTrace = e.StackTrace;
            }

            return null;
        }
    }
}
