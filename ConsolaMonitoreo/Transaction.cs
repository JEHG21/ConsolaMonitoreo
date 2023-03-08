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
        public int ThreadNum { get; set; }

        public string GetTokenTransactionRequest { get; set; }
        public string GetTokenTransactionResponse { get; set; }
        public bool GetTokenTransactionResponseStatus { get; set; }
        public long GetTokenTransactionElapsedMilliseconds { get; set; }
        public string GetTokenTransactionStackTrace { get; set; }

        public string SendTokenTransactionRequest { get; set; }
        public string SendTokenTransactionResponse { get; set; }
        public bool SendTokenTransactionResponseStatus { get; set; }
        public long SendTokenTransactionElapsedMilliseconds { get; set; }
        public string SendTokenTransactionStackTrace { get; set; }

        public string ValidateTokenTransactionRequest { get; set; }
        public string ValidateTokenTransactionResponse { get; set; }
        public bool ValidateTokenTransactionResponseStatus { get; set; }
        public long ValidateTokenTransactionElapsedMilliseconds { get; set; }
        public string ValidateTokenTransactionStackTrace { get; set; }

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

        public string GenerateTokenRequest { get; set; }
        public string GenerateTokenResponse { get; set; }
        public bool GenerateTokenResponseStatus { get; set; }
        public long GenerateTokenElapsedMilliseconds { get; set; }
        public string GenerateTokenStackTrace { get; set; }

        public string GenerateSecretStringRequest { get; set; }
        public string GenerateSecretStringResponse { get; set; }
        public bool GenerateSecretStringResponseStatus { get; set; }
        public long GenerateSecretStringElapsedMilliseconds { get; set; }
        public string GenerateSecretStringStackTrace { get; set; }

        public string UserLoginRequest { get; set; }
        public string UserLoginResponse { get; set; }
        public bool UserLoginResponseStatus { get; set; }
        public long UserLoginElapsedMilliseconds { get; set; }
        public string UserLoginStackTrace { get; set; }

        public string ValidateFacephiRequest { get; set; }
        public string ValidateFacephiResponse { get; set; }
        public bool ValidateFacephiResponseStatus { get; set; }
        public long ValidateFacephiElapsedMilliseconds { get; set; }
        public string ValidateFacephiStackTrace { get; set; }

        public string TransactionStackTrace { get; set; }
    }
}
