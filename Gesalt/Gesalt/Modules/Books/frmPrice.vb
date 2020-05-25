Imports System.Resources

Public Class frmPrice
    Public Property editPrice As Price
    Public Property btStartDate As Date
    Public Property btEndDate As Date

    Dim LocRM As New ResourceManager("Gesalt.WinFormStrings", GetType(frmPrice).Assembly)
    Dim priceAux As Price
    Dim opBook As OpBook

    Private Sub frmPrice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If editPrice Is Nothing Then
            editPrice = New Price()
        Else
            Me.Text = LocRM.GetString("editPrice")
        End If

        priceAux = Utils.DeepClone(editPrice)

        For i As Integer = 1 To 5
            cbxType.Items.Add(LocRM.GetString("priceType" & i))
        Next
        cbxType.SelectedIndex = 0

        cbxType.DataBindings.Add("SelectedItem", priceAux, "Type")
        cbxPercentage.DataBindings.Add("Checked", priceAux, "Percentage")
        tbxStartDate.DataBindings.Add("Text", priceAux, "StartDate")
        nudValue.DataBindings.Add("Value", priceAux, "Value")

        If Utils.IsEndDateEmpty(priceAux.EndDate) Then
            tbxEndDate.Text = ""
        Else
            tbxEndDate.Text = priceAux.EndDate
        End If
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If tbxEndDate.Text.Equals("") Then
            priceAux.EndDate = New Date(1970, 12, 1)
        Else
            priceAux.EndDate = tbxEndDate.Text
        End If

        If Not ValidateFields() Then
            Exit Sub
        End If

        editPrice = Utils.DeepClone(priceAux)

        Me.DialogResult = DialogResult.OK
    End Sub

    Private Function ValidateFields() As Boolean
        If cbxPercentage.Checked AndAlso (nudValue.Value < 0 Or nudValue.Value > 100) Then
            MsgBox(LocRM.GetString("percentError"), MsgBoxStyle.Exclamation, "Gesalt")
            Return False
        End If

        If priceAux.StartDate < btStartDate OrElse priceAux.StartDate > btEndDate Then
            MsgBox(LocRM.GetString("priceStartDateOutOfLimitsMsg"), MsgBoxStyle.Exclamation, "Gesalt")
            Return False
        End If

        If Not Utils.IsEndDateEmpty(priceAux.EndDate) AndAlso (priceAux.EndDate < btStartDate OrElse priceAux.EndDate > btEndDate) Then
            MsgBox(LocRM.GetString("priceEndDateOutOfLimitsMsg"), MsgBoxStyle.Exclamation, "Gesalt")
            Return False
        End If

        If Not Utils.IsEndDateEmpty(priceAux.EndDate) AndAlso priceAux.StartDate > priceAux.EndDate Then
            MsgBox(LocRM.GetString("startDateAfterEndDate2"), MsgBoxStyle.Exclamation, "Gesalt")
            Return False
        End If

        Return True
    End Function

    Private Sub bntCancel_Click(sender As Object, e As EventArgs) Handles bntCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnDeleteEndDate_Click(sender As Object, e As EventArgs) Handles btnDeleteEndDate.Click
        priceAux.EndDate = New Date(1970, 12, 1)
        tbxEndDate.Text = ""
    End Sub

    Private Sub dtpStartDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpStartDate.ValueChanged
        If priceAux Is Nothing Then
            Exit Sub
        End If

        priceAux.StartDate = dtpStartDate.Value
        tbxStartDate.Text = priceAux.StartDate
    End Sub

    Private Sub dtpEndDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpEndDate.ValueChanged
        If priceAux Is Nothing Then
            Exit Sub
        End If

        priceAux.EndDate = dtpEndDate.Value
        tbxEndDate.Text = priceAux.EndDate
    End Sub
End Class