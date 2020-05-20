<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBookType
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBookType))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblProperty = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblBTName = New System.Windows.Forms.Label()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.lblUrlWeb = New System.Windows.Forms.Label()
        Me.lblUrlICalendar = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dgvBooksTypes = New System.Windows.Forms.DataGridView()
        Me.btnFirst = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnPrevious = New System.Windows.Forms.Button()
        Me.bntLast = New System.Windows.Forms.Button()
        Me.lblBooksTypes = New System.Windows.Forms.Label()
        Me.tlsBookType = New System.Windows.Forms.ToolStrip()
        Me.ToolStripAdd = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripEdit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripReports = New System.Windows.Forms.ToolStripDropDownButton()
        Me.PropReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripExit = New System.Windows.Forms.ToolStripButton()
        Me.dgvPrices = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.dgvBooksTypes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlsBookType.SuspendLayout()
        CType(Me.dgvPrices, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'lblBTName
        '
        resources.ApplyResources(Me.lblBTName, "lblBTName")
        Me.lblBTName.Name = "lblBTName"
        '
        'lblEndDate
        '
        resources.ApplyResources(Me.lblEndDate, "lblEndDate")
        Me.lblEndDate.Name = "lblEndDate"
        '
        'lblStartDate
        '
        resources.ApplyResources(Me.lblStartDate, "lblStartDate")
        Me.lblStartDate.Name = "lblStartDate"
        '
        'lblUrlWeb
        '
        resources.ApplyResources(Me.lblUrlWeb, "lblUrlWeb")
        Me.lblUrlWeb.Name = "lblUrlWeb"
        '
        'lblUrlICalendar
        '
        resources.ApplyResources(Me.lblUrlICalendar, "lblUrlICalendar")
        Me.lblUrlICalendar.Name = "lblUrlICalendar"
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
        'Label11
        '
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.Name = "Label11"
        '
        'dgvBooksTypes
        '
        Me.dgvBooksTypes.AllowUserToAddRows = False
        Me.dgvBooksTypes.AllowUserToDeleteRows = False
        Me.dgvBooksTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        resources.ApplyResources(Me.dgvBooksTypes, "dgvBooksTypes")
        Me.dgvBooksTypes.Name = "dgvBooksTypes"
        Me.dgvBooksTypes.ReadOnly = True
        Me.dgvBooksTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        '
        'btnFirst
        '
        resources.ApplyResources(Me.btnFirst, "btnFirst")
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        resources.ApplyResources(Me.btnNext, "btnNext")
        Me.btnNext.Name = "btnNext"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnPrevious
        '
        resources.ApplyResources(Me.btnPrevious, "btnPrevious")
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.UseVisualStyleBackColor = True
        '
        'bntLast
        '
        resources.ApplyResources(Me.bntLast, "bntLast")
        Me.bntLast.Name = "bntLast"
        Me.bntLast.UseVisualStyleBackColor = True
        '
        'lblBooksTypes
        '
        resources.ApplyResources(Me.lblBooksTypes, "lblBooksTypes")
        Me.lblBooksTypes.Name = "lblBooksTypes"
        '
        'tlsBookType
        '
        Me.tlsBookType.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripAdd, Me.ToolStripEdit, Me.ToolStripDelete, Me.ToolStripSeparator1, Me.ToolStripReports, Me.ToolStripSeparator2, Me.ToolStripExit})
        resources.ApplyResources(Me.tlsBookType, "tlsBookType")
        Me.tlsBookType.Name = "tlsBookType"
        '
        'ToolStripAdd
        '
        Me.ToolStripAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.ToolStripAdd, "ToolStripAdd")
        Me.ToolStripAdd.Name = "ToolStripAdd"
        '
        'ToolStripEdit
        '
        Me.ToolStripEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.ToolStripEdit, "ToolStripEdit")
        Me.ToolStripEdit.Name = "ToolStripEdit"
        '
        'ToolStripDelete
        '
        Me.ToolStripDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.ToolStripDelete, "ToolStripDelete")
        Me.ToolStripDelete.Name = "ToolStripDelete"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        '
        'ToolStripReports
        '
        Me.ToolStripReports.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripReports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PropReportToolStripMenuItem})
        resources.ApplyResources(Me.ToolStripReports, "ToolStripReports")
        Me.ToolStripReports.Name = "ToolStripReports"
        '
        'PropReportToolStripMenuItem
        '
        Me.PropReportToolStripMenuItem.Name = "PropReportToolStripMenuItem"
        resources.ApplyResources(Me.PropReportToolStripMenuItem, "PropReportToolStripMenuItem")
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        '
        'ToolStripExit
        '
        Me.ToolStripExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.ToolStripExit, "ToolStripExit")
        Me.ToolStripExit.Name = "ToolStripExit"
        '
        'dgvPrices
        '
        Me.dgvPrices.AllowUserToAddRows = False
        Me.dgvPrices.AllowUserToDeleteRows = False
        Me.dgvPrices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        resources.ApplyResources(Me.dgvPrices, "dgvPrices")
        Me.dgvPrices.Name = "dgvPrices"
        Me.dgvPrices.ReadOnly = True
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvPrices.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPrices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'frmBookType
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dgvPrices)
        Me.Controls.Add(Me.tlsBookType)
        Me.Controls.Add(Me.lblBooksTypes)
        Me.Controls.Add(Me.bntLast)
        Me.Controls.Add(Me.btnPrevious)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnFirst)
        Me.Controls.Add(Me.dgvBooksTypes)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lblUrlICalendar)
        Me.Controls.Add(Me.lblUrlWeb)
        Me.Controls.Add(Me.lblStartDate)
        Me.Controls.Add(Me.lblEndDate)
        Me.Controls.Add(Me.lblBTName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblProperty)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmBookType"
        CType(Me.dgvBooksTypes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlsBookType.ResumeLayout(False)
        Me.tlsBookType.PerformLayout()
        CType(Me.dgvPrices, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents lblProperty As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblBTName As Label
    Friend WithEvents lblEndDate As Label
    Friend WithEvents lblStartDate As Label
    Friend WithEvents lblUrlWeb As Label
    Friend WithEvents lblUrlICalendar As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents dgvBooksTypes As DataGridView
    Friend WithEvents btnFirst As Button
    Friend WithEvents btnNext As Button
    Friend WithEvents btnPrevious As Button
    Friend WithEvents bntLast As Button
    Friend WithEvents lblBooksTypes As Label
    Friend WithEvents tlsBookType As ToolStrip
    Friend WithEvents ToolStripAdd As ToolStripButton
    Friend WithEvents ToolStripEdit As ToolStripButton
    Friend WithEvents ToolStripDelete As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripReports As ToolStripDropDownButton
    Friend WithEvents PropReportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripExit As ToolStripButton
    Friend WithEvents dgvPrices As DataGridView
    Friend WithEvents Label3 As Label
End Class
