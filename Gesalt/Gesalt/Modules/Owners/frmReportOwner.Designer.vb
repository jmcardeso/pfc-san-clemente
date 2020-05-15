<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmReportOwner
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReportOwner))
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.rpvOwner = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.OwnerBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.OwnerBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rpvOwner
        '
        resources.ApplyResources(Me.rpvOwner, "rpvOwner")
        ReportDataSource1.Name = "dsOwner"
        ReportDataSource1.Value = Me.OwnerBindingSource
        Me.rpvOwner.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rpvOwner.LocalReport.ReportEmbeddedResource = "Gesalt.rptOwner.rdlc"
        Me.rpvOwner.Name = "rpvOwner"
        Me.rpvOwner.ServerReport.BearerToken = Nothing
        '
        'OwnerBindingSource
        '
        Me.OwnerBindingSource.DataSource = GetType(Gesalt.Owner)
        '
        'frmReportOwner
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.rpvOwner)
        Me.Name = "frmReportOwner"
        CType(Me.OwnerBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents rpvOwner As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents OwnerBindingSource As BindingSource
End Class
