Imports MySql.Data.MySqlClient


Module MySqlHelper
    Public sqlStatement As String
    Private ParamsList As New List(Of MySqlParameter)
    Private sqlError As String
    Public UploadImagePath As String = "C:\ProgramData\student_form\student form\1.0.0.0\photos"

    Friend Sub AddParams(ByVal paramName As String, ByVal paramValue As String)
        ParamsList.Add(New MySqlParameter(paramName, paramValue))
    End Sub


    Friend Function ExecuteSQL(ByVal sqlStament As String) As DataTable
        sqlError = ""
        Dim connection As MySqlConnection = New MySqlConnection

        connection.ConnectionString = "server=localhost; userid=root; password=''; database=voa;database=voa;"
        Dim dt As New DataTable
        Try
            If connection.State = ConnectionState.Closed Then connection.Open()


            Dim Command As MySqlCommand = New MySqlCommand(sqlStament, connection)

            For Each param In ParamsList
                Command.Parameters.Add(param)
            Next

            Dim reader As MySqlDataReader = Command.ExecuteReader
            dt.Load(reader)
            connection.Close()

        Catch ex As MySqlException
            sqlError = ex.Message

        Finally
            If ParamsList.Count > 0 Then ParamsList.Clear()
            connection.Close()
            connection.Dispose()
        End Try
        Return dt
    End Function

    Friend Sub CatchExecption()
        If sqlError = "" Then
            MessageBox.Show(text:="Query executed successfully", caption:="VOA Student Management System", buttons:=MessageBoxButtons.OK, icon:=MessageBoxIcon.Information)
        Else
            MessageBox.Show("Cause: " & sqlError, "Something went wrong  during query execution", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Public Function GetLastStudentID() As Integer
        Dim strGetStudID As String = "SELECT lastStudentID from extras"
        Dim dt As DataTable = ExecuteSQL(strGetStudID)
        Dim lastStudentID As Integer
        If dt.Rows.Count > 0 Then
            lastStudentID = Integer.Parse(dt.Rows(0).Item("lastStudentID"))
        End If
        Return lastStudentID
    End Function



    Public Function IncreaseStudentID() As Integer
        Dim lastStudentID = GetLastStudentID()
        lastStudentID += 1
        AddParams("@lastStudentID", lastStudentID)
        Dim increaseCount As String = "UPDATE extras SET lastStudentID = @lastStudentID"
        ExecuteSQL(increaseCount)
        Return lastStudentID
    End Function

  

End Module
