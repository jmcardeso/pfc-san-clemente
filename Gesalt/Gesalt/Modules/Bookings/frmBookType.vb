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
            column.Width = 280
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

        ' Creamos un Binding para este control que genere un evento cada vez que tiene que dar formato a los datos
        Dim bindingStartDate As Binding = New Binding("Text", bs, "StartDate")
        AddHandler bindingStartDate.Format, AddressOf DateWihtoutTime
        lblStartDate.DataBindings.Add(bindingStartDate)

        Dim bindingEndDate As Binding = New Binding("Text", bs, "EndDate")
        AddHandler bindingEndDate.Format, AddressOf DateWihtoutTime
        lblEndDate.DataBindings.Add(bindingEndDate)

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
            column.Width = 100
            .Columns(0).Name = "Type"
            .Columns(0).HeaderText = LocRM.GetString("fieldType")
            .Columns(0).DataPropertyName = "Type"

            column = .Columns(1)
            column.Width = 70
            .Columns(1).Name = "StartDate"
            .Columns(1).HeaderText = LocRM.GetString("fieldStartDate2")
            .Columns(1).DataPropertyName = "StartDate"

            column = .Columns(2)
            column.Width = 70
            .Columns(2).Name = "EndDate"
            .Columns(2).HeaderText = LocRM.GetString("fieldEndDate2")
            .Columns(2).DataPropertyName = "EndDate"

            column = .Columns(3)
            column.Width = 50
            .Columns(3).Name = "Value"
            .Columns(3).HeaderText = LocRM.GetString("fieldValue")
            .Columns(3).DataPropertyName = "Value"
            .Columns(3).DefaultCellStyle.Format = "N2"

            column = .Columns(4)
            column.Width = 30
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
            If Utils.IsEndDateEmpty(bs.Current.EndDate) Then
                lblEndDate.Text = ""
            End If
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

        For Each price As Price In newBT.Prices
            price.BookTypeId = id
        Next

        newBT.EndDate = Utils.EndDateToObject(newBT.EndDate)

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

        bookTypes.Item(bs.Position).EndDate = Utils.EndDateToObject(bookTypes.Item(bs.Position).EndDate)

        bs.ResetBindings(False)
    End Sub

    Private Sub ToolStripDelete_Click(sender As Object, e As EventArgs) Handles ToolStripDelete.Click
        If bs.Current Is Nothing Then
            Exit Sub
        End If

        If Not opBook.IsSafeDeleteBookType(bs.Current.Id) Then
            MsgBox(LocRM.GetString("btNoDeleted"), MsgBoxStyle.Exclamation, "Gesalt")
            Exit Sub
        End If

        If MsgBox(LocRM.GetString("rowRemovedBookTypeMsg") & "'" & bs.Current.BTName & "' " & LocRM.GetString("rowRemovedMsg"),
      MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2,
      LocRM.GetString("rowRemovedTitle")) = MsgBoxResult.No Then
            Exit Sub
        End If

        If Not opBook.DeleteBookType(bs.Current) Then
            MsgBox(LocRM.GetString("opFailedMsg"), MsgBoxStyle.Exclamation, LocRM.GetString("opFailedTitle"))
            Exit Sub
        End If

        bookTypes.Remove(bs.Current)
        bs.ResetBindings(False)
    End Sub

    ' Evento que se dispara cada vez que el control vinculado a una fuente de datos escribe el dato.
    ' En este caso, hace que sólo se muestre la fecha sin la hora.
    Private Sub DateWihtoutTime(sender As Object, dateEvent As ConvertEventArgs)
        If sender.BindingMemberInfo.BindingField.Equals("EndDate") Then
            If Utils.IsEndDateEmpty(dateEvent.Value) Then
                dateEvent.Value = Nothing
            Else
                dateEvent.Value = FormatDateTime(Utils.EndDateToObject(dateEvent.Value), DateFormat.ShortDate)
            End If
        Else
            dateEvent.Value = FormatDateTime(dateEvent.Value, DateFormat.ShortDate)
        End If
    End Sub

    ' El DataGridView ya implementa sus propios eventos para dar formato a los datos.
    ' En el tipo de reserva, hacemos que se muestre la fecha sin la hora.
    Private Sub dgvBooksTypes_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvBooksTypes.CellFormatting
        If dgvBooksTypes.Columns(e.ColumnIndex).ValueType Is GetType(Date) Then
            If dgvBooksTypes.Columns(e.ColumnIndex).DataPropertyName.Equals("EndDate") AndAlso Utils.IsEndDateEmpty(e.Value) Then
                e.Value = Nothing
            Else
                e.Value = FormatDateTime(Utils.EndDateToObject(e.Value), DateFormat.ShortDate)
            End If
        End If
    End Sub

    ' En el dgv de los precios, además de formatear la fecha, convierte el True/False del booleano "Percentage" en Sí/No.
    Private Sub dgvPrices_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvPrices.CellFormatting
        If dgvPrices.Columns(e.ColumnIndex).ValueType Is GetType(Date) Then
            If dgvPrices.Columns(e.ColumnIndex).DataPropertyName.Equals("EndDate") AndAlso Utils.IsEndDateEmpty(e.Value) Then
                e.Value = Nothing
            Else
                e.Value = FormatDateTime(Utils.EndDateToObject(e.Value), DateFormat.ShortDate)
            End If
        End If

        ' TODO: Se puede hacer, y quedaría mucho más visual, que esta celda sea de tipo imagen y, en lugar de texto, apareciera un símbolo gráfico.
        If dgvPrices.Columns(e.ColumnIndex).Name.Equals("Percentage") Then
            If e.Value Then
                e.Value = LocRM.GetString("Yes")
            Else
                e.Value = LocRM.GetString("No")
            End If
        End If
    End Sub
End Class