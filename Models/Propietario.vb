Public Class Propietario
    Inherits Persona 'Hereda las propiedades de la clase persona'

    Private _IdPropietario As Integer
    Private _numVehiculos As String
    Private _IdPersona As Integer



    'Propiiedades'
    Public Property IdPropietario As Integer
        Get
            Return _IdPropietario
        End Get
        Set(value As Integer)
            _IdPropietario = value
        End Set
    End Property
    Public Property NumVehiculos As String
        Get
            Return _numVehiculos
        End Get
        Set(value As String)
            _numVehiculos = value
        End Set
    End Property

    Public Property IdPersona As Integer
        Get
            Return _IdPersona
        End Get
        Set(value As Integer)
            _IdPersona = value
        End Set
    End Property



    'Constructores'
    Public Sub New(idPropietario As Integer, numVehiculos As String, IdPersona As Integer)
        Me.IdPropietario = idPropietario
        Me.NumVehiculos = numVehiculos
        Me.IdPersona = IdPersona
    End Sub

    Public Sub New(idPropietario As Integer, numVehiculos As String, IdPersona As Integer, persona As Persona)
        MyBase.New(
            persona.IdPersona, persona.Nombre,
            persona.Apellido1, persona.Apellido2, persona.Nacionalidad,
            persona.FechaNacimiento, persona.Telefono
        )
        Me.IdPropietario = idPropietario
        Me.NumVehiculos = numVehiculos
        Me.IdPersona = IdPersona
    End Sub

    Public Sub New()
        MyBase.New() ' para la herencia'
    End Sub


End Class
