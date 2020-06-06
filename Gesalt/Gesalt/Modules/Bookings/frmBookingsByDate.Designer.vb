<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBookingsByDate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBookingsByDate))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpCheckin = New System.Windows.Forms.DateTimePicker()
        Me.dtpCheckout = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbxProperties = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbxBookings = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'dtpCheckin
        '
        resources.ApplyResources(Me.dtpCheckin, "dtpCheckin")
        Me.dtpCheckin.Name = "dtpCheckin"
        '
        'dtpCheckout
        '
        resources.ApplyResources(Me.dtpCheckout, "dtpCheckout")
        Me.dtpCheckout.Name = "dtpCheckout"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'cbxProperties
        '
        Me.cbxProperties.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxProperties.FormattingEnabled = True
        resources.ApplyResources(Me.cbxProperties, "cbxProperties")
        Me.cbxProperties.Name = "cbxProperties"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'tbxBookings
        '
        resources.ApplyResources(Me.tbxBookings, "tbxBookings")
        Me.tbxBookings.Name = "tbxBookings"
        Me.tbxBookings.ReadOnly = True
        '
        'frmBookingsByDate
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tbxBookings)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cbxProperties)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpCheckout)
        Me.Controls.Add(Me.dtpCheckin)
        Me.Controls.Add(Me.Label2)
        Me.MaximizeBox = False
        Me.Name = "frmBookingsByDate"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpCheckin As DateTimePicker
    Friend WithEvents dtpCheckout As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cbxProperties As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents tbxBookings As TextBox
End Class
