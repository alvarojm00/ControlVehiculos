Imports ControlVehiculos.Utils

Public Class Registro
    Inherits System.Web.UI.Page
    Protected dbHelper As New dbLogin()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnregistrar_Click(sender As Object, e As EventArgs)
        Dim nombreUsuario = txtUsuario.Text
        Dim Password = txtPassword.Text
        Dim PasswordC = txtConfirmarPassword.Text

        If Password <> PasswordC Then
            SwalUtils.ShowSwalError(Me, "No coincide la contraseña")
            Return
        End If

        Dim encryptador As Simple3Des = New Simple3Des("MiClaveSecreta123")  ' Clave para encriptar y desencriptar
        Dim pass As String = encryptador.EncryptData(Password) ' Encriptar la contraseña antes de guardarla
        Dim usuario As Usuario = New Usuario(nombreUsuario, pass, TextEmail.Text)

        Dim mensaje = dbHelper.RegisterUser(usuario)
        If mensaje.Contains("Error") Then
            SwalUtils.ShowSwalError(Me, "Error: ", mensaje)
        Else
            SwalUtils.ShowSwal(Me, mensaje)
        End If


    End Sub
End Class