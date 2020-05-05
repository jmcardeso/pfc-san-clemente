Imports System.Configuration
Imports MySql.Data.MySqlClient

''' <summary>
''' Representa un conjunto de propiedades de <c>MySql.Data.MySqlClient</c> necesarias para utilizar este proveedor de datos concreto.
''' </summary>
Public Class DBTypeMySQL
    Implements IDBType(Of MySqlConnectionStringBuilder, MySqlConnection, MySqlDataAdapter)

    Private _csBuilder As MySqlConnectionStringBuilder

    ''' <summary>
    ''' Obtiene la cadena de conexión para la base de datos MySQL.
    ''' </summary>
    ''' <returns>Cadena de conexión de la base de datos MySQL.</returns>
    Public Overloads ReadOnly Property csBuilder As MySqlConnectionStringBuilder Implements IDBType(Of MySqlConnectionStringBuilder, MySqlConnection, MySqlDataAdapter).csBuilder
        Get
            Dim conMySQL As Connection = Connection.GetInstance()
            Dim cs As ConnectionStringSettings = conMySQL.GetMySQLConnectionString()
            _csBuilder = New MySqlConnectionStringBuilder(cs.ConnectionString)
            Return _csBuilder
        End Get
    End Property

    ''' <summary>
    ''' Obtiene o establece la conexión para la base de datos MySQL.
    ''' </summary>
    ''' <returns>La conexión para la base de datos MySQL.</returns>
    Public Overloads Property dbCon As MySqlConnection Implements IDBType(Of MySqlConnectionStringBuilder, MySqlConnection, MySqlDataAdapter).dbCon

    ''' <summary>
    ''' Obtiene o establece un DataAdapter para la base de datos MySQL.
    ''' </summary>
    ''' <returns>DataAdapter para la base de datos MySQL.</returns>
    Public Overloads Property dtaPrueba As MySqlDataAdapter Implements IDBType(Of MySqlConnectionStringBuilder, MySqlConnection, MySqlDataAdapter).dtaPrueba
End Class
