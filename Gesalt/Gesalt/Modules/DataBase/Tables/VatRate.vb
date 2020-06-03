<Serializable>
Public Class VatRate
    Public Property Id As Integer
    Public Property Description As String

    Public Sub New(id As Integer, description As String)
        Me.Id = id
        Me.Description = description
    End Sub

    Public Sub New()
        Me.Id = 0
        Me.Description = ""
    End Sub
End Class
