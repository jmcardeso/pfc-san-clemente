Imports Gesalt

<Serializable()>
Public Class LessorProp
    Public Property Lessor As Lessor
    Public Property Percentage As Decimal

    Public Sub New(lessor As Lessor, percentage As Decimal)
        Me.Lessor = lessor
        Me.Percentage = percentage
    End Sub

    Public Sub New()
        Me.Lessor = New Lessor()
        Me.Percentage = 100
    End Sub

    Public Overrides Function Equals(obj As Object) As Boolean
        Dim prop = TryCast(obj, LessorProp)
        Return prop IsNot Nothing AndAlso
            Lessor.Id = prop.Lessor.Id
    End Function
End Class
