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
        Me.mnuAyuda = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAyuda_Preferencias = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btnOwners = New System.Windows.Forms.Button()
        Me.btnGuests = New System.Windows.Forms.Button()
        Me.btnProperties = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuAyuda
        '
        Me.mnuAyuda.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAyuda_Preferencias})
        Me.mnuAyuda.Name = "mnuAyuda"
        resources.ApplyResources(Me.mnuAyuda, "mnuAyuda")
        '
        'mnuAyuda_Preferencias
        '
        Me.mnuAyuda_Preferencias.Name = "mnuAyuda_Preferencias"
        resources.ApplyResources(Me.mnuAyuda_Preferencias, "mnuAyuda_Preferencias")
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAyuda})
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

    Friend WithEvents mnuAyuda As ToolStripMenuItem
    Friend WithEvents mnuAyuda_Preferencias As ToolStripMenuItem
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents btnOwners As Button
    Friend WithEvents btnGuests As Button
    Friend WithEvents btnProperties As Button
End Class
