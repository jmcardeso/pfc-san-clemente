<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportOwner
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
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.OwnerBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.rpvOwner = New Microsoft.Reporting.WinForms.ReportViewer()
        CType(Me.OwnerBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OwnerBindingSource
        '
        Me.OwnerBindingSource.DataSource = GetType(Gesalt.Owner)
        '
        'rpvOwner
        '
        ReportDataSource1.Name = "dsOwner"
        ReportDataSource1.Value = Me.OwnerBindingSource
        Me.rpvOwner.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rpvOwner.LocalReport.ReportEmbeddedResource = "Gesalt.rptOwner.rdlc"
        Me.rpvOwner.Location = New System.Drawing.Point(12, 12)
        Me.rpvOwner.Name = "rpvOwner"
        Me.rpvOwner.ServerReport.BearerToken = Nothing
        Me.rpvOwner.Size = New System.Drawing.Size(776, 426)
        Me.rpvOwner.TabIndex = 0
        '
        'frmReportOwner
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.rpvOwner)
        Me.Name = "frmReportOwner"
        Me.Text = "frmReportOwner"
        CType(Me.OwnerBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents rpvOwner As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents OwnerBindingSource As BindingSource
End Class
