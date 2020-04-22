Imports System.Configuration
Imports MySql.Data.MySqlClient

Public Class DuckTypingMySQL
    Private _csBuilder As MySqlConnectionStringBuilder

    Public ReadOnly Property csBuilder As MySqlConnectionStringBuilder
        Get
            Dim conMySQL As Connection = Connection.getInstance()
            Dim cs As ConnectionStringSettings = conMySQL.GetMySQLConnectionString()
            _csBuilder = New MySqlConnectionStringBuilder(cs.ConnectionString)
            Return _csBuilder
        End Get
    End Property

    Public Property dbCon As MySqlConnection

    Public Property dtaPrueba As MySqlDataAdapter
End Class
