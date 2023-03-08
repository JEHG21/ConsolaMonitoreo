using FileHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaMonitoreo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Request.AssignTokenType();
            Request.GetTokenType();
            Request.GenerateToken();
        }
    }
}
