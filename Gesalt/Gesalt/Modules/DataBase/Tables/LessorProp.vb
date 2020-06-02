''' <summary>
''' Representa los datos de una fila de la tabla lessor_prop de la base de datos.
''' </summary>
<Serializable()>
Public Class LessorProp
    Public Property Lessor As Lessor
    Public Property Percentage As Decimal

    ''' <summary>
    ''' Crea una nueva instancia de la clase <c>LessorProp</c>, asignándole los valores especificados.
    ''' </summary>
    ''' <param name="lessor">Se corresponde con un objeto de la clase <c>Lessor</c>, que representa el arrendador de un inmueble.</param>
    ''' <param name="percentage">Se corresponde con el campo percentage de la tabla lessor_prop, que representa el porcentaje de la propiedad del inmueble que tiene un arrendador.</param>
    Public Sub New(lessor As Lessor, percentage As Decimal)
        Me.Lessor = lessor
        Me.Percentage = percentage
    End Sub

    ''' <summary>
    ''' Crea una nueva instancia de la clase <c>LessorProp</c>, asignándole los valores por defecto.
    ''' </summary>
    Public Sub New()
        Me.Lessor = New Lessor()
        Me.Percentage = 100
    End Sub

    ''' <summary>
    ''' Devuelve un valor que indica si esta instancia y un <c>Object</c> especificado representan el mismo tipo y valor.
    ''' </summary>
    ''' <param name="obj">El objeto con el que se va a comparar.</param>
    ''' <returns><c>True</c> si son iguales, <c>False</c> en caso contrario.</returns>
    Public Overrides Function Equals(obj As Object) As Boolean
        Dim prop = TryCast(obj, LessorProp)
        Return prop IsNot Nothing AndAlso
            Lessor.Id = prop.Lessor.Id
    End Function
End Class
