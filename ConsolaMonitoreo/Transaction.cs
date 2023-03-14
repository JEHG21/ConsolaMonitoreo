using FileHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaMonitoreo
{
    [DelimitedRecord("|")]
    public class Transaction
    {
        public int Id { get; set; }
        public string Installation { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string TokenType { get; set; }
        public string TokenTypeValue { get; set; }
        public string Channel { get; set; }
        public string Country { get; set; }
        public string TelefonoDefault { get; set; }
        public string TelefonoBackup { get; set; }
        public string EmailDefault { get; set; }
        public string EmailBackup { get; set; }
        public string AccountNumber { get; set; }
        public string TelcommService { get; set; }
        public string TransactionId { get; set; }
        public string TransactionValue { get; set; }
        public string TransactionAmount { get; set; }
        public string TransactionDatetime { get; set; }
        public string TransactionIp { get; set; }
        public bool AddToWhiteList { get; set; }
        public string SuscriptionType { get; set; }
        public string BestImage { get; set; }
        public string TemplateRaw { get; set; }
        public string Dpi { get; set; }
        public string Token { get; set; }
        public string DeviceID { get; set; }
        public string Timestamp { get; set; }
        public string DeviceIdOneSignal { get; set; }
        public int ThreadNum { get; set; }

        public string AssignTokenTypeRequest { get; set; }
        public string AssignTokenTypeResponse { get; set; }
        public bool AssignTokenTypeResponseStatus { get; set; }
        public long AssignTokenTypeElapsedMilliseconds { get; set; }
        public string AssignTokenTypeStackTrace { get; set; }

        public string GetTokenTypeRequest { get; set; }
        public string GetTokenTypeResponse { get; set; }
        public bool GetTokenTypeResponseStatus { get; set; }
        public long GetTokenTypeElapsedMilliseconds { get; set; }
        public string GetTokenTypeStackTrace { get; set; }

        public string ValidateTokenRequest { get; set; }
        public string ValidateTokenResponse { get; set; }
        public bool ValidateTokenResponseStatus { get; set; }
        public long ValidateTokenElapsedMilliseconds { get; set; }
        public string ValidateTokenStackTrace { get; set; }

        public string ResyncDeviceRequest { get; set; }
        public string ResyncDeviceResponse { get; set; }
        public bool ResyncDeviceResponseStatus { get; set; }
        public long ResyncDeviceElapsedMilliseconds { get; set; }
        public string ResyncDeviceStackTrace { get; set; }

        public string TransactionStackTrace { get; set; }
    }
}
