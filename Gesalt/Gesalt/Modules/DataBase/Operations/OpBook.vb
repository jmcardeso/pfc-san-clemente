Imports System.Data.Common
Imports Gesalt

''' <summary>
''' Representa un conjunto de métodos para realizar operaciones en la tabla book de la base de datos.
''' </summary>
Public Class OpBook
    Private Shared objOpBook As OpBook
    Private con As Connection = Connection.GetInstance()

    ''' <summary>
    ''' Inicializa una nueva instancia de la clase <c>OpBook</c>, que permite realizar operaciones en la tabla book de la base de datos.
    ''' </summary>
    Private Sub New()
        If con.Open() Is Nothing Then
            'My.Settings.appStatus = "dbError"
            'My.Settings.Save()
            'MsgBox(LocRM.GetString("fatalErrorDB"), MsgBoxStyle.Critical, LocRM.GetString("fatalErrorDBTitle"))
            'ConnectionWizard()
        End If
    End Sub

    ''' <summary>
    ''' Devuelve la única instancia de la clase <c>OpBook</c>.
    ''' </summary>
    ''' <returns>Instancia a la clase <c>OpBook</c></returns>
    Public Shared Function GetInstance() As OpBook
        If objOpBook Is Nothing Then
            objOpBook = New OpBook()
        End If

        Return objOpBook
    End Function

    Public Function GetBookTypes(propertyId As Integer) As List(Of BookType)
        Dim bookTypes As New List(Of BookType)
        Dim da As DbDataAdapter
        Dim sqlCommand As DbCommand
        Dim parameter As DbParameter

        sqlCommand = con.Factory.CreateCommand()
        parameter = con.Factory.CreateParameter()

        parameter.ParameterName = "@p_property_id"
        parameter.Value = propertyId
        parameter.DbType = DbType.Int32

        sqlCommand.Parameters.Add(parameter)
        sqlCommand.CommandText = "select * from booktype where property_id = @p_property_id"
        sqlCommand.Connection = con.Con

        da = con.Factory.CreateDataAdapter()
        da.SelectCommand = sqlCommand

        Dim dt As New DataTable()
        da.Fill(dt)

        Dim bt As BookType
        For Each dr As DataRow In dt.Rows
            bt = New BookType(dr.Item("Id"), dr.Item("property_id"), dr.Item("bt_name"), dr.Item("start_date"),
                              Utils.EndDateToObject(dr.Item("end_date")), dr.Item("url_web"), dr.Item("url_icalendar"))
            bt.Prices = GetPrices(bt.Id)
            bookTypes.Add(bt)
        Next

        Return bookTypes
    End Function

    Private Function GetPrices(bookTypeId As Integer) As List(Of Price)
        Dim prices As New List(Of Price)
        Dim da As DbDataAdapter
        Dim sqlCommand As DbCommand
        Dim parameter As DbParameter

        sqlCommand = con.Factory.CreateCommand()
        parameter = con.Factory.CreateParameter()

        parameter.ParameterName = "@p_booktype_id"
        parameter.Value = bookTypeId
        parameter.DbType = DbType.Int32

        sqlCommand.Parameters.Add(parameter)
        sqlCommand.CommandText = "select * from price where booktype_id = @p_booktype_id"
        sqlCommand.Connection = con.Con

        da = con.Factory.CreateDataAdapter()
        da.SelectCommand = sqlCommand

        Dim dt As New DataTable()
        da.Fill(dt)

        For Each dr As DataRow In dt.Rows
            prices.Add(New Price(dr.Item("Id"), dr.Item("booktype_id"), dr.Item("p_value"), dr.Item("type"), dr.Item("start_date"),
                                Utils.EndDateToObject(dr.Item("end_date")), dr.Item("percentage")))
        Next

        Return prices
    End Function

    Private Function GetId() As Integer
        Dim result As Object
        Dim sqlCommand As DbCommand
        Dim sql As String = "select max(Id) from book"

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

    Private Function GetBookTypeId() As Integer
        Dim result As Object
        Dim sqlCommand As DbCommand
        Dim sql As String = "select max(Id) from booktype"

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

    Public Function AddBookType(bt As BookType) As Integer
        Dim result As Integer
        Dim da As DbDataAdapter
        Dim cb As DbCommandBuilder
        Dim sqlCommand As DbCommand

        Dim sql As String = "select * from booktype"

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

        result = GetBookTypeId()

        If result <> -1 Then
            bt.Id = result

            FillBTRow(dr, bt)
            dt.Rows.Add(dr)

            If da.Update(dt) <> 1 Then
                result = -2
            End If
        End If

        If Not RefreshPrices(bt) Then
            result = -3
        End If

        Return result
    End Function
    Public Function UpdateBookType(bt As BookType) As Boolean
        Dim result As Boolean = False
        Dim da As DbDataAdapter
        Dim cb As DbCommandBuilder
        Dim sqlCommand As DbCommand
        Dim p As DbParameter

        Dim sql As String = "select * from booktype where Id = @p_id"

        sqlCommand = con.Factory.CreateCommand()
        sqlCommand.CommandText = sql
        sqlCommand.Connection = con.Con

        p = con.Factory.CreateParameter()
        p.DbType = DbType.Int32
        p.Value = bt.Id
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
        FillBTRow(dr, bt)
        dr.EndEdit()

        If da.Update(dt) = 1 Then
            result = True
        End If

        If Not RefreshPrices(bt) Then
            result = False
        End If

        Return result
    End Function

    Private Function RefreshPrices(bt As BookType) As Boolean
        Dim oldPrices As New List(Of Price)
        oldPrices = GetPrices(bt.Id)

        For Each price As Price In oldPrices
            If Not DeletePrice(price) Then
                Return False
            End If
        Next

        For Each price As Price In bt.Prices
            If Not AddPrice(price, bt.Id) Then
                Return False
            End If
        Next

        Return True
    End Function

    Private Function AddPrice(ByRef price As Price, bookTypeId As Integer) As Boolean
        Dim da As DbDataAdapter
        Dim cb As DbCommandBuilder
        Dim sqlCommand As DbCommand

        sqlCommand = con.Factory.CreateCommand()

        Dim sql As String = "select * from price"

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

        price.Id = GetPriceId()
        dr.Item("Id") = price.Id
        dr.Item("booktype_id") = bookTypeId
        dr.Item("p_value") = price.Value
        dr.Item("type") = price.Type
        dr.Item("start_date") = price.StartDate
        dr.Item("end_date") = Utils.EndDateToDB(price.EndDate)
        dr.Item("percentage") = price.Percentage

        dt.Rows.Add(dr)

        If da.Update(dt) <> 1 Then
            Return False
        End If

        Return True
    End Function

    Private Function DeletePrice(price As Price) As Boolean
        Dim da As DbDataAdapter
        Dim cb As DbCommandBuilder
        Dim sqlCommand As DbCommand
        Dim pId As DbParameter
        Dim pBookTypeId As DbParameter

        sqlCommand = con.Factory.CreateCommand()

        pId = con.Factory.CreateParameter()
        pBookTypeId = con.Factory.CreateParameter()

        pId.ParameterName = "@p_id"
        pId.Value = price.Id
        pId.DbType = DbType.Int32
        sqlCommand.Parameters.Add(pId)

        pBookTypeId.ParameterName = "@p_booktype_id"
        pBookTypeId.Value = price.BookTypeId
        pBookTypeId.DbType = DbType.Int32
        sqlCommand.Parameters.Add(pBookTypeId)

        Dim sql As String = "select * from price where Id = @p_id and booktype_id = @p_booktype_id"

        sqlCommand.CommandText = sql
        sqlCommand.Connection = con.Con

        da = con.Factory.CreateDataAdapter()
        da.SelectCommand = sqlCommand

        cb = con.Factory.CreateCommandBuilder()
        cb.DataAdapter = da

        Dim dt As New DataTable()
        da.Fill(dt)

        Dim dr As DataRow
        dr = dt.Rows.Item(0)

        dr.Delete()

        If da.Update(dt) <> 1 Then
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' Introduce los datos de las propiedades de un objeto de la clase <c>BookType</c> en los campos de una fila de la tabla booktype de la base de datos.
    ''' </summary>
    ''' <param name="dr">Representa una fila de datos de la tabla booktype de la base de datos.</param>
    ''' <param name="bt">El objeto de la clase BookType cuyos parámetros se van a introducir en la fila.</param>
    Private Sub FillBTRow(dr As DataRow, bt As BookType)
        dr.Item("Id") = bt.Id
        dr.Item("property_id") = bt.PropertyId
        dr.Item("bt_name") = bt.BTName
        dr.Item("start_date") = bt.StartDate
        dr.Item("end_date") = Utils.EndDateToDB(bt.EndDate)
        dr.Item("url_web") = bt.UrlWeb
        dr.Item("url_icalendar") = bt.UrlICalendar
    End Sub

    Private Function GetPriceId() As Integer
        Dim result As Object
        Dim sqlCommand As DbCommand
        Dim sql As String = "select max(Id) from price"

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
