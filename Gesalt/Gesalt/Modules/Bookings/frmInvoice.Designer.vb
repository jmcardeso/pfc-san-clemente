<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmInvoice
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInvoice))
        Me.rpvInvoice = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SuspendLayout()
        '
        'rpvInvoice
        '
        resources.ApplyResources(Me.rpvInvoice, "rpvInvoice")
        Me.rpvInvoice.LocalReport.ReportEmbeddedResource = "Gesalt.rptInvoice.rdlc"
        Me.rpvInvoice.Name = "rpvInvoice"
        Me.rpvInvoice.ServerReport.BearerToken = Nothing
        '
        'frmInvoice
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.rpvInvoice)
        Me.Name = "frmInvoice"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents rpvInvoice As Microsoft.Reporting.WinForms.ReportViewer
End Class
