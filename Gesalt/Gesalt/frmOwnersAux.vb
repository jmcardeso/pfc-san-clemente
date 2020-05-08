Imports System.Resources

Public Class frmOwnersAux
    Public Property editOwner As Owner
    Dim ownerAux As Owner
    Dim LocRM As New ResourceManager("Gesalt.WinFormStrings", GetType(frmOwnersAux).Assembly)

    Private Sub frmOwnersAux_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If editOwner IsNot Nothing Then
            ownerAux = Utils.DeepClone(editOwner)
            Me.Text = LocRM.GetString("editOwnerTitle")
        Else

        End If

        tbxLastName.DataBindings.Add("Text", ownerAux, "LastName")
        tbxFirstName.DataBindings.Add("Text", ownerAux, "FirstName")
        tbxAddress.DataBindings.Add("Text", ownerAux, "Address")
        tbxCity.DataBindings.Add("Text", ownerAux, "City")
        tbxEmail.DataBindings.Add("Text", ownerAux, "Email")
        tbxLogo.DataBindings.Add("Text", ownerAux, "PathLogo")
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
End Class