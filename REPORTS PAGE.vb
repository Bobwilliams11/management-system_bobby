Public Class REPORTS_PAGE

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ADMIN_PAGE.Show()
        Me.Close()
    End Sub

    Private Sub REPORTS_PAGE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        INCOME_REPORT_FORM.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        'EXPENSES_REPORT_FORM.Show()
        'Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        ' MONTHLY_REPORT_FORM.Show()
        ' Me.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        STUDENT_REPORT_FORM.Show()
        Me.Hide()
    End Sub
End Class