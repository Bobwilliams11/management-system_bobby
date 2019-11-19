Imports MySql.Data.MySqlClient

Public Class STUDENT_REPORT_FORM
    Dim connection As MySqlConnection
    Dim READER As MySqlDataReader
    Dim dt As New DataTable
    Dim command As MySqlCommand

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        REPORTS_PAGE.Show()
    End Sub

    Private Sub STUDENT_REPORT_FORM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connection = New MySqlConnection
        connection.ConnectionString = "server=localhost; userid=root; password=''; database=voa;"
        Dim sda As New MySqlDataAdapter

        Dim bs As New BindingSource
        Try
            connection.Open()
            Dim query As String
            query = "SELECT `student_id`, `first_name`, `middle_name`, `last_name`, `gender`, `date_of_birth`, `nationality`, `marital_status`, `level_of_education`, `occupation`, `mobile_number`, `telephone_number`, `email`, `residence`, `house_number`, `guardian_name`, `emergency_name`, `emergency_contact`, `courses` FROM  voa. student_information "
            command = New MySqlCommand(query, connection)
            sda.SelectCommand = command
            sda.Fill(dt)
            bs.DataSource = dt
            DataGridView1.DataSource = bs
            sda.Update(dt)
            connection.Close()
        Catch ex As MySqlException
            MessageBox.Show("student_information")

        Finally
            connection.Dispose()
        End Try
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim bitmap As New Bitmap(Me.DataGridView1.Width, Me.DataGridView1.Height)
        DataGridView1.DrawToBitmap(bitmap, New Rectangle(0, 0, Me.DataGridView1.Width, Me.DataGridView1.Height))
        e.Graphics.DrawImage(bitmap, 0, 0)
        Dim rectprint As RectangleF = e.PageSettings.PrintableArea
        If Me.DataGridView1.Height = rectprint.Height > 0 Then e.HasMorePages = True

    End Sub
    Private bitmap As Bitmap


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PrintDocument1.Print()
        Dim height As Integer = DataGridView1.Height
        DataGridView1.Height = DataGridView1.RowCount = DataGridView1.RowTemplate.Height
        'Bitmap = New Bitmap(Me.DataGridView1.Width, Me.DataGridView1.Height)
        'DataGridView1.DrawToBitmap(Bitmap, New Rectangle(0, 0, Me.DataGridView1.Width, Me.DataGridView1.Height))
        'PrintPreviewDialog1.Document = PrintDocument1
        'PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
        'PrintPreviewDialog1.ShowDialog()
        'DataGridView1.Height = height
    End Sub
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class