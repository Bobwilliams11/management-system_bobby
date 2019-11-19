Imports MySql.Data.MySqlClient

Public Class Accounts
    Dim connection As MySqlConnection
    Dim READER As MySqlDataReader
    Dim command As MySqlCommand
    Dim dt As New DataTable
    Private Sub Accounts_Load(sender As Object, e As EventArgs) Handles Me.Load
        cmbType.DataSource = incomeCategories
        sqlStatement = "SELECT * FROM student_information"
        dt = ExecuteSQL(sqlStatement)
        cmbPersonName.Items.Clear()
        For Each row As DataRow In dt.Rows
            cmbPersonName.Items.Add(row.Item("first_name") & " " & row.Item("middle_name") & " " & row.Item("last_name"))
        Next

        connection = New MySqlConnection

        connection.ConnectionString = "server=localhost; userid=root; password=''; database=voa;"

        Dim sda As New MySqlDataAdapter

        Dim bs As New BindingSource
        Try
            connection.Open()
            Dim query As String
            query = "Select * from voa.student_information"
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

    Private Sub cmbPersonName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPersonName.SelectedIndexChanged
        pbxStudentPic.ImageLocation = UploadImagePath & "\" & dt.Rows(cmbPersonName.SelectedIndex).Item("image")
        MsgBox(dt.Rows(0).Item("image"))
    End Sub

    Private Sub btnGetData_Click(sender As Object, e As EventArgs) Handles btnGetData.Click

        sqlStatement = "SELECT * FROM transaction_tb WHERE person_name = '" & dt.Rows(cmbPersonName.SelectedIndex).Item("student_id") & "' AND " &
                        "STR_TO_DATE(trans_date, '%m/%d/%Y') BETWEEN '" & dtpFromDate.Value.ToShortDateString & "' AND  '" & dtpToDate.Value.ToShortDateString & "'"


        MsgBox(sqlStatement)
        DataGridView1.DataSource = ExecuteSQL(sqlStament:=sqlStatement)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub txbAmountPaid_TextChanged(sender As Object, e As EventArgs) Handles txbAmountPaid.TextChanged
        txbBalance.Text = Val(txbFeeAmount.Text) - Val(txbAmountPaid.Text)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub
End Class