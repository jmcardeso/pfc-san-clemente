Imports System.Resources

Public Class frmPropertiesAux
    Public Property editProp As Prop
    Dim propAux As Prop
    Dim opProp As OpProp = OpProp.GetInstance()
    Dim bs As New BindingSource()
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

        bs.DataSource = propAux.Photos

        tbxCadRef.DataBindings.Add("Text", propAux, "CadRef")
        tbxMaxGuests.DataBindings.Add("Text", propAux, "MaxGuests")
        tbxAddress.DataBindings.Add("Text", propAux, "Address")
        tbxCity.DataBindings.Add("Text", propAux, "City")
        tbxBaths.DataBindings.Add("Text", propAux, "Baths")
        pbxPhotos.DataBindings.Add("ImageLocation", bs, "Path")
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
                bs.DataSource = propAux.Photos
            End If
            bs.ResetBindings(False)
            bs.Position = bs.Count - 1
        End If

        If Not btnDeletePhoto.Enabled Then
            btnDeletePhoto.Enabled = True
        End If
    End Sub

    Private Sub btnDeletePhoto_Click(sender As Object, e As EventArgs) Handles btnDeletePhoto.Click
        If bs.Current.Id <> 0 Then
            opProp.DeletePhoto(bs.Current)
        End If

        propAux.Photos.Remove(bs.Current)

        bs.ResetBindings(False)

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
        bs.Position = 0
    End Sub

    Private Sub btnPhotosPrevious_Click(sender As Object, e As EventArgs) Handles btnPhotosPrevious.Click
        bs.Position -= 1
    End Sub

    Private Sub btnPhotosNext_Click(sender As Object, e As EventArgs) Handles btnPhotosNext.Click
        bs.Position += 1
    End Sub

    Private Sub btnPhotosLast_Click(sender As Object, e As EventArgs) Handles btnPhotosLast.Click
        bs.Position = propAux.Photos.Count - 1
    End Sub

    Private Sub pbxPhotos_Click(sender As Object, e As EventArgs) Handles pbxPhotos.Click
        If bs.Count = 0 Then
            Exit Sub
        End If

        Dim frmPV = New frmPictureViewer()
        frmPV.photos = bs.List
        frmPV.index = bs.Position
        frmPV.ShowDialog()
    End Sub
End Class