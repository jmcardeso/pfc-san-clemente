﻿<Serializable()>
Public Class Prop
    Public ReadOnly Property Id As Integer
    Public Property CadRef As String
    Public Property Address As String
    Public Property Zip As String
    Public Property City As String
    Public Property Province As String
    Public Property MaxGuests As Integer
    Public Property Size As Decimal
    Public Property BedRooms As Integer
    Public Property Baths As Integer
    Public Property Description As String

    Public Sub New()
        Me.Id = 0
        Me.CadRef = ""
        Me.Address = ""
        Me.Zip = ""
        Me.City = ""
        Me.Province = ""
        Me.MaxGuests = 0
        Me.Size = 0
        Me.BedRooms = 0
        Me.Baths = 0
        Me.Description = ""
    End Sub

    Public Sub New(id As Integer, cadRef As String, address As String, zip As String, city As String,
                   province As String, maxGuests As Integer, size As Decimal, bedRooms As Integer,
                   baths As Integer, description As String)
        Me.Id = id
        Me.CadRef = cadRef
        Me.Address = address
        Me.Zip = zip
        Me.City = city
        Me.Province = province
        Me.MaxGuests = maxGuests
        Me.Size = size
        Me.BedRooms = bedRooms
        Me.Baths = baths
        Me.Description = description
    End Sub
End Class
