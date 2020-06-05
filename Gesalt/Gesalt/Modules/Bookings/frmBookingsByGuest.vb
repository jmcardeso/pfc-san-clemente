Public Class frmBookingsByGuest
    Dim books As New List(Of Book)
    Dim props As New List(Of Prop)

    Dim opBook As OpBook = OpBook.GetInstance()
    Dim opProp As OpProp = OpProp.GetInstance()

    Private Sub cbxSelect_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxSelect.SelectedIndexChanged
        Dim guestId As Integer = CType(cbxSelect.SelectedItem, Guest).Id

        books = opBook.GetBooksByGuestId(guestId)
        props = opProp.GetProps()
        cbxProps.Items.Clear()

        For Each book As Book In books
            Dim propAux = From prop In props Where prop.Id = book.PropertyId

            If Not cbxProps.Items.Contains(propAux.First) Then
                cbxProps.Items.Add(propAux.First)
            End If
        Next

        If cbxProps.Items.Count > 0 Then
            cbxProps.SelectedIndex = 0
        Else
            lblBookings.Text = ""
        End If

    End Sub

    Private Sub cbxProps_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxProps.SelectedIndexChanged
        Dim booksByProp As New List(Of Book)
        Dim text As String = ""

        Dim propId As Integer = CType(cbxProps.SelectedItem, Prop).Id

        Dim bookAux = From book In books Where book.PropertyId = propId Order By book.CheckIn
        booksByProp = bookAux.ToList

        For Each book As Book In booksByProp
            text &= opBook.GetBookTypeById(book.BookTypeId).BTName & vbNewLine
            text &= book.ToString & vbNewLine
            text &= Utils.GetBookStatusString(book.Status) & vbNewLine
            text &= "--------------------------------------------------" & vbNewLine
        Next

        lblBookings.Text = text.Substring(0, text.Length - 54)
    End Sub
End Class