Imports System.Data.Common
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

''' <summary>
''' Representa un conjunto de métodos de utilidad general.
''' </summary>
Public Class Utils

    ''' <summary>
    ''' Realiza una copia profunda del objeto especificado.
    ''' <para>Ref: https://stackoverflow.com/questions/129389/how-do-you-do-a-deep-copy-of-an-object-in-net</para>
    ''' </summary>
    ''' <typeparam name="T">Tipo de objeto a copiar.</typeparam>
    ''' <param name="obj">Representa el objeto del que se hará la copia profunda.</param>
    ''' <returns>Representa un nuevo objeto con los mismos valores en sus atributos que el original, pero sin ninguna dependencia con él.</returns>
    Public Shared Function DeepClone(Of T)(obj As T)
        Using ms = New MemoryStream()
            Dim formatter = New BinaryFormatter()
            formatter.Serialize(ms, obj)
            ms.Position = 0
            Return formatter.Deserialize(ms)
        End Using
    End Function

    Public Shared Function AddFilterParameter(parameterName As String, value As Object, dbType As DbType) As DbParameter
        Dim con As Connection = Connection.GetInstance()
        Dim p As DbParameter

        p = con.Factory.CreateParameter()
        p.ParameterName = parameterName
        p.Value = value
        p.DbType = dbType

        Return p
    End Function

    Public Shared Function SetEndDate(endDate As Date) As Date
        Return IIf(endDate.Year = 1970 Or endDate.Year = 1, Nothing, endDate)
    End Function

    Public Shared Function GetEndDate(endDate As Date) As Date
        Return IIf(endDate.Year < 1971, New Date(1970, 12, 1), endDate)
    End Function

    Public Shared Function IsEndDateEmpty(endDate As Date) As Boolean
        Return endDate.Year = 1 OrElse endDate.Year = 1970
    End Function
End Class
