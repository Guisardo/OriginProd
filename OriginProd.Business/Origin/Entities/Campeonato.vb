Option Explicit On
Option Strict On

Namespace Origin.Entities
    Public Class Campeonato

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
