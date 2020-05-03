Imports System.Configuration
Imports MySql.Data.MySqlClient
Imports System.Data.OleDb
Imports System.Data.Common

''' <summary>
''' Ayuda en la creación de una conexión a una base de datos, exponiendo métodos y propiedades útiles para tal fin.
''' </summary>
Public Class Connection
    Private Shared objConnection As Connection
    Private Con As DbConnection

    ''' <summary>
    ''' Inicializa una nueva instancia de la clase <c>Connection</c>, que ayuda a establecer una conexión a una base de datos.
    ''' </summary>
    Private Sub New()

    End Sub

    ''' <summary>
    ''' Devuelve la única instancia del objeto <c>Connection</c>.
    ''' </summary>
    ''' <returns>Instancia al objeto <c>Connection</c></returns>
    Public Shared Function getInstance() As Connection
        If objConnection Is Nothing Then
            objConnection = New Connection()
        End If

        Return objConnection
    End Function

    ''' <summary>
    ''' Abre una conexión con la base de datos con la configuración especificada.
    ''' </summary>
    ''' <param name="cs">Ayuda en la creación de la cadena de conexión exponiendo las opciones como propiedades.</param>
    ''' <returns>Representa una conexión abierta con una base de datos en un servidor MySQL o <c>Nothing</c> si se ha producido un error.</returns>
    Public Function Open(cs As MySqlConnectionStringBuilder) As MySqlConnection
        If Con Is Nothing Then
            Try
                Con = New MySqlConnection(cs.ConnectionString)
                Con.Open()
            Catch err As Exception
                Return Nothing
            End Try
        End If
        Return Con
    End Function

    ''' <summary>
    ''' Abre una conexión con la base de datos con la configuración especificada.
    ''' </summary>
    ''' <param name="cs">Ayuda en la creación de la cadena de conexión exponiendo las opciones como propiedades.</param>
    ''' <returns>Representa una conexión abierta con una base de datos en un servidor MySQL o <c>Nothing</c> si se ha producido un error.</returns>
    Public Function Open(cs As OleDbConnectionStringBuilder) As OleDbConnection
        If Con Is Nothing Then
            Try
                Con = New OleDbConnection(cs.ConnectionString)
                Con.Open()
            Catch err As Exception
                Return Nothing
            End Try
        End If
        Return Con
    End Function

    ''' <summary>
    ''' Cierra la conexión establecida con la base de datos.
    ''' </summary>
    Public Sub Close()
        If Not Con Is Nothing Then
            Con.Close()
            Con = Nothing
        End If
    End Sub

    ''' <summary>
    ''' Inicializa una instancia de la clase MySqlDataAdapter.
    ''' </summary>
    ''' <param name="selectCommandText">Setencia SELECT.</param>
    ''' <param name="connection">Conexión a la base de datos</param>
    ''' <returns>Representa un conjunto de comnados de datos y una conexión a una base de datos que se usan para rellenar <c>DataSet</c> y actualizar el origen de datos.</returns>
    Public Function DataApdapter(selectCommandText As String, connection As MySqlConnection) As MySqlDataAdapter
        Return New MySqlDataAdapter(selectCommandText, connection)
    End Function

    ''' <summary>
    ''' Inicializa una instancia de la clase OleDbDataAdapter.
    ''' </summary>
    ''' <param name="selectCommandText">Setencia SELECT.</param>
    ''' <param name="connection">Conexión a la base de datos</param>
    ''' <returns>Representa un conjunto de comnados de datos y una conexión a una base de datos que se usan para rellenar <c>DataSet</c> y actualizar el origen de datos.</returns>
    Public Function DataApdapter(selectCommandText As String, connection As OleDbConnection) As OleDbDataAdapter
        Return New OleDbDataAdapter(selectCommandText, connection)
    End Function

    ''' <summary>
    ''' Modifica la cadena de conexión de una base de datos guardada en el archivo de configuración del programa.
    ''' </summary>
    ''' <param name="csName">Nombre de la cadena de conexión en las preferencias del programa.</param>
    ''' <param name="csConnectionString">Cadena de conexión de la base de datos.</param>
    ''' <param name="csProviderName">Nombre del proveedor de la base de datos.</param>
    Public Sub EditConnectionString(csName As String, csConnectionString As String, csProviderName As String)
        If RemoveConnectionStrings(csName) Then
            AddConnectionString(csName, csConnectionString, csProviderName)
        End If
    End Sub

    ''' <summary>
    ''' Encripta la sección de la configuración del programa que almacena las cadenas de conexión de las bases de datos.
    ''' </summary>
    Private Sub ProtectConnectionString()
        Dim config As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
        Dim cs As ConfigurationSection = config.ConnectionStrings

        If Not cs.SectionInformation.IsProtected Then
            If Not cs.ElementInformation.IsLocked Then
                cs.SectionInformation.ProtectSection("DataProtectionConfigurationProvider")
                cs.SectionInformation.ForceSave = True
                config.Save(ConfigurationSaveMode.Full)
                ConfigurationManager.RefreshSection("configuration")
            End If
        End If
    End Sub

    ''' <summary>
    ''' Desencripta la sección de la configuración del programa que almacena las cadenas de conexión de las bases de datos.
    ''' </summary>
    Private Sub UnprotectConnectionString()
        Dim config As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
        Dim cs As ConfigurationSection = config.ConnectionStrings

        If cs.SectionInformation.IsProtected Then
            If Not cs.ElementInformation.IsLocked Then
                cs.SectionInformation.UnprotectSection()
                cs.SectionInformation.ForceSave = True
                config.Save(ConfigurationSaveMode.Full)
                ConfigurationManager.RefreshSection("configuration")
            End If
        End If
    End Sub

    ''' <summary>
    ''' Añade una cadena de conexión de una base de datos en el archivo de configuración del programa.
    ''' <para>Referencia: "https://docs.microsoft.com/en-us/dotnet/api/system.configuration.connectionstringsettingscollection.add?view=netframework-4.8"</para>
    ''' </summary>
    ''' <param name="csName">Nombre único de la cadena de conexión en el archivo de configuración del programa.</param>
    ''' <param name="csConnectionString">Cadena de conexión de la base de datos.</param>
    ''' <param name="csProviderName">Nombre del proveedor de la base de datos.</param>
    Public Sub AddConnectionString(csName As String, csConnectionString As String, csProviderName As String)
        Try
            ' Get the configuration file.
            Dim config As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)

            ' Add the connection string.
            Dim csSection As ConnectionStringsSection = config.ConnectionStrings
            csSection.ConnectionStrings.Add(New ConnectionStringSettings(csName, csConnectionString, csProviderName))

            ' Save the configuration file.
            config.Save(ConfigurationSaveMode.Modified)
            ConfigurationManager.RefreshSection("configuration")
            ProtectConnectionString()
        Catch err As ConfigurationErrorsException
            MsgBox(err.BareMessage)
        End Try
    End Sub

    ' Ref: https://docs.microsoft.com/en-us/dotnet/api/system.configuration.connectionstringsettingscollection.remove?view=netframework-4.8
    ''' <summary>
    ''' Borra una cadena de conexión de una base de datos de el archivo de conexión del programa.
    ''' </summary>
    ''' <param name="csName">Nombre único de la cadena de conexión en el archivo de conexión del programa.</param>
    ''' <returns><c>True</c> si la cadena de conexión ha sido borrada, <c>False</c> en caso contrario.</returns>
    Private Function RemoveConnectionStrings(csName As String) As Boolean
        Dim resultado As Boolean = False

        Try
            UnprotectConnectionString()
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
                ConfigurationManager.RefreshSection("configuration")
                resultado = True
            End If
        Catch err As ConfigurationErrorsException

        End Try

        Return resultado
    End Function

    ' Ref: https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/connection-strings-and-configuration-files
    ' Retrieves the MySQL connection string.
    ' Returns Nothing if the name is not found.
    ''' <summary>
    ''' Obtiene la cadena de conexión con nombre único del archivo de configuración del programa.
    ''' <para>La cadena de conexión debe ser válida para una conexión del tipo <c>MySQLConnection</c>.</para>
    ''' <para>Referencia: " https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/connection-strings-and-configuration-files"</para>
    ''' </summary>
    ''' <returns>La cadena de conexión de nombre único de la configuración del programa o <c>Nothing</c> si no se ha encontrado.</returns>
    Public Function GetMySQLConnectionString() As ConnectionStringSettings

        ' Assume failure
        Dim returnValue As ConnectionStringSettings = Nothing

        Dim config As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)

        ' Clear the connection strings collection.
        Dim csSection As ConnectionStringsSection = config.ConnectionStrings
        Dim csCollection As ConnectionStringSettingsCollection = csSection.ConnectionStrings

        ' Get the connection string setting element
        ' with the specified name.
        Dim settings As ConnectionStringSettings = csCollection(MYSQL_CS_NAME)

        ' If found, return the connection string.
        If Not settings Is Nothing Then
            returnValue = settings
        End If

        Return returnValue
    End Function
End Class
