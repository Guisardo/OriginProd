Option Explicit On
Option Strict On

Namespace Origin.Entities
    Public Class Torneo

        Private m_Campeonato As Campeonato
        Public Property Campeonato() As Campeonato
            Get
                Return m_Campeonato
            End Get
            Set(ByVal value As Campeonato)
                m_Campeonato = value
            End Set
        End Property

        Private m_Description As String
        Public Property Description() As String
            Get
                Return m_Description
            End Get
            Set(ByVal value As String)
                m_Description = value
            End Set
        End Property

    End Class
End Namespace
