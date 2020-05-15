Imports Ical.Net
Imports Ical.Net.CalendarComponents
Imports Ical.Net.DataTypes
Imports Ical.Net.Serialization
Imports System.Resources
Public Class frmMain
    ' Creamos un ResourceManager para el formulario
    Dim LocRM As New ResourceManager("Gesalt.WinFormStrings", GetType(frmMain).Assembly)

    Public Sub New()
        Dim strIdioma As String = My.Settings.language
        Dim cultura As Globalization.CultureInfo

        ' Si es la primera vez que se inicia la aplicación (y, por tanto, no hay un idioma definido)
        If My.Settings.appStatus.Equals("first_start") Then
            cultura = Threading.Thread.CurrentThread.CurrentUICulture

            Select Case cultura.TwoLetterISOLanguageName
                Case "es", "gl"
                    strIdioma = cultura.TwoLetterISOLanguageName
                Case Else
                    strIdioma = "en"
            End Select
            My.Settings.language = strIdioma
        End If

        ' Para forzar el cambio de idioma por código
        Threading.Thread.CurrentThread.CurrentUICulture = Globalization.CultureInfo.GetCultureInfo(strIdioma)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.appStatus.Equals("first_start") Then
            ConnectionWizard()
        End If
        '' Asignamos a la etiqueta Label2 la cadena con la clave Cosa (como en Android)
        '' Esto no es necesario hacerlo así, porque ya tenemos el propio formulario con la propiedad Language en varios idiomas
        '' pero sirve para ver cómo se haría con texto mostrado por código
        'Label2.Text = LocRM.GetString("Cosa")

        'Dim now = Date.Now
        'Dim later = now.AddHours(1)

        'Dim rrule As New RecurrencePattern(FrequencyType.Daily, 1) With {
        '    .Count = 5
        '}

        'Dim ce As New CalendarEvent With {
        '    .Start = New CalDateTime(now),
        '    .End = New CalDateTime(later),
        '    .RecurrenceRules = New List(Of RecurrencePattern)
        '}
        'ce.RecurrenceRules.Add(rrule)

        'Dim calendar As New Calendar()
        'calendar.Events.Add(ce)

        'Dim serializer As New CalendarSerializer()
        'Dim serializerCalendar = serializer.SerializeToString(calendar)

        'Label1.Text = serializerCalendar

        '' =========================================================================

        'Dim con As Connection = Connection.getInstance()
        'Dim dbt As Object = Nothing

        'If My.Settings.dbType.Equals("local") Then
        '    dbt = New DBTypeOleDB()
        'Else
        '    dbt = New DBTypeMySQL()
        'End If

        'Dim dtsPruebas As New DataSet

        'dbt.dbCon = con.Open(dbt.csBuilder)

        'If dbt.dbCon Is Nothing Then
        '    My.Settings.appStatus = "dbError"
        '    My.Settings.Save()
        '    MsgBox(LocRM.GetString("fatalErrorDB"), MsgBoxStyle.Critical, LocRM.GetString("fatalErrorDBTitle"))
        '    ConnectionWizard()
        'End If

        'dbt.dtaPrueba = con.DataApdapter("select * from owner", dbt.dbCon)
        'dbt.dtaPrueba.Fill(dtsPruebas, "owner")

        'DataGridView1.DataSource = dtsPruebas.Tables("owner")

        'con.Close()
    End Sub

    Private Sub mnuAyuda_Preferencias_Click(sender As Object, e As EventArgs) Handles mnuAyuda_Preferencias.Click
        Dim frmPref As New frmSettings

        frmPref.ShowDialog()

        If frmPref.LanguageChanged Then
            ReLoadMain(My.Settings.language)
        End If
    End Sub

    ' PARA PROBAR LOS TESTS. BORRAR!
    Public Function PruebaDePruebas(numero As Integer) As Integer
        Return numero * 2
    End Function

    ''' <summary>
    ''' Vuelve a cargar el formulario.
    ''' </summary>
    ''' <param name="language">El idioma en el que se mostrará el formulario.
    ''' <para>Ver: <see cref="Globalization.CultureInfo.GetCultureInfo(String)"/>.</para></param>
    Private Sub ReLoadMain(language As String)
        Threading.Thread.CurrentThread.CurrentUICulture = Globalization.CultureInfo.GetCultureInfo(language)
        Me.Controls.Clear()
        Me.InitializeComponent()
        Form1_Load(Nothing, Nothing)
    End Sub

    ''' <summary>
    ''' Muestra el formulario de preferencias de la aplicación.
    ''' <para>Se utiliza en caso de error en la conexión o cuando el programa se ejecuta por primera vez.</para>
    ''' </summary>
    Private Sub ConnectionWizard()
        Dim frmPref As New frmSettings

        If My.Settings.appStatus.Equals("dbError") Then
            frmPref.Text = LocRM.GetString("dbErrorTitle")
        ElseIf My.Settings.appStatus.Equals("first_start") Then
            MsgBox(LocRM.GetString("firstTimeMsg"), MsgBoxStyle.Information, LocRM.GetString("firstTimeTitle"))
            frmPref.Text = LocRM.GetString("firstTimeTitle")
        End If

        frmPref.ShowDialog()

        If frmPref.LanguageChanged Then
            ReLoadMain(My.Settings.language)
        End If
    End Sub

    Private Sub btnOwners_Click(sender As Object, e As EventArgs) Handles btnOwners.Click
        Dim frmOwn As New frmLessors

        frmOwn.ShowDialog()
    End Sub

    Private Sub btnGuests_Click(sender As Object, e As EventArgs) Handles btnGuests.Click
        Dim frmGst As New frmGuests

        frmGst.ShowDialog()
    End Sub

    Private Sub btnProperties_Click(sender As Object, e As EventArgs) Handles btnProperties.Click
        Dim frmProp As New frmProperty

        frmProp.ShowDialog()
    End Sub
End Class
