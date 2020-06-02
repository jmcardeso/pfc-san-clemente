''' <summary>
''' Representa los datos de una fila de la tabla book de la base de datos.
''' </summary>
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

    ''' <summary>
    ''' Crea una nueva instancia de la clase <c>Book</c>, asignándole los valores especificados.
    ''' </summary>
    ''' <param name="id">Se corresponde con el campo Id de la tabla book de la base de datos, que representa el índice de la fila.</param>
    ''' <param name="guestId">Se corresponde con el campo guest_id de la tabla book de la base de datos, que representa la clave foránea que apunta a la tabla guest.</param>
    ''' <param name="propertyId">Se corresponde con el campo property_id de la tabla book de la base de datos, que representa la clave foránea que apunta a la tabla property.</param>
    ''' <param name="bookTypeId">Se corresponde con el campo booktype_id de la tabla book de la base de datos, que representa la clave foránea que apunta a la tabla booktype.</param>
    ''' <param name="status">Se corresponde con el campo status de la tabla book de la base de datos, que representa el estado de la reserva.</param>
    ''' <param name="checkIn">Se corresponde con el campo checkin de la tabla book de la base de datos, que representa la fecha de inicio de la reserva.</param>
    ''' <param name="checkOut">Se corresponde con el campo checkout de la tabla book de la base de datos, que representa la fecha de fin de la reserva.</param>
    ''' <param name="invoiceNumber">Se corresponde con el campo invoice_number de la tabla book de la base de datos, que representa el número de factura de la reserva.</param>
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

    ''' <summary>
    ''' Crea una nueva instancia de la clase <c>Book</c>, asignándole valores por defecto.
    ''' </summary>
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

    ''' <summary>
    ''' Devuelve una cadena de texto que representa al objeto de la clase <c>Book</c> (fecha de inicio - fecha de fin).
    ''' </summary>
    ''' <returns>La cadena de texto que representa al objeto de la clase <c>Book</c>.</returns>
    Public Overrides Function ToString() As String
        Return Me.CheckIn.Date & " - " & Me.CheckOut.Date
    End Function
End Class
