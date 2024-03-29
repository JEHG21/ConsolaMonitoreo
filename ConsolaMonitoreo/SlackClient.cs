﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaMonitoreo
{
    public class Payload
    {
        public string channel { get; set; }
        public string text { get; set; }
    }

    public class SlackClient
    {
        private readonly string _uri;

        private RestClient _client;

        public SlackClient(string uri, string apiKey)
        {
            _uri = uri;
            _client = new RestClient(_uri);
            _client.AddDefaultHeaders(new Dictionary<string, string>
            {
                { "Accept", "application/json" },
                { "Authorization", "Bearer " + apiKey }
            });
        }

        public SlackClient(string uri)
        {
            _uri = uri;
            _client = new RestClient(_uri);
            _client.AddDefaultHeaders(new Dictionary<string, string>
            {
                { "Accept", "application/json" }
            });
        }

        public bool PostMessage(string text, string channel = null)
        {
            Payload payload = new Payload
            {
                channel = channel,
                text = text
            };

            return PostMessage(payload);
        }

        public bool PostMessage(Payload payload)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                var req = new RestRequest(_uri, Method.POST);
                req.AddJsonBody(payload);
                var res = _client.Execute(req);

                //Console.WriteLine(res.StatusCode.ToString());
                return true;
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
            }
            return false;
        }
    }
}
