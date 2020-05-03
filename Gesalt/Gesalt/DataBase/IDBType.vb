''' <summary>
''' Contiene un conjunto de propiedades comunes a las clases que proporcionan tipos de datos específicos para conectarse a bases de datos de un determinado proveedor.
''' </summary>
''' <typeparam name="TStringBuilder">Representa el tipo básico para una cadena de conexión.</typeparam>
''' <typeparam name="TConnection">Representa el tipo básico para una conexión genérica.</typeparam>
''' <typeparam name="TDataAdapter">Representa el tipo básico para un DataAdapter genérico.</typeparam>
Public Interface IDBType(Of TStringBuilder, TConnection, TDataAdapter)
    ''' <summary>
    ''' Representa una cadena de conexión genérica.
    ''' </summary>
    ReadOnly Property csBuilder() As TStringBuilder

    ''' <summary>
    ''' Representa una conexión genérica.
    ''' </summary>
    Property dbCon() As TConnection

    ''' <summary>
    ''' Representa un DataAdapter genérico.
    ''' </summary>
    ''' <returns></returns>
    Property dtaPrueba() As TDataAdapter
End Interface
