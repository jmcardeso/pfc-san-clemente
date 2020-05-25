Imports System.Resources

Public Class frmBookTypeAux
    Public Property editBT As BookType
    Dim LocRM As New ResourceManager("Gesalt.WinFormStrings", GetType(frmBookTypeAux).Assembly)
    Dim btAux As BookType
    Dim opBook As OpBook
    Dim bsPrices As New BindingSource()

    Private Sub frmBookTypeAux_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim opbook As OpBook = OpBook.GetInstance()

        If editBT IsNot Nothing Then
            Me.Text = LocRM.GetString("editBTTitle")
        Else
            editBT = New BookType()
        End If

        btAux = Utils.DeepClone(editBT)

        bsPrices.DataSource = btAux.Prices

        Dim column As DataGridViewColumn

        With dgvPrices
            .AutoGenerateColumns = False
            .ColumnCount = 5

            column = .Columns(0)
            column.Width = 60
            .Columns(0).Name = "Type"
            .Columns(0).HeaderText = LocRM.GetString("fieldType")
            .Columns(0).DataPropertyName = "Type"

            column = .Columns(1)
            column.Width = 60
            .Columns(1).Name = "StartDate"
            .Columns(1).HeaderText = LocRM.GetString("fieldStartDate2")
            .Columns(1).DataPropertyName = "StartDate"

            column = .Columns(2)
            column.Width = 60
            .Columns(2).Name = "EndDate"
            .Columns(2).HeaderText = LocRM.GetString("fieldEndDate2")
            .Columns(2).DataPropertyName = "EndDate"

            column = .Columns(3)
            column.Width = 50
            .Columns(3).Name = "Value"
            .Columns(3).HeaderText = LocRM.GetString("fieldValue")
            .Columns(3).DataPropertyName = "Value"

            column = .Columns(4)
            column.Width = 50
            .Columns(4).Name = "Percentage"
            .Columns(4).HeaderText = LocRM.GetString("fieldPercentage")
            .Columns(4).DataPropertyName = "Percentage"

            .DataSource = bsPrices
        End With

        tbxName.DataBindings.Add("Text", btAux, "BTName")
        tbxStartDate.DataBindings.Add("Text", btAux, "StartDate")
        tbxUrlWeb.DataBindings.Add("Text", btAux, "UrlWeb")
        tbxUrlICalendar.DataBindings.Add("Text", btAux, "UrlICalendar")

        If Utils.IsEndDateEmpty(btAux.EndDate) Then
            tbxEndDate.Text = ""
        Else
            tbxEndDate.Text = btAux.EndDate
        End If
    End Sub

    Private Sub bntCancel_Click(sender As Object, e As EventArgs) Handles bntCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If tbxEndDate.Text.Equals("") Then
            btAux.EndDate = New Date(1970, 12, 1)
        Else
            btAux.EndDate = tbxEndDate.Text
        End If

        If Not ValidateFields() Then
            Exit Sub
        End If

        editBT = Utils.DeepClone(btAux)
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub dtpStartDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpStartDate.ValueChanged
        btAux.StartDate = dtpStartDate.Value
        tbxStartDate.Text = btAux.StartDate
    End Sub

    Private Sub dtpEndDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpEndDate.ValueChanged
        btAux.EndDate = dtpEndDate.Value
        tbxEndDate.Text = btAux.EndDate
    End Sub

    Private Sub btnDeleteEndDate_Click(sender As Object, e As EventArgs) Handles btnDeleteEndDate.Click
        btAux.EndDate = New Date(1970, 12, 1)
        tbxEndDate.Text = ""
    End Sub
    Private Function ValidateFields() As Boolean
        Dim result As Boolean = True

        If tbxName.Text.Trim.Length = 0 Then
            result = False
            MsgBox(LocRM.GetString("fieldBTName") & ". " & LocRM.GetString("fieldRequired"), MsgBoxStyle.Exclamation, "Gesalt")
        ElseIf btaux.EndDate.year <> 1970 AndAlso btAux.StartDate > btAux.EndDate Then
            MsgBox(LocRM.GetString("startDateAfterEndDate"), MsgBoxStyle.Exclamation, "Gesalt")
            result = False
        End If

        Return result
    End Function

    Private Sub btnAddPrice_Click(sender As Object, e As EventArgs) Handles btnAddPrice.Click
        Dim frmAux As New frmPrice With {
            .editPrice = Nothing,
            .btStartDate = btAux.StartDate,
            .btEndDate = btAux.EndDate
        }

        If frmAux.ShowDialog = DialogResult.Cancel Then
            Exit Sub
        End If

        frmAux.editPrice.EndDate = Utils.EndDateToObject(frmAux.editPrice.EndDate)

        btAux.Prices.Add(frmAux.editPrice)
        bsPrices.ResetBindings(False)
    End Sub

    Private Sub bntEditPrice_Click(sender As Object, e As EventArgs) Handles bntEditPrice.Click, dgvPrices.DoubleClick
        If bsPrices.Current Is Nothing Then
            Exit Sub
        End If

        Dim frmAux As New frmPrice With {
             .editPrice = bsPrices.Current,
             .btStartDate = btAux.StartDate,
             .btEndDate = btAux.EndDate
         }

        If frmAux.ShowDialog = DialogResult.Cancel Then
            Exit Sub
        End If

        With bsPrices.Current
            .Type = frmAux.editPrice.Type
            .Value = frmAux.editPrice.Value
            .Percentage = frmAux.editPrice.Percentage
            .StartDate = frmAux.editPrice.StartDate
            .EndDate = Utils.EndDateToObject(frmAux.editPrice.EndDate)
        End With

        bsPrices.ResetBindings(False)
    End Sub

    Private Sub bntDeletePrice_Click(sender As Object, e As EventArgs) Handles bntDeletePrice.Click
        If bsPrices.Current Is Nothing Then
            Exit Sub
        End If

        If MsgBox(LocRM.GetString("priceRemovedMsg"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton1, "Gesalt") = MsgBoxResult.No Then
            Exit Sub
        End If

        btAux.Prices.Remove(bsPrices.Current)
        bsPrices.ResetBindings(False)
    End Sub
End Class