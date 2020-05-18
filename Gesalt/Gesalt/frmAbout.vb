Imports System.Resources

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
        Me.TextBoxDescription.Text = "Este programa es software libre: puedes redistribuirlo y/o modificarlo bajo los términos de la Licencia General Pública de GNU publicada por la Free Software Foundation, ya sea la versión 3 de la Licencia, o (a tu elección) cualquier versión posterior." & vbNewLine &
            "Este programa se distribuye con la esperanza de que sea útil pero SIN NINGUNA GARANTÍA; incluso sin la garantía implícita de MERCANTIBILIDAD o CALIFICADA PARA UN PROPÓSITO EN PARTICULAR." & vbNewLine &
            "Lee la Licencia General Pública de GNU para más detalles." & vbNewLine &
            "Has debido de recibir una copia de la Licencia General Pública de GNU junto con este programa. Si no, ve a http://www.gnu.org/licenses/." & vbNewLine &
            vbNewLine & "Icono de la aplicación diseñado por Payungkead de Flaticon" & vbNewLine &
            "Iconos de estrellas para valoración de clientes de iconsDB - CC0 1.0 Universal (CC0 1.0) Public Domain Dedication."
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

End Class
