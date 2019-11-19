Imports MySql.Data.MySqlClient
Public Class ACADEMIC_REPORT
    Dim connection As MySqlConnection
    Dim READER As MySqlDataReader
    Dim dt As New DataTable
    Dim command As MySqlCommand




    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ADMIN_PAGE.Show()
        Me.Close()
    End Sub

    Private Sub ACADEMIC_REPORT_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        connection = New MySqlConnection

        connection.ConnectionString = "server=localhost; userid=root; password=''; database=voa;database=voa;"

        Dim sda As New MySqlDataAdapter

        Dim bs As New BindingSource
        Try
            connection.Open()
            Dim query As String
            query = "Select * From academic_report"
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
        connection = New MySqlConnection

        connection.ConnectionString = "server=localhost; userid=root; password=''; database=voa;database=voa;"

        Try
            connection.Open()
            Dim query As String
            query = "INSERT INTO `academic_report`(`student_id`, `Total_fees`, `certificate_fees`, `status_of_completion`) VALUES ('" & TextBox1.Text & "','" & txbTotalFees.Text & "', '" & txbCertFees.Text & "','" & cmbStatusComp.Text & "')"
            command = New MySqlCommand(query, connection)
            READER = command.ExecuteReader
            MsgBox("Data Save successfully")
            connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            connection.Dispose()
        End Try
    End Sub
    Public Sub frm_load()
        connection = New MySqlConnection
        connection.ConnectionString = "server=localhost; userid=root; password=''; database=voa;database=voa;"

        Dim sda As New MySqlDataAdapter
        Dim dt As New DataTable
        Dim bs As New BindingSource
        Try
            connection.Open()
            Dim query As String
            query = "Select * From academic_report"
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

    Private Sub AddAccademicReport()
        'Insert the new Academic record
        Dim query As String = "INSERT INTO academic_report(Total_fees, certificate_fees, status_of_completion)" &
                                                "VALUES (@Total_fees, @certificate_fees,@status_of_completion )"
        AddParams("@Total_fees", txbTotalFees.Text)
        AddParams("@certificate_fees", txbCertFees.Text)
        AddParams("@status_of_completion", cmbStatusComp.Text)
        ExecuteSQL(sqlStament:=query)
        CatchExecption()
        'Fetch all the records from the database
        Dim sqlStatement As String = "SELECT * FROM academic_report"
        DataGridView1.DataSource = ExecuteSQL(sqlStament:=sqlStatement)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AddAccademicReport()
        'Dim READER As MySqlDataReader

        'connection = New MySqlConnection

        'connection.ConnectionString = "server=localhost; userid=root; password=''; database=voa;"

        'Try
        '    connection.Open()
        '    If TextBox1.Text = "" Then
        '        MsgBox("Name cannot be null", vbAbort + MsgBoxResult.No, "")
        '    ElseIf txbTotalFees.Text = "" Then

        '        MsgBox("Please insert the total_fees ", vbCancel + MsgBoxResult.No, "")
        '    Else
        '        Dim query As String = "INSERT INTO `academic_report`(`student_id`, `Total_fees`, `certificate_fees`, `status_of_completion`) VALUES ('" & TextBox1.Text & "','" & txbTotalFees.Text & "', '" & txbCertFees.Text & "','" & cmbStatusComp.Text & "')"
        '        command = New MySqlCommand(query, connection)
        '        READER = command.ExecuteReader
        '        ' insert()

        '        MessageBox.Show("Data Save successfully")
        '        TextBox1.Text = ""
        '        txbTotalFees.Text = ""
        '        txbCertFees.Text = ""
        '        cmbStatusComp.Text = ""
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'Finally
        '    connection.Dispose()
        'End Try
        'connection.Open()
        'frm_load()
        'connection.Close()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        AddParams("@student_id", TextBox4.Text)
        sqlStatement = "SELECT * FROM academic_report WHERE student_id = @student_id"

        DataGridView1.DataSource = ExecuteSQL(sqlStament:=sqlStatement)

    End Sub
End Class