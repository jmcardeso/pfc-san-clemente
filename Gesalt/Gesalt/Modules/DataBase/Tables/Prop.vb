''' <summary>
''' Representa los datos de una fila de la tabla property de la base de datos.
''' </summary>
<Serializable()>
Public Class Prop
    Public Property Id As Integer
    Public Property CadRef As String
    Public Property Address As String
    Public Property Zip As String
    Public Property City As String
    Public Property Province As String
    Public Property MaxGuests As Integer
    Public Property Size As Integer
    Public Property Bedrooms As Integer
    Public Property Baths As Integer
    Public Property Description As String
    Public Property Photos As New List(Of Photo)
    Public Property Lessors As New List(Of LessorProp)
    Public Property Books As New List(Of Book)
    Public Property PropClass As PropClass

    ''' <summary>
    ''' Crea una nueva instancia de la clase <c>Prop</c>, asignándole los valores por defecto.
    ''' </summary>
    Public Sub New()
        Me.Id = 0
        Me.CadRef = ""
        Me.Address = ""
        Me.Zip = ""
        Me.City = ""
        Me.Province = ""
        Me.MaxGuests = 0
        Me.Size = 0
        Me.Bedrooms = 0
        Me.Baths = 0
        Me.Description = ""
        Me.Photos = New List(Of Photo)
        Me.Lessors = New List(Of LessorProp)
        Me.Books = New List(Of Book)
        Me.PropClass = New PropClass()
    End Sub

    ''' <summary>
    ''' Crea una nueva instancia de la clase <c>Prop</c>, asignándole los valores especificados.
    ''' </summary>
    ''' <param name="id">Se corresponde con el campo Id de la tabla property de la base de datos, que representa el índice de la fila.</param>
    ''' <param name="cadRef">Se corresponde con el campo cad_ref de la tabla property de la base de datos, que representa la referencia catastral de un inmueble.</param>
    ''' <param name="address">Se corresponde con el campo address de la tabla property de la base de datos, que representa la dirección del inmueble.</param>
    ''' <param name="zip">Se corresponde con el campo zip de la tabla property de la base de datos, que representa el código postal del inmueble.</param>
    ''' <param name="city">Se corresponde con el campo city de la tabla property de la base de datos, que representa la localidad del inmueble.</param>
    ''' <param name="province">Se corresponde con el campo province de la tabla property de la base de datos, que representa la provincia o país del inmueble.</param>
    ''' <param name="maxGuests">Se corresponde con el campo max_guests de la tabla property de la base de datos, que representa el número máximo de clientes que se pueden alojar en el inmueble.</param>
    ''' <param name="size">Se corresponde con el campo size de la tabla property de la base de datos, que representa la superficie del inmueble.</param>
    ''' <param name="bedRooms">Se corresponde con el campo bedrooms de la tabla property de la base de datos, que representa el número de dormitorios del inmueble.</param>
    ''' <param name="baths">Se corresponde con el campo baths de la tabla property de la base de datos, que representa el número de cuartos de baño del inmueble.</param>
    ''' <param name="description">Se corresponde con el campo description de la tabla property de la base de datos, que representa la descripción del inmueble.</param>
    Public Sub New(id As Integer, cadRef As String, address As String, zip As String, city As String,
                   province As String, maxGuests As Integer, size As Decimal, bedRooms As Integer,
                   baths As Integer, description As String)
        Me.Id = id
        Me.CadRef = cadRef
        Me.Address = address
        Me.Zip = zip
        Me.City = city
        Me.Province = province
        Me.MaxGuests = maxGuests
        Me.Size = size
        Me.Bedrooms = bedRooms
        Me.Baths = baths
        Me.Description = description
    End Sub

    Public Overrides Function ToString() As String
        Return Me.Address
    End Function
End Class
