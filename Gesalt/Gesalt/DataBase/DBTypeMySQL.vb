Imports System.Configuration
Imports MySql.Data.MySqlClient

Public Class DBTypeMySQL
    Implements IDBType(Of MySqlConnectionStringBuilder, MySqlConnection, MySqlDataAdapter)
    Private _csBuilder As MySqlConnectionStringBuilder

    Public ReadOnly Property csBuilder As MySqlConnectionStringBuilder Implements IDBType(Of MySqlConnectionStringBuilder, MySqlConnection, MySqlDataAdapter).csBuilder
        Get
            Dim conMySQL As Connection = Connection.getInstance()
            Dim cs As ConnectionStringSettings = conMySQL.GetMySQLConnectionString()
            _csBuilder = New MySqlConnectionStringBuilder(cs.ConnectionString)
            Return _csBuilder
        End Get
    End Property

    Public Property dbCon As MySqlConnection Implements IDBType(Of MySqlConnectionStringBuilder, MySqlConnection, MySqlDataAdapter).dbCon

    Public Property dtaPrueba As MySqlDataAdapter Implements IDBType(Of MySqlConnectionStringBuilder, MySqlConnection, MySqlDataAdapter).dtaPrueba
End Class
