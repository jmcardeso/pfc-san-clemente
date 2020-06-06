Imports System.Resources

Public NotInheritable Class frmAbout

    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim LocRM As New ResourceManager("Gesalt.WinFormStrings", GetType(frmAbout).Assembly)

        Me.LabelProductName.Text = My.Application.Info.ProductName
        Me.LabelVersion.Text = String.Format(LocRM.GetString("aboutVersion"), My.Application.Info.Version.ToString)
        Me.LabelCopyright.Text = My.Application.Info.Copyright
        Me.LabelCompanyName.Text = My.Application.Info.CompanyName
        Me.TextBoxDescription.Text = LocRM.GetString("aboutDesc1") & vbNewLine &
            LocRM.GetString("aboutDesc2") & vbNewLine &
            LocRM.GetString("aboutDesc3") & vbNewLine &
            LocRM.GetString("aboutDesc4") & vbNewLine &
            vbNewLine & LocRM.GetString("aboutDesc5") & vbNewLine &
            LocRM.GetString("aboutDesc6") & vbNewLine &
            LocRM.GetString("aboutDesc7")
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

End Class
