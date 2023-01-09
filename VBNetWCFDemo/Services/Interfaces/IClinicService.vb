<ServiceContract()>
Public Interface IClinicService

   <OperationContract()>
   Function GetClinics() As List(Of Clinic)

   <OperationContract()>
   Sub DeleteClinic(ByVal deletedId As Guid)

   <OperationContract()>
   Function GetClinicById(ByVal clinicId As Guid) As Clinic

   <OperationContract()>
   Function UpdateClinicById(ByVal clinicId As Guid, ByVal name As String, ByVal address As String, ByVal phone As String) As Boolean

   <OperationContract()>
   Function AddNewClinic(ByVal name As String, ByVal address As String, ByVal phone As String) As Boolean
End Interface
