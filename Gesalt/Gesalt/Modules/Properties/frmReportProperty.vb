Public Class frmReportProperty
    Private Sub frmReportProperty_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.rpvProp.RefreshReport()
    End Sub

    Private Sub OwnerBindingSource_CurrentChanged(sender As Object, e As EventArgs) Handles PropBindingSource.CurrentChanged

    End Sub
End Class