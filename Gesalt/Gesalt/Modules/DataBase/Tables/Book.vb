<Serializable()>
Public Class Book
    Public Property Id As Integer
    Public Property GuestId As Integer
    Public Property PropertyId As Integer
    Public Property BookTypeId As Integer
    Public Property Status As String
    Public Property CheckIn As Date
    Public Property CheckOut As Date
    Public Property InvoiceNumber As String

    Public Sub New(id As Integer, guestId As Integer, propertyId As Integer,
                   bookTypeId As Integer, status As String, checkIn As Date,
                   checkOut As Date, invoiceNumber As String)
        Me.Id = id
        Me.GuestId = guestId
        Me.PropertyId = propertyId
        Me.BookTypeId = bookTypeId
        Me.Status = status
        Me.CheckIn = checkIn
        Me.CheckOut = checkOut
        Me.InvoiceNumber = invoiceNumber
    End Sub

    Public Sub New()
        Me.Id = 0
        Me.GuestId = 0
        Me.PropertyId = 0
        Me.BookTypeId = 0
        Me.Status = ""
        Me.CheckIn = Now()
        Me.CheckOut = New Date(1970, 12, 1)
        Me.InvoiceNumber = ""
    End Sub
End Class
