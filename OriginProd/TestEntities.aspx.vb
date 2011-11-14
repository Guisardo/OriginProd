Public Partial Class TestEntities
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim miEquipo As New OriginProd.Entities.Equipo
        Dim miPartido As New OriginProd.Entities.Partido
        Dim miArbitro As New OriginProd.Entities.Arbitro
        Dim miCamp As New OriginProd.Entities.Campeonato
        Dim miDiv As New OriginProd.Entities.Division

        miDiv.Nombre = "1ra Division"
        miDiv.Save()

        miArbitro.Nombre = "Baldasi"
        miArbitro.Save()

        miCamp.Nombre = "Apertura 2012"
        miCamp.Id_Division = miDiv.Id_Division
        miCamp.Save()

        miEquipo.Nombre = "River Plate"
        miEquipo.Save()

        miPartido.Id_EquipoLocal = miEquipo.Id_Equipo

        miEquipo = New OriginProd.Entities.Equipo()
        miEquipo.Nombre = "Boca Juniors"
        miEquipo.Save()

        miPartido.Id_EquipoVisitante = miEquipo.Id_Equipo
        miPartido.GolesLocales = 5
        miPartido.GolesVisitantes = 0
        miPartido.FechaNumero = 1
        miPartido.EsProde = True
        miPartido.Id_Arbitro = miArbitro.Id_Arbitro
        miPartido.Id_Campeonato = miCamp.Id_Campeonato
        miPartido.Save()

    End Sub

End Class