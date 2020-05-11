''' <summary>
''' Representa los datos de una fila de la tabla guest de la base de datos.
''' </summary>
<Serializable()>
Public Class Guest
    Public ReadOnly Property Id As Integer

    Public Property FirstName As String

    Public Property LastName As String

    Public Property Nif As String

    Public Property Address As String

    Public Property Zip As String

    Public Property City As String

    Public Property Province As String

    Public Property Phone As String

    Public Property Email As String

    Public Property Rating As Integer

    Public Property Comments As String

    Public Property AcceptAd As Boolean

    ''' <summary>
    ''' Crea una nueva instancia de la clase <c>Guest</c>, asignándole valores por defecto.
    ''' </summary>
    Public Sub New()
        Me.Id = 0
        Me.FirstName = ""
        Me.LastName = ""
        Me.Nif = ""
        Me.Address = ""
        Me.Zip = ""
        Me.City = ""
        Me.Province = ""
        Me.Phone = ""
        Me.Email = ""
        Me.Rating = 0
        Me.Comments = ""
        Me.AcceptAd = True
    End Sub

    ''' <summary>
    ''' Crea una nueva instancia de la clase <c>Guest</c>, asignándole los valores especificados.
    ''' </summary>
    ''' <param name="id">Se corresponde con el campo Id de la tabla guest de la base de datos, que representa el índice de la fila.</param>
    ''' <param name="firstName">Se corresponde con el campo first_name de la tabla guest de la base de datos, que representa el nombre del cliente.</param>
    ''' <param name="lastName">Se corresponde con el campo last_name de la tabla guest de la base de datos, que representa los apellidos del cliente.</param>
    ''' <param name="nif">Se corresponde con el campo nif de la tabla guest de la base de datos, que representa el NIF del cliente.</param>
    ''' <param name="address">Se corresponde con el campo address de la tabla guest de la base de datos, que representa la dirección del cliente.</param>
    ''' <param name="zip">Se corresponde con el campo zip de la tabla guest de la base de datos, que representa el código postal del cliente.</param>
    ''' <param name="city">Se corresponde con el campo city de la tabla guest de la base de datos, que representa la localidad del cliente.</param>
    ''' <param name="province">Se corresponde con el campo province de la tabla guest de la base de datos, que representa la provincia o país del cliente.</param>
    ''' <param name="phone">Se corresponde con el campo phone de la tabla guest de la base de datos, que representa el teléfono del cliente.</param>
    ''' <param name="email">Se corresponde con el campo email de la tabla guest de la base de datos, que representa el correo electrónico del cliente.</param>
    ''' <param name="rating">Se corresponde con el campo rating de la tabla guest de la base de datos, que representa la valoración del cliente.</param>
    ''' <param name="comments">Se corresponde con el campo comments de la tabla guest de la base de datos, que representa un comentario sobre el cliente.</param>
    ''' <param name="acceptAd">Se corresponde con el campo accept_ad de la tabla guest de la base de datos, que representa si el cliente acepta o no recibir correo publicitario.</param>
    Public Sub New(id As Integer, firstName As String, lastName As String,
               nif As String, address As String, zip As String, city As String,
               province As String, phone As String, email As String, rating As Integer,
               comments As String, acceptAd As Boolean)
        Me.Id = id
        Me.FirstName = firstName
        Me.LastName = lastName
        Me.Nif = nif
        Me.Address = address
        Me.Zip = zip
        Me.City = city
        Me.Province = province
        Me.Phone = phone
        Me.Email = email
        Me.Rating = rating
        Me.Comments = comments
        Me.AcceptAd = acceptAd
    End Sub
End Class
