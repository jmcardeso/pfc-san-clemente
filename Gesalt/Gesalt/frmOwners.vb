Public Class frmOwners
    Private Sub frmOwners_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dbo As DbOperations
        Try
            dbo = DbOperations.GetInstance(My.Settings.dbType)
            dgvOwners.DataSource = dbo.GetAllOwners()
        Catch err As InvalidOperationException
            MsgBox(err.Message)
            Close()
        End Try
    End Sub
End Class