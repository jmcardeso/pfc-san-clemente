Imports System.Resources

Public Class frmOwnersAux
    Public Property editOwner As Owner
    Dim ownerAux As Owner
    Dim LocRM As New ResourceManager("Gesalt.WinFormStrings", GetType(frmOwnersAux).Assembly)

    Private Sub frmOwnersAux_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If editOwner IsNot Nothing Then
            Me.Text = LocRM.GetString("editOwnerTitle")
        Else
            editOwner = New Owner()
        End If

        ownerAux = Utils.DeepClone(editOwner)

        tbxLastName.DataBindings.Add("Text", ownerAux, "LastName")
        tbxFirstName.DataBindings.Add("Text", ownerAux, "FirstName")
        tbxAddress.DataBindings.Add("Text", ownerAux, "Address")
        tbxCity.DataBindings.Add("Text", ownerAux, "City")
        tbxEmail.DataBindings.Add("Text", ownerAux, "Email")
        pbxLogo.DataBindings.Add("ImageLocation", ownerAux, "PathLogo")
        tbxNif.DataBindings.Add("Text", ownerAux, "Nif")
        tbxPhone.DataBindings.Add("Text", ownerAux, "Phone")
        tbxProvince.DataBindings.Add("Text", ownerAux, "Province")
        tbxType.DataBindings.Add("Text", ownerAux, "Type")
        tbxZip.DataBindings.Add("Text", ownerAux, "Zip")
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        editOwner = Utils.DeepClone(ownerAux)
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub bntCancel_Click(sender As Object, e As EventArgs) Handles bntCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnAddLogo_Click(sender As Object, e As EventArgs) Handles btnAddLogo.Click
        ofdLogo.Filter = LocRM.GetString("ofdLogoFilter")
        ofdLogo.FilterIndex = 1
        ofdLogo.FileName = ""
        ofdLogo.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyPictures

        If ofdLogo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            pbxLogo.Image = Image.FromFile(ofdLogo.FileName)
            ownerAux.PathLogo = ofdLogo.FileName
        End If
    End Sub
End Class