<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPreferencias
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPreferencias))
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.tcPreferencias = New System.Windows.Forms.TabControl()
        Me.tbpLanguage = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rbEnglish = New System.Windows.Forms.RadioButton()
        Me.rbSpanish = New System.Windows.Forms.RadioButton()
        Me.rbGalician = New System.Windows.Forms.RadioButton()
        Me.lblIdioma = New System.Windows.Forms.Label()
        Me.tbpLogin = New System.Windows.Forms.TabPage()
        Me.btnTestCon = New System.Windows.Forms.Button()
        Me.nudPort = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbxServer = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.nudSSHPort = New System.Windows.Forms.NumericUpDown()
        Me.tbxSSHPass = New System.Windows.Forms.TextBox()
        Me.lblSSHPort = New System.Windows.Forms.Label()
        Me.tbxSSHHost = New System.Windows.Forms.TextBox()
        Me.tbxSSHName = New System.Windows.Forms.TextBox()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.lblSSHPassword = New System.Windows.Forms.Label()
        Me.lblHostName = New System.Windows.Forms.Label()
        Me.cbxSSH = New System.Windows.Forms.CheckBox()
        Me.tbxPass = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbxUser = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.tcPreferencias.SuspendLayout()
        Me.tbpLanguage.SuspendLayout()
        Me.tbpLogin.SuspendLayout()
        CType(Me.nudPort, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.nudSSHPort, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        resources.ApplyResources(Me.btnOK, "btnOK")
        Me.btnOK.Name = "btnOK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        resources.ApplyResources(Me.btnCancel, "btnCancel")
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'tcPreferencias
        '
        Me.tcPreferencias.Controls.Add(Me.tbpLanguage)
        Me.tcPreferencias.Controls.Add(Me.tbpLogin)
        Me.tcPreferencias.Controls.Add(Me.TabPage1)
        resources.ApplyResources(Me.tcPreferencias, "tcPreferencias")
        Me.tcPreferencias.Name = "tcPreferencias"
        Me.tcPreferencias.SelectedIndex = 0
        '
        'tbpLanguage
        '
        Me.tbpLanguage.Controls.Add(Me.Label1)
        Me.tbpLanguage.Controls.Add(Me.rbEnglish)
        Me.tbpLanguage.Controls.Add(Me.rbSpanish)
        Me.tbpLanguage.Controls.Add(Me.rbGalician)
        Me.tbpLanguage.Controls.Add(Me.lblIdioma)
        resources.ApplyResources(Me.tbpLanguage, "tbpLanguage")
        Me.tbpLanguage.Name = "tbpLanguage"
        Me.tbpLanguage.UseVisualStyleBackColor = True
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'rbEnglish
        '
        resources.ApplyResources(Me.rbEnglish, "rbEnglish")
        Me.rbEnglish.Name = "rbEnglish"
        Me.rbEnglish.TabStop = True
        Me.rbEnglish.UseVisualStyleBackColor = True
        '
        'rbSpanish
        '
        resources.ApplyResources(Me.rbSpanish, "rbSpanish")
        Me.rbSpanish.Name = "rbSpanish"
        Me.rbSpanish.TabStop = True
        Me.rbSpanish.UseVisualStyleBackColor = True
        '
        'rbGalician
        '
        resources.ApplyResources(Me.rbGalician, "rbGalician")
        Me.rbGalician.Name = "rbGalician"
        Me.rbGalician.TabStop = True
        Me.rbGalician.UseVisualStyleBackColor = True
        '
        'lblIdioma
        '
        resources.ApplyResources(Me.lblIdioma, "lblIdioma")
        Me.lblIdioma.Name = "lblIdioma"
        '
        'tbpLogin
        '
        Me.tbpLogin.Controls.Add(Me.btnTestCon)
        Me.tbpLogin.Controls.Add(Me.nudPort)
        Me.tbpLogin.Controls.Add(Me.Label5)
        Me.tbpLogin.Controls.Add(Me.tbxServer)
        Me.tbpLogin.Controls.Add(Me.Label4)
        Me.tbpLogin.Controls.Add(Me.Panel1)
        Me.tbpLogin.Controls.Add(Me.cbxSSH)
        Me.tbpLogin.Controls.Add(Me.tbxPass)
        Me.tbpLogin.Controls.Add(Me.Label3)
        Me.tbpLogin.Controls.Add(Me.tbxUser)
        Me.tbpLogin.Controls.Add(Me.Label2)
        resources.ApplyResources(Me.tbpLogin, "tbpLogin")
        Me.tbpLogin.Name = "tbpLogin"
        Me.tbpLogin.UseVisualStyleBackColor = True
        '
        'btnTestCon
        '
        resources.ApplyResources(Me.btnTestCon, "btnTestCon")
        Me.btnTestCon.Name = "btnTestCon"
        Me.btnTestCon.UseVisualStyleBackColor = True
        '
        'nudPort
        '
        resources.ApplyResources(Me.nudPort, "nudPort")
        Me.nudPort.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.nudPort.Name = "nudPort"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'tbxServer
        '
        resources.ApplyResources(Me.tbxServer, "tbxServer")
        Me.tbxServer.Name = "tbxServer"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.nudSSHPort)
        Me.Panel1.Controls.Add(Me.tbxSSHPass)
        Me.Panel1.Controls.Add(Me.lblSSHPort)
        Me.Panel1.Controls.Add(Me.tbxSSHHost)
        Me.Panel1.Controls.Add(Me.tbxSSHName)
        Me.Panel1.Controls.Add(Me.lblUserName)
        Me.Panel1.Controls.Add(Me.lblSSHPassword)
        Me.Panel1.Controls.Add(Me.lblHostName)
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
        '
        'nudSSHPort
        '
        resources.ApplyResources(Me.nudSSHPort, "nudSSHPort")
        Me.nudSSHPort.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.nudSSHPort.Name = "nudSSHPort"
        '
        'tbxSSHPass
        '
        resources.ApplyResources(Me.tbxSSHPass, "tbxSSHPass")
        Me.tbxSSHPass.Name = "tbxSSHPass"
        Me.tbxSSHPass.UseSystemPasswordChar = True
        '
        'lblSSHPort
        '
        resources.ApplyResources(Me.lblSSHPort, "lblSSHPort")
        Me.lblSSHPort.Name = "lblSSHPort"
        '
        'tbxSSHHost
        '
        resources.ApplyResources(Me.tbxSSHHost, "tbxSSHHost")
        Me.tbxSSHHost.Name = "tbxSSHHost"
        '
        'tbxSSHName
        '
        resources.ApplyResources(Me.tbxSSHName, "tbxSSHName")
        Me.tbxSSHName.Name = "tbxSSHName"
        '
        'lblUserName
        '
        resources.ApplyResources(Me.lblUserName, "lblUserName")
        Me.lblUserName.Name = "lblUserName"
        '
        'lblSSHPassword
        '
        resources.ApplyResources(Me.lblSSHPassword, "lblSSHPassword")
        Me.lblSSHPassword.Name = "lblSSHPassword"
        '
        'lblHostName
        '
        resources.ApplyResources(Me.lblHostName, "lblHostName")
        Me.lblHostName.Name = "lblHostName"
        '
        'cbxSSH
        '
        resources.ApplyResources(Me.cbxSSH, "cbxSSH")
        Me.cbxSSH.Name = "cbxSSH"
        Me.cbxSSH.UseVisualStyleBackColor = True
        '
        'tbxPass
        '
        resources.ApplyResources(Me.tbxPass, "tbxPass")
        Me.tbxPass.Name = "tbxPass"
        Me.tbxPass.UseSystemPasswordChar = True
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'tbxUser
        '
        resources.ApplyResources(Me.tbxUser, "tbxUser")
        Me.tbxUser.Name = "tbxUser"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'TabPage1
        '
        resources.ApplyResources(Me.TabPage1, "TabPage1")
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'frmPreferencias
        '
        Me.AcceptButton = Me.btnOK
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.Controls.Add(Me.tcPreferencias)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmPreferencias"
        Me.tcPreferencias.ResumeLayout(False)
        Me.tbpLanguage.ResumeLayout(False)
        Me.tbpLanguage.PerformLayout()
        Me.tbpLogin.ResumeLayout(False)
        Me.tbpLogin.PerformLayout()
        CType(Me.nudPort, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.nudSSHPort, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents tcPreferencias As TabControl
    Friend WithEvents tbpLanguage As TabPage
    Friend WithEvents tbpLogin As TabPage
    Friend WithEvents rbEnglish As RadioButton
    Friend WithEvents rbSpanish As RadioButton
    Friend WithEvents rbGalician As RadioButton
    Friend WithEvents lblIdioma As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents tbxUser As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tbxPass As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents tbxServer As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents tbxSSHHost As TextBox
    Friend WithEvents tbxSSHName As TextBox
    Friend WithEvents lblUserName As Label
    Private WithEvents lblSSHPassword As Label
    Friend WithEvents lblHostName As Label
    Friend WithEvents cbxSSH As CheckBox
    Friend WithEvents tbxSSHPass As TextBox
    Friend WithEvents lblSSHPort As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents nudPort As NumericUpDown
    Friend WithEvents nudSSHPort As NumericUpDown
    Friend WithEvents btnTestCon As Button
    Friend WithEvents TabPage1 As TabPage
End Class
