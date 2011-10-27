Option Explicit On
Option Strict On

Imports System.Net
Imports System.IO
Imports System.Text.RegularExpressions

Namespace Origin.Managers
    Public Class Parser
        Public Shared Function ParseFecha(ByVal fecha As Int32, ByVal torneo As Enums.Torneos, ByVal campeonato As Enums.Campeonatos, ByVal anio As Int32) As List(Of Entities.Partido)
            Dim result As New List(Of Entities.Partido)()
            Dim torneoAfa As String = GetResultadosAfa(torneo, campeonato, anio)
            Dim fechaAfa As String

            fechaAfa = Regex.Match(torneoAfa, String.Format("<td colspan=""2"" align=""center"">Fecha {0}</td>.+?</table>", fecha), RegexOptions.Singleline).Value

            Dim newTorneo As New Entities.Torneo(torneo, campeonato, anio)
            Dim RegexObj As New Regex("<td class=""local"">(?<local>.+?)</td>.+?<td class=""gol"">(?<local_goles>.+?)</td>.+?<td class=""gol"">(?<visitante_goles>.+?)</td>.+?<td class=""visitante"">(?<visitante>.+?)</td>.+?<td class=""estado""><strong>(?<estado>.+?)</strong></td>.+?<td class=""estadio"">(?<estadio>.+?)</td>.+?<td class=""arbitro"">(?<arbitro>.+?)</td>", RegexOptions.Singleline)
            Dim MatchesResults As MatchCollection = RegexObj.Matches(fechaAfa)
            For Each MatchResult As Match In MatchesResults
                If MatchResult.Groups("estado").Value = "Finalizado" Then
                    Dim newPartido As New Entities.Partido()

                    newPartido.Torneo = newTorneo
                    newPartido.Fecha = fecha
                    newPartido.Local = MatchResult.Groups("local").Value
                    newPartido.Visitante = MatchResult.Groups("visitante").Value
                    newPartido.GolesLocal = Convert.ToInt32(MatchResult.Groups("local_goles").Value)
                    newPartido.GolesVisitante = Convert.ToInt32(MatchResult.Groups("visitante_goles").Value)
                    newPartido.Estadio = MatchResult.Groups("estadio").Value
                    newPartido.Arbitros = MatchResult.Groups("arbitro").Value
                    result.Add(newPartido)
                End If
            Next
            Return result
        End Function

        Private Shared Function GetResultadosAfa(ByVal torneo As Enums.Torneos, ByVal campeonato As Enums.Campeonatos, ByVal anio As Int32) As String
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
                    loResponseStream = New StreamReader(loWebResponse.GetResponseStream(), Text.Encoding.GetEncoding("latin1"))
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
