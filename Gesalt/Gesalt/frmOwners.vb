Imports System.Resources

Public Class frmOwners
    Dim opOwner As OpOwner = OpOwner.GetInstance()
    Dim LocRM As New ResourceManager("Gesalt.WinFormStrings", GetType(frmOwners).Assembly)
    Dim bs As New BindingSource()
    Dim owners As New List(Of Owner)

    Private Sub frmOwners_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            owners = opOwner.GetOwners()

            bs.DataSource = owners

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

                .DataSource = bs
            End With

            lblLastName.DataBindings.Add("Text", bs, "LastName")
            lblFirstName.DataBindings.Add("Text", bs, "FirstName")
            lblAddress.DataBindings.Add("Text", bs, "Address")
            lblCity.DataBindings.Add("Text", bs, "City")
            lblEmail.DataBindings.Add("Text", bs, "Email")
            lblLogo.DataBindings.Add("Text", bs, "PathLogo")
            lblNif.DataBindings.Add("Text", bs, "Nif")
            lblPhone.DataBindings.Add("Text", bs, "Phone")
            lblProvince.DataBindings.Add("Text", bs, "Province")
            lblType.DataBindings.Add("Text", bs, "Type")
            lblZip.DataBindings.Add("Text", bs, "Zip")

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
        bs.Position += 1
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        bs.Position -= 1
    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        bs.Position = 0
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        bs.Position = owners.Count - 1
    End Sub

    Private Sub AddAnOwnerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddAnOwnerToolStripMenuItem.Click
        Dim frmAux As New frmOwnersAux With {
            .editOwner = Nothing
        }

        If frmAux.ShowDialog = DialogResult.Cancel Then
            Exit Sub
        End If

        If Not opOwner.AddOwner(frmAux.editOwner) Then
            MsgBox(LocRM.GetString("opFailedMsg"), MsgBoxStyle.Exclamation, LocRM.GetString("opFailedTitle"))
            Exit Sub
        End If
        ' si añade y hay filtro, ¿qué hace, borra el filtro o añade sin más o k  ase?
        owners.Add(frmAux.editOwner)
        bs.ResetBindings(False)
        bs.Position = owners.Count - 1
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        Dim frmAux As New frmOwnersAux With {
            .Text = LocRM.GetString("editOwnerTitle"),
            .editOwner = bs.Current
        }

        If frmAux.ShowDialog = DialogResult.Cancel Then
            Exit Sub
        End If

        Dim ownerAux As Owner = Utils.DeepClone(owners.Item(bs.Position))
        owners.Item(bs.Position) = Utils.DeepClone(frmAux.editOwner)

        If Not opOwner.UpdateOwner(owners.Item(bs.Position)) Then
            MsgBox(LocRM.GetString("opFailedMsg"), MsgBoxStyle.Exclamation, LocRM.GetString("opFailedTitle"))
            owners.Item(bs.Position) = Utils.DeepClone(ownerAux)
            Exit Sub
        End If

        bs.ResetBindings(False)
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        If MsgBox("'" & bs.Current.LastName & ", " & bs.Current.FirstName & "' " & LocRM.GetString("rowRemovedMsg"),
                  MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2,
                  LocRM.GetString("rewRemovedTitle")) = MsgBoxResult.No Then
            Exit Sub
        End If

        If Not opOwner.DeleteOwner(bs.Current) Then
            MsgBox(LocRM.GetString("opFailedMsg"), MsgBoxStyle.Exclamation, LocRM.GetString("opFailedTitle"))
            Exit Sub
        End If

        owners.Remove(bs.Current)
        bs.ResetBindings(False)
    End Sub

    Private Sub FilterDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FilterDataToolStripMenuItem.Click
        If FilterDataToolStripMenuItem.Text.Equals(LocRM.GetString("filterOwnersMenuOFF")) Then
            Dim frmFlt As frmOwnersFilter = New frmOwnersFilter()
            If frmFlt.ShowDialog() = DialogResult.Cancel Then
                Exit Sub
            End If
            lblFilter.Text = LocRM.GetString("filterOwnersLabelON") & " " & frmFlt.resultReadable
            lblFilter.BackColor = Color.Red
            lblFilter.ForeColor = Color.White
            FilterDataToolStripMenuItem.Text = LocRM.GetString("filterOwnersMenuON")

            owners = opOwner.GetOwners(frmFlt.resultSQL, frmFlt.resultParameters)
        Else
            lblFilter.Text = LocRM.GetString("filterOwnersLabelOFF")
            lblFilter.BackColor = SystemColors.Control
            lblFilter.ForeColor = SystemColors.ControlText
            FilterDataToolStripMenuItem.Text = LocRM.GetString("filterOwnersMenuOFF")

            owners = opOwner.GetOwners()
        End If

        bs.DataSource = owners
    End Sub
End Class