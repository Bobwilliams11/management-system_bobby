Imports MySql.Data.MySqlClient
Public Class LOGIN_FORM
    Dim connection As MySqlConnection

    Dim command As MySqlCommand
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Application.Exit()
    End Sub

    Private Sub btnLOGIN_Click(sender As Object, e As EventArgs) Handles btnLOGIN.Click
        connection = New MySqlConnection

        Dim Reader As MySqlDataReader

        Dim count As Integer
        Try
            connection.ConnectionString = "server=localhost; userid=root; password=''; database=voa;"

            Dim query As String = "select * from voa.usertable where username='" & txtBox1.Text & "' and password='" & txtBox2.Text & "' "

            command = New MySqlCommand(query, connection)

            connection.Open()
            Reader = command.ExecuteReader

            While Reader.Read
                count = count + 1
            End While

            If count = 1 Then
                MessageBox.Show("Successfully Login as ADMIN")
                ADMIN_PAGE.Show()
                Me.Hide()
            ElseIf count = 2 Then
                MessageBox.Show("Successfully Login As USER")
                MAIN_PAGE.Show()
                Me.Hide()
            Else
                MessageBox.Show("Invalid username and password")
            End If
            txtBox1.Text = ""
            txtBox2.Text = ""
            txtBox1.Focus()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            connection.Dispose()


        End Try
    End Sub

    Private Sub LOGIN_FORM_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class