﻿Imports System.Data.Common

''' <summary>
''' Representa un conjunto de métodos para realizar operaciones en la tabla lessor de la base de datos.
''' </summary>
Public Class OpLessor
    Private Shared objOpLessor As OpLessor
    Private con As Connection = Connection.GetInstance()

    ''' <summary>
    ''' Inicializa una nueva instancia de la clase <c>OpLessor</c>, que permite realizar operaciones en la tabla lessor de la base de datos.
    ''' </summary>
    Private Sub New()
        con.Open()
    End Sub

    ''' <summary>
    ''' Devuelve la única instancia de la clase <c>OpLessor</c>.
    ''' </summary>
    ''' <returns>Instancia a la clase <c>OpLessor</c></returns>
    Public Shared Function GetInstance() As OpLessor
        If objOpLessor Is Nothing Then
            objOpLessor = New OpLessor()
        End If

        Return objOpLessor
    End Function

    ''' <summary>
    ''' Obtiene una lista con las filas de datos de la tabla lessor de la base de datos.
    ''' </summary>
    ''' <param name="sql">Opcional. Cadena de texto con la sentencia de selección de la tabla lessor de la base de datos.</param>
    ''' <param name="parameters">Opcional. Colección de parámetros para la sentencia de selección de la tabla lessor de la base de datos.</param>
    ''' <returns>Lista con los objetos de la case <c>Lessor</c> obtenidos de la tabla lessor de la base de datos.</returns>
    Public Function GetAllLessors(Optional sql As String = "select * from lessor order by last_name",
                                 Optional parameters As List(Of DbParameter) = Nothing) As List(Of Lessor)
        Dim lessors As New List(Of Lessor)
        Dim lessor As Lessor

        Dim da As DbDataAdapter
        Dim sqlCommand As DbCommand

        sqlCommand = con.Factory.CreateCommand()

        If parameters IsNot Nothing Then
            For Each parameter As DbParameter In parameters
                sqlCommand.Parameters.Add(parameter)
            Next
        End If

        sqlCommand.CommandText = sql
        sqlCommand.Connection = con.Con
        da = con.Factory.CreateDataAdapter()
        da.SelectCommand = sqlCommand
        Dim dt As New DataTable()
        da.Fill(dt)

        For Each dr As DataRow In dt.Rows
            lessor = New Lessor(dr.Item(0), dr.Item(1),
                              dr.Item(2), dr.Item(3),
                              dr.Item(4), dr.Item(5),
                              dr.Item(6), dr.Item(7),
                              dr.Item(8), dr.Item(9),
                              dr.Item(10), dr.Item(11))
            lessors.Add(lessor)
        Next

        Return lessors
    End Function

    ''' <summary>
    ''' Devuelve un arrendador de la base de datos.
    ''' </summary>
    ''' <param name="id">El campo Id de la fila de la tabla lessor que se quiere obtener.</param>
    ''' <returns>Un objeto de la clase <c>Lessor</c> que representa un arrendador.</returns>
    Public Function GetLessor(id As Integer) As Lessor
        Dim lessor As Lessor

        Dim da As DbDataAdapter
        Dim sqlCommand As DbCommand
        Dim p As DbParameter
        Dim dr As DataRow

        sqlCommand = con.Factory.CreateCommand()

        p = con.Factory.CreateParameter()
        p.DbType = DbType.Int32
        p.Value = id
        p.ParameterName = "@p_id"
        sqlCommand.Parameters.Add(p)

        sqlCommand.CommandText = "select * from lessor where Id = @p_id"
        sqlCommand.Connection = con.Con
        da = con.Factory.CreateDataAdapter()
        da.SelectCommand = sqlCommand
        Dim dt As New DataTable()
        da.Fill(dt)

        dr = dt.Rows.Item(0)
        lessor = New Lessor(dr.Item(0), dr.Item(1),
                              dr.Item(2), dr.Item(3),
                              dr.Item(4), dr.Item(5),
                              dr.Item(6), dr.Item(7),
                              dr.Item(8), dr.Item(9),
                              dr.Item(10), dr.Item(11))

        Return lessor
    End Function

    ''' <summary>
    ''' Obtiene una lista de valores únicos del campo type de la tabla lessor de la base de datos.
    ''' </summary>
    ''' <returns>Lista con los valores del campo type de la tabla lessor de la base de datos.</returns>
    Public Function GetLessorsType() As List(Of String)
        Dim types As New List(Of String)

        Dim da As DbDataAdapter
        Dim sqlCommand As DbCommand

        sqlCommand = con.Factory.CreateCommand()

        sqlCommand.CommandText = "select distinct type from lessor order by type"
        sqlCommand.Connection = con.Con
        da = con.Factory.CreateDataAdapter()
        da.SelectCommand = sqlCommand
        Dim dt As New DataTable()
        da.Fill(dt)

        For Each dr As DataRow In dt.Rows
            types.Add(dr.Item(0))
        Next

        Return types
    End Function

    ''' <summary>
    ''' Borra una fila de datos de la tabla lessor de la base de datos.
    ''' </summary>
    ''' <param name="lessor">El objeto de la clase <c>Lessor</c> que se va a borrar de la tabla lessor de la base de datos.</param>
    ''' <returns><c>True</c> si el borrado ha tenido éxito, <c>False</c> en caso contrario.</returns>
    Public Function DeleteLessor(lessor As Lessor) As Boolean
        Dim result As Boolean = False
        Dim da As DbDataAdapter
        Dim cb As DbCommandBuilder
        Dim sqlCommand As DbCommand
        Dim p As DbParameter

        Dim sql As String = "select * from lessor where Id = @p_id"

        sqlCommand = con.Factory.CreateCommand()
        sqlCommand.CommandText = sql
        sqlCommand.Connection = con.Con

        p = con.Factory.CreateParameter()
        p.DbType = DbType.Int32
        p.Value = lessor.Id
        p.ParameterName = "@p_id"
        sqlCommand.Parameters.Add(p)

        da = con.Factory.CreateDataAdapter()
        da.SelectCommand = sqlCommand

        cb = con.Factory.CreateCommandBuilder()
        cb.DataAdapter = da

        Dim dt As New DataTable()
        da.Fill(dt)

        Dim dr As DataRow
        dr = dt.Rows.Item(0)

        dr.Delete()

        If da.Update(dt) = 1 Then
            result = True
        End If

        Return result
    End Function

    ''' <summary>
    ''' Añade una nueva fila a la tabla lessor de la base de datos.
    ''' </summary>
    ''' <param name="lessor">El objeto de la clase <c>Lessor</c> que se va a añadir en la tabla lessor de la base de datos.</param>
    ''' <returns>El índice de la clave primaria de la fila añadida. -1 si ha habido un problema al calcular el índice. -2 si ha habido un problema al añadir la fila.</returns>
    Public Function AddLessor(lessor As Lessor) As Integer
        Dim result As Integer
        Dim da As DbDataAdapter
        Dim cb As DbCommandBuilder
        Dim sqlCommand As DbCommand

        Dim sql As String = "select * from lessor"

        sqlCommand = con.Factory.CreateCommand()
        sqlCommand.CommandText = sql
        sqlCommand.Connection = con.Con

        da = con.Factory.CreateDataAdapter()
        da.SelectCommand = sqlCommand

        cb = con.Factory.CreateCommandBuilder()
        cb.DataAdapter = da

        Dim dt As New DataTable()
        da.Fill(dt)

        Dim dr As DataRow
        dr = dt.NewRow()

        result = GetId()

        If result <> -1 Then
            lessor.Id = result

            FillRow(dr, lessor)
            dt.Rows.Add(dr)

            If da.Update(dt) <> 1 Then
                result = -2
            End If
        End If

        Return result
    End Function

    ''' <summary>
    ''' Modifica los datos de una fila de la tabla lessor de la base de datos.
    ''' </summary>
    ''' <param name="lessor">El objeto de la clase <c>Lessor</c> que se va a modificar en la tabla lessor de la base de datos.</param>
    ''' <returns><c>True</c> si la modificación ha tenido éxito, <c>False</c> en caso contrario.</returns>
    Public Function UpdateLessor(lessor As Lessor) As Boolean
        Dim result As Boolean = False
        Dim da As DbDataAdapter
        Dim cb As DbCommandBuilder
        Dim sqlCommand As DbCommand
        Dim p As DbParameter

        Dim sql As String = "select * from lessor where Id = @p_id"

        sqlCommand = con.Factory.CreateCommand()
        sqlCommand.CommandText = sql
        sqlCommand.Connection = con.Con

        p = con.Factory.CreateParameter()
        p.DbType = DbType.Int32
        p.Value = lessor.Id
        p.ParameterName = "@p_id"
        sqlCommand.Parameters.Add(p)

        da = con.Factory.CreateDataAdapter()
        da.SelectCommand = sqlCommand

        cb = con.Factory.CreateCommandBuilder()
        cb.DataAdapter = da

        Dim dt As New DataTable()
        da.Fill(dt)

        Dim dr As DataRow
        dr = dt.Rows.Item(0)

        dr.BeginEdit()
        FillRow(dr, lessor)
        dr.EndEdit()

        If da.Update(dt) = 1 Then
            result = True
        End If

        Return result
    End Function

    ''' <summary>
    ''' Comprueba si un arrendador tiene inmuebles asociados
    ''' </summary>
    ''' <param name="id">El índice correspondiente a la fila de la tabla lessor donde está almacenado el arrendador.</param>
    ''' <returns><c>True</c> si el arrendador tiene inmuebles asociados, <c>False</c> en caso contrario.</returns>
    Public Function LessorHasProperty(id As Integer) As Boolean
        Dim da As DbDataAdapter
        Dim sqlCommand As DbCommand
        Dim parameter As DbParameter

        sqlCommand = con.Factory.CreateCommand()
        parameter = con.Factory.CreateParameter()

        parameter.ParameterName = "@p_lessor_id"
        parameter.Value = id
        parameter.DbType = DbType.Int32

        sqlCommand.Parameters.Add(parameter)
        sqlCommand.CommandText = "select * from lessor_prop where lessor_id = @p_lessor_id"
        sqlCommand.Connection = con.Con

        da = con.Factory.CreateDataAdapter()
        da.SelectCommand = sqlCommand

        Dim dt As New DataTable()
        da.Fill(dt)

        If dt.Rows.Count <> 0 Then
            Return True
        End If

        Return False
    End Function


    ''' <summary>
    ''' Introduce los datos de las propiedades de un objeto de la clase <c>Lessor</c> en los campos de una fila de la tabla lessor de la base de datos.
    ''' </summary>
    ''' <param name="dr">Representa una fila de datos de la tabla lessor de la base de datos.</param>
    ''' <param name="lessor">El objeto de la clase Lessor cuyos parámetros se van a introducir en la fila.</param>
    Private Sub FillRow(dr As DataRow, lessor As Lessor)
        dr("Id") = lessor.Id
        dr("first_name") = lessor.FirstName
        dr("last_name") = lessor.LastName
        dr("nif") = lessor.Nif
        dr("address") = lessor.Address
        dr("city") = lessor.City
        dr("zip") = lessor.Zip
        dr("type") = lessor.Type
        dr("province") = lessor.Province
        dr("phone") = lessor.Phone
        dr("email") = lessor.Email
        dr("path_logo") = lessor.PathLogo
    End Sub

    ''' <summary>
    ''' Genera una Id para una nueva fila de la tabla lessor.
    ''' </summary>
    ''' <returns>La nueva Id generada, -1 en caso de error.</returns>
    Private Function GetId() As Integer
        Dim result As Object
        Dim sqlCommand As DbCommand
        Dim sql As String = "select max(Id) from lessor"

        sqlCommand = con.Factory.CreateCommand()
        sqlCommand.CommandText = sql
        sqlCommand.Connection = con.Con

        Try
            result = sqlCommand.ExecuteScalar()
            If IsDBNull(result) Then
                result = 1
            Else
                result += 1
            End If
        Catch err As Exception
            result = -1
        End Try

        Return result
    End Function
End Class
