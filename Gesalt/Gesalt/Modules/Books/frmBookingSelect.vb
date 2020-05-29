Imports System.Resources

Public Class frmBookingSelect
    Public Property bookings As New List(Of Book)
    Public Property bookingSelected As Book
    Dim LocRM As New ResourceManager("Gesalt.WinFormStrings", GetType(frmBookingSelect).Assembly)

    Private Sub frmBookingSelect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rbtBooking1.Text = bookings.Item(0).ToString()

        If bookings.Item(1) IsNot Nothing Then
            rbtBooking2.Text = bookings.Item(1).ToString()
        Else
            rbtBooking2.Text = LocRM.GetString("newBooking")
        End If

        rbtBooking1.Checked = True
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If rbtBooking1.Checked Then
            bookingSelected = bookings.Item(0)
        Else
            bookingSelected = bookings.Item(1)
        End If

        Me.DialogResult = DialogResult.OK
    End Sub
End Class