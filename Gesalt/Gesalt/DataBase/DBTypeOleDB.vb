Imports System.Data.OleDb

''' <summary>
''' Representa un conjunto de propiedades de <c>System.Data.OleDb</c> necesarias para utilizar este proveedor de datos concreto.
''' </summary>
Public Class DBTypeOleDB
    Implements IDBType(Of OleDbConnectionStringBuilder, OleDbConnection, OleDbDataAdapter)
    Private _csBuilder As OleDbConnectionStringBuilder

    ''' <summary>
    ''' Obtiene la cadena de conexión para la base de datos OleDb.
    ''' </summary>
    ''' <returns>Cadena de conexión de la base de datos OleDb.</returns>
    Public ReadOnly Property csBuilder As OleDbConnectionStringBuilder Implements IDBType(Of OleDbConnectionStringBuilder, OleDbConnection, OleDbDataAdapter).csBuilder
        Get
            _csBuilder = New OleDbConnectionStringBuilder("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & My.Computer.FileSystem.SpecialDirectories.Desktop & "\Gesalt\gesalt.accdb'")
            Return _csBuilder
        End Get
    End Property

    ''' <summary>
    ''' Obtiene o establece la conexión para la base de datos OleDb.
    ''' </summary>
    ''' <returns>La conexión para la base de datos OleDb.</returns>
    Public Property dbCon As OleDbConnection Implements IDBType(Of OleDbConnectionStringBuilder, OleDbConnection, OleDbDataAdapter).dbCon

    ''' <summary>
    ''' Obtiene o establece un DataAdapter para la base de datos OleDb.
    ''' </summary>
    ''' <returns>DataAdapter para la base de datos OleDb.</returns>
    Public Property dtaPrueba As OleDbDataAdapter Implements IDBType(Of OleDbConnectionStringBuilder, OleDbConnection, OleDbDataAdapter).dtaPrueba
End Class