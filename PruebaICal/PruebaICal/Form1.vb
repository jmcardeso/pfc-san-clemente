Imports Ical.Net
Imports Ical.Net.CalendarComponents
Imports Ical.Net.DataTypes
Imports Ical.Net.Serialization
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim now = Date.Now
        Dim later = now.AddHours(1)

        Dim rrule As New RecurrencePattern(FrequencyType.Daily, 1) With {
            .Count = 5
        }

        Dim ce As New CalendarEvent With {
            .Start = New CalDateTime(now),
            .End = New CalDateTime(later),
            .RecurrenceRules = New List(Of RecurrencePattern)
        }
        ce.RecurrenceRules.Add(rrule)

        Dim calendar As New Calendar()
        calendar.Events.Add(ce)

        Dim serializer As New CalendarSerializer()
        Dim serializerCalendar = serializer.SerializeToString(calendar)

        Label1.Text = serializerCalendar
    End Sub
    Public Function PruebaDePruebas(numero As Integer) As Integer
        Return numero * 2
    End Function
End Class
