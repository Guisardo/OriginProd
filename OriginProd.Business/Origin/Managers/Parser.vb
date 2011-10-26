Option Explicit On
Option Strict On

Imports System.Net
Imports System.IO

Namespace Origin.Managers
    Public Class Parser
        Public Shared Function ParseFecha(ByVal fecha As Int32, ByVal torneo As Enums.Torneos, ByVal campeonato As Enums.Campeonatos, ByVal anio As Int32) As List(Of Entities.Partido)

        End Function

        Public Shared Function GetResultadosAfa(ByVal torneo As Enums.Torneos, ByVal campeonato As Enums.Campeonatos, ByVal anio As Int32) As String
            Dim result As String = String.Empty

            Dim division As String = torneo.ToString()
            If anio <> DateTime.UtcNow.Year Then
                division += "/" & campeonato & anio
            End If
            If torneo = Enums.Torneos.argentinoa Or torneo = Enums.Torneos.argentinob Or torneo = Enums.Torneos.argentinoc Then
                division += "&condesc=no"
            End If

            'http://www.afa.org.ar/datafactory/estadisticas.php?division=primeraa&tipo=fix&condesc=si
            Dim realUrl As String = String.Format("http://www.afa.org.ar/datafactory/estadisticas.php?tipo=fix&division={0}", division)
            Dim loHttp As HttpWebRequest = Nothing
            Try
                'Establesco el request
                loHttp = DirectCast(WebRequest.Create(realUrl.ToString()), HttpWebRequest)
            Catch
                If Not Err.Description.Contains("(50") Then
                    Throw New WebException("Error calling: " & realUrl.ToString(), Err.GetException())
                End If
            End Try
            'Algunas propiedades para el request
            If loHttp IsNot Nothing Then
                loHttp.Timeout = 20 * 1000
                Dim loWebResponse As HttpWebResponse = Nothing
                Dim loResponseStream As StreamReader = Nothing
                Try
                    'Obtengo la cabecera
                    loWebResponse = DirectCast(loHttp.GetResponse(), HttpWebResponse)
                    'Obtengo la respuesta
                    loResponseStream = New StreamReader(loWebResponse.GetResponseStream())
                    result = loResponseStream.ReadToEnd()
                Catch
                    If Not Err.Description.Contains("(50") Then
                        Throw New WebException("Error reading: " & realUrl.ToString(), Err.GetException())
                    End If
                End Try
                'Cierro la conexión
                If loWebResponse IsNot Nothing Then
                    loWebResponse.Close()
                End If
                If loResponseStream IsNot Nothing Then
                    loResponseStream.Close()
                End If
            End If

            Return result
        End Function
    End Class
End Namespace
