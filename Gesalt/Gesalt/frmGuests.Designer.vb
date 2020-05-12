<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmGuests
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGuests))
        Me.dgvGuests = New System.Windows.Forms.DataGridView()
        Me.mnsGuests = New System.Windows.Forms.MenuStrip()
        Me.GuestsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddAGuestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FilterDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PruebaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tlsGuests = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnFirst = New System.Windows.Forms.Button()
        Me.btnPrevious = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnLast = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.lblProvince = New System.Windows.Forms.Label()
        Me.lblCity = New System.Windows.Forms.Label()
        Me.lblZip = New System.Windows.Forms.Label()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.lblNif = New System.Windows.Forms.Label()
        Me.lblFirstName = New System.Windows.Forms.Label()
        Me.lblLastName = New System.Windows.Forms.Label()
        Me.lblFilter = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbxAcceptAd = New System.Windows.Forms.CheckBox()
        Me.pbxRating5 = New System.Windows.Forms.PictureBox()
        Me.pbxRating4 = New System.Windows.Forms.PictureBox()
        Me.pbxRating3 = New System.Windows.Forms.PictureBox()
        Me.pbxRating2 = New System.Windows.Forms.PictureBox()
        Me.pbxRating1 = New System.Windows.Forms.PictureBox()
        Me.ToolStripAdd = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripEdit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripReports = New System.Windows.Forms.ToolStripDropDownButton()
        Me.GuestsReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripExit = New System.Windows.Forms.ToolStripButton()
        Me.lblComments = New System.Windows.Forms.Label()
        Me.lblRating = New System.Windows.Forms.Label()
        CType(Me.dgvGuests, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnsGuests.SuspendLayout()
        Me.tlsGuests.SuspendLayout()
        CType(Me.pbxRating5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxRating4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxRating3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxRating2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxRating1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvGuests
        '
        Me.dgvGuests.AllowUserToAddRows = False
        Me.dgvGuests.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvGuests.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvGuests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        resources.ApplyResources(Me.dgvGuests, "dgvGuests")
        Me.dgvGuests.MultiSelect = False
        Me.dgvGuests.Name = "dgvGuests"
        Me.dgvGuests.ReadOnly = True
        Me.dgvGuests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvGuests.ShowEditingIcon = False
        '
        'mnsGuests
        '
        Me.mnsGuests.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GuestsToolStripMenuItem, Me.ReportsToolStripMenuItem})
        resources.ApplyResources(Me.mnsGuests, "mnsGuests")
        Me.mnsGuests.Name = "mnsGuests"
        '
        'GuestsToolStripMenuItem
        '
        Me.GuestsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddAGuestToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.FilterDataToolStripMenuItem})
        Me.GuestsToolStripMenuItem.Name = "GuestsToolStripMenuItem"
        resources.ApplyResources(Me.GuestsToolStripMenuItem, "GuestsToolStripMenuItem")
        '
        'AddAGuestToolStripMenuItem
        '
        Me.AddAGuestToolStripMenuItem.Name = "AddAGuestToolStripMenuItem"
        resources.ApplyResources(Me.AddAGuestToolStripMenuItem, "AddAGuestToolStripMenuItem")
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
        'tlsGuests
        '
        Me.tlsGuests.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripAdd, Me.ToolStripEdit, Me.ToolStripDelete, Me.ToolStripSeparator1, Me.ToolStripReports, Me.ToolStripSeparator2, Me.ToolStripExit})
        resources.ApplyResources(Me.tlsGuests, "tlsGuests")
        Me.tlsGuests.Name = "tlsGuests"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
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
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'Label11
        '
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.Name = "Label11"
        '
        'cbxAcceptAd
        '
        resources.ApplyResources(Me.cbxAcceptAd, "cbxAcceptAd")
        Me.cbxAcceptAd.Name = "cbxAcceptAd"
        Me.cbxAcceptAd.UseVisualStyleBackColor = True
        '
        'pbxRating5
        '
        Me.pbxRating5.Image = Global.Gesalt.My.Resources.Resources.star_off
        resources.ApplyResources(Me.pbxRating5, "pbxRating5")
        Me.pbxRating5.Name = "pbxRating5"
        Me.pbxRating5.TabStop = False
        '
        'pbxRating4
        '
        Me.pbxRating4.Image = Global.Gesalt.My.Resources.Resources.star_off
        resources.ApplyResources(Me.pbxRating4, "pbxRating4")
        Me.pbxRating4.Name = "pbxRating4"
        Me.pbxRating4.TabStop = False
        '
        'pbxRating3
        '
        Me.pbxRating3.Image = Global.Gesalt.My.Resources.Resources.star_off
        resources.ApplyResources(Me.pbxRating3, "pbxRating3")
        Me.pbxRating3.Name = "pbxRating3"
        Me.pbxRating3.TabStop = False
        '
        'pbxRating2
        '
        Me.pbxRating2.Image = Global.Gesalt.My.Resources.Resources.star_off
        resources.ApplyResources(Me.pbxRating2, "pbxRating2")
        Me.pbxRating2.Name = "pbxRating2"
        Me.pbxRating2.TabStop = False
        '
        'pbxRating1
        '
        Me.pbxRating1.Image = Global.Gesalt.My.Resources.Resources.star_off
        resources.ApplyResources(Me.pbxRating1, "pbxRating1")
        Me.pbxRating1.Name = "pbxRating1"
        Me.pbxRating1.TabStop = False
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
        'ToolStripReports
        '
        Me.ToolStripReports.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripReports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GuestsReportToolStripMenuItem})
        resources.ApplyResources(Me.ToolStripReports, "ToolStripReports")
        Me.ToolStripReports.Name = "ToolStripReports"
        '
        'GuestsReportToolStripMenuItem
        '
        Me.GuestsReportToolStripMenuItem.Name = "GuestsReportToolStripMenuItem"
        resources.ApplyResources(Me.GuestsReportToolStripMenuItem, "GuestsReportToolStripMenuItem")
        '
        'ToolStripExit
        '
        Me.ToolStripExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.ToolStripExit, "ToolStripExit")
        Me.ToolStripExit.Name = "ToolStripExit"
        '
        'lblComments
        '
        resources.ApplyResources(Me.lblComments, "lblComments")
        Me.lblComments.Name = "lblComments"
        '
        'lblRating
        '
        resources.ApplyResources(Me.lblRating, "lblRating")
        Me.lblRating.Name = "lblRating"
        '
        'frmGuests
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblRating)
        Me.Controls.Add(Me.lblComments)
        Me.Controls.Add(Me.pbxRating5)
        Me.Controls.Add(Me.pbxRating4)
        Me.Controls.Add(Me.pbxRating3)
        Me.Controls.Add(Me.pbxRating2)
        Me.Controls.Add(Me.pbxRating1)
        Me.Controls.Add(Me.cbxAcceptAd)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblFilter)
        Me.Controls.Add(Me.lblLastName)
        Me.Controls.Add(Me.lblFirstName)
        Me.Controls.Add(Me.lblNif)
        Me.Controls.Add(Me.lblAddress)
        Me.Controls.Add(Me.lblZip)
        Me.Controls.Add(Me.lblCity)
        Me.Controls.Add(Me.lblProvince)
        Me.Controls.Add(Me.lblPhone)
        Me.Controls.Add(Me.lblEmail)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnLast)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnPrevious)
        Me.Controls.Add(Me.btnFirst)
        Me.Controls.Add(Me.tlsGuests)
        Me.Controls.Add(Me.dgvGuests)
        Me.Controls.Add(Me.mnsGuests)
        Me.MainMenuStrip = Me.mnsGuests
        Me.Name = "frmGuests"
        CType(Me.dgvGuests, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnsGuests.ResumeLayout(False)
        Me.mnsGuests.PerformLayout()
        Me.tlsGuests.ResumeLayout(False)
        Me.tlsGuests.PerformLayout()
        CType(Me.pbxRating5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxRating4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxRating3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxRating2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxRating1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvGuests As DataGridView
    Friend WithEvents mnsGuests As MenuStrip
    Friend WithEvents tlsGuests As ToolStrip
    Friend WithEvents btnFirst As Button
    Friend WithEvents btnPrevious As Button
    Friend WithEvents btnNext As Button
    Friend WithEvents btnLast As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents lblEmail As Label
    Friend WithEvents lblPhone As Label
    Friend WithEvents lblProvince As Label
    Friend WithEvents lblCity As Label
    Friend WithEvents lblZip As Label
    Friend WithEvents lblAddress As Label
    Friend WithEvents lblNif As Label
    Friend WithEvents lblFirstName As Label
    Friend WithEvents lblLastName As Label
    Friend WithEvents GuestsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddAGuestToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FilterDataToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lblFilter As Label
    Friend WithEvents ToolStripAdd As ToolStripButton
    Friend WithEvents ToolStripEdit As ToolStripButton
    Friend WithEvents ToolStripDelete As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripReports As ToolStripDropDownButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripExit As ToolStripButton
    Friend WithEvents PruebaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GuestsReportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label2 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents cbxAcceptAd As CheckBox
    Friend WithEvents pbxRating1 As PictureBox
    Friend WithEvents pbxRating2 As PictureBox
    Friend WithEvents pbxRating3 As PictureBox
    Friend WithEvents pbxRating4 As PictureBox
    Friend WithEvents pbxRating5 As PictureBox
    Friend WithEvents lblComments As Label
    Friend WithEvents lblRating As Label
End Class
