﻿Public Class frmBook
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

        Utils.MarkBooksInCalendar(books, mclBooks)

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub
End Class