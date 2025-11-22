Public Class SiteMaster
    Inherits MasterPage

    Protected Autenticado As Boolean = False
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        Dim Usuario As Usuario = Session("Usuario") ' Obtener la información del usuario desde la sesión")
        Autenticado = Usuario IsNot Nothing ' Verificar si el usuario está autenticado
        Dim esAdmin As Boolean = Usuario?.Rol = "2" ' Verificar si el usuario es administrador. el signo de interrogacion significa que si Usuario es nulo, no intente acceder a la propiedad Rol
        liAdmin.Visible = esAdmin ' Mostrar u ocultar el enlace de administración según el rol del usuario

    End Sub

    Protected Sub LogOut_Click(sender As Object, e As EventArgs)
        Session.Clear() ' Limpiar la sesión
        Session.Abandon() ' Abandonar la sesión
        Response.Redirect("Login.aspx") ' Redirigir al login
    End Sub
End Class