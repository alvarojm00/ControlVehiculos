
Imports ControlVehiculos.Utils
Imports Microsoft.VisualBasic.ApplicationServices

Public Class Login
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs)
        Dim Usuario As String = txtUsuario.Text
        Dim Password As String = txtPassword.Text
        Dim encryptador As New Simple3Des("MiClaveSecreta123")  ' Clave para encriptar y desencriptar
        Dim pass As String = encryptador.EncryptData(Password) ' Encriptar la contraseña antes de validarla
        Dim dbHelper As New dbLogin()
        Dim esValido As Boolean = dbHelper.ValidateLogin(Usuario, pass)
        If esValido Then
            ' Inicio de sesión exitoso
            Dim user As Usuario = dbHelper.GetUser(Usuario) ' Obtener y almacenar la información del usuario en la sesión

            Session("Usuario") = user ' Almacenar el objeto Usuario en la sesión

            If user.Rol = "2" Then
                Response.Redirect("Admin.aspx") ' Redirigir a la página de Administración
                Return
            End If
            Response.Redirect("Home.aspx") ' Redirigir a la página de inicio o dashboard

        Else
            ' Inicio de sesión fallido
            SwalUtils.ShowSwalError(Me, "Credenciales incorrectas", "Credenciales incorrectas")
        End If

    End Sub
End Class