<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMail))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.tbxCancel = New System.Windows.Forms.Button()
        Me.tbxSubject = New System.Windows.Forms.TextBox()
        Me.rtbMessage = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'btnSend
        '
        resources.ApplyResources(Me.btnSend, "btnSend")
        Me.btnSend.Name = "btnSend"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'tbxCancel
        '
        resources.ApplyResources(Me.tbxCancel, "tbxCancel")
        Me.tbxCancel.Name = "tbxCancel"
        Me.tbxCancel.UseVisualStyleBackColor = True
        '
        'tbxSubject
        '
        resources.ApplyResources(Me.tbxSubject, "tbxSubject")
        Me.tbxSubject.Name = "tbxSubject"
        '
        'rtbMessage
        '
        resources.ApplyResources(Me.rtbMessage, "rtbMessage")
        Me.rtbMessage.Name = "rtbMessage"
        '
        'frmMail
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.rtbMessage)
        Me.Controls.Add(Me.tbxSubject)
        Me.Controls.Add(Me.tbxCancel)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.Name = "frmMail"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnSend As Button
    Friend WithEvents tbxCancel As Button
    Friend WithEvents tbxSubject As TextBox
    Friend WithEvents rtbMessage As RichTextBox
End Class
