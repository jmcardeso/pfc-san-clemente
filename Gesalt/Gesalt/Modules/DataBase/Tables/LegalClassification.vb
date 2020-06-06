''' <summary>
''' Representa los datos de una fila de la tabla legalclassification de la base de datos.
''' </summary>
<Serializable>
Public Class LegalClassification
    Public Property Id As Integer
    Public Property Description As String

    ''' <summary>
    ''' Crea una nueva instancia de la clase <c>LegalClassification</c> asignándole los valores especificados.
    ''' </summary>
    ''' <param name="id">Se corresponde con el campo Id de la tabla legalclassification de la base de datos, que representa el índice de la fila.</param>
    ''' <param name="description">Se corresponde con el campo description de la tabla legalclassification de la base de datos, que representa la descripción de la clasificación legal de un inmueble.</param>
    Public Sub New(id As Integer, description As String)
        Me.Id = id
        Me.Description = description
    End Sub

    ''' <summary>
    ''' Crea una nueva instancia de la clase <c>LegalClassification</c> asignándole los valores por defecto.
    ''' </summary>
    Public Sub New()
        Me.Id = 0
        Me.Description = ""
    End Sub

    ''' <summary>
    ''' Devuelve una cadena de texto que representa al objeto de la clase <c>LegalClassification</c> (descripción).
    ''' </summary>
    ''' <returns>La cadena de texto que representa al objeto de la clase <c>LegalClassification</c>.</returns>
    Public Overrides Function ToString() As String
        Return Me.Description
    End Function
End Class
