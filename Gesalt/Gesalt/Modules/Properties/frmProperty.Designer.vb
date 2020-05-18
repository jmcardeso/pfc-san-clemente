<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProperty
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProperty))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tlsProperties = New System.Windows.Forms.ToolStrip()
        Me.ToolStripAdd = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripEdit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripReports = New System.Windows.Forms.ToolStripDropDownButton()
        Me.PropReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripExit = New System.Windows.Forms.ToolStripButton()
        Me.mnsProperties = New System.Windows.Forms.MenuStrip()
        Me.PropertiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddAPropertyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FilterDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PropertiesReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblFilter = New System.Windows.Forms.Label()
        Me.btnLast = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnPrevious = New System.Windows.Forms.Button()
        Me.btnFirst = New System.Windows.Forms.Button()
        Me.dgvProperties = New System.Windows.Forms.DataGridView()
        Me.pbxPhotos = New System.Windows.Forms.PictureBox()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnPhotosFirst = New System.Windows.Forms.Button()
        Me.btnPhotosNext = New System.Windows.Forms.Button()
        Me.btnPhotosPrevious = New System.Windows.Forms.Button()
        Me.btnPhotosLast = New System.Windows.Forms.Button()
        Me.lblCadRef = New System.Windows.Forms.Label()
        Me.lblProvince = New System.Windows.Forms.Label()
        Me.lblBaths = New System.Windows.Forms.Label()
        Me.lblBedrooms = New System.Windows.Forms.Label()
        Me.lblSize = New System.Windows.Forms.Label()
        Me.lblMaxGuests = New System.Windows.Forms.Label()
        Me.lblZip = New System.Windows.Forms.Label()
        Me.lblCity = New System.Windows.Forms.Label()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.dgvLessors = New System.Windows.Forms.DataGridView()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.BookTypeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BookTypeToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tlsProperties.SuspendLayout()
        Me.mnsProperties.SuspendLayout()
        CType(Me.dgvProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxPhotos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvLessors, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'tlsProperties
        '
        Me.tlsProperties.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripAdd, Me.ToolStripEdit, Me.ToolStripDelete, Me.ToolStripSeparator1, Me.ToolStripReports, Me.ToolStripSeparator2, Me.ToolStripExit})
        resources.ApplyResources(Me.tlsProperties, "tlsProperties")
        Me.tlsProperties.Name = "tlsProperties"
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
        'mnsProperties
        '
        Me.mnsProperties.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PropertiesToolStripMenuItem, Me.BookTypeToolStripMenuItem, Me.ReportsToolStripMenuItem})
        resources.ApplyResources(Me.mnsProperties, "mnsProperties")
        Me.mnsProperties.Name = "mnsProperties"
        '
        'PropertiesToolStripMenuItem
        '
        Me.PropertiesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddAPropertyToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.FilterDataToolStripMenuItem})
        Me.PropertiesToolStripMenuItem.Name = "PropertiesToolStripMenuItem"
        resources.ApplyResources(Me.PropertiesToolStripMenuItem, "PropertiesToolStripMenuItem")
        '
        'AddAPropertyToolStripMenuItem
        '
        Me.AddAPropertyToolStripMenuItem.Name = "AddAPropertyToolStripMenuItem"
        resources.ApplyResources(Me.AddAPropertyToolStripMenuItem, "AddAPropertyToolStripMenuItem")
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        resources.ApplyResources(Me.EditToolStripMenuItem, "EditToolStripMenuItem")
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        resources.ApplyResources(Me.DeleteToolStripMenuItem, "DeleteToolStripMenuItem")
        '
        'FilterDataToolStripMenuItem
        '
        Me.FilterDataToolStripMenuItem.Name = "FilterDataToolStripMenuItem"
        resources.ApplyResources(Me.FilterDataToolStripMenuItem, "FilterDataToolStripMenuItem")
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PropertiesReportToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        resources.ApplyResources(Me.ReportsToolStripMenuItem, "ReportsToolStripMenuItem")
        '
        'PropertiesReportToolStripMenuItem
        '
        Me.PropertiesReportToolStripMenuItem.Name = "PropertiesReportToolStripMenuItem"
        resources.ApplyResources(Me.PropertiesReportToolStripMenuItem, "PropertiesReportToolStripMenuItem")
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
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
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
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
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
        'lblFilter
        '
        resources.ApplyResources(Me.lblFilter, "lblFilter")
        Me.lblFilter.Name = "lblFilter"
        '
        'btnLast
        '
        resources.ApplyResources(Me.btnLast, "btnLast")
        Me.btnLast.Name = "btnLast"
        Me.btnLast.UseVisualStyleBackColor = True
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
        'btnFirst
        '
        resources.ApplyResources(Me.btnFirst, "btnFirst")
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.UseVisualStyleBackColor = True
        '
        'dgvProperties
        '
        Me.dgvProperties.AllowUserToAddRows = False
        Me.dgvProperties.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvProperties.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        resources.ApplyResources(Me.dgvProperties, "dgvProperties")
        Me.dgvProperties.MultiSelect = False
        Me.dgvProperties.Name = "dgvProperties"
        Me.dgvProperties.ReadOnly = True
        Me.dgvProperties.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProperties.ShowEditingIcon = False
        '
        'pbxPhotos
        '
        Me.pbxPhotos.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.pbxPhotos, "pbxPhotos")
        Me.pbxPhotos.Name = "pbxPhotos"
        Me.pbxPhotos.TabStop = False
        '
        'lblDescription
        '
        Me.lblDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.lblDescription, "lblDescription")
        Me.lblDescription.Name = "lblDescription"
        '
        'Label12
        '
        resources.ApplyResources(Me.Label12, "Label12")
        Me.Label12.Name = "Label12"
        '
        'btnPhotosFirst
        '
        resources.ApplyResources(Me.btnPhotosFirst, "btnPhotosFirst")
        Me.btnPhotosFirst.Name = "btnPhotosFirst"
        Me.btnPhotosFirst.UseVisualStyleBackColor = True
        '
        'btnPhotosNext
        '
        resources.ApplyResources(Me.btnPhotosNext, "btnPhotosNext")
        Me.btnPhotosNext.Name = "btnPhotosNext"
        Me.btnPhotosNext.UseVisualStyleBackColor = True
        '
        'btnPhotosPrevious
        '
        resources.ApplyResources(Me.btnPhotosPrevious, "btnPhotosPrevious")
        Me.btnPhotosPrevious.Name = "btnPhotosPrevious"
        Me.btnPhotosPrevious.UseVisualStyleBackColor = True
        '
        'btnPhotosLast
        '
        resources.ApplyResources(Me.btnPhotosLast, "btnPhotosLast")
        Me.btnPhotosLast.Name = "btnPhotosLast"
        Me.btnPhotosLast.UseVisualStyleBackColor = True
        '
        'lblCadRef
        '
        resources.ApplyResources(Me.lblCadRef, "lblCadRef")
        Me.lblCadRef.Name = "lblCadRef"
        '
        'lblProvince
        '
        resources.ApplyResources(Me.lblProvince, "lblProvince")
        Me.lblProvince.Name = "lblProvince"
        '
        'lblBaths
        '
        resources.ApplyResources(Me.lblBaths, "lblBaths")
        Me.lblBaths.Name = "lblBaths"
        '
        'lblBedrooms
        '
        resources.ApplyResources(Me.lblBedrooms, "lblBedrooms")
        Me.lblBedrooms.Name = "lblBedrooms"
        '
        'lblSize
        '
        resources.ApplyResources(Me.lblSize, "lblSize")
        Me.lblSize.Name = "lblSize"
        '
        'lblMaxGuests
        '
        resources.ApplyResources(Me.lblMaxGuests, "lblMaxGuests")
        Me.lblMaxGuests.Name = "lblMaxGuests"
        '
        'lblZip
        '
        resources.ApplyResources(Me.lblZip, "lblZip")
        Me.lblZip.Name = "lblZip"
        '
        'lblCity
        '
        resources.ApplyResources(Me.lblCity, "lblCity")
        Me.lblCity.Name = "lblCity"
        '
        'lblAddress
        '
        resources.ApplyResources(Me.lblAddress, "lblAddress")
        Me.lblAddress.Name = "lblAddress"
        '
        'dgvLessors
        '
        Me.dgvLessors.AllowUserToAddRows = False
        Me.dgvLessors.AllowUserToDeleteRows = False
        Me.dgvLessors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvLessors.DefaultCellStyle = DataGridViewCellStyle2
        resources.ApplyResources(Me.dgvLessors, "dgvLessors")
        Me.dgvLessors.MultiSelect = False
        Me.dgvLessors.Name = "dgvLessors"
        Me.dgvLessors.ReadOnly = True
        Me.dgvLessors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLessors.ShowEditingIcon = False
        '
        'Label11
        '
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.Name = "Label11"
        '
        'BookTypeToolStripMenuItem
        '
        Me.BookTypeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BookTypeToolStripMenuItem1})
        Me.BookTypeToolStripMenuItem.Name = "BookTypeToolStripMenuItem"
        resources.ApplyResources(Me.BookTypeToolStripMenuItem, "BookTypeToolStripMenuItem")
        '
        'BookTypeToolStripMenuItem1
        '
        Me.BookTypeToolStripMenuItem1.Name = "BookTypeToolStripMenuItem1"
        resources.ApplyResources(Me.BookTypeToolStripMenuItem1, "BookTypeToolStripMenuItem1")
        '
        'frmProperty
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.dgvLessors)
        Me.Controls.Add(Me.lblAddress)
        Me.Controls.Add(Me.lblCity)
        Me.Controls.Add(Me.lblZip)
        Me.Controls.Add(Me.lblMaxGuests)
        Me.Controls.Add(Me.lblSize)
        Me.Controls.Add(Me.lblBedrooms)
        Me.Controls.Add(Me.lblBaths)
        Me.Controls.Add(Me.lblProvince)
        Me.Controls.Add(Me.lblCadRef)
        Me.Controls.Add(Me.btnPhotosLast)
        Me.Controls.Add(Me.btnPhotosPrevious)
        Me.Controls.Add(Me.btnPhotosNext)
        Me.Controls.Add(Me.btnPhotosFirst)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.pbxPhotos)
        Me.Controls.Add(Me.lblFilter)
        Me.Controls.Add(Me.btnLast)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnPrevious)
        Me.Controls.Add(Me.btnFirst)
        Me.Controls.Add(Me.dgvProperties)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tlsProperties)
        Me.Controls.Add(Me.mnsProperties)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.Name = "frmProperty"
        Me.tlsProperties.ResumeLayout(False)
        Me.tlsProperties.PerformLayout()
        Me.mnsProperties.ResumeLayout(False)
        Me.mnsProperties.PerformLayout()
        CType(Me.dgvProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxPhotos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvLessors, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents tlsProperties As ToolStrip
    Friend WithEvents ToolStripAdd As ToolStripButton
    Friend WithEvents ToolStripEdit As ToolStripButton
    Friend WithEvents ToolStripDelete As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripReports As ToolStripDropDownButton
    Friend WithEvents PropReportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripExit As ToolStripButton
    Friend WithEvents mnsProperties As MenuStrip
    Friend WithEvents PropertiesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddAPropertyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FilterDataToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PropertiesReportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lblFilter As Label
    Friend WithEvents btnLast As Button
    Friend WithEvents btnNext As Button
    Friend WithEvents btnPrevious As Button
    Friend WithEvents btnFirst As Button
    Friend WithEvents dgvProperties As DataGridView
    Friend WithEvents pbxPhotos As PictureBox
    Friend WithEvents lblDescription As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents btnPhotosFirst As Button
    Friend WithEvents btnPhotosNext As Button
    Friend WithEvents btnPhotosPrevious As Button
    Friend WithEvents btnPhotosLast As Button
    Friend WithEvents lblCadRef As Label
    Friend WithEvents lblProvince As Label
    Friend WithEvents lblBaths As Label
    Friend WithEvents lblBedrooms As Label
    Friend WithEvents lblSize As Label
    Friend WithEvents lblMaxGuests As Label
    Friend WithEvents lblZip As Label
    Friend WithEvents lblCity As Label
    Friend WithEvents lblAddress As Label
    Friend WithEvents dgvLessors As DataGridView
    Friend WithEvents Label11 As Label
    Friend WithEvents BookTypeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BookTypeToolStripMenuItem1 As ToolStripMenuItem
End Class
