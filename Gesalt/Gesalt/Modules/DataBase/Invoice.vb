Imports System.Data.Common

Public Class Invoice
    Public Property Book As Book
    Public Property Prop As Prop
    Public Property BookType As BookType
    Public Property Guest As Guest

    Private con As Connection = Connection.GetInstance()

    Public Sub New(book As Book)
        Dim opProp As OpProp = OpProp.GetInstance()
        Dim opBookType As OpBook = OpBook.GetInstance()
        Dim opGuest As OpGuest = OpGuest.GetInstance()
        Dim parameters As New List(Of DbParameter)
        Dim pPropId As DbParameter

        Me.Book = book

        pPropId = con.Factory.CreateParameter()
        pPropId.ParameterName = "@p_property_Id"
        pPropId.Value = book.PropertyId
        pPropId.DbType = DbType.Int32
        parameters.Add(pPropId)

        Me.Prop = opProp.GetProps("select from property where Id = @p_property_Id", parameters).Item(0)

        Me.BookType = opBookType.GetBookTypeById(book.BookTypeId)

        Me.Guest = opGuest.GuetGuestById(book.GuestId)
    End Sub
End Class
