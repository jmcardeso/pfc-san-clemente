Imports System.Net
Imports System.Net.Mail
Imports System.Resources

Public Class frmMail
    Dim LocRM As New ResourceManager("Gesalt.WinFormStrings", GetType(frmMail).Assembly)

    Private Sub tbxCancel_Click(sender As Object, e As EventArgs) Handles tbxCancel.Click
        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        Dim fromAddress = New MailAddress(My.Settings.mailAddress, My.Settings.mailName)

        Dim smtp As New SmtpClient() With {
        .Host = My.Settings.mailHost,
        .Port = My.Settings.mailPort,
        .EnableSsl = My.Settings.mailSSL,
        .DeliveryMethod = SmtpDeliveryMethod.Network,
        .UseDefaultCredentials = False,
        .Credentials = New NetworkCredential(My.Settings.mailUserName, Utils.Unprotect(My.Settings.mailPassword))
    }

        Dim mail As New MailMessage() With {
            .From = fromAddress,
            .SubjectEncoding = System.Text.Encoding.UTF8,
            .Subject = tbxSubject.Text,
            .Body = rtbMessage.Text,
            .BodyEncoding = System.Text.Encoding.UTF8,
            .IsBodyHtml = False,
            .Priority = MailPriority.Normal,
            .Sender = fromAddress
        }

        Me.UseWaitCursor = True

        Dim opGuest As OpGuest = OpGuest.GetInstance()
        Dim guests As New List(Of Guest)

        guests = opGuest.GetGuests()

        For Each guest As Guest In guests
            If guest.AcceptAd AndAlso guest.Email.Length > 0 Then
                mail.Bcc.Add(New MailAddress(guest.Email, guest.FirstName & " " & guest.LastName))
            End If
        Next

        Try
            smtp.Send(mail)
        Catch err As Exception
            MsgBox(LocRM.GetString("errorMailMsg"), MsgBoxStyle.Exclamation, "Gesalt")
        End Try

        Me.UseWaitCursor = False
        DialogResult = DialogResult.OK
    End Sub
End Class