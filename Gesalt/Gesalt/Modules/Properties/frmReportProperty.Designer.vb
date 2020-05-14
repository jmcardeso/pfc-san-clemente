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
        Me.PropBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.rpvProp = New Microsoft.Reporting.WinForms.ReportViewer()
        CType(Me.PropBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PropBindingSource
        '
        Me.PropBindingSource.DataSource = GetType(Gesalt.Prop)
        '
        'rpvProp
        '
        resources.ApplyResources(Me.rpvProp, "rpvProp")
        ReportDataSource1.Name = "dsProp"
        ReportDataSource1.Value = Me.PropBindingSource
        Me.rpvProp.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rpvProp.LocalReport.ReportEmbeddedResource = "Gesalt.rptProperty.rdlc"
        Me.rpvProp.Name = "rpvProp"
        Me.rpvProp.ServerReport.BearerToken = Nothing
        '
        'frmReportOwner
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.rpvProp)
        Me.Name = "frmReportOwner"
        CType(Me.PropBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents rpvProp As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents PropBindingSource As BindingSource
End Class
