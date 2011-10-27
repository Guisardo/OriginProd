Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        OriginProd.Business.Origin.Managers.Parser.ParseFecha(12, Business.Origin.Enums.Torneos.primeraa, Business.Origin.Enums.Campeonatos.clausura, 2011)
    End Sub

End Class