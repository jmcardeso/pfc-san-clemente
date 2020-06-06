Imports System.Data.Common

''' <summary>
''' Representa un conjunto de métodos para realizar operaciones en las tablas book, booktype y price de la base de datos.
''' </summary>
Public Class OpBook
    Private Shared objOpBook As OpBook
    Private con As Connection = Connection.GetInstance()

    ''' <summary>
    ''' Inicializa una nueva instancia de la clase <c>OpBook</c>, que permite realizar operaciones en las tablas book, booktype y price de la base de datos.
    ''' </summary>
    Private Sub New()
        con.Open()
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

#Region "Book"
    ''' <summary>
    ''' Devuelve una lista de objetos de la clase <c>Book</c> que representan las reservas hechas por un cliente.
    ''' </summary>
    ''' <param name="guestId">El campo Id del cliente.</param>
    ''' <returns>La lista con las reservas.</returns>
    Public Function GetBooksByGuestId(guestId As Integer) As List(Of Book)
        Dim books As New List(Of Book)
        Dim da As DbDataAdapter
        Dim sqlCommand As DbCommand
        Dim pPropId As DbParameter

        sqlCommand = con.Factory.CreateCommand()
        pPropId = con.Factory.CreateParameter()

        pPropId.ParameterName = "@p_guest_id"
        pPropId.Value = guestId
        pPropId.DbType = DbType.Int32

        sqlCommand.Parameters.Add(pPropId)

        sqlCommand.CommandText = "select * from book where guest_id = @p_guest_id order by property_id"
        sqlCommand.Connection = con.Con

        da = con.Factory.CreateDataAdapter()
        da.SelectCommand = sqlCommand

        Dim dt As New DataTable()
        da.Fill(dt)

        Dim book As Book
        For Each dr As DataRow In dt.Rows
            book = New Book(dr.Item("Id"), dr.Item("guest_id"), dr.Item("property_id"),
                            dr.Item("booktype_id"), dr.Item("status"), dr.Item("checkin"),
                            dr.Item("checkout"), dr.Item("invoice_number"))
            books.Add(book)
        Next

        Return books
    End Function

    ''' <summary>
    ''' Devuelve una lista de objetos de la clase <c>Book</c> que representan las reservas pertenecienes a un modo de reserva concreto.
    ''' </summary>
    ''' <param name="bookTypeId">El campo Id del modo de reserva.</param>
    ''' <returns>La lista con las reservas.</returns>
    Public Function GetBooksByBookTypeId(bookTypeId As Integer) As List(Of Book)
        Dim books As New List(Of Book)
        Dim da As DbDataAdapter
        Dim sqlCommand As DbCommand
        Dim pPropId As DbParameter

        sqlCommand = con.Factory.CreateCommand()
        pPropId = con.Factory.CreateParameter()

        pPropId.ParameterName = "@p_booktype_id"
        pPropId.Value = bookTypeId
        pPropId.DbType = DbType.Int32

        sqlCommand.Parameters.Add(pPropId)

        sqlCommand.CommandText = "select * from book where booktype_id = @p_booktype_id"
        sqlCommand.Connection = con.Con

        da = con.Factory.CreateDataAdapter()
        da.SelectCommand = sqlCommand

        Dim dt As New DataTable()
        da.Fill(dt)

        Dim book As Book
        For Each dr As DataRow In dt.Rows
            book = New Book(dr.Item("Id"), dr.Item("guest_id"), dr.Item("property_id"),
                            dr.Item("booktype_id"), dr.Item("status"), dr.Item("checkin"),
                            dr.Item("checkout"), dr.Item("invoice_number"))
            books.Add(book)
        Next

        Return books
    End Function

    ''' <summary>
    ''' Devuelve una lista de objetos de la clase <c>Book</c> que representan las reservas asociadas a un inmueble.
    ''' </summary>
    ''' <param name="propertyId">El campo Id del inmueble.</param>
    ''' <returns>La lista con las reservas.</returns>
    Public Function GetBooksByPropertyId(propertyId As Integer) As List(Of Book)
        Dim books As New List(Of Book)
        Dim da As DbDataAdapter
        Dim sqlCommand As DbCommand
        Dim pPropId As DbParameter

        sqlCommand = con.Factory.CreateCommand()
        pPropId = con.Factory.CreateParameter()

        pPropId.ParameterName = "@p_property_id"
        pPropId.Value = propertyId
        pPropId.DbType = DbType.Int32

        sqlCommand.Parameters.Add(pPropId)

        sqlCommand.CommandText = "select * from book where property_id = @p_property_id"
        sqlCommand.Connection = con.Con

        da = con.Factory.CreateDataAdapter()
        da.SelectCommand = sqlCommand

        Dim dt As New DataTable()
        da.Fill(dt)

        Dim book As Book
        For Each dr As DataRow In dt.Rows
            book = New Book(dr.Item("Id"), dr.Item("guest_id"), dr.Item("property_id"),
                            dr.Item("booktype_id"), dr.Item("status"), dr.Item("checkin"),
                            dr.Item("checkout"), dr.Item("invoice_number"))
            books.Add(book)
        Next

        Return books
    End Function

    ''' <summary>
    ''' Añade una reserva a la base de datos.
    ''' </summary>
    ''' <param name="book">El objeto de la clase <c>Book</c> que representa una reserva.</param>
    ''' <returns>La Id de la nueva reserva, -1 si ha habido algún error al intentar generar la Id y -2 si ha habido algún error al intentar añadir la reserva a la base de datos.</returns>
    Public Function AddBook(book As Book) As Integer
        Dim result As Integer
        Dim da As DbDataAdapter
        Dim cb As DbCommandBuilder
        Dim sqlCommand As DbCommand

        Dim sql As String = "select * from book"

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
            book.Id = result

            FillRow(dr, book)
            dt.Rows.Add(dr)

            If da.Update(dt) <> 1 Then
                result = -2
            End If
        End If

        Return result
    End Function

    ''' <summary>
    ''' Actualiza una reserva ya existente en la base de datos con nuevos valores.
    ''' </summary>
    ''' <param name="book">El objeto de la clase <c>Book</c> que representa la reserva que se va a actualizar.</param>
    ''' <returns><c>True</c> si la operación ha tenido éxito, <c>False</c> en caso contrario.</returns>
    Public Function UpdateBook(book As Book) As Boolean
        Dim result As Boolean = False
        Dim da As DbDataAdapter
        Dim cb As DbCommandBuilder
        Dim sqlCommand As DbCommand
        Dim p As DbParameter

        Dim sql As String = "select * from book where Id = @p_id"

        sqlCommand = con.Factory.CreateCommand()
        sqlCommand.CommandText = sql
        sqlCommand.Connection = con.Con

        p = con.Factory.CreateParameter()
        p.DbType = DbType.Int32
        p.Value = book.Id
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
        FillRow(dr, book)
        dr.EndEdit()

        If da.Update(dt) = 1 Then
            result = True
        End If

        Return result
    End Function

    ''' <summary>
    ''' Borra una reserva de la base de datos.
    ''' </summary>
    ''' <param name="book">El objeto de la clase <c>Book</c> que representa la reserva que va a ser borrada.</param>
    ''' <returns><c>True</c> si la operación ha tenido éxito, <c>False</c> en caso contrario.</returns>
    Public Function DeleteBook(book As Book) As Boolean
        Dim result As Boolean = False
        Dim da As DbDataAdapter
        Dim cb As DbCommandBuilder
        Dim sqlCommand As DbCommand
        Dim p As DbParameter

        Dim sql As String = "select * from book where Id = @p_id"

        sqlCommand = con.Factory.CreateCommand()
        sqlCommand.CommandText = sql
        sqlCommand.Connection = con.Con

        p = con.Factory.CreateParameter()
        p.DbType = DbType.Int32
        p.Value = book.Id
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
    ''' Indica si es seguro eliminar un modo de reserva.
    ''' </summary>
    ''' <param name="bookTypeId">El campo Id del modo de reserva.</param>
    ''' <returns>Devuelve <c>True</c> si es seguro eliminar el modo de reserva, <c>False</c> en caso contrario.</returns>
    Public Function IsSafeDeleteBookType(bookTypeId As Integer) As Boolean
        Return GetBooksByBookTypeId(bookTypeId).Count = 0
    End Function

    ''' <summary>
    ''' Devuelve una nueva Id para insertar en una nueva fila de la tabla book de la base de datos.
    ''' </summary>
    ''' <returns>La nueva Id.</returns>
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

    ''' <summary>
    ''' Introduce los datos de las propiedades de un objeto de la clase <c>Book</c> en los campos de una fila de la tabla book de la base de datos.
    ''' </summary>
    ''' <param name="dr">Representa una fila de datos de la tabla book de la base de datos.</param>
    ''' <param name="book">El objeto de la clase <c>Book</c> cuyas propiedades se van a introducir en la fila.</param>
    Private Sub FillRow(dr As DataRow, book As Book)
        dr.Item("Id") = book.Id
        dr.Item("property_id") = book.PropertyId
        dr.Item("booktype_id") = book.BookTypeId
        dr.Item("guest_id") = book.GuestId
        dr.Item("status") = book.Status
        dr.Item("checkin") = book.CheckIn
        dr.Item("checkout") = book.CheckOut
        dr.Item("invoice_number") = book.InvoiceNumber
    End Sub
#End Region

#Region "BookType"

    ''' <summary>
    ''' Devuelve un objeto de la clase <c>BookType</c> que representa un modo de reserva.
    ''' </summary>
    ''' <param name="id">El campo Id del modo de reserva.</param>
    ''' <returns>El modo de reserva.</returns>
    Public Function GetBookTypeById(id As Integer) As BookType
        Dim bookType As BookType
        Dim da As DbDataAdapter
        Dim sqlCommand As DbCommand
        Dim parameter As DbParameter

        sqlCommand = con.Factory.CreateCommand()
        parameter = con.Factory.CreateParameter()

        parameter.ParameterName = "@p_Id"
        parameter.Value = id
        parameter.DbType = DbType.Int32

        sqlCommand.Parameters.Add(parameter)
        sqlCommand.CommandText = "select * from booktype where Id = @p_Id"
        sqlCommand.Connection = con.Con

        da = con.Factory.CreateDataAdapter()
        da.SelectCommand = sqlCommand

        Dim dt As New DataTable()
        da.Fill(dt)

        Dim dr As DataRow = dt.Rows.Item(0)

        bookType = New BookType(dr.Item("Id"), dr.Item("property_id"), dr.Item("bt_name"), dr.Item("start_date"),
                              Utils.EndDateToObject(dr.Item("end_date")), dr.Item("url_web"), dr.Item("url_icalendar")) With {
                    .Prices = GetPrices(id)
                   }

        Return bookType
    End Function

    ''' <summary>
    ''' Devuelve una lista de objetos de la clase <c>BookType</c> que representan las reservas asociadas a un inmueble.
    ''' </summary>
    ''' <param name="propertyId">El campo Id del inmueble.</param>
    ''' <returns>La lista que contiene las reservas del inmueble.</returns>
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

    Public Function GetAllBookTypes() As List(Of BookType)
        Dim bookTypes As New List(Of BookType)
        Dim da As DbDataAdapter
        Dim sqlCommand As DbCommand

        sqlCommand = con.Factory.CreateCommand()

        sqlCommand.CommandText = "select * from booktype"
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

    ''' <summary>
    ''' Devuelve una nueva Id para insertar en una nueva fila de la tabla booktype de la base de datos.
    ''' </summary>
    ''' <returns>La nueva Id</returns>
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

    ''' <summary>
    ''' Añade una nueva fila en la tabla booktype de la base de datos.
    ''' </summary>
    ''' <param name="bt">El objeto de la clase <c>BookType</c> que representa un modo de reserva.</param>
    ''' <returns>La Id de la nueva fila, -1 si ha habido un error al generar la Id, -2 si ha habido un error al insertar la fila, -3 si ha habido un error al actualizar los precios de ese modo de resrva.</returns>
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

    ''' <summary>
    ''' Actualiza los valores de una fila de la tabla booktype de la base de datos.
    ''' </summary>
    ''' <param name="bt">El objeto de la clase <c>BookType</c> que representa el modo de reserva que se va a actualizar.</param>
    ''' <returns><c>True</c> si la operación ha tenido éxito, <c>False</c> en caso contrario.</returns>
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

    ''' <summary>
    ''' Borra una fila de datos de la tabla booktype de la base de datos.
    ''' </summary>
    ''' <param name="bt">El objeto de la clase <c>BookType</c> que se va a borrar de la tabla booktype de la base de datos.</param>
    ''' <returns><c>True</c> si el borrado ha tenido éxito, <c>False</c> en caso contrario.</returns>
    Public Function DeleteBookType(bt As BookType) As Boolean
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

        For Each price As Price In bt.Prices
            DeletePrice(price)
        Next

        Dim dr As DataRow
        dr = dt.Rows.Item(0)

        dr.Delete()

        If da.Update(dt) = 1 Then
            result = True
        End If

        Return result
    End Function

    ''' <summary>
    ''' Introduce los datos de las propiedades de un objeto de la clase <c>BookType</c> en los campos de una fila de la tabla booktype de la base de datos.
    ''' </summary>
    ''' <param name="dr">Representa una fila de datos de la tabla booktype de la base de datos.</param>
    ''' <param name="bt">El objeto de la clase <c>BookType</c> cuyas propiedades se van a introducir en la fila.</param>
    Private Sub FillBTRow(dr As DataRow, bt As BookType)
        dr.Item("Id") = bt.Id
        dr.Item("property_id") = bt.PropertyId
        dr.Item("bt_name") = bt.BTName
        dr.Item("start_date") = bt.StartDate
        dr.Item("end_date") = Utils.EndDateToDB(bt.EndDate)
        dr.Item("url_web") = bt.UrlWeb
        dr.Item("url_icalendar") = bt.UrlICalendar
    End Sub
#End Region

#Region "Price"
    ''' <summary>
    ''' Devuelve una nueva Id para insertar en una nueva fila de la tabla price de la base de datos.
    ''' </summary>
    ''' <returns>La nueva Id o -1 si no se ha podido obtener.</returns>
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

    ''' <summary>
    ''' Devuelve una lista de objetos de la clase <c>Price</c> que representa los precios de un modo de reserva.
    ''' </summary>
    ''' <param name="bookTypeId">El campo Id del modo de reserva.</param>
    ''' <returns>La lista de precios.</returns>
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

    ''' <summary>
    ''' Añade una nueva fila a la tabla price de la base de datos.
    ''' </summary>
    ''' <param name="price">El objeto de la clase <c>Price</c> que representa el nuevo precio.</param>
    ''' <param name="bookTypeId">El campo Id del modo de reserva al que pertenece el nuevo precio.</param>
    ''' <returns><c>True</c> si la operación ha tenido éxito, <c>False</c> en caso contrario.</returns>
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

    ''' <summary>
    ''' Borra una fila de la tabla price de la base de datos.
    ''' </summary>
    ''' <param name="price">El objeto de la clase <c>Price</c> que se va a eliminar.</param>
    ''' <returns><c>True</c> si la operación ha tenido éxito, <c>False</c> en caso contrario.</returns>
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
    ''' Actualiza la lista de precios de un modo de reserva para que se reflejen las modificaciones.
    ''' </summary>
    ''' <param name="bt">El objeto de la clase <c>BookType</c> al que se le actualizarán sus precios.</param>
    ''' <returns><c>True</c> si la actualización ha tenido éxito, <c>False</c> en caso contrario.</returns>
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

    ''' <summary>
    ''' Genera un número de factura válido del tipo año-número de secuencia (0000-000). Si se cambia de año, la secuencia se reinicia a 001.
    ''' </summary>
    ''' <param name="propertyId">El campo Id del inmueble al que pertenece la reserva.</param>
    ''' <returns>El nuevo número de factura</returns>
    Public Function GetInvoiceNumber(propertyId As Integer) As String
        Dim invoiceNumber As Object
        Dim sqlCommand As DbCommand
        Dim pPropId As DbParameter
        Dim sql As String = "select max(invoice_number) from book where property_id = @p_property_id AND invoice_number LIKE '____-___' AND invoice_number >= '0000-000' AND invoice_number <= '9999-999'"

        sqlCommand = con.Factory.CreateCommand()
        sqlCommand.CommandText = sql
        sqlCommand.Connection = con.Con

        pPropId = con.Factory.CreateParameter()
        pPropId.ParameterName = "@p_property_id"
        pPropId.Value = propertyId
        pPropId.DbType = DbType.Int32

        sqlCommand.Parameters.Add(pPropId)

        Try
            invoiceNumber = sqlCommand.ExecuteScalar()
            If IsDBNull(invoiceNumber) Then
                invoiceNumber = Now.Year & "-001"
            Else
                Dim invoiceParts() As String

                invoiceParts = CStr(invoiceNumber).Split("-")
                If Not invoiceParts(0).Equals(Now.Year.ToString()) Then
                    invoiceNumber = Now.Year & "-001"
                Else
                    invoiceNumber = invoiceParts(0) & "-" & (CInt(invoiceParts(1)) + 1).ToString("D3")
                End If
            End If
        Catch err As Exception
            invoiceNumber = "ERROR"
        End Try

        Return invoiceNumber
    End Function
#End Region

End Class
