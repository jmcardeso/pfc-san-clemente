Imports System.Resources

Public Class frmOwners
    Dim LocRM As New ResourceManager("Gesalt.WinFormStrings", GetType(frmOwners).Assembly)
    Dim cm As CurrencyManager
    Dim owners As New List(Of Owner)

    Private Sub frmOwners_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dbo As DbOperations

        Try
            dbo = DbOperations.GetInstance(My.Settings.dbType)
            owners = dbo.GetAllOwners()

            With dgvOwners
                .AutoGenerateColumns = False
                .ColumnCount = 4

                .Columns(0).Name = "LastName"
                .Columns(0).HeaderText = LocRM.GetString("fieldLastName")
                .Columns(0).DataPropertyName = "LastName"

                .Columns(1).Name = "FirstName"
                .Columns(1).HeaderText = LocRM.GetString("fieldFirstName")
                .Columns(1).DataPropertyName = "FirstName"

                .Columns(2).Name = "Nif"
                .Columns(2).HeaderText = LocRM.GetString("fieldNif")
                .Columns(2).DataPropertyName = "Nif"

                .Columns(3).Name = "Type"
                .Columns(3).HeaderText = LocRM.GetString("fieldType")
                .Columns(3).DataPropertyName = "Type"

                .DataSource = owners
            End With

            ' Uso de CurrencyManager con objetos: https://support.microsoft.com/en-us/help/315786/how-to-bind-a-datagrid-control-to-an-array-of-objects-or-of-structures
            cm = dgvOwners.BindingContext(owners)

            lblLastName.DataBindings.Add("Text", owners, "LastName")
            lblFirstName.DataBindings.Add("Text", owners, "FirstName")
            lblAddress.DataBindings.Add("Text", owners, "Address")
            lblCity.DataBindings.Add("Text", owners, "City")
            lblEmail.DataBindings.Add("Text", owners, "Email")
            lblLogo.DataBindings.Add("Text", owners, "PathLogo")
            lblNif.DataBindings.Add("Text", owners, "Nif")
            lblPhone.DataBindings.Add("Text", owners, "Phone")
            lblProvince.DataBindings.Add("Text", owners, "Province")
            lblType.DataBindings.Add("Text", owners, "Type")
            lblZip.DataBindings.Add("Text", owners, "Zip")

        Catch err As InvalidOperationException
            MsgBox(err.Message)
            Close()
        Catch err As Net.Sockets.SocketException
            MsgBox(err.Message)
            Close()
        Finally

        End Try
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        cm.Position += 1
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        cm.Position -= 1
    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        cm.Position = 0
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        cm.Position = owners.Count - 1
    End Sub
End Class