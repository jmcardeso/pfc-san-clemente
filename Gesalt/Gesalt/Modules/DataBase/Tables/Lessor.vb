''' <summary>
''' Representa los datos de una fila de la tabla lessor de la base de datos.
''' </summary>
<Serializable()>
Public Class Lessor

    Public Property Id As Integer

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
    ''' Crea una nueva instancia de la clase <c>Lessor</c>, asignándole valores por defecto.
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
    ''' Crea una nueva instancia de la clase <c>Lessor</c>, asignándole los valores especificados.
    ''' </summary>
    ''' <param name="id">Se corresponde con el campo Id de la tabla lessor de la base de datos, que representa el índice de la fila.</param>
    ''' <param name="type">Se corresponde con el campo type de la tabla lessor de la base de datos, que representa el tipo de arrendador.</param>
    ''' <param name="firstName">Se corresponde con el campo first_name de la tabla lessor de la base de datos, que representa el nombre del arrendador.</param>
    ''' <param name="lastName">Se corresponde con el campo last_name de la tabla lessor de la base de datos, que representa los apellidos del arrendador.</param>
    ''' <param name="nif">Se corresponde con el campo nif de la tabla lessor de la base de datos, que representa el NIF del arrendador.</param>
    ''' <param name="address">Se corresponde con el campo address de la tabla lessor de la base de datos, que representa la dirección del arrendador.</param>
    ''' <param name="zip">Se corresponde con el campo zip de la tabla lessor de la base de datos, que representa el código postal del arrendador.</param>
    ''' <param name="city">Se corresponde con el campo city de la tabla lessor de la base de datos, que representa la localidad del arrendador.</param>
    ''' <param name="province">Se corresponde con el campo province de la tabla lessor de la base de datos, que representa la provincia o país del arrendador.</param>
    ''' <param name="phone">Se corresponde con el campo phone de la tabla lessor de la base de datos, que representa el teléfono del arrendador.</param>
    ''' <param name="email">Se corresponde con el campo email de la tabla lessor de la base de datos, que representa el correo electrónico del arrendador.</param>
    ''' <param name="pathLogo">Se corresponde con el campo path_logo de la tabla lessor de la base de datos, que representa la ruta a un logotipo del arrendador.</param>
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

    ''' <summary>
    ''' Devuelve una cadena de texto que representa un objeto de la clase <c>Lessor</c> (Apellidos, Nombre).
    ''' </summary>
    ''' <returns>La cadena de texto que representa un objeto de la clase <c>Lessor</c>.</returns>
    Public Overrides Function ToString() As String
        Return Me.LastName & ", " & Me.FirstName
    End Function
End Class
