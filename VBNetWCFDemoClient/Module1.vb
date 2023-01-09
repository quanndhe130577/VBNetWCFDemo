Imports VBNetWCFDemo
Imports VBNetWCFDemoClient.ClinicServiceReference
Module Module1

   Sub Main()
      'Step 1: Create an instance of the WCF proxy.
      Dim client As ClinicServiceClient = New ClinicServiceClient()

      ' Step 2: Call the service operations.
      ' Call the Add service operation.
      Dim result = client.GetClinics()
      For Each item In result
         Console.WriteLine("Clinic name :{0}", item.Name)
      Next

      ' Step 3: Close the client to gracefully close the connection and clean up resources.
      Console.WriteLine(vbLf & "Press <Enter> to terminate the client.")
      Console.ReadLine()
      client.Close()
   End Sub

End Module
