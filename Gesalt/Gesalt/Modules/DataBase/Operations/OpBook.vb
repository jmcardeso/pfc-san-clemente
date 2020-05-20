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
                dr.Item("end_date"), dr.Item("url_web"), dr.Item("url_icalendar"))
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
            prices.Add(New Price(dr.Item("Id"), dr.Item("booktype_id"), dr.Item("value"), dr.Item("type"),
                                 dr.Item("start_date"), dr.Item("end_date"), dr.Item("percentage")))
        Next

        Return prices
    End Function
End Class
