
Imports System.Data.SqlClient
Imports System.Configuration


Public Class dbPropietario



    Public ReadOnly ConectionString As String = ConfigurationManager.ConnectionStrings("ll-46ConnectionString").ConnectionString

    Dim dbHelper = New DdHelper() ' Clase manejar para manejar conexiones y comandos

    Public Function create(Persona As Persona) As String
        Try
            Dim sql As String = "INSERT INTO Propietarios (IdPersona) 
            VALUES (@IdPersona)"
            Dim Parametros As New List(Of SqlParameter) From {
            New SqlParameter("@IdPersona", Persona.IdPersona)
            }
            dbHelper.ExecuteNonQuery(sql, Parametros)
        Catch ex As Exception
            Return "Error al guardar el propietario: " & ex.Message
        End Try
        Return "Propietario Guardado"
    End Function

    Public Function delete(ByRef id As Integer) As String
        Try
            Dim sql As String = "DELETE FROM Propietarios WHERE idPropietario = @idPropietario"
            Dim Parametros As New List(Of SqlParameter) From {
                New SqlParameter("@idPropietario", id)
            }
            Using connetion As New SqlConnection(ConectionString)
                Using command As New SqlCommand(sql, connetion)
                    command.Parameters.AddRange(Parametros.ToArray())
                    connetion.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
            Return "Propietario eliminado"
        Catch ex As Exception
            Return "Error al eliminar el propietario: " & ex.Message
        End Try
    End Function


    Public Function GetById(ByRef id As Integer) As Propietario
        Dim propietario As New Propietario()
        Try
            Dim sql As String = "SELECT idPropietario, IdPersona FROM Propietarios WHERE idPropietario = @idPropietario"
            Dim Parametros As New List(Of SqlParameter) From {
                New SqlParameter("@idPropietario", id)
            }
            Using connetion As New SqlConnection(ConectionString)
                Using command As New SqlCommand(sql, connetion)
                    command.Parameters.AddRange(Parametros.ToArray())
                    connetion.Open()
                    Using reader As SqlDataReader = command.ExecuteReader()
                        If reader.Read() Then ' Si se encontró el propietario
                            propietario.IdPropietario = Convert.ToInt32(reader("idPropietario")) ' Asignar el IdPropietario
                            propietario.IdPersona = Convert.ToInt32(reader("IdPersona"))    ' Asignar el IdPersona
                        Else
                            Return Nothing ' No se encontró el propietario
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Return Nothing
        End Try
        Return propietario
    End Function


    Public Function update(ByRef Propietario As Propietario) As String
        Try
            Dim sql As String = "UPDATE Propietarios SET IdPersona = @IdPersona WHERE idPropietario = @idPropietario"
            Dim Parametros As New List(Of SqlParameter) From {
                New SqlParameter("@idPropietario", Propietario.IdPropietario),
                New SqlParameter("@IdPersona", Propietario.IdPersona)
            }
            Using connetion As New SqlConnection(ConectionString)
                Using command As New SqlCommand(sql, connetion)
                    command.Parameters.AddRange(Parametros.ToArray())
                    connetion.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
            Return "Propietario actualizado"
        Catch ex As Exception
            Return "Error al actualizar el propietario: " & ex.Message
        End Try
    End Function

    Public Function Consulta() As DataTable
        Try
            Dim sql As String = "SELECT p.idPropietario, p.IdPersona, 
            CONCAT(pe.Nombre,' ',pe.Apellido1,' ',pe.Apellido2) AS NombreCompleto
            FROM Propietarios p
            JOIN Personas pe ON p.IdPersona = pe.IdPersona" ' Consulta todas las personas llevando el nombre completo 
            Dim dt As DataTable = dbHelper.ExecuteDataTable(sql, Nothing)
            Return dt
        Catch ex As Exception
            Return New DataTable()
        End Try
    End Function


End Class
