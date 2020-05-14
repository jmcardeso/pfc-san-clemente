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

        tbxLastName.DataBindings.Add("Text", GuestAux, "LastName")
        tbxFirstName.DataBindings.Add("Text", GuestAux, "FirstName")
        tbxAddress.DataBindings.Add("Text", GuestAux, "Address")
        tbxCity.DataBindings.Add("Text", GuestAux, "City")
        tbxEmail.DataBindings.Add("Text", GuestAux, "Email")
        tbxNif.DataBindings.Add("Text", GuestAux, "Nif")
        tbxPhone.DataBindings.Add("Text", GuestAux, "Phone")
        tbxProvince.DataBindings.Add("Text", GuestAux, "Province")
        lblRating.DataBindings.Add("Text", GuestAux, "Rating")
        tbxZip.DataBindings.Add("Text", GuestAux, "Zip")
        tbxComments.DataBindings.Add("Text", GuestAux, "Comments")
        cbxAcceptAd.DataBindings.Add("Checked", GuestAux, "AcceptAd")
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

    Private Function ValidateFields() As Boolean
        Dim result As Boolean = True
        Dim fieldName As String = ""

        If tbxLastName.Text.Trim.Length = 0 Then
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

    Private Sub lblRating_TextChanged(sender As Object, e As EventArgs) Handles lblRating.TextChanged
        For Each star As PictureBox In pnlRating.Controls
            star.Image = My.Resources.star_off
            If star.Name.Last <= lblRating.Text Then
                star.Image = My.Resources.star_on
            End If
        Next
    End Sub

    Private Sub Rating_MouseEnter(sender As PictureBox, e As EventArgs) Handles pbxRating1.MouseEnter, pbxRating2.MouseEnter,
            pbxRating3.MouseEnter, pbxRating4.MouseEnter, pbxRating5.MouseEnter
        For Each star As PictureBox In pnlRating.Controls
            If star.Name.Last <= sender.Name.Last Then
                star.Image = My.Resources.star_on
            Else
                star.Image = My.Resources.star_off
            End If
        Next
    End Sub

    Private Sub Rating_MouseLeave(sender As PictureBox, e As EventArgs) Handles pbxRating1.MouseLeave, pbxRating2.MouseLeave,
            pbxRating3.MouseLeave, pbxRating4.MouseLeave, pbxRating5.MouseLeave
        lblRating_TextChanged(Nothing, Nothing)
    End Sub

    Private Sub Rating_Click(sender As PictureBox, e As EventArgs) Handles pbxRating1.Click, pbxRating2.Click, pbxRating3.Click,
            pbxRating4.Click, pbxRating5.Click
        GuestAux.Rating = Val(sender.Name.Last)
        lblRating.Text = sender.Name.Last
    End Sub
End Class