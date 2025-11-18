Public Class Admin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Usuario As Usuario = Session("Usuario") ' Obtener la información del usuario desde la sesión

        lblUsuario.Text = "Bienvenido, " & Usuario.NombreUsuario ' Mostrar el nombre de usuario
        lblEmail.Text = "Email: " & Usuario.Email                   ' Mostrar el email del usuario
    End Sub

End Class