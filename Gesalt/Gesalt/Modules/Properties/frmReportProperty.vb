Public Class frmReportOwner
    Private Sub frmReportOwner_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.rpvOwner.RefreshReport()
    End Sub

    Private Sub OwnerBindingSource_CurrentChanged(sender As Object, e As EventArgs) Handles OwnerBindingSource.CurrentChanged

    End Sub
End Class