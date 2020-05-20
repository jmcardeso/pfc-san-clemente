Imports System.Resources

Public Class frmBookType
    Public Property propertyId As Integer
    Dim bookTypes As New List(Of BookType)
    Dim bs As New BindingSource()
    Dim bsPrices As New BindingSource()
    Dim opBook As OpBook = OpBook.GetInstance()
    Dim LocRM As New ResourceManager("Gesalt.WinFormStrings", GetType(frmBookType).Assembly)
    Private Sub frmBookType_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bookTypes = opBook.GetBookTypes(propertyId)

        bs.DataSource = bookTypes

        Dim column As DataGridViewColumn
        With dgvBooksTypes
            .AutoGenerateColumns = False
            .ColumnCount = 3

            column = .Columns(0)
            column.Width = 250
            .Columns(0).Name = "BTName"
            .Columns(0).HeaderText = LocRM.GetString("fieldBTName")
            .Columns(0).DataPropertyName = "BTName"

            column = .Columns(1)
            column.Width = 150
            .Columns(1).Name = "StartDate"
            .Columns(1).HeaderText = LocRM.GetString("fieldStartDate")
            .Columns(1).DataPropertyName = "StartDate"

            column = .Columns(2)
            column.Width = 150
            .Columns(2).Name = "EndDate"
            .Columns(2).HeaderText = LocRM.GetString("fieldEndDate")
            .Columns(2).DataPropertyName = "EndDate"

            .DataSource = bs
        End With

        lblBTName.DataBindings.Add("Text", bs, "BTName")
        lblStartDate.DataBindings.Add("Text", bs, "StartDate")
        lblEndDate.DataBindings.Add("Text", bs, "EndDate")
        lblUrlWeb.DataBindings.Add("Text", bs, "UrlWeb")
        lblUrlICalendar.DataBindings.Add("Text", bs, "UrlICalendar")

        If bs.Current IsNot Nothing Then
            bsPrices.DataSource = bs.Current.Prices
        Else
            bsPrices.DataSource = New List(Of Price)
        End If

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

    End Sub

    Private Sub ToolStripExit_Click(sender As Object, e As EventArgs) Handles ToolStripExit.Click
        Close()
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

    Private Sub bntLast_Click(sender As Object, e As EventArgs) Handles bntLast.Click
        bs.Position = bookTypes.Count - 1
    End Sub

    Private Sub dgvBooksTypes_SelectionChanged(sender As Object, e As EventArgs) Handles dgvBooksTypes.SelectionChanged
        If bs.Current Is Nothing OrElse bs.Current.Prices.Count = 0 Then
            bsPrices.DataSource = New List(Of Price)
        Else
            bsPrices.DataSource = bs.Current.Prices
        End If

        bsPrices.ResetBindings(False)
    End Sub
End Class