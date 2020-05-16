Imports System.Resources
Imports Microsoft.Reporting.WinForms

Public Class frmLessors
    Dim opLessor As OpLessor = OpLessor.GetInstance()
    Dim LocRM As New ResourceManager("Gesalt.WinFormStrings", GetType(frmLessors).Assembly)
    Dim bs As New BindingSource()
    Dim lessors As New List(Of Lessor)

    Private Sub frmLessors_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            lessors = opLessor.GetLessors()

            bs.DataSource = lessors

            Dim column As DataGridViewColumn
            With dgvLessors
                .AutoGenerateColumns = False
                .ColumnCount = 6

                .Columns(0).Name = "Type"
                .Columns(0).HeaderText = LocRM.GetString("fieldType")
                .Columns(0).DataPropertyName = "Type"

                column = .Columns(1)
                column.Width = 180
                .Columns(1).Name = "LastName"
                .Columns(1).HeaderText = LocRM.GetString("fieldLastName")
                .Columns(1).DataPropertyName = "LastName"

                column = .Columns(2)
                column.Width = 135
                .Columns(2).Name = "FirstName"
                .Columns(2).HeaderText = LocRM.GetString("fieldFirstName")
                .Columns(2).DataPropertyName = "FirstName"

                .Columns(3).Name = "Nif"
                .Columns(3).HeaderText = LocRM.GetString("fieldNif")
                .Columns(3).DataPropertyName = "Nif"

                .Columns(4).Name = "City"
                .Columns(4).HeaderText = LocRM.GetString("fieldCity")
                .Columns(4).DataPropertyName = "City"

                .Columns(5).Name = "Province"
                .Columns(5).HeaderText = LocRM.GetString("fieldProvince")
                .Columns(5).DataPropertyName = "Province"

                .DataSource = bs
            End With

            lblLastName.DataBindings.Add("Text", bs, "LastName")
            lblFirstName.DataBindings.Add("Text", bs, "FirstName")
            lblAddress.DataBindings.Add("Text", bs, "Address")
            lblCity.DataBindings.Add("Text", bs, "City")
            lblEmail.DataBindings.Add("Text", bs, "Email")
            pbxLogo.DataBindings.Add("ImageLocation", bs, "PathLogo")
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
        bs.Position = lessors.Count - 1
    End Sub

    Private Sub AddALessorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddALessorToolStripMenuItem.Click, ToolStripAdd.Click
        If FilterDataToolStripMenuItem.Text.Equals(LocRM.GetString("filterLessorsMenuON")) Then
            If MsgBox(LocRM.GetString("addWhenFilterOnMsg"), MsgBoxStyle.Information Or MsgBoxStyle.YesNo, "Gesalt") = MsgBoxResult.No Then
                Exit Sub
            Else
                FilterDataToolStripMenuItem_Click(Nothing, Nothing)
            End If
        End If

        Dim frmAux As New frmLessorsAux With {
            .editLessor = Nothing
        }

        If frmAux.ShowDialog = DialogResult.Cancel Then
            Exit Sub
        End If

        Dim id As Integer = opLessor.AddLessor(frmAux.editLessor)
        If id < 1 Then
            MsgBox(LocRM.GetString("opFailedMsg"), MsgBoxStyle.Exclamation, LocRM.GetString("opFailedTitle"))
            Exit Sub
        End If

        ' Se añade el objeto a la lista, incluyendo la id que obtuvimos al insertarlo en la base de datos
        Dim newLessor As New Lessor()
        newLessor = Utils.DeepClone(frmAux.editLessor)
        newLessor.Id = id
        lessors.Add(newLessor)

        bs.ResetBindings(False)
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click, ToolStripEdit.Click, dgvLessors.DoubleClick
        If bs.Current Is Nothing Then
            Exit Sub
        End If

        Dim frmAux As New frmLessorsAux With {
            .Text = LocRM.GetString("editLessorTitle"),
            .editLessor = bs.Current
        }

        If frmAux.ShowDialog = DialogResult.Cancel Then
            Exit Sub
        End If

        Dim lessorAux As Lessor = Utils.DeepClone(lessors.Item(bs.Position))
        lessors.Item(bs.Position) = Utils.DeepClone(frmAux.editLessor)

        If Not opLessor.UpdateLessor(lessors.Item(bs.Position)) Then
            MsgBox(LocRM.GetString("opFailedMsg"), MsgBoxStyle.Exclamation, LocRM.GetString("opFailedTitle"))
            lessors.Item(bs.Position) = Utils.DeepClone(lessorAux)
            Exit Sub
        End If

        bs.ResetBindings(False)
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click, ToolStripDelete.Click
        If bs.Current Is Nothing Then
            Exit Sub
        End If

        If MsgBox("'" & bs.Current.LastName & ", " & bs.Current.FirstName & "' " & LocRM.GetString("rowRemovedMsg"),
                  MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2,
                  LocRM.GetString("rowRemovedTitle")) = MsgBoxResult.No Then
            Exit Sub
        End If

        If Not opLessor.DeleteLessor(bs.Current) Then
            MsgBox(LocRM.GetString("opFailedMsg"), MsgBoxStyle.Exclamation, LocRM.GetString("opFailedTitle"))
            Exit Sub
        End If

        lessors.Remove(bs.Current)
        bs.ResetBindings(False)
    End Sub

    Private Sub FilterDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FilterDataToolStripMenuItem.Click
        If FilterDataToolStripMenuItem.Text.Equals(LocRM.GetString("filterLessorsMenuOFF")) Then
            Dim frmFlt As frmLessorsFilter = New frmLessorsFilter()
            If frmFlt.ShowDialog() = DialogResult.Cancel Then
                Exit Sub
            End If
            lblFilter.Text = LocRM.GetString("filterLessorsLabelON") & " " & frmFlt.resultReadable
            lblFilter.BackColor = Color.Red
            lblFilter.ForeColor = Color.White
            FilterDataToolStripMenuItem.Text = LocRM.GetString("filterLessorsMenuON")

            lessors = opLessor.GetLessors(frmFlt.resultSQL, frmFlt.resultParameters)
        Else
            lblFilter.Text = LocRM.GetString("filterLessorsLabelOFF")
            lblFilter.BackColor = SystemColors.Control
            lblFilter.ForeColor = SystemColors.ControlText
            FilterDataToolStripMenuItem.Text = LocRM.GetString("filterLessorsMenuOFF")

            lessors = opLessor.GetLessors()
        End If

        bs.DataSource = lessors
    End Sub

    Private Sub ToolStripExit_Click(sender As Object, e As EventArgs) Handles ToolStripExit.Click
        Close()
    End Sub

    Private Sub LessorsReport_Click(sender As Object, e As EventArgs) Handles PruebaToolStripMenuItem.Click, LessorsReportToolStripMenuItem.Click
        Dim frmRpt As New frmReportLessor()
        Dim rpd As New ReportDataSource("dsLessor", bs)
        Dim parameters As New List(Of ReportParameter) From {
            New ReportParameter("p_RptLessorsHeaderTitle", LocRM.GetString("rptLessorsHeaderTitle")),
            New ReportParameter("p_RptLessorsHeaderSubtitle",
                                If(FilterDataToolStripMenuItem.Text.Equals(LocRM.GetString("filterLessorsMenuON")), lblFilter.Text, " ")),
            New ReportParameter("p_rptLessorsFieldType", LocRM.GetString("fieldType")),
            New ReportParameter("p_rptLessorsFieldLastName", LocRM.GetString("fieldLastName")),
            New ReportParameter("p_rptLessorsFieldFirstName", LocRM.GetString("fieldFirstName")),
            New ReportParameter("p_rptLessorsFieldNif", LocRM.GetString("fieldNif")),
            New ReportParameter("p_rptLessorsFieldPhone", LocRM.GetString("fieldPhone"))
        }

        frmRpt.rpvLessor.LocalReport.DataSources.Clear()
        frmRpt.rpvLessor.LocalReport.DataSources.Add(rpd)
        frmRpt.rpvLessor.LocalReport.ReportEmbeddedResource = "Gesalt.rptLessor.rdlc"
        frmRpt.rpvLessor.LocalReport.SetParameters(parameters)
        frmRpt.rpvLessor.RefreshReport()
        frmRpt.ShowDialog()
    End Sub
End Class