Imports System.Resources

Public Class frmOwnersFilter
    Dim LocRM As New ResourceManager("Gesalt.WinFormStrings", GetType(frmOwnersFilter).Assembly)

    Dim Position As New Point(10, 10)
    Dim FiltersPanel As New List(Of Panel)
    Dim ContainerPanel As New FlowLayoutPanel
    Dim FieldsOwner As String() = {LocRM.GetString("fieldType"), LocRM.GetString("fieldLastName"), LocRM.GetString("fieldFirstName"), LocRM.GetString("fieldNif"),
        LocRM.GetString("fieldAddress"), LocRM.GetString("fieldCity"), LocRM.GetString("fieldZip"), LocRM.GetString("fieldProvince"),
        LocRM.GetString("fieldPhone"), LocRM.GetString("fieldEmail"), LocRM.GetString("fieldPahtLogo")}
    Dim NumberOperators As String() = {"=", "<>", "<", ">", "<=", ">="}
    Dim StringOperators As String() = {LocRM.GetString("EqualTo"), LocRM.GetString("DifferentFrom"), LocRM.GetString("StartsWith"), LocRM.GetString("Contains")}
    Const MATRICULA As Integer = 0, MARCA As Integer = 1, MODELO As Integer = 2, CARGA_MAX As Integer = 3, N_BASTIDOR As Integer = 4, FECHA_MAT As Integer = 5, FOTO As Integer = 6
    Dim FilterError As Boolean = False

    Private Sub FrmFiltros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ContainerPanel.FlowDirection = FlowDirection.TopDown
        ContainerPanel.Location = New Point(10, 10)
        ContainerPanel.Size = New Size(850, 300)
        Me.Controls.Add(ContainerPanel)

        AddFilterLine()
    End Sub
    Private Sub BtnOk_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim SelectionAux As String() = ValidateFilter()

        If FilterError Then
            MsgBox(LocRM.GetString("InvalidFilterData") + vbNewLine + LocRM.GetString("EnterCorrectData"), MsgBoxStyle.Exclamation, "Atención")
        Else
            SeleccionSociosFiltro = SelectionAux
            Me.DialogResult = DialogResult.OK
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub
    Private Sub CmbCampos_SelectedIndexChanged(sender As ComboBox, e As EventArgs)
        Dim CmbCurrentOperator As ComboBox = sender.Parent.Controls.Item(1)
        Dim index As String = CmbCurrentOperator.Name.Last

        CmbCurrentOperator.Items.Clear()
        If CmbCurrentOperator.Visible = False Then
            CmbCurrentOperator.Visible = True
        End If

        Select Case sender.SelectedIndex
            Case MATRICULA
                CmbCurrentOperator.Items.AddRange(StringOperators)
                CmbCurrentOperator.SelectedIndex = 0
                ShowControl(sender.SelectedIndex, sender.Parent.Controls.Find("VTextBox_" & index, True)(0))
            Case MARCA
                CmbCurrentOperator.Items.AddRange(StringOperators)
                CmbCurrentOperator.SelectedIndex = 0
                ShowControl(sender.SelectedIndex, sender.Parent.Controls.Find("VTextBox_" & index, True)(0))
            Case MODELO
                CmbCurrentOperator.Items.AddRange(StringOperators)
                CmbCurrentOperator.SelectedIndex = 0
                ShowControl(sender.SelectedIndex, sender.Parent.Controls.Find("VTextBox_" & index, True)(0))
            Case CARGA_MAX
                CmbCurrentOperator.Items.AddRange(NumberOperators)
                CmbCurrentOperator.SelectedIndex = 0
                ShowControl(sender.SelectedIndex, sender.Parent.Controls.Find("VTextBox_" & index, True)(0))
            Case N_BASTIDOR
                CmbCurrentOperator.Items.AddRange(StringOperators)
                CmbCurrentOperator.SelectedIndex = 0
                ShowControl(sender.SelectedIndex, sender.Parent.Controls.Find("VTextBox_" & index, True)(0))
            Case FECHA_MAT
                CmbCurrentOperator.Items.AddRange(NumberOperators)
                CmbCurrentOperator.SelectedIndex = 0
                ShowControl(sender.SelectedIndex, sender.Parent.Controls.Find("VDateTimePicker_" & index, True)(0))
            Case FOTO
                CmbCurrentOperator.Visible = False
                ShowControl(sender.SelectedIndex, sender.Parent.Controls.Find("VCheckBox_" & index, True)(0))
        End Select

    End Sub
    Private Sub VTextBox_KeyDown(sender As TextBox, e As EventArgs)
        sender.BackColor = Color.White
    End Sub
    Private Sub BtnMas_Click(sender As Object, e As EventArgs)
        AddFilterLine()
    End Sub

    Private Sub BtnMenos_Click(sender As Object, e As EventArgs)
        Dim index As Integer = Val(CType(sender, Control).Parent.Name.Last)
        ContainerPanel.Controls.Remove(Controls.Find("Panel_" & index, True)(0))
        FiltersPanel.RemoveAt(index)
        Dim cont As Integer = 0
        For Each item As Panel In FiltersPanel
            item.Name = "Panel_" & cont
            cont += 1
        Next
    End Sub
    Public Sub AddFilterLine()
        If FiltersPanel.Count > 5 Then
            Exit Sub
        End If

        Dim PosY As Integer = Position.Y + (50 * FiltersPanel.Count)

        Dim pnlFilter As New Panel
        pnlFilter.Location = New Point(Position.X, PosY)
        pnlFilter.Size = New Size(830, 25)
        pnlFilter.Name = "Panel_" & FiltersPanel.Count
        FiltersPanel.Add(pnlFilter)

        Dim CmbFields As New ComboBox
        CmbFields.Location = New Point(0, 0)
        CmbFields.Name = "CmbFields_" & FiltersPanel.Count
        CmbFields.DropDownStyle = ComboBoxStyle.DropDownList
        CmbFields.Items.AddRange(FieldsOwner)
        CmbFields.SelectedIndex = 0
        AddHandler CmbFields.SelectedIndexChanged, AddressOf Me.CmbCampos_SelectedIndexChanged
        pnlFilter.Controls.Add(CmbFields)

        Dim cmbOperators As New ComboBox
        cmbOperators.Location = New Point(130, 0)
        cmbOperators.Name = "CmbOperators_" & FiltersPanel.Count
        cmbOperators.Items.AddRange(StringOperators)
        cmbOperators.SelectedIndex = 0
        cmbOperators.DropDownStyle = ComboBoxStyle.DropDownList
        pnlFilter.Controls.Add(cmbOperators)

        Dim VTextBox As New TextBox
        VTextBox.Location = New Point(273, 0)
        VTextBox.Name = "VTextBox_" & FiltersPanel.Count
        AddHandler VTextBox.KeyDown, AddressOf Me.VTextBox_KeyDown
        pnlFilter.Controls.Add(VTextBox)

        Dim VCheckBox As New CheckBox
        VCheckBox.Location = New Point(273, 0)
        VCheckBox.Text = "Foto"
        VCheckBox.Name = "VCheckBox_" & FiltersPanel.Count
        VCheckBox.Visible = False
        pnlFilter.Controls.Add(VCheckBox)

        Dim VDateTimePicker As New DateTimePicker
        VDateTimePicker.Location = New Point(273, 0)
        VDateTimePicker.Name = "VDateTimePicker_" & FiltersPanel.Count
        VDateTimePicker.Format = DateTimePickerFormat.Short
        VDateTimePicker.Visible = False
        pnlFilter.Controls.Add(VDateTimePicker)

        Dim cmbAdd As New ComboBox
        cmbAdd.Location = New Point(500, 0)
        cmbAdd.Name = "CmbAdd_" & FiltersPanel.Count
        cmbAdd.DropDownStyle = ComboBoxStyle.DropDownList
        cmbAdd.Items.Add(LocRM.GetString("filterAnd"))
        cmbAdd.Items.Add(LocRM.GetString("filterOr"))
        cmbAdd.SelectedIndex = 0
        pnlFilter.Controls.Add(cmbAdd)

        Dim btnPlus As New Button
        btnPlus.Location = New Point(650, 0)
        btnPlus.Name = "BtnPlus_" & FiltersPanel.Count
        btnPlus.Text = "+"
        AddHandler btnPlus.Click, AddressOf Me.BtnMas_Click
        pnlFilter.Controls.Add(btnPlus)

        Dim btnMinus As New Button
        btnMinus.Location = New Point(750, 0)
        btnMinus.Name = "BtnMinus_" & FiltersPanel.Count
        btnMinus.Text = "-"
        AddHandler btnMinus.Click, AddressOf Me.BtnMenos_Click
        pnlFilter.Controls.Add(btnMinus)

        If FiltersPanel.Count = 1 Then
            btnMinus.Visible = False
        End If

        ContainerPanel.Controls.Add(FiltersPanel.Item(FiltersPanel.Count - 1))

    End Sub
    Private Sub ShowControl(TipoControl As Integer, objControl As Control)
        For i As Integer = 2 To 4
            objControl.Parent.Controls.Item(i).Visible = False
        Next

        objControl.Visible = True
    End Sub
    Private Function ValidateFilter() As String()
        Dim result As String() = {"", ""}
        Dim resultSQL As String = ""
        Dim resultReadable As String = ""
        Dim resultAux As String = ""
        FilterError = False

        For indice As Integer = 0 To ContainerPanel.Controls.Count - 1

            Select Case CType(ContainerPanel.Controls.Item(indice).Controls.Item(0), ComboBox).SelectedIndex
                Case MATRICULA
                    Dim VTextBox As TextBox = ContainerPanel.Controls.Item(indice).Controls.Find("VTextBox_" & indice + 1, True)(0)

                    If VTextBox.TextLength = 0 Then
                        VTextBox.BackColor = Color.Red
                        FilterError = True
                    Else
                        resultSQL += "Matricula "
                        Select Case CType(ContainerPanel.Controls.Item(indice).Controls.Item(1), ComboBox).SelectedIndex
                            Case 0
                                resultSQL += "like '" & VTextBox.Text & "'"
                            Case 1
                                resultSQL += "not like '" & VTextBox.Text & "'"
                            Case 2
                                resultSQL += "like '" & VTextBox.Text & "%'"
                            Case 3
                                resultSQL += "like '%" & VTextBox.Text & "%'"
                        End Select
                        resultReadable += "Matrícula " & CType(ContainerPanel.Controls.Item(indice).Controls.Item(1), ComboBox).SelectedItem & " '" &
                            VTextBox.Text & "'"
                    End If
                Case MARCA
                    Dim VTextBox As TextBox = ContainerPanel.Controls.Item(indice).Controls.Find("VTextBox_" & indice + 1, True)(0)

                    If VTextBox.TextLength = 0 Then
                        VTextBox.BackColor = Color.Red
                        FilterError = True
                    Else
                        resultSQL += "Marca "
                        Select Case CType(ContainerPanel.Controls.Item(indice).Controls.Item(1), ComboBox).SelectedIndex
                            Case 0
                                resultSQL += "like '" & VTextBox.Text & "'"
                            Case 1
                                resultSQL += "not like '" & VTextBox.Text & "'"
                            Case 2
                                resultSQL += "like '" & VTextBox.Text & "%'"
                            Case 3
                                resultSQL += "like '%" & VTextBox.Text & "%'"
                        End Select
                        resultReadable += "Marca " & CType(ContainerPanel.Controls.Item(indice).Controls.Item(1), ComboBox).SelectedItem & " '" &
                            VTextBox.Text & "'"
                    End If
                Case MODELO
                    Dim VTextBox As TextBox = ContainerPanel.Controls.Item(indice).Controls.Find("VTextBox_" & indice + 1, True)(0)

                    If VTextBox.TextLength = 0 Then
                        VTextBox.BackColor = Color.Red
                        FilterError = True
                    Else
                        resultSQL += "Modelo "
                        Select Case CType(ContainerPanel.Controls.Item(indice).Controls.Item(1), ComboBox).SelectedIndex
                            Case 0
                                resultSQL += "like '" & VTextBox.Text & "'"
                            Case 1
                                resultSQL += "not like '" & VTextBox.Text & "'"
                            Case 2
                                resultSQL += "like '" & VTextBox.Text & "%'"
                            Case 3
                                resultSQL += "like '%" & VTextBox.Text & "%'"
                        End Select
                        resultReadable += "Modelo " & CType(ContainerPanel.Controls.Item(indice).Controls.Item(1), ComboBox).SelectedItem & " '" &
                            VTextBox.Text & "'"
                    End If
                Case CARGA_MAX
                    Dim VTextBox As TextBox = ContainerPanel.Controls.Item(indice).Controls.Find("VTextBox_" & indice + 1, True)(0)

                    If Not IsNumeric(VTextBox.Text) Then
                        VTextBox.BackColor = Color.Red
                        FilterError = True
                    Else
                        resultAux = "CargaMax " & CType(ContainerPanel.Controls.Item(indice).Controls.Item(1), ComboBox).SelectedItem & " "
                        resultAux += VTextBox.Text
                        resultSQL += resultAux
                        resultReadable += "Carga máxima " & CType(ContainerPanel.Controls.Item(indice).Controls.Item(1), ComboBox).SelectedItem & " " & VTextBox.Text
                    End If
                Case N_BASTIDOR
                    Dim VTextBox As TextBox = ContainerPanel.Controls.Item(indice).Controls.Find("VTextBox_" & indice + 1, True)(0)

                    If VTextBox.TextLength = 0 Then
                        VTextBox.BackColor = Color.Red
                        FilterError = True
                    Else
                        resultSQL += "nBastidor "
                        Select Case CType(ContainerPanel.Controls.Item(indice).Controls.Item(1), ComboBox).SelectedIndex
                            Case 0
                                resultSQL += "like '" & VTextBox.Text & "'"
                            Case 1
                                resultSQL += "not like '" & VTextBox.Text & "'"
                            Case 2
                                resultSQL += "like '" & VTextBox.Text & "%'"
                            Case 3
                                resultSQL += "like '%" & VTextBox.Text & "%'"
                        End Select
                        resultReadable += "Nº de bastidor " & CType(ContainerPanel.Controls.Item(indice).Controls.Item(1), ComboBox).SelectedItem & " '" &
                            VTextBox.Text & "'"
                    End If
                Case FECHA_MAT
                    Dim VDateTimePicker As DateTimePicker = ContainerPanel.Controls.Item(indice).Controls.Find("VDateTimePicker_" & indice + 1, True)(0)

                    resultAux = "Fechamatric " & CType(ContainerPanel.Controls.Item(indice).Controls.Item(1), ComboBox).SelectedItem & " '"
                    resultAux += VDateTimePicker.Value.ToShortDateString & "'"
                    resultSQL += resultAux
                    resultReadable += resultAux
                Case FOTO
                    Dim VCheckBox As CheckBox = ContainerPanel.Controls.Item(indice).Controls.Find("VCheckBox_" & indice + 1, True)(0)

                    resultSQL += "Foto IS "
                    resultSQL += IIf(VCheckBox.Checked, "NOT NULL", "NULL")
                    resultReadable += IIf(VCheckBox.Checked, "'Vehículo tiene foto'", "'Vehículo no tiene foto'")
            End Select

            If indice < ContainerPanel.Controls.Count - 1 Then
                resultSQL += IIf(CType(ContainerPanel.Controls.Item(indice).Controls.Item(5), ComboBox).SelectedItem.Equals("Y"), " and ", " or ")
                resultReadable += IIf(CType(ContainerPanel.Controls.Item(indice).Controls.Item(5), ComboBox).SelectedItem.Equals("Y"), " Y ", " O ")
            End If
        Next

        result(0) = resultSQL
        result(1) = resultReadable
        Return result
    End Function
End Class