''' <summary>
''' Representa los datos de una fila de la tabla booktype de la base de datos.
''' </summary>
<Serializable()>
Public Class BookType
    Public Property Id As Integer
    Public Property PropertyId As Integer
    Public Property BTName As String
    Public Property StartDate As Date
    Public Property EndDate As Date
    Public Property UrlWeb As String
    Public Property UrlICalendar As String
    Public Property Prices As New List(Of Price)

    ''' <summary>
    ''' Crea una nueva instancia de la clase <c>BookType</c>, asignándole los valores especificados.
    ''' </summary>
    ''' <param name="id">Se corresponde con el campo Id de la tabla booktype de la base de datos, que representa el índice de la fila.</param>
    ''' <param name="propertyId">Se corresponde con el campo property_id de la tabla booktype de la base de datos, que representa la clave foránea que apunta a la tabla property.</param>
    ''' <param name="bTName">Se corresponde con el campo bt_name de la tabla booktype de la base de datos, que representa el nombre del modo de reserva.</param>
    ''' <param name="startDate">Se corresponde con el campo start_date de la tabla booktype de la base de datos, que representa la fecha de alta en el modo de reserva.</param>
    ''' <param name="endDate">Se corresponde con el campo end_date de la tabla booktype de la base de datos, que representa la fecha de baja del modo de reserva.</param>
    ''' <param name="urlWeb">Se corresponde con el campo url_web de la tabla booktype de la base de datos, que representa la URL de una página web con información del inmueble.</param>
    ''' <param name="urlICalendar">Se corresponde con el campo url_icalendar de la tabla booktype de la base de datos, que representa la URL de un calendario en formato ICalendar con información de las reservas del inmueble en una página web determinada.</param>
    Public Sub New(id As Integer, propertyId As Integer, bTName As String,
                   startDate As Date, endDate As Date, urlWeb As String, urlICalendar As String)
        Me.Id = id
        Me.PropertyId = propertyId
        Me.BTName = bTName
        Me.StartDate = startDate
        Me.EndDate = endDate
        Me.UrlWeb = urlWeb
        Me.UrlICalendar = urlICalendar
    End Sub

    ''' <summary>
    ''' Crea una nueva instancia de la clase <c>BookType</c>, asignándole valores por defecto.
    ''' </summary>
    Public Sub New()
        Me.Id = 0
        Me.PropertyId = 0
        Me.BTName = ""
        Me.StartDate = Now()
        Me.EndDate = New Date(1970, 12, 1)
        Me.UrlWeb = ""
        Me.UrlICalendar = ""
    End Sub

    ''' <summary>
    ''' Devuelve una cadena de texto que representa al objeto de la clase <c>BookType</c> (su nombre).
    ''' </summary>
    ''' <returns>La cadena de texto que representa al objeto de la clase <c>BookType</c>.</returns>
    Public Overrides Function ToString() As String
        Return Me.BTName
    End Function
End Class
