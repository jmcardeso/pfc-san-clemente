Public Class frmReportLessor
    Private Sub frmReportLessor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.rpvLessor.RefreshReport()
    End Sub

    Private Sub LessorBindingSource_CurrentChanged(sender As Object, e As EventArgs) Handles LessorBindingSource.CurrentChanged

    End Sub
End Class