Public Class frmOwners
    Private Sub frmOwners_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dbo = New DbOperations(My.Settings.dbType)

        dgvOwners.DataSource = dbo.GetAllOwners()
    End Sub
End Class