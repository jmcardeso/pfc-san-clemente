<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBook
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBook))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblProperty = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbxBookTypes = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbxGuests = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpCheckout = New System.Windows.Forms.DateTimePicker()
        Me.dtpCheckin = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbxStatus = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblAmount = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblVat = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.mclCalendar = New System.Windows.Forms.MonthCalendar()
        Me.btnCalculatePrice = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tbxInvoiceNumber = New System.Windows.Forms.TextBox()
        Me.btnPrintInvoice = New System.Windows.Forms.Button()
        Me.lblVATPercent = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'lblProperty
        '
        resources.ApplyResources(Me.lblProperty, "lblProperty")
        Me.lblProperty.Name = "lblProperty"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'cbxBookTypes
        '
        Me.cbxBookTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxBookTypes.FormattingEnabled = True
        resources.ApplyResources(Me.cbxBookTypes, "cbxBookTypes")
        Me.cbxBookTypes.Name = "cbxBookTypes"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'cbxGuests
        '
        Me.cbxGuests.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxGuests.FormattingEnabled = True
        resources.ApplyResources(Me.cbxGuests, "cbxGuests")
        Me.cbxGuests.Name = "cbxGuests"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'dtpCheckout
        '
        resources.ApplyResources(Me.dtpCheckout, "dtpCheckout")
        Me.dtpCheckout.Name = "dtpCheckout"
        '
        'dtpCheckin
        '
        resources.ApplyResources(Me.dtpCheckin, "dtpCheckin")
        Me.dtpCheckin.Name = "dtpCheckin"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'cbxStatus
        '
        Me.cbxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxStatus.FormattingEnabled = True
        resources.ApplyResources(Me.cbxStatus, "cbxStatus")
        Me.cbxStatus.Name = "cbxStatus"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'lblAmount
        '
        resources.ApplyResources(Me.lblAmount, "lblAmount")
        Me.lblAmount.Name = "lblAmount"
        '
        'btnCancel
        '
        resources.ApplyResources(Me.btnCancel, "btnCancel")
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        resources.ApplyResources(Me.btnOK, "btnOK")
        Me.btnOK.Name = "btnOK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
        '
        'Label9
        '
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.Name = "Label9"
        '
        'Label10
        '
        resources.ApplyResources(Me.Label10, "Label10")
        Me.Label10.Name = "Label10"
        '
        'lblVat
        '
        resources.ApplyResources(Me.lblVat, "lblVat")
        Me.lblVat.Name = "lblVat"
        '
        'lblTotal
        '
        resources.ApplyResources(Me.lblTotal, "lblTotal")
        Me.lblTotal.Name = "lblTotal"
        '
        'mclCalendar
        '
        resources.ApplyResources(Me.mclCalendar, "mclCalendar")
        Me.mclCalendar.MaxSelectionCount = 31
        Me.mclCalendar.Name = "mclCalendar"
        Me.mclCalendar.ShowTodayCircle = False
        '
        'btnCalculatePrice
        '
        resources.ApplyResources(Me.btnCalculatePrice, "btnCalculatePrice")
        Me.btnCalculatePrice.Name = "btnCalculatePrice"
        Me.ToolTip1.SetToolTip(Me.btnCalculatePrice, resources.GetString("btnCalculatePrice.ToolTip"))
        Me.btnCalculatePrice.UseVisualStyleBackColor = True
        '
        'Label11
        '
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.Name = "Label11"
        '
        'tbxInvoiceNumber
        '
        resources.ApplyResources(Me.tbxInvoiceNumber, "tbxInvoiceNumber")
        Me.tbxInvoiceNumber.Name = "tbxInvoiceNumber"
        '
        'btnPrintInvoice
        '
        resources.ApplyResources(Me.btnPrintInvoice, "btnPrintInvoice")
        Me.btnPrintInvoice.Name = "btnPrintInvoice"
        Me.btnPrintInvoice.UseVisualStyleBackColor = True
        '
        'lblVATPercent
        '
        resources.ApplyResources(Me.lblVATPercent, "lblVATPercent")
        Me.lblVATPercent.Name = "lblVATPercent"
        '
        'frmBook
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblVATPercent)
        Me.Controls.Add(Me.btnPrintInvoice)
        Me.Controls.Add(Me.tbxInvoiceNumber)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.btnCalculatePrice)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.mclCalendar)
        Me.Controls.Add(Me.lblVat)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.lblAmount)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cbxStatus)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dtpCheckout)
        Me.Controls.Add(Me.dtpCheckin)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cbxGuests)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbxBookTypes)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblProperty)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.Name = "frmBook"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents lblProperty As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cbxBookTypes As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cbxGuests As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents dtpCheckout As DateTimePicker
    Friend WithEvents dtpCheckin As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cbxStatus As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents lblAmount As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnOK As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lblVat As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents mclCalendar As MonthCalendar
    Friend WithEvents btnCalculatePrice As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Label11 As Label
    Friend WithEvents tbxInvoiceNumber As TextBox
    Friend WithEvents btnPrintInvoice As Button
    Friend WithEvents lblVATPercent As Label
End Class
