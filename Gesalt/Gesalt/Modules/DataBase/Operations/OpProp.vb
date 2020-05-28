Imports System.Data.Common
Imports Gesalt

''' <summary>
''' Representa un conjunto de métodos para realizar operaciones en la tabla property de la base de datos.
''' </summary>
Public Class OpProp
    Private Shared objOpProp As OpProp
    Private con As Connection = Connection.GetInstance()

    ''' <summary>
    ''' Inicializa una nueva instancia de la clase <c>OpProp</c>, que permite realizar operaciones en la tabla property de la base de datos.
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
    ''' Devuelve la única instancia de la clase <c>OpProp</c>.
    ''' </summary>
    ''' <returns>Instancia a la clase <c>OpProp</c></returns>
    Public Shared Function GetInstance() As OpProp
        If objOpProp Is Nothing Then
            objOpProp = New OpProp()
        End If

        Return objOpProp
    End Function

    ''' <summary>
    ''' Obtiene una lista con las filas de datos de la tabla property de la base de datos.
    ''' </summary>
    ''' <param name="sql">Opcional. Cadena de texto con la sentencia de selección de la tabla property de la base de datos.</param>
    ''' <param name="parameters">Opcional. Colección de parámetros para la sentencia de selección de la tabla property de la base de datos.</param>
    ''' <returns>Lista con los objetos de la case <c>Prop</c> obtenidos de la tabla property de la base de datos.</returns>
    Public Function GetProps(Optional sql As String = "select * from property order by city",
                                 Optional parameters As List(Of DbParameter) = Nothing) As List(Of Prop)
        Dim Props As New List(Of Prop)
        Dim Prop As Prop

        Dim da As DbDataAdapter
        Dim sqlCommand As DbCommand
        Dim opBook As OpBook = OpBook.GetInstance()

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
            Prop = New Prop(dr.Item(0), dr.Item(1),
                              dr.Item(2), dr.Item(3),
                              dr.Item(4), dr.Item(5),
                              dr.Item(6), dr.Item(7),
                              dr.Item(8), dr.Item(9),
                              dr.Item(10))

            Prop.Photos = GetAllPhotos(Prop.Id)
            Prop.Lessors = GetLessors(Prop.Id)
            Prop.Books = opBook.GetBooksByPropertyId(Prop.Id)

            Props.Add(Prop)
        Next

        Return Props
    End Function

    ''' <summary>
    ''' Borra una fila de datos de la tabla property de la base de datos.
    ''' </summary>
    ''' <param name="prop">El objeto de la clase <c>Prop</c> que se va a borrar de la tabla property de la base de datos.</param>
    ''' <returns><c>True</c> si el borrado ha tenido éxito, <c>False</c> en caso contrario.</returns>
    Public Function DeleteProp(prop As Prop) As Boolean
        Dim result As Boolean = False
        Dim da As DbDataAdapter
        Dim cb As DbCommandBuilder
        Dim sqlCommand As DbCommand
        Dim p As DbParameter
        Dim opBook As OpBook = OpBook.GetInstance()

        Dim sql As String = "select * from property where Id = @p_id"

        sqlCommand = con.Factory.CreateCommand()
        sqlCommand.CommandText = sql
        sqlCommand.Connection = con.Con

        p = con.Factory.CreateParameter()
        p.DbType = DbType.Int32
        p.Value = prop.Id
        p.ParameterName = "@p_id"
        sqlCommand.Parameters.Add(p)

        da = con.Factory.CreateDataAdapter()
        da.SelectCommand = sqlCommand

        cb = con.Factory.CreateCommandBuilder()
        cb.DataAdapter = da

        Dim dt As New DataTable()
        da.Fill(dt)

        'COMPROBAR QUE SE PUEDE BORRAR (QUE NO TIENE RESERVAS)
        If True Then
            For Each photo As Photo In prop.Photos
                DeletePhoto(photo)
            Next

            For Each lessor As LessorProp In prop.Lessors
                DeleteLessor(prop.Id, lessor.Lessor.Id)
            Next

            For Each bt As BookType In opBook.GetBookTypes(prop.Id)
                opBook.DeleteBookType(bt)
            Next

            Dim dr As DataRow
            dr = dt.Rows.Item(0)
            dr.Delete()

            If da.Update(dt) = 1 Then
                result = True
            End If
        End If

        Return result
    End Function

    ''' <summary>
    ''' Añade una nueva fila a la tabla property de la base de datos.
    ''' </summary>
    ''' <param name="prop">El objeto de la clase <c>Prop</c> que se va a añadir en la tabla property de la base de datos.</param>
    ''' <returns>El índice de la clave primaria de la fila añadida. -1 si ha habido un problema al calcular el índice.
    ''' -2 si ha habido un problema al añadir la fila. -3 si ha habido un problema al refrescar la tabla lessor_prop</returns>
    Public Function AddProp(prop As Prop) As Integer
        Dim result As Integer
        Dim da As DbDataAdapter
        Dim cb As DbCommandBuilder
        Dim sqlCommand As DbCommand

        Dim sql As String = "select * from property"

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
            prop.Id = result

            FillRow(dr, prop)
            dt.Rows.Add(dr)

            If da.Update(dt) <> 1 Then
                result = -2
            End If
        End If

        If Not RefreshLessors(prop) Then
            result = -3
        End If

        Return result
    End Function

    ''' <summary>
    ''' Modifica los datos de una fila de la tabla property de la base de datos.
    ''' </summary>
    ''' <param name="prop">El objeto de la clase <c>Prop</c> que se va a modificar en la tabla property de la base de datos.</param>
    ''' <returns><c>True</c> si la modificación ha tenido éxito, <c>False</c> en caso contrario.</returns>
    Public Function UpdateProp(prop As Prop) As Boolean
        Dim result As Boolean = False
        Dim da As DbDataAdapter
        Dim cb As DbCommandBuilder
        Dim sqlCommand As DbCommand
        Dim p As DbParameter

        Dim sql As String = "select * from property where Id = @p_id"

        sqlCommand = con.Factory.CreateCommand()
        sqlCommand.CommandText = sql
        sqlCommand.Connection = con.Con

        p = con.Factory.CreateParameter()
        p.DbType = DbType.Int32
        p.Value = prop.Id
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
        FillRow(dr, prop)
        dr.EndEdit()

        If da.Update(dt) = 1 Then
            result = True
        End If

        If Not RefreshLessors(prop) Then
            result = False
        End If

        Return result
    End Function

    Public Function GetAllPhotos(propertyId As Integer) As List(Of Photo)
        Dim photos As New List(Of Photo)
        Dim da As DbDataAdapter
        Dim sqlCommand As DbCommand
        Dim parameter As DbParameter

        sqlCommand = con.Factory.CreateCommand()
        parameter = con.Factory.CreateParameter()

        parameter.ParameterName = "@property_id"
        parameter.Value = propertyId
        parameter.DbType = DbType.Int32

        sqlCommand.Parameters.Add(parameter)
        sqlCommand.CommandText = "select * from photo where property_id = @property_id"
        sqlCommand.Connection = con.Con

        da = con.Factory.CreateDataAdapter()
        da.SelectCommand = sqlCommand

        Dim dt As New DataTable()
        da.Fill(dt)

        For Each dr As DataRow In dt.Rows
            photos.Add(New Photo(dr.Item(0), dr.Item(1), dr.Item(2)))
        Next

        Return photos
    End Function

    Public Function AddPhoto(photo As Photo) As Integer
        Dim result As Integer
        Dim da As DbDataAdapter
        Dim cb As DbCommandBuilder
        Dim sqlCommand As DbCommand

        Dim sql As String = "select * from photo"

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

        result = GetPhotoId()
        If result <> -1 Then
            dr("Id") = result
            dr("property_id") = photo.PropertyId
            dr("path") = photo.Path

            dt.Rows.Add(dr)

            If da.Update(dt) <> 1 Then
                result = -2
            End If
        End If

        Return result
    End Function

    Public Function DeletePhoto(photo As Photo) As Boolean
        Dim result As Boolean = False
        Dim da As DbDataAdapter
        Dim cb As DbCommandBuilder
        Dim sqlCommand As DbCommand
        Dim p As DbParameter

        Dim sql As String = "select * from photo where Id = @p_id"

        sqlCommand = con.Factory.CreateCommand()
        sqlCommand.CommandText = sql
        sqlCommand.Connection = con.Con

        p = con.Factory.CreateParameter()
        p.DbType = DbType.Int32
        p.Value = photo.Id
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

    Public Function GetLessors(propertyId As Integer) As List(Of LessorProp)
        Dim lessors As New List(Of LessorProp)
        Dim da As DbDataAdapter
        Dim sqlCommand As DbCommand
        Dim parameter As DbParameter

        sqlCommand = con.Factory.CreateCommand()
        parameter = con.Factory.CreateParameter()

        parameter.ParameterName = "@p_property_id"
        parameter.Value = propertyId
        parameter.DbType = DbType.Int32

        sqlCommand.Parameters.Add(parameter)
        sqlCommand.CommandText = "select * from lessor_prop where property_id = @p_property_id"
        sqlCommand.Connection = con.Con

        da = con.Factory.CreateDataAdapter()
        da.SelectCommand = sqlCommand

        Dim dt As New DataTable()
        da.Fill(dt)

        Dim opLessor As OpLessor = OpLessor.GetInstance()

        For Each dr As DataRow In dt.Rows
            lessors.Add(New LessorProp(opLessor.GetLessor(dr.Item("lessor_id")), dr.Item("percent_property")))
        Next

        Return lessors
    End Function

    Private Function RefreshLessors(prop As Prop) As Boolean
        Dim oldLessors As New List(Of LessorProp)
        oldLessors = GetLessors(prop.Id)

        For Each lessor As LessorProp In oldLessors
            If Not DeleteLessor(prop.Id, lessor.Lessor.Id) Then
                Return False
            End If
        Next

        For Each lessor As LessorProp In prop.Lessors
            If Not AddLessor(prop.Id, lessor.Lessor.Id, lessor.Percentage) Then
                Return False
            End If
        Next

        Return True
    End Function

    Private Function DeleteLessor(propertyId As Integer, lessorId As Integer) As Boolean
        Dim da As DbDataAdapter
        Dim cb As DbCommandBuilder
        Dim sqlCommand As DbCommand
        Dim pPropertyId As DbParameter
        Dim pLessorId As DbParameter

        sqlCommand = con.Factory.CreateCommand()

        pPropertyId = con.Factory.CreateParameter()
        pLessorId = con.Factory.CreateParameter()

        pPropertyId.ParameterName = "@p_property_id"
        pPropertyId.Value = propertyId
        pPropertyId.DbType = DbType.Int32
        sqlCommand.Parameters.Add(pPropertyId)

        pLessorId.ParameterName = "@p_lessor_id"
        pLessorId.Value = lessorId
        pLessorId.DbType = DbType.Int32
        sqlCommand.Parameters.Add(pLessorId)

        Dim sql As String = "select * from lessor_prop where property_id = @p_property_id and lessor_id = @p_lessor_id"

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

    Private Function AddLessor(propertyId As Integer, lessorId As Integer, percentage As Decimal) As Boolean
        Dim da As DbDataAdapter
        Dim cb As DbCommandBuilder
        Dim sqlCommand As DbCommand
        Dim parameter As DbParameter

        sqlCommand = con.Factory.CreateCommand()
        parameter = con.Factory.CreateParameter()

        parameter.ParameterName = "@p_property_id"
        parameter.Value = propertyId
        parameter.DbType = DbType.Int32
        sqlCommand.Parameters.Add(parameter)

        Dim sql As String = "select * from lessor_prop where property_id = @p_property_id"

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
        dr.Item("property_id") = propertyId
        dr.Item("lessor_id") = lessorId
        dr.Item("percent_property") = percentage

        dt.Rows.Add(dr)

        If da.Update(dt) <> 1 Then
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' Introduce los datos de las propiedades de un objeto de la clase <c>Prop</c> en los campos de una fila de la tabla property de la base de datos.
    ''' </summary>
    ''' <param name="dr">Representa una fila de datos de la tabla property de la base de datos.</param>
    ''' <param name="prop">El objeto de la clase Prop cuyos parámetros se van a introducir en la fila.</param>
    Private Sub FillRow(dr As DataRow, prop As Prop)
        dr("Id") = prop.Id
        dr("cad_ref") = prop.CadRef
        dr("address") = prop.Address
        dr("zip") = prop.Zip
        dr("city") = prop.City
        dr("province") = prop.Province
        dr("max_guests") = prop.MaxGuests
        dr("siz") = prop.Size
        dr("bedrooms") = prop.Bedrooms
        dr("baths") = prop.Baths
        dr("description") = prop.Description
    End Sub

    Private Function GetId() As Integer
        Dim result As Object
        Dim sqlCommand As DbCommand
        Dim sql As String = "select max(Id) from property"

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

    Private Function GetPhotoId() As Integer
        Dim result As Object
        Dim sqlCommand As DbCommand
        Dim sql As String = "select max(Id) from photo"

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
