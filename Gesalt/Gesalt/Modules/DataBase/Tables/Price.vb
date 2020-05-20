<Serializable()>
Public Class Price
    Public Property Id As Integer
    Public Property BookTypeId As Integer
    Public Property Value As Decimal
    Public Property Type As String
    Public Property StartDate As Date
    Public Property EndDate As Date
    Public Property Percentage As Boolean

    Public Sub New(id As Integer, bookTypeId As Integer, value As Decimal,
                   type As String, startDate As Date, endDate As Date, percentage As Decimal)
        Me.Id = id
        Me.BookTypeId = bookTypeId
        Me.Value = value
        Me.Type = type
        Me.StartDate = startDate
        Me.EndDate = endDate
        Me.Percentage = percentage
    End Sub

    Public Sub New()
        Me.Id = 0
        Me.BookTypeId = 0
        Me.Value = 0
        Me.Type = ""
        Me.StartDate = Now()
        Me.EndDate = New Date(1970, 12, 1)
        Me.Percentage = False
    End Sub
End Class
