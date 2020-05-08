Imports System.Data.Common
Imports System.Configuration
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Public Class DbOperations
    Private Shared objDbOperations As DbOperations
    Private con As Connection = Connection.GetInstance()
    Private cs As ConnectionStringSettings
    ' Private dtsPruebas As New DataSet

    Private Sub New(dbType As String)
        If con.Open(dbType) Is Nothing Then
            'My.Settings.appStatus = "dbError"
            'My.Settings.Save()
            'MsgBox(LocRM.GetString("fatalErrorDB"), MsgBoxStyle.Critical, LocRM.GetString("fatalErrorDBTitle"))
            'ConnectionWizard()
        End If
    End Sub

    Public Shared Function GetInstance(dbType As String) As DbOperations
        If objDbOperations Is Nothing Then
            If dbType Is Nothing Then
                Throw New InvalidOperationException("No database type has been defined")
            End If
            objDbOperations = New DbOperations(dbType)
        End If

        Return objDbOperations
    End Function

    Public Shared Function GetInstance() As DbOperations
        Return GetInstance(Nothing)
    End Function

    Public Function GetAllOwners() As List(Of Owner)
        Return GetAllOwners(Nothing)
    End Function

    Public Function GetAllOwners(nif As String) As List(Of Owner)
        Dim owners As New List(Of Owner)
        Dim owner As Owner

        Dim da As DbDataAdapter
        Dim sqlCommand As DbCommand
        Dim sql As String = "select * from owner order by last_name"

        sqlCommand = con.Factory.CreateCommand()

        If nif IsNot Nothing Then
            sql = "select * from owner where nif like @p_nif order by last_name"
            Dim p As DbParameter
            p = con.Factory.CreateParameter()
            p.DbType = DbType.String
            p.Value = nif
            p.ParameterName = "@p_nif"
            sqlCommand.Parameters.Add(p)
        End If

        sqlCommand.CommandText = sql
        sqlCommand.Connection = con.Con
        da = con.Factory.CreateDataAdapter()
        da.SelectCommand = sqlCommand
        Dim dt As New DataTable()
        da.Fill(dt)

        For Each dr As DataRow In dt.Rows
            owner = New Owner(dr.Item(0), dr.Item(1), dr.Item(2), dr.Item(3), dr.Item(4), dr.Item(5), dr.Item(6), dr.Item(7), dr.Item(8), dr.Item(9), dr.Item(10), dr.Item(11))
            owners.Add(owner)
        Next

        Return owners
    End Function

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
        dr.EndEdit()

        da.Update(dt)


        Return result
    End Function

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
