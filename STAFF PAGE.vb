Imports MySql.Data.MySqlClient

Public Class STAFF_PAGE
    Dim connection As MySqlConnection
    Dim READER As MySqlDataReader
    Dim command As MySqlCommand
    Dim dt As New DataTable




    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ADMIN_PAGE.Show()
        Me.Close()
    End Sub
    Private Sub frm_load()
        connection = New MySqlConnection
        connection.ConnectionString = "server=localhost; userid=root; password=''; database=voa;"

        Dim sda As New MySqlDataAdapter
        Dim dt As New DataTable
        Dim bs As New BindingSource
        Try
            connection.Open()
            Dim query As String
            query = "Select * From staff"
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
    Private Sub autogenerate()

        connection.ConnectionString = ("server=localhost; userid=root; password=''; database=voa;database=voa;")
        command.Connection = connection
        connection.Open()
        Dim number As Integer
        command.CommandText = "select max(staff_id) from staff"
        If IsDBNull(command.ExecuteScalar) Then
            number = 1
            TextBox1.Text = number
        Else
            number = command.ExecuteScalar + 1
            TextBox1.Text = number
        End If
        command.Dispose()
        connection.Close()
        connection.Dispose()

    End Sub
    Private Sub STAFF_PAGE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TextBox1.Visible = False


        connection = New MySqlConnection

        connection.ConnectionString = "server=localhost; userid=root; password=''; database=voa;"

        Dim sda As New MySqlDataAdapter

        Dim bs As New BindingSource
        Try
            connection.Open()
            Dim query As String
            query = "Select * From staff"
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
            frm_load()
        End Try

    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim READER As MySqlDataReader
       connection = New MySqlConnection
            connection.ConnectionString = "server=localhost; userid=root; password=''; database=voa;"

            Try
                connection.Open()
            Dim query As String = "delete from staff where staff_name='" & TextBox2.Text & "'"
                command = New MySqlCommand(query, connection)
            READER = command.ExecuteReader
            MessageBox.Show("Data Delete Sucessfully")
            connection.Close()

            TextBox2.Text = ""

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                connection.Dispose()
        End Try
        connection.Open()
        frm_load()
        connection.Close()

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Dim READER As MySqlDataReader

        connection = New MySqlConnection
        autogenerate()

        connection.ConnectionString = "server=localhost; userid=root; password=''; database=voa"
        Dim time As DateTime = DateTime.Now
        Dim formate As String = "yyyy/MM/dd"
        Dim newdate = time.ToString(formate)
        Try

            connection.Open()

            Dim query As String = "INSERT INTO `staff`(`staff_id`, `staff_name`, `position`, `location`, `email`, `employment_date`, `staff_salary`) values ('" & TextBox1.Text & "','" & TextBox2.Text & "', '" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "' ,'" & TextBox6.Text & "','" & TextBox7.Text & "')"
            command = New MySqlCommand(query, connection)
            READER = command.ExecuteReader


            MessageBox.Show("Data Save Successfully")
            'TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox6.Text = ""
            TextBox7.Text = ""
            TextBox8.Text = ""

            connection.Close()
        Catch ex As Exception

            MessageBox.Show(ex.Message)
        Finally
            connection.Dispose()
        End Try
        connection.Open()
        frm_load()
        connection.Close()

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class