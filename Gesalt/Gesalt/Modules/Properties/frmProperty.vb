Imports System.Resources
Imports Microsoft.Reporting.WinForms
Public Class frmProperty
    Dim opProp As OpProp = OpProp.GetInstance()
    Dim LocRM As New ResourceManager("Gesalt.WinFormStrings", GetType(frmProperty).Assembly)
    Dim bs As New BindingSource()
    Dim props As New List(Of Prop)

    Private Sub frmprops_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            props = opProp.GetProps()

            bs.DataSource = props

            Dim column As DataGridViewColumn
            With dgvProperties
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
        bs.Position = props.Count - 1
    End Sub

    Private Sub AddAnPropToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddAPropertyToolStripMenuItem.Click, ToolStripAdd.Click
        If FilterDataToolStripMenuItem.Text.Equals(LocRM.GetString("filterpropsMenuON")) Then
            If MsgBox(LocRM.GetString("addWhenFilterOnMsg"), MsgBoxStyle.Information Or MsgBoxStyle.YesNo, "Gesalt") = MsgBoxResult.No Then
                Exit Sub
            Else
                FilterDataToolStripMenuItem_Click(Nothing, Nothing)
            End If
        End If

        Dim frmAux As New frmPropertiesAux With {
        .editProp = Nothing
    }

        If frmAux.ShowDialog = DialogResult.Cancel Then
            Exit Sub
        End If

        If Not opProp.AddProp(frmAux.editProp) Then
            MsgBox(LocRM.GetString("opFailedMsg"), MsgBoxStyle.Exclamation, LocRM.GetString("opFailedTitle"))
            Exit Sub
        End If

        props = opProp.GetProps()
        bs.DataSource = props
        bs.ResetBindings(False)
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click, ToolStripEdit.Click, dgvProperties.DoubleClick
        Dim frmAux As New frmPropertiesAux With {
        .Text = LocRM.GetString("editPropTitle"),
        .editProp = bs.Current
    }

        If frmAux.ShowDialog = DialogResult.Cancel Then
            Exit Sub
        End If

        Dim PropAux As Prop = Utils.DeepClone(props.Item(bs.Position))
        props.Item(bs.Position) = Utils.DeepClone(frmAux.editProp)

        If Not opProp.UpdateProp(props.Item(bs.Position)) Then
            MsgBox(LocRM.GetString("opFailedMsg"), MsgBoxStyle.Exclamation, LocRM.GetString("opFailedTitle"))
            props.Item(bs.Position) = Utils.DeepClone(PropAux)
            Exit Sub
        End If

        bs.ResetBindings(False)
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click, ToolStripDelete.Click
        If MsgBox("'" & bs.Current.LastName & ", " & bs.Current.FirstName & "' " & LocRM.GetString("rowRemovedMsg"),
              MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2,
              LocRM.GetString("rewRemovedTitle")) = MsgBoxResult.No Then
            Exit Sub
        End If

        If Not opProp.DeleteProp(bs.Current) Then
            MsgBox(LocRM.GetString("opFailedMsg"), MsgBoxStyle.Exclamation, LocRM.GetString("opFailedTitle"))
            Exit Sub
        End If

        props.Remove(bs.Current)
        bs.ResetBindings(False)
    End Sub

    Private Sub FilterDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FilterDataToolStripMenuItem.Click
        If FilterDataToolStripMenuItem.Text.Equals(LocRM.GetString("filterpropsMenuOFF")) Then
            Dim frmFlt As frmPropertiesFilter = New frmPropertiesFilter()
            If frmFlt.ShowDialog() = DialogResult.Cancel Then
                Exit Sub
            End If
            lblFilter.Text = LocRM.GetString("filterpropsLabelON") & " " & frmFlt.resultReadable
            lblFilter.BackColor = Color.Red
            lblFilter.ForeColor = Color.White
            FilterDataToolStripMenuItem.Text = LocRM.GetString("filterpropsMenuON")

            props = opProp.GetProps(frmFlt.resultSQL, frmFlt.resultParameters)
        Else
            lblFilter.Text = LocRM.GetString("filterpropsLabelOFF")
            lblFilter.BackColor = SystemColors.Control
            lblFilter.ForeColor = SystemColors.ControlText
            FilterDataToolStripMenuItem.Text = LocRM.GetString("filterpropsMenuOFF")

            props = opProp.GetProps()
        End If

        bs.DataSource = props
    End Sub

    Private Sub ToolStripExit_Click(sender As Object, e As EventArgs) Handles ToolStripExit.Click
        Close()
    End Sub

    Private Sub propsReport_Click(sender As Object, e As EventArgs) Handles ReportsToolStripMenuItem.Click, PropertiesReportToolStripMenuItem.Click
        Dim frmRpt As New frmReportProp()
        Dim rpd As New ReportDataSource("dsProp", bs)
        Dim parameters As New List(Of ReportParameter) From {
        New ReportParameter("p_RptpropsHeaderTitle", LocRM.GetString("rptpropsHeaderTitle")),
        New ReportParameter("p_RptpropsHeaderSubtitle",
                            If(FilterDataToolStripMenuItem.Text.Equals(LocRM.GetString("filterpropsMenuON")), lblFilter.Text, " ")),
        New ReportParameter("p_rptpropsFieldType", LocRM.GetString("fieldType")),
        New ReportParameter("p_rptpropsFieldLastName", LocRM.GetString("fieldLastName")),
        New ReportParameter("p_rptpropsFieldFirstName", LocRM.GetString("fieldFirstName")),
        New ReportParameter("p_rptpropsFieldNif", LocRM.GetString("fieldNif")),
        New ReportParameter("p_rptpropsFieldPhone", LocRM.GetString("fieldPhone"))
    }

        frmRpt.rpvProp.LocalReport.DataSources.Clear()
        frmRpt.rpvProp.LocalReport.DataSources.Add(rpd)
        frmRpt.rpvProp.LocalReport.ReportEmbeddedResource = "Gesalt.rptProp.rdlc"
        frmRpt.rpvProp.LocalReport.SetParameters(parameters)
        frmRpt.rpvProp.RefreshReport()
        frmRpt.ShowDialog()
    End Sub
End Class