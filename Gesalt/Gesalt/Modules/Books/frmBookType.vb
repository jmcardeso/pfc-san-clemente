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
        If bs.Position < bs.Count - 1 Then
            bs.Position += 1
        End If
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

        If bs.Current.EndDate.Equals(New Date(1, 1, 1)) OrElse bs.Current.EndDate.Year = 1970 Then
            lblEndDate.Text = ""
        End If

        bsPrices.ResetBindings(False)
    End Sub

    Private Sub ToolStripAdd_Click(sender As Object, e As EventArgs) Handles ToolStripAdd.Click
        Dim frmAux As New frmBookTypeAux With {
            .editBT = Nothing
        }

        If frmAux.ShowDialog = DialogResult.Cancel Then
            Exit Sub
        End If

        frmAux.editBT.PropertyId = propertyId

        Dim id As Integer = opBook.AddBookType(frmAux.editBT)
        If id < 1 Then
            MsgBox(LocRM.GetString("opFailedMsg"), MsgBoxStyle.Exclamation, LocRM.GetString("opFailedTitle"))
            Exit Sub
        End If

        ' Se añade el objeto a la lista, incluyendo la id que obtuvimos al insertarlo en la base de datos
        Dim newBT As New BookType()
        newBT = Utils.DeepClone(frmAux.editBT)
        newBT.Id = id

        If newBT.EndDate.Year = 1970 Then
            newBT.EndDate = Nothing
        End If

        bookTypes.Add(newBT)

        bs.ResetBindings(False)
    End Sub

    Private Sub ToolStripEdit_Click(sender As Object, e As EventArgs) Handles ToolStripEdit.Click, dgvBooksTypes.DoubleClick
        If bs.Current Is Nothing Then
            Exit Sub
        End If

        Dim frmAux As New frmBookTypeAux With {
            .editBT = bs.Current
        }

        If frmAux.ShowDialog = DialogResult.Cancel Then
            Exit Sub
        End If

        Dim btAux As BookType = Utils.DeepClone(bookTypes.Item(bs.Position))
        bookTypes.Item(bs.Position) = Utils.DeepClone(frmAux.editBT)

        If Not opBook.UpdateBookType(bookTypes.Item(bs.Position)) Then
            MsgBox(LocRM.GetString("opFailedMsg"), MsgBoxStyle.Exclamation, LocRM.GetString("opFailedTitle"))
            bookTypes.Item(bs.Position) = Utils.DeepClone(btAux)
            Exit Sub
        End If

        If bookTypes.Item(bs.Position).EndDate.Year = 1970 Then
            bookTypes.Item(bs.Position).EndDate = Nothing
        End If

        bs.ResetBindings(False)
    End Sub
End Class