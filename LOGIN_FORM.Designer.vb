<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LOGIN_FORM
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblLogin = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtBox1 = New System.Windows.Forms.TextBox()
        Me.btnLOGIN = New System.Windows.Forms.Button()
        Me.txtBox2 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(377, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(338, 23)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "VOA INSTITUTE OF TECHNOLOGY"
        '
        'lblLogin
        '
        Me.lblLogin.AutoSize = True
        Me.lblLogin.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLogin.Location = New System.Drawing.Point(487, 57)
        Me.lblLogin.Name = "lblLogin"
        Me.lblLogin.Size = New System.Drawing.Size(120, 21)
        Me.lblLogin.TabIndex = 9
        Me.lblLogin.Text = "LOGIN PAGE"
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.Red
        Me.btnClose.Location = New System.Drawing.Point(272, 128)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(120, 36)
        Me.btnClose.TabIndex = 11
        Me.btnClose.Text = "CLOSE"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.student_form.My.Resources.Resources.V_O_A_LOGO
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Controls.Add(Me.txtBox1)
        Me.Panel1.Controls.Add(Me.btnLOGIN)
        Me.Panel1.Controls.Add(Me.txtBox2)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(355, 94)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(419, 235)
        Me.Panel1.TabIndex = 10
        '
        'txtBox1
        '
        Me.txtBox1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBox1.Location = New System.Drawing.Point(151, 32)
        Me.txtBox1.Multiline = True
        Me.txtBox1.Name = "txtBox1"
        Me.txtBox1.Size = New System.Drawing.Size(241, 28)
        Me.txtBox1.TabIndex = 4
        Me.txtBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnLOGIN
        '
        Me.btnLOGIN.BackColor = System.Drawing.Color.Transparent
        Me.btnLOGIN.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLOGIN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnLOGIN.Location = New System.Drawing.Point(150, 128)
        Me.btnLOGIN.Name = "btnLOGIN"
        Me.btnLOGIN.Size = New System.Drawing.Size(116, 33)
        Me.btnLOGIN.TabIndex = 2
        Me.btnLOGIN.Text = "LOGIN"
        Me.btnLOGIN.UseVisualStyleBackColor = False
        '
        'txtBox2
        '
        Me.txtBox2.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBox2.Location = New System.Drawing.Point(150, 75)
        Me.txtBox2.Multiline = True
        Me.txtBox2.Name = "txtBox2"
        Me.txtBox2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtBox2.Size = New System.Drawing.Size(242, 27)
        Me.txtBox2.TabIndex = 5
        Me.txtBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(22, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 21)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "PASSWORD"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(23, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 21)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "USERNAME"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.CornflowerBlue
        Me.Panel2.BackgroundImage = Global.student_form.My.Resources.Resources.login_icon_png_27
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel2.Location = New System.Drawing.Point(3, -1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(334, 371)
        Me.Panel2.TabIndex = 1
        '
        'LOGIN_FORM
        '
        Me.AcceptButton = Me.btnLOGIN
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(801, 373)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblLogin)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LOGIN_FORM"
        Me.Text = "LOGIN_FORM"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnLOGIN As System.Windows.Forms.Button
    Friend WithEvents txtBox1 As System.Windows.Forms.TextBox
    Friend WithEvents txtBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblLogin As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class
