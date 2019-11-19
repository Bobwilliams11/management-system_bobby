Imports MySql.Data.MySqlClient

Public Class CHANGE_PASSWORD
    Dim READER As MySqlDataReader
    Dim connection As MySqlConnection
    Dim command As MySqlCommand
    ' Dim dt As New DataTable

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        connection = New MySqlConnection
        Dim Reader As MySqlDataReader
        Try
            If TextBox1.Text = "" Then
                MsgBox("PLEASE ENTER OLD USERNAME", vbCancel + MsgBoxResult.No, "")
            ElseIf TextBox2.Text = "" Then
                MsgBox("PLEASE ENTER NEW USERNAME", vbCancel + MsgBoxResult.No, "")
            ElseIf TextBox3.Text = "" Then
                MsgBox("PLEASE ENTER NEW PASSWORD", vbCancel + MsgBoxResult.No, " ")
            ElseIf TextBox4.Text <> TextBox3.Text Then
                MsgBox("PASSWORD DID NOT MATCH", vbCancel + MsgBoxResult.No, "")
            Else
                connection.ConnectionString = "server=localhost; userid=root; password=''; database=voa;"

                Dim query As String = "update usertable set username='" & TextBox2.Text & "',password= '" & TextBox3.Text & "' where username='" & TextBox1.Text & "'"
                connection.Open()
                Command = New MySqlCommand(query, connection)
                Reader = Command.ExecuteReader
                MsgBox("USER CHANGED SUCCESFULLY")
            End If

            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox1.Focus()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            connection.Dispose()


        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        LOGIN_FORM.Show()
        Me.Close()

    End Sub
End Class