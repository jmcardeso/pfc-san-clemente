Imports System.Resources

Public Class frmBook
    Public Property editBook As Book
    Private _IsEdited As Boolean
    Public ReadOnly Property IsEdited As Boolean
        Get
            Return _IsEdited
        End Get
    End Property

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

        If editBook.Id = 0 Then
            cbxGuests.SelectedIndex = 0
            cbxBookTypes.SelectedIndex = 0
            _IsEdited = False
        Else
            Dim thisGuest = From guest In guests Where guest.Id = editBook.GuestId
            cbxGuests.SelectedItem = thisGuest.First

            Dim thisBooking = From book In bookTypes Where book.Id = editBook.BookTypeId
            cbxBookTypes.SelectedItem = thisBooking.First
            _IsEdited = True
        End If

        bookAux = Utils.DeepClone(editBook)

        RemoveHandler mclCalendar.DateChanged, AddressOf mclCalendar_DateChanged

        dtpCheckin.DataBindings.Add("Value", bookAux, "CheckIn")
        dtpCheckout.DataBindings.Add("Value", bookAux, "CheckOut")
        cbxStatus.DataBindings.Add("SelectedIndex", bookAux, "Status")
        tbxInvoiceNumber.DataBindings.Add("Text", bookAux, "InvoiceNumber")

        mclCalendar.SelectionStart = bookAux.CheckIn
        mclCalendar.SelectionEnd = bookAux.CheckOut

        AddHandler mclCalendar.DateChanged, AddressOf mclCalendar_DateChanged
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If Not ValidateFields() Then
            Exit Sub
        End If

        editBook = Utils.DeepClone(bookAux)

        Me.DialogResult = DialogResult.OK
    End Sub

    Private Function ValidateFields() As Boolean
        If editBook.Status = BK_COMPLETED AndAlso bookAux.Status <> BK_COMPLETED Then
            If MsgBox(LocRM.GetString("bookingCompletedErrorMsg"),
                   MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2, "Gesalt") = MsgBoxResult.No Then
                Return False
            End If
        End If

        If bookAux.CheckIn > bookAux.CheckOut Then
            MsgBox(LocRM.GetString("startDateAfterEndDate3"), MsgBoxStyle.Exclamation, "Gesalt")
            Return False
        End If

        bookAux.BookTypeId = CType(cbxBookTypes.SelectedItem, BookType).Id
        bookAux.GuestId = CType(cbxGuests.SelectedItem, Guest).Id
        bookAux.CheckIn = dtpCheckin.Value.Date
        bookAux.CheckOut = dtpCheckout.Value.Date

        If IsEdited AndAlso (editBook.GuestId <> bookAux.GuestId Or
            editBook.BookTypeId <> bookAux.BookTypeId Or editBook.CheckIn <> bookAux.CheckIn Or
            editBook.CheckOut <> bookAux.CheckOut) Then
            If MsgBox(LocRM.GetString("bookingChangeData"),
               MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2, "Gesalt") = MsgBoxResult.No Then
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnSyncDates_Click(sender As Object, e As EventArgs) Handles btnSyncDates.Click
        mclCalendar.SelectionStart = dtpCheckin.Value
        mclCalendar.SelectionEnd = dtpCheckout.Value
    End Sub

    Private Sub mclCalendar_DateSelected(sender As Object, e As DateRangeEventArgs) Handles mclCalendar.DateSelected
        dtpCheckin.Value = mclCalendar.SelectionStart
        dtpCheckout.Value = mclCalendar.SelectionEnd
    End Sub

    Private Sub mclCalendar_DateChanged(sender As Object, e As DateRangeEventArgs) Handles mclCalendar.DateChanged
        ' Se elimina el evento para que no se dispare dentro de él (al añadir una BoldedDate)
        RemoveHandler mclCalendar.DateChanged, AddressOf mclCalendar_DateChanged

        If mclCalendar.BoldedDates.Contains(e.Start.Date) And mclCalendar.BoldedDates.Contains(e.End.Date) Then
            Dim limits(2) As Date

            limits = Utils.GetBookLimits(prop, e.Start)
            mclCalendar.SelectionStart = limits(0)
            mclCalendar.SelectionEnd = limits(1)

            dtpCheckin.Value = limits(0)
            dtpCheckout.Value = limits(1)
        End If

        ' Se vuelve a añadir el evento al salir
        AddHandler mclCalendar.DateChanged, AddressOf mclCalendar_DateChanged
    End Sub

    Private Sub dtpCheckin_ValueChanged(sender As Object, e As EventArgs) Handles dtpCheckin.ValueChanged
        mclCalendar.SelectionStart = dtpCheckin.Value
    End Sub

    Private Sub dtpCheckout_ValueChanged(sender As Object, e As EventArgs) Handles dtpCheckout.ValueChanged
        mclCalendar.SelectionEnd = dtpCheckout.Value
    End Sub

    Private Sub cbxStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxStatus.SelectedIndexChanged
        If cbxStatus.SelectedIndex = BK_COMPLETED AndAlso editBook.Status <> BK_COMPLETED Then
            Dim opBook As OpBook = OpBook.GetInstance()

            tbxInvoiceNumber.Text = opBook.GetInvoiceNumber(prop.Id)
        End If
    End Sub

    Private Sub btnPrintInvoice_Click(sender As Object, e As EventArgs) Handles btnPrintInvoice.Click
        If cbxStatus.SelectedIndex <> BK_COMPLETED And editBook.Status <> BK_COMPLETED Then
            MsgBox(LocRM.GetString("bookingInvoicePrintErrorMsg"), MsgBoxStyle.Exclamation, "Gesalt")
            Exit Sub
        End If

        MsgBox("Print!")
    End Sub
End Class