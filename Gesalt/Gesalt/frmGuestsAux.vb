Imports System.Resources

Public Class frmGuestsAux
    Public Property editGuest As Guest
    Dim GuestAux As Guest
    Dim LocRM As New ResourceManager("Gesalt.WinFormStrings", GetType(frmGuestsAux).Assembly)

    Private Sub frmGuestsAux_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim opGuest As OpGuest = OpGuest.GetInstance()
        Dim types As New List(Of String)

        If editGuest IsNot Nothing Then
            Me.Text = LocRM.GetString("editGuestTitle")
        Else
            editGuest = New Guest()
        End If

        GuestAux = Utils.DeepClone(editGuest)

        types = opGuest.GetGuestsType()
        For Each t As String In types
            cbxType.Items.Add(t)
        Next

        tbxLastName.DataBindings.Add("Text", GuestAux, "LastName")
        tbxFirstName.DataBindings.Add("Text", GuestAux, "FirstName")
        tbxAddress.DataBindings.Add("Text", GuestAux, "Address")
        tbxCity.DataBindings.Add("Text", GuestAux, "City")
        tbxEmail.DataBindings.Add("Text", GuestAux, "Email")
        pbxLogo.DataBindings.Add("ImageLocation", GuestAux, "PathLogo")
        tbxNif.DataBindings.Add("Text", GuestAux, "Nif")
        tbxPhone.DataBindings.Add("Text", GuestAux, "Phone")
        tbxProvince.DataBindings.Add("Text", GuestAux, "Province")
        cbxType.DataBindings.Add("Text", GuestAux, "Type")
        tbxZip.DataBindings.Add("Text", GuestAux, "Zip")
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If Not ValidateFields() Then
            Exit Sub
        End If

        editGuest = Utils.DeepClone(GuestAux)
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
            GuestAux.PathLogo = ofdLogo.FileName
        End If
    End Sub

    Private Function ValidateFields() As Boolean
        Dim result As Boolean = True
        Dim fieldName As String = ""

        If cbxType.Text.Trim.Length = 0 Then
            fieldName = LocRM.GetString("fieldType")
            result = False
        ElseIf tbxLastName.Text.Trim.Length = 0 Then
            fieldName = LocRM.GetString("fieldLastName")
            result = False
        ElseIf tbxFirstName.Text.Trim.Length = 0 Then
            fieldName = LocRM.GetString("fieldFirstName")
            result = False
        ElseIf tbxNif.Text.Trim.Length = 0 Then
            fieldName = LocRM.GetString("fieldNif")
            result = False
        End If

        If Not result Then
            MsgBox(fieldName & ". " & LocRM.GetString("fieldRequired"), MsgBoxStyle.Exclamation, "Gesalt")
        End If

        Return result
    End Function
End Class