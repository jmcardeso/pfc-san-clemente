<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmReportLessor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReportLessor))
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.rpvLessor = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.LessorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.LessorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rpvLessor
        '
        resources.ApplyResources(Me.rpvLessor, "rpvLessor")
        ReportDataSource1.Name = "dsLessor"
        ReportDataSource1.Value = Me.LessorBindingSource
        Me.rpvLessor.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rpvLessor.LocalReport.ReportEmbeddedResource = "Gesalt.rptLessor.rdlc"
        Me.rpvLessor.Name = "rpvLessor"
        Me.rpvLessor.ServerReport.BearerToken = Nothing
        '
        'LessorBindingSource
        '
        Me.LessorBindingSource.DataSource = GetType(Gesalt.Lessor)
        '
        'frmReportLessor
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.rpvLessor)
        Me.Name = "frmReportLessor"
        CType(Me.LessorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents rpvLessor As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents LessorBindingSource As BindingSource
End Class
