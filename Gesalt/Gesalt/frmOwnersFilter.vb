Imports System.Resources
Imports System.Data.Common

Public Class frmOwnersFilter
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

    Const SELECT_OWNER As String = "select * from owner where "
    Const ORDERBY_OWNER As String = " order by last_name"

    Dim LocRM As New ResourceManager("Gesalt.WinFormStrings", GetType(frmOwnersFilter).Assembly)

    Dim Position As New Point(10, 10)
    Dim FiltersPanel As New List(Of Panel)
    Dim ContainerPanel As New FlowLayoutPanel
    Dim FieldsOwnerName As String() = {LocRM.GetString("fieldType"), LocRM.GetString("fieldLastName"), LocRM.GetString("fieldFirstName"), LocRM.GetString("fieldNif"),
        LocRM.GetString("fieldAddress"), LocRM.GetString("fieldCity"), LocRM.GetString("fieldZip"), LocRM.GetString("fieldProvince"),
        LocRM.GetString("fieldPhone"), LocRM.GetString("fieldEmail"), LocRM.GetString("fieldPathLogo")}
    Dim FieldsOwner As String() = {"type", "last_name", "first_name", "nif", "address", "city", "zip", "province", "phone", "email", "paht_logo"}
    Dim NumberOperators As String() = {"=", "<>", "<", ">", "<=", ">="}
    Dim StringOperators As String() = {LocRM.GetString("EqualTo"), LocRM.GetString("DifferentFrom"), LocRM.GetString("StartsWith"), LocRM.GetString("Contains")}
    Const TYPE As Integer = 0, LAST_NAME As Integer = 1, FIRST_NAME As Integer = 2, NIF As Integer = 3, ADDRESS As Integer = 4, CITY As Integer = 5, ZIP As Integer = 6,
        PROVINCE As Integer = 7, PHONE As Integer = 8, EMAIL As Integer = 9, PATH_LOGO As Integer = 10

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
            Case TYPE, LAST_NAME, FIRST_NAME, NIF, ADDRESS, CITY, ZIP, PROVINCE, PHONE, EMAIL
                CmbCurrentOperator.Items.AddRange(StringOperators)
                CmbCurrentOperator.SelectedIndex = 0
                ShowControl(sender.SelectedIndex, sender.Parent.Controls.Find("VTextBox_" & index, True)(0))
            Case PATH_LOGO
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
        CmbFields.Name = "CmbFields_" & FiltersPanel.Count
        CmbFields.DropDownStyle = ComboBoxStyle.DropDownList
        CmbFields.Items.AddRange(FieldsOwnerName)
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
        VCheckBox.Text = LocRM.GetString("fieldPathLogo")
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
    Private Function ValidateFilter() As Boolean
        _resultSQL = SELECT_OWNER
        _resultReadable = ""
        _resultParameters.Clear()

        Dim resultAux As String = ""
        Dim controlIndex As Integer
        Dim FilterOK As Boolean = True

        For i As Integer = 0 To ContainerPanel.Controls.Count - 1
            controlIndex = CType(ContainerPanel.Controls.Item(i).Controls.Item(0), ComboBox).SelectedIndex
            Select Case controlIndex
                Case TYPE, LAST_NAME, FIRST_NAME, NIF, ADDRESS, CITY, ZIP, PROVINCE, PHONE, EMAIL

                    Dim VTextBox As TextBox = ContainerPanel.Controls.Item(i).Controls.Find("VTextBox_" & i, True)(0)

                    If VTextBox.TextLength = 0 Then
                        VTextBox.BackColor = Color.Red
                        FilterOK = False
                    Else
                        _resultSQL += FieldsOwner(controlIndex) & " "
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
                        _resultReadable += FieldsOwnerName(controlIndex) & " " & CType(ContainerPanel.Controls.Item(i).Controls.Item(1), ComboBox).SelectedItem & " '" &
                            VTextBox.Text & "'"
                    End If
                Case PATH_LOGO
                    Dim VCheckBox As CheckBox = ContainerPanel.Controls.Item(i).Controls.Find("VCheckBox_" & i + 1, True)(0)

                    _resultSQL += FieldsOwner(controlIndex)
                    _resultSQL += IIf(VCheckBox.Checked, " like @", " not like @") & VCheckBox.Name
                    _resultParameters.Add(Utils.AddFilterParameter("@" & VCheckBox.Name, "", DbType.String))
                    _resultReadable += IIf(VCheckBox.Checked, "'" & LocRM.GetString("filterOwnerLogoTrue") & "'", "'" & LocRM.GetString("filterOwnerLogoFalse") & "'")
            End Select

            If i < ContainerPanel.Controls.Count - 1 Then
                _resultSQL += IIf(CType(ContainerPanel.Controls.Item(i).Controls.Item(5), ComboBox).SelectedItem.Equals(LocRM.GetString("filterAnd")), " and ", " or ")
                _resultReadable += IIf(CType(ContainerPanel.Controls.Item(i).Controls.Item(5), ComboBox).SelectedItem.Equals(LocRM.GetString("filterAnd")),
                                      " " & LocRM.GetString("filterAnd") & " ", " " & LocRM.GetString("filterOr") & " ")
            End If
        Next

        _resultSQL &= ORDERBY_OWNER
        Return FilterOK
    End Function
End Class