Public Class frmDescriptionAux
    Public Property Description As String

    Private Sub frmDescriptionAux_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tbxDescription.Text = Description
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Description = tbxDescription.Text
        DialogResult = DialogResult.OK
    End Sub
End Class