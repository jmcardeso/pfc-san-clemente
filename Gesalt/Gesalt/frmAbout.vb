﻿Imports System.Resources

Public NotInheritable Class frmAbout

    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim LocRM As New ResourceManager("Gesalt.WinFormStrings", GetType(frmAbout).Assembly)
        ' Establezca el título del formulario.
        'Dim ApplicationTitle As String
        'If My.Application.Info.Title <> "" Then
        '    ApplicationTitle = My.Application.Info.Title
        'Else
        '    ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        'End If
        'Me.Text = String.Format("Acerca de {0}", ApplicationTitle)
        ' Inicialice todo el texto mostrado en el cuadro Acerca de.
        ' TODO: personalice la información del ensamblado de la aplicación en el panel "Aplicación" del 
        '    cuadro de diálogo propiedades del proyecto (bajo el menú "Proyecto").
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
