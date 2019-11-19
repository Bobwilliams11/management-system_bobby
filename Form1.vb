Imports MySql.Data.MySqlClient

Public Class frmSTUDENT
    Dim connection As MySqlConnection
    Dim READER As MySqlDataReader
    Dim command As MySqlCommand
    Dim loadimagesStr As Boolean = False
    Dim IMG_Filenameinput As String
    Dim statusinput As String = "save"
    Dim mysqlconn As New MySqlConnection
    Dim dt As New DataTable



    Private SelectedCourses As Dictionary(Of String, Double)
    Private AllCourses As Dictionary(Of String, Double)

    Private Sub frm_load()
        connection = New MySqlConnection

        connection.ConnectionString = "server=localhost; userid=root; password=''; database=voa"

        Dim sda As New MySqlDataAdapter
        Dim bs As New BindingSource
        Try
            connection.Open()
            Dim query As String
            query = "Select * From voa.student_information"
            command = New MySqlCommand(query, connection)
            sda.SelectCommand = command

            connection.Close()
        Catch ex As MySqlException
        Finally
            connection.Dispose()
        End Try

    End Sub
 
    Private Sub price()
        connection = New MySqlConnection
        connection.ConnectionString = "server=localhost; userid=root; password=''; database=voa;database=voa;"
        Dim reader As MySqlDataReader
        Try
            connection.Open()
            Dim query As String = "SELECT price FROM voa.add_course where course_name='" & cmbAllPrograms.Text & "'"

            command = New MySqlCommand(query, connection)

            reader = command.ExecuteReader
            While reader.Read
                txtGrandTotal.Text = reader.GetInt32("price")
                Dim name = reader.GetString("course_name")
                cmbAllPrograms.Items.Add(Name)

            End While
            connection.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub autogenerate()
        Try
            connection.ConnectionString = "server=localhost; userid=root; password=''; database=voa;database=voa;"
            command.Connection = connection
            connection.Open()
            Dim number As Integer
            command.CommandText = "select max(student_id) from student_information"
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
        Catch ex As Exception
            'connection.Close()

        End Try
    End Sub

  
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        table_load()


        LoadAllPrograms()
        SelectedCourses = New Dictionary(Of String, Double)
        AllCourses = New Dictionary(Of String, Double)
        TextBox1.Visible = False
    End Sub



    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        MAIN_PAGE.Show()
        Me.Hide()
    End Sub
    Private Sub table_load()
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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        autogenerate()

        Dim READER As MySqlDataReader
        connection = New MySqlConnection
        connection.ConnectionString = "server=localhost; userid=root; password=''; database=voa"
        Dim lastID As Integer = GetLastStudentID()
        Dim stdID = "VOA " & lastID
        Dim myCourses As String = ""
        Dim comma As String = " , "
        For i As Integer = 0 To lbxSelectedCourse.Items.Count - 1
            If i = lbxSelectedCourse.Items.Count - 1 Then
                comma = ""
            End If
            myCourses += lbxSelectedCourse.Items.Item(i).ToString & comma
        Next
        Try
            connection.Open()
            Dim query As String = "INSERT INTO `student_information`(`student_id`, `image`, `first_name`, `middle_name`, `last_name`, `gender`, `date_of_birth`, `nationality`, `marital_status`, `level_of_education`, `occupation`, `mobile_number`, `telephone_number`, `email`, `residence`, `house_number`, `guardian_name`, `emergency_name`, `emergency_contact`, `courses`) VALUES ('" & stdID & "','" & imageName & "','" & TextBox2.Text & "', '" & TextBox3.Text & "','" & TextBox4.Text & "','" & ComboBox1.Text & "','" & TextBox6.Text & "','" & TextBox25.Text & "','" & ComboBox3.Text & "','" & TextBox26.Text & "','" & TextBox10.Text & "','" & TextBox11.Text & "','" & TextBox12.Text & "','" & TextBox13.Text & "','" & TextBox14.Text & "','" & TextBox15.Text & "','" & TextBox18.Text & "','" & TextBox19.Text & "','" & TextBox20.Text & "','" & myCourses & "')"
            command = New MySqlCommand(query, connection)
            READER = command.ExecuteReader
            MessageBox.Show("Save successfully")
            connection.Close()
            TextBox1.Text = ""
            PictureBox1.ImageLocation = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            ComboBox1.Text = ""
            TextBox6.Text = ""
            TextBox25.Text = ""
            ComboBox3.Text = ""
            TextBox26.Text = ""
            TextBox10.Text = ""
            TextBox11.Text = ""
            TextBox12.Text = ""
            TextBox13.Text = ""
            TextBox14.Text = ""
            TextBox15.Text = ""
            TextBox18.Text = ""
            TextBox19.Text = ""
            TextBox20.Text = ""
            cmbAllPrograms.Text = ""
            lbxAllCourse.Text = ""
            lbxSelectedCourse.Text = ""
            txtGrandTotal.Text = ""

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            connection.Dispose()
        End Try
        connection.Open()
        frm_load()
        table_load()
        connection.Close()
        IncreaseStudentID()
    End Sub

    Dim imageName As String = ""
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim userpicname As String
        With OpenFileDialog1
            .Title = "select a jpeg image"
            .Filter = "All files|*.JPG"
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyPictures
            .FileName = ""
            .Multiselect = False
            .ShowDialog()

            If .FileName = "" Then
                Exit Sub

            Else
                Try
                    My.Computer.FileSystem.CopyFile(.FileName, My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData & "\photos\" & .SafeFileName.ToString, True)
                    userPicName = .SafeFileName
                    PictureBox1.ImageLocation = UploadImagePath & "\" & .SafeFileName
                    imageName = .SafeFileName
                Catch ex As Exception
                    '  MsgBox(ex.Message)
                End Try
            End If


        End With
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Delete_Click(sender As Object, e As EventArgs)
        If TextBox1.Text = "" Then
            MsgBox("Please enter student_id to delete")
        Else
            connection = New MySqlConnection
            connection.ConnectionString = "server=localhost; userid=root; password=''; database=voa;"

            Dim READER As MySqlDataReader
            Try
                connection.Open()
                Dim query As String = "delete from voa. student_information where student_id='" & TextBox1.Text & "'"
                command = New MySqlCommand(query, connection)
                READER = command.ExecuteReader
                MessageBox.Show("Data Delete Sucessfully")
                connection.Close()
                TextBox1.Text = ""
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                connection.Dispose()
            End Try
        End If
        frm_load()
    End Sub

    Private Sub Close_Click(sender As Object, e As EventArgs) Handles Close.Click
        Application.Exit()
    End Sub

    Private Sub LoadAllPrograms()
        sqlStatement = "SELECT * FROM programs_tb"
        Dim dt As DataTable = ExecuteSQL(sqlStament:=sqlStatement)
        cmbAllPrograms.DataSource = dt
        cmbAllPrograms.DisplayMember = "program_name"
        cmbAllPrograms.ValueMember = "id"
    End Sub

    Private Sub cmbAllPrograms_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAllPrograms.SelectedIndexChanged
        GetCourses()
    End Sub

    Private Sub GetCourses()
        If cmbAllPrograms.Items.Count > 0 Then
            Try
                sqlStatement = "SELECT * FROM courses_tb WHERE program_id = " & cmbAllPrograms.SelectedValue
                Dim dt As DataTable = ExecuteSQL(sqlStament:=sqlStatement)
                If AllCourses.Count > 0 Then AllCourses.Clear()
                For i As Integer = 0 To dt.Rows.Count - 1
                    AllCourses.Add(dt.Rows(i).Item("course_name"), dt.Rows(i).Item("price"))
                    LoadAllCourses()
                Next
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub LoadAllCourses()
        lbxAllCourse.Items.Clear()
        For Each course In AllCourses
            lbxAllCourse.Items.Add(course.Key)
        Next
        GetTotalPrice()
    End Sub
    Private Sub LoadSelectedCourses()
        lbxSelectedCourse.Items.Clear()
        For Each course In SelectedCourses
            lbxSelectedCourse.Items.Add(course.Key)
        Next
        GetTotalPrice()
    End Sub

    Private Sub AddSelectedCourse()
        Try
            Dim course = lbxAllCourse.Text
            SelectedCourses.Add(course, AllCourses.Item(course))
            AllCourses.Remove(course)
            LoadSelectedCourses()
            LoadAllCourses()
        Catch ex As Exception
        End Try
    End Sub



    Private Sub AddAllCourse()
        GetCourses()
        SelectedCourses.Clear()
       For Each item In AllCourses
            SelectedCourses.Add(item.Key, item.Value)
        Next
        LoadSelectedCourses()
        AllCourses.Clear()
        LoadAllCourses()
    End Sub




    Private Sub RemoveSelectedCourse()
        Try
            Dim course = lbxSelectedCourse.Text
            If AllCourses.ContainsKey(course) = False Then AllCourses.Add(course, SelectedCourses.Item(course))
            SelectedCourses.Remove(course)
            LoadSelectedCourses()
            LoadAllCourses()
        Catch ex As Exception
        End Try

    End Sub



    Private Sub RemoveAllCourse()
        GetCourses()
        LoadAllCourses()
        SelectedCourses.Clear()
        LoadSelectedCourses()
    End Sub


    Private Sub GetTotalPrice()
        Dim total As Double = 0.0
        For Each course In SelectedCourses
            total += course.Value
        Next
        txtGrandTotal.Text = total.ToString
    End Sub




    Private Sub btnAddSelectedCourse_Click(sender As Object, e As EventArgs) Handles btnAddSelectedCourse.Click
        AddSelectedCourse()
    End Sub

    Private Sub btnAddAllCourse_Click(sender As Object, e As EventArgs) Handles btnAddAllCourse.Click
        AddAllCourse()
    End Sub

    Private Sub btnRemoveSelectedCourse_Click(sender As Object, e As EventArgs) Handles btnRemoveSelectedCourse.Click
        RemoveSelectedCourse()
    End Sub

    Private Sub btnRemoveAllCourses_Click(sender As Object, e As EventArgs) Handles btnRemoveAllCourses.Click
        RemoveAllCourse()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Search_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        Dim dv As New DataView(dt)
        dv.RowFilter = String.Format("student_id like '%{0}%'", TextBox5.Text)
        DataGridView1.DataSource = dv
    End Sub
End Class
