<Serializable()>
Public Class Photo
    Public Property Id As Integer
    Public Property PropertyId As Integer
    Public Property Path As String

    Public Sub New()
        Me.Id = 0
        Me.PropertyId = 0
        Me.Path = ""
    End Sub

    Public Sub New(id As Integer, propertyId As Integer, path As String)
        Me.Id = id
        Me.PropertyId = propertyId
        Me.Path = path
    End Sub
End Class
