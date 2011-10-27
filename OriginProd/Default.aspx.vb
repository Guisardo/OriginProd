Option Explicit On
Option Strict On

Imports OriginProd.Business.Importer.AFA

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Managers.Parser.ParseFecha(12, Enums.Torneos.primeraa, Enums.Campeonatos.clausura, 2011)
    End Sub

End Class