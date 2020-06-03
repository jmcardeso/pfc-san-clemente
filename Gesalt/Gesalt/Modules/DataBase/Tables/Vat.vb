<Serializable>
Public Class Vat
    Public Property Id As Integer
    Public Property VatRateId As Integer
    Public Property Percentage As Decimal
    Public Property StartDate As Date

    Public Sub New(id As Integer, vatRateId As Integer, percentage As Decimal, startDate As Date)
        Me.Id = id
        Me.VatRateId = vatRateId
        Me.Percentage = percentage
        Me.StartDate = startDate
    End Sub

    Public Sub New()
        Me.Id = 0
        Me.VatRateId = 0
        Me.Percentage = 0
        Me.StartDate = Now.Date()
    End Sub
End Class
