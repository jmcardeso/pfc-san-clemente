Imports System.Resources
Imports Microsoft.Reporting.WinForms
Public Class frmMain
    Dim opProp As OpProp
    Dim LocRM As New ResourceManager("Gesalt.WinFormStrings", GetType(frmMain).Assembly)
    Dim bs As New BindingSource()
    Dim bsPhotos As New BindingSource()
    Dim bsLessors As New BindingSource()
    Dim props As New List(Of Prop)

    Public Sub New()
        Dim strIdioma As String = My.Settings.language
        Dim cultura As Globalization.CultureInfo

        ' Si es la primera vez que se inicia la aplicación (y, por tanto, no hay un idioma definido)
        If My.Settings.appStatus.Equals("first_start") Then
            cultura = Threading.Thread.CurrentThread.CurrentUICulture

            Select Case cultura.TwoLetterISOLanguageName
                Case "es", "gl"
                    strIdioma = cultura.TwoLetterISOLanguageName
                Case Else
                    strIdioma = "en"
            End Select
            My.Settings.language = strIdioma
        End If

        ' Para forzar el cambio de idioma por código
        Threading.Thread.CurrentThread.CurrentUICulture = Globalization.CultureInfo.GetCultureInfo(strIdioma)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Private Sub frmprops_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.appStatus.Equals("first_start") Then
            ConnectionWizard()
        End If

        ' 1ª aproximación a poner un tooltip con los datos de la reserva
        mclBooks.AddBoldedDate(New Date(2020, 5, 29))
        ToolTip1.SetToolTip(mclBooks, "hohohoh")

        Try
            opProp = OpProp.GetInstance()
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

    Private Sub BookTypeToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BookTypeToolStripMenuItem1.Click
        If bs.Current Is Nothing Then
            Exit Sub
        End If

        Dim frmBT As New frmBookType With {
            .propertyId = bs.Current.Id
        }

        frmBT.lblProperty.Text = bs.Current.Address
        frmBT.ShowDialog()
    End Sub

    ''' <summary>
    ''' Vuelve a cargar el formulario.
    ''' </summary>
    ''' <param name="language">El idioma en el que se mostrará el formulario.
    ''' <para>Ver: <see cref="Globalization.CultureInfo.GetCultureInfo(String)"/>.</para></param>
    Private Sub ReLoadMain(language As String)
        Threading.Thread.CurrentThread.CurrentUICulture = Globalization.CultureInfo.GetCultureInfo(language)
        Me.Controls.Clear()
        Me.InitializeComponent()
        frmprops_Load(Nothing, Nothing)
    End Sub

    ''' <summary>
    ''' Muestra el formulario de preferencias de la aplicación.
    ''' <para>Se utiliza en caso de error en la conexión o cuando el programa se ejecuta por primera vez.</para>
    ''' </summary>
    Private Sub ConnectionWizard()
        Dim frmPref As New frmSettings

        If My.Settings.appStatus.Equals("dbError") Then
            frmPref.Text = LocRM.GetString("dbErrorTitle")
            CloseSplash()
        ElseIf My.Settings.appStatus.Equals("first_start") Then
            CloseSplash()
            MsgBox(LocRM.GetString("firstTimeMsg"), MsgBoxStyle.Information, LocRM.GetString("firstTimeTitle"))
            frmPref.Text = LocRM.GetString("firstTimeTitle")
        End If

        frmPref.ShowDialog()

        If frmPref.LanguageChanged Then
            ReLoadMain(My.Settings.language)
        End If
    End Sub

    Private Sub ManageLessorsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManageLessorsToolStripMenuItem.Click
        Dim frmLsr As New frmLessors

        frmLsr.ShowDialog()
        RefreshData()
    End Sub

    Private Sub ManageGuestsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManageGuestsToolStripMenuItem.Click
        Dim frmGst As New frmGuests

        frmGst.ShowDialog()
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        Dim frmPref As New frmSettings

        frmPref.ShowDialog()

        If frmPref.LanguageChanged Then
            ReLoadMain(My.Settings.language)
        End If
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        Dim frmAbout As New frmAbout

        frmAbout.ShowDialog()
    End Sub

    Private Sub RefreshData()
        props = opProp.GetProps()

        bs.DataSource = props

        If bs.Current IsNot Nothing Then
            bsPhotos.DataSource = bs.Current.Photos
            bsLessors.DataSource = bs.Current.Lessors
        Else
            bsPhotos.DataSource = New List(Of Photo)
            pbxPhotos.SizeMode = PictureBoxSizeMode.CenterImage
            pbxPhotos.Image = My.Resources.noImage
            bsLessors.DataSource = New List(Of LessorProp)
        End If
    End Sub
    Private Sub CloseSplash()

        Dim mySplash = My.Application.OpenForms.Item("SplashScreen")

        If mySplash Is Nothing Then
            Exit Sub
        End If

        mySplash.Invoke(New MethodInvoker(Sub()
                                              mySplash.Close()
                                              mySplash.Dispose()
                                          End Sub))

    End Sub

    Private Sub ManageBooksToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManageBooksToolStripMenuItem.Click
        Dim frmBk As New frmBook()

        frmBk.ShowDialog()
    End Sub

    Private Sub MonthCalendar1_DateChanged(sender As Object, e As DateRangeEventArgs) Handles mclBooks.DateChanged
        If mclBooks.BoldedDates.Contains(e.Start) Then
            mclBooks.RemoveBoldedDate(e.Start)
        Else
            mclBooks.AddBoldedDate(e.Start)
        End If
        mclBooks.UpdateBoldedDates()
    End Sub
End Class