﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.ServiceReference2 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Person", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class Person : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nameField;
        
        private int phoneField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int id {
            get {
                return this.idField;
            }
            set {
                if ((this.idField.Equals(value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string name {
            get {
                return this.nameField;
            }
            set {
                if ((object.ReferenceEquals(this.nameField, value) != true)) {
                    this.nameField = value;
                    this.RaisePropertyChanged("name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int phone {
            get {
                return this.phoneField;
            }
            set {
                if ((this.phoneField.Equals(value) != true)) {
                    this.phoneField = value;
                    this.RaisePropertyChanged("phone");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference2.WebService2Soap")]
    public interface WebService2Soap {
        
        // CODEGEN: Generating message contract since element name findpersonResult from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/findperson", ReplyAction="*")]
        WebApplication1.ServiceReference2.findpersonResponse findperson(WebApplication1.ServiceReference2.findpersonRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/findperson", ReplyAction="*")]
        System.Threading.Tasks.Task<WebApplication1.ServiceReference2.findpersonResponse> findpersonAsync(WebApplication1.ServiceReference2.findpersonRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class findpersonRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="findperson", Namespace="http://tempuri.org/", Order=0)]
        public WebApplication1.ServiceReference2.findpersonRequestBody Body;
        
        public findpersonRequest() {
        }
        
        public findpersonRequest(WebApplication1.ServiceReference2.findpersonRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class findpersonRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int id;
        
        public findpersonRequestBody() {
        }
        
        public findpersonRequestBody(int id) {
            this.id = id;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class findpersonResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="findpersonResponse", Namespace="http://tempuri.org/", Order=0)]
        public WebApplication1.ServiceReference2.findpersonResponseBody Body;
        
        public findpersonResponse() {
        }
        
        public findpersonResponse(WebApplication1.ServiceReference2.findpersonResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class findpersonResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public WebApplication1.ServiceReference2.Person findpersonResult;
        
        public findpersonResponseBody() {
        }
        
        public findpersonResponseBody(WebApplication1.ServiceReference2.Person findpersonResult) {
            this.findpersonResult = findpersonResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WebService2SoapChannel : WebApplication1.ServiceReference2.WebService2Soap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WebService2SoapClient : System.ServiceModel.ClientBase<WebApplication1.ServiceReference2.WebService2Soap>, WebApplication1.ServiceReference2.WebService2Soap {
        
        public WebService2SoapClient() {
        }
        
        public WebService2SoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WebService2SoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebService2SoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebService2SoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WebApplication1.ServiceReference2.findpersonResponse WebApplication1.ServiceReference2.WebService2Soap.findperson(WebApplication1.ServiceReference2.findpersonRequest request) {
            return base.Channel.findperson(request);
        }
        
        public WebApplication1.ServiceReference2.Person findperson(int id) {
            WebApplication1.ServiceReference2.findpersonRequest inValue = new WebApplication1.ServiceReference2.findpersonRequest();
            inValue.Body = new WebApplication1.ServiceReference2.findpersonRequestBody();
            inValue.Body.id = id;
            WebApplication1.ServiceReference2.findpersonResponse retVal = ((WebApplication1.ServiceReference2.WebService2Soap)(this)).findperson(inValue);
            return retVal.Body.findpersonResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WebApplication1.ServiceReference2.findpersonResponse> WebApplication1.ServiceReference2.WebService2Soap.findpersonAsync(WebApplication1.ServiceReference2.findpersonRequest request) {
            return base.Channel.findpersonAsync(request);
        }
        
        public System.Threading.Tasks.Task<WebApplication1.ServiceReference2.findpersonResponse> findpersonAsync(int id) {
            WebApplication1.ServiceReference2.findpersonRequest inValue = new WebApplication1.ServiceReference2.findpersonRequest();
            inValue.Body = new WebApplication1.ServiceReference2.findpersonRequestBody();
            inValue.Body.id = id;
            return ((WebApplication1.ServiceReference2.WebService2Soap)(this)).findpersonAsync(inValue);
        }
    }
}
