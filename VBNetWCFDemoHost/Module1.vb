Imports System.ServiceModel
Imports System.ServiceModel.Description
Imports VBNetWCFDemo

Module Module1
   Sub Main()
      ' Step 1: Create a URI to serve as the base address.
      Dim baseAddress1 As Uri = New Uri("http://localhost:8001/VBNetWCFDemo/")
      Dim baseAddress2 As Uri = New Uri("http://localhost:8002/VBNetWCFDemo/")

      ' Step 2: Create a ServiceHost instance.
      Dim clinicHost As ServiceHost = New ServiceHost(GetType(ClinicService), baseAddress1)
      Dim patientHost As ServiceHost = New ServiceHost(GetType(PatientService), baseAddress2)
      Try
         HostService(clinicHost, GetType(IClinicService), "ClinicService")
         HostService(patientHost, GetType(IPatientService), "PatientService")

         ' Close the ServiceHost to stop the service.
         Console.WriteLine("Press <Enter> to terminate all the services.")
         Console.WriteLine()
         Console.ReadLine()
         clinicHost.Close()
         patientHost.Close()
      Catch ce As CommunicationException
         Console.WriteLine("An exception occurred: {0}", ce.Message)
         clinicHost.Abort()
         patientHost.Abort()
      End Try
   End Sub

   Private Sub HostService(service As ServiceHost, serviceType As Type, address As String)
      service.AddServiceEndpoint(serviceType, New WSHttpBinding(), address)
      Dim smb As ServiceMetadataBehavior = New ServiceMetadataBehavior()
      smb.HttpGetEnabled = True
      service.Description.Behaviors.Add(smb)
      service.Open()
      Console.WriteLine("The {0} is ready.", serviceType)
   End Sub
End Module
