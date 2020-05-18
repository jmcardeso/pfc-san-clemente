Imports System.Resources
Imports Microsoft.Reporting.WinForms
Public Class frmProperty
    Dim opProp As OpProp = OpProp.GetInstance()
    Dim LocRM As New ResourceManager("Gesalt.WinFormStrings", GetType(frmProperty).Assembly)
    Dim bs As New BindingSource()
    Dim bsPhotos As New BindingSource()
    Dim bsLessors As New BindingSource()
    Dim props As New List(Of Prop)

    Private Sub frmprops_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            props = opProp.GetProps()

            bs.DataSource = props

            Dim column As DataGridViewColumn
            With dgvProperties
                .AutoGenerateColumns = False
                .ColumnCount = 5

                column = .Columns(0)
                column.Width = 120
                .Columns(0).Name = "CadRed"
                .Columns(0).HeaderText = LocRM.GetString("fieldCadRef")
                .Columns(0).DataPropertyName = "CadRef"

                column = .Columns(1)
                column.Width = 250
                .Columns(1).Name = "Address"
                .Columns(1).HeaderText = LocRM.GetString("fieldAddress")
                .Columns(1).DataPropertyName = "Address"

                column = .Columns(2)
                column.Width = 150
                .Columns(2).Name = "City"
                .Columns(2).HeaderText = LocRM.GetString("fieldCity")
                .Columns(2).DataPropertyName = "City"

                .Columns(3).Name = "Zip"
                .Columns(3).HeaderText = LocRM.GetString("fieldZip")
                .Columns(3).DataPropertyName = "Zip"

                .Columns(4).Name = "Province"
                .Columns(4).HeaderText = LocRM.GetString("fieldProvince")
                .Columns(4).DataPropertyName = "Province"

                .DataSource = bs
            End With

            lblCadRef.DataBindings.Add("Text", bs, "CadRef")
            lblAddress.DataBindings.Add("Text", bs, "Address")
            lblCity.DataBindings.Add("Text", bs, "City")
            lblZip.DataBindings.Add("Text", bs, "Zip")
            lblProvince.DataBindings.Add("Text", bs, "Province")
            lblMaxGuests.DataBindings.Add("Text", bs, "MaxGuests")
            lblSize.DataBindings.Add("Text", bs, "Size")
            lblBedrooms.DataBindings.Add("Text", bs, "Bedrooms")
            lblBaths.DataBindings.Add("Text", bs, "Baths")
            lblDescription.DataBindings.Add("Text", bs, "Description")

            If bs.Current IsNot Nothing Then
                bsPhotos.DataSource = bs.Current.Photos
                bsLessors.DataSource = bs.Current.Lessors
            Else
                bsPhotos.DataSource = New List(Of Photo)
                pbxPhotos.SizeMode = PictureBoxSizeMode.CenterImage
                pbxPhotos.Image = My.Resources.noImage
                bsLessors.DataSource = New List(Of LessorProp)
            End If

            pbxPhotos.DataBindings.Add("ImageLocation", bsPhotos, "Path")

            With dgvLessors
                .AutoGenerateColumns = False
                .ColumnCount = 2

                column = .Columns(0)
                column.Width = 250
                .Columns(0).Name = "Lessor"
                .Columns(0).HeaderText = LocRM.GetString("fieldLessors")
                .Columns(0).DataPropertyName = "Lessor"

                column = .Columns(1)
                column.Width = 90
                .Columns(1).Name = "Percentage"
                .Columns(1).HeaderText = LocRM.GetString("fieldPercentage")
                .Columns(1).DataPropertyName = "Percentage"
                .DataSource = bsLessors
            End With

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

    Private Sub AddAPropertyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddAPropertyToolStripMenuItem.Click, ToolStripAdd.Click
        If FilterDataToolStripMenuItem.Text.Equals(LocRM.GetString("filterPropertiesMenuON")) Then
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

        Dim id As Integer = opProp.AddProp(frmAux.editProp)
        If id < 1 Then
            MsgBox(LocRM.GetString("opFailedMsg"), MsgBoxStyle.Exclamation, LocRM.GetString("opFailedTitle"))
            Exit Sub
        End If

        ' Se añade el objeto a la lista, incluyendo la id que obtuvimos al insertarlo en la base de datos
        Dim newProp As New Prop()
        newProp = Utils.DeepClone(frmAux.editProp)
        newProp.Id = id
        props.Add(newProp)

        ' Añade las fotos a la base de datos
        For Each photo As Photo In newProp.Photos
            If photo.Id = 0 Then
                photo.PropertyId = newProp.Id
                Dim idPhoto As Integer = opProp.AddPhoto(photo)
                If idPhoto < 1 Then
                    MsgBox(LocRM.GetString("opFailedMsg"), MsgBoxStyle.Exclamation, LocRM.GetString("opFailedTitle"))
                    Exit Sub
                End If
                photo.Id = idPhoto
            End If
        Next

        bs.ResetBindings(False)
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click, ToolStripEdit.Click, dgvProperties.DoubleClick
        If bs.Current Is Nothing Then
            Exit Sub
        End If

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

        ' Si hay alguna foto nueva, la añade a la base de datos
        For Each photo As Photo In props.Item(bs.Position).Photos
            If photo.Id = 0 Then
                photo.PropertyId = props.Item(bs.Position).Id
                Dim idPhoto As Integer = opProp.AddPhoto(photo)
                If idPhoto < 1 Then
                    MsgBox(LocRM.GetString("opFailedMsg"), MsgBoxStyle.Exclamation, LocRM.GetString("opFailedTitle"))
                    Exit Sub
                End If
                photo.Id = idPhoto
            End If
        Next

        bs.ResetBindings(False)
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click, ToolStripDelete.Click
        If bs.Current Is Nothing Then
            Exit Sub
        End If

        If MsgBox(LocRM.GetString("rowRemovedPropMsg") & "'" & bs.Current.Address & "' " & LocRM.GetString("rowRemovedMsg"),
              MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2,
              LocRM.GetString("rowRemovedTitle")) = MsgBoxResult.No Then
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
        If FilterDataToolStripMenuItem.Text.Equals(LocRM.GetString("filterPropertiesMenuOFF")) Then
            Dim frmFlt As frmPropertiesFilter = New frmPropertiesFilter()
            If frmFlt.ShowDialog() = DialogResult.Cancel Then
                Exit Sub
            End If
            lblFilter.Text = LocRM.GetString("filterPropertiesLabelON") & " " & frmFlt.resultReadable
            lblFilter.BackColor = Color.Red
            lblFilter.ForeColor = Color.White
            FilterDataToolStripMenuItem.Text = LocRM.GetString("filterPropertiesMenuON")

            props = opProp.GetProps(frmFlt.resultSQL, frmFlt.resultParameters)
        Else
            lblFilter.Text = LocRM.GetString("filterPropertiesLabelOFF")
            lblFilter.BackColor = SystemColors.Control
            lblFilter.ForeColor = SystemColors.ControlText
            FilterDataToolStripMenuItem.Text = LocRM.GetString("filterPropertiesMenuOFF")

            props = opProp.GetProps()
        End If

        bs.DataSource = props
    End Sub

    Private Sub ToolStripExit_Click(sender As Object, e As EventArgs) Handles ToolStripExit.Click
        Close()
    End Sub

    Private Sub PropReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PropReportToolStripMenuItem.Click, PropertiesReportToolStripMenuItem.Click
        Dim frmRpt As New frmReportProperty()
        Dim rpd As New ReportDataSource("dsProp", bs)
        Dim parameters As New List(Of ReportParameter) From {
        New ReportParameter("p_RptPropertiesHeaderTitle", LocRM.GetString("rptPropertiesHeaderTitle")),
        New ReportParameter("p_RptPropertiesHeaderSubtitle",
                            If(FilterDataToolStripMenuItem.Text.Equals(LocRM.GetString("filterPropertiesMenuON")), lblFilter.Text, " ")),
        New ReportParameter("p_RptPropertiesFieldCadRef", LocRM.GetString("fieldCadRef")),
        New ReportParameter("p_RptPropertiesFieldAddress", LocRM.GetString("fieldAddress")),
        New ReportParameter("p_RptPropertiesFieldCity", LocRM.GetString("fieldCity")),
        New ReportParameter("p_RptPropertiesFieldZip", LocRM.GetString("fieldZip")),
        New ReportParameter("p_RptPropertiesFieldProvince", LocRM.GetString("fieldProvince"))
    }

        frmRpt.rpvProp.LocalReport.DataSources.Clear()
        frmRpt.rpvProp.LocalReport.DataSources.Add(rpd)
        frmRpt.rpvProp.LocalReport.ReportEmbeddedResource = "Gesalt.rptProperty.rdlc"
        frmRpt.rpvProp.LocalReport.SetParameters(parameters)
        frmRpt.rpvProp.RefreshReport()
        frmRpt.ShowDialog()
    End Sub

    Private Sub dgvProperties_SelectionChanged(sender As Object, e As EventArgs) Handles dgvProperties.SelectionChanged
        If bs.Current Is Nothing OrElse bs.Current.Photos.Count = 0 Then
            pbxPhotos.SizeMode = PictureBoxSizeMode.CenterImage
            pbxPhotos.Image = My.Resources.noImage
            bsPhotos.DataSource = New List(Of Photo)
        Else
            pbxPhotos.SizeMode = PictureBoxSizeMode.Zoom
            bsPhotos.DataSource = bs.Current.Photos
            bsPhotos.ResetBindings(False)
        End If

        If bs.Current Is Nothing OrElse bs.Current.Lessors.Count = 0 Then
            bsLessors.DataSource = New List(Of LessorProp)
        Else
            bsLessors.DataSource = bs.Current.Lessors
        End If

        bsLessors.ResetBindings(False)
    End Sub

    Private Sub btnPhotosFirst_Click(sender As Object, e As EventArgs) Handles btnPhotosFirst.Click
        bsPhotos.Position = 0
    End Sub

    Private Sub btnPhotosPrevious_Click(sender As Object, e As EventArgs) Handles btnPhotosPrevious.Click
        bsPhotos.Position -= 1
    End Sub

    Private Sub btnPhotosNext_Click(sender As Object, e As EventArgs) Handles btnPhotosNext.Click
        bsPhotos.Position += 1
    End Sub

    Private Sub btnPhotosLast_Click(sender As Object, e As EventArgs) Handles btnPhotosLast.Click
        bsPhotos.Position = bsPhotos.Count - 1
    End Sub

    Private Sub pbxPhotos_Click(sender As Object, e As EventArgs) Handles pbxPhotos.Click
        If bs.Current Is Nothing OrElse bs.Current.Photos.Count = 0 Then
            Exit Sub
        End If

        Dim frmPV = New frmPictureViewer()
        frmPV.photos = bs.Current.Photos
        frmPV.index = bsPhotos.Position
        frmPV.ShowDialog()
    End Sub
End Class