''' <summary>
''' Representa los datos de una fila de la tabla price de la base de datos.
''' </summary>
<Serializable()>
Public Class Price
    Public Property Id As Integer
    Public Property BookTypeId As Integer
    Public Property Value As Decimal
    Public Property Type As String
    Public Property StartDate As Date
    Public Property EndDate As Date
    Public Property Percentage As Boolean

    ''' <summary>
    ''' Crea una nueva instancia de la clase <c>Price</c>, asignándole los valores especificados.
    ''' </summary>
    ''' <param name="id">Se corresponde con el campo Id de la tabla price de la base de datos, que representa el índice de la fila.</param>
    ''' <param name="bookTypeId">Se corresponde con el campo booktype_id de la tabla price de la base de datos, que representa la clave foránea que apunta a la tabla booktype.</param>
    ''' <param name="value">Se corresponde con el campo value de la tabla price de la base de datos, que representa el valor de un precio.</param>
    ''' <param name="type">Se corresponde con el campo type de la tabla price de la base de datos, que representa el tipo de precio.</param>
    ''' <param name="startDate">Se corresponde con el campo start_date de la tabla price de la base de datos, que representa la fecha a partir de la cual es efectivo un precio.</param>
    ''' <param name="endDate">Se corresponde con el campo end_date de la tabla price de la base de datos, que representa la fecha en la que deja de ser efectivo un precio.</param>
    ''' <param name="percentage">Se corresponde con el campo percentage de la tabla price de la base de datos, que representa si el precio es una cantidad o un porcentaje.</param>
    Public Sub New(id As Integer, bookTypeId As Integer, value As Decimal,
                   type As String, startDate As Date, endDate As Date, percentage As Decimal)
        Me.Id = id
        Me.BookTypeId = bookTypeId
        Me.Value = value
        Me.Type = type
        Me.StartDate = startDate
        Me.EndDate = endDate
        Me.Percentage = percentage
    End Sub

    ''' <summary>
    ''' Crea una nueva instancia de la clase <c>Price</c>, asignándole los valores por defecto.
    ''' </summary>
    Public Sub New()
        Me.Id = 0
        Me.BookTypeId = 0
        Me.Value = 0
        Me.Type = ""
        Me.StartDate = Now()
        Me.EndDate = New Date(1970, 12, 1)
        Me.Percentage = False
    End Sub
End Class
