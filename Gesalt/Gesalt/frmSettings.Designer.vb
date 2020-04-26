<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSettings
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSettings))
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.tcPreferencias = New System.Windows.Forms.TabControl()
        Me.tbpLogin = New System.Windows.Forms.TabPage()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.rbServer = New System.Windows.Forms.RadioButton()
        Me.rbLocal = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblServerSettings = New System.Windows.Forms.Label()
        Me.nudPort = New System.Windows.Forms.NumericUpDown()
        Me.btnTestCon = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.nudSSHPort = New System.Windows.Forms.NumericUpDown()
        Me.tbxSSHPass = New System.Windows.Forms.TextBox()
        Me.lblSSHPort = New System.Windows.Forms.Label()
        Me.tbxSSHHost = New System.Windows.Forms.TextBox()
        Me.tbxSSHName = New System.Windows.Forms.TextBox()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.lblSSHPassword = New System.Windows.Forms.Label()
        Me.lblHostName = New System.Windows.Forms.Label()
        Me.tbxServer = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbxSSH = New System.Windows.Forms.CheckBox()
        Me.tbxPass = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbxUser = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbpLanguage = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rbEnglish = New System.Windows.Forms.RadioButton()
        Me.rbSpanish = New System.Windows.Forms.RadioButton()
        Me.rbGalician = New System.Windows.Forms.RadioButton()
        Me.lblIdioma = New System.Windows.Forms.Label()
        Me.tcPreferencias.SuspendLayout()
        Me.tbpLogin.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.nudPort, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.nudSSHPort, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpLanguage.SuspendLayout()
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
        resources.ApplyResources(Me.btnCancel, "btnCancel")
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'tcPreferencias
        '
        Me.tcPreferencias.Controls.Add(Me.tbpLogin)
        Me.tcPreferencias.Controls.Add(Me.tbpLanguage)
        resources.ApplyResources(Me.tcPreferencias, "tcPreferencias")
        Me.tcPreferencias.Name = "tcPreferencias"
        Me.tcPreferencias.SelectedIndex = 0
        '
        'tbpLogin
        '
        Me.tbpLogin.Controls.Add(Me.Label6)
        Me.tbpLogin.Controls.Add(Me.rbServer)
        Me.tbpLogin.Controls.Add(Me.rbLocal)
        Me.tbpLogin.Controls.Add(Me.Panel2)
        resources.ApplyResources(Me.tbpLogin, "tbpLogin")
        Me.tbpLogin.Name = "tbpLogin"
        Me.tbpLogin.UseVisualStyleBackColor = True
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'rbServer
        '
        resources.ApplyResources(Me.rbServer, "rbServer")
        Me.rbServer.Name = "rbServer"
        Me.rbServer.TabStop = True
        Me.rbServer.UseVisualStyleBackColor = True
        '
        'rbLocal
        '
        resources.ApplyResources(Me.rbLocal, "rbLocal")
        Me.rbLocal.Name = "rbLocal"
        Me.rbLocal.TabStop = True
        Me.rbLocal.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.lblServerSettings)
        Me.Panel2.Controls.Add(Me.nudPort)
        Me.Panel2.Controls.Add(Me.btnTestCon)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Controls.Add(Me.tbxServer)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.cbxSSH)
        Me.Panel2.Controls.Add(Me.tbxPass)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.tbxUser)
        Me.Panel2.Controls.Add(Me.Label2)
        resources.ApplyResources(Me.Panel2, "Panel2")
        Me.Panel2.Name = "Panel2"
        '
        'lblServerSettings
        '
        resources.ApplyResources(Me.lblServerSettings, "lblServerSettings")
        Me.lblServerSettings.Name = "lblServerSettings"
        '
        'nudPort
        '
        resources.ApplyResources(Me.nudPort, "nudPort")
        Me.nudPort.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.nudPort.Name = "nudPort"
        '
        'btnTestCon
        '
        resources.ApplyResources(Me.btnTestCon, "btnTestCon")
        Me.btnTestCon.Name = "btnTestCon"
        Me.btnTestCon.UseVisualStyleBackColor = True
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
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
        'frmPreferencias
        '
        Me.AcceptButton = Me.btnOK
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tcPreferencias)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmPreferencias"
        Me.tcPreferencias.ResumeLayout(False)
        Me.tbpLogin.ResumeLayout(False)
        Me.tbpLogin.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.nudPort, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.nudSSHPort, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpLanguage.ResumeLayout(False)
        Me.tbpLanguage.PerformLayout()
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
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents rbServer As RadioButton
    Friend WithEvents rbLocal As RadioButton
    Friend WithEvents lblServerSettings As Label
End Class
