Imports System.Resources

Public Class frmBookType
    Public Property propertyId As Integer
    Dim bookTypes As New List(Of BookType)
    Dim bs As New BindingSource()
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
End Class