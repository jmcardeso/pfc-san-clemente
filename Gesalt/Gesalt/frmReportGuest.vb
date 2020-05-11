Public Class frmReportGuest
    Private Sub frmReportGuest_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.rpvGuest.RefreshReport()
    End Sub

    Private Sub GuestBindingSource_CurrentChanged(sender As Object, e As EventArgs) Handles GuestBindingSource.CurrentChanged

    End Sub
End Class