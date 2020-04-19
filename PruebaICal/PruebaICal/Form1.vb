Imports Ical.Net
Imports Ical.Net.CalendarComponents
Imports Ical.Net.DataTypes
Imports Ical.Net.Serialization
Imports System.Configuration
Imports System.Resources
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

        AddConnectionString("mysql", "LocalSqlServer: data source=127.0.0.1;Integrated Security=SSPI;" + "Initial Catalog=aspnetdb", "System.Data.SqlClient")

        MsgBox(GetConnectionStringByName("mysql"))

        EditConnectionString("mysql", "LocalSqlServer: data source=127.0.0.199;Integrated Security=SSPI;" + "Initial Catalog=aspnetdb", "System.Data.SqlClient")

        MsgBox(GetConnectionStringByName("mysql"))
    End Sub
    Public Function PruebaDePruebas(numero As Integer) As Integer
        Return numero * 2
    End Function

    Private Sub EditConnectionString(csName As String, csConnectionString As String, csProviderName As String)
        If RemoveConnectionStrings(csName) Then
            AddConnectionString(csName, csConnectionString, csProviderName)
        End If
    End Sub

    ' Ref: https://docs.microsoft.com/en-us/dotnet/api/system.configuration.connectionstringsettingscollection.add?view=netframework-4.8
    Private Sub AddConnectionString(csName As String, csConnectionString As String, csProviderName As String)
        Try
            ' Get the configuration file.
            Dim config As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)

            ' Add the connection string.
            Dim csSection As ConnectionStringsSection = config.ConnectionStrings
            csSection.ConnectionStrings.Add(New ConnectionStringSettings(csName, csConnectionString, csProviderName))

            ' Save the configuration file.
            config.Save(ConfigurationSaveMode.Modified)
        Catch err As ConfigurationErrorsException
            MsgBox(err.ToString)
        End Try
    End Sub

    ' Ref: https://docs.microsoft.com/en-us/dotnet/api/system.configuration.connectionstringsettingscollection.remove?view=netframework-4.8
    Private Function RemoveConnectionStrings(csName As String) As Boolean
        Dim resultado As Boolean = False

        Try
            ' Get the application configuration file.
            Dim config As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)

            ' Clear the connection strings collection.
            Dim csSection As ConnectionStringsSection = config.ConnectionStrings
            Dim csCollection As ConnectionStringSettingsCollection = csSection.ConnectionStrings

            ' Get the connection string setting element
            ' with the specified name.
            Dim cs As ConnectionStringSettings = csCollection(csName)

            ' Remove it.
            If Not (cs Is Nothing) Then
                ' Remove the element.
                csCollection.Remove(cs)

                ' Save the configuration file.
                config.Save(ConfigurationSaveMode.Modified)
                resultado = True
            End If
        Catch err As ConfigurationErrorsException
            MsgBox(err.ToString())
        End Try

        Return resultado
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

    ' Ref: https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/connection-strings-and-configuration-files
    ' Retrieves a connection string by name.
    ' Returns Nothing if the name is not found.
    Private Shared Function GetConnectionStringByName(ByVal name As String) As String

        ' Assume failure
        Dim returnValue As String = Nothing

        ' Look for the name in the connectionStrings section.
        Dim settings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings(name)

        ' If found, return the connection string.
        If Not settings Is Nothing Then
            returnValue = settings.ConnectionString
        End If

        Return returnValue
    End Function
End Class
