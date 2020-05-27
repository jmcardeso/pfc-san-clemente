Public Class frmBook
    Public Property editBook As Book
    Public Property prop As Prop
    Public Property bookTypes As New List(Of BookType)
    Public Property guests As New List(Of Guest)

    Dim opBook As OpBook
    Dim bookAux As Book
    Dim books As New List(Of Book)

    Private Sub frmBook_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbxBookTypes.DataSource = bookTypes
        cbxGuests.DataSource = guests

        lblProperty.Text = prop.Address

        opBook = OpBook.GetInstance()
        books = opBook.GetBooksByPropertyId(prop.Id)

        For Each book As Book In books
            For Each d As Date In InBetween(book.CheckIn, book.CheckOut)
                mclBooks.AddBoldedDate(d)
            Next
        Next
        mclBooks.UpdateBoldedDates()

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub
    Private Function InBetween(d1 As Date, d2 As Date) As List(Of Date)
        Dim datesIB As New List(Of Date)

        While d1 <= d2
            datesIB.Add(d1)
            d1 = d1.AddDays(1)
        End While

        Return datesIB
    End Function
End Class