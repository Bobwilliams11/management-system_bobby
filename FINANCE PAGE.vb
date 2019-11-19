Imports MySql.Data.MySqlClient
Public Class FINANCE_PAGE
    Dim connection As MySqlConnection
    Dim READER As MySqlDataReader
    Dim dt As New DataTable
    Dim command As MySqlCommand


    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        MAIN_PAGE.Show()
        Me.Close()
    End Sub

    Private Sub FINANCE_PAGE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox11.Visible = False
    End Sub
    Private Sub autogenerate()
        connection.ConnectionString = "server=localhost; userid=root; password=''; database=voa;database=voa;"
        command.Connection = connection
        connection.Open()
        Dim number As Integer
        command.CommandText = "select max(student_id) from income"
        If IsDBNull(command.ExecuteScalar) Then
            number = 1
            TextBox11.Text = number
        Else
            number = command.ExecuteScalar + 1
            TextBox11.Text = number
        End If
        command.Dispose()
        connection.Close()
        connection.Dispose()

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        connection = New MySqlConnection
        connection.ConnectionString = "server=localhost; userid=root; password=''; database=voa;database=voa;"

        autogenerate()


        Try
            connection.Open()
            Dim query As String
            query = "INSERT INTO voa . income (`addmission_fees`, `form_fees`, `certificate_fees`, `handout_fees`, `printing_fees`, `sales`, `software_development`, `sales_of_uniform`, `installation_and_repairs`, `cafe_services`, `student_id`, `total`, `date_time`) VALUES ('" & TextBox1.Text & "' , '" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "' , '" & TextBox6.Text & "' , '" & TextBox7.Text & "' , '" & TextBox8.Text & "' ,'" & TextBox9.Text & "' ,'" & TextBox10.Text & " ','" & TextBox11.Text & "','" & TextBox25.Text & "','" & DateTimePicker1.Value & "')"
            command = New MySqlCommand(query, connection)
            READER = command.ExecuteReader

            MsgBox("Data Save Successfully")
            connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            connection.Dispose()
        End Try
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""



    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        connection = New MySqlConnection
        connection.ConnectionString = "server=localhost; userid=root; password=''; database=voa;database=voa;"

        Try
            connection.Open()
            Dim query As String
            query = "INSERT INTO voa . expenses (`promotion`, `discount_allowed`, `purchases`, `vehicle_maintenance`, `general_maintenance`, `clearning_and_sanitation`, `transportation`, `total`) VALUES ('" & TextBox12.Text & "', '" & TextBox13.Text & "','" & TextBox14.Text & "','" & TextBox15.Text & "','" & TextBox16.Text & "', '" & TextBox17.Text & "','" & TextBox18.Text & "','" & TextBox23.Text & "')"
            command = New MySqlCommand(query, connection)
            READER = command.ExecuteReader
            MsgBox("Data Save Successfully")
            connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            connection.Dispose()
        End Try



        TextBox12.Text = ""
        TextBox13.Text = ""
        TextBox14.Text = ""
        TextBox15.Text = ""
        TextBox16.Text = ""
        TextBox17.Text = ""
        TextBox18.Text = ""

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        connection = New MySqlConnection
        connection.ConnectionString = "server=localhost; userid=root; password=''; database=voa;database=voa;"

        Try
            connection.Open()
            Dim query As String
            query = "INSERT INTO `voa`.`monthly_expenses`(`rent`, `light_bill`, `wages_salary`, `ssnit`, `total`) VALUES ('" & TextBox19.Text & "' ,'" & TextBox20.Text & "','" & TextBox21.Text & "','" & TextBox22.Text & "','" & TextBox24.Text & "')"
            command = New MySqlCommand(query, connection)
            READER = command.ExecuteReader
            MsgBox("Data Save Successfully")
            connection.Close()


            TextBox19.Text = ""
            TextBox20.Text = ""
            TextBox21.Text = ""
            TextBox22.Text = ""
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            connection.Dispose()


        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox19_TextChanged(sender As Object, e As EventArgs) Handles TextBox19.TextChanged
        TextBox24.Text = Val(TextBox19.Text) + Val(TextBox20.Text) + Val(TextBox21.Text) + Val(TextBox22.Text)
    End Sub

    Private Sub TextBox20_TextChanged(sender As Object, e As EventArgs) Handles TextBox20.TextChanged
        TextBox24.Text = Val(TextBox19.Text) + Val(TextBox20.Text) + Val(TextBox21.Text) + Val(TextBox22.Text)
    End Sub

    Private Sub TextBox21_TextChanged(sender As Object, e As EventArgs) Handles TextBox21.TextChanged
        TextBox24.Text = Val(TextBox19.Text) + Val(TextBox20.Text) + Val(TextBox21.Text) + Val(TextBox22.Text)
    End Sub

    Private Sub TextBox22_TextChanged(sender As Object, e As EventArgs) Handles TextBox22.TextChanged
        TextBox24.Text = Val(TextBox19.Text) + Val(TextBox20.Text) + Val(TextBox21.Text) + Val(TextBox22.Text)
    End Sub

    Private Sub TextBox12_TextChanged(sender As Object, e As EventArgs) Handles TextBox12.TextChanged
        TextBox23.Text = Val(TextBox12.Text) + Val(TextBox13.Text) + Val(TextBox14.Text) + Val(TextBox15.Text) + Val(TextBox16.Text) + Val(TextBox17.Text) + Val(TextBox18.Text)
    End Sub

    Private Sub TextBox13_TextChanged(sender As Object, e As EventArgs) Handles TextBox13.TextChanged
        TextBox23.Text = Val(TextBox12.Text) + Val(TextBox13.Text) + Val(TextBox14.Text) + Val(TextBox15.Text) + Val(TextBox16.Text) + Val(TextBox17.Text) + Val(TextBox18.Text)
    End Sub

    Private Sub TextBox14_TextChanged(sender As Object, e As EventArgs) Handles TextBox14.TextChanged
        TextBox23.Text = Val(TextBox12.Text) + Val(TextBox13.Text) + Val(TextBox14.Text) + Val(TextBox15.Text) + Val(TextBox16.Text) + Val(TextBox17.Text) + Val(TextBox18.Text)
    End Sub

    Private Sub TextBox15_TextChanged(sender As Object, e As EventArgs) Handles TextBox15.TextChanged
        TextBox23.Text = Val(TextBox12.Text) + Val(TextBox13.Text) + Val(TextBox14.Text) + Val(TextBox15.Text) + Val(TextBox16.Text) + Val(TextBox17.Text) + Val(TextBox18.Text)
    End Sub

    Private Sub TextBox16_TextChanged(sender As Object, e As EventArgs) Handles TextBox16.TextChanged
        TextBox23.Text = Val(TextBox12.Text) + Val(TextBox13.Text) + Val(TextBox14.Text) + Val(TextBox15.Text) + Val(TextBox16.Text) + Val(TextBox17.Text) + Val(TextBox18.Text)
    End Sub

    Private Sub TextBox17_TextChanged(sender As Object, e As EventArgs) Handles TextBox17.TextChanged
        TextBox23.Text = Val(TextBox12.Text) + Val(TextBox13.Text) + Val(TextBox14.Text) + Val(TextBox15.Text) + Val(TextBox16.Text) + Val(TextBox17.Text) + Val(TextBox18.Text)
    End Sub

    Private Sub TextBox18_TextChanged(sender As Object, e As EventArgs) Handles TextBox18.TextChanged
        TextBox23.Text = Val(TextBox12.Text) + Val(TextBox13.Text) + Val(TextBox14.Text) + Val(TextBox15.Text) + Val(TextBox16.Text) + Val(TextBox17.Text) + Val(TextBox18.Text)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        TextBox25.Text = Val(TextBox1.Text) + Val(TextBox2.Text) + Val(TextBox3.Text) + Val(TextBox4.Text) + Val(TextBox5.Text) + Val(TextBox6.Text) + Val(TextBox7.Text) + Val(TextBox8.Text) + Val(TextBox9.Text) + Val(TextBox10.Text)
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        TextBox25.Text = Val(TextBox1.Text) + Val(TextBox2.Text) + Val(TextBox3.Text) + Val(TextBox4.Text) + Val(TextBox5.Text) + Val(TextBox6.Text) + Val(TextBox7.Text) + Val(TextBox8.Text) + Val(TextBox9.Text) + Val(TextBox10.Text)
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        TextBox25.Text = Val(TextBox1.Text) + Val(TextBox2.Text) + Val(TextBox3.Text) + Val(TextBox4.Text) + Val(TextBox5.Text) + Val(TextBox6.Text) + Val(TextBox7.Text) + Val(TextBox8.Text) + Val(TextBox9.Text) + Val(TextBox10.Text)
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        TextBox25.Text = Val(TextBox1.Text) + Val(TextBox2.Text) + Val(TextBox3.Text) + Val(TextBox4.Text) + Val(TextBox5.Text) + Val(TextBox6.Text) + Val(TextBox7.Text) + Val(TextBox8.Text) + Val(TextBox9.Text) + Val(TextBox10.Text)
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        TextBox25.Text = Val(TextBox1.Text) + Val(TextBox2.Text) + Val(TextBox3.Text) + Val(TextBox4.Text) + Val(TextBox5.Text) + Val(TextBox6.Text) + Val(TextBox7.Text) + Val(TextBox8.Text) + Val(TextBox9.Text) + Val(TextBox10.Text)
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        TextBox25.Text = Val(TextBox1.Text) + Val(TextBox2.Text) + Val(TextBox3.Text) + Val(TextBox4.Text) + Val(TextBox5.Text) + Val(TextBox6.Text) + Val(TextBox7.Text) + Val(TextBox8.Text) + Val(TextBox9.Text) + Val(TextBox10.Text)
    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged
        TextBox25.Text = Val(TextBox1.Text) + Val(TextBox2.Text) + Val(TextBox3.Text) + Val(TextBox4.Text) + Val(TextBox5.Text) + Val(TextBox6.Text) + Val(TextBox7.Text) + Val(TextBox8.Text) + Val(TextBox9.Text) + Val(TextBox10.Text)
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged
        TextBox25.Text = Val(TextBox1.Text) + Val(TextBox2.Text) + Val(TextBox3.Text) + Val(TextBox4.Text) + Val(TextBox5.Text) + Val(TextBox6.Text) + Val(TextBox7.Text) + Val(TextBox8.Text) + Val(TextBox9.Text) + Val(TextBox10.Text)
    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged
        TextBox25.Text = Val(TextBox1.Text) + Val(TextBox2.Text) + Val(TextBox3.Text) + Val(TextBox4.Text) + Val(TextBox5.Text) + Val(TextBox6.Text) + Val(TextBox7.Text) + Val(TextBox8.Text) + Val(TextBox9.Text) + Val(TextBox10.Text)
    End Sub

    Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs) Handles TextBox10.TextChanged
        TextBox25.Text = Val(TextBox1.Text) + Val(TextBox2.Text) + Val(TextBox3.Text) + Val(TextBox4.Text) + Val(TextBox5.Text) + Val(TextBox6.Text) + Val(TextBox7.Text) + Val(TextBox8.Text) + Val(TextBox9.Text) + Val(TextBox10.Text)
    End Sub
End Class