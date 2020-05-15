<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLessors
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLessors))
        Me.dgvLessors = New System.Windows.Forms.DataGridView()
        Me.mnsLessors = New System.Windows.Forms.MenuStrip()
        Me.LessorsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddALessorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FilterDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PruebaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MailingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tlsLessors = New System.Windows.Forms.ToolStrip()
        Me.ToolStripAdd = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripEdit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripReports = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMailing = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripExit = New System.Windows.Forms.ToolStripButton()
        Me.btnFirst = New System.Windows.Forms.Button()
        Me.btnPrevious = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnLast = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.lblProvince = New System.Windows.Forms.Label()
        Me.lblCity = New System.Windows.Forms.Label()
        Me.lblZip = New System.Windows.Forms.Label()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.lblType = New System.Windows.Forms.Label()
        Me.lblNif = New System.Windows.Forms.Label()
        Me.lblFirstName = New System.Windows.Forms.Label()
        Me.lblLastName = New System.Windows.Forms.Label()
        Me.lblFilter = New System.Windows.Forms.Label()
        Me.pbxLogo = New System.Windows.Forms.PictureBox()
        Me.LessorsReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.dgvLessors, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnsLessors.SuspendLayout()
        Me.tlsLessors.SuspendLayout()
        CType(Me.pbxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvLessors
        '
        Me.dgvLessors.AllowUserToAddRows = False
        Me.dgvLessors.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvLessors.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvLessors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        resources.ApplyResources(Me.dgvLessors, "dgvLessors")
        Me.dgvLessors.MultiSelect = False
        Me.dgvLessors.Name = "dgvLessors"
        Me.dgvLessors.ReadOnly = True
        Me.dgvLessors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLessors.ShowEditingIcon = False
        '
        'mnsLessors
        '
        Me.mnsLessors.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LessorsToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.MailingToolStripMenuItem})
        resources.ApplyResources(Me.mnsLessors, "mnsLessors")
        Me.mnsLessors.Name = "mnsLessors"
        '
        'LessorsToolStripMenuItem
        '
        Me.LessorsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddALessorToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.FilterDataToolStripMenuItem})
        Me.LessorsToolStripMenuItem.Name = "LessorsToolStripMenuItem"
        resources.ApplyResources(Me.LessorsToolStripMenuItem, "LessorsToolStripMenuItem")
        '
        'AddAnLessorToolStripMenuItem
        '
        Me.AddALessorToolStripMenuItem.Name = "AddAnLessorToolStripMenuItem"
        resources.ApplyResources(Me.AddALessorToolStripMenuItem, "AddAnLessorToolStripMenuItem")
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
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PruebaToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        resources.ApplyResources(Me.ReportsToolStripMenuItem, "ReportsToolStripMenuItem")
        '
        'PruebaToolStripMenuItem
        '
        Me.PruebaToolStripMenuItem.Name = "PruebaToolStripMenuItem"
        resources.ApplyResources(Me.PruebaToolStripMenuItem, "PruebaToolStripMenuItem")
        '
        'MailingToolStripMenuItem
        '
        Me.MailingToolStripMenuItem.Name = "MailingToolStripMenuItem"
        resources.ApplyResources(Me.MailingToolStripMenuItem, "MailingToolStripMenuItem")
        '
        'tlsLessors
        '
        Me.tlsLessors.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripAdd, Me.ToolStripEdit, Me.ToolStripDelete, Me.ToolStripSeparator1, Me.ToolStripReports, Me.ToolStripSeparator2, Me.ToolStripMailing, Me.ToolStripSeparator3, Me.ToolStripExit})
        resources.ApplyResources(Me.tlsLessors, "tlsLessors")
        Me.tlsLessors.Name = "tlsLessors"
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
        Me.ToolStripReports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LessorsReportToolStripMenuItem})
        resources.ApplyResources(Me.ToolStripReports, "ToolStripReports")
        Me.ToolStripReports.Name = "ToolStripReports"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        '
        'ToolStripMailing
        '
        Me.ToolStripMailing.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.ToolStripMailing, "ToolStripMailing")
        Me.ToolStripMailing.Name = "ToolStripMailing"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        resources.ApplyResources(Me.ToolStripSeparator3, "ToolStripSeparator3")
        '
        'ToolStripExit
        '
        Me.ToolStripExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.ToolStripExit, "ToolStripExit")
        Me.ToolStripExit.Name = "ToolStripExit"
        '
        'btnFirst
        '
        resources.ApplyResources(Me.btnFirst, "btnFirst")
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.UseVisualStyleBackColor = True
        '
        'btnPrevious
        '
        resources.ApplyResources(Me.btnPrevious, "btnPrevious")
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        resources.ApplyResources(Me.btnNext, "btnNext")
        Me.btnNext.Name = "btnNext"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnLast
        '
        resources.ApplyResources(Me.btnLast, "btnLast")
        Me.btnLast.Name = "btnLast"
        Me.btnLast.UseVisualStyleBackColor = True
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
        'Label11
        '
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.Name = "Label11"
        '
        'Label12
        '
        resources.ApplyResources(Me.Label12, "Label12")
        Me.Label12.Name = "Label12"
        '
        'lblEmail
        '
        resources.ApplyResources(Me.lblEmail, "lblEmail")
        Me.lblEmail.Name = "lblEmail"
        '
        'lblPhone
        '
        resources.ApplyResources(Me.lblPhone, "lblPhone")
        Me.lblPhone.Name = "lblPhone"
        '
        'lblProvince
        '
        resources.ApplyResources(Me.lblProvince, "lblProvince")
        Me.lblProvince.Name = "lblProvince"
        '
        'lblCity
        '
        resources.ApplyResources(Me.lblCity, "lblCity")
        Me.lblCity.Name = "lblCity"
        '
        'lblZip
        '
        resources.ApplyResources(Me.lblZip, "lblZip")
        Me.lblZip.Name = "lblZip"
        '
        'lblAddress
        '
        resources.ApplyResources(Me.lblAddress, "lblAddress")
        Me.lblAddress.Name = "lblAddress"
        '
        'lblType
        '
        resources.ApplyResources(Me.lblType, "lblType")
        Me.lblType.Name = "lblType"
        '
        'lblNif
        '
        resources.ApplyResources(Me.lblNif, "lblNif")
        Me.lblNif.Name = "lblNif"
        '
        'lblFirstName
        '
        resources.ApplyResources(Me.lblFirstName, "lblFirstName")
        Me.lblFirstName.Name = "lblFirstName"
        '
        'lblLastName
        '
        resources.ApplyResources(Me.lblLastName, "lblLastName")
        Me.lblLastName.Name = "lblLastName"
        '
        'lblFilter
        '
        resources.ApplyResources(Me.lblFilter, "lblFilter")
        Me.lblFilter.Name = "lblFilter"
        '
        'pbxLogo
        '
        resources.ApplyResources(Me.pbxLogo, "pbxLogo")
        Me.pbxLogo.Name = "pbxLogo"
        Me.pbxLogo.TabStop = False
        '
        'LessorsReportToolStripMenuItem
        '
        Me.LessorsReportToolStripMenuItem.Name = "LessorsReportToolStripMenuItem"
        resources.ApplyResources(Me.LessorsReportToolStripMenuItem, "LessorsReportToolStripMenuItem")
        '
        'frmLessors
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pbxLogo)
        Me.Controls.Add(Me.lblFilter)
        Me.Controls.Add(Me.lblLastName)
        Me.Controls.Add(Me.lblFirstName)
        Me.Controls.Add(Me.lblNif)
        Me.Controls.Add(Me.lblType)
        Me.Controls.Add(Me.lblAddress)
        Me.Controls.Add(Me.lblZip)
        Me.Controls.Add(Me.lblCity)
        Me.Controls.Add(Me.lblProvince)
        Me.Controls.Add(Me.lblPhone)
        Me.Controls.Add(Me.lblEmail)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnLast)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnPrevious)
        Me.Controls.Add(Me.btnFirst)
        Me.Controls.Add(Me.tlsLessors)
        Me.Controls.Add(Me.dgvLessors)
        Me.Controls.Add(Me.mnsLessors)
        Me.MainMenuStrip = Me.mnsLessors
        Me.Name = "frmLessors"
        CType(Me.dgvLessors, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnsLessors.ResumeLayout(False)
        Me.mnsLessors.PerformLayout()
        Me.tlsLessors.ResumeLayout(False)
        Me.tlsLessors.PerformLayout()
        CType(Me.pbxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvLessors As DataGridView
    Friend WithEvents mnsLessors As MenuStrip
    Friend WithEvents tlsLessors As ToolStrip
    Friend WithEvents btnFirst As Button
    Friend WithEvents btnPrevious As Button
    Friend WithEvents btnNext As Button
    Friend WithEvents btnLast As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents lblEmail As Label
    Friend WithEvents lblPhone As Label
    Friend WithEvents lblProvince As Label
    Friend WithEvents lblCity As Label
    Friend WithEvents lblZip As Label
    Friend WithEvents lblAddress As Label
    Friend WithEvents lblType As Label
    Friend WithEvents lblNif As Label
    Friend WithEvents lblFirstName As Label
    Friend WithEvents lblLastName As Label
    Friend WithEvents LessorsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddALessorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MailingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FilterDataToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lblFilter As Label
    Friend WithEvents ToolStripAdd As ToolStripButton
    Friend WithEvents ToolStripEdit As ToolStripButton
    Friend WithEvents ToolStripDelete As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripReports As ToolStripDropDownButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripMailing As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolStripExit As ToolStripButton
    Friend WithEvents pbxLogo As PictureBox
    Friend WithEvents PruebaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LessorsReportToolStripMenuItem As ToolStripMenuItem
End Class
