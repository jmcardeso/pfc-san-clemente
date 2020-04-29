﻿Imports System.ComponentModel
Imports System.Configuration
Imports System.Resources
Imports MySql.Data.MySqlClient

Public Class frmSettings
    Public Property LanguageChanged() As Boolean

    Dim strLanguage As String = ""
    Dim strDBType As String = ""
    Dim accept As Boolean = False
    Dim LocRM As New ResourceManager("Gesalt.WinFormStrings", GetType(frmSettings).Assembly)

    Private Sub frmPreferencias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Select Case My.Settings.language
            Case "en"
                rbEnglish.Checked = True
            Case "es"
                rbSpanish.Checked = True
            Case "gl"
                rbGalician.Checked = True
        End Select

        ' Ajustamos la posición de la etiqueta de conexión al servidor al ancho del texto (diferente para cada idioma)
        lblServerSettings.Location = New Point((pnlConnection.Size.Width - lblServerSettings.Size.Width) / 2, lblServerSettings.Location.Y)

        If My.Settings.dbType.Equals("local") Then
            rbLocal.Checked = True
            strDBType = "local"
        ElseIf My.Settings.dbType.Equals("remote") Then
            rbServer.Checked = True
            strDBType = "remote"
        End If

        cbxSSH.Checked = My.Settings.ssh
        EnabledServerSettings(rbServer.Checked)

        If My.Settings.dbType.Equals("remote") Then
            LoadMySQLConnectionStringData()
        End If
    End Sub

    Private Sub frmPreferencias_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If Not accept Then
            If strDBType.Equals("") OrElse My.Settings.appStatus.Equals("first_start") OrElse My.Settings.appStatus.Equals("dbError") Then
                e.Cancel = True
                Environment.Exit(1)
            End If
        End If
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim changeDBType As Boolean = False
        Dim changeDBSettings As Boolean = False

        accept = True

        If strDBType.Equals("") Then
            MsgBox(LocRM.GetString("noDBMsg"), MsgBoxStyle.Exclamation, LocRM.GetString("msgTitle"))
            Exit Sub
        End If

        If Not strDBType.Equals(My.Settings.dbType) Then
            changeDBType = True
        End If

        If strDBType.Equals("remote") AndAlso Not changeDBType Then
            Dim con As Connection = Connection.getInstance()
            Dim cs As ConnectionStringSettings = con.GetMySQLConnectionString()
            Dim csbOld As MySqlConnectionStringBuilder = New MySqlConnectionStringBuilder(cs.ConnectionString)

            If Not csbOld.UserID.Equals(tbxUser.Text) OrElse Not csbOld.Password.Equals(tbxPass.Text) OrElse
                Not csbOld.Server.Equals(tbxServer.Text) OrElse csbOld.Port <> nudPort.Value Then
                changeDBSettings = True
            End If

            If My.Settings.ssh <> cbxSSH.Checked Then
                changeDBSettings = True
            End If

            If Not changeDBSettings Then
                If Not csbOld.SshHostName.Equals(tbxSSHHost.Text) OrElse csbOld.SshPort <> nudSSHPort.Value OrElse
                    Not csbOld.SshUserName.Equals(tbxSSHName.Text) OrElse Not csbOld.SshPassword.Equals(tbxSSHPass.Text) Then
                    changeDBSettings = True
                End If
            End If
        End If

        If changeDBType And Not My.Settings.appStatus.Equals("first_start") AndAlso MsgBox(LocRM.GetString("dbChange"), MsgBoxStyle.OkCancel Or MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Question, LocRM.GetString("dbChangeTitle")) = MsgBoxResult.Cancel Then
            Exit Sub
        End If

        If changeDBSettings AndAlso MsgBox(LocRM.GetString("dbSettingsChange"), MsgBoxStyle.OkCancel Or MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Question, LocRM.GetString("dbSettingsChangeTitle")) = MsgBoxResult.Cancel Then
            Exit Sub
        End If

        My.Settings.dbType = strDBType
        My.Settings.language = strLanguage

        ' Si se elige un servidor, guarda la cadena de conexión
        If strDBType.Equals("remote") Then
            My.Settings.ssh = cbxSSH.Checked
            SaveMySQLConnectionStringData()
        Else
            My.Settings.ssh = False
        End If

        My.Settings.Save()

        ' Si no entró como asistente, es decir, si es el usuario quien fuerza el cambio de SGBD, sale de la aplicación
        If (changeDBSettings Or changeDBType) And Not My.Settings.appStatus.Equals("first_start") Then
            Environment.Exit(0)
        End If

        My.Settings.appStatus = "ok"
        My.Settings.Save()

        Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub btnTestCon_Click(sender As Object, e As EventArgs) Handles btnTestCon.Click
        Dim con As MySqlConnection = New MySqlConnection(buildMySQLConnectionString.ConnectionString)
        Try
            con.Open()
            MsgBox(LocRM.GetString("conOK"), MsgBoxStyle.Information, LocRM.GetString("msgTitle"))
        Catch err As Exception
            MsgBox(LocRM.GetString("conError"), MsgBoxStyle.Exclamation, LocRM.GetString("msgTitle"))
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub rbDBType_CheckedChanged(sender As Object, e As EventArgs) Handles rbLocal.CheckedChanged, rbServer.CheckedChanged
        If rbLocal.Checked Then
            strDBType = "local"
            EnabledServerSettings(False)
        Else
            strDBType = "remote"
            EnabledServerSettings(True)
        End If
    End Sub

    Private Sub cbxSSH_CheckedChanged(sender As Object, e As EventArgs) Handles cbxSSH.CheckedChanged
        SSHControls(cbxSSH.Checked)
    End Sub

    Private Sub rbLanguage_CheckedChanged(sender As RadioButton, e As EventArgs) Handles rbEnglish.CheckedChanged, rbGalician.CheckedChanged, rbSpanish.CheckedChanged
        For Each control As Control In tbpLanguage.Controls
            If control.Name.StartsWith("rb") Then
                Dim rb As RadioButton = CType(control, RadioButton)
                If rb.Checked = True Then
                    Select Case rb.Name
                        Case "rbEnglish"
                            strLanguage = "en"
                        Case "rbGalician"
                            strLanguage = "gl"
                        Case "rbSpanish"
                            strLanguage = "es"
                    End Select
                    Exit For
                End If
            End If
        Next

        LanguageChanged = IIf(strLanguage.Equals(My.Settings.language), False, True)
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

    Private Function buildMySQLConnectionString() As MySqlConnectionStringBuilder
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

        Return csBuilder
    End Function

    Private Sub EnabledServerSettings(opt As Boolean)
        lblServerSettings.Enabled = opt
        lblUser.Enabled = opt
        lblPass.Enabled = opt
        lblServer.Enabled = opt
        lblPort.Enabled = opt

        tbxUser.Enabled = opt
        tbxPass.Enabled = opt
        tbxServer.Enabled = opt
        nudPort.Enabled = opt

        btnTestCon.Enabled = opt

        cbxSSH.Enabled = opt

        If Not opt OrElse Not cbxSSH.Checked Then
            SSHControls(False)
        Else
            SSHControls(True)
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
End Class