Imports System.Resources

Public Class frmLegalClassification
    Dim opProp As OpProp = OpProp.GetInstance()
    Dim legalClassAux As LegalClassification
    Dim legalClasses As New List(Of LegalClassification)
    Dim bs As New BindingSource()
    Dim LocRM As New ResourceManager("Gesalt.WinFormStrings", GetType(frmMain).Assembly)

    Private Sub frmLegalClassification_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        legalClasses = opProp.GetLegalClasses()

        If legalClasses.Count = 0 Then
            legalClassAux = New LegalClassification()
        Else
            legalClassAux = legalClasses.Item(0)
        End If

        bs.DataSource = legalClasses

        Dim column As DataGridViewColumn
        With dgvLegalClasses
            .AutoGenerateColumns = False
            .ColumnCount = 1

            column = .Columns(0)
            column.Width = 310
            .Columns(0).Name = "Description"
            .Columns(0).HeaderText = LocRM.GetString("fieldDescription")
            .Columns(0).DataPropertyName = "Description"

            .DataSource = bs
        End With

        tbxDescription.DataBindings.Add("Text", legalClassAux, "Description")

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub bntOK_Click(sender As Object, e As EventArgs) Handles bntOK.Click
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If tbxDescription.Text.Length = 0 Then
            MsgBox(LocRM.GetString("legalClassDescEmptyMsg"), MsgBoxStyle.Exclamation, "Gesalt")
            Exit Sub
        End If

        Dim frmDesAux As New frmDescriptionAux With {
            .Text = LocRM.GetString("addLegalClassDesc")
        }

        If frmDesAux.ShowDialog() = DialogResult.Cancel Then
            Exit Sub
        End If

        tbxDescription.Text = frmDesAux.Description

        Dim newLC As LegalClassification = New LegalClassification(0, tbxDescription.Text)
        Dim id As Integer = opProp.AddLegalClass(newLC)

        If id < 1 Then
            MsgBox(LocRM.GetString("opFailedMsg"), MsgBoxStyle.Exclamation, LocRM.GetString("opFailedTitle"))
        Else
            newLC.Id = id
            legalClasses.Add(newLC)

            bs.ResetBindings(False)
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If bs.Current Is Nothing Then
            Exit Sub
        End If

        CType(bs.Current, LegalClassification).Description = tbxDescription.Text

        If Not opProp.UpdateLegalClass(bs.Current) Then
            MsgBox(LocRM.GetString("opFailedMsg"), MsgBoxStyle.Exclamation, LocRM.GetString("opFailedTitle"))
        Else
            bs.ResetBindings(False)
        End If

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If bs.Current Is Nothing Then
            Exit Sub
        End If

        If Not opProp.IsSafeDeleteLegalClass(bs.Current.Id) Then
            MsgBox(LocRM.GetString("lcNoDeleted"), MsgBoxStyle.Exclamation, "Gesalt")
            Exit Sub
        End If

        If MsgBox("'" & bs.Current.Description & "' " & LocRM.GetString("rowRemovedMsg"),
              MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2,
              LocRM.GetString("rowRemovedTitle")) = MsgBoxResult.No Then
            Exit Sub
        End If

        If Not opProp.DeleteLegalClass(bs.Current) Then
            MsgBox(LocRM.GetString("opFailedMsg"), MsgBoxStyle.Exclamation, LocRM.GetString("opFailedTitle"))
        Else
            legalClasses.Remove(bs.Current)
            bs.ResetBindings(False)
        End If
    End Sub

    Private Sub dgvLegalClasses_SelectionChanged(sender As Object, e As EventArgs) Handles dgvLegalClasses.SelectionChanged
        legalClassAux = bs.Current
        tbxDescription.Text = bs.Current.Description
    End Sub
End Class