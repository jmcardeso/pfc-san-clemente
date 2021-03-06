﻿Imports System.Resources
Imports System.Data.Common

Public Class frmPropertiesFilter
    Private _resultSQL As String
    Public ReadOnly Property resultSQL As String
        Get
            Return _resultSQL
        End Get
    End Property

    Private _resultReadable As String
    Public ReadOnly Property resultReadable As String
        Get
            Return _resultReadable
        End Get
    End Property

    Private _resultParameters As New List(Of DbParameter)
    Public ReadOnly Property resultParameters As List(Of DbParameter)
        Get
            Return _resultParameters
        End Get
    End Property

    Const SELECT_PROPERTY As String = "select * from property where "
    Const ORDERBY_PROPERTY As String = " order by city"

    Dim LocRM As New ResourceManager("Gesalt.WinFormStrings", GetType(frmPropertiesFilter).Assembly)

    Dim Position As New Point(10, 10)
    Dim FiltersPanel As New List(Of Panel)
    Dim ContainerPanel As New FlowLayoutPanel
    Dim FieldsPropName As String() = {LocRM.GetString("fieldCadRef"), LocRM.GetString("fieldAddress"), LocRM.GetString("fieldCity"), LocRM.GetString("fieldZip"),
        LocRM.GetString("fieldProvince"), LocRM.GetString("fieldMaxGuests"), LocRM.GetString("fieldSize"), LocRM.GetString("fieldBedrooms"),
        LocRM.GetString("fieldBaths"), LocRM.GetString("fieldDescription")}
    Dim FieldsProp As String() = {"cad_ref", "address", "city", "zip", "province", "max_guests", "siz", "bedrooms", "baths", "description"}
    Dim NumberOperators As String() = {"=", "<>", "<", ">", "<=", ">="}
    Dim StringOperators As String() = {LocRM.GetString("EqualTo"), LocRM.GetString("DifferentFrom"), LocRM.GetString("StartsWith"), LocRM.GetString("Contains")}
    Const CAD_REF As Integer = 0, ADDRESS As Integer = 1, CITY As Integer = 2, ZIP As Integer = 3, PROVINCE As Integer = 4, MAX_GUESTS As Integer = 5,
        SIZ As Integer = 6, BEDROOMS As Integer = 7, BATHS As Integer = 8, DESCRIPTION As Integer = 9

    Private Sub FrmFiltros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ContainerPanel.FlowDirection = FlowDirection.TopDown
        ContainerPanel.Location = New Point(10, 10)
        ContainerPanel.Size = New Size(850, 300)
        Me.Controls.Add(ContainerPanel)

        AddFilterLine()
    End Sub
    Private Sub BtnOk_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If Not ValidateFilter() Then
            MsgBox(LocRM.GetString("InvalidFilterData") + vbNewLine + LocRM.GetString("EnterCorrectData"), MsgBoxStyle.Exclamation, "Gesalt")
            _resultParameters.Clear()
            _resultReadable = ""
            _resultSQL = ""
        Else
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
            Case CAD_REF, ADDRESS, CITY, ZIP, PROVINCE, DESCRIPTION
                CmbCurrentOperator.Items.AddRange(StringOperators)
                CmbCurrentOperator.SelectedIndex = 0
                ShowControl(sender.SelectedIndex, sender.Parent.Controls.Find("VTextBox_" & index, True)(0))
            Case MAX_GUESTS, SIZ, BEDROOMS, BATHS
                CmbCurrentOperator.Items.AddRange(NumberOperators)
                CmbCurrentOperator.SelectedIndex = 0
                ShowControl(sender.SelectedIndex, sender.Parent.Controls.Find("VTextBox_" & index, True)(0))
        End Select

    End Sub
    Private Sub VTextBox_KeyDown(sender As TextBox, e As EventArgs)
        sender.BackColor = Color.White
    End Sub
    Private Sub BtnPlus_Click(sender As Object, e As EventArgs)
        AddFilterLine()
    End Sub

    Private Sub BtnMinus_Click(sender As Object, e As EventArgs)
        Dim index As Integer = Val(CType(sender, Control).Parent.Name.Last)
        ContainerPanel.Controls.Remove(Controls.Find("Panel_" & index, True)(0))
        FiltersPanel.RemoveAt(index)
        Dim cont As Integer = 0
        For Each item As Panel In FiltersPanel
            item.Name = "Panel_" & cont
            For Each subitem As Control In item.Controls
                Dim splitName As String() = subitem.Name.Split("_")
                subitem.Name = splitName(0) & "_" & cont
            Next
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
        CmbFields.Name = "CmbFields_" & FiltersPanel.Count - 1
        CmbFields.DropDownStyle = ComboBoxStyle.DropDownList
        CmbFields.Items.AddRange(FieldsPropName)
        CmbFields.SelectedIndex = 0
        AddHandler CmbFields.SelectedIndexChanged, AddressOf Me.CmbCampos_SelectedIndexChanged
        pnlFilter.Controls.Add(CmbFields)

        Dim cmbOperators As New ComboBox
        cmbOperators.Location = New Point(130, 0)
        cmbOperators.Name = "CmbOperators_" & FiltersPanel.Count - 1
        cmbOperators.Items.AddRange(StringOperators)
        cmbOperators.SelectedIndex = 0
        cmbOperators.DropDownStyle = ComboBoxStyle.DropDownList
        pnlFilter.Controls.Add(cmbOperators)

        Dim VTextBox As New TextBox
        VTextBox.Location = New Point(273, 0)
        VTextBox.Name = "VTextBox_" & FiltersPanel.Count - 1
        AddHandler VTextBox.KeyDown, AddressOf Me.VTextBox_KeyDown
        pnlFilter.Controls.Add(VTextBox)

        Dim VCheckBox As New CheckBox
        VCheckBox.Location = New Point(273, 0)
        VCheckBox.Size = New Size(190, 20)
        VCheckBox.Text = LocRM.GetString("filterPropLogoTrue")
        VCheckBox.Name = "VCheckBox_" & FiltersPanel.Count - 1
        VCheckBox.Visible = False
        pnlFilter.Controls.Add(VCheckBox)

        Dim VDateTimePicker As New DateTimePicker
        VDateTimePicker.Location = New Point(273, 0)
        VDateTimePicker.Name = "VDateTimePicker_" & FiltersPanel.Count - 1
        VDateTimePicker.Format = DateTimePickerFormat.Short
        VDateTimePicker.Visible = False
        pnlFilter.Controls.Add(VDateTimePicker)

        Dim cmbAdd As New ComboBox
        cmbAdd.Location = New Point(500, 0)
        cmbAdd.Name = "CmbAdd_" & FiltersPanel.Count - 1
        cmbAdd.DropDownStyle = ComboBoxStyle.DropDownList
        cmbAdd.Items.Add(LocRM.GetString("filterAnd"))
        cmbAdd.Items.Add(LocRM.GetString("filterOr"))
        cmbAdd.SelectedIndex = 0
        pnlFilter.Controls.Add(cmbAdd)

        Dim btnPlus As New Button
        btnPlus.Location = New Point(650, 0)
        btnPlus.Name = "BtnPlus_" & FiltersPanel.Count - 1
        btnPlus.Text = "+"
        AddHandler btnPlus.Click, AddressOf Me.BtnPlus_Click
        pnlFilter.Controls.Add(btnPlus)

        Dim btnMinus As New Button
        btnMinus.Location = New Point(750, 0)
        btnMinus.Name = "BtnMinus_" & FiltersPanel.Count - 1
        btnMinus.Text = "-"
        AddHandler btnMinus.Click, AddressOf Me.BtnMinus_Click
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
    Private Function ValidateFilter() As Boolean
        _resultSQL = SELECT_PROPERTY
        _resultReadable = ""
        _resultParameters.Clear()

        Dim resultAux As String = ""
        Dim controlIndex As Integer
        Dim FilterOK As Boolean = True

        For i As Integer = 0 To ContainerPanel.Controls.Count - 1
            controlIndex = CType(ContainerPanel.Controls.Item(i).Controls.Item(0), ComboBox).SelectedIndex
            Select Case controlIndex
                Case CAD_REF, ADDRESS, CITY, ZIP, PROVINCE, DESCRIPTION

                    Dim VTextBox As TextBox = ContainerPanel.Controls.Item(i).Controls.Find("VTextBox_" & i, True)(0)

                    If VTextBox.TextLength = 0 And (controlIndex = CAD_REF Or controlIndex = ADDRESS) Then
                        VTextBox.BackColor = Color.Red
                        FilterOK = False
                    Else
                        _resultSQL += FieldsProp(controlIndex) & " "
                        Select Case CType(ContainerPanel.Controls.Item(i).Controls.Item(1), ComboBox).SelectedIndex
                            Case 0
                                _resultSQL += "like @" & VTextBox.Name
                                _resultParameters.Add(Utils.AddFilterParameter("@" & VTextBox.Name, VTextBox.Text, DbType.String))
                            Case 1
                                _resultSQL += "not like @" & VTextBox.Name
                                _resultParameters.Add(Utils.AddFilterParameter("@" & VTextBox.Name, VTextBox.Text, DbType.String))
                            Case 2
                                _resultSQL += "like @" & VTextBox.Name
                                _resultParameters.Add(Utils.AddFilterParameter("@" & VTextBox.Name, VTextBox.Text & "%", DbType.String))
                            Case 3
                                _resultSQL += "like @" & VTextBox.Name
                                _resultParameters.Add(Utils.AddFilterParameter("@" & VTextBox.Name, "%" & VTextBox.Text & "%", DbType.String))
                        End Select
                        _resultReadable += FieldsPropName(controlIndex) & " " & CType(ContainerPanel.Controls.Item(i).Controls.Item(1), ComboBox).SelectedItem & " '" &
                            VTextBox.Text & "'"
                    End If
                Case MAX_GUESTS, BEDROOMS, BATHS, SIZ
                    Dim VTextBox As TextBox = ContainerPanel.Controls.Item(i).Controls.Find("VTextBox_" & i, True)(0)

                    If Not IsNumeric(VTextBox.Text) Then
                        VTextBox.BackColor = Color.Red
                        FilterOK = False
                    Else
                        _resultSQL += FieldsProp(controlIndex) & " " & CType(ContainerPanel.Controls.Item(i).Controls.Item(1), ComboBox).SelectedItem & " @"
                        _resultSQL += VTextBox.Name
                        _resultReadable += FieldsPropName(controlIndex) & " " & CType(ContainerPanel.Controls.Item(i).Controls.Item(1), ComboBox).SelectedItem & " " & VTextBox.Text
                        _resultParameters.Add(Utils.AddFilterParameter("@" & VTextBox.Name, VTextBox.Text, DbType.Int32))
                    End If
            End Select

            If i < ContainerPanel.Controls.Count - 1 Then
                _resultSQL += IIf(CType(ContainerPanel.Controls.Item(i).Controls.Item(5), ComboBox).SelectedItem.Equals(LocRM.GetString("filterAnd")), " and ", " or ")
                _resultReadable += IIf(CType(ContainerPanel.Controls.Item(i).Controls.Item(5), ComboBox).SelectedItem.Equals(LocRM.GetString("filterAnd")),
                                      " " & LocRM.GetString("filterAnd") & " ", " " & LocRM.GetString("filterOr") & " ")
            End If
        Next

        _resultSQL &= ORDERBY_PROPERTY
        Return FilterOK
    End Function
End Class