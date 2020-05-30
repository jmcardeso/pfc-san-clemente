Imports System.Resources

Public Class frmBook
    Public Property editBook As Book
    Public Property prop As Prop
    Public Property bookTypes As New List(Of BookType)
    Public Property guests As New List(Of Guest)

    Dim bookAux As Book
    Dim LocRM As New ResourceManager("Gesalt.WinFormStrings", GetType(frmBook).Assembly)

    Private Sub frmBook_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbxBookTypes.DataSource = bookTypes
        cbxGuests.DataSource = guests

        For i As Integer = 1 To 5
            cbxStatus.Items.Add(LocRM.GetString("bookingStatus" & i))
        Next

        lblProperty.Text = prop.Address

        Utils.MarkBooksInCalendar(prop.Books, mclCalendar)

        If editBook IsNot Nothing Then
            dtpCheckin.Value = editBook.CheckIn
            dtpCheckout.Value = editBook.CheckOut

            Dim thisGuest = From guest In guests Where guest.Id = editBook.GuestId
            cbxGuests.SelectedItem = thisGuest.First

            Dim thisBooking = From book In bookTypes Where book.Id = editBook.BookTypeId
            cbxBookTypes.SelectedItem = thisBooking.First

            mclCalendar.SelectionStart = editBook.CheckIn
            mclCalendar.SelectionEnd = editBook.CheckOut

            cbxStatus.SelectedIndex = editBook.Status
        Else
            cbxGuests.SelectedIndex = 0
            cbxBookTypes.SelectedIndex = 0
            cbxStatus.SelectedIndex = 0
        End If
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnSyncDates_Click(sender As Object, e As EventArgs) Handles btnSyncDates.Click
        mclCalendar.SelectionStart = dtpCheckin.Value
        mclCalendar.SelectionEnd = dtpCheckout.Value
    End Sub
End Class