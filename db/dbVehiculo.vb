
Imports System.Data.SqlClient

Public Class dbVehiculo



    Private ReadOnly dbHelper = New DdHelper() ' Clase para manejar conexiones y consultas
    Public Function GetVehiculosByPropietario(idPropietario As String) As List(Of Vehiculo)
        Dim vehiculos As New List(Of Vehiculo)()
        Try
            Dim sql As String = "SELECT IdVehiculo, Marca, Modelo, Placa FROM Vehiculos WHERE IdPropietario = @IdPropietario"
            Dim Parametros As New List(Of SqlParameter) From {
                New SqlParameter("@IdPropietario", idPropietario)
            }
            Dim dt As DataTable = dbHelper.ExecuteQuery(sql, Parametros)
            For Each row As DataRow In dt.Rows
                Dim vehiculo As New Vehiculo() With {
                    .IdVehiculo = Convert.ToInt32(row("IdVehiculo")),
                    .Marca = row("Marca").ToString(),
                    .Modelo = row("Modelo").ToString(),
                    .Placa = row("Placa").ToString(),
                    .IdPropietario = idPropietario
                }
                vehiculos.Add(vehiculo)
            Next
        Catch ex As Exception
            ' Manejo de errores si es necesario
        End Try
        Return vehiculos
    End Function

    Public Function DeleteVehiculo(idVehiculo As Integer) As String
        Try
            Dim sql As String = "DELETE FROM Vehiculos WHERE IdVehiculo = @IdVehiculo"
            Dim Parametros As New List(Of SqlParameter) From {
                New SqlParameter("@IdVehiculo", idVehiculo)
            }
            dbHelper.ExecuteNonQuery(sql, Parametros)
            Return "Vehículo eliminado"
        Catch ex As Exception
            Return "Error al eliminar el vehículo: " & ex.Message
        End Try
    End Function

    Public Function UpdateVehiculo(vehiculo As Vehiculo) As String
        Try
            Dim sql As String = "UPDATE Vehiculos SET Marca = @Marca, Modelo = @Modelo, Placa = @Placa, IdPropietario = @IdPropietario  WHERE IdVehiculo = @IdVehiculo"
            Dim Parametros As New List(Of SqlParameter) From {
                New SqlParameter("@IdVehiculo", vehiculo.IdVehiculo),
                New SqlParameter("@Marca", vehiculo.Marca),
                New SqlParameter("@Modelo", vehiculo.Modelo),
                New SqlParameter("@Placa", vehiculo.Placa),
                New SqlParameter("@IdPropietario", vehiculo.IdPropietario)
            }
            dbHelper.ExecuteNonQuery(sql, Parametros)
            Return "Vehículo actualizado"
        Catch ex As Exception
            Return "Error al actualizar el vehículo: " & ex.Message
        End Try
    End Function

    Public Function AddVehiculo(vehiculo As Vehiculo) As String
        Try
            Dim sql As String = "INSERT INTO Vehiculos (IdPropietario, Marca, Modelo, Placa) VALUES (@IdPropietario, @Marca, @Modelo,@Placa)"
            Dim Parametros As New List(Of SqlParameter) From {
                New SqlParameter("@IdPropietario", vehiculo.IdPropietario),
                New SqlParameter("@Marca", vehiculo.Marca),
                New SqlParameter("@Modelo", vehiculo.Modelo),
                New SqlParameter("@Placa", vehiculo.Placa)
            }
            dbHelper.ExecuteNonQuery(sql, Parametros)
            Return "Vehículo agregado"
        Catch ex As Exception
            Return "Error al agregar el vehículo: " & ex.Message
        End Try
    End Function

    Public Function GetVehiculoById(idVehiculo As Integer) As Vehiculo
        Dim vehiculo As New Vehiculo()
        Try
            Dim sql As String = "SELECT IdVehiculo, IdPropietario, Marca, Modelo, Placa FROM Vehiculos WHERE IdVehiculo = @IdVehiculo"
            Dim Parametros As New List(Of SqlParameter) From {
                New SqlParameter("@IdVehiculo", idVehiculo)
            }
            Dim dt As DataTable = dbHelper.ExecuteQuery(sql, Parametros)
            If dt.Rows.Count > 0 Then
                Dim row As DataRow = dt.Rows(0)
                vehiculo.IdVehiculo = Convert.ToInt32(row("IdVehiculo"))
                vehiculo.IdPropietario = row("IdPropietario").ToString()
                vehiculo.Marca = row("Marca").ToString()
                vehiculo.Modelo = row("Modelo").ToString()
                vehiculo.Placa = row("Placa").ToString()
            End If
        Catch ex As Exception
            ' Manejo de errores si es necesario
        End Try
        Return vehiculo
    End Function

    Public Function GetAllVehiculos() As List(Of Vehiculo)
        Dim vehiculos As New List(Of Vehiculo)()
        Try
            Dim sql As String = "SELECT IdVehiculo, IdPropietario, Marca, Modelo, Placa FROM Vehiculos"
            Dim dt As DataTable = dbHelper.ExecuteQuery(sql, Nothing)
            For Each row As DataRow In dt.Rows
                Dim vehiculo As New Vehiculo() With {
                    .IdVehiculo = Convert.ToInt32(row("IdVehiculo")),
                    .IdPropietario = row("IdPropietario").ToString(),
                    .Marca = row("Marca").ToString(),
                    .Modelo = row("Modelo").ToString(),
                    .Placa = row("Placa").ToString()
                }
                vehiculos.Add(vehiculo)
            Next
        Catch ex As Exception
            ' Manejo de errores si es necesario
        End Try
        Return vehiculos
    End Function




End Class
