<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBookingsByGuest
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBookingsByGuest))
        Me.lblSelect = New System.Windows.Forms.Label()
        Me.cbxSelect = New System.Windows.Forms.ComboBox()
        Me.cbxProps = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblBookings = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblSelect
        '
        resources.ApplyResources(Me.lblSelect, "lblSelect")
        Me.lblSelect.Name = "lblSelect"
        '
        'cbxSelect
        '
        Me.cbxSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxSelect.FormattingEnabled = True
        resources.ApplyResources(Me.cbxSelect, "cbxSelect")
        Me.cbxSelect.Name = "cbxSelect"
        '
        'cbxProps
        '
        Me.cbxProps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxProps.FormattingEnabled = True
        resources.ApplyResources(Me.cbxProps, "cbxProps")
        Me.cbxProps.Name = "cbxProps"
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
        'lblBookings
        '
        Me.lblBookings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.lblBookings, "lblBookings")
        Me.lblBookings.Name = "lblBookings"
        '
        'frmBookingsByGuest
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblBookings)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbxProps)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbxSelect)
        Me.Controls.Add(Me.lblSelect)
        Me.MaximizeBox = False
        Me.Name = "frmBookingsByGuest"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblSelect As Label
    Friend WithEvents cbxSelect As ComboBox
    Friend WithEvents cbxProps As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblBookings As Label
End Class
