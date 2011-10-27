Option Explicit On
Option Strict On

Namespace Importer.AFA.Entities
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

        Public Sub New()
        End Sub
        Public Sub New(ByVal campeonato As Enums.Campeonatos, ByVal anio As Int32)
            m_Description = campeonato.ToString() & anio.ToString()
        End Sub
    End Class
End Namespace
