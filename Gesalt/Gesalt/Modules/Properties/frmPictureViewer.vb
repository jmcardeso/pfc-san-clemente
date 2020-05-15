Public Class frmPictureViewer
    Public Property photos As List(Of Photo)
    Public Property index As Integer

    Dim bs As New BindingSource()

    Private Sub frmPictureViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bs.DataSource = photos
        pbxPhoto.DataBindings.Add("ImageLocation", bs, "Path")
        bs.Position = index
    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        bs.Position = 0
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        bs.Position -= 1
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        bs.Position += 1
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        bs.Position = photos.Count - 1
    End Sub
End Class