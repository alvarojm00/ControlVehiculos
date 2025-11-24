<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FormVehiculo.aspx.vb" Inherits="ControlVehiculos.FormVehiculo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <h2>Formulario de Vehículo</h2>
    <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
    <asp:Panel ID="pnlFormulario" runat="server">
        <table>
            <tr>
                <td><asp:Label ID="lblMarca" runat="server" Text="Marca:"></asp:Label></td>
                <td><asp:TextBox ID="txtMarca" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblModelo" runat="server" Text="Modelo:"></asp:Label></td>
                <td><asp:TextBox ID="txtModelo" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblPlaca" runat="server" Text="Placa:"></asp:Label></td>
                <td><asp:TextBox ID="txtPlaca" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblIdPropietario" runat="server" Text="Propietario ID:"></asp:Label></td>
                <td>
                <asp:DropDownList ID="ddlPropietario" runat="server"
                    DataSourceID="SqlDataSourcePropietarios"
                    DataTextField="IdPropietario"
                    DataValueField="IdPropietario">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-primary" />
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn btn-primary"/>
                </td>
            </tr>
            
        </table>
    </asp:Panel>    


        <asp:GridView ID="GV_Vehiculos" runat="server" AutoGenerateColumns="False" DataKeyNames="IdVehiculo" DataSourceID="SqlDataSource" CssClass="table table-striped table-hover table-success"

            onRowDeleting="GV_Vehiculos_RowDeleting"
            onRowEditing="GV_Vehiculos_RowEditing"
            onRowCancelingEdit="GV_Vehiculos_RowCancelingEdit"
            onRowUpdating="GV_Vehiculos_RowUpdating"
            onSelectedIndexChanged="GV_Vehiculos_SelectedIndexChanged"
            onRowDataBound="GV_Vehiculos_RowDataBound">

            <Columns>
                <asp:CommandField ShowEditButton="True" ControlStyle-CssClass="btn btn-primary" />
                <asp:BoundField DataField="IdVehiculo" HeaderText="ID Vehiculo" SortExpression="IdVehiculo" ReadOnly="True" />
                <asp:BoundField DataField="Placa" HeaderText="Placa" SortExpression="Placa"  />
                <asp:BoundField DataField="Marca" HeaderText="Marca" SortExpression="Marca"  />
                <asp:BoundField DataField="Modelo" HeaderText="Modelo" SortExpression="Modelo"  />
        
                <asp:TemplateField HeaderText="ID Propietario">
            <ItemTemplate>
                <%# Eval("IdPropietario") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:DropDownList ID="ddlVehiculoEdit" runat="server"
                    DataSourceID="SqlDataSourcePropietarios"
                    DataTextField="IdPropietario"
                    DataValueField="IdPropietario"
                    SelectedValue='<%# Bind("IdPropietario") %>'>
                </asp:DropDownList>
            </EditItemTemplate>
        </asp:TemplateField>

                <asp:CommandField ShowDeleteButton="true" ControlStyle-CssClass="btn btn-danger " />
            </Columns>

        </asp:GridView>





        <asp:SqlDataSource ID="SqlDataSource" runat="server"
        ConnectionString="<%$ ConnectionStrings:ll-46ConnectionString %>"
        SelectCommand="SELECT IdVehiculo, Placa, Marca, Modelo, IdPropietario FROM Vehiculos"
        UpdateCommand="UPDATE Vehiculos 
                   SET Placa = @Placa, Marca = @Marca, Modelo = @Modelo, IdPropietario = @IdPropietario 
                   WHERE IdVehiculo = @IdVehiculo"
        DeleteCommand="DELETE FROM Vehiculos WHERE IdVehiculo = @IdVehiculo"
            >
            <UpdateParameters>
                <asp:Parameter Name="Placa" Type="String" />
                <asp:Parameter Name="Marca" Type="String" />
                <asp:Parameter Name="Modelo" Type="String" />
                <asp:Parameter Name="IdPropietario" Type="Int32" />
                <asp:Parameter Name="IdVehiculo" Type="Int32" />
                </UpdateParameters>
        
            <DeleteParameters>
                <asp:Parameter Name="IdVehiculo" Type="Int32" />
            </DeleteParameters>


        </asp:SqlDataSource>


        <asp:SqlDataSource ID="SqlDataSourcePropietarios" runat="server"
            ConnectionString="<%$ ConnectionStrings:ll-46ConnectionString %>"
            SelectCommand="SELECT IdPropietario FROM Propietarios">
        </asp:SqlDataSource>





</asp:Content>
