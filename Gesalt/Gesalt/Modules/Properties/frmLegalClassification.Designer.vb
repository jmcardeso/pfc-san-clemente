<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLegalClassification
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLegalClassification))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbxDescription = New System.Windows.Forms.TextBox()
        Me.dgvLegalClasses = New System.Windows.Forms.DataGridView()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.bntOK = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.pnlDescription = New System.Windows.Forms.Panel()
        CType(Me.dgvLegalClasses, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDescription.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'tbxDescription
        '
        resources.ApplyResources(Me.tbxDescription, "tbxDescription")
        Me.tbxDescription.Name = "tbxDescription"
        '
        'dgvLegalClasses
        '
        Me.dgvLegalClasses.AllowUserToAddRows = False
        Me.dgvLegalClasses.AllowUserToDeleteRows = False
        Me.dgvLegalClasses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        resources.ApplyResources(Me.dgvLegalClasses, "dgvLegalClasses")
        Me.dgvLegalClasses.Name = "dgvLegalClasses"
        Me.dgvLegalClasses.ReadOnly = True
        Me.dgvLegalClasses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        '
        'btnCancel
        '
        resources.ApplyResources(Me.btnCancel, "btnCancel")
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'bntOK
        '
        resources.ApplyResources(Me.bntOK, "bntOK")
        Me.bntOK.Name = "bntOK"
        Me.bntOK.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        resources.ApplyResources(Me.btnDelete, "btnDelete")
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        resources.ApplyResources(Me.btnEdit, "btnEdit")
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        resources.ApplyResources(Me.btnAdd, "btnAdd")
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'pnlDescription
        '
        Me.pnlDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlDescription.Controls.Add(Me.Label1)
        Me.pnlDescription.Controls.Add(Me.btnAdd)
        Me.pnlDescription.Controls.Add(Me.btnEdit)
        Me.pnlDescription.Controls.Add(Me.tbxDescription)
        Me.pnlDescription.Controls.Add(Me.btnDelete)
        resources.ApplyResources(Me.pnlDescription, "pnlDescription")
        Me.pnlDescription.Name = "pnlDescription"
        '
        'frmLegalClassification
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlDescription)
        Me.Controls.Add(Me.bntOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.dgvLegalClasses)
        Me.MaximizeBox = False
        Me.Name = "frmLegalClassification"
        CType(Me.dgvLegalClasses, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDescription.ResumeLayout(False)
        Me.pnlDescription.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents tbxDescription As TextBox
    Friend WithEvents dgvLegalClasses As DataGridView
    Friend WithEvents btnCancel As Button
    Friend WithEvents bntOK As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents pnlDescription As Panel
End Class
