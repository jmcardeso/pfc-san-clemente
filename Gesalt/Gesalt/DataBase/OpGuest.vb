Imports System.Data.Common

''' <summary>
''' Representa un conjunto de métodos para realizar operaciones en la tabla guest de la base de datos.
''' </summary>
Public Class OpGuest
    Private Shared objOpGuest As OpGuest
    Private con As Connection = Connection.GetInstance()

    ''' <summary>
    ''' Inicializa una nueva instancia de la clase <c>OpGuest</c>, que permite realizar operaciones en la tabla guest de la base de datos.
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
    ''' Devuelve la única instancia de la clase <c>OpGuest</c>.
    ''' </summary>
    ''' <returns>Instancia a la clase <c>OpGuest</c></returns>
    Public Shared Function GetInstance() As OpGuest
        If objOpGuest Is Nothing Then
            objOpGuest = New OpGuest()
        End If

        Return objOpGuest
    End Function

    ''' <summary>
    ''' Obtiene una lista con las filas de datos de la tabla guest de la base de datos.
    ''' </summary>
    ''' <param name="sql">Opcional. Cadena de texto con la sentencia de selección de la tabla guest de la base de datos.</param>
    ''' <param name="parameters">Opcional. Colección de parámetros para la sentencia de selección de la tabla guest de la base de datos.</param>
    ''' <returns>Lista con los objetos de la case <c>guest</c> obtenidos de la tabla guest de la base de datos.</returns>
    Public Function Getguests(Optional sql As String = "select * from guest order by last_name",
                                 Optional parameters As List(Of DbParameter) = Nothing) As List(Of Guest)
        Dim guests As New List(Of Guest)
        Dim guest As Guest

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
            guest = New Guest(dr.Item(0), dr.Item(1),
                              dr.Item(2), dr.Item(3),
                              dr.Item(4), dr.Item(5),
                              dr.Item(6), dr.Item(7),
                              dr.Item(8), dr.Item(9),
                              dr.Item(10), dr.Item(11),
                              dr.Item(12))
            guests.Add(guest)
        Next

        Return guests
    End Function

    ''' <summary>
    ''' Borra una fila de datos de la tabla guest de la base de datos.
    ''' </summary>
    ''' <param name="guest">El objeto de la clase <c>guest</c> que se va a borrar de la tabla guest de la base de datos.</param>
    ''' <returns><c>True</c> si el borrado ha tenido éxito, <c>False</c> en caso contrario.</returns>
    Public Function Deleteguest(guest As Guest) As Boolean
        Dim result As Boolean = False
        Dim da As DbDataAdapter
        Dim cb As DbCommandBuilder
        Dim sqlCommand As DbCommand
        Dim p As DbParameter

        Dim sql As String = "select * from guest where Id = @p_id"

        sqlCommand = con.Factory.CreateCommand()
        sqlCommand.CommandText = sql
        sqlCommand.Connection = con.Con

        p = con.Factory.CreateParameter()
        p.DbType = DbType.Int32
        p.Value = guest.Id
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
        'COMPROBAR QUE SE PUEDE BORRAR (QUE NO TIENE RESERVAS)
        dr.Delete()

        If da.Update(dt) = 1 Then
            result = True
        End If

        Return result
    End Function

    ''' <summary>
    ''' Añade una nueva fila a la tabla guest de la base de datos.
    ''' </summary>
    ''' <param name="guest">El objeto de la clase <c>guest</c> que se va a añadir en la tabla guest de la base de datos.</param>
    ''' <returns><c>True</c> si la inserción ha tenido éxito, <c>False</c> en caso contrario.</returns>
    Public Function Addguest(guest As Guest) As Boolean
        Dim result As Boolean = False
        Dim da As DbDataAdapter
        Dim cb As DbCommandBuilder
        Dim sqlCommand As DbCommand

        Dim sql As String = "select * from guest"

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

        FillRow(dr, guest)
        dt.Rows.Add(dr)

        If da.Update(dt) = 1 Then
            result = True
        End If

        Return result
    End Function

    ''' <summary>
    ''' Modifica los datos de una fila de la tabla guest de la base de datos.
    ''' </summary>
    ''' <param name="guest">El objeto de la clase <c>guest</c> que se va a modificar en la tabla guest de la base de datos.</param>
    ''' <returns><c>True</c> si la modificación ha tenido éxito, <c>False</c> en caso contrario.</returns>
    Public Function Updateguest(guest As Guest) As Boolean
        Dim result As Boolean = False
        Dim da As DbDataAdapter
        Dim cb As DbCommandBuilder
        Dim sqlCommand As DbCommand
        Dim p As DbParameter

        Dim sql As String = "select * from guest where Id = @p_id"

        sqlCommand = con.Factory.CreateCommand()
        sqlCommand.CommandText = sql
        sqlCommand.Connection = con.Con

        p = con.Factory.CreateParameter()
        p.DbType = DbType.Int32
        p.Value = guest.Id
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
        FillRow(dr, guest)
        dr.EndEdit()

        If da.Update(dt) = 1 Then
            result = True
        End If

        Return result
    End Function

    ''' <summary>
    ''' Introduce los datos de las propiedades de un objeto de la clase <c>guest</c> en los campos de una fila de la tabla guest de la base de datos.
    ''' </summary>
    ''' <param name="dr">Representa una fila de datos de la tabla guest de la base de datos.</param>
    ''' <param name="guest">El objeto de la clase guest cuyos parámetros se van a introducir en la fila.</param>
    Private Sub FillRow(dr As DataRow, guest As Guest)
        dr("Id") = guest.Id
        dr("first_name") = guest.FirstName
        dr("last_name") = guest.LastName
        dr("nif") = guest.Nif
        dr("address") = guest.Address
        dr("city") = guest.City
        dr("zip") = guest.Zip
        dr("rating") = guest.Rating
        dr("province") = guest.Province
        dr("phone") = guest.Phone
        dr("email") = guest.Email
        dr("comments") = guest.Comments
        dr("accept_ad") = guest.AcceptAd
    End Sub
End Class
