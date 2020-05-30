<Serializable()>
Public Class Book
    Public Property Id As Integer
    Public Property GuestId As Integer
    Public Property PropertyId As Integer
    Public Property BookTypeId As Integer
    Public Property Status As Integer
    Public Property CheckIn As Date
    Public Property CheckOut As Date
    Public Property InvoiceNumber As String

    Public Sub New(id As Integer, guestId As Integer, propertyId As Integer,
                   bookTypeId As Integer, status As Integer, checkIn As Date,
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
        Me.Status = 0
        Me.CheckIn = Now()
        Me.CheckOut = Now()
        Me.InvoiceNumber = ""
    End Sub

    Public Overrides Function ToString() As String
        Return Me.CheckIn.Date & " - " & Me.CheckOut.Date
    End Function
End Class
