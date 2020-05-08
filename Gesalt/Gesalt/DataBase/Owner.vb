<Serializable()>
Public Class Owner

    Public ReadOnly Property Id As Integer

    Public Property Type As String

    Public Property FirstName As String

    Public Property LastName As String

    Public Property Nif As String

    Public Property Address As String

    Public Property Zip As String

    Public Property City As String

    Public Property Province As String

    Public Property Phone As String

    Public Property Email As String

    Public Property PathLogo As String

    Public Sub New()
        Me.Id = 0
        Me.Type = ""
        Me.FirstName = ""
        Me.LastName = ""
        Me.Nif = ""
        Me.Address = ""
        Me.Zip = ""
        Me.City = ""
        Me.Province = ""
        Me.Phone = ""
        Me.Email = ""
        Me.PathLogo = ""
    End Sub

    Public Sub New(id As Integer, type As String, firstName As String, lastName As String, nif As String, address As String, zip As String, city As String, province As String, phone As String, email As String, pathLogo As String)
        Me.Id = id
        Me.Type = type
        Me.FirstName = firstName
        Me.LastName = lastName
        Me.Nif = nif
        Me.Address = address
        Me.Zip = zip
        Me.City = city
        Me.Province = province
        Me.Phone = phone
        Me.Email = email
        Me.PathLogo = pathLogo
    End Sub

End Class
