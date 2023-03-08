using FileHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsolaMonitoreo
{
    [DelimitedRecord("|")]
    public class User
    {
        public string Username;
        public string Channel;
        public string Country;
        public string TokenType;
        public string Phone;
        public string TransactionID;
    }
}
