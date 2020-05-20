Imports System.Resources

Public Class frmPrice
    Public Property editPrice As Price
    Dim LocRM As New ResourceManager("Gesalt.WinFormStrings", GetType(frmPrice).Assembly)
    Dim bs As New BindingSource()

    Private Sub frmPrice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If editPrice Is Nothing Then
            editPrice = New Price()
        End If

        For i As Integer = 1 To 5
            cbxType.Items.Add(LocRM.GetString("priceType" & i))
        Next

        cbxType.SelectedIndex = 0
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub bntCancel_Click(sender As Object, e As EventArgs) Handles bntCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub
End Class