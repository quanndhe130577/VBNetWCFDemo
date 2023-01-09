Imports System.Data.SqlClient

Public Class ClinicService
   Implements IClinicService

   Private myConn As SqlConnection
   Private myCmd As SqlCommand
   Private myReader As SqlDataReader

   Function GetClinics() As List(Of Clinic) Implements IClinicService.GetClinics
      Dim result = New List(Of Clinic)()
      'Create a Connection object.
      myConn = New SqlConnection("Initial Catalog=VBDemoDatabase;Data Source=localhost;Integrated Security=SSPI;")
      'Create a Command object.
      myCmd = myConn.CreateCommand
      myCmd.CommandText = "SELECT ID, Name, Address, PhoneNumber FROM Clinics"
      'Open the connection.
      myConn.Open()

      myReader = myCmd.ExecuteReader()
      Do While myReader.Read()
         Dim clinic As Clinic = New Clinic
         clinic.ID = myReader.GetGuid(0)
         clinic.Name = myReader.GetString(1)
         clinic.Address = myReader.GetString(2)
         clinic.PhoneNumber = myReader.GetString(3)

         result.Add(clinic)
      Loop

      'Close the reader and the database connection.
      myReader.Close()
      myConn.Close()
      Return result
   End Function

   Public Sub DeleteClinic(ByVal deletedId As Guid) Implements IClinicService.DeleteClinic
      Dim query As String = String.Empty
      query &= " delete Clinics "
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

   Function GetClinicById(ByVal clinicId As Guid) As Clinic Implements IClinicService.GetClinicById
      Dim result = New Clinic()
      Dim Query As String = "Select top 1 Name, Address, PhoneNumber from Clinics where id = @id"
      Using conn As New SqlConnection("Initial Catalog=VBDemoDatabase;Data Source=localhost;Integrated Security=SSPI;")
         Using comm As New SqlCommand()
            With comm
               .Connection = conn
               .CommandType = CommandType.Text
               .CommandText = Query
               .Parameters.AddWithValue("@id", clinicId)
            End With
            Try
               conn.Open()
               myReader = comm.ExecuteReader()
               Do While myReader.Read()
                  result.Name = myReader.GetString(0)
                  result.Address = myReader.GetString(1)
                  result.PhoneNumber = myReader.GetString(2)
                  Exit Do
               Loop

               Return result
            Catch ex As SqlException
               Return Nothing
            Finally
               conn.Close()
            End Try
         End Using
      End Using
   End Function

   Public Function UpdateClinicById(clinicId As Guid, name As String, address As String, phone As String) As Boolean Implements IClinicService.UpdateClinicById
      Dim query As String = String.Empty
      query &= " Update Clinics "
      query &= " set name = @name, address = @address, phoneNumber = @phoneNumber"
      query &= " where id = @id"

      Using conn As New SqlConnection("Initial Catalog=VBDemoDatabase;Data Source=localhost;Integrated Security=SSPI;")
         Using comm As New SqlCommand()
            With comm
               .Connection = conn
               .CommandType = CommandType.Text
               .CommandText = query
               .Parameters.AddWithValue("@id", clinicId)
               .Parameters.AddWithValue("@name", name)
               .Parameters.AddWithValue("@address", address)
               .Parameters.AddWithValue("@phoneNumber", phone)
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

   Public Function AddNewClinic(name As String, address As String, phone As String) As Boolean Implements IClinicService.AddNewClinic
      Dim query As String = String.Empty
      query &= "INSERT INTO Clinics (ID, Name, Address, PhoneNumber)"
      query &= "VALUES (@id, @name, @address, @phoneNumber)"

      Using conn As New SqlConnection("Initial Catalog=VBDemoDatabase;Data Source=localhost;Integrated Security=SSPI;")
         Using comm As New SqlCommand()
            With comm
               .Connection = conn
               .CommandType = CommandType.Text
               .CommandText = query
               .Parameters.AddWithValue("@id", Guid.NewGuid())
               .Parameters.AddWithValue("@name", name)
               .Parameters.AddWithValue("@address", address)
               .Parameters.AddWithValue("@phoneNumber", phone)
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
