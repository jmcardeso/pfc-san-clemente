Public Class frmPreferencias
    Public Property CambioIdioma() As Boolean
    Dim strIdioma As String = ""

    Private Sub frmPreferencias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Select Case My.Settings.idioma
            Case "en"
                rbEnglish.Checked = True
            Case "es"
                rbSpanish.Checked = True
            Case "gl"
                rbGalician.Checked = True
        End Select
    End Sub

    Private Sub rbDefecto_CheckedChanged(sender As RadioButton, e As EventArgs) Handles rbEnglish.CheckedChanged, rbGalician.CheckedChanged, rbSpanish.CheckedChanged

        For Each control As Control In tbpLanguage.Controls
            If control.Name.StartsWith("rb") Then
                Dim rb As RadioButton = CType(control, RadioButton)
                If rb.Checked = True Then
                    Select Case rb.Name
                        Case "rbEnglish"
                            strIdioma = "en"
                        Case "rbGalician"
                            strIdioma = "gl"
                        Case "rbSpanish"
                            strIdioma = "es"
                    End Select
                    Exit For
                End If
            End If
        Next

        If Not strIdioma.Equals(My.Settings.idioma) Then
            CambioIdioma = True
        End If
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        My.Settings.idioma = strIdioma
        My.Settings.Save()
        Close()
    End Sub
End Class