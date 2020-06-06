''' <summary>
''' Representa los datos de una fila de la tabla prop_class de la base de datos.
''' </summary>
<Serializable>
Public Class PropClass
    Public Property Id As Integer
    Public Property PropId As Integer
    Public Property ClassId As Integer
    Public Property StartDate As Date
    Public Property Keys As Integer
    Public Property VAT As Decimal
    Public Property LegalClass As LegalClassification

    ''' <summary>
    ''' Crea una nueva instancia de la clase <c>PropClass</c> asignándole los valores especificados.
    ''' </summary>
    ''' <param name="id">Se corresponde con el campo Id de la tabla prop_class de la base de datos, que representa el índice de la fila.</param>
    ''' <param name="propId">Se corresponde con el campo property_id de la tabla prop_class de la base de datos, que representa el índice del inmueble asociado.</param>
    ''' <param name="classId">Se corresponde con el campo class_id de la tabla prop_class de la base de datos, que representa el índice de la clasificación legal asociada.</param>
    ''' <param name="startDate">Se corresponde con el campo start_date de la tabla prop_class de la base de datos, que representa la fecha de alta de la clasificación legal del inmueble.</param>
    ''' <param name="keys">Se corresponde con el campo keys de la tabla prop_class de la base de datos, que representa la clasificación en llaves del inmueble.</param>
    ''' <param name="vat">Se corresponde con el campo vat de la tabla prop_class de la base de datos, que representa el IVA correspondiente a la clasificación legal del inmueble.</param>
    Public Sub New(id As Integer, propId As Integer, classId As Integer, startDate As Date, keys As Integer, vat As Decimal)
        Me.Id = id
        Me.PropId = propId
        Me.ClassId = classId
        Me.StartDate = startDate
        Me.Keys = keys
        Me.VAT = vat
    End Sub

    ''' <summary>
    ''' Crea una nueva instancia de la clase <c>PropClass</c> asignándole los valores por defecto.
    ''' </summary>
    Public Sub New()
        Me.Id = 0
        Me.PropId = 0
        Me.ClassId = 0
        Me.StartDate = Now()
        Me.Keys = 0
        Me.VAT = 0
        Me.LegalClass = New LegalClassification()
    End Sub

    ''' <summary>
    ''' Devuelve una cadena de texto que representa al objeto de la clase <c>PropClass</c> (descripción de la clasificación legal del inmueble).
    ''' </summary>
    ''' <returns>La cadena de texto que representa al objeto de la clase <c>PropClass</c>.</returns>
    Public Overrides Function ToString() As String
        Return LegalClass.Description
    End Function
End Class
