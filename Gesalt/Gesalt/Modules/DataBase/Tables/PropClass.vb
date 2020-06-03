<Serializable>
Public Class PropClass
    Public Property PropId As Integer
    Public Property ClassId As Integer
    Public Property StartDate As Date
    Public Property Keys As Integer
    Public Property LegalClass As LegalClassification

    Public Sub New(propId As Integer, classId As Integer, startDate As Date, keys As Integer)
        Me.PropId = propId
        Me.ClassId = classId
        Me.StartDate = startDate
        Me.Keys = keys
    End Sub

    Public Sub New()
        Me.PropId = 0
        Me.ClassId = 0
        Me.StartDate = Now.Date()
        Me.Keys = 0
        Me.LegalClass = New LegalClassification()
    End Sub

    Public Overrides Function ToString() As String
        Return LegalClass.Description
    End Function
End Class
