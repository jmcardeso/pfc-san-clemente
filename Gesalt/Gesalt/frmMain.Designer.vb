<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.mnuHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelp_Settings = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelp_About = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btnOwners = New System.Windows.Forms.Button()
        Me.btnGuests = New System.Windows.Forms.Button()
        Me.btnProperties = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuHelp
        '
        Me.mnuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuHelp_Settings, Me.mnuHelp_About})
        Me.mnuHelp.Name = "mnuHelp"
        resources.ApplyResources(Me.mnuHelp, "mnuHelp")
        '
        'mnuHelp_Settings
        '
        Me.mnuHelp_Settings.Name = "mnuHelp_Settings"
        resources.ApplyResources(Me.mnuHelp_Settings, "mnuHelp_Settings")
        '
        'mnuHelp_About
        '
        Me.mnuHelp_About.Name = "mnuHelp_About"
        resources.ApplyResources(Me.mnuHelp_About, "mnuHelp_About")
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuHelp})
        resources.ApplyResources(Me.MenuStrip1, "MenuStrip1")
        Me.MenuStrip1.Name = "MenuStrip1"
        '
        'btnOwners
        '
        resources.ApplyResources(Me.btnOwners, "btnOwners")
        Me.btnOwners.Name = "btnOwners"
        Me.btnOwners.UseVisualStyleBackColor = True
        '
        'btnGuests
        '
        resources.ApplyResources(Me.btnGuests, "btnGuests")
        Me.btnGuests.Name = "btnGuests"
        Me.btnGuests.TabStop = False
        Me.btnGuests.UseVisualStyleBackColor = True
        '
        'btnProperties
        '
        resources.ApplyResources(Me.btnProperties, "btnProperties")
        Me.btnProperties.Name = "btnProperties"
        Me.btnProperties.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnProperties)
        Me.Controls.Add(Me.btnGuests)
        Me.Controls.Add(Me.btnOwners)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents mnuHelp As ToolStripMenuItem
    Friend WithEvents mnuHelp_Settings As ToolStripMenuItem
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents btnOwners As Button
    Friend WithEvents btnGuests As Button
    Friend WithEvents btnProperties As Button
    Friend WithEvents mnuHelp_About As ToolStripMenuItem
End Class
