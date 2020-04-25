Imports System.Data.Common
Public Interface IDBType(Of TStringBuilder, TConnection, TDataAdapter)

    ReadOnly Property csBuilder() As TStringBuilder

    Property dbCon() As TConnection

    Property dtaPrueba() As TDataAdapter
End Interface
