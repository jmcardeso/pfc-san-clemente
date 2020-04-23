Imports System.Configuration
Imports MySql.Data.MySqlClient
Imports System.Data.OleDb
Imports System.Data.Common
Public Class Connection
    Private Shared objConnection As Connection
    Private Con As DbConnection

    Private Sub New()

    End Sub

    Public Shared Function getInstance() As Connection
        If objConnection Is Nothing Then
            objConnection = New Connection()
        End If

        Return objConnection
    End Function
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

    Public Sub Close()
        If Not Con Is Nothing Then
            Con.Close()
            Con = Nothing
        End If
    End Sub

    Public Function DataApdapter(selectCommandText As String, connection As MySqlConnection) As MySqlDataAdapter
        Return New MySqlDataAdapter(selectCommandText, connection)
    End Function

    Public Function DataApdapter(selectCommandText As String, connection As OleDbConnection) As OleDbDataAdapter
        Return New OleDbDataAdapter(selectCommandText, connection)
    End Function
    Public Sub EditConnectionString(csName As String, csConnectionString As String, csProviderName As String)
        If RemoveConnectionStrings(csName) Then
            AddConnectionString(csName, csConnectionString, csProviderName)
        End If
    End Sub

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

    ' Ref: https://docs.microsoft.com/en-us/dotnet/api/system.configuration.connectionstringsettingscollection.add?view=netframework-4.8
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
            MsgBox(err.BareMessage)
        End Try

        Return resultado
    End Function

    ' Ref: https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/connection-strings-and-configuration-files
    ' Retrieves the MySQL connection string.
    ' Returns Nothing if the name is not found.
    Public Function GetMySQLConnectionString() As ConnectionStringSettings

        ' Assume failure
        Dim returnValue As ConnectionStringSettings = Nothing

        ' Look for the name in the connectionStrings section.
        Dim settings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings(MYSQL_CS_NAME)

        ' If found, return the connection string.
        If Not settings Is Nothing Then
            returnValue = settings
        End If

        Return returnValue
    End Function
End Class
