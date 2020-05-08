Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Public Class Utils
    'Ref: https://stackoverflow.com/questions/129389/how-do-you-do-a-deep-copy-of-an-object-in-net
    Public Shared Function DeepClone(Of T)(obj As T)
        Using ms = New MemoryStream()
            Dim formatter = New BinaryFormatter()
            formatter.Serialize(ms, obj)
            ms.Position = 0
            Return formatter.Deserialize(ms)
        End Using
    End Function
End Class
