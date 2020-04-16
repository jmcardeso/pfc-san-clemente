Imports Ical.Net
Imports Ical.Net.CalendarComponents
Imports Ical.Net.DataTypes
Imports Ical.Net.Serialization
Imports System.Resources
Public Class Form1
    Public Sub New()
        ' Para forzar el cambio de idioma por código
        Threading.Thread.CurrentThread.CurrentUICulture = Globalization.CultureInfo.GetCultureInfo("fr")

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Creamos un ResourceManager para el formulario
        Dim LocRM As New ResourceManager("PruebaICal.WinFormStrings", GetType(Form1).Assembly)
        ' Asignamos a la etiqueta Label2 la cadena con la clave Cosa (como en Android)
        Label2.Text = LocRM.GetString("Cosa")
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

    Private Sub Idioma_Click(sender As ToolStripMenuItem, e As EventArgs) Handles mnuIdiomaGL.Click, mnuIdiomaES.Click, mnuIdiomaEN.Click
        Dim idioma As String

        Select Case sender.Name
            Case "mnuIdiomaGL"
                idioma = "gl"
               ' sender.Checked = True
            Case "mnuIdiomaES"
                idioma = "es"
                sender.Checked = True
            Case Else
                idioma = "en"
                sender.Checked = True
        End Select

        CambiarIdioma(idioma)
    End Sub
    Private Sub CambiarIdioma(idioma As String)
        Threading.Thread.CurrentThread.CurrentUICulture = Globalization.CultureInfo.GetCultureInfo(idioma)
        Me.Controls.Clear()
        Me.InitializeComponent()
        Form1_Load(Nothing, Nothing)
    End Sub

    Private Sub Idioma_Click(sender As Object, e As EventArgs) Handles mnuIdiomaGL.Click, mnuIdiomaES.Click, mnuIdiomaEN.Click

    End Sub

End Class
