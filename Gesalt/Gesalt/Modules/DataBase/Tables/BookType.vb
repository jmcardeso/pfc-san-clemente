<Serializable()>
Public Class BookType
    Public Property Id As Integer
    Public Property PropertyId As Integer
    Public Property BTName As String
    Public Property StartDate As Date
    Public Property EndDate As Date
    Public Property UrlWeb As String
    Public Property UrlICalendar As String

    Public Property Prices As New List(Of Price)

    Public Sub New(id As Integer, propertyId As Integer, bTName As String,
                   startDate As Date, endDate As Date, urlWeb As String, urlICalendar As String)
        Me.Id = id
        Me.PropertyId = propertyId
        Me.BTName = bTName
        Me.StartDate = startDate
        Me.EndDate = endDate
        Me.UrlWeb = urlWeb
        Me.UrlICalendar = urlICalendar
    End Sub

    Public Sub New()
        Me.Id = 0
        Me.PropertyId = 0
        Me.BTName = ""
        Me.StartDate = Now()
        Me.EndDate = New Date(1970, 12, 1)
        Me.UrlWeb = ""
        Me.UrlICalendar = ""
    End Sub

    Public Overrides Function ToString() As String
        Return Me.BTName
    End Function
End Class
