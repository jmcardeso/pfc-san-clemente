Imports System.Resources

Public Class frmLessorsAux
    Public Property editLessor As Lessor
    Dim lessorAux As Lessor
    Dim LocRM As New ResourceManager("Gesalt.WinFormStrings", GetType(frmLessorsAux).Assembly)

    Private Sub frmLessorsAux_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim opLessor As OpLessor = OpLessor.GetInstance()
        Dim types As New List(Of String)

        If editLessor IsNot Nothing Then
            Me.Text = LocRM.GetString("editLessorTitle")
        Else
            editLessor = New Lessor()
        End If

        lessorAux = Utils.DeepClone(editLessor)

        types = opLessor.GetLessorsType()
        For Each t As String In types
            cbxType.Items.Add(t)
        Next

        tbxLastName.DataBindings.Add("Text", lessorAux, "LastName")
        tbxFirstName.DataBindings.Add("Text", lessorAux, "FirstName")
        tbxAddress.DataBindings.Add("Text", lessorAux, "Address")
        tbxCity.DataBindings.Add("Text", lessorAux, "City")
        tbxEmail.DataBindings.Add("Text", lessorAux, "Email")
        pbxLogo.DataBindings.Add("ImageLocation", lessorAux, "PathLogo")
        tbxNif.DataBindings.Add("Text", lessorAux, "Nif")
        tbxPhone.DataBindings.Add("Text", lessorAux, "Phone")
        tbxProvince.DataBindings.Add("Text", lessorAux, "Province")
        cbxType.DataBindings.Add("Text", lessorAux, "Type")
        tbxZip.DataBindings.Add("Text", lessorAux, "Zip")

        If lessorAux.PathLogo.Length = 0 Then
            pbxLogo.SizeMode = PictureBoxSizeMode.CenterImage
            pbxLogo.Image = My.Resources.noImage
        End If
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If Not ValidateFields() Then
            Exit Sub
        End If

        editLessor = Utils.DeepClone(lessorAux)
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub bntCancel_Click(sender As Object, e As EventArgs) Handles bntCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnAddLogo_Click(sender As Object, e As EventArgs) Handles btnAddLogo.Click
        ofdLogo.Filter = LocRM.GetString("ofdImageFilter")
        ofdLogo.FilterIndex = 1
        ofdLogo.FileName = ""
        ofdLogo.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyPictures

        If ofdLogo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            pbxLogo.SizeMode = PictureBoxSizeMode.Zoom
            pbxLogo.Image = Image.FromFile(ofdLogo.FileName)
            lessorAux.PathLogo = ofdLogo.FileName
        End If
    End Sub

    Private Sub bntDeleteLogo_Click(sender As Object, e As EventArgs) Handles bntDeleteLogo.Click
        pbxLogo.SizeMode = PictureBoxSizeMode.CenterImage
        pbxLogo.Image = My.Resources.noImage
        lessorAux.PathLogo = ""
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