﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.IdiomaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuIdiomaGL = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuIdiomaES = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuIdiomaEN = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
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
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IdiomaToolStripMenuItem})
        resources.ApplyResources(Me.MenuStrip1, "MenuStrip1")
        Me.MenuStrip1.Name = "MenuStrip1"
        '
        'IdiomaToolStripMenuItem
        '
        Me.IdiomaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuIdiomaGL, Me.mnuIdiomaES, Me.mnuIdiomaEN})
        Me.IdiomaToolStripMenuItem.Name = "IdiomaToolStripMenuItem"
        resources.ApplyResources(Me.IdiomaToolStripMenuItem, "IdiomaToolStripMenuItem")
        '
        'mnuIdiomaGL
        '
        Me.mnuIdiomaGL.Name = "mnuIdiomaGL"
        resources.ApplyResources(Me.mnuIdiomaGL, "mnuIdiomaGL")
        '
        'mnuIdiomaES
        '
        Me.mnuIdiomaES.Name = "mnuIdiomaES"
        resources.ApplyResources(Me.mnuIdiomaES, "mnuIdiomaES")
        '
        'mnuIdiomaEN
        '
        Me.mnuIdiomaEN.Name = "mnuIdiomaEN"
        resources.ApplyResources(Me.mnuIdiomaEN, "mnuIdiomaEN")
        '
        'Form1
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents IdiomaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuIdiomaGL As ToolStripMenuItem
    Friend WithEvents mnuIdiomaES As ToolStripMenuItem
    Friend WithEvents mnuIdiomaEN As ToolStripMenuItem
End Class
