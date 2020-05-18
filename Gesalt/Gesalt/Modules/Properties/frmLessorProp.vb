Imports System.Resources

Public Class frmLessorProp
    Public Property editLessorProp As LessorProp
    Dim lpAux As LessorProp
    Dim LocRM As New ResourceManager("Gesalt.WinFormStrings", GetType(frmLessorProp).Assembly)

    Private Sub frmLessorProp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim opLessor As OpLessor = OpLessor.GetInstance()
        Dim lessors As New List(Of Lessor)

        If editLessorProp IsNot Nothing Then
            Me.Text = LocRM.GetString("editLP")

            cbxLessors.Items.Add(editLessorProp.Lessor)
        Else
            editLessorProp = New LessorProp()

            lessors = opLessor.GetAllLessors()
            cbxLessors.DataSource = lessors
        End If

        lpAux = Utils.DeepClone(editLessorProp)

        cbxLessors.SelectedIndex = 0
        nudPercentage.Value = lpAux.Percentage
    End Sub
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        lpAux.Percentage = nudPercentage.Value
        lpAux.Lessor = cbxLessors.SelectedItem

        editLessorProp = Utils.DeepClone(lpAux)
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub
End Class