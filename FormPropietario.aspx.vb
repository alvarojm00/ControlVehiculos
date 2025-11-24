

Imports ControlVehiculos.Utils


Public Class FormPropietario
    Inherits System.Web.UI.Page

    Protected dbHelper As New dbPropietario()
    Protected dbHelperP As New dbPersona()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then ' significa que es la primera vez que se carga la página
            CargarPersonas()
        End If

    End Sub

    Public Sub CargarPersonas()
        ddlPersona.DataSource = dbHelperP.Consulta()
        ddlPersona.DataTextField = "NombreCompleto"
        ddlPersona.DataValueField = "IdPersona"
        ddlPersona.DataBind()
        ddlPersona.Items.Insert(0, New ListItem("-- Seleccione una persona --", "0"))
    End Sub

    Protected Sub btn_guardar_Click(sender As Object, e As EventArgs)
        Dim dbPropietario As New dbPropietario()
        Dim persona As New Persona()
        Try
            Dim idPersona As Integer = Convert.ToInt32(ddlPersona.SelectedValue)
            persona.IdPersona = idPersona
            Dim mensaje = dbPropietario.create(persona)
            If mensaje.Contains("Error") Then
                SwalUtils.ShowSwalError(Me, "Error ", mensaje)
            Else
                SwalUtils.ShowSwal(Me, mensaje)
            End If
            ddlPersona.SelectedIndex = 0
            GV_Propietarios.DataBind()
        Catch ex As Exception
            lbl_mensaje.Text = "Error al guardar el propietario: " & ex.Message
            SwalUtils.ShowSwalError(Me, "Error al guardar el propietario: " & ex.Message)
        End Try

    End Sub

    Protected Sub GV_Propietarios_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)


        'Eliminar propietario
        Try
            Dim id As Integer = Convert.ToInt32(GV_Propietarios.DataKeys(e.RowIndex).Value)
            ' Primero, obtener el IdPersona del propietario a eliminar
            Dim dbPropietario As New dbPropietario()
            Dim propietario = dbPropietario.GetById(id)
            If propietario IsNot Nothing Then
                Dim idPersona As Integer = propietario.IdPersona
                ' Eliminar el propietario
                Dim mensajePropietario = dbPropietario.delete(id)
                SwalUtils.ShowSwal(Me, mensajePropietario)
            Else
                SwalUtils.ShowSwalError(Me, "Error", "Propietario no encontrado.")
            End If
            e.Cancel = "True"
            GV_Propietarios.DataBind()
        Catch ex As Exception
            lbl_mensaje.Text = "Error al eliminar el propietario: " & ex.Message
            SwalUtils.ShowSwalError(Me, "Error al eliminar el propietario: " & ex.Message)
        End Try

    End Sub

    Protected Sub GV_Propietarios_RowEditing(sender As Object, e As GridViewEditEventArgs)

        GV_Propietarios.DataBind()
        GV_Propietarios.EditIndex = e.NewEditIndex

    End Sub

    Protected Sub GV_Propietarios_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)
        GV_Propietarios.EditIndex = -1
        GV_Propietarios.DataBind()
    End Sub

    Protected Sub GV_Propietarios_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        Dim fila As GridViewRow = GV_Propietarios.Rows(e.RowIndex)

        ' Buscar el DropDownList en la fila en edición
        Dim ddl As DropDownList = CType(fila.FindControl("ddlPersonaEdit"), DropDownList)

        ' Meter el valor elegido en los NewValues que usa el SqlDataSource
        e.NewValues("IdPersona") = ddl.SelectedValue
    End Sub

    Protected Sub GV_Propietarios_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Protected Sub GV_Propietarios_RowDataBound(sender As Object, e As GridViewRowEventArgs)

        If e.Row.RowType = DataControlRowType.DataRow Then '

            ' La columna Eliminar es la última:
            ' 0 = seleccionar, 1 = editar, 2 = IdPropietario, 3 = IdPersona, 4 = eliminar
            Dim btnDelete As LinkButton = TryCast(e.Row.Cells(3).Controls(0), LinkButton)

            If btnDelete IsNot Nothing AndAlso btnDelete.CommandName = "Delete" Then
                btnDelete.OnClientClick = "return confirmarBorrado(this);"
            End If
        End If

    End Sub


End Class