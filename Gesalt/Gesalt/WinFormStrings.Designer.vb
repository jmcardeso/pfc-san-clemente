﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Este código fue generado por una herramienta.
'     Versión de runtime:4.0.30319.42000
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'StronglyTypedResourceBuilder generó automáticamente esta clase
    'a través de una herramienta como ResGen o Visual Studio.
    'Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    'con la opción /str o recompile su proyecto de VS.
    '''<summary>
    '''  Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Class WinFormStrings
        
        Private Shared resourceMan As Global.System.Resources.ResourceManager
        
        Private Shared resourceCulture As Global.System.Globalization.CultureInfo
        
        <Global.System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")>  _
        Friend Sub New()
            MyBase.New
        End Sub
        
        '''<summary>
        '''  Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Shared ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("Gesalt.WinFormStrings", GetType(WinFormStrings).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        '''  búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Shared Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Version {0}.
        '''</summary>
        Friend Shared ReadOnly Property aboutVersion() As String
            Get
                Return ResourceManager.GetString("aboutVersion", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a There is an active filter. If you add a record, the filter will be reset. Are you sure?.
        '''</summary>
        Friend Shared ReadOnly Property addWhenFilterOnMsg() As String
            Get
                Return ResourceManager.GetString("addWhenFilterOnMsg", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Connection Error.
        '''</summary>
        Friend Shared ReadOnly Property conError() As String
            Get
                Return ResourceManager.GetString("conError", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Connection established successfully.
        '''</summary>
        Friend Shared ReadOnly Property conOK() As String
            Get
                Return ResourceManager.GetString("conOK", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Contains.
        '''</summary>
        Friend Shared ReadOnly Property Contains() As String
            Get
                Return ResourceManager.GetString("Contains", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Thing.
        '''</summary>
        Friend Shared ReadOnly Property Cosa() As String
            Get
                Return ResourceManager.GetString("Cosa", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a No connection bd..
        '''</summary>
        Friend Shared ReadOnly Property csNotFound() As String
            Get
                Return ResourceManager.GetString("csNotFound", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a The database will change. The data saved in the old one will not be saved in the new one. The program will stop and the next time you run it, it will open with the new database..
        '''</summary>
        Friend Shared ReadOnly Property dbChange() As String
            Get
                Return ResourceManager.GetString("dbChange", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Database change.
        '''</summary>
        Friend Shared ReadOnly Property dbChangeTitle() As String
            Get
                Return ResourceManager.GetString("dbChangeTitle", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a An error occurred while trying to connect to the database. Check the connection settings..
        '''</summary>
        Friend Shared ReadOnly Property dbErrorMsg() As String
            Get
                Return ResourceManager.GetString("dbErrorMsg", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Check the connection settings.
        '''</summary>
        Friend Shared ReadOnly Property dbErrorTitle() As String
            Get
                Return ResourceManager.GetString("dbErrorTitle", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a You will change the database connection settings. The program will stop and the next time you run it, it will connect to the database with the new settings..
        '''</summary>
        Friend Shared ReadOnly Property dbSettingsChange() As String
            Get
                Return ResourceManager.GetString("dbSettingsChange", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Database connection settings change.
        '''</summary>
        Friend Shared ReadOnly Property dbSettingsChangeTitle() As String
            Get
                Return ResourceManager.GetString("dbSettingsChangeTitle", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Different from.
        '''</summary>
        Friend Shared ReadOnly Property DifferentFrom() As String
            Get
                Return ResourceManager.GetString("DifferentFrom", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Edit a Guest - Gesalt.
        '''</summary>
        Friend Shared ReadOnly Property editGuestTitle() As String
            Get
                Return ResourceManager.GetString("editGuestTitle", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Edit an Lessor - Gesalt.
        '''</summary>
        Friend Shared ReadOnly Property editLessorTitle() As String
            Get
                Return ResourceManager.GetString("editLessorTitle", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Edit a Property - Gesalt.
        '''</summary>
        Friend Shared ReadOnly Property editPropTitle() As String
            Get
                Return ResourceManager.GetString("editPropTitle", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Enter correct data..
        '''</summary>
        Friend Shared ReadOnly Property EnterCorrectData() As String
            Get
                Return ResourceManager.GetString("EnterCorrectData", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Equal to.
        '''</summary>
        Friend Shared ReadOnly Property EqualTo() As String
            Get
                Return ResourceManager.GetString("EqualTo", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a An error occurred while connecting to the database. The Connection Wizard will open for you to check if the settings are correct..
        '''</summary>
        Friend Shared ReadOnly Property fatalErrorDB() As String
            Get
                Return ResourceManager.GetString("fatalErrorDB", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Fatal error.
        '''</summary>
        Friend Shared ReadOnly Property fatalErrorDBTitle() As String
            Get
                Return ResourceManager.GetString("fatalErrorDBTitle", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Accept advertising.
        '''</summary>
        Friend Shared ReadOnly Property fieldAcceptAd() As String
            Get
                Return ResourceManager.GetString("fieldAcceptAd", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Address.
        '''</summary>
        Friend Shared ReadOnly Property fieldAddress() As String
            Get
                Return ResourceManager.GetString("fieldAddress", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Baths.
        '''</summary>
        Friend Shared ReadOnly Property fieldBaths() As String
            Get
                Return ResourceManager.GetString("fieldBaths", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Bedrooms.
        '''</summary>
        Friend Shared ReadOnly Property fieldBedrooms() As String
            Get
                Return ResourceManager.GetString("fieldBedrooms", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Cadastral Ref..
        '''</summary>
        Friend Shared ReadOnly Property fieldCadRef() As String
            Get
                Return ResourceManager.GetString("fieldCadRef", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a City.
        '''</summary>
        Friend Shared ReadOnly Property fieldCity() As String
            Get
                Return ResourceManager.GetString("fieldCity", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Comments.
        '''</summary>
        Friend Shared ReadOnly Property fieldComments() As String
            Get
                Return ResourceManager.GetString("fieldComments", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Description.
        '''</summary>
        Friend Shared ReadOnly Property fieldDescription() As String
            Get
                Return ResourceManager.GetString("fieldDescription", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Email.
        '''</summary>
        Friend Shared ReadOnly Property fieldEmail() As String
            Get
                Return ResourceManager.GetString("fieldEmail", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a First Name.
        '''</summary>
        Friend Shared ReadOnly Property fieldFirstName() As String
            Get
                Return ResourceManager.GetString("fieldFirstName", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Last Name.
        '''</summary>
        Friend Shared ReadOnly Property fieldLastName() As String
            Get
                Return ResourceManager.GetString("fieldLastName", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Max. Guests.
        '''</summary>
        Friend Shared ReadOnly Property fieldMaxGuests() As String
            Get
                Return ResourceManager.GetString("fieldMaxGuests", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a NIF.
        '''</summary>
        Friend Shared ReadOnly Property fieldNif() As String
            Get
                Return ResourceManager.GetString("fieldNif", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Logo.
        '''</summary>
        Friend Shared ReadOnly Property fieldPathLogo() As String
            Get
                Return ResourceManager.GetString("fieldPathLogo", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Phone.
        '''</summary>
        Friend Shared ReadOnly Property fieldPhone() As String
            Get
                Return ResourceManager.GetString("fieldPhone", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Province/Country.
        '''</summary>
        Friend Shared ReadOnly Property fieldProvince() As String
            Get
                Return ResourceManager.GetString("fieldProvince", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Rating.
        '''</summary>
        Friend Shared ReadOnly Property fieldRating() As String
            Get
                Return ResourceManager.GetString("fieldRating", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a This field is required.
        '''</summary>
        Friend Shared ReadOnly Property fieldRequired() As String
            Get
                Return ResourceManager.GetString("fieldRequired", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Size.
        '''</summary>
        Friend Shared ReadOnly Property fieldSize() As String
            Get
                Return ResourceManager.GetString("fieldSize", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Type.
        '''</summary>
        Friend Shared ReadOnly Property fieldType() As String
            Get
                Return ResourceManager.GetString("fieldType", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Zip Code.
        '''</summary>
        Friend Shared ReadOnly Property fieldZip() As String
            Get
                Return ResourceManager.GetString("fieldZip", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a AND.
        '''</summary>
        Friend Shared ReadOnly Property filterAnd() As String
            Get
                Return ResourceManager.GetString("filterAnd", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Guest don&apos;t accept ad.
        '''</summary>
        Friend Shared ReadOnly Property filterGuestAcceptAdFalse() As String
            Get
                Return ResourceManager.GetString("filterGuestAcceptAdFalse", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Guest accept ad.
        '''</summary>
        Friend Shared ReadOnly Property filterGuestAcceptAdTrue() As String
            Get
                Return ResourceManager.GetString("filterGuestAcceptAdTrue", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Guests:.
        '''</summary>
        Friend Shared ReadOnly Property filterGuestsLabelOFF() As String
            Get
                Return ResourceManager.GetString("filterGuestsLabelOFF", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a FILTER.
        '''</summary>
        Friend Shared ReadOnly Property filterGuestsLabelON() As String
            Get
                Return ResourceManager.GetString("filterGuestsLabelON", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a &amp;Filter data.
        '''</summary>
        Friend Shared ReadOnly Property filterGuestsMenuOFF() As String
            Get
                Return ResourceManager.GetString("filterGuestsMenuOFF", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Clear &amp;filter.
        '''</summary>
        Friend Shared ReadOnly Property filterGuestsMenuON() As String
            Get
                Return ResourceManager.GetString("filterGuestsMenuON", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Lessor has no logo.
        '''</summary>
        Friend Shared ReadOnly Property filterLessorLogoFalse() As String
            Get
                Return ResourceManager.GetString("filterLessorLogoFalse", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Lessor has logo.
        '''</summary>
        Friend Shared ReadOnly Property filterLessorLogoTrue() As String
            Get
                Return ResourceManager.GetString("filterLessorLogoTrue", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Lessors:.
        '''</summary>
        Friend Shared ReadOnly Property filterLessorsLabelOFF() As String
            Get
                Return ResourceManager.GetString("filterLessorsLabelOFF", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a FILTER.
        '''</summary>
        Friend Shared ReadOnly Property filterLessorsLabelON() As String
            Get
                Return ResourceManager.GetString("filterLessorsLabelON", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a &amp;Filter data.
        '''</summary>
        Friend Shared ReadOnly Property filterLessorsMenuOFF() As String
            Get
                Return ResourceManager.GetString("filterLessorsMenuOFF", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Clear &amp;filter.
        '''</summary>
        Friend Shared ReadOnly Property filterLessorsMenuON() As String
            Get
                Return ResourceManager.GetString("filterLessorsMenuON", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a OR.
        '''</summary>
        Friend Shared ReadOnly Property filterOr() As String
            Get
                Return ResourceManager.GetString("filterOr", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Properties:.
        '''</summary>
        Friend Shared ReadOnly Property filterPropertiesLabelOFF() As String
            Get
                Return ResourceManager.GetString("filterPropertiesLabelOFF", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a FILTER.
        '''</summary>
        Friend Shared ReadOnly Property filterPropertiesLabelON() As String
            Get
                Return ResourceManager.GetString("filterPropertiesLabelON", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a &amp;Filter data.
        '''</summary>
        Friend Shared ReadOnly Property filterPropertiesMenuOFF() As String
            Get
                Return ResourceManager.GetString("filterPropertiesMenuOFF", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Clear &amp;filter.
        '''</summary>
        Friend Shared ReadOnly Property filterPropertiesMenuON() As String
            Get
                Return ResourceManager.GetString("filterPropertiesMenuON", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Gesalt is running for the first time. You must enter some data..
        '''</summary>
        Friend Shared ReadOnly Property firstTimeMsg() As String
            Get
                Return ResourceManager.GetString("firstTimeMsg", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Setup Wizard.
        '''</summary>
        Friend Shared ReadOnly Property firstTimeTitle() As String
            Get
                Return ResourceManager.GetString("firstTimeTitle", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Invalid filter data..
        '''</summary>
        Friend Shared ReadOnly Property InvalidFilterData() As String
            Get
                Return ResourceManager.GetString("InvalidFilterData", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Gesalt.
        '''</summary>
        Friend Shared ReadOnly Property msgTitle() As String
            Get
                Return ResourceManager.GetString("msgTitle", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a You must choose a database location.
        '''</summary>
        Friend Shared ReadOnly Property noDBMsg() As String
            Get
                Return ResourceManager.GetString("noDBMsg", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a JPG files (*.jpg)|*.jpg|All files (*.*)|*.*.
        '''</summary>
        Friend Shared ReadOnly Property ofdImageFilter() As String
            Get
                Return ResourceManager.GetString("ofdImageFilter", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a The operation couldn&apos;t be completed..
        '''</summary>
        Friend Shared ReadOnly Property opFailedMsg() As String
            Get
                Return ResourceManager.GetString("opFailedMsg", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Operation failed.
        '''</summary>
        Friend Shared ReadOnly Property opFailedTitle() As String
            Get
                Return ResourceManager.GetString("opFailedTitle", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a is going to be removed from the database. Are you sure?.
        '''</summary>
        Friend Shared ReadOnly Property rowRemovedMsg() As String
            Get
                Return ResourceManager.GetString("rowRemovedMsg", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a The property located on .
        '''</summary>
        Friend Shared ReadOnly Property rowRemovedPropMsg() As String
            Get
                Return ResourceManager.GetString("rowRemovedPropMsg", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Delete a row.
        '''</summary>
        Friend Shared ReadOnly Property rowRemovedTitle() As String
            Get
                Return ResourceManager.GetString("rowRemovedTitle", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Guests Report.
        '''</summary>
        Friend Shared ReadOnly Property rptGuestsHeaderTitle() As String
            Get
                Return ResourceManager.GetString("rptGuestsHeaderTitle", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Lessors Report.
        '''</summary>
        Friend Shared ReadOnly Property rptLessorsHeaderTitle() As String
            Get
                Return ResourceManager.GetString("rptLessorsHeaderTitle", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Properties Report.
        '''</summary>
        Friend Shared ReadOnly Property rptPropertiesHeaderTitle() As String
            Get
                Return ResourceManager.GetString("rptPropertiesHeaderTitle", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Starts with.
        '''</summary>
        Friend Shared ReadOnly Property StartsWith() As String
            Get
                Return ResourceManager.GetString("StartsWith", resourceCulture)
            End Get
        End Property
    End Class
End Namespace
