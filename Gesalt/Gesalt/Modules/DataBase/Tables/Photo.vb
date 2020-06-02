''' <summary>
''' Representa los datos de una fila de la tabla photo de la base de datos.
''' </summary>
<Serializable()>
Public Class Photo
    Public Property Id As Integer
    Public Property PropertyId As Integer
    Public Property Path As String

    ''' <summary>
    ''' Crea una nueva instancia de la clase <c>Photo</c>, asignándole los valores por defecto.
    ''' </summary>
    Public Sub New()
        Me.Id = 0
        Me.PropertyId = 0
        Me.Path = ""
    End Sub

    ''' <summary>
    ''' Crea una nueva instancia de la clase <c>Photo</c>, asignándole los valores especificados.
    ''' </summary>
    ''' <param name="id">Se corresponde con el campo Id de la tabla photo de la base de datos, que representa el índice de la fila.</param>
    ''' <param name="propertyId">Se corresponde con el campo property_id de la tabla photo de la base de datos, que representa la clave foránea que apunta a la tabla property.</param>
    ''' <param name="path">Se corresponde con el campo path de la tabla photo de la base de datos, que representa la ruta a una imagen del inmueble.</param>
    Public Sub New(id As Integer, propertyId As Integer, path As String)
        Me.Id = id
        Me.PropertyId = propertyId
        Me.Path = path
    End Sub
End Class
