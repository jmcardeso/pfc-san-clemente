'****************************************************************************************
'*                                                                                      *
'*                       GESALT - Gestión de alquileres turísticos                      *
'*                                                                                      *
'*                         (c) Juan Manuel Cardeso García, 2020                         *
'*                                                                                      *
'*      Proyecto de fin de ciclo DAM - IES San Clemente - Santiago de Compostela        *
'*                                                                                      *
'*     Este programa es software libre: puedes redistribuirlo y/o modificarlo bajo      *
'*      los términos de la Licencia General Pública de GNU publicada por la Free        *
'*     Software Foundation, ya sea la versión 3 de la Licencia, o (a tu elección)       *
'*                             cualquier versión posterior.                             *
'*                                                                                      *
'****************************************************************************************

Imports System.Resources
Imports Microsoft.Reporting.WinForms
Public Class frmMain
    Dim opProp As OpProp
    Dim LocRM As New ResourceManager("Gesalt.WinFormStrings", GetType(frmMain).Assembly)
    Dim bs As New BindingSource()
    Dim bsPhotos As New BindingSource()
    Dim bsLessors As New BindingSource()
    Dim props As New List(Of Prop)
    Private lastClickTick As Integer

    Public Sub New()
        Dim strLanguage As String = My.Settings.language
        Dim culture As Globalization.CultureInfo

        ' Si es la primera vez que se inicia la aplicación (y, por tanto, no hay un idioma definido)
        If My.Settings.appStatus.Equals("first_start") Then
            culture = Threading.Thread.CurrentThread.CurrentUICulture

            Select Case culture.TwoLetterISOLanguageName
                Case "es", "gl"
                    strLanguage = culture.TwoLetterISOLanguageName
                Case Else
                    strLanguage = "en"
            End Select
            My.Settings.language = strLanguage
        End If

        ' Para forzar el cambio de idioma por código
        Threading.Thread.CurrentThread.CurrentUICulture = Globalization.CultureInfo.GetCultureInfo(strLanguage)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Private Sub frmprops_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.appStatus.Equals("first_start") Then
            ConnectionWizard()
        End If

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
            lblLegalClass.DataBindings.Add("Text", bs, "PropClass")

            If bs.Current IsNot Nothing Then
                bsPhotos.DataSource = bs.Current.Photos
                bsLessors.DataSource = bs.Current.Lessors
                mclCalendar_DateChanged(Nothing, New DateRangeEventArgs(Now(), Now()))
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

            lastClickTick = Environment.TickCount - SystemInformation.DoubleClickTime
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

        If Not opProp.IsSafeDeleteProp(bs.Current.Id) Then
            MsgBox(LocRM.GetString("propNoDeleted"), MsgBoxStyle.Exclamation, "Gesalt")
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

        mclCalendar.RemoveAllBoldedDates()
        mclCalendar.SelectionStart = Now()
        mclCalendar.SelectionEnd = Now()
        Utils.MarkBooksInCalendar(bs.Current.Books, mclCalendar)
        mclCalendar_DateChanged(Nothing, New DateRangeEventArgs(Now(), Now()))
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

    Private Sub mclCalendar_DateChanged(sender As Object, e As DateRangeEventArgs) Handles mclCalendar.DateChanged
        ' Se elimina el evento para que no se dispare dentro de él (al añadir una BoldedDate)
        RemoveHandler mclCalendar.DateChanged, AddressOf mclCalendar_DateChanged

        If mclCalendar.BoldedDates.Contains(e.Start.Date) And mclCalendar.BoldedDates.Contains(e.End.Date) Then
            Dim limits(2) As Date

            lblCalendar.Text = Utils.GetBookInfo(bs.Current, e.Start)

            limits = Utils.GetBookLimits(bs.Current, e.Start)
            mclCalendar.SelectionStart = limits(0)
            mclCalendar.SelectionEnd = limits(1)
        Else
            lblCalendar.Text = ""
        End If

        ' Se vuelve a añadir el evento al salir
        AddHandler mclCalendar.DateChanged, AddressOf mclCalendar_DateChanged
    End Sub

    ' Ref: https://stackoverflow.com/questions/8498014/capture-doubleclick-for-monthcalendar-control-in-windows-forms-app
    Private Sub mclCalendar_MouseDown(sender As Object, e As MouseEventArgs) Handles mclCalendar.MouseDown
        Dim info As MonthCalendar.HitTestInfo = mclCalendar.HitTest(e.X, e.Y)

        ' Si se pulsa en una zona que se corresponda con una fecha
        If info.HitArea = MonthCalendar.HitArea.Date Then
            Dim tick As Integer

            ' Cuenta los ticks que son necesarios para hacer doble click (MonthCalendar no lanza el evento DoubleClick)
            tick = Environment.TickCount
            If tick - lastClickTick <= SystemInformation.DoubleClickTime Then
                calendarDoubleClick()
            Else
                lastClickTick = tick
            End If
        End If
    End Sub

    Private Sub calendarDoubleClick()
        tsbAddEditCalendar_Click(Nothing, Nothing)
    End Sub

    Private Sub tsbAddEditCalendar_Click(sender As Object, e As EventArgs) Handles tsbAddEditCalendar.Click, ManageBooksToolStripMenuItem.Click
        Dim frmBk As frmBook
        Dim frmSlct As New frmBookingSelect

        If bs.Current Is Nothing Then
            Exit Sub
        End If

        Dim opBook As OpBook = OpBook.GetInstance()
        Dim opGuest As OpGuest = OpGuest.GetInstance()

        Dim bookTypes As New List(Of BookType)
        Dim guests As New List(Of Guest)

        bookTypes = opBook.GetBookTypes(bs.Current.Id)
        If bookTypes.Count = 0 Then
            MsgBox(LocRM.GetString("noBookTypesErrorMsg"), MsgBoxStyle.Exclamation, "Gesalt")
            Exit Sub
        End If

        guests = opGuest.GetGuests()
        If guests.Count = 0 Then
            MsgBox(LocRM.GetString("noGuestsErrorMsg"), MsgBoxStyle.Exclamation, "Gesalt")
            Exit Sub
        End If

        If bs.Current.Lessors.Count = 0 Then
            MsgBox(LocRM.GetString("noLessorsForBookingErrorMsg"), MsgBoxStyle.Exclamation, "Gesalt")
            Exit Sub
        End If

        frmBk = New frmBook With {
            .prop = bs.Current,
            .bookTypes = bookTypes,
            .guests = guests
        }

        Dim books As List(Of Book) = bs.Current.Books

        Dim showfrmSelect As Boolean = False

        Dim dayMatch = From book In books
                       Where mclCalendar.SelectionStart.Date <= book.CheckOut And
                               book.CheckIn <= mclCalendar.SelectionEnd.Date

        Dim bookDayMatch As List(Of Book) = dayMatch.ToList()

        If bookDayMatch.Count > 0 Then
            If bookDayMatch.Count = 2 Then
                If mclCalendar.SelectionStart = bookDayMatch.Item(0).CheckIn And
                    mclCalendar.SelectionEnd.Date = bookDayMatch.Item(1).CheckOut Then
                    frmSlct.bookings = bookDayMatch.ToList()
                    showfrmSelect = True
                Else
                    frmBk.editBook = bookDayMatch.Item(IIf(bookDayMatch.Item(0).CheckIn = mclCalendar.SelectionStart, 0, 1))
                End If
            Else
                If bookDayMatch.Item(0).CheckIn <> mclCalendar.SelectionStart And
                    bookDayMatch.Item(0).CheckOut <> mclCalendar.SelectionEnd.Date Then
                    If bookDayMatch.Item(0).CheckIn = mclCalendar.SelectionEnd.Date Or
                        bookDayMatch.Item(0).CheckOut = mclCalendar.SelectionStart Then
                        frmSlct.bookings.Add(bookDayMatch.First)
                        frmSlct.bookings.Add(Nothing)
                        showfrmSelect = True
                    Else
                        MsgBox(LocRM.GetString("bookAlreadyReservedErrorMsg"), MsgBoxStyle.Exclamation, "Gesalt")
                        Exit Sub
                    End If
                Else
                    frmBk.editBook = bookDayMatch.First
                End If
            End If

            If showfrmSelect Then
                If frmSlct.ShowDialog() = DialogResult.Cancel Then
                    Exit Sub
                Else
                    If frmSlct.bookingSelected Is Nothing Then
                        frmBk.editBook = New Book With {
                            .CheckIn = mclCalendar.SelectionStart,
                            .CheckOut = mclCalendar.SelectionEnd
                        }
                    Else
                        frmBk.editBook = frmSlct.bookingSelected
                    End If
                End If
            End If
        Else
            frmBk.editBook = New Book With {
                .CheckIn = mclCalendar.SelectionStart,
                .CheckOut = mclCalendar.SelectionEnd
            }
        End If

        If frmBk.ShowDialog() = DialogResult.Cancel Then
            Exit Sub
        End If

        If frmBk.IsEdited Then
            Dim thisBooking = From book In CType(bs.Current.Books, List(Of Book)) Where book.Id = frmBk.editBook.Id

            Dim bookAux As Book = thisBooking.First

            If Not opBook.UpdateBook(frmBk.editBook) Then
                MsgBox(LocRM.GetString("opFailedMsg"), MsgBoxStyle.Exclamation, LocRM.GetString("opFailedTitle"))
                Exit Sub
            Else
                bs.Current.Books.Item(bs.Current.Books.indexOf(bookAux)) = Utils.DeepClone(frmBk.editBook)
            End If
        Else
            frmBk.editBook.PropertyId = bs.Current.Id

            Dim id As Integer = opBook.AddBook(frmBk.editBook)
            If id < 1 Then
                MsgBox(LocRM.GetString("opFailedMsg"), MsgBoxStyle.Exclamation, LocRM.GetString("opFailedTitle"))
                Exit Sub
            End If

            Dim newBook As New Book()
            newBook = Utils.DeepClone(frmBk.editBook)
            newBook.Id = id

            bs.Current.Books.Add(newBook)
        End If

        bs.ResetBindings(False)
    End Sub

    Private Sub tsbDeleteCalendar_Click(sender As Object, e As EventArgs) Handles tsbDeleteCalendar.Click
        Dim frmSlct As New frmBookingSelect
        Dim bookToDel As Book

        If bs.Current Is Nothing Then
            Exit Sub
        End If

        Dim books As List(Of Book) = bs.Current.Books

        Dim dayMatch = From book In books
                       Where mclCalendar.SelectionStart.Date <= book.CheckOut And
                               book.CheckIn <= mclCalendar.SelectionEnd.Date

        Dim bookDayMatch As List(Of Book) = dayMatch.ToList()

        If bookDayMatch.Count > 0 Then
            If bookDayMatch.Count = 2 Then
                If mclCalendar.SelectionStart = bookDayMatch.Item(0).CheckIn And
                    mclCalendar.SelectionEnd.Date = bookDayMatch.Item(1).CheckOut Then
                    frmSlct.bookings = bookDayMatch.ToList()

                    If frmSlct.ShowDialog() = DialogResult.Cancel Then
                        Exit Sub
                    Else
                        bookToDel = frmSlct.bookingSelected
                    End If
                Else
                    bookToDel = bookDayMatch.First 'Revisar esto si hay errores
                End If
            Else
                bookToDel = bookDayMatch.First
            End If
        Else
            MsgBox(LocRM.GetString("noBookingToDeleteErrorMsg"), MsgBoxStyle.Information, "Gesalt")
            Exit Sub
        End If

        If bookToDel.Status <> BK_CANCELLED Then
            MsgBox(LocRM.GetString("bookingNotCanceledErrorMsg"), MsgBoxStyle.Exclamation, "Gesalt")
            Exit Sub
        End If

        If MsgBox(LocRM.GetString("rowRemovedBookMsg") & " '" & bookToDel.ToString() & "' " & LocRM.GetString("rowRemovedMsg"),
              MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2,
              LocRM.GetString("rowRemovedTitle")) = MsgBoxResult.No Then
            Exit Sub
        End If

        Dim opBook As OpBook = OpBook.GetInstance()

        If Not opBook.DeleteBook(bookToDel) Then
            MsgBox(LocRM.GetString("opFailedMsg"), MsgBoxStyle.Exclamation, LocRM.GetString("opFailedTitle"))
            Exit Sub
        End If

        bs.Current.Books.Remove(bs.Current.Books.Item(bs.Current.Books.indexOf(bookToDel)))
        Utils.MarkBooksInCalendar(bs.Current.Books, mclCalendar)

        bs.ResetBindings(False)
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

    ''' <summary>
    ''' Actualiza los datos de las imágenes y los arrendadores. Si no hay imágenes, pone una por defecto.
    ''' </summary>
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

    ''' <summary>
    ''' Fuerza el cierre de la ventana de bienvenida de la aplicación.
    ''' </summary>
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

    Private Sub ManageVATToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManageVATToolStripMenuItem.Click
        If bs.Current Is Nothing Then
            Exit Sub
        End If
    End Sub

    Private Sub LegalClassificationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LegalClassificationToolStripMenuItem.Click
        If bs.Current Is Nothing Then
            Exit Sub
        End If

        Dim frmLC As New frmLegalClassification()

        If frmLC.ShowDialog() = DialogResult.Cancel Then
            Exit Sub
        End If

        RefreshData()
    End Sub
End Class