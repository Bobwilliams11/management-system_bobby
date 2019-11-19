Public Class TRANSACTIONS
    Private Sub LoadDGV()
        sqlStatement = "SELECT * FROM transaction_tb"
        DataGridView1.DataSource = ExecuteSQL(sqlStament:=sqlStatement)
    End Sub


  
    Private Sub cmbType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbType.SelectedIndexChanged
        If cmbType.Text = "Income" Then
            cmbCategory.DataSource = incomeCategories
            rdbStudent.Enabled = True
            rdbStudent.Checked = False
            rdbOther.Enabled = True
            rdbOther.Checked = False
            rdbFromUs.Enabled = False
            rdbFromUs.Checked = False
        Else
            rdbStudent.Enabled = False
            rdbStudent.Checked = False
            rdbOther.Enabled = False
            rdbOther.Checked = False
            rdbFromUs.Enabled = True
            rdbFromUs.Checked = True
            cmbPersonName.Text = "VOA Institute Of Technology"
            cmbCategory.DataSource = expensesCategories
            If cmbPersonName.Items.Count > 0 Then cmbPersonName.Items.Clear()
               End If
    End Sub

    Dim transFrom As String = ""
    Private Sub rdbFrom_CheckedChanged(sender As Object, e As EventArgs) Handles rdbStudent.CheckedChanged, rdbOther.CheckedChanged, rdbFromUs.CheckedChanged, rdbFromUs.CheckedChanged

        If rdbStudent.Checked = True Then
            transFrom = "Student"
            txbTo.Text = "VOA Institute Of Technology"
            txbTo.ReadOnly = True
            cmbPersonName.Text = ""
            sqlStatement = "SELECT student_id FROM  student_information"
            cmbPersonName.Enabled = True
            Dim autoCompleteStrCol As AutoCompleteStringCollection = New AutoCompleteStringCollection
            Dim dt As DataTable = ExecuteSQL(sqlStament:=sqlStatement)
            If cmbPersonName.Items.Count > 0 Then cmbPersonName.Items.Clear()
            For Each row As DataRow In dt.Rows
                autoCompleteStrCol.Add(row.Item(0))
                cmbPersonName.Items.Add(row.Item(0))
            Next
            cmbPersonName.AutoCompleteSource = Windows.Forms.AutoCompleteSource.CustomSource
            cmbPersonName.AutoCompleteMode = AutoCompleteMode.Suggest
            cmbPersonName.AutoCompleteCustomSource = autoCompleteStrCol
        ElseIf rdbOther.Checked = True Then
            transFrom = "Others"
            txbTo.Clear()
            txbTo.ReadOnly = False
            cmbPersonName.Enabled = True
            If cmbPersonName.Items.Count > 0 Then cmbPersonName.Items.Clear()
            cmbPersonName.Text = ""

        ElseIf rdbFromUs.Checked = True Then
            transFrom = "Us"
            If cmbPersonName.Items.Count > 0 Then cmbPersonName.Items.Clear()
            cmbPersonName.Text = "VOA Institute Of Technology"
            cmbPersonName.Enabled = False
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        AddParams("@trans_date", Now.Date)
        AddParams("@amount", txbAmount.Text)
        AddParams("@trans_type", cmbType.Text)
        AddParams("@category", cmbCategory.Text)
        AddParams("trans_from", transFrom)
        AddParams("@person_name", cmbPersonName.Text)
        AddParams("@trans_to", txbTo.Text)
        AddParams("@purpose", txbPurpose.Text)
        sqlStatement = "INSERT INTO transaction_tb(trans_date, amount, trans_type, category, trans_from, person_name, trans_to, purpose)" &
                                         "VALUES (@trans_date ,@amount , @trans_type , @category , @trans_from , @person_name , @trans_to , @purpose )"
        ExecuteSQL(sqlStament:=sqlStatement)
        MessageBox.Show("Data Save Successfully")
        LoadDGV()
    End Sub

    Private Sub TRANSACTIONS_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadDGV()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MAIN_PAGE.Show()
        Me.Close()

    End Sub

    Private Sub SplitContainer1_Panel1_Paint(sender As Object, e As PaintEventArgs) Handles SplitContainer1.Panel1.Paint

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class