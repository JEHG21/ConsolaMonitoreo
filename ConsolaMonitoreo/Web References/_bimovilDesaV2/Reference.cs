﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace ConsolaMonitoreo._bimovilDesaV2 {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    using System.Data;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="Mensajes_TokensSoap", Namespace="http://10.1.1.53/bimovil_tokens")]
    public partial class Mensajes_Tokens : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback Envia_MensajeOperationCompleted;
        
        private System.Threading.SendOrPostCallback Lista_OperadoresOperationCompleted;
        
        private System.Threading.SendOrPostCallback envia_mensaje_emailOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Mensajes_Tokens() {
            this.Url = global::ConsolaMonitoreo.Properties.Settings.Default.ConsolaMonitoreo__bimovilDesaV2_Mensajes_Tokens;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event Envia_MensajeCompletedEventHandler Envia_MensajeCompleted;
        
        /// <remarks/>
        public event Lista_OperadoresCompletedEventHandler Lista_OperadoresCompleted;
        
        /// <remarks/>
        public event envia_mensaje_emailCompletedEventHandler envia_mensaje_emailCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://10.1.1.53/bimovil_tokensX", RequestNamespace="http://10.1.1.53/bimovil_tokensX", ResponseNamespace="http://10.1.1.53/bimovil_tokensX", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataTable Envia_Mensaje(string User, string Pass, string Telefono_SMS, string Operador, string Mensaje_TXT, string Numero_Transaccion, string enmascarar_desde, string enmascarar_hasta) {
            object[] results = this.Invoke("Envia_Mensaje", new object[] {
                        User,
                        Pass,
                        Telefono_SMS,
                        Operador,
                        Mensaje_TXT,
                        Numero_Transaccion,
                        enmascarar_desde,
                        enmascarar_hasta});
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public void Envia_MensajeAsync(string User, string Pass, string Telefono_SMS, string Operador, string Mensaje_TXT, string Numero_Transaccion, string enmascarar_desde, string enmascarar_hasta) {
            this.Envia_MensajeAsync(User, Pass, Telefono_SMS, Operador, Mensaje_TXT, Numero_Transaccion, enmascarar_desde, enmascarar_hasta, null);
        }
        
        /// <remarks/>
        public void Envia_MensajeAsync(string User, string Pass, string Telefono_SMS, string Operador, string Mensaje_TXT, string Numero_Transaccion, string enmascarar_desde, string enmascarar_hasta, object userState) {
            if ((this.Envia_MensajeOperationCompleted == null)) {
                this.Envia_MensajeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnEnvia_MensajeOperationCompleted);
            }
            this.InvokeAsync("Envia_Mensaje", new object[] {
                        User,
                        Pass,
                        Telefono_SMS,
                        Operador,
                        Mensaje_TXT,
                        Numero_Transaccion,
                        enmascarar_desde,
                        enmascarar_hasta}, this.Envia_MensajeOperationCompleted, userState);
        }
        
        private void OnEnvia_MensajeOperationCompleted(object arg) {
            if ((this.Envia_MensajeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.Envia_MensajeCompleted(this, new Envia_MensajeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://10.1.1.53/bimovil_tokens", RequestNamespace="http://10.1.1.53/bimovil_tokens", ResponseNamespace="http://10.1.1.53/bimovil_tokens", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataTable Lista_Operadores(string User, string Pass) {
            object[] results = this.Invoke("Lista_Operadores", new object[] {
                        User,
                        Pass});
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public void Lista_OperadoresAsync(string User, string Pass) {
            this.Lista_OperadoresAsync(User, Pass, null);
        }
        
        /// <remarks/>
        public void Lista_OperadoresAsync(string User, string Pass, object userState) {
            if ((this.Lista_OperadoresOperationCompleted == null)) {
                this.Lista_OperadoresOperationCompleted = new System.Threading.SendOrPostCallback(this.OnLista_OperadoresOperationCompleted);
            }
            this.InvokeAsync("Lista_Operadores", new object[] {
                        User,
                        Pass}, this.Lista_OperadoresOperationCompleted, userState);
        }
        
        private void OnLista_OperadoresOperationCompleted(object arg) {
            if ((this.Lista_OperadoresCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.Lista_OperadoresCompleted(this, new Lista_OperadoresCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://10.1.1.53/envia_mensaje_email", RequestNamespace="http://10.1.1.53/envia_mensaje_email", ResponseNamespace="http://10.1.1.53/envia_mensaje_email", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataTable envia_mensaje_email(string User, string Pass, string email, string Mensaje_TXT, string Numero_Transaccion, string instancia_aws, string pais, string enmascarar_desde, string enmascarar_hasta) {
            object[] results = this.Invoke("envia_mensaje_email", new object[] {
                        User,
                        Pass,
                        email,
                        Mensaje_TXT,
                        Numero_Transaccion,
                        instancia_aws,
                        pais,
                        enmascarar_desde,
                        enmascarar_hasta});
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public void envia_mensaje_emailAsync(string User, string Pass, string email, string Mensaje_TXT, string Numero_Transaccion, string instancia_aws, string pais, string enmascarar_desde, string enmascarar_hasta) {
            this.envia_mensaje_emailAsync(User, Pass, email, Mensaje_TXT, Numero_Transaccion, instancia_aws, pais, enmascarar_desde, enmascarar_hasta, null);
        }
        
        /// <remarks/>
        public void envia_mensaje_emailAsync(string User, string Pass, string email, string Mensaje_TXT, string Numero_Transaccion, string instancia_aws, string pais, string enmascarar_desde, string enmascarar_hasta, object userState) {
            if ((this.envia_mensaje_emailOperationCompleted == null)) {
                this.envia_mensaje_emailOperationCompleted = new System.Threading.SendOrPostCallback(this.Onenvia_mensaje_emailOperationCompleted);
            }
            this.InvokeAsync("envia_mensaje_email", new object[] {
                        User,
                        Pass,
                        email,
                        Mensaje_TXT,
                        Numero_Transaccion,
                        instancia_aws,
                        pais,
                        enmascarar_desde,
                        enmascarar_hasta}, this.envia_mensaje_emailOperationCompleted, userState);
        }
        
        private void Onenvia_mensaje_emailOperationCompleted(object arg) {
            if ((this.envia_mensaje_emailCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.envia_mensaje_emailCompleted(this, new envia_mensaje_emailCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void Envia_MensajeCompletedEventHandler(object sender, Envia_MensajeCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Envia_MensajeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal Envia_MensajeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataTable Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataTable)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void Lista_OperadoresCompletedEventHandler(object sender, Lista_OperadoresCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Lista_OperadoresCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal Lista_OperadoresCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataTable Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataTable)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void envia_mensaje_emailCompletedEventHandler(object sender, envia_mensaje_emailCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class envia_mensaje_emailCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal envia_mensaje_emailCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataTable Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataTable)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591