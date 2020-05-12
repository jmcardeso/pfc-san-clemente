<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmReportGuest
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReportGuest))
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.GuestBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.rpvGuest = New Microsoft.Reporting.WinForms.ReportViewer()
        CType(Me.GuestBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GuestBindingSource
        '
        Me.GuestBindingSource.DataSource = GetType(Gesalt.Guest)
        '
        'rpvGuest
        '
        resources.ApplyResources(Me.rpvGuest, "rpvGuest")
        ReportDataSource1.Name = "dsGuest"
        ReportDataSource1.Value = Me.GuestBindingSource
        Me.rpvGuest.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rpvGuest.LocalReport.ReportEmbeddedResource = "Gesalt.rptGuest.rdlc"
        Me.rpvGuest.Name = "rpvGuest"
        Me.rpvGuest.ServerReport.BearerToken = Nothing
        '
        'frmReportGuest
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.rpvGuest)
        Me.Name = "frmReportGuest"
        CType(Me.GuestBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents rpvGuest As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents GuestBindingSource As BindingSource
End Class
