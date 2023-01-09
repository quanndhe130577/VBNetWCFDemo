﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System
Imports System.Runtime.Serialization

Namespace ClinicServiceReference
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0"),  _
     System.Runtime.Serialization.DataContractAttribute(Name:="Clinic", [Namespace]:="http://schemas.datacontract.org/2004/07/VBNetWCFDemo"),  _
     System.SerializableAttribute()>  _
    Partial Public Class Clinic
        Inherits Object
        Implements System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
        
        <System.NonSerializedAttribute()>  _
        Private extensionDataField As System.Runtime.Serialization.ExtensionDataObject
        
        <System.Runtime.Serialization.OptionalFieldAttribute()>  _
        Private AddressField As String
        
        <System.Runtime.Serialization.OptionalFieldAttribute()>  _
        Private IDField As System.Guid
        
        <System.Runtime.Serialization.OptionalFieldAttribute()>  _
        Private NameField As String
        
        <System.Runtime.Serialization.OptionalFieldAttribute()>  _
        Private PhoneNumberField As String
        
        <Global.System.ComponentModel.BrowsableAttribute(false)>  _
        Public Property ExtensionData() As System.Runtime.Serialization.ExtensionDataObject Implements System.Runtime.Serialization.IExtensibleDataObject.ExtensionData
            Get
                Return Me.extensionDataField
            End Get
            Set
                Me.extensionDataField = value
            End Set
        End Property
        
        <System.Runtime.Serialization.DataMemberAttribute()>  _
        Public Property Address() As String
            Get
                Return Me.AddressField
            End Get
            Set
                If (Object.ReferenceEquals(Me.AddressField, value) <> true) Then
                    Me.AddressField = value
                    Me.RaisePropertyChanged("Address")
                End If
            End Set
        End Property
        
        <System.Runtime.Serialization.DataMemberAttribute()>  _
        Public Property ID() As System.Guid
            Get
                Return Me.IDField
            End Get
            Set
                If (Me.IDField.Equals(value) <> true) Then
                    Me.IDField = value
                    Me.RaisePropertyChanged("ID")
                End If
            End Set
        End Property
        
        <System.Runtime.Serialization.DataMemberAttribute()>  _
        Public Property Name() As String
            Get
                Return Me.NameField
            End Get
            Set
                If (Object.ReferenceEquals(Me.NameField, value) <> true) Then
                    Me.NameField = value
                    Me.RaisePropertyChanged("Name")
                End If
            End Set
        End Property
        
        <System.Runtime.Serialization.DataMemberAttribute()>  _
        Public Property PhoneNumber() As String
            Get
                Return Me.PhoneNumberField
            End Get
            Set
                If (Object.ReferenceEquals(Me.PhoneNumberField, value) <> true) Then
                    Me.PhoneNumberField = value
                    Me.RaisePropertyChanged("PhoneNumber")
                End If
            End Set
        End Property
        
        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
        
        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
    End Class
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.ServiceContractAttribute(ConfigurationName:="ClinicServiceReference.IClinicService")>  _
    Public Interface IClinicService
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IClinicService/GetClinics", ReplyAction:="http://tempuri.org/IClinicService/GetClinicsResponse")>  _
        Function GetClinics() As ClinicServiceReference.Clinic()
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IClinicService/GetClinics", ReplyAction:="http://tempuri.org/IClinicService/GetClinicsResponse")>  _
        Function GetClinicsAsync() As System.Threading.Tasks.Task(Of ClinicServiceReference.Clinic())
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IClinicService/DeleteClinic", ReplyAction:="http://tempuri.org/IClinicService/DeleteClinicResponse")>  _
        Sub DeleteClinic(ByVal deletedId As System.Guid)
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IClinicService/DeleteClinic", ReplyAction:="http://tempuri.org/IClinicService/DeleteClinicResponse")>  _
        Function DeleteClinicAsync(ByVal deletedId As System.Guid) As System.Threading.Tasks.Task
    End Interface
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Public Interface IClinicServiceChannel
        Inherits ClinicServiceReference.IClinicService, System.ServiceModel.IClientChannel
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Partial Public Class ClinicServiceClient
        Inherits System.ServiceModel.ClientBase(Of ClinicServiceReference.IClinicService)
        Implements ClinicServiceReference.IClinicService
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String)
            MyBase.New(endpointConfigurationName)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(binding, remoteAddress)
        End Sub
        
        Public Function GetClinics() As ClinicServiceReference.Clinic() Implements ClinicServiceReference.IClinicService.GetClinics
            Return MyBase.Channel.GetClinics
        End Function
        
        Public Function GetClinicsAsync() As System.Threading.Tasks.Task(Of ClinicServiceReference.Clinic()) Implements ClinicServiceReference.IClinicService.GetClinicsAsync
            Return MyBase.Channel.GetClinicsAsync
        End Function
        
        Public Sub DeleteClinic(ByVal deletedId As System.Guid) Implements ClinicServiceReference.IClinicService.DeleteClinic
            MyBase.Channel.DeleteClinic(deletedId)
        End Sub
        
        Public Function DeleteClinicAsync(ByVal deletedId As System.Guid) As System.Threading.Tasks.Task Implements ClinicServiceReference.IClinicService.DeleteClinicAsync
            Return MyBase.Channel.DeleteClinicAsync(deletedId)
        End Function
    End Class
End Namespace