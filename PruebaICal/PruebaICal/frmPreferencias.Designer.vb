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
        Me.tcPreferencias.SuspendLayout()
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
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        resources.ApplyResources(Me.btnCancel, "btnCancel")
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'tcPreferencias
        '
        Me.tcPreferencias.Controls.Add(Me.tbpLanguage)
        Me.tcPreferencias.Controls.Add(Me.tbpLogin)
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
        resources.ApplyResources(Me.tbpLogin, "tbpLogin")
        Me.tbpLogin.Name = "tbpLogin"
        Me.tbpLogin.UseVisualStyleBackColor = True
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
End Class
