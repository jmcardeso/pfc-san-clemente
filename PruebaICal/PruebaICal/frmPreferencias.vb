Imports System.Configuration
Imports System.Resources
Imports MySql.Data.MySqlClient

Public Class frmPreferencias
    Public Property CambioIdioma() As Boolean
    Dim strIdioma As String = ""
    Dim LocRM As New ResourceManager("PruebaICal.WinFormStrings", GetType(frmPreferencias).Assembly)

    Private Sub frmPreferencias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Select Case My.Settings.language
            Case "en"
                rbEnglish.Checked = True
            Case "es"
                rbSpanish.Checked = True
            Case "gl"
                rbGalician.Checked = True
        End Select

        cbxSSH.Checked = My.Settings.ssh
        LoadMySQLConnectionStringData()
    End Sub

    Private Sub LoadMySQLConnectionStringData()
        Dim con As Connection = Connection.getInstance()
        Dim cs As ConnectionStringSettings = con.GetMySQLConnectionString()

        If cs Is Nothing Then
            MsgBox(LocRM.GetString("csNotFound"), MsgBoxStyle.Exclamation, LocRM.GetString("msgTitle"))
            Exit Sub
        End If

        Dim csBuilder As New MySqlConnectionStringBuilder(cs.ConnectionString)

        tbxUser.Text = csBuilder.UserID
        tbxPass.Text = csBuilder.Password
        tbxServer.Text = csBuilder.Server
        nudPort.Value = csBuilder.Port

        If cbxSSH.Checked Then
            tbxSSHHost.Text = csBuilder.SshHostName
            nudSSHPort.Value = csBuilder.SshPort
            tbxSSHName.Text = csBuilder.SshUserName
            tbxSSHPass.Text = csBuilder.SshPassword
        End If
    End Sub

    Private Sub SaveMySQLConnectionStringData()
        Dim con As Connection = Connection.getInstance()
        Dim cs As ConnectionStringSettings = con.GetMySQLConnectionString()

        Dim csBuilder As New MySqlConnectionStringBuilder() With {
            .UserID = tbxUser.Text,
            .Password = tbxPass.Text,
            .Server = tbxServer.Text,
            .Port = nudPort.Value,
            .Database = MYSQL_DATABASE
        }

        If cbxSSH.Checked Then
            csBuilder.SshHostName = tbxSSHHost.Text
            csBuilder.SshPort = nudSSHPort.Value
            csBuilder.SshUserName = tbxSSHName.Text
            csBuilder.SshPassword = tbxSSHPass.Text
        End If

        If cs Is Nothing Then
            con.AddConnectionString(MYSQL_CS_NAME, csBuilder.ConnectionString, MYSQL_PROVIDER_NAME)
        Else
            con.EditConnectionString(MYSQL_CS_NAME, csBuilder.ConnectionString, MYSQL_PROVIDER_NAME)
        End If
    End Sub

    Private Sub SSHControls(ssh As Boolean)
        lblHostName.Enabled = ssh
        lblSSHPassword.Enabled = ssh
        lblSSHPort.Enabled = ssh
        lblUserName.Enabled = ssh

        tbxSSHHost.Enabled = ssh
        tbxSSHName.Enabled = ssh
        nudSSHPort.Enabled = ssh
        tbxSSHPass.Enabled = ssh
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

        CambioIdioma = IIf(strIdioma.Equals(My.Settings.language), False, True)
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        My.Settings.language = strIdioma
        My.Settings.ssh = cbxSSH.Checked
        My.Settings.Save()
        SaveMySQLConnectionStringData()
        Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        CambioIdioma = False
        Close()
    End Sub

    Private Sub cbxSSH_CheckedChanged(sender As Object, e As EventArgs) Handles cbxSSH.CheckedChanged
        SSHControls(cbxSSH.Checked)
    End Sub

    Private Sub btnTestCon_Click(sender As Object, e As EventArgs) Handles btnTestCon.Click
        Dim con As Connection = Connection.getInstance()

        Dim csBuilder As New MySqlConnectionStringBuilder() With {
            .UserID = tbxUser.Text,
            .Password = tbxPass.Text,
            .Server = tbxServer.Text,
            .Port = nudPort.Value,
            .Database = MYSQL_DATABASE
        }

        If cbxSSH.Checked Then
            csBuilder.SshHostName = tbxSSHHost.Text
            csBuilder.SshPort = nudSSHPort.Value
            csBuilder.SshUserName = tbxSSHName.Text
            csBuilder.SshPassword = tbxSSHPass.Text
        End If

        If con.Open(csBuilder) Is Nothing Then
            MsgBox(LocRM.GetString("conError"), MsgBoxStyle.Exclamation, LocRM.GetString("msgTitle"))
        Else
            MsgBox(LocRM.GetString("conOK"), MsgBoxStyle.Information, LocRM.GetString("msgTitle"))
            con.Close()
        End If
    End Sub
End Class