<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBookTypeAux
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBookTypeAux))
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbxName = New System.Windows.Forms.TextBox()
        Me.tbxUrlICalendar = New System.Windows.Forms.TextBox()
        Me.tbxUrlWeb = New System.Windows.Forms.TextBox()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.bntCancel = New System.Windows.Forms.Button()
        Me.dgvPrices = New System.Windows.Forms.DataGridView()
        Me.bntEditPrice = New System.Windows.Forms.Button()
        Me.bntDeletePrice = New System.Windows.Forms.Button()
        Me.btnAddPrice = New System.Windows.Forms.Button()
        Me.gbxPrices = New System.Windows.Forms.GroupBox()
        Me.tbxEndDate = New System.Windows.Forms.TextBox()
        Me.tbxStartDate = New System.Windows.Forms.TextBox()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.btnDeleteEndDate = New System.Windows.Forms.Button()
        CType(Me.dgvPrices, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxPrices.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label11
        '
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.Name = "Label11"
        '
        'Label10
        '
        resources.ApplyResources(Me.Label10, "Label10")
        Me.Label10.Name = "Label10"
        '
        'Label9
        '
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.Name = "Label9"
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'tbxName
        '
        resources.ApplyResources(Me.tbxName, "tbxName")
        Me.tbxName.Name = "tbxName"
        '
        'tbxUrlICalendar
        '
        resources.ApplyResources(Me.tbxUrlICalendar, "tbxUrlICalendar")
        Me.tbxUrlICalendar.Name = "tbxUrlICalendar"
        '
        'tbxUrlWeb
        '
        resources.ApplyResources(Me.tbxUrlWeb, "tbxUrlWeb")
        Me.tbxUrlWeb.Name = "tbxUrlWeb"
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        resources.ApplyResources(Me.dtpStartDate, "dtpStartDate")
        Me.dtpStartDate.MinDate = New Date(1971, 1, 1, 0, 0, 0, 0)
        Me.dtpStartDate.Name = "dtpStartDate"
        '
        'btnOK
        '
        resources.ApplyResources(Me.btnOK, "btnOK")
        Me.btnOK.Name = "btnOK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'bntCancel
        '
        resources.ApplyResources(Me.bntCancel, "bntCancel")
        Me.bntCancel.Name = "bntCancel"
        Me.bntCancel.UseVisualStyleBackColor = True
        '
        'dgvPrices
        '
        Me.dgvPrices.AllowUserToAddRows = False
        Me.dgvPrices.AllowUserToDeleteRows = False
        Me.dgvPrices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        resources.ApplyResources(Me.dgvPrices, "dgvPrices")
        Me.dgvPrices.MultiSelect = False
        Me.dgvPrices.Name = "dgvPrices"
        Me.dgvPrices.ReadOnly = True
        Me.dgvPrices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        '
        'bntEditPrice
        '
        resources.ApplyResources(Me.bntEditPrice, "bntEditPrice")
        Me.bntEditPrice.Name = "bntEditPrice"
        Me.bntEditPrice.UseVisualStyleBackColor = True
        '
        'bntDeletePrice
        '
        resources.ApplyResources(Me.bntDeletePrice, "bntDeletePrice")
        Me.bntDeletePrice.Name = "bntDeletePrice"
        Me.bntDeletePrice.UseVisualStyleBackColor = True
        '
        'btnAddPrice
        '
        resources.ApplyResources(Me.btnAddPrice, "btnAddPrice")
        Me.btnAddPrice.Name = "btnAddPrice"
        Me.btnAddPrice.UseVisualStyleBackColor = True
        '
        'gbxPrices
        '
        Me.gbxPrices.Controls.Add(Me.dgvPrices)
        Me.gbxPrices.Controls.Add(Me.bntEditPrice)
        Me.gbxPrices.Controls.Add(Me.btnAddPrice)
        Me.gbxPrices.Controls.Add(Me.bntDeletePrice)
        resources.ApplyResources(Me.gbxPrices, "gbxPrices")
        Me.gbxPrices.Name = "gbxPrices"
        Me.gbxPrices.TabStop = False
        '
        'tbxEndDate
        '
        resources.ApplyResources(Me.tbxEndDate, "tbxEndDate")
        Me.tbxEndDate.Name = "tbxEndDate"
        '
        'tbxStartDate
        '
        resources.ApplyResources(Me.tbxStartDate, "tbxStartDate")
        Me.tbxStartDate.Name = "tbxStartDate"
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        resources.ApplyResources(Me.dtpEndDate, "dtpEndDate")
        Me.dtpEndDate.MinDate = New Date(1971, 1, 1, 0, 0, 0, 0)
        Me.dtpEndDate.Name = "dtpEndDate"
        '
        'btnDeleteEndDate
        '
        resources.ApplyResources(Me.btnDeleteEndDate, "btnDeleteEndDate")
        Me.btnDeleteEndDate.Name = "btnDeleteEndDate"
        Me.btnDeleteEndDate.UseVisualStyleBackColor = True
        '
        'frmBookTypeAux
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnDeleteEndDate)
        Me.Controls.Add(Me.dtpEndDate)
        Me.Controls.Add(Me.tbxStartDate)
        Me.Controls.Add(Me.tbxEndDate)
        Me.Controls.Add(Me.gbxPrices)
        Me.Controls.Add(Me.bntCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.dtpStartDate)
        Me.Controls.Add(Me.tbxUrlWeb)
        Me.Controls.Add(Me.tbxUrlICalendar)
        Me.Controls.Add(Me.tbxName)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label2)
        Me.MaximizeBox = False
        Me.Name = "frmBookTypeAux"
        CType(Me.dgvPrices, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxPrices.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents tbxName As TextBox
    Friend WithEvents tbxUrlICalendar As TextBox
    Friend WithEvents tbxUrlWeb As TextBox
    Friend WithEvents dtpStartDate As DateTimePicker
    Friend WithEvents btnOK As Button
    Friend WithEvents bntCancel As Button
    Friend WithEvents dgvPrices As DataGridView
    Friend WithEvents bntEditPrice As Button
    Friend WithEvents bntDeletePrice As Button
    Friend WithEvents btnAddPrice As Button
    Friend WithEvents gbxPrices As GroupBox
    Friend WithEvents tbxEndDate As TextBox
    Friend WithEvents tbxStartDate As TextBox
    Friend WithEvents dtpEndDate As DateTimePicker
    Friend WithEvents btnDeleteEndDate As Button
End Class
