﻿Imports Ical.Net
Imports Ical.Net.CalendarComponents
Imports Ical.Net.DataTypes
Imports Ical.Net.Serialization
Imports System.Resources
Imports MySql.Data.MySqlClient
Public Class Form1

    Public Sub New()
        Dim strIdioma As String = My.Settings.idioma
        Dim cultura As Globalization.CultureInfo

        ' Si es la primera vez que se inicia la aplicación (y, por tanto, no hay un idioma definido)
        If strIdioma.Equals("primera_vez") Then
            cultura = Threading.Thread.CurrentThread.CurrentUICulture

            Select Case cultura.TwoLetterISOLanguageName
                Case "es", "gl"
                    strIdioma = cultura.TwoLetterISOLanguageName
                Case Else
                    strIdioma = "en"
            End Select
            My.Settings.idioma = strIdioma
        End If

        ' Para forzar el cambio de idioma por código
        Threading.Thread.CurrentThread.CurrentUICulture = Globalization.CultureInfo.GetCultureInfo(strIdioma)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Creamos un ResourceManager para el formulario
        Dim LocRM As New ResourceManager("PruebaICal.WinFormStrings", GetType(Form1).Assembly)
        ' Asignamos a la etiqueta Label2 la cadena con la clave Cosa (como en Android)
        ' Esto no es necesario hacerlo así, porque ya tenemos el propio formulario con la propiedad Language en varios idiomas
        ' pero sirve para ver cómo se haría con texto mostrado por código
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

        ' =========================================================================

        Dim con As Connection = Connection.getInstance()
        Dim conexion As MySqlConnection
        Dim dtaTabla As MySqlDataAdapter
        Dim dtsPruebas As New DataSet
        Dim cs = con.GetMySQLConnectionString()

        conexion = con.Open(New MySqlConnectionStringBuilder(cs.ConnectionString))

        dtaTabla = New MySqlDataAdapter("select * from country", conexion)
        dtaTabla.Fill(dtsPruebas, "paises")

        DataGridView1.DataSource = dtsPruebas.Tables("paises")

        con.Close()
    End Sub
    Public Function PruebaDePruebas(numero As Integer) As Integer
        Return numero * 2
    End Function

    Private Sub CambiarIdioma(idioma As String)
        Threading.Thread.CurrentThread.CurrentUICulture = Globalization.CultureInfo.GetCultureInfo(idioma)
        Me.Controls.Clear()
        Me.InitializeComponent()
        Form1_Load(Nothing, Nothing)
    End Sub

    Private Sub mnuAyuda_Preferencias_Click(sender As Object, e As EventArgs) Handles mnuAyuda_Preferencias.Click
        Dim frmPref As New frmPreferencias

        frmPref.ShowDialog()

        If frmPref.CambioIdioma Then
            CambiarIdioma(My.Settings.idioma)
        End If
    End Sub
End Class
