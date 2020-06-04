<Serializable>
Public Class PropClass
    Public Property Id As Integer
    Public Property PropId As Integer
    Public Property ClassId As Integer
    Public Property StartDate As Date
    Public Property Keys As Integer
    Public Property VAT As Decimal
    Public Property LegalClass As LegalClassification

    Public Sub New(id As Integer, propId As Integer, classId As Integer, startDate As Date, keys As Integer, vat As Decimal)
        Me.Id = id
        Me.PropId = propId
        Me.ClassId = classId
        Me.StartDate = startDate
        Me.Keys = keys
        Me.VAT = vat
    End Sub

    Public Sub New()
        Me.Id = 0
        Me.PropId = 0
        Me.ClassId = 0
        Me.StartDate = Now.Date()
        Me.Keys = 0
        Me.VAT = 0
        Me.LegalClass = New LegalClassification()
    End Sub

    Public Overrides Function ToString() As String
        Return LegalClass.Description
    End Function
End Class
