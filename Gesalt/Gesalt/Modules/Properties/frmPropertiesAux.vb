﻿Imports System.Resources

Public Class frmPropertiesAux
    Public Property editProp As Prop

    Dim propAux As Prop
    Dim opProp As OpProp
    Dim bsPhotos As New BindingSource()
    Dim bsLessors As New BindingSource()
    Dim legalClasses As New List(Of LegalClassification)
    Dim LocRM As New ResourceManager("Gesalt.WinFormStrings", GetType(frmPropertiesAux).Assembly)
    Dim isEdited As Boolean = False

    Private Sub frmPropertiesAux_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        opProp = OpProp.GetInstance()
        legalClasses = opProp.GetLegalClasses()
        cbxLegalClass.DataSource = legalClasses

        If editProp IsNot Nothing Then
            Me.Text = LocRM.GetString("editPropTitle")
            isEdited = True

            If legalClasses.Count = 0 Then
                cbxLegalClass.SelectedIndex = 0
            Else
                Dim thisLegalClass = From lc In legalClasses Where lc.Id = editProp.PropClass.ClassId
                cbxLegalClass.SelectedItem = thisLegalClass.First
            End If
        Else
            editProp = New Prop()
            cbxLegalClass.SelectedIndex = 0
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
        tbxVat.DataBindings.Add("Text", propAux, "PropClass.VAT")
        tbxKeys.DataBindings.Add("Text", propAux, "PropClass.Keys")
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If Not ValidateFields() Then
            Exit Sub
        End If

        propAux.PropClass.ClassId = CType(cbxLegalClass.SelectedItem, LegalClassification).Id

        If isEdited Then
            If editProp.PropClass.ClassId <> propAux.PropClass.ClassId Then
                If MsgBox(LocRM.GetString("legalClassChangedMsg"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2, "Gesalt") = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If

            Dim pcAux As PropClass = New PropClass(0, propAux.PropClass.PropId, propAux.PropClass.ClassId,
                                     Now.Date(), propAux.PropClass.Keys, propAux.PropClass.VAT)
            pcAux.LegalClass = opProp.GetLegalClassById(pcAux.ClassId)

            If opProp.AddPropClass(pcAux) < 1 Then
                MsgBox(LocRM.GetString("opFailedMsg"), MsgBoxStyle.Exclamation, LocRM.GetString("opFailedTitle"))
                Exit Sub
            End If

            propAux.PropClass = pcAux
        Else
            propAux.PropClass.LegalClass = opProp.GetLegalClassById(propAux.PropClass.ClassId)
        End If

        editProp = Utils.DeepClone(propAux)
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub bntCancel_Click(sender As Object, e As EventArgs) Handles bntCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

#Region "Photo"

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

#End Region

#Region "Lessor"

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

#End Region

#Region "Validators"

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

#End Region

End Class