Imports ControlVehiculos.Utils

Public Class FormVehiculo
    Inherits System.Web.UI.Page
    Protected dbHelperP As New dbVehiculo()
    Public vehiculo As New Vehiculo()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then ' significa que es la primera vez que se carga la página
            GV_Vehiculos.DataBind()
        End If

    End Sub

    Protected Sub GV_Vehiculos_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)

        'Eliminar vehículo
        Try
            Dim id As Integer = Convert.ToInt32(GV_Vehiculos.DataKeys(e.RowIndex).Value)
            Dim mensaje = dbHelperP.DeleteVehiculo(id)

            If mensaje.Contains("Error") Then
                SwalUtils.ShowSwalError(Me, "Error ", mensaje)
            Else
                SwalUtils.ShowSwal(Me, mensaje)
            End If
            GV_Vehiculos.DataBind()
        Catch ex As Exception
            SwalUtils.ShowSwalError(Me, "Error al eliminar el vehículo: " & ex.Message)
        End Try


        'Try
        '    Dim id As Integer = Convert.ToInt32(GV_Propietarios.DataKeys(e.RowIndex).Value)
        '    ' Primero, obtener el IdPersona del propietario a eliminar

        '    Dim dbPropietario As New dbPropietario()
        '    Dim propietario = dbPropietario.GetById(id)

        '    If propietario IsNot Nothing Then
        '        Dim idPersona As Integer = propietario.IdPersona
        '        ' Eliminar el propietario
        '        Dim mensajePropietario = dbPropietario.delete(id)
        '        SwalUtils.ShowSwal(Me, mensajePropietario)
        '    Else
        '        SwalUtils.ShowSwalError(Me, "Error", "Propietario no encontrado.")
        '    End If
        '    e.Cancel = "True"
        '    GV_Propietarios.DataBind()
        'Catch ex As Exception
        '    lbl_mensaje.Text = "Error al eliminar el propietario: " & ex.Message
        '    SwalUtils.ShowSwalError(Me, "Error al eliminar el propietario: " & ex.Message)
        'End Try



    End Sub

    Protected Sub GV_Vehiculos_RowEditing(sender As Object, e As GridViewEditEventArgs)

        'Editar vehículo
        GV_Vehiculos.EditIndex = e.NewEditIndex
        GV_Vehiculos.DataBind()


    End Sub

    Protected Sub GV_Vehiculos_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)

    End Sub

    Protected Sub GV_Vehiculos_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)

        'Actualizar vehículo

        Try

            Dim id As Integer = Convert.ToInt32(GV_Vehiculos.DataKeys(e.RowIndex).Value)
            Dim vehiculo = New Vehiculo With {
                .Placa = e.NewValues("Placa"),
                .Marca = e.NewValues("Marca"),
                .Modelo = e.NewValues("Modelo"),
                .IdPropietario = e.NewValues("IdPropietario"),
                .IdVehiculo = id
            }

            Dim mensaje = dbHelperP.UpdateVehiculo(vehiculo)
            If mensaje.Contains("Error") Then
                SwalUtils.ShowSwalError(Me, "Error ", mensaje)
            Else
                SwalUtils.ShowSwal(Me, mensaje)
            End If

            GV_Vehiculos.DataBind()
            e.Cancel = True
            GV_Vehiculos.EditIndex = -1

        Catch ex As Exception

            SwalUtils.ShowSwalError(Me, "Error al actualizar vehiculo: " & ex.Message)

        End Try



    End Sub

    Protected Sub GV_Vehiculos_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Protected Sub GV_Vehiculos_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType <> DataControlRowType.DataRow Then Return

        ' Ciclo para encontrar el botón Eliminar en la fila actual
        For Each cell As TableCell In e.Row.Cells ' Recorre cada celda de la fila
            For Each ctl As Control In cell.Controls ' Recorre cada control dentro de la celda
                Dim lb As LinkButton = TryCast(ctl, LinkButton)     ' Intenta convertir el control a LinkButton para el botón Eliminar
                If lb IsNot Nothing AndAlso String.Equals(lb.CommandName, "Delete", StringComparison.OrdinalIgnoreCase) Then ' Verifica si es el botón Eliminar
                    lb.OnClientClick = "return confirmarBorrado(this);" ' Agrega el atributo OnClientClick para la confirmación de borrado
                    Exit For
                End If
            Next
        Next
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)

        'Guardar vehículo
        Try
            vehiculo.Placa = txtPlaca.Text
            vehiculo.Marca = txtMarca.Text
            vehiculo.Modelo = txtModelo.Text
            vehiculo.IdPropietario = Convert.ToInt32(ddlPropietario.SelectedValue)


            Dim mensaje = dbHelperP.AddVehiculo(vehiculo)


            If mensaje.Contains("Error") Then
                SwalUtils.ShowSwalError(Me, "Error ", mensaje)
            Else
                SwalUtils.ShowSwal(Me, mensaje)
            End If

            txtMarca.Text = ""
            txtPlaca.Text = ""
            txtModelo.Text = ""



            GV_Vehiculos.DataBind()

        Catch ex As Exception
            SwalUtils.ShowSwalError(Me, "Error al guardar vehiculo: " & ex.Message)

        End Try

    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs)

        'Cancelar acción de agregar vehículo
        txtMarca.Text = ""
        txtPlaca.Text = ""
        txtModelo.Text = ""

    End Sub
End Class