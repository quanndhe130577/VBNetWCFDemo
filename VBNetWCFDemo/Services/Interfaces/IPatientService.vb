<ServiceContract()>
Public Interface IPatientService

   <OperationContract()>
   Function GetPatients(ByVal clinicId As Guid) As List(Of Patient)

   <OperationContract()>
   Sub DeletePatient(ByVal deletedId As Guid)

   <OperationContract()>
   Function GetPatientById(ByVal patientId As Guid) As Patient

   <OperationContract()>
   Function UpdatePatientById(
      ByVal patientId As Guid,
      ByVal nric As String,
      ByVal name As String,
      ByVal dob As DateTime,
      ByVal address As String,
      ByVal phone As String,
      ByVal picture As String) As Boolean

   <OperationContract()>
   Function AddNewPatient(
      ByVal nric As String,
      ByVal name As String,
      ByVal dob As DateTime,
      ByVal address As String,
      ByVal phone As String,
      ByVal picture As String) As Boolean
End Interface
