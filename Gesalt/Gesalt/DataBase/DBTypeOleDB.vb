Imports System.Data.OleDb

Public Class DBTypeOleDB
    Implements IDBType(Of OleDbConnectionStringBuilder, OleDbConnection, OleDbDataAdapter)
    Private _csBuilder As OleDbConnectionStringBuilder

    Public ReadOnly Property csBuilder As OleDbConnectionStringBuilder Implements IDBType(Of OleDbConnectionStringBuilder, OleDbConnection, OleDbDataAdapter).csBuilder
        Get
            _csBuilder = New OleDbConnectionStringBuilder("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & My.Computer.FileSystem.SpecialDirectories.Desktop & "\Gesalt\gesalt.accdb'")
            Return _csBuilder
        End Get
    End Property

    Public Property dbCon As OleDbConnection Implements IDBType(Of OleDbConnectionStringBuilder, OleDbConnection, OleDbDataAdapter).dbCon

    Public Property dtaPrueba As OleDbDataAdapter Implements IDBType(Of OleDbConnectionStringBuilder, OleDbConnection, OleDbDataAdapter).dtaPrueba
End Class