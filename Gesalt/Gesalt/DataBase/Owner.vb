''' <summary>
''' Representa los datos de una fila de la tabla owner de la base de datos.
''' </summary>
<Serializable()>
Public Class Owner

    Public ReadOnly Property Id As Integer

    Public Property Type As String

    Public Property FirstName As String

    Public Property LastName As String

    Public Property Nif As String

    Public Property Address As String

    Public Property Zip As String

    Public Property City As String

    Public Property Province As String

    Public Property Phone As String

    Public Property Email As String

    Public Property PathLogo As String

    ''' <summary>
    ''' Crea una nueva instancia de la clase <c>Owner</c>, asignándole valores por defecto.
    ''' </summary>
    Public Sub New()
        Me.Id = 0
        Me.Type = ""
        Me.FirstName = ""
        Me.LastName = ""
        Me.Nif = ""
        Me.Address = ""
        Me.Zip = ""
        Me.City = ""
        Me.Province = ""
        Me.Phone = ""
        Me.Email = ""
        Me.PathLogo = ""
    End Sub

    ''' <summary>
    ''' Crea una nueva instancia de la clase <c>Owner</c>, asignándole los valores especificados.
    ''' </summary>
    ''' <param name="id">Se corresponde con el campo Id de la tabla owner de la base de datos, que representa el índice de la fila.</param>
    ''' <param name="type">Se corresponde con el campo type de la tabla owner de la base de datos, que representa el tipo de propietario.</param>
    ''' <param name="firstName">Se corresponde con el campo first_name de la tabla owner de la base de datos, que representa el nombre del propietario.</param>
    ''' <param name="lastName">Se corresponde con el campo last_name de la tabla owner de la base de datos, que representa los apellidos del propietario.</param>
    ''' <param name="nif">Se corresponde con el campo nif de la tabla owner de la base de datos, que representa el NIF del propietario.</param>
    ''' <param name="address">Se corresponde con el campo address de la tabla owner de la base de datos, que representa la dirección del propietario.</param>
    ''' <param name="zip">Se corresponde con el campo zip de la tabla owner de la base de datos, que representa el código postal del propietario.</param>
    ''' <param name="city">Se corresponde con el campo city de la tabla owner de la base de datos, que representa la localidad del propietario.</param>
    ''' <param name="province">Se corresponde con el campo province de la tabla owner de la base de datos, que representa la provincia o país del propietario.</param>
    ''' <param name="phone">Se corresponde con el campo phone de la tabla owner de la base de datos, que representa el teléfono del propietario.</param>
    ''' <param name="email">Se corresponde con el campo email de la tabla owner de la base de datos, que representa el correo electrónico del propietario.</param>
    ''' <param name="pathLogo">Se corresponde con el campo path_logo de la tabla owner de la base de datos, que representa la ruta a un logotipo del propietario.</param>
    Public Sub New(id As Integer, type As String, firstName As String, lastName As String,
                   nif As String, address As String, zip As String, city As String,
                   province As String, phone As String, email As String, pathLogo As String)
        Me.Id = id
        Me.Type = type
        Me.FirstName = firstName
        Me.LastName = lastName
        Me.Nif = nif
        Me.Address = address
        Me.Zip = zip
        Me.City = city
        Me.Province = province
        Me.Phone = phone
        Me.Email = email
        Me.PathLogo = pathLogo
    End Sub

End Class
