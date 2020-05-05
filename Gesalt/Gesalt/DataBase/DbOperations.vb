Public Class DbOperations
    Private Shared objDbOperations As DbOperations
    Private con As Connection = Connection.GetInstance()
    Private dbt As Object
    ' Private dtsPruebas As New DataSet

    Private Sub New(dbType As String)
        If dbType.Equals("local") Then
            dbt = New DBTypeOleDB()
        Else
            dbt = New DBTypeMySQL()
        End If

        dbt.dbCon = con.Open(dbt.csBuilder)

        If dbt.dbCon Is Nothing Then
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
        Dim sql As String = "select * from owner"

        ' Mejor utilizar parámetros y no concatenar sentencias SQL (por seguridad)
        If Not nif Is Nothing Then
            sql = "select * from owner where nif like @p_nif"

        End If

        dbt.dtaPrueba = con.DataApdapter(sql, dbt.dbCon)
        Dim dt As New DataTable()
        dbt.dtaPrueba.Fill(dt)

        For Each dr As DataRow In dt.Rows
            owner = New Owner(dr.Item(0), dr.Item(1), dr.Item(2), dr.Item(3), dr.Item(4), dr.Item(5), dr.Item(6), dr.Item(7), dr.Item(8), dr.Item(9), dr.Item(10), dr.Item(11))
            owners.Add(owner)
        Next

        Return owners
    End Function

End Class
