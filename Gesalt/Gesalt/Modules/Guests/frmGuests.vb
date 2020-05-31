Imports System.Resources
Imports Microsoft.Reporting.WinForms

Public Class frmGuests
    Dim opGuest As OpGuest = OpGuest.GetInstance()
    Dim LocRM As New ResourceManager("Gesalt.WinFormStrings", GetType(frmGuests).Assembly)
    Dim bs As New BindingSource()
    Dim Guests As New List(Of Guest)

    Private Sub frmGuests_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Guests = opGuest.Getguests()

            bs.DataSource = Guests

            Dim column As DataGridViewColumn
            With dgvGuests
                .AutoGenerateColumns = False
                .ColumnCount = 5

                column = .Columns(0)
                column.Width = 200
                .Columns(0).Name = "LastName"
                .Columns(0).HeaderText = LocRM.GetString("fieldLastName")
                .Columns(0).DataPropertyName = "LastName"

                column = .Columns(1)
                column.Width = 170
                .Columns(1).Name = "FirstName"
                .Columns(1).HeaderText = LocRM.GetString("fieldFirstName")
                .Columns(1).DataPropertyName = "FirstName"

                .Columns(2).Name = "Nif"
                .Columns(2).HeaderText = LocRM.GetString("fieldNif")
                .Columns(2).DataPropertyName = "Nif"

                column = .Columns(3)
                column.Width = 145
                .Columns(3).Name = "City"
                .Columns(3).HeaderText = LocRM.GetString("fieldCity")
                .Columns(3).DataPropertyName = "City"

                .Columns(4).Name = "Province"
                .Columns(4).HeaderText = LocRM.GetString("fieldProvince")
                .Columns(4).DataPropertyName = "Province"

                .DataSource = bs
            End With

            lblLastName.DataBindings.Add("Text", bs, "LastName")
            lblFirstName.DataBindings.Add("Text", bs, "FirstName")
            lblAddress.DataBindings.Add("Text", bs, "Address")
            lblCity.DataBindings.Add("Text", bs, "City")
            lblEmail.DataBindings.Add("Text", bs, "Email")
            lblRating.DataBindings.Add("Text", bs, "Rating")
            lblNif.DataBindings.Add("Text", bs, "Nif")
            lblPhone.DataBindings.Add("Text", bs, "Phone")
            lblProvince.DataBindings.Add("Text", bs, "Province")
            lblComments.DataBindings.Add("Text", bs, "Comments")
            lblZip.DataBindings.Add("Text", bs, "Zip")
            cbxAcceptAd.DataBindings.Add("Checked", bs, "AcceptAd")
        Catch err As InvalidOperationException
            MsgBox(err.Message)
            Close()
        Catch err As Net.Sockets.SocketException
            MsgBox(err.Message)
            Close()
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
        bs.Position = Guests.Count - 1
    End Sub

    Private Sub AddAGuestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddAGuestToolStripMenuItem.Click, ToolStripAdd.Click
        If FilterDataToolStripMenuItem.Text.Equals(LocRM.GetString("filterGuestsMenuON")) Then
            If MsgBox(LocRM.GetString("addWhenFilterOnMsg"), MsgBoxStyle.Information Or MsgBoxStyle.YesNo, "Gesalt") = MsgBoxResult.No Then
                Exit Sub
            Else
                FilterDataToolStripMenuItem_Click(Nothing, Nothing)
            End If
        End If

        Dim frmAux As New frmGuestsAux With {
            .editGuest = Nothing
        }

        If frmAux.ShowDialog = DialogResult.Cancel Then
            Exit Sub
        End If

        Dim id As Integer = opGuest.AddGuest(frmAux.editGuest)
        If id < 1 Then
            MsgBox(LocRM.GetString("opFailedMsg"), MsgBoxStyle.Exclamation, LocRM.GetString("opFailedTitle"))
            Exit Sub
        End If

        ' Se añade el objeto a la lista, incluyendo la id que obtuvimos al insertarlo en la base de datos
        Dim newGuest As New Guest()
        newGuest = Utils.DeepClone(frmAux.editGuest)
        newGuest.Id = id
        Guests.Add(newGuest)

        bs.ResetBindings(False)
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click, ToolStripEdit.Click, dgvGuests.DoubleClick
        If bs.Current Is Nothing Then
            Exit Sub
        End If

        Dim frmAux As New frmGuestsAux With {
            .Text = LocRM.GetString("editGuestTitle"),
            .editGuest = bs.Current
        }

        If frmAux.ShowDialog = DialogResult.Cancel Then
            Exit Sub
        End If

        Dim GuestAux As Guest = Utils.DeepClone(Guests.Item(bs.Position))
        Guests.Item(bs.Position) = Utils.DeepClone(frmAux.editGuest)

        If Not opGuest.UpdateGuest(Guests.Item(bs.Position)) Then
            MsgBox(LocRM.GetString("opFailedMsg"), MsgBoxStyle.Exclamation, LocRM.GetString("opFailedTitle"))
            Guests.Item(bs.Position) = Utils.DeepClone(GuestAux)
            Exit Sub
        End If

        bs.ResetBindings(False)
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click, ToolStripDelete.Click
        If bs.Current Is Nothing Then
            Exit Sub
        End If

        If Not opGuest.IsSafeDeleteGuest(bs.Current.Id) Then
            MsgBox(LocRM.GetString("guestNoDeleted"), MsgBoxStyle.Exclamation, "Gesalt")
            Exit Sub
        End If

        If MsgBox("'" & bs.Current.LastName & ", " & bs.Current.FirstName & "' " & LocRM.GetString("rowRemovedMsg"),
                  MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2,
                  LocRM.GetString("rowRemovedTitle")) = MsgBoxResult.No Then
            Exit Sub
        End If

        If Not opGuest.DeleteGuest(bs.Current) Then
            MsgBox(LocRM.GetString("opFailedMsg"), MsgBoxStyle.Exclamation, LocRM.GetString("opFailedTitle"))
            Exit Sub
        End If

        Guests.Remove(bs.Current)
        bs.ResetBindings(False)
    End Sub

    Private Sub FilterDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FilterDataToolStripMenuItem.Click
        If FilterDataToolStripMenuItem.Text.Equals(LocRM.GetString("filterGuestsMenuOFF")) Then
            Dim frmFlt As frmGuestsFilter = New frmGuestsFilter()
            If frmFlt.ShowDialog() = DialogResult.Cancel Then
                Exit Sub
            End If
            lblFilter.Text = LocRM.GetString("filterGuestsLabelON") & " " & frmFlt.resultReadable
            lblFilter.BackColor = Color.Red
            lblFilter.ForeColor = Color.White
            FilterDataToolStripMenuItem.Text = LocRM.GetString("filterGuestsMenuON")

            Guests = opGuest.Getguests(frmFlt.resultSQL, frmFlt.resultParameters)
        Else
            lblFilter.Text = LocRM.GetString("filterGuestsLabelOFF")
            lblFilter.BackColor = SystemColors.Control
            lblFilter.ForeColor = SystemColors.ControlText
            FilterDataToolStripMenuItem.Text = LocRM.GetString("filterGuestsMenuOFF")

            Guests = opGuest.Getguests()
        End If

        bs.DataSource = Guests
    End Sub

    Private Sub ToolStripExit_Click(sender As Object, e As EventArgs) Handles ToolStripExit.Click
        Close()
    End Sub

    Private Sub GuestsReport_Click(sender As Object, e As EventArgs) Handles PruebaToolStripMenuItem.Click, GuestsReportToolStripMenuItem.Click
        Dim frmRpt As New frmReportGuest()
        Dim rpd As New ReportDataSource("dsGuest", bs)
        Dim parameters As New List(Of ReportParameter) From {
            New ReportParameter("p_RptGuestsHeaderTitle", LocRM.GetString("rptGuestsHeaderTitle")),
            New ReportParameter("p_RptGuestsHeaderSubtitle",
                                If(FilterDataToolStripMenuItem.Text.Equals(LocRM.GetString("filterGuestsMenuON")), lblFilter.Text, " ")),
            New ReportParameter("p_rptGuestsFieldLastName", LocRM.GetString("fieldLastName")),
            New ReportParameter("p_rptGuestsFieldFirstName", LocRM.GetString("fieldFirstName")),
            New ReportParameter("p_rptGuestsFieldNif", LocRM.GetString("fieldNif")),
            New ReportParameter("p_rptGuestsFieldPhone", LocRM.GetString("fieldPhone"))
        }

        frmRpt.rpvGuest.LocalReport.DataSources.Clear()
        frmRpt.rpvGuest.LocalReport.DataSources.Add(rpd)
        frmRpt.rpvGuest.LocalReport.ReportEmbeddedResource = "Gesalt.rptGuest.rdlc"
        frmRpt.rpvGuest.LocalReport.SetParameters(parameters)
        frmRpt.rpvGuest.RefreshReport()
        frmRpt.ShowDialog()
    End Sub

    Private Sub lblRating_TextChanged(sender As Object, e As EventArgs) Handles lblRating.TextChanged
        For Each star As PictureBox In pnlRating.Controls
            star.Image = My.Resources.star_off
            If IsNumeric(lblRating.Text) AndAlso star.Name.Last <= lblRating.Text Then
                star.Image = My.Resources.star_on
            End If
        Next
    End Sub
End Class