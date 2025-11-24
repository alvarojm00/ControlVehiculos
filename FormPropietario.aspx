<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FormPropietario.aspx.vb" Inherits="ControlVehiculos.FormPropietario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">




    <asp:HiddenField ID="editando" runat="server" />  <%--Indica si estamos en modo edición--%>

    <div class="Container d-flex flex-column mb-3 gap-2">

    <asp:DropDownList ID="ddlPersona" CssClass="flex-control" runat="server" >
        <asp:ListItem Text="Seleccione una persona" Value="" />
    </asp:DropDownList>

    <asp:Button ID="btn_guardar" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btn_guardar_Click" />

    <asp:Label ID="lbl_mensaje" runat="server" Text="Selecciona una persona"></asp:Label>

    </div>


    <asp:GridView ID="GV_Propietarios" runat="server" AutoGenerateColumns="False" DataKeyNames="idPropietario" DataSourceID="SqlDataSource" CssClass="table table-striped table-hover table-success"
        OnRowDeleting="GV_Propietarios_RowDeleting"
        OnRowEditing="GV_Propietarios_RowEditing"
        OnRowCancelingEdit="GV_Propietarios_RowCancelingEdit"
        OnRowUpdating="GV_Propietarios_RowUpdating"
        OnSelectedIndexChanged="GV_Propietarios_SelectedIndexChanged"
        OnRowDataBound="GV_Propietarios_RowDataBound">
    <Columns>
        <asp:CommandField ShowEditButton="True" ControlStyle-CssClass="btn btn-primary" />
        <asp:BoundField DataField="idPropietario" HeaderText="ID Propietario" SortExpression="idPropietario" ReadOnly="True" />
        
        <asp:TemplateField HeaderText="ID Persona">
    <ItemTemplate>
        <%# Eval("IdPersona") %>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:DropDownList ID="ddlPersonaEdit" runat="server"
            DataSourceID="SqlDataSourcePersonas"
            DataTextField="IdPersona"
            DataValueField="IdPersona"
            SelectedValue='<%# Bind("IdPersona") %>'>
        </asp:DropDownList>
    </EditItemTemplate>
</asp:TemplateField>

        <asp:CommandField ShowDeleteButton="true" ControlStyle-CssClass="btn btn-danger " />
    </Columns>

</asp:GridView>

<asp:SqlDataSource ID="SqlDataSource" runat="server"
    ConnectionString="<%$ ConnectionStrings:ll-46ConnectionString %>"
    SelectCommand="SELECT IdPropietario, IdPersona FROM Propietarios"
    UpdateCommand="UPDATE Propietarios 
                   SET IdPersona = @IdPersona 
                   WHERE IdPropietario = @IdPropietario">
    <UpdateParameters>
        <asp:Parameter Name="IdPersona" Type="Int32" />
        <asp:Parameter Name="IdPropietario" Type="Int32" />
    </UpdateParameters>
</asp:SqlDataSource>


<asp:SqlDataSource ID="SqlDataSourcePersonas" runat="server"
    ConnectionString="<%$ ConnectionStrings:ll-46ConnectionString %>"
    SelectCommand="SELECT IdPersona, Nombre FROM Personas">
</asp:SqlDataSource>




</asp:Content>
