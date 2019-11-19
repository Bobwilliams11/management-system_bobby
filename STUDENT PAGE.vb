Imports MySql.Data.MySqlClient

Public Class STUDENT_PAGE
    Dim connection As MySqlConnection
    Dim READER As MySqlDataReader
    Dim command As MySqlCommand
    Dim dt As New DataTable


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PrintDocument1.Print()
        Dim height As Integer = DataGridView1.Height
        DataGridView1.Height = DataGridView1.RowCount = DataGridView1.RowTemplate.Height
        'bitmap = New Bitmap(Me.DataGridView1.Width, Me.DataGridView1.Height)
        ' DataGridView1.DrawToBitmap(bitmap, New Rectangle(0, 0, Me.DataGridView1.Width, Me.DataGridView1.Height))
        'PrintPreviewDialog1.Document = PrintDocument1
        'PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
        'PrintPreviewDialog1.ShowDialog()
        'DataGridView1.Height = height


    End Sub
    Private bitmap As Bitmap


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MAIN_PAGE.Show()
        Me.Close()

    End Sub

    Private Sub STUDENT_PAGE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GroupBox4.Visible = False
        Button6.Visible = True
        Button4.Visible = False
        Button7.Visible = False
        Label7.Visible = False
        Label8.Visible = False




        connection = New MySqlConnection

        connection.ConnectionString = "server=localhost; userid=root; password=''; database=voa;"

        Dim sda As New MySqlDataAdapter

        Dim bs As New BindingSource
        Try
            connection.Open()
            Dim query As String
            query = "Select * From student_payment"
            command = New MySqlCommand(query, connection)

            sda.SelectCommand = command
            sda.Fill(dt)
            bs.DataSource = dt
            DataGridView1.DataSource = bs

            sda.Update(dt)
            connection.Close()


            ' sqlStatement = " INSERT INTO `student_payment"
            ' DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            ' DataGridView1.ColumnCount = 5

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub populate(student_id As String, course As String, amount As Double, paid As Double, balance As Double)
        Dim row As String() = New String() {student_id, course, amount, paid, balance}
        'add to rows collection
        'DataGridView1.Rows.Add(row)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click


        Dim READER As MySqlDataReader

        connection = New MySqlConnection

        connection.ConnectionString = "server=localhost; userid=root; password=''; database=voa"
        Dim time As DateTime = DateTime.Now
        Dim formate As String = "yyyy/MM/dd"
        Dim newdate = time.ToString(formate)
        Try
            connection.Open()
            If TextBox1.Text = "" Then
                MsgBox("Name cannot be null", vbAbort + MsgBoxResult.No, "")
            ElseIf TextBox2.Text = "" Then

                MsgBox("Please insert the Region of the supplier", vbCancel + MsgBoxResult.No, "")
            Else
                Dim query As String = "INSERT INTO `student_payment`(`student_id`, `course`, `amount`, `paid`, `balance`) VALUES ('" & TextBox1.Text & "','" & TextBox2.Text & "', '" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "')"
                command = New MySqlCommand(query, connection)
                READER = command.ExecuteReader
                TextBox5.Text = Val(TextBox4.Text) - Val(TextBox3.Text)

                MessageBox.Show("Data Save successfully")
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            connection.Dispose()
        End Try
        connection.Open()
        frm_load()
        connection.Close()


    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        TextBox5.Text = Val(TextBox4.Text) - Val(TextBox3.Text)
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim bitmap As New Bitmap(Me.DataGridView1.Width, Me.DataGridView1.Height)
        DataGridView1.DrawToBitmap(bitmap, New Rectangle(0, 0, Me.DataGridView1.Width, Me.DataGridView1.Height))
        e.Graphics.DrawImage(bitmap, 0, 0)
        Dim rectprint As RectangleF = e.PageSettings.PrintableArea
        If Me.DataGridView1.Height = rectprint.Height > 0 Then e.HasMorePages = True


    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        Dim dv As New DataView(dt)
        dv.RowFilter = String.Format("student_id like '%{0}%'", TextBox6.Text)
        DataGridView1.DataSource = dv
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button7.Visible = True

        command = New MySqlCommand
        connection = New MySqlConnection
        Dim reader As MySqlDataReader
        connection.ConnectionString = "server=localhost; userid=root; password=''; database=voa;"

        Try
            connection.Open()
            Dim query As String = " UPDATE student_payment set amount=( amount = '" & TextBox7.Text & "'), paid=(paid + '" & TextBox8.Text & "'), balance=(balance = '" & TextBox10.Text & "') where student_id='" & TextBox1.Text & "' "
            command = New MySqlCommand(query, connection)
            reader = command.ExecuteReader
            MsgBox("Data Updated Successfully")

            TextBox10.Text = Val(TextBox8.Text) - Val(TextBox7.Text) + Val(TextBox9.Text)
            frm_load()
            connection.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            connection.Dispose()

        End Try
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""




    End Sub
    Public Sub frm_load()
        connection = New MySqlConnection
        connection.ConnectionString = "server=localhost; userid=root; password=''; database=voa;"

        Dim sda As New MySqlDataAdapter
        Dim dt As New DataTable
        Dim bs As New BindingSource
        Try
            connection.Open()
            Dim query As String
            query = "Select * From student_payment"
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

    Private Sub PrintPreviewDialog1_Load(sender As Object, e As EventArgs) Handles PrintPreviewDialog1.Load

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim student_id As String = DataGridView1.SelectedRows(0).Cells(0).Value.ToString()
        Dim course As String = DataGridView1.SelectedRows(0).Cells(1).Value.ToString()
        Dim amount As Double = DataGridView1.SelectedRows(0).Cells(2).Value.ToString()
        Dim paid As Double = DataGridView1.SelectedRows(0).Cells(3).Value.ToString()
        Dim balance As Double = DataGridView1.SelectedRows(0).Cells(4).Value.ToString()

        'set to data textbox

        TextBox1.Text = student_id
        TextBox2.Text = course
        TextBox3.Text = amount
        TextBox4.Text = paid
        TextBox5.Text = balance

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Dim READER As MySqlDataReader
        connection = New MySqlConnection
        connection.ConnectionString = "server=localhost; userid=root; password=''; database=voa;"

        Try
            connection.Open()
            Dim query As String = "delete from student_payment where student_id='" & TextBox1.Text & "'"
            command = New MySqlCommand(query, connection)
            READER = command.ExecuteReader
            ' MessageBox.Show("Data Delete Sucessfully")
            connection.Close()

            TextBox1.Text = ""

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            connection.Dispose()
        End Try
        connection.Open()
        frm_load()
        connection.Close()

        If MessageBox.Show("Area You sure to delete ??", "DELETE", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.OK Then
            'remove that row
            DataGridView1.Rows.RemoveAt(DataGridView1.SelectedRows(0).Index)

        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Button6.Visible = True
        GroupBox4.Visible = True
        Button4.Visible = True
        Button7.Visible = True
        Label7.Visible = True
        Label8.Visible = True
        Button6.Visible = False


    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged
        TextBox10.Text = Val(TextBox8.Text) - Val(TextBox7.Text) + Val(TextBox9.Text)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Button3.Visible = True
        Button7.Visible = False
        Button6.Visible = True
        GroupBox4.Visible = False
        Label7.Visible = False
        Label8.Visible = False




    End Sub

End Class