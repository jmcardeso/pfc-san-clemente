Imports System.Data.OleDb

Public Class DuckTypingOleDB
    Private _csBuilder As OleDbConnectionStringBuilder

    Public ReadOnly Property csBuilder As OleDbConnectionStringBuilder
        Get
            _csBuilder = New OleDbConnectionStringBuilder("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & My.Computer.FileSystem.SpecialDirectories.Desktop & "\Prueba.Accdb'")
            Return _csBuilder
        End Get
    End Property

    Public Property dbCon As OleDbConnection

    Public Property dtaPrueba As OleDbDataAdapter
End Class