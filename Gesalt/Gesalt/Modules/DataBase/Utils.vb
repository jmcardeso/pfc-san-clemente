﻿Imports System.Data.Common
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

    ''' <summary>
    ''' Obtiene un objeto de tipo <c>DBParameter</c>.
    ''' </summary>
    ''' <param name="parameterName">El nombre del parámetro.</param>
    ''' <param name="value">El valor del parámetro.</param>
    ''' <param name="dbType">El tipo del valor del parámetro.</param>
    ''' <returns></returns>
    Public Shared Function AddFilterParameter(parameterName As String, value As Object, dbType As DbType) As DbParameter
        Dim con As Connection = Connection.GetInstance()
        Dim p As DbParameter

        p = con.Factory.CreateParameter()
        p.ParameterName = parameterName
        p.Value = value
        p.DbType = dbType

        Return p
    End Function

    ''' <summary>
    ''' Asigna la fecha de baja/fin a un atributo de un objeto comprobando si debe ser nula.
    ''' </summary>
    ''' <param name="endDate">La fecha de baja/fin.</param>
    ''' <returns>La fecha, si se ha dado de baja el elemento, o Nothing si todavía está activo.</returns>
    Public Shared Function EndDateToObject(endDate As Date) As Date
        Return IIf(endDate.Year = 1970 Or endDate.Year = 1, Nothing, endDate)
    End Function

    ''' <summary>
    ''' Asigna la fecha de baja/fin al campo de una fila de la base de datos. Si aún no se ha producido la baja, inserta un valor semejante a null.
    ''' </summary>
    ''' <param name="endDate">La fecha de baja/fin.</param>
    ''' <returns>La fecha, si se ha dado de baja el elemento, o un valor semejante a null si todavía está activo.</returns>
    Public Shared Function EndDateToDB(endDate As Date) As Date
        Return IIf(endDate.Year < 1971, New Date(1970, 12, 1), endDate)
    End Function


    ''' <summary>
    ''' Comprueba si la fecha de baja/fin existe.
    ''' </summary>
    ''' <param name="endDate">La fecha de baja/fin.</param>
    ''' <returns><c>True</c> si no se ha dado de baja el elemento, <c>False</c> en caso contrario.</returns>
    Public Shared Function IsEndDateEmpty(endDate As Date) As Boolean
        Return endDate.Year = 1 OrElse endDate.Year = 1970
    End Function

    ''' <summary>
    ''' Marca en negrita en el calendario los días con reserva de un inmueble.
    ''' </summary>
    ''' <param name="books">Lista de objetos de la clase <c>Book</c>.</param>
    ''' <param name="mclBooks">Control <c>MonthCalendar</c> en donde se van a marcar las reservas.</param>
    Public Shared Sub MarkBooksInCalendar(books As List(Of Book), mclBooks As MonthCalendar)
        For Each book As Book In books
            For Each d As Date In InBetween(book.CheckIn, book.CheckOut)
                mclBooks.AddBoldedDate(d)
            Next
        Next
        mclBooks.UpdateBoldedDates()
    End Sub

    ''' <summary>
    ''' Crea una lista de <c>Date</c> entre las fechas suministradas.
    ''' </summary>
    ''' <param name="d1">La fecha de inicio.</param>
    ''' <param name="d2">La fecha de fin.</param>
    ''' <returns>Lista de <c>Date</c> con el intervalo de fechas entre las suministradas.</returns>
    Private Shared Function InBetween(d1 As Date, d2 As Date) As List(Of Date)
        Dim datesIB As New List(Of Date)

        While d1 <= d2
            datesIB.Add(d1)
            d1 = d1.AddDays(1)
        End While

        Return datesIB
    End Function
End Class
