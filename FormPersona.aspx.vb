Imports Persona.Models

Public Class FormPersona
    Inherits System.Web.UI.Page
    Public persona As New Persona()
    Protected dbHelper As New dbPersona()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_guardar_Click(sender As Object, e As EventArgs)
        Try
            persona.Nombre = txtNombre.Text
            persona.Apellido1 = txtApellido1.Text
            persona.Apellido2 = txtApellido2.Text
            persona.FechaNacimiento = txtfechaNacimiento.Text
            persona.Nacionalidad = txtNacionalidad.Text
            persona.Telefono = txtTelefono.Text

            lbl_mensaje.Text = dbHelper.create(persona)
            txtNombre.Text = ""
            txtApellido1.Text = ""
            txtApellido2.Text = ""
            txtfechaNacimiento.Text = ""



            GV_personas.DataBind()

        Catch ex As Exception
            lbl_mensaje.Text = "Error al guardar la persona: " & ex.Message

        End Try



    End Sub


    Protected Sub GV_personas_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)

        Try
            Dim id As Integer = Convert.ToInt32(GV_personas.DataKeys(e.RowIndex).Value)
            dbHelper.delete(id)
            e.Cancel = "True"
            GV_personas.DataBind()

        Catch ex As Exception
            lbl_mensaje.Text = "Error al eliminar la persona: " & ex.Message
        End Try

    End Sub

    Protected Sub GV_personas_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)

        GV_personas.EditIndex = -1
        GV_personas.DataBind()

    End Sub

    Protected Sub GV_personas_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)

        Dim id As Integer = Convert.ToInt32(GV_personas.DataKeys(e.RowIndex).Value)
        Dim persona As Persona = New Persona With {
            .Nombre = e.NewValues("Nombre"),
            .Apellido1 = e.NewValues("Apellido"),
            .Apellido2 = e.NewValues("Apellido"),
            .FechaNacimiento = e.NewValues("Edad"),
            .IdPersona = id
        }

        dbHelper.update(persona)
        GV_personas.DataBind()
        e.Cancel = True
        GV_personas.EditIndex = -1

    End Sub

    Protected Sub GV_personas_RowEditing(sender As Object, e As GridViewEditEventArgs)

    End Sub

    Protected Sub GV_personas_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim row As GridViewRow = GV_personas.SelectedRow()
        Dim id As Integer = Convert.ToInt32(row.Cells(2).Text)
        Dim persona As Persona = New Persona()

        txtNombre.Text = row.Cells(3).Text
        txtApellido1.Text = row.Cells(4).Text
        txtApellido2.Text = row.Cells(4).Text
        txtfechaNacimiento.Text = row.Cells(5).Text

        editando.Value = id

    End Sub

    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs)


        Dim persona As Persona = New Persona With {
            .Nombre = txtNombre.Text,
            .Apellido1 = txtApellido1.Text,
            .Apellido2 = txtApellido2.Text,
            .FechaNacimiento = txtfechaNacimiento.Text,
            .IdPersona = editando.Value()
        }
        dbHelper.update(persona)
        GV_personas.DataBind()
        GV_personas.EditIndex = -1



    End Sub
End Class