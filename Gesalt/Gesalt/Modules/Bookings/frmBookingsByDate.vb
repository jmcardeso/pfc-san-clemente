Imports System.Resources

Public Class frmBookingsByDate
    Dim LocRM As New ResourceManager("Gesalt.WinFormStrings", GetType(frmBookingsByDate).Assembly)

    Private Sub cbxProperties_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxProperties.SelectedIndexChanged,
            dtpCheckin.ValueChanged, dtpCheckout.ValueChanged
        Dim books As New List(Of Book)
        Dim opBook As OpBook = OpBook.GetInstance()

        Dim opGuest As OpGuest = OpGuest.GetInstance()
        Dim guest As Guest

        Dim strInfo As String = ""
        Dim propId As Integer = CType(cbxProperties.SelectedItem, Prop).Id

        tbxBookings.Text = ""

        books = OpBook.GetBooksByPropertyId(propId)

        Dim booksByDate = From book In books Where book.CheckIn >= dtpCheckin.Value.Date And book.CheckOut <= dtpCheckout.Value.Date
                          Order By book.CheckIn
        Dim booksAux As List(Of Book) = booksByDate.ToList

        If booksAux.Count = 0 Then
            Exit Sub
        End If

        For Each book As Book In booksByDate
            strInfo &= LocRM.GetString("bookBT") & " "
            strInfo &= OpBook.GetBookTypeById(book.BookTypeId).BTName & vbNewLine & LocRM.GetString("bookGuest") & " "
            guest = OpGuest.GuetGuestById(book.GuestId)
            strInfo &= guest.LastName & ", " & guest.FirstName & vbNewLine
            strInfo &= LocRM.GetString("bookDays") & " "
            strInfo &= book.CheckIn.ToShortDateString & " - " & book.CheckOut.ToShortDateString & vbNewLine
            strInfo &= LocRM.GetString("bookStatus") & " " & Utils.GetBookStatusString(book.Status) & vbNewLine & "---------------------------------------------------" & vbNewLine
        Next

        tbxBookings.Text = strInfo.Substring(0, strInfo.Length - 54)
    End Sub
End Class