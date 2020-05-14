Imports System.Resources

Public Class frmPropertiesAux
    Public Property editProp As Prop
    Dim propAux As Prop
    Dim LocRM As New ResourceManager("Gesalt.WinFormStrings", GetType(frmPropertiesAux).Assembly)

    Private Sub frmPropertiesAux_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim opProp As OpProp = OpProp.GetInstance()

        If editProp IsNot Nothing Then
            Me.Text = LocRM.GetString("editPropTitle")
        Else
            editProp = New Prop()
        End If

        propAux = Utils.DeepClone(editProp)

        tbxCadRef.DataBindings.Add("Text", propAux, "LastName")
        tbxMaxGuests.DataBindings.Add("Text", propAux, "FirstName")
        tbxAddress.DataBindings.Add("Text", propAux, "Address")
        tbxCity.DataBindings.Add("Text", propAux, "City")
        tbxBaths.DataBindings.Add("Text", propAux, "Email")
        pbxPhotos.DataBindings.Add("ImageLocation", propAux, "PathLogo")
        tbxSize.DataBindings.Add("Text", propAux, "Nif")
        tbxBedrooms.DataBindings.Add("Text", propAux, "Phone")
        tbxProvince.DataBindings.Add("Text", propAux, "Province")
        tbxZip.DataBindings.Add("Text", propAux, "Zip")
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

    Private Sub btnAddLogo_Click(sender As Object, e As EventArgs) Handles btnAddPhoto.Click
        ofdPhotos.Filter = LocRM.GetString("ofdLogoFilter")
        ofdPhotos.FilterIndex = 1
        ofdPhotos.FileName = ""
        ofdPhotos.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyPictures

        If ofdPhotos.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            pbxPhotos.Image = Image.FromFile(ofdPhotos.FileName)
            ' propAux.PathLogo = ofdPhotos.FileName
        End If
    End Sub

    Private Function ValidateFields() As Boolean
        Dim result As Boolean = True
        Dim fieldName As String = ""

        If tbxCadRef.Text.Trim.Length = 0 Then
            fieldName = LocRM.GetString("fieldLastName")
            result = False
        ElseIf tbxMaxGuests.Text.Trim.Length = 0 Then
            fieldName = LocRM.GetString("fieldFirstName")
            result = False
        ElseIf tbxSize.Text.Trim.Length = 0 Then
            fieldName = LocRM.GetString("fieldNif")
            result = False
        End If

        If Not result Then
            MsgBox(fieldName & ". " & LocRM.GetString("fieldRequired"), MsgBoxStyle.Exclamation, "Gesalt")
        End If

        Return result
    End Function
End Class