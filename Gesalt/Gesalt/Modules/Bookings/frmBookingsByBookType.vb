Imports System.Resources

Public Class frmBookingsByBookType
    Dim LocRM As New ResourceManager("Gesalt.WinFormStrings", GetType(frmBookingsByBookType).Assembly)

    Dim bookTypes As New List(Of BookType)
    Dim books As New List(Of Book)
    Dim props As New List(Of Prop)

    Dim opBook As OpBook = OpBook.GetInstance()
    Dim opProp As OpProp = OpProp.GetInstance()

    Private Sub frmBookingsByBookType_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bookTypes = opBook.GetAllBookTypes()
        props = opProp.GetProps()

        For Each bt As BookType In bookTypes
            If Not cbxSelect.Items.Contains(bt.BTName) Then
                cbxSelect.Items.Add(bt.BTName)
            End If
        Next

        If cbxSelect.Items.Count > 0 Then
            cbxSelect.SelectedIndex = 0
        End If
    End Sub

    Private Sub cbxSelect_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxSelect.SelectedIndexChanged
        cbxProps.Items.Clear()

        Dim propsByBookType = From bt In bookTypes, prop In props Where bt.BTName.Equals(cbxSelect.SelectedItem) And
                                                                      bt.PropertyId = prop.Id
                              Select prop

        Dim pbt As List(Of Prop) = propsByBookType.ToList

        For Each p As Prop In pbt
            cbxProps.Items.Add(p)
        Next
        If cbxProps.Items.Count > 0 Then
            cbxProps.SelectedIndex = 0
        End If
    End Sub

    Private Sub cbxProps_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxProps.SelectedIndexChanged
        Dim books As New List(Of Book)
        Dim opBook As OpBook = OpBook.GetInstance()

        Dim opGuest As OpGuest = OpGuest.GetInstance()
        Dim guest As Guest

        Dim strInfo As String = ""
        Dim btName As String = cbxSelect.SelectedItem
        Dim propId As Integer = CType(cbxProps.SelectedItem, Prop).Id

        tbxBookings.Text = ""

        books = opBook.GetBooksByPropertyId(propId)

        Dim booksByProp = From book In books, bt In bookTypes Where book.PropertyId = propId And
                                                                  book.BookTypeId = bt.Id And bt.BTName.Equals(btName)
                          Select book Order By book.CheckIn

        Dim booksAux As List(Of Book) = booksByProp.ToList

        If booksAux.Count = 0 Then
            Exit Sub
        End If

        For Each book As Book In booksByProp
            strInfo &= LocRM.GetString("bookBT") & " "
            strInfo &= opBook.GetBookTypeById(book.BookTypeId).BTName & vbNewLine & LocRM.GetString("bookGuest") & " "
            guest = opGuest.GuetGuestById(book.GuestId)
            strInfo &= guest.LastName & ", " & guest.FirstName & vbNewLine
            strInfo &= LocRM.GetString("bookDays") & " "
            strInfo &= book.CheckIn.ToShortDateString & " - " & book.CheckOut.ToShortDateString & vbNewLine
            strInfo &= LocRM.GetString("bookStatus") & " " & Utils.GetBookStatusString(book.Status) & vbNewLine & "---------------------------------------------------" & vbNewLine
        Next

        tbxBookings.Text = strInfo.Substring(0, strInfo.Length - 54)
    End Sub
End Class