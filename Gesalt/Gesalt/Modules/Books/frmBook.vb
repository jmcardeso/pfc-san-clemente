﻿Imports System.Resources

Public Class frmBook
    Public Property editBook As Book
    Public Property prop As Prop
    Public Property bookTypes As New List(Of BookType)
    Public Property guests As New List(Of Guest)

    Dim opBook As OpBook
    Dim bookAux As Book
    Dim LocRM As New ResourceManager("Gesalt.WinFormStrings", GetType(frmBook).Assembly)

    Private Sub frmBook_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbxBookTypes.DataSource = bookTypes
        cbxGuests.DataSource = guests

        For i As Integer = 1 To 5
            cbxStatus.Items.Add(LocRM.GetString("bookingStatus" & i))
        Next
        cbxStatus.SelectedIndex = 0

        lblProperty.Text = prop.Address

        Utils.MarkBooksInCalendar(prop.Books, mclCalendar)


    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub
    Private Sub mclCalendar_DateChanged(sender As Object, e As DateRangeEventArgs)
        If mclCalendar.BoldedDates.Contains(e.Start) Then
            lblCalendar.Text = Utils.GetBookInfo(prop, e.Start)
        Else
            lblCalendar.Text = ""
        End If
    End Sub
End Class