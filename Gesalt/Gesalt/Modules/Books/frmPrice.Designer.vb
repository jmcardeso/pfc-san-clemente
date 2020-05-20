<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrice
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrice))
        Me.cbxType = New System.Windows.Forms.ComboBox()
        Me.gbxPrice = New System.Windows.Forms.GroupBox()
        Me.nudValue = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.bntCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.cbxPercentage = New System.Windows.Forms.CheckBox()
        Me.gbxPrice.SuspendLayout()
        CType(Me.nudValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbxType
        '
        Me.cbxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxType.FormattingEnabled = True
        resources.ApplyResources(Me.cbxType, "cbxType")
        Me.cbxType.Name = "cbxType"
        '
        'gbxPrice
        '
        Me.gbxPrice.Controls.Add(Me.cbxPercentage)
        Me.gbxPrice.Controls.Add(Me.nudValue)
        resources.ApplyResources(Me.gbxPrice, "gbxPrice")
        Me.gbxPrice.Name = "gbxPrice"
        Me.gbxPrice.TabStop = False
        '
        'nudValue
        '
        resources.ApplyResources(Me.nudValue, "nudValue")
        Me.nudValue.Name = "nudValue"
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
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'dtpStartDate
        '
        resources.ApplyResources(Me.dtpStartDate, "dtpStartDate")
        Me.dtpStartDate.Name = "dtpStartDate"
        '
        'dtpEndDate
        '
        resources.ApplyResources(Me.dtpEndDate, "dtpEndDate")
        Me.dtpEndDate.Name = "dtpEndDate"
        '
        'bntCancel
        '
        resources.ApplyResources(Me.bntCancel, "bntCancel")
        Me.bntCancel.Name = "bntCancel"
        Me.bntCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        resources.ApplyResources(Me.btnOK, "btnOK")
        Me.btnOK.Name = "btnOK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'cbxPercentage
        '
        resources.ApplyResources(Me.cbxPercentage, "cbxPercentage")
        Me.cbxPercentage.Name = "cbxPercentage"
        Me.cbxPercentage.UseVisualStyleBackColor = True
        '
        'frmPrice
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.bntCancel)
        Me.Controls.Add(Me.dtpEndDate)
        Me.Controls.Add(Me.dtpStartDate)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.gbxPrice)
        Me.Controls.Add(Me.cbxType)
        Me.MaximizeBox = False
        Me.Name = "frmPrice"
        Me.gbxPrice.ResumeLayout(False)
        Me.gbxPrice.PerformLayout()
        CType(Me.nudValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cbxType As ComboBox
    Friend WithEvents gbxPrice As GroupBox
    Friend WithEvents nudValue As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dtpStartDate As DateTimePicker
    Friend WithEvents dtpEndDate As DateTimePicker
    Friend WithEvents bntCancel As Button
    Friend WithEvents btnOK As Button
    Friend WithEvents cbxPercentage As CheckBox
End Class
