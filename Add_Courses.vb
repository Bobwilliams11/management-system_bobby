Imports MySql.Data.MySqlClient

Public Class Add_Courses
    Dim connection As MySqlConnection
    Dim READER As MySqlDataReader
    Dim command As MySqlCommand
    Dim dt As New DataTable

    Private Sub Add_Courses_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connection = New MySqlConnection

        connection.ConnectionString = "server=localhost; userid=root; password=''; database=voa;"

        Dim sda As New MySqlDataAdapter

        Dim bs As New BindingSource
        Try
            connection.Open()
            Dim query As String
            query = "Select course_name,course_duration,price from voa.courses_tb"
            command = New MySqlCommand(query, connection)

            sda.SelectCommand = command
            sda.Fill(dt)
            bs.DataSource = dt
            DataGridView1.DataSource = bs

            sda.Update(dt)
            connection.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)

        Finally
            connection.Dispose()
        End Try

    End Sub
    Private Sub insert()
        autogenerate()
        connection = New MySqlConnection
        connection.ConnectionString = "server=localhost; userid=root; password=''; database=voa;database=voa;"

        Try
            connection.Open()
            Dim query As String
            query = "INSERT INTO `voa`.`courses` (`id`, `program_id`, `course_name`, `course_duration`, `price`) VALUES ('" & TextBox1.Text & "','" & TextBox2.Text & "', '" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "')"
            command = New MySqlCommand(query, connection)
            READER = command.ExecuteReader
            MsgBox(" Successfully Save")
            connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            connection.Dispose()
        End Try
    End Sub
    Private Sub autogenerate()

        connection.ConnectionString = ("server=localhost; userid=root; password=''; database=voa;database=voa;")
        command.Connection = connection
        connection.Open()
        Dim number As Integer
        command.CommandText = "select max(id) from courses_tb"
        command.CommandText = "select max(program_id) from courses_tb"
        If IsDBNull(command.ExecuteScalar) Then
            number = 1
            TextBox4.Text = number
            TextBox5.Text = number
        Else
            number = command.ExecuteScalar + 1
            TextBox4.Text = number
            TextBox5.Text = number

        End If
        command.Dispose()
        connection.Close()
        connection.Dispose()
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        Dim dv As New DataView(dt)
        dv.RowFilter = String.Format("course_name like '%{0}%'", TextBox6.Text)
        DataGridView1.DataSource = dv
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub
End Class