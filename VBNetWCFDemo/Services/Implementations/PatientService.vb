Imports System.Data.SqlClient

Public Class PatientService
   Implements IPatientService

   Private myConn As SqlConnection
   Private myCmd As SqlCommand
   Private myReader As SqlDataReader

   Function GetPatients(clinicId As Guid) As List(Of Patient) Implements IPatientService.GetPatients
      Dim result = New List(Of Patient)()
      'Create a Connection object.
      myConn = New SqlConnection("Initial Catalog=VBDemoDatabase;Data Source=localhost;Integrated Security=SSPI;")
      'Create a Command object.
      myCmd = myConn.CreateCommand
      myCmd.CommandText = "SELECT p.ID, p.NRIC, p.Name, p.DateOfBirth, p.Address, p.PhoneNumber "

      If (Guid.Empty = clinicId) Then
         myCmd.CommandText &= " FROM Patients p"
      Else
         myCmd.CommandText &= " FROM Patients p, Clinics c, Treatments t"
         myCmd.CommandText &= " where p.id = t.patientId and c.id = t.clinicId and c.Id = @clinicId"
         myCmd.Parameters.AddWithValue("@clinicId", clinicId)
      End If

      'Open the connection.
      myConn.Open()

      myReader = myCmd.ExecuteReader()
      Do While myReader.Read()
         Dim patient As Patient = New Patient
         patient.ID = myReader.GetGuid(0)
         patient.NRIC = myReader.GetString(1)
         patient.Name = myReader.GetString(2)
         patient.DateOfBirth = myReader.GetDateTime(3)
         patient.Address = myReader.GetString(4)
         patient.PhoneNumber = myReader.GetString(5)

         result.Add(patient)
      Loop

      'Close the reader and the database connection.
      myReader.Close()
      myConn.Close()
      Return result
   End Function

   Public Sub DeletePatient(ByVal deletedId As Guid) Implements IPatientService.DeletePatient
      Dim query As String = String.Empty
      query &= " delete Patients "
      query &= " where id = @id"

      Using conn As New SqlConnection("Initial Catalog=VBDemoDatabase;Data Source=localhost;Integrated Security=SSPI;")
         Using comm As New SqlCommand()
            With comm
               .Connection = conn
               .CommandType = CommandType.Text
               .CommandText = query
               .Parameters.AddWithValue("@id", deletedId)
            End With
            Try
               conn.Open()
               comm.ExecuteNonQuery()
            Catch ex As SqlException
            Finally
               conn.Close()
            End Try
         End Using
      End Using
   End Sub

   Function GetPatientById(ByVal patientId As Guid) As Patient Implements IPatientService.GetPatientById
      Dim Query As String = "Select top 1 NRIC, Name ,DateOfBirth, Address, PhoneNumber, Picture from Patients where id = @id"
      Using conn As New SqlConnection("Initial Catalog=VBDemoDatabase;Data Source=localhost;Integrated Security=SSPI;")
         Using comm As New SqlCommand()
            With comm
               .Connection = conn
               .CommandType = CommandType.Text
               .CommandText = Query
               .Parameters.AddWithValue("@id", patientId)
            End With
            Try
               Dim patient = New Patient()
               conn.Open()
               myReader = comm.ExecuteReader()
               Do While myReader.Read()
                  patient.NRIC = myReader.GetString(0)
                  patient.Name = myReader.GetString(1)
                  patient.DateOfBirth = myReader.GetDateTime(2).ToString("yyyy-MM-dd")
                  patient.Address = myReader.GetString(3)
                  patient.PhoneNumber = myReader.GetString(4)
                  patient.Picture = myReader.GetString(5)
                  Exit Do
               Loop
               Return patient
            Catch ex As SqlException
               Return Nothing
            Finally
               conn.Close()
            End Try
         End Using
      End Using
   End Function

   Public Function UpdatePatientById(patientId As Guid, nric As String, name As String, dob As DateTime, address As String, phone As String, picture As String) As Boolean Implements IPatientService.UpdatePatientById
      Dim query As String = String.Empty
      query &= " Update Patients "
      query &= " set NRIC = @nric, name = @name, dateOfBirth = @dob, address = @address, phoneNumber = @phoneNumber"
      query &= " where id = @id"

      Using conn As New SqlConnection("Initial Catalog=VBDemoDatabase;Data Source=localhost;Integrated Security=SSPI;")
         Using comm As New SqlCommand()
            With comm
               .Connection = conn
               .CommandType = CommandType.Text
               .CommandText = query
               .Parameters.AddWithValue("@id", patientId)
               .Parameters.AddWithValue("@nric", nric)
               .Parameters.AddWithValue("@name", name)
               .Parameters.AddWithValue("@dob", dob)
               .Parameters.AddWithValue("@address", address)
               .Parameters.AddWithValue("@phoneNumber", phone)
               .Parameters.AddWithValue("@pic", picture)
            End With
            Try
               conn.Open()
               comm.ExecuteNonQuery()
               Return True
            Catch ex As SqlException
               Return False
            Finally
               conn.Close()
            End Try
         End Using
      End Using
   End Function

   Public Function AddNewPatient(nric As String, name As String, dob As DateTime, address As String, phone As String, picture As String) As Boolean Implements IPatientService.AddNewPatient
      Dim query As String = String.Empty
      query &= " INSERT INTO Patients (ID, NRIC, Name, DateOfBirth, Address, PhoneNumber, Picture)"
      query &= " VALUES (@id, @nric, @name, @dob, @address, @phoneNumber, @pic)"

      Using conn As New SqlConnection("Initial Catalog=VBDemoDatabase;Data Source=localhost;Integrated Security=SSPI;")
         Using comm As New SqlCommand()
            With comm
               .Connection = conn
               .CommandType = CommandType.Text
               .CommandText = query
               .Parameters.AddWithValue("@id", Guid.NewGuid())
               .Parameters.AddWithValue("@nric", nric)
               .Parameters.AddWithValue("@name", name)
               .Parameters.AddWithValue("@dob", dob)
               .Parameters.AddWithValue("@address", address)
               .Parameters.AddWithValue("@phoneNumber", phone)
               .Parameters.AddWithValue("@pic", picture)
            End With
            Try
               conn.Open()
               comm.ExecuteNonQuery()
               Return True
            Catch ex As SqlException
               Return False
            Finally
               conn.Close()
            End Try
         End Using
      End Using
   End Function
End Class
