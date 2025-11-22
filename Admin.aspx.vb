Public Class Admin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Usuario As Usuario = Session("Usuario") ' Obtener la información del usuario desde la sesión

        If Usuario Is Nothing Then
            ' Si no hay usuario en sesión o el rol no es de administrador, redirigir al login
            Response.Redirect("Login.aspx")
            Return
        End If

        If Usuario.Rol <> "2" Then
            ' Si el rol del usuario no es administrador, redirigir al login
            Response.Redirect("Home.aspx")
            Return
        End If

        lblUsuario.Text = "Bienvenido, " & Usuario.NombreUsuario ' Mostrar el nombre de usuario
        lblEmail.Text = "Email: " & Usuario.Email                   ' Mostrar el email del usuario
    End Sub

End Class