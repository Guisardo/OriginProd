Option Explicit On
Option Strict On

Namespace Importer.AFA.Entities
    Public Class Partido

        Private m_Torneo As Torneo
        Public Property Torneo() As Torneo
            Get
                Return m_Torneo
            End Get
            Set(ByVal value As Torneo)
                m_Torneo = value
            End Set
        End Property

        Private m_Fecha As Int32
        Public Property Fecha() As Int32
            Get
                Return m_Fecha
            End Get
            Set(ByVal value As Int32)
                m_Fecha = value
            End Set
        End Property

        Private m_Local As String
        Public Property Local() As String
            Get
                Return m_Local
            End Get
            Set(ByVal value As String)
                m_Local = value
            End Set
        End Property

        Private m_GolesLocal As Int32
        Public Property GolesLocal() As Int32
            Get
                Return m_GolesLocal
            End Get
            Set(ByVal value As Int32)
                m_GolesLocal = value
            End Set
        End Property

        Private m_GolesVisitante As Int32
        Public Property GolesVisitante() As Int32
            Get
                Return m_GolesVisitante
            End Get
            Set(ByVal value As Int32)
                m_GolesVisitante = value
            End Set
        End Property

        Private m_Visitante As String
        Public Property Visitante() As String
            Get
                Return m_Visitante
            End Get
            Set(ByVal value As String)
                m_Visitante = value
            End Set
        End Property

        Private m_Estadio As String
        Public Property Estadio() As String
            Get
                Return m_Estadio
            End Get
            Set(ByVal value As String)
                m_Estadio = value
            End Set
        End Property

        Private m_Arbitros As String
        Public Property Arbitros() As String
            Get
                Return m_Arbitros
            End Get
            Set(ByVal value As String)
                m_Arbitros = value
            End Set
        End Property

    End Class
End Namespace
