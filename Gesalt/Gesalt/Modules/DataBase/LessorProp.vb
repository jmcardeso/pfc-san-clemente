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
End Class
