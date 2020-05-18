Imports System.Resources

Public Class frmPropertiesAux
    Public Property editProp As Prop

    Dim propAux As Prop
    Dim opProp As OpProp = OpProp.GetInstance()
    Dim bsPhotos As New BindingSource()
    Dim bsLessors As New BindingSource()
    Dim LocRM As New ResourceManager("Gesalt.WinFormStrings", GetType(frmPropertiesAux).Assembly)

    Private Sub frmPropertiesAux_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim opProp As OpProp = OpProp.GetInstance()

        If editProp IsNot Nothing Then
            Me.Text = LocRM.GetString("editPropTitle")
        Else
            editProp = New Prop()
        End If

        propAux = Utils.DeepClone(editProp)
   
        If propAux.Photos.Count = 0 Then
            pbxPhotos.SizeMode = PictureBoxSizeMode.CenterImage
            pbxPhotos.Image = My.Resources.noImage
            btnDeletePhoto.Enabled = False
        End If

        bsPhotos.DataSource = propAux.Photos

        bsLessors.DataSource = propAux.Lessors

        Dim column As DataGridViewColumn
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

        tbxCadRef.DataBindings.Add("Text", propAux, "CadRef")
        tbxMaxGuests.DataBindings.Add("Text", propAux, "MaxGuests")
        tbxAddress.DataBindings.Add("Text", propAux, "Address")
        tbxCity.DataBindings.Add("Text", propAux, "City")
        tbxBaths.DataBindings.Add("Text", propAux, "Baths")
        pbxPhotos.DataBindings.Add("ImageLocation", bsPhotos, "Path")
        tbxSize.DataBindings.Add("Text", propAux, "Size")
        tbxBedrooms.DataBindings.Add("Text", propAux, "Bedrooms")
        tbxProvince.DataBindings.Add("Text", propAux, "Province")
        tbxZip.DataBindings.Add("Text", propAux, "Zip")
        tbxDescription.DataBindings.Add("Text", propAux, "Description")
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If Not ValidateFields() Then
            Exit Sub
        End If

        editProp = Utils.DeepClone(propAux)
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub bntCancel_Click(sender As Object, e As EventArgs) Handles bntCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnAddPhoto_Click(sender As Object, e As EventArgs) Handles btnAddPhoto.Click
        ofdPhotos.Filter = LocRM.GetString("ofdImageFilter")
        ofdPhotos.FilterIndex = 1
        ofdPhotos.FileName = ""
        ofdPhotos.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyPictures

        If ofdPhotos.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            pbxPhotos.SizeMode = PictureBoxSizeMode.Zoom
            pbxPhotos.Image = Image.FromFile(ofdPhotos.FileName)
            Dim photo As New Photo(0, propAux.Id, ofdPhotos.FileName)
            propAux.Photos.Add(photo)
            If propAux.Photos.Count = 1 Then
                bsPhotos.DataSource = propAux.Photos
            End If
            bsPhotos.ResetBindings(False)
            bsPhotos.Position = bsPhotos.Count - 1
        End If

        If Not btnDeletePhoto.Enabled Then
            btnDeletePhoto.Enabled = True
        End If
    End Sub

    Private Sub btnDeletePhoto_Click(sender As Object, e As EventArgs) Handles btnDeletePhoto.Click
        If bsPhotos.Current.Id <> 0 Then
            opProp.DeletePhoto(bsPhotos.Current)
        End If

        propAux.Photos.Remove(bsPhotos.Current)

        bsPhotos.ResetBindings(False)

        If propAux.Photos.Count = 0 Then
            btnDeletePhoto.Enabled = False
            pbxPhotos.SizeMode = PictureBoxSizeMode.CenterImage
            pbxPhotos.Image = My.Resources.noImage
        End If
    End Sub

    Private Function ValidateFields() As Boolean
        Dim result As Boolean = True
        Dim fieldName As String = ""

        If tbxCadRef.Text.Trim.Length = 0 Then
            fieldName = LocRM.GetString("fieldCadRef")
            result = False
        ElseIf tbxAddress.Text.Trim.Length = 0 Then
            fieldName = LocRM.GetString("fieldAddress")
            result = False
        ElseIf tbxMaxGuests.Text.Trim.Length = 0 Then
            fieldName = LocRM.GetString("fieldMaxGuests")
            result = False
        End If

        If Not result Then
            MsgBox(fieldName & ". " & LocRM.GetString("fieldRequired"), MsgBoxStyle.Exclamation, "Gesalt")
        End If

        Return result
    End Function

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
        bsPhotos.Position = propAux.Photos.Count - 1
    End Sub

    Private Sub pbxPhotos_Click(sender As Object, e As EventArgs) Handles pbxPhotos.Click
        If bsPhotos.Count = 0 Then
            Exit Sub
        End If

        Dim frmPV = New frmPictureViewer()
        frmPV.photos = bsPhotos.List
        frmPV.index = bsPhotos.Position
        frmPV.ShowDialog()
    End Sub

    Private Sub btnAddLessor_Click(sender As Object, e As EventArgs) Handles btnAddLessor.Click
        Dim frmLP = New frmLessorProp With {
            .editLessorProp = Nothing
        }

        Dim opLessor As OpLessor = OpLessor.GetInstance()
        If opLessor.GetAllLessors().Count = 0 Then
            MsgBox(LocRM.GetString("noLessorsErrorMsg"), MsgBoxStyle.Exclamation, "Gesalt")
            Exit Sub
        End If

        If frmLP.ShowDialog() = DialogResult.Cancel Then
            Exit Sub
        End If

        If Not ValidateEquality(frmLP.editLessorProp) Then
            MsgBox(LocRM.GetString("lpEqualsError"), MsgBoxStyle.Exclamation, "Gesalt")
            Exit Sub
        End If

        If Not ValidatePercent(frmLP.editLessorProp.Percentage) Then
            MsgBox(LocRM.GetString("percentError"), MsgBoxStyle.Exclamation, "Gesalt")
            Exit Sub
        End If

        Dim lp As LessorProp = New LessorProp(frmLP.editLessorProp.Lessor, frmLP.editLessorProp.Percentage)
        propAux.Lessors.Add(lp)
        bsLessors.ResetBindings(False)
    End Sub

    Private Sub bntDeleteLessor_Click(sender As Object, e As EventArgs) Handles bntDeleteLessor.Click
        If bsLessors.Current Is Nothing Then
            Exit Sub
        End If

        If MsgBox(LocRM.GetString("lpRemovedMsg"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton1, "Gesalt") = MsgBoxResult.No Then
            Exit Sub
        End If

        propAux.Lessors.Remove(bsLessors.Current)
        bsLessors.ResetBindings(False)
    End Sub

    Private Sub btnEditLessor_Click(sender As Object, e As EventArgs) Handles btnEditLessor.Click, dgvLessors.DoubleClick
        If bsLessors.Current Is Nothing Then
            Exit Sub
        End If

        Dim frmLP = New frmLessorProp With {
            .editLessorProp = bsLessors.Current
        }

        If frmLP.ShowDialog() = DialogResult.Cancel Then
            Exit Sub
        End If

        Dim percentAux As Decimal = bsLessors.Current.Percentage
        bsLessors.Current.Percentage = frmLP.editLessorProp.Percentage

        If Not ValidatePercent() Then
            bsLessors.Current.Percentage = percentAux
            MsgBox(LocRM.GetString("percentError"), MsgBoxStyle.Exclamation, "Gesalt")
            Exit Sub
        End If

        bsLessors.ResetBindings(False)
    End Sub

    Private Function ValidatePercent(Optional newPercentage As Decimal = 0) As Boolean
        Dim percentTotal As Decimal = 0
        For Each lessor As LessorProp In propAux.Lessors
            percentTotal += lessor.Percentage
        Next

        If percentTotal + newPercentage > 100 Then
            Return False
        End If

        Return True
    End Function

    Private Function ValidateEquality(lp As LessorProp) As Boolean
        For Each lessor As LessorProp In propAux.Lessors
            If lp.Equals(lessor) Then
                Return False
            End If
        Next

        Return True
    End Function
End Class