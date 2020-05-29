<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBookingSelect
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBookingSelect))
        Me.rbtBooking1 = New System.Windows.Forms.RadioButton()
        Me.rbtBooking2 = New System.Windows.Forms.RadioButton()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'rbtBooking1
        '
        resources.ApplyResources(Me.rbtBooking1, "rbtBooking1")
        Me.rbtBooking1.Name = "rbtBooking1"
        Me.rbtBooking1.TabStop = True
        Me.rbtBooking1.UseVisualStyleBackColor = True
        '
        'rbtBooking2
        '
        resources.ApplyResources(Me.rbtBooking2, "rbtBooking2")
        Me.rbtBooking2.Name = "rbtBooking2"
        Me.rbtBooking2.TabStop = True
        Me.rbtBooking2.UseVisualStyleBackColor = True
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
        'frmBookingSelect
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.rbtBooking2)
        Me.Controls.Add(Me.rbtBooking1)
        Me.MaximizeBox = False
        Me.Name = "frmBookingSelect"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents rbtBooking1 As RadioButton
    Friend WithEvents rbtBooking2 As RadioButton
    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancel As Button
End Class
