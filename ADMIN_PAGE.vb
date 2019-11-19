Public Class ADMIN_PAGE

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        STAFF_PAGE.Show()
        Me.Close()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        ACADEMIC_REPORT.Show()
        Me.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        REPORTS_PAGE.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LOGIN_FORM.Show()
        Me.Close()
    End Sub

    Private Sub ADMIN_PAGE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        CHANGE_PASSWORD.Show()
        Me.Close()

    End Sub
End Class