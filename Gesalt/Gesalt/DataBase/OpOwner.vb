Imports System.Data.Common

''' <summary>
''' Representa un conjunto de métodos para realizar operaciones en la tabla owner de la base de datos.
''' </summary>
Public Class OpOwner
    Private Shared objOpOwner As OpOwner
    Private con As Connection = Connection.GetInstance()

    ''' <summary>
    ''' Inicializa una nueva instancia de la clase <c>OpOwner</c>, que permite realizar operaciones en la tabla owner de la base de datos.
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
    ''' Devuelve la única instancia de la clase <c>OpOwner</c>.
    ''' </summary>
    ''' <returns>Instancia a la clase <c>OpOwner</c></returns>
    Public Shared Function GetInstance() As OpOwner
        If objOpOwner Is Nothing Then
            objOpOwner = New OpOwner()
        End If

        Return objOpOwner
    End Function

    ''' <summary>
    ''' Obtiene una lista con las filas de datos de la tabla owner de la base de datos.
    ''' </summary>
    ''' <param name="sql">Opcional. Cadena de texto con la sentencia de selección de la tabla owner de la base de datos.</param>
    ''' <param name="parameters">Opcional. Colección de parámetros para la sentencia de selección de la tabla owner de la base de datos.</param>
    ''' <returns>Lista con los objetos de la case <c>Owner</c> obtenidos de la tabla owner de la base de datos.</returns>
    Public Function GetOwners(Optional sql As String = "select * from owner order by last_name",
                                 Optional parameters As List(Of DbParameter) = Nothing) As List(Of Owner)
        Dim owners As New List(Of Owner)
        Dim owner As Owner

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
            owner = New Owner(dr.Item(0), dr.Item(1),
                              dr.Item(2), dr.Item(3),
                              dr.Item(4), dr.Item(5),
                              dr.Item(6), dr.Item(7),
                              dr.Item(8), dr.Item(9),
                              dr.Item(10), dr.Item(11))
            owners.Add(owner)
        Next

        Return owners
    End Function

    ''' <summary>
    ''' Obtiene una lista de valores únicos del campo type de la tabla owner de la base de datos.
    ''' </summary>
    ''' <returns>Lista con los valores del campo type de la tabla owner de la base de datos.</returns>
    Public Function GetOwnersType() As List(Of String)
        Dim types As New List(Of String)

        Dim da As DbDataAdapter
        Dim sqlCommand As DbCommand

        sqlCommand = con.Factory.CreateCommand()

        sqlCommand.CommandText = "select distinct type from owner order by type"
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
    ''' Borra una fila de datos de la tabla owner de la base de datos.
    ''' </summary>
    ''' <param name="owner">El objeto de la clase <c>Owner</c> que se va a borrar de la tabla owner de la base de datos.</param>
    ''' <returns><c>True</c> si el borrado ha tenido éxito, <c>False</c> en caso contrario.</returns>
    Public Function DeleteOwner(owner As Owner) As Boolean
        Dim result As Boolean = False
        Dim da As DbDataAdapter
        Dim cb As DbCommandBuilder
        Dim sqlCommand As DbCommand
        Dim p As DbParameter

        Dim sql As String = "select * from owner where Id = @p_id"

        sqlCommand = con.Factory.CreateCommand()
        sqlCommand.CommandText = sql
        sqlCommand.Connection = con.Con

        p = con.Factory.CreateParameter()
        p.DbType = DbType.Int32
        p.Value = owner.Id
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
        'COMPROBAR QUE SE PUEDE BORRAR (QUE NO TIENE INMUEBLES)
        dr.Delete()

        If da.Update(dt) = 1 Then
            result = True
        End If

        Return result
    End Function

    ''' <summary>
    ''' Añade una nueva fila a la tabla owner de la base de datos.
    ''' </summary>
    ''' <param name="owner">El objeto de la clase <c>Owner</c> que se va a añadir en la tabla owner de la base de datos.</param>
    ''' <returns><c>True</c> si la inserción ha tenido éxito, <c>False</c> en caso contrario.</returns>
    Public Function AddOwner(owner As Owner) As Boolean
        Dim result As Boolean = False
        Dim da As DbDataAdapter
        Dim cb As DbCommandBuilder
        Dim sqlCommand As DbCommand

        Dim sql As String = "select * from owner"

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

        FillRow(dr, owner)
        dt.Rows.Add(dr)

        If da.Update(dt) = 1 Then
            result = True
        End If

        Return result
    End Function

    ''' <summary>
    ''' Modifica los datos de una fila de la tabla owner de la base de datos.
    ''' </summary>
    ''' <param name="owner">El objeto de la clase <c>Owner</c> que se va a modificar en la tabla owner de la base de datos.</param>
    ''' <returns><c>True</c> si la modificación ha tenido éxito, <c>False</c> en caso contrario.</returns>
    Public Function UpdateOwner(owner As Owner) As Boolean
        Dim result As Boolean = False
        Dim da As DbDataAdapter
        Dim cb As DbCommandBuilder
        Dim sqlCommand As DbCommand
        Dim p As DbParameter

        Dim sql As String = "select * from owner where Id = @p_id"

        sqlCommand = con.Factory.CreateCommand()
        sqlCommand.CommandText = sql
        sqlCommand.Connection = con.Con

        p = con.Factory.CreateParameter()
        p.DbType = DbType.Int32
        p.Value = owner.Id
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
        FillRow(dr, owner)
        dr.EndEdit()

        If da.Update(dt) = 1 Then
            result = True
        End If

        Return result
    End Function

    ''' <summary>
    ''' Introduce los datos de las propiedades de un objeto de la clase <c>Owner</c> en los campos de una fila de la tabla owner de la base de datos.
    ''' </summary>
    ''' <param name="dr">Representa una fila de datos de la tabla owner de la base de datos.</param>
    ''' <param name="owner">El objeto de la clase Owner cuyos parámetros se van a introducir en la fila.</param>
    Private Sub FillRow(dr As DataRow, owner As Owner)
        dr("Id") = owner.Id
        dr("first_name") = owner.FirstName
        dr("last_name") = owner.LastName
        dr("nif") = owner.Nif
        dr("address") = owner.Address
        dr("city") = owner.City
        dr("zip") = owner.Zip
        dr("type") = owner.Type
        dr("province") = owner.Province
        dr("phone") = owner.Phone
        dr("email") = owner.Email
        dr("path_logo") = owner.PathLogo
    End Sub
End Class
