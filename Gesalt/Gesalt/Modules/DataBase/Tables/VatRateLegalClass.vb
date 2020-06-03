<Serializable>
Public Class VatRateLegalClass
    Public Property VatRateId As Integer
    Public Property ClassId As Integer
    Public Property StartDate As Date

    Public Sub New(vatRateId As Integer, classId As Integer, startDate As Date)
        Me.VatRateId = vatRateId
        Me.ClassId = classId
        Me.StartDate = startDate
    End Sub

    Public Sub New()
        Me.VatRateId = 0
        Me.ClassId = 0
        Me.StartDate = Now.Date()
    End Sub
End Class
